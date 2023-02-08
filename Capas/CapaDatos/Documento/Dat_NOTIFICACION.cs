using GeneralSQL.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_NOTIFICACION;
using CEntSDetDevol = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
using CEntSDetMarable = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;

namespace CapaDatos.DOC
{
    public class Dat_NOTIFICACION
    {
        private SQL oGDataSQL = new SQL();

        //public CEntidad RegMostrarListaItem(CEntidad oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spFISNOTIMostrarItem_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        lsCEntidad.ListInforme = new List<CapaEntidad.DOC.Ent_INFORME_CONSULTA>();
        //                        lsCEntidad.ListExpediente = new List<CapaEntidad.DOC.Ent_RESODIREC_CONSULTA>();
        //                        lsCEntidad.ListResolucion = new List<CapaEntidad.DOC.Ent_RESODIREC_CONSULTA>();
        //                        lsCEntidad.ListILegal = new List<CapaEntidad.DOC.Ent_ILEGAL_CONSULTA>();
        //                        lsCEntidad.ListPoa = new List<CapaEntidad.DOC.Ent_POA_CONSULTA>();
        //                        lsCEntidad.ListDevolucionMadera = new List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA_CONSULTA>();

        //                        #region "Cargar datos generales"
        //                        dr.Read();
        //                        lsCEntidad.COD_FISNOTI = dr.GetString(dr.GetOrdinal("COD_FISNOTI"));
        //                        lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
        //                        lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
        //                        lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
        //                        lsCEntidad.NUMERO_NOTIFICACION = dr.GetString(dr.GetOrdinal("NUMERO_NOTIFICACION"));
        //                        lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
        //                        lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
        //                        lsCEntidad.FECHA_NOTIFICADOR = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICADOR"));
        //                        lsCEntidad.FECHA_NOTIFICA_TITULAR = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICA_TITULAR"));
        //                        lsCEntidad.COD_NOTIFICADOR = dr.GetString(dr.GetOrdinal("COD_NOTIFICADOR"));
        //                        lsCEntidad.NOTIFICADOR = dr.GetString(dr.GetOrdinal("NOTIFICADOR"));
        //                        lsCEntidad.TIPO_NOTIFICACION = dr.GetString(dr.GetOrdinal("TIPO_NOTIFICACION"));
        //                        lsCEntidad.NOTIF_TITULAR = dr.GetBoolean(dr.GetOrdinal("NOTIF_TITULAR"));
        //                        lsCEntidad.fdevolucionSEC = dr.GetString(dr.GetOrdinal("fdevolucionSEC"));
        //                        lsCEntidad.IdEstadoCargo = dr.GetInt32(dr.GetOrdinal("IdEstadoCargo"));
        //                        lsCEntidad.FlagPrimeraVisita = dr.GetBoolean(dr.GetOrdinal("FlagPrimeraVisita"));
        //                        lsCEntidad.FechaPrimeraVisita = dr.GetString(dr.GetOrdinal("FechaPrimeraVisita"));
        //                        lsCEntidad.FlagSegundaVisita = dr.GetBoolean(dr.GetOrdinal("FlagSegundaVisita"));
        //                        lsCEntidad.FechaSegundaVisita = dr.GetString(dr.GetOrdinal("FechaSegundaVisita"));
        //                        lsCEntidad.FlagConformeRecepcion = dr.GetBoolean(dr.GetOrdinal("FlagConformeRecepcion"));
        //                        lsCEntidad.FlagSeNegoRecibir = dr.GetBoolean(dr.GetOrdinal("FlagSeNegoRecibir"));
        //                        lsCEntidad.FlagSeNegoFirmar = dr.GetBoolean(dr.GetOrdinal("FlagSeNegoFirmar"));
        //                        lsCEntidad.FlagBajoPuerta = dr.GetBoolean(dr.GetOrdinal("FlagBajoPuerta"));
        //                        lsCEntidad.COD_PARENTESCO = dr.GetString(dr.GetOrdinal("COD_PARENTESCO"));
        //                        lsCEntidad.PARENTESCO = dr.GetString(dr.GetOrdinal("PARENTESCO"));
        //                        lsCEntidad.COD_RECIBE_NOTIFICA = dr.GetString(dr.GetOrdinal("COD_RECIBE_NOTIFICA"));
        //                        lsCEntidad.RECIBE_NOTIFICA = dr.GetString(dr.GetOrdinal("RECIBE_NOTIFICA"));
        //                        lsCEntidad.COD_FENTIDAD = dr.GetString(dr.GetOrdinal("COD_FENTIDAD"));
        //                        lsCEntidad.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
        //                        lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
        //                        lsCEntidad.DIRECCION = dr.GetString(dr.GetOrdinal("DIRECCION"));
        //                        lsCEntidad.FlagActaNotificacion = dr.GetBoolean(dr.GetOrdinal("FlagActaNotificacion"));
        //                        lsCEntidad.MedidorAgua = dr.GetBoolean(dr.GetOrdinal("MedidorAgua"));
        //                        lsCEntidad.MedidorLuz = dr.GetBoolean(dr.GetOrdinal("MedidorLuz"));
        //                        lsCEntidad.NroMedidor = dr.GetString(dr.GetOrdinal("NroMedidor"));
        //                        lsCEntidad.MaterialColorFachada = dr.GetString(dr.GetOrdinal("MaterialColorFachada"));
        //                        lsCEntidad.MaterialColorPuerta = dr.GetString(dr.GetOrdinal("MaterialColorPuerta"));
        //                        lsCEntidad.NroPisos = dr.GetString(dr.GetOrdinal("NroPisos"));
        //                        lsCEntidad.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
        //                        lsCEntidad.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
        //                        lsCEntidad.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
        //                        lsCEntidad.TelefonoOtros = dr.GetString(dr.GetOrdinal("TelefonoOtros"));
        //                        lsCEntidad.DJ_CAMBIO_DOMICILIO = dr.GetBoolean(dr.GetOrdinal("FlagCambioDomicilio"));
        //                        lsCEntidad.DireccionDeCambioDomicilio = dr.GetString(dr.GetOrdinal("DireccionDeCambioDomicilio"));
        //                        lsCEntidad.UrbanizacionDeCambioDomicilio = dr.GetString(dr.GetOrdinal("UrbanizacionDeCambioDomicilio"));
        //                        lsCEntidad.CodUbigeoCambioDomicilio = dr.GetString(dr.GetOrdinal("CodUbigeoCambioDomicilio"));
        //                        lsCEntidad.UbigeoCambioDomicilio = dr.GetString(dr.GetOrdinal("UbigeoCambioDomicilio"));
        //                        lsCEntidad.ReferenciaDeCambioDomicilio = dr.GetString(dr.GetOrdinal("ReferenciaDeCambioDomicilio"));
        //                        lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                        lsCEntidad.CODIFICACION_SITD = dr.GetString(dr.GetOrdinal("CODIFICACION_SITD"));
        //                        lsCEntidad.DOCUMENTO_CARGO = dr.GetString(dr.GetOrdinal("DOCUMENTO_CARGO"));
        //                        lsCEntidad.DIR_COINCIDE_DTITULAR = dr.GetBoolean(dr.GetOrdinal("DIR_COINCIDE_DTITULAR"));
        //                        lsCEntidad.FECHA_PSUPERVISION = dr.GetString(dr.GetOrdinal("FECHA_PSUPERVISION"));
        //                        lsCEntidad.MES_SUPERVISION = dr.GetString(dr.GetOrdinal("MES_SUPERVISION"));
        //                        lsCEntidad.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
        //                        lsCEntidad.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                        lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                        lsCEntidad.COD_NOTIFICACION_REF = dr.GetString(dr.GetOrdinal("COD_FISNOTI_REF"));
        //                        lsCEntidad.NUM_NOTIFICACION_REF = dr.GetString(dr.GetOrdinal("NUM_FISNOTI_REF"));
        //                        #endregion
        //                        #region "Control de calidad"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            dr.Read();
        //                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
        //                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
        //                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
        //                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
        //                        }
        //                        #endregion
        //                        #region "ListInforme"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            CapaEntidad.DOC.Ent_INFORME_CONSULTA entInforme;
        //                            while (dr.Read())
        //                            {
        //                                entInforme = new CapaEntidad.DOC.Ent_INFORME_CONSULTA();
        //                                entInforme.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
        //                                entInforme.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
        //                                entInforme.DLINEA = dr.GetString(dr.GetOrdinal("DLINEA"));
        //                                entInforme.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                                entInforme.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
        //                                entInforme.RegEstado = 0;
        //                                lsCEntidad.ListInforme.Add(entInforme);
        //                            }
        //                        }
        //                        #endregion
        //                        #region "ListExpediente"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            CapaEntidad.DOC.Ent_RESODIREC_CONSULTA entExp;
        //                            while (dr.Read())
        //                            {
        //                                entExp = new CapaEntidad.DOC.Ent_RESODIREC_CONSULTA();
        //                                entExp.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
        //                                entExp.COD_RESODIREC_INI_PAU = dr.GetString(dr.GetOrdinal("COD_RESODIREC_INI_PAU"));
        //                                entExp.COD_RPSECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_RPSECUENCIAL"));
        //                                entExp.NUM_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUM_EXPEDIENTE"));
        //                                entExp.DLINEA = dr.GetString(dr.GetOrdinal("DLINEA"));
        //                                entExp.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                                entExp.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
        //                                entExp.RegEstado = 0;
        //                                lsCEntidad.ListExpediente.Add(entExp);
        //                            }
        //                        }
        //                        #endregion
        //                        #region "ListResolucion"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            CapaEntidad.DOC.Ent_RESODIREC_CONSULTA entRes;
        //                            while (dr.Read())
        //                            {
        //                                entRes = new CapaEntidad.DOC.Ent_RESODIREC_CONSULTA();
        //                                entRes.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
        //                                entRes.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
        //                                entRes.DLINEA = dr.GetString(dr.GetOrdinal("DLINEA"));
        //                                entRes.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                                entRes.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
        //                                entRes.RegEstado = 0;
        //                                lsCEntidad.ListResolucion.Add(entRes);
        //                            }
        //                        }
        //                        #endregion
        //                        #region "ListILegal"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            CapaEntidad.DOC.Ent_ILEGAL_CONSULTA entIle;
        //                            while (dr.Read())
        //                            {
        //                                entIle = new CapaEntidad.DOC.Ent_ILEGAL_CONSULTA();
        //                                entIle.COD_ILEGAL = dr.GetString(dr.GetOrdinal("COD_ILEGAL"));
        //                                entIle.NUM_ILEGAL = dr.GetString(dr.GetOrdinal("NUM_ILEGAL"));
        //                                entIle.DLINEA = dr.GetString(dr.GetOrdinal("DLINEA"));
        //                                entIle.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                                entIle.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
        //                                entIle.RegEstado = 0;
        //                                lsCEntidad.ListILegal.Add(entIle);
        //                            }
        //                        }
        //                        #endregion
        //                        #region "ListPoa"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            CapaEntidad.DOC.Ent_POA_CONSULTA entPoa;
        //                            while (dr.Read())
        //                            {
        //                                entPoa = new CapaEntidad.DOC.Ent_POA_CONSULTA();
        //                                entPoa.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                                entPoa.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
        //                                entPoa.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
        //                                entPoa.ARESOLUCION_NUM = dr.GetString(dr.GetOrdinal("ARESOLUCION_NUM"));
        //                                entPoa.NUM_MUESTRA = dr.GetInt32(dr.GetOrdinal("NUM_MUESTRA"));
        //                                entPoa.RegEstado = 0;
        //                                lsCEntidad.ListPoa.Add(entPoa);
        //                            }
        //                        }
        //                        #endregion
        //                        #region "ListDevolucionMadera"
        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            CapaEntidad.DOC.Ent_DEVOLUCION_MADERA_CONSULTA entDev;
        //                            while (dr.Read())
        //                            {
        //                                entDev = new CapaEntidad.DOC.Ent_DEVOLUCION_MADERA_CONSULTA();
        //                                entDev.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                                entDev.COD_DEVOLUCION = dr.GetString(dr.GetOrdinal("COD_DEVOLUCION"));
        //                                entDev.FECHA_RESOLUCION = dr.GetString(dr.GetOrdinal("FECHA_RESOLUCION"));
        //                                entDev.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
        //                                entDev.RegEstado = 0;
        //                                lsCEntidad.ListDevolucionMadera.Add(entDev);
        //                            }
        //                        }
        //                        #endregion
        //                    }
        //                }
        //            }
        //        }

        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string RegGrabar(CEntidad oCEntidad)
        //{
        //    string OUTPUTPARAM01 = "";
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            #region "Grabar datos generales"
        //            using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, null, "DOC.spFISNOTIGrabar_v3", oCEntidad))
        //            {
        //                cmd.ExecuteNonQuery();
        //                OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;

