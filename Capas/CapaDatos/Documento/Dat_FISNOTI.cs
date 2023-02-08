using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using CEntidadC = CapaEntidad.DOC.Ent_FISNOTI;
using CEntidadP = CapaEntidad.DOC.Ent_Persona;
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_FISNOTI
    {
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> RegMostrarFISNOTIInf_Buscar(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabaNotificacion(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidadC oCamposDet;
            CEntidadP oCamposDetP;
            CEntidadP notificado = new CEntidadP();

            if (oCEntidad.ENT_NOTIFICADO != null)
            {
                notificado.ListCorreo = oCEntidad.ENT_NOTIFICADO.tbCorreo;
                notificado.ListTelefono = oCEntidad.ENT_NOTIFICADO.tbTelefono;
                oCEntidad.ENT_NOTIFICADO = null;
            }
            
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTIGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    //     OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número  de la Notificación  ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Notificación existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar esta notificación");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado

                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_FISNOTI = OUTPUTPARAM01;
                }
                //  Eliminando Detalle        
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_FISNOTI = OUTPUTPARAM01;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_ILEGAL = loDatos.COD_ILEGAL;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTILEliminarDetalle", oCamposDet);

                    }
                }
                //Grabando Detalle Inicio PAU 
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_FISNOTI = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;

                            loDatos.COD_RESODIREC = (loDatos.COD_RESODIREC == null) ? "" : loDatos.COD_RESODIREC;
                            loDatos.COD_RESODIREC_INI_PAU = (loDatos.COD_RESODIREC_INI_PAU == null) ? "" : loDatos.COD_RESODIREC_INI_PAU;
                            loDatos.COD_INFORME = (loDatos.COD_INFORME == null) ? "" : loDatos.COD_INFORME;
                            loDatos.COD_ILEGAL = (loDatos.COD_ILEGAL == null) ? "" : loDatos.COD_ILEGAL;

                            if (loDatos.COD_RESODIREC != "" && loDatos.COD_RESODIREC_INI_PAU != "")
                            {
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOT_DET_EXPADM_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_RESODIREC != "")
                            {
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTI_DET_RD_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != "")
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTI_DET_INFORME_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_ILEGAL != "")
                            {
                                oCamposDet.COD_ILEGAL = loDatos.COD_ILEGAL;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTI_DET_ILEGAL_Grabar", oCamposDet);
                            }
                        }
                    }
                }

                if (notificado.ListTelefono != null)
                {
                    foreach (var itemTel in notificado.ListTelefono)
                    {
                        oCamposDetP = new CEntidadP();
                        oCamposDetP.COD_PERSONA = oCEntidad.COD_TITULAR;
                        oCamposDetP.COD_SECUENCIAL = itemTel.COD_SECUENCIAL;
                        oCamposDetP.COD_TTELEFONO = itemTel.COD_TTELEFONO;
                        oCamposDetP.NUMERO = itemTel.NUMERO;
                        oCamposDetP.ANEXO = itemTel.ANEXO;
                        oCamposDetP.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDetP.RegEstado = itemTel.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_TELEFONOGrabar", oCamposDetP);
                    }
                }
                if (notificado.ListCorreo != null)
                {
                    foreach (var itemCor in notificado.ListCorreo)
                    {
                        oCamposDetP = new CEntidadP();
                        oCamposDetP.COD_PERSONA = oCEntidad.COD_TITULAR;
                        oCamposDetP.COD_SECUENCIAL = itemCor.COD_SECUENCIAL;
                        oCamposDetP.COD_TCORREO = itemCor.COD_TCORREO;
                        oCamposDetP.CORREO = itemCor.CORREO;
                        oCamposDetP.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDetP.NOTIFICAR = itemCor.NOTIFICAR;
                        oCamposDetP.RegEstado = itemCor.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_CORREOGrabar", oCamposDetP);
                    }
                }


                tr.Commit();

                #region [Actualiza DB de SQL]
                {
                    //Setear variables para que n se envien como parámetros
                    oCEntidad.COD_TITULAR = null;
                    oCEntidad.NINTERNET_TITULAR = -1;

                    //DBL_STD
                    tr = null;
                    tr = cn.BeginTransaction();
                    try
                    {
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTIGrabarSQL_Std", oCEntidad))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                            tr.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        tr.Rollback();
                    }
                    tr = null;
                    tr = cn.BeginTransaction();
                    try
                    {
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTIGrabarSQL_Osinfor", oCEntidad))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                            tr.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        tr.Rollback();
                    }

                }
                #endregion

                return OUTPUTPARAM01 + '|' + OUTPUTPARAM02;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostrarListaFisnotiItem(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC lsCEntidad = new CEntidadC();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spFISNOTIMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidadC>();
                        lsCEntidad.ListEliTABLA = new List<CEntidadC>();
                        lsCEntidad.ENT_NOTIFICADO = new CapaEntidad.ViewModel.VM_Persona();
                        CEntidadC ocampoEnt2;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            lsCEntidad.NUMERO_NOTIFICACION = dr.GetString(dr.GetOrdinal("NUMERO_NOTIFICACION"));
                            lsCEntidad.COD_RECIBE_NOTIFICA = dr.GetString(dr.GetOrdinal("COD_RECIBE_NOTIFICA"));
                            lsCEntidad.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            //lsCEntidad.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.COD_PARENTESCO = dr.GetString(dr.GetOrdinal("COD_PARENTESCO"));
                            lsCEntidad.BUZON = dr.GetBoolean(dr.GetOrdinal("BUZON"));
                            lsCEntidad.ACTA_DISPENSA = dr.GetBoolean(dr.GetOrdinal("ACTA_DISPENSA"));
                            lsCEntidad.DJ_CAMBIO_DOMICILIO = dr.GetBoolean(dr.GetOrdinal("DJ_CAMBIO_DOMICILIO"));

                            lsCEntidad.DOCUMENTOS_ADJUNTOS = dr.GetString(dr.GetOrdinal("DOCUMENTOS_ADJUNTOS"));
                            lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            lsCEntidad.FECHA_NOTIFICA_TITULAR = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICA_TITULAR"));
                            lsCEntidad.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.DIRECCION = dr.GetString(dr.GetOrdinal("DIRECCION"));
                           
                            lsCEntidad.ENT_NOTIFICADO.rb_internet=dr.GetInt32(dr.GetOrdinal("NINTERNET"));
                            lsCEntidad.UBIGEOCAMBIO = dr.GetString(dr.GetOrdinal("UBIGEOCAMBIO"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.NOTIFICADOR = dr.GetString(dr.GetOrdinal("NOTIFICADOR"));
                            lsCEntidad.COD_NOTIFICADOR = dr.GetString(dr.GetOrdinal("COD_NOTIFICADOR"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.NOTIF_TITULAR = dr.GetBoolean(dr.GetOrdinal("NOTIF_TITULAR"));
                            lsCEntidad.COD_FENTIDAD = dr.GetString(dr.GetOrdinal("COD_FENTIDAD"));
                            lsCEntidad.FECHA_NOTIFICADOR = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICADOR"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.ID_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("ID_TRAMITE_SITD"));
                            //coactiva
                            lsCEntidad.IdEstadoCargo = dr.GetInt32(dr.GetOrdinal("IdEstadoCargo"));
                            lsCEntidad.FlagPrimeraVisita = dr.GetBoolean(dr.GetOrdinal("FlagPrimeraVisita"));
                            lsCEntidad.FechaPrimeraVisita = dr.GetString(dr.GetOrdinal("FechaPrimeraVisita"));
                            lsCEntidad.FlagSegundaVisita = dr.GetBoolean(dr.GetOrdinal("FlagSegundaVisita"));
                            lsCEntidad.FechaSegundaVisita = dr.GetString(dr.GetOrdinal("FechaSegundaVisita"));
                            lsCEntidad.FlagConformeRecepcion = dr.GetBoolean(dr.GetOrdinal("FlagConformeRecepcion"));
                            lsCEntidad.FlagSeNegoRecibir = dr.GetBoolean(dr.GetOrdinal("FlagSeNegoRecibir"));
                            lsCEntidad.FlagSeNegoFirmar = dr.GetBoolean(dr.GetOrdinal("FlagSeNegoFirmar"));
                            lsCEntidad.FlagBajoPuerta = dr.GetBoolean(dr.GetOrdinal("FlagBajoPuerta"));
                            lsCEntidad.MedidorAgua = dr.GetBoolean(dr.GetOrdinal("MedidorAgua"));
                            lsCEntidad.MedidorLuz = dr.GetBoolean(dr.GetOrdinal("MedidorLuz"));
                            lsCEntidad.NroMedidor = dr.GetString(dr.GetOrdinal("NroMedidor"));
                            lsCEntidad.MaterialColorFachada = dr.GetString(dr.GetOrdinal("MaterialColorFachada"));
                            lsCEntidad.MaterialColorPuerta = dr.GetString(dr.GetOrdinal("MaterialColorPuerta"));
                            lsCEntidad.NroPisos = dr.GetString(dr.GetOrdinal("NroPisos"));
                            lsCEntidad.CoordenadaUTM = dr.GetString(dr.GetOrdinal("CoordenadaUTM"));
                            lsCEntidad.TelefonoOtros = dr.GetString(dr.GetOrdinal("TelefonoOtros"));
                            lsCEntidad.FlagCambioDomicilio = dr.GetBoolean(dr.GetOrdinal("FlagCambioDomicilio"));
                            lsCEntidad.DireccionDeCambioDomicilio = dr.GetString(dr.GetOrdinal("DireccionDeCambioDomicilio"));
                            lsCEntidad.CodUbigeoCambioDomicilio = dr.GetString(dr.GetOrdinal("CodUbigeoCambioDomicilio"));
                            lsCEntidad.UrbanizacionDeCambioDomicilio = dr.GetString(dr.GetOrdinal("UrbanizacionDeCambioDomicilio"));
                            lsCEntidad.ReferenciaDeCambioDomicilio = dr.GetString(dr.GetOrdinal("ReferenciaDeCambioDomicilio"));
                            lsCEntidad.PARENTESCO = dr.GetString(dr.GetOrdinal("parentesco"));
                            lsCEntidad.ID_ORIGEN_REGISTRO = dr.GetInt32(dr.GetOrdinal("ID_ORIGEN_REGISTRO"));
                            lsCEntidad.FlagActaNotificacion = dr.GetBoolean(dr.GetOrdinal("FlagActaNotificacion"));
                            lsCEntidad.fdevolucionSEC = dr.GetString(dr.GetOrdinal("fdevolucionSEC"));
                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                        }
                        else
                        {
                            lsCEntidad.COD_ESTADO_DOC = "";
                            lsCEntidad.OBSERVACIONES_CONTROL = "";
                            lsCEntidad.OBSERV_SUBSANAR = false;
                            lsCEntidad.USUARIO_CONTROL = "";
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt2 = new CEntidadC();
                                ocampoEnt2.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
                                ocampoEnt2.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt2.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt2.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                ocampoEnt2.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt2.D_LINEA = dr["D_LINEA"].ToString();
                                ocampoEnt2.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt2.TITULAR = dr["TITULAR"].ToString();
                                ocampoEnt2.RegEstado = 0;
                                ocampoEnt2.COD_TITULAR = dr["COD_TITULAR"].ToString();
                                lsCEntidad.ListInformes.Add(ocampoEnt2);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.ESTADO_ARCHIVO = "0";
                            lsCEntidad.cCodificacion_SiTD = dr["cCodificacion_SiTD"].ToString();
                            lsCEntidad.NOMBRE_ARCHIVO = dr["nombreDescargar"].ToString();
                        }
                        

                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostCombo(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        List<CEntidadC> lsDetDetalle;
                        CEntidadC oCamposDet;
                        //
                        //Especies Maderable
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListParentesco = lsDetDetalle;
                        //Especies Fauna
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEntidades = lsDetDetalle;

                        //03 Estado Documento
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;

                        //04 Oficina Desconcentrada
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboOD = lsDetDetalle;
                        //05 Tipo de Carta de Notificación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoCNotificacion = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> ReporteFiscalizacionNotificacion(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteFiscalizacionNotificacion", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            string sColumn = "";

                            while (dr.Read())
                            {
                                sFila = new Dictionary<string, string>();
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    sColumn = dr.GetName(i);
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostrarFISNOTIInf_BuscarDatos(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC busqueda = new CEntidadC();
            busqueda.ListBusqueda = new List<CEntidadC>();

            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                busqueda.v_row_index = Int32.Parse(dr["TOTALROW"].ToString());
                            }
                        }
                    }
                }
                busqueda.ListBusqueda = lsCEntidad;
                return busqueda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