        //                if (OUTPUTPARAM01 == "99")
        //                {
        //                    throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //                }
        //                else if (OUTPUTPARAM01 == "1")
        //                {
        //                    throw new Exception("El número de notificación existe en otro registro");
        //                }
        //            }
        //            oCEntidad.COD_FISNOTI = OUTPUTPARAM01;
        //            #endregion
        //            #region "ListEliTABLA"
        //            if (oCEntidad.ListEliTABLA != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_ELI oEli;
        //                foreach (var loDatos in oCEntidad.ListEliTABLA)
        //                {
        //                    oEli = new CapaEntidad.DOC.Ent_NOTIFICACION_ELI();
        //                    oEli.COD_FISNOTI = OUTPUTPARAM01;
        //                    oEli.EliTABLA = loDatos.EliTABLA;
        //                    oEli.COD_INFORME = loDatos.COD_INFORME;
        //                    oEli.COD_RESODIREC = loDatos.COD_RESODIREC;
        //                    oEli.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
        //                    oEli.COD_RPSECUENCIAL = loDatos.COD_RPSECUENCIAL;
        //                    oEli.COD_ILEGAL = loDatos.COD_ILEGAL;
        //                    oEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oEli.NUM_POA = loDatos.NUM_POA;
        //                    oEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    oGDataSQL.ManExecute(cn, null, "DOC.spFISNOTILEliminarDetalle_v3", oEli);
        //                }
        //            }
        //            #endregion
        //            #region "ListInforme"
        //            if (oCEntidad.ListInforme != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_INF oInf;
        //                foreach (var loDatos in oCEntidad.ListInforme)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo
        //                    {
        //                        oInf = new CapaEntidad.DOC.Ent_NOTIFICACION_INF();
        //                        oInf.COD_FISNOTI = OUTPUTPARAM01;
        //                        oInf.COD_INFORME = loDatos.COD_INFORME;
        //                        oInf.RegEstado = loDatos.RegEstado;
        //                        oGDataSQL.ManExecute(cn, null, "DOC.spFISNOTI_DET_INFORME_Grabar", oInf);
        //                    }
        //                }
        //            }
        //            #endregion
        //            #region "ListExpediente"
        //            if (oCEntidad.ListExpediente != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_EXP oExp;
        //                foreach (var loDatos in oCEntidad.ListExpediente)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo
        //                    {
        //                        oExp = new CapaEntidad.DOC.Ent_NOTIFICACION_EXP();
        //                        oExp.COD_FISNOTI = OUTPUTPARAM01;
        //                        oExp.COD_RESODIREC = loDatos.COD_RESODIREC;
        //                        oExp.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
        //                        oExp.COD_RPSECUENCIAL = loDatos.COD_RPSECUENCIAL;
        //                        oExp.RegEstado = loDatos.RegEstado;
        //                        oGDataSQL.ManExecute(cn, null, "DOC.spFISNOT_DET_EXPADM_Grabar", oExp);
        //                    }
        //                }
        //            }
        //            #endregion
        //            #region "ListResolucion"
        //            if (oCEntidad.ListResolucion != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_RES oRes;
        //                foreach (var loDatos in oCEntidad.ListResolucion)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo
        //                    {
        //                        oRes = new CapaEntidad.DOC.Ent_NOTIFICACION_RES();
        //                        oRes.COD_FISNOTI = OUTPUTPARAM01;
        //                        oRes.COD_RESODIREC = loDatos.COD_RESODIREC;
        //                        oRes.RegEstado = loDatos.RegEstado;
        //                        oGDataSQL.ManExecute(cn, null, "DOC.spFISNOTI_DET_RD_Grabar", oRes);
        //                    }
        //                }
        //            }
        //            #endregion
        //            #region "ListILegal"
        //            if (oCEntidad.ListILegal != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_ILE oIle;
        //                foreach (var loDatos in oCEntidad.ListILegal)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo
        //                    {
        //                        oIle = new CapaEntidad.DOC.Ent_NOTIFICACION_ILE();
        //                        oIle.COD_FISNOTI = OUTPUTPARAM01;
        //                        oIle.COD_ILEGAL = loDatos.COD_ILEGAL;
        //                        oIle.RegEstado = loDatos.RegEstado;
        //                        oGDataSQL.ManExecute(cn, null, "DOC.spFISNOTI_DET_ILEGAL_Grabar", oIle);
        //                    }
        //                }
        //            }
        //            #endregion
        //            #region "ListPoa"
        //            if (oCEntidad.ListPoa != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_POA oPoa;
        //                foreach (var loDatos in oCEntidad.ListPoa)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo
        //                    {
        //                        oPoa = new CapaEntidad.DOC.Ent_NOTIFICACION_POA();
        //                        oPoa.COD_FISNOTI = OUTPUTPARAM01;
        //                        oPoa.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                        oPoa.NUM_POA = loDatos.NUM_POA;
        //                        oGDataSQL.ManExecute(cn, null, "DOC.spCNOTIFICACION_VS_POA_Grabar_v3", oPoa);
        //                    }
        //                }
        //            }
        //            #endregion
        //            #region "ListDevolucionMadera"
        //            if (oCEntidad.ListDevolucionMadera != null)
        //            {
        //                CapaEntidad.DOC.Ent_NOTIFICACION_DEVMAD oDev;
        //                foreach (var loDatos in oCEntidad.ListDevolucionMadera)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo
        //                    {
        //                        oDev = new CapaEntidad.DOC.Ent_NOTIFICACION_DEVMAD();
        //                        oDev.COD_FISNOTI = OUTPUTPARAM01;
        //                        oDev.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                        oDev.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                        oGDataSQL.ManExecute(cn, null, "DOC.spCNOTIFICACION_VS_DEVOLUCION_Grabar_v3", oDev);
        //                    }
        //                }
        //            }
        //            #endregion
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return OUTPUTPARAM01;
        //}

        //public void RegInsertarCargoSITD(CapaEntidad.DOC.Ent_NOTIFICACION_CARGO oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            oGDataSQL.ManExecute(cn, null, "DOC.spFISNOTIGrabar_CargoSITD_v3", oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntSDetMarable> RegMostrarPoaDetMadCensoLista_v3(CEntSDetMarable oCEntidad)
        //{
        //    List<CEntSDetMarable> ListCEntSDetMarable = new List<CEntSDetMarable>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spPOA_DET_MADERABLE_CENSO_Listar_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        CEntSDetMarable oCampos;
        //                        Int32 num_fila = 0;
        //                        while (dr.Read())
        //                        {
        //                            oCampos = new CEntSDetMarable();
        //                            oCampos.NUMERO_FILA = num_fila;
        //                            oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                            oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
        //                            oCampos.POA = dr["POA"].ToString();
        //                            oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                            oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
        //                            oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                            oCampos.BLOQUE = dr["BLOQUE"].ToString();
        //                            oCampos.FAJA = dr["FAJA"].ToString();
        //                            oCampos.CODIGO = dr["CODIGO"].ToString();
        //                            oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
        //                            oCampos.DAP = Decimal.Parse(dr["DAP"].ToString());
        //                            oCampos.AC = Decimal.Parse(dr["AC"].ToString());
        //                            oCampos.DMC = Int32.Parse(dr["DMC"].ToString());
        //                            oCampos.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
        //                            oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
        //                            oCampos.ZONA = dr["ZONA"].ToString();
        //                            oCampos.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
        //                            oCampos.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
        //                            oCampos.CODIGO_GPS = dr["CODIGO_GPS"].ToString();
        //                            oCampos.COD_SISTEMA = dr["CODIGO_SISTEMA"].ToString();
        //                            oCampos.ESTADO_MUESTRA = Boolean.Parse(dr["ESTADO_MUESTRA"].ToString());
        //                            oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
        //                            oCampos.ESTADO_MUESTRA2 = Boolean.Parse(dr["ESTADO_MUESTRA2"].ToString());
        //                            oCampos.ESTADO_MUESTRA3 = Boolean.Parse(dr["ESTADO_MUESTRA3"].ToString());
        //                            oCampos.NUM_MUESTRA = Int32.Parse(dr["NUM_MUESTRA"].ToString());
        //                            oCampos.COD_FISNOTI = dr["COD_FISNOTI"].ToString();
        //                            oCampos.ESPECIES_ARESOLUCION = dr["ESPECIES_ARESOLUCION"].ToString();
        //                            oCampos.RegEstado = 0;
        //                            ListCEntSDetMarable.Add(oCampos);
        //                            num_fila++;
        //                        }
        //                    }
        //                }
        //            }
        //            return ListCEntSDetMarable;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetMarable> RegMostrarPoaDetNoMadCensoLista_v3(CEntSDetMarable oCEntidad)
        //{
        //    List<CEntSDetMarable> ListCEntSDetMarable = new List<CEntSDetMarable>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spPOA_DET_NOMADERABLE_CENSO_Listar_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        CEntSDetMarable oCampos;
        //                        Int32 num_fila = 0;
        //                        while (dr.Read())
        //                        {
        //                            oCampos = new CEntSDetMarable();
        //                            oCampos.NUMERO_FILA = num_fila;
        //                            oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                            oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
        //                            oCampos.POA = dr["POA"].ToString();
        //                            oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                            oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
        //                            oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                            oCampos.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
        //                            oCampos.CODIGO = dr["CODIGO"].ToString();
        //                            oCampos.DIAMETRO = Decimal.Parse(dr["DIAMETRO"].ToString());
        //                            oCampos.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
        //                            oCampos.PRODUCCION_LATAS = Decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
        //                            oCampos.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
        //                            oCampos.ZONA = dr["ZONA"].ToString();
        //                            oCampos.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
        //                            oCampos.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
        //                            oCampos.CODIGO_GPS = dr["CODIGO_GPS"].ToString();
        //                            oCampos.COD_SISTEMA = dr["CODIGO_SISTEMA"].ToString();
        //                            oCampos.ESTADO_MUESTRA = Boolean.Parse(dr["ESTADO_MUESTRA"].ToString());
        //                            oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
        //                            oCampos.ESTADO_MUESTRA2 = Boolean.Parse(dr["ESTADO_MUESTRA2"].ToString());
        //                            oCampos.ESTADO_MUESTRA3 = Boolean.Parse(dr["ESTADO_MUESTRA3"].ToString());
        //                            oCampos.NUM_MUESTRA = Int32.Parse(dr["NUM_MUESTRA"].ToString());
        //                            oCampos.COD_FISNOTI = dr["COD_FISNOTI"].ToString();
        //                            oCampos.ESPECIES_ARESOLUCION = dr["ESPECIES_ARESOLUCION"].ToString();
        //                            oCampos.RegEstado = 0;
        //                            num_fila++;
        //                            ListCEntSDetMarable.Add(oCampos);
        //                        }
        //                    }
        //                }
        //            }
        //            return ListCEntSDetMarable;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetDevol> RegMostrarDevolDetTrozaCensoLista_v3(CEntSDetDevol oCEntidad)
        //{
        //    List<CEntSDetDevol> ListCEntSDetDevol = new List<CEntSDetDevol>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spDEVOL_DET_TROZA_CENSO_Listar_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        CEntSDetDevol oCampos;
        //                        Int32 num_fila = 0;
        //                        while (dr.Read())
        //                        {
        //                            oCampos = new CEntSDetDevol();
        //                            oCampos.NUMERO_FILA = num_fila;
        //                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                            oCampos.COD_DEVOLUCION = dr.GetString(dr.GetOrdinal("COD_DEVOLUCION"));
        //                            oCampos.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
        //                            oCampos.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
        //                            oCampos.ESPECIES = dr.GetString(dr.GetOrdinal("DESC_ESPECIES"));
        //                            oCampos.DAP = Decimal.Parse(dr.GetString(dr.GetOrdinal("DAP")));
        //                            oCampos.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
        //                            oCampos.ALTURA = Decimal.Parse(dr.GetString(dr.GetOrdinal("ALTURA")));
        //                            oCampos.VOLUMEN = Decimal.Parse(dr.GetString(dr.GetOrdinal("VOLUMEN")));
        //                            oCampos.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
        //                            oCampos.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
        //                            oCampos.NUM_TROZAS = dr.GetInt32(dr.GetOrdinal("NUM_TROZAS"));
        //                            oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
        //                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                            oCampos.ESTADO_MUESTRA = dr.GetBoolean(dr.GetOrdinal("ESTADO_MUESTRA"));
        //                            oCampos.RegEstado = 0;
        //                            oCampos.CONDICION = "";
        //                            oCampos.DESC_ESPECIES = "";
        //                            num_fila++;
        //                            ListCEntSDetDevol.Add(oCampos);
        //                        }
        //                    }
        //                }
        //            }
        //            return ListCEntSDetDevol;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetDevol> RegMostrarDevolDetToconCensoLista_v3(CEntSDetDevol oCEntidad)
        //{
        //    List<CEntSDetDevol> ListCEntSDetDevol = new List<CEntSDetDevol>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spDEVOL_DET_TOCON_CENSO_Listar_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        CEntSDetDevol oCampos;
        //                        Int32 num_fila = 0;
        //                        while (dr.Read())
        //                        {
        //                            oCampos = new CEntSDetDevol();
        //                            oCampos.NUMERO_FILA = num_fila;
        //                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                            oCampos.COD_DEVOLUCION = dr.GetString(dr.GetOrdinal("COD_DEVOLUCION"));
        //                            oCampos.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
        //                            oCampos.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
        //                            oCampos.ESPECIES = dr.GetString(dr.GetOrdinal("DESC_ESPECIES"));
        //                            oCampos.CODIGO = dr.GetString(dr.GetOrdinal("DIAMETRO"));
        //                            oCampos.DIAMETRO = Decimal.Parse(dr.GetString(dr.GetOrdinal("CODIGO")));
        //                            oCampos.LARGO = Decimal.Parse(dr.GetString(dr.GetOrdinal("LARGO")));
        //                            oCampos.VOLUMEN = Decimal.Parse(dr.GetString(dr.GetOrdinal("VOLUMEN")));
        //                            oCampos.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
        //                            oCampos.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
        //                            oCampos.CANTIDAD = dr.GetInt32(dr.GetOrdinal("CANTIDAD"));
        //                            oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
        //                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                            oCampos.ESTADO_MUESTRA = dr.GetBoolean(dr.GetOrdinal("ESTADO_MUESTRA"));
        //                            oCampos.RegEstado = 0;
        //                            oCampos.CONDICION = "";
        //                            oCampos.DESC_ESPECIES = oCampos.ESPECIES;
        //                            num_fila++;
        //                            ListCEntSDetDevol.Add(oCampos);
        //                        }
        //                    }
        //                }
        //            }
        //            return ListCEntSDetDevol;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetDevol> RegMostrarDevolDetArbolCensoLista_v3(CEntSDetDevol oCEntidad)
        //{
        //    List<CEntSDetDevol> ListCEntSDetDevol = new List<CEntSDetDevol>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spDEVOL_DET_ARBOL_CENSO_Listar_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        CEntSDetDevol oCampos;
        //                        Int32 num_fila = 0;
        //                        while (dr.Read())
        //                        {
        //                            oCampos = new CEntSDetDevol();
        //                            oCampos.NUMERO_FILA = num_fila;
        //                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                            oCampos.COD_DEVOLUCION = dr.GetString(dr.GetOrdinal("COD_DEVOLUCION"));
        //                            oCampos.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
        //                            oCampos.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
        //                            oCampos.NUM_PCA = dr.GetString(dr.GetOrdinal("NUM_PCA"));
        //                            oCampos.ESPECIES = dr.GetString(dr.GetOrdinal("DESC_ESPECIES"));
        //                            oCampos.DAP = Decimal.Parse(dr.GetString(dr.GetOrdinal("DAP")));
        //                            oCampos.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
        //                            oCampos.ALTURA = Decimal.Parse(dr.GetString(dr.GetOrdinal("ALTURA")));
        //                            oCampos.VOLUMEN = Decimal.Parse(dr.GetString(dr.GetOrdinal("VOLUMEN")));
        //                            oCampos.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
        //                            oCampos.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
        //                            oCampos.COD_ECONDICION = dr.GetString(dr.GetOrdinal("COD_ECONDICION"));
        //                            oCampos.COD_EESTADO = dr.GetString(dr.GetOrdinal("COD_EESTADO"));
        //                            oCampos.CONDICION = dr.GetString(dr.GetOrdinal("CONDICION"));
        //                            oCampos.ESTADO = dr.GetString(dr.GetOrdinal("ESTADO"));
        //                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                            oCampos.ESTADO_MUESTRA = dr.GetBoolean(dr.GetOrdinal("ESTADO_MUESTRA"));
        //                            oCampos.RegEstado = 0;
        //                            oCampos.DESC_ESPECIES = oCampos.ESPECIES;
        //                            num_fila++;
        //                            ListCEntSDetDevol.Add(oCampos);
        //                        }
        //                    }
        //                }
        //            }
        //            return ListCEntSDetDevol;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Int32 RegInsertar_Maderable_Muestra_v3(CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetMarable oCamposDet;
        //    CapaEntidad.DOC.Ent_CNOTIFICACION CampoEli;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //Eliminar Total de la Muestra en un solo paso
        //            if (oCEntidad.ELIM_TOTAL_MUESTRA_M != null)
        //            {
        //                if ((Boolean)oCEntidad.ELIM_TOTAL_MUESTRA_M)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    CampoEli.COD_FISNOTI = oCEntidad.COD_FISNOTI;
        //                    CampoEli.EliTABLA = "POA_DET_MADERABLE";
        //                    CampoEli.ELIM_TOTAL_MUESTRA_M = oCEntidad.ELIM_TOTAL_MUESTRA_M;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }

        //            //ELIMINAR MUESTRAS
        //            if (oCEntidad.ListEliTABLACenso != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    CampoEli.NUM_POA = loDatos.NUM_POA;
        //                    CampoEli.COD_FISNOTI = loDatos.COD_FISNOTI;
        //                    CampoEli.EliTABLA = "POA_DET_MADERABLE";
        //                    CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }
        //            //Grabando Detalle THABILITANTE_DET_TITULARES
        //            if (oCEntidad.ListSDETMADERABLE_Muestra != null)
        //            {
        //                CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidadTemp = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                List<CapaEntidad.DOC.Ent_CNOTIFICACION> ListNUM_POA = new List<CapaEntidad.DOC.Ent_CNOTIFICACION>();
        //                foreach (var loDatos in oCEntidad.ListSDETMADERABLE_Muestra)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                    {
        //                        oCamposDet = new CEntSDetMarable();
        //                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                        oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                        oCamposDet.COD_FISNOTI = loDatos.COD_FISNOTI;
        //                        oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_MADERABLE_CENSO_Mod_Muestra_v3", oCamposDet);

        //                        if (oCEntidadTemp.NUM_POA != loDatos.NUM_POA)
        //                        {
        //                            oCEntidadTemp.NUM_POA = loDatos.NUM_POA;
        //                            CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidadTemp1 = new CapaEntidad.DOC.Ent_CNOTIFICACION();


        //                            oCEntidadTemp1.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                            oCEntidadTemp1.NUM_POA = loDatos.NUM_POA;
        //                            ListNUM_POA.Add(oCEntidadTemp1);
        //                        }

        //                    }
        //                }
        //                OUTPUTPARAM01 = 1;
        //                if (ListNUM_POA.Count > 0)
        //                {
        //                    List<CapaEntidad.DOC.Ent_CNOTIFICACION> listPOAsTemp = new List<CapaEntidad.DOC.Ent_CNOTIFICACION>();

        //                    listPOAsTemp = ListNUM_POA;
        //                    for (int j = 0; j < listPOAsTemp.Count; j++)
        //                    {
        //                        for (int k = 1; k < listPOAsTemp.Count - 1; k++)
        //                        {
        //                            if (listPOAsTemp[j].NUM_POA == listPOAsTemp[k].NUM_POA)
        //                            {
        //                                listPOAsTemp.Remove(listPOAsTemp[j]);
        //                            }
        //                        }
        //                    }


        //                    for (int i = 0; i < listPOAsTemp.Count; i++)
        //                    {
        //                        oCEntidadTemp = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                        oCEntidadTemp = ListNUM_POA[i];
        //                        oCEntidadTemp.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                        if (oCEntidadTemp.COD_THABILITANTE != "" && oCEntidadTemp.NUM_POA > -1 && oCEntidadTemp.COD_UCUENTA != "")
        //                        {
        //                            oGDataSQL.ManExecute(cn, tr, "DOC.zReporteCorreoMuestra", oCEntidadTemp);
        //                        }
        //                    }
        //                }

        //            }
        //            tr.Commit();
        //            return OUTPUTPARAM01;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
        //public Int32 RegInsertar_NoMaderable_Muestra_v3(CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetMarable oCamposDet;
        //    CapaEntidad.DOC.Ent_CNOTIFICACION CampoEli;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //Eliminar Total de la Muestra en un solo paso
        //            if (oCEntidad.ELIM_TOTAL_MUESTRA_NM != null)
        //            {
        //                if ((Boolean)oCEntidad.ELIM_TOTAL_MUESTRA_NM)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    CampoEli.COD_FISNOTI = oCEntidad.COD_FISNOTI;
        //                    CampoEli.EliTABLA = "POA_DET_NOMADERABLE";
        //                    CampoEli.ELIM_TOTAL_MUESTRA_NM = oCEntidad.ELIM_TOTAL_MUESTRA_NM;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }
        //            //Eliminar
        //            if (oCEntidad.ListEliTABLACenso != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    CampoEli.NUM_POA = loDatos.NUM_POA;
        //                    CampoEli.COD_FISNOTI = loDatos.COD_FISNOTI;
        //                    CampoEli.EliTABLA = "POA_DET_NOMADERABLE";
        //                    CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }
        //            OUTPUTPARAM01 = 1;
        //            //Grabando Detalle THABILITANTE_DET_TITULARES
        //            if (oCEntidad.ListSDETMADERABLE_Muestra != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListSDETMADERABLE_Muestra)
        //                {
        //                    //if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                    //{
        //                    oCamposDet = new CEntSDetMarable();
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_FISNOTI = loDatos.COD_FISNOTI;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_NOMADERABLE_CENSO_Mod_Muestra_v3", oCamposDet);
        //                    //}
        //                    OUTPUTPARAM01 = 1;
        //                }
        //            }
        //            tr.Commit();
        //            return OUTPUTPARAM01;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
        //public Int32 RegInsertar_DevolTroza_Muestra_v3(CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetDevol oCamposDet;
        //    CapaEntidad.DOC.Ent_CNOTIFICACION CampoEli;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //ELIMINAR MUESTRAS
        //            if (oCEntidad.ListEliTABLACenso != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    CampoEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    CampoEli.EliTABLA = "DEVOL_DET_TROZA";
        //                    CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }
        //            //Grabando Detalle THABILITANTE_DET_TITULARES
        //            if (oCEntidad.ListSDETDEVOLUCION_Muestra != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListSDETDEVOLUCION_Muestra)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                    {
        //                        oCamposDet = new CEntSDetDevol();
        //                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                        oCamposDet.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                        oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOL_DET_TROZA_CENSO_Mod_Muestra", oCamposDet);
        //                    }
        //                }
        //                OUTPUTPARAM01 = 1;
        //            }
        //            tr.Commit();
        //            return OUTPUTPARAM01;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
        //public Int32 RegInsertar_DevolTocon_Muestra_v3(CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetDevol oCamposDet;
        //    CapaEntidad.DOC.Ent_CNOTIFICACION CampoEli;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //ELIMINAR MUESTRAS
        //            if (oCEntidad.ListEliTABLACenso != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    CampoEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    CampoEli.EliTABLA = "DEVOL_DET_TOCON";
        //                    CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }
        //            //Grabando Detalle THABILITANTE_DET_TITULARES
        //            if (oCEntidad.ListSDETDEVOLUCION_Muestra != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListSDETDEVOLUCION_Muestra)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                    {
        //                        oCamposDet = new CEntSDetDevol();
        //                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                        oCamposDet.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                        oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOL_DET_TOCON_CENSO_Mod_Muestra", oCamposDet);
        //                    }
        //                }
        //                OUTPUTPARAM01 = 1;
        //            }
        //            tr.Commit();
        //            return OUTPUTPARAM01;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
        //public Int32 RegInsertar_DevolArbol_Muestra_v3(CapaEntidad.DOC.Ent_CNOTIFICACION oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetDevol oCamposDet;
        //    CapaEntidad.DOC.Ent_CNOTIFICACION CampoEli;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //ELIMINAR MUESTRAS
        //            if (oCEntidad.ListEliTABLACenso != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //                {
        //                    CampoEli = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //                    CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    CampoEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    CampoEli.EliTABLA = "DEVOL_DET_ARBOL";
        //                    CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra_v3", CampoEli);
        //                }
        //            }
        //            //Grabando Detalle THABILITANTE_DET_TITULARES
        //            if (oCEntidad.ListSDETDEVOLUCION_Muestra != null)
        //            {
        //                foreach (var loDatos in oCEntidad.ListSDETDEVOLUCION_Muestra)
        //                {
        //                    if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                    {
        //                        oCamposDet = new CEntSDetDevol();
        //                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                        oCamposDet.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                        oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOL_DET_ARBOL_CENSO_Mod_Muestra", oCamposDet);
        //                    }
        //                }
        //                OUTPUTPARAM01 = 1;
        //            }
        //            tr.Commit();
        //            return OUTPUTPARAM01;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}

        //public List<CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA> RegListarNotificacionConsulta_v3(CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA oCEntidad)
        //{
        //    List<CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA> olResult = new List<CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spFISNOTI_Consultar_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA oCampos;
        //                        while (dr.Read())
        //                        {
        //                            oCampos = new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA();
        //                            oCampos.COD_FISNOTI = dr["COD_FISNOTI"].ToString();
        //                            oCampos.NUM_NOTIFICACION = dr["NUM_NOTIFICACION"].ToString();
        //                            oCampos.COD_FCTIPO = dr["COD_FCTIPO"].ToString();
        //                            oCampos.FCTIPO = dr["FCTIPO"].ToString();
        //                            oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                            oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                            oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
        //                            oCampos.MTIPO = dr["MTIPO"].ToString();
        //                            oCampos.ESTADO_ORIGEN = dr["ESTADO_ORIGEN"].ToString();
        //                            oCampos.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
        //                            oCampos.COD_UBIGEO = dr["COD_UBIGEO"].ToString();
        //                            oCampos.UBIGEO = dr["UBIGEO"].ToString();
        //                            oCampos.SECTOR = dr["SECTOR"].ToString();
        //                            olResult.Add(oCampos);
        //                        }
        //                    }
        //                }
        //            }
        //            return olResult;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<Dictionary<string, string>> ReportesNotificacion(CEntidad oCEntidad)
        //{
        //    List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporteNotificacion_v3", oCEntidad))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        Dictionary<string, string> sFila;
        //                        string sColumn = "";

        //                        while (dr.Read())
        //                        {
        //                            sFila = new Dictionary<string, string>();
        //                            for (int i = 0; i < dr.FieldCount; i++)
        //                            {
        //                                sColumn = dr.GetName(i);
        //                                sFila.Add(sColumn, dr[sColumn].ToString());
        //                            }
        //                            lstResult.Add(sFila);
        //                        }
        //                    }
        //                }
        //            }
        //            return lstResult;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
