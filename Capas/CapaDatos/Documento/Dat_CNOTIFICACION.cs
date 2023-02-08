using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CEntidad = CapaEntidad.DOC.Ent_CNOTIFICACION;
using CEntSDetDevol = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
using CEntSDetMarable = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;
using CEntidadP = CapaEntidad.DOC.Ent_Persona;
//using SQL = GeneralSQL.Data.SQL;
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_CNOTIFICACION
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarLista(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    List<CEntidad> lsCEntidadCab = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    oCampos.ListNUM_POA = new List<CEntidad>();
        //    oCampos.ListNUM_DEVOL = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                CEntidad oCamposCab;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_CNOTIFICACION");
        //                    int p2 = dr.GetOrdinal("NUM_POA");
        //                    int p3 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p4 = dr.GetOrdinal("NUM_THABILITANTE");
        //                    int p5 = dr.GetOrdinal("NUMERO");
        //                    int p6 = dr.GetOrdinal("FECHA_EMISION");
        //                    int p7 = dr.GetOrdinal("PERSONA_NOTIFICADOR");
        //                    int p8 = dr.GetOrdinal("INDICADOR");
        //                    int p9 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    Int32 NumReg = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_CNOTIFICACION = dr.GetString(p1);
        //                        oCamposDet.NUM_POA = dr.GetInt32(p2);
        //                        oCamposDet.ESTADO_ORIGEN = dr.GetString(p9);

        //                        NumReg = (from p in lsCEntidadCab where p.COD_CNOTIFICACION == dr.GetString(p1) select p).Count();
        //                        if (NumReg == 0)
        //                        {
        //                            oCamposCab = new CEntidad();
        //                            oCamposCab.INDICADOR = dr.GetString(p8);
        //                            oCamposCab.COD_CNOTIFICACION = dr.GetString(p1);
        //                            oCamposCab.COD_THABILITANTE = dr.GetString(p3);
        //                            oCamposCab.NUM_THABILITANTE = dr.GetString(p4);
        //                            oCamposCab.NUMERO = dr.GetString(p5);
        //                            oCamposCab.FECHA_EMISION = dr.GetString(p6);
        //                            oCamposCab.PERSONA_NOTIFICADOR = dr.GetString(p7);
        //                            lsCEntidadCab.Add(oCamposCab);
        //                        }
        //                        lsCEntidad.Add(oCamposDet);
        //                    }
        //                    NumReg = 0;
        //                    foreach (var lsRegCNotificacion in lsCEntidadCab)
        //                    {
        //                        lsRegCNotificacion.ListNUM_POA = (from p in lsCEntidad where p.COD_CNOTIFICACION == lsRegCNotificacion.COD_CNOTIFICACION orderby p.NUM_POA select p).ToList<CEntidad>();
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidadCab;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr =dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCNOTIFICACION_Item", oCEntidad))
                {
                    lsCEntidad.ENT_NOTIFICADO = new CapaEntidad.ViewModel.VM_Persona();
                    if (dr != null)
                    {
                        //CEntPSupervision ocampodet;
                        lsCEntidad.ListNUM_POA = new List<CEntidad>();
                        lsCEntidad.ListNUM_DEVOL = new List<CEntidad>();
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();
                        //lsCEntidad.ListDetZAFRA = new List<CEntidad>();
                        lsCEntidad.ListDetMuestra = new List<CEntidad>();
                        CEntidad campo_poa;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.FECHA_PSUPERVISION = dr.GetString(dr.GetOrdinal("FECHA_PSUPERVISION"));
                            lsCEntidad.MES_SUPERVISION = dr.GetString(dr.GetOrdinal("MES_SUPERVISION"));
                            lsCEntidad.FECHA_NOTIFICADOR = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICADOR"));
                            lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            lsCEntidad.RNOTIFICACION_FECHA = dr.GetString(dr.GetOrdinal("RNOTIFICACION_FECHA"));
                            lsCEntidad.RNOTIFICACION_COD_PERSONA = dr.GetString(dr.GetOrdinal("RNOTIFICACION_COD_PERSONA"));
                            lsCEntidad.PERSONA_RNOTIFICACION = dr.GetString(dr.GetOrdinal("PERSONA_RNOTIFICACION"));
                            lsCEntidad.COD_PARENTESCO_RTITULAR = dr.GetString(dr.GetOrdinal("COD_PARENTESCO_RTITULAR"));
                            lsCEntidad.BUZON = dr.GetBoolean(dr.GetOrdinal("BUZON"));
                            lsCEntidad.LNOTIFI_COD_UBIGEO = dr.GetString(dr.GetOrdinal("LNOTIFI_COD_UBIGEO"));
                            lsCEntidad.LNOTIFI_UBIGEO = dr.GetString(dr.GetOrdinal("LNOTIFI_UBIGEO"));
                            lsCEntidad.LNOTIFI_DIRECCION = dr.GetString(dr.GetOrdinal("LNOTIFI_DIRECCION"));

                            lsCEntidad.LNOTIFI_COD_UBIGEO_ACTUAL = dr.GetString(dr.GetOrdinal("LNOTIFI_COD_UBIGEO_ACTUAL"));
                            lsCEntidad.LNOTIFI_UBIGEO_ACTUAL  = dr.GetString(dr.GetOrdinal("LNOTIFI_UBIGEO_ACTUAL"));
                            lsCEntidad.LNOTIFI_DIRECCION_ACTUAL = dr.GetString(dr.GetOrdinal("LNOTIFI_DIRECCION_ACTUAL"));
                            lsCEntidad.LNOTIFI_REFERENCIA_ACTUAL = dr.GetString(dr.GetOrdinal("LNOTIFI_REFERENCIA_ACTUAL"));

                            lsCEntidad.ENT_NOTIFICADO.rb_internet = dr.GetInt32(dr.GetOrdinal("NINTERNET"));
                            lsCEntidad.DIR_COINCIDE_DTITULAR = dr.GetBoolean(dr.GetOrdinal("DIR_COINCIDE_DTITULAR"));
                            lsCEntidad.COD_PERSONA_NOTIFICADOR = dr.GetString(dr.GetOrdinal("COD_PERSONA_NOTIFICADOR"));
                            lsCEntidad.PERSONA_NOTIFICADOR = dr.GetString(dr.GetOrdinal("PERSONA_NOTIFICADOR"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            
                            
                            //lsCEntidad.ESTAB_UBIGEO = dr.GetString(dr.GetOrdinal("ESTAB_UBIGEO"));
                            lsCEntidad.ARCHIVO = dr.GetString(dr.GetOrdinal("ARCHIVO"));
                            //Control de calidad
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));

                            lsCEntidad.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            lsCEntidad.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));

                            //Cambios: 15/12/2016
                            lsCEntidad.MAE_COD_CNTIPO = dr.GetString(dr.GetOrdinal("MAE_COD_CNTIPO"));
                            lsCEntidad.MAE_CNTIPO = dr.GetString(dr.GetOrdinal("MAE_CNTIPO"));
                            lsCEntidad.COD_CNOTIFICACION_REF = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION_REF"));
                            lsCEntidad.NUMERO_REF = dr.GetString(dr.GetOrdinal("NUMERO_REF"));

                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            lsCEntidad.COD_INFORME = dr["COD_INFORME"].ToString();
                            lsCEntidad.NUM_INFORME = dr["NUM_INFORME"].ToString();
                            lsCEntidad.ID_TRAMITE_SITD = Convert.ToInt32(dr["ID_TRAMITE_SITD"]);

                            /*lsCEntidad.PRIM_QUIN = dr.GetBoolean(dr.GetOrdinal("PRIM_QUIN"));
                            lsCEntidad.SEGUN_QUIN = dr.GetBoolean(dr.GetOrdinal("SEGUN_QUIN"));
                            lsCEntidad.TERC_QUIN = dr.GetBoolean(dr.GetOrdinal("TERC_QUIN"));
                            lsCEntidad.CUART_QUIN = dr.GetBoolean(dr.GetOrdinal("CUART_QUIN"));*/
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("NUM_POA");
                            int pt1 = dr.GetOrdinal("NUM_PCOMPLEMENTARIO");
                            int pt2 = dr.GetOrdinal("ESTADO_ORIGEN");
                            int pt3 = dr.GetOrdinal("ARESOLUCION_NUM");
                            int pt4 = dr.GetOrdinal("COD_PMANEJO");
                            while (dr.Read())
                            {
                                campo_poa = new CEntidad();
                                campo_poa.NUM_POA = dr.GetInt32(pt0);
                                campo_poa.NUM_PCOMPLEMENTARIO = dr.GetString(pt1);

                                campo_poa.ESTADO_ORIGEN = dr.GetString(pt2);
                                campo_poa.NUM_RESOLUCION = dr.GetString(pt3);
                                campo_poa.COD_PMANEJO = dr.GetString(pt4);
                                campo_poa.NUM_MUESTRA = dr.GetInt32(dr.GetOrdinal("NUM_MUESTRA"));
                                campo_poa.RegEstado = 0;
                                lsCEntidad.ListNUM_POA.Add(campo_poa);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_DEVOLUCION");
                            int pt1 = dr.GetOrdinal("FECHA_RESOLUCION");
                            int pt2 = dr.GetOrdinal("NUM_RESOLUCION");
                            while (dr.Read())
                            {
                                campo_poa = new CEntidad();
                                campo_poa.COD_DEVOLUCION = dr.GetString(pt0);
                                campo_poa.FECHA_RESOLUCION = dr.GetString(pt1);
                                campo_poa.NUM_RESOLUCION = dr.GetString(pt2);
                                lsCEntidad.ListNUM_DEVOL.Add(campo_poa);
                            }
                        }
                        dr.NextResult();
                        lsCEntidad.ENT_NOTIFICADO.tbTelefono = new List<Ent_Persona>();
                        lsCEntidad.ENT_NOTIFICADO.tbCorreo = new List<Ent_Persona>();
                        if (dr.HasRows)
                        {


                            while (dr.Read())
                            {
                                Ent_Persona oCamposDet = new Ent_Persona();
                                oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.COD_TTELEFONO = dr.GetString(dr.GetOrdinal("COD_TTELEFONO"));
                                oCamposDet.TIPO_TELEFONO = dr.GetString(dr.GetOrdinal("TIPO_TELEFONO"));
                                oCamposDet.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                                oCamposDet.ANEXO = dr.GetString(dr.GetOrdinal("ANEXO"));
                                oCamposDet.RegEstado = 0;
                                lsCEntidad.ENT_NOTIFICADO.tbTelefono.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Ent_Persona oCamposDet = new Ent_Persona();
                                oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.COD_TCORREO = dr.GetString(dr.GetOrdinal("COD_TCORREO"));
                                oCamposDet.TIPO_CORREO = dr.GetString(dr.GetOrdinal("TIPO_CORREO"));
                                oCamposDet.CORREO = dr.GetString(dr.GetOrdinal("CORREO"));
                                oCamposDet.NOTIFICAR = dr.GetBoolean(dr.GetOrdinal("NOTIFICAR"));
                                oCamposDet.TXT_NOTIFICAR = (dr.GetBoolean(dr.GetOrdinal("NOTIFICAR")) == true) ? "SI" : "NO";
                                oCamposDet.RegEstado = 0;
                                lsCEntidad.ENT_NOTIFICADO.tbCorreo.Add(oCamposDet);
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
        public String RegInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null/*, tr2 = null*/;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidadP notificado = new CEntidadP();
            notificado.ListCorreo = oCEntidad.ENT_NOTIFICADO.tbCorreo;
            notificado.ListTelefono = oCEntidad.ENT_NOTIFICADO.tbTelefono;
            oCEntidad.ENT_NOTIFICADO = null;
            CEntidad ocampo_poa;
            CEntidadP oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCNOTIFICACION_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de la Carta de Notificación ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de la Carta de Notificación Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar esta Carta de Notificación");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                    else if (OUTPUTPARAM01 == "999")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No existe Plan de Manejo");
                    }

                    //Eliminando Detalle Informe
                    if (oCEntidad.ListEliTABLA != null)
                    {
                        foreach (var loDatos in oCEntidad.ListEliTABLA)
                        {
                            ocampo_poa = new CEntidad();
                            ocampo_poa.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            ocampo_poa.COD_CNOTIFICACION = OUTPUTPARAM01;
                            ocampo_poa.NUM_POA = loDatos.NUM_POA;
                            ocampo_poa.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
                            ocampo_poa.COD_PMANEJO = loDatos.COD_PMANEJO;
                            ocampo_poa.EliTABLA = loDatos.EliTABLA;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCNOTIFICACION_DET_Eliminar", ocampo_poa);
                        }
                    }
                    if (oCEntidad.ListNUM_POA != null)
                    {
                        foreach (var loDatos in oCEntidad.ListNUM_POA)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                ocampo_poa = new CEntidad();
                                ocampo_poa.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                ocampo_poa.NUM_POA = loDatos.NUM_POA;
                                ocampo_poa.COD_PMANEJO = loDatos.COD_PMANEJO ?? "";
                                ocampo_poa.COD_ORIGEN = loDatos.COD_ORIGEN;
                                ocampo_poa.COD_CNOTIFICACION = OUTPUTPARAM01;
                                ocampo_poa.NUM_MUESTRA = loDatos.NUM_MUESTRA;
                                ocampo_poa.RegEstado = loDatos.RegEstado;
                                //oGDataSQL.ManExecute(cn, tr, "DOC.spCNOTIFICACION_VS_POA_Grabar", ocampo_poa);
                                using (OracleCommand cmd2 = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCNOTIFICACION_VS_POA_Grabar", ocampo_poa))
                                {
                                    cmd2.ExecuteNonQuery();
                                    OUTPUTPARAM02 = Convert.ToString(cmd2.Parameters["OUTPUTPARAM02"].Value).Trim();
                                    if (OUTPUTPARAM02 != "")
                                    {
                                        tr.Rollback();
                                        tr = null;
                                        if (ocampo_poa.NUM_MUESTRA == 1)
                                        { throw new Exception("Ya se ha registrado una 1ra supervisión a: " + OUTPUTPARAM02); }
                                        else if (ocampo_poa.NUM_MUESTRA == 2)
                                        { throw new Exception("Ya se ha registrado una 2da supervisión a: " + OUTPUTPARAM02); }
                                        else if (ocampo_poa.NUM_MUESTRA == 3)
                                        { throw new Exception("Ya se ha registrado una 3ra supervisión a: " + OUTPUTPARAM02); }
                                    }
                                }
                            }
                        }
                    }
                    if (oCEntidad.ListNUM_DEVOL != null)
                    {
                        CEntidad ocampo_devol;
                        foreach (var loDatos in oCEntidad.ListNUM_DEVOL)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                ocampo_devol = new CEntidad();
                                ocampo_devol.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                ocampo_devol.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
                                ocampo_devol.COD_CNOTIFICACION = OUTPUTPARAM01;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCNOTIFICACION_VS_DEVOLUCION_Grabar", ocampo_devol);
                            }
                        }
                    }
                }
               
                if (notificado.ListTelefono != null)
                {
                    foreach (var itemTel in notificado.ListTelefono)
                    {
                        oCamposDet = new CEntidadP();
                        oCamposDet.COD_PERSONA = oCEntidad.RNOTIFICACION_COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemTel.COD_SECUENCIAL;
                        oCamposDet.COD_TTELEFONO = itemTel.COD_TTELEFONO;
                        oCamposDet.NUMERO = itemTel.NUMERO;
                        oCamposDet.ANEXO = itemTel.ANEXO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = itemTel.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_TELEFONOGrabar", oCamposDet);
                    }
                }
                if (notificado.ListCorreo != null)
                {
                    foreach (var itemCor in notificado.ListCorreo)
                    {
                        oCamposDet = new CEntidadP();
                        oCamposDet.COD_PERSONA = oCEntidad.RNOTIFICACION_COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemCor.COD_SECUENCIAL;
                        oCamposDet.COD_TCORREO = itemCor.COD_TCORREO;
                        oCamposDet.CORREO = itemCor.CORREO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.NOTIFICAR = itemCor.NOTIFICAR;
                        oCamposDet.RegEstado = itemCor.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_CORREOGrabar", oCamposDet);
                    }
                }
                tr.Commit();
                if (oCEntidad.ID_TRAMITE_SITD > 0)
                {
                    tr = null;
                    tr = cn.BeginTransaction();
                    try
                    {
                        object[] paramO = { oCEntidad.COD_CNOTIFICACION };
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCNOTIFICACION_GRABAR_TRAMITE", paramO);
                        tr.Commit();
                    }
                    catch (Exception)
                    {                        
                        tr.Rollback();
                        throw new Exception("Sucedió un error al actualizar datos en tramite");
                    }
                }
                
                return OUTPUTPARAM01;
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
        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //Documento Identidad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //
                        //Parentesco
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboParentesco = lsDetDetalle;
                        //
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;
                        //Oficinas Desconcentradas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListODs = lsDetDetalle;
                        //Tipos de Notificación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoCN = lsDetDetalle;
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
        //public List<CEntidad> RegMostrarThabiliPoaLista(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p2 = dr.GetOrdinal("NUMERO");
        //                    int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int p4 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_THABILITANTE = dr.GetString(p1);
        //                        oCampos.NUMERO = dr.GetString(p2);
        //                        oCampos.APELLIDOS_NOMBRES = dr.GetString(p3);
        //                        oCampos.ESTADO_ORIGEN = dr.GetString(p4);
        //                        lsCEntidad.Add(oCampos);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarPoaDetMadCensoLista(OracleConnection cn, CEntSDetMarable oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            List<CEntSDetMarable> ListCEntSDetMarable = new List<CEntSDetMarable>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_CENSO_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntSDetMarable oCampos;
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                oCampos = new CEntSDetMarable();
                                oCampos.NUMERO_FILA = num_fila;
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.BLOQUE = dr["BLOQUE"].ToString();
                                oCampos.FAJA = dr["FAJA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oCampos.DAP = Decimal.Parse(dr["DAP"].ToString());
                                oCampos.AC = Decimal.Parse(dr["AC"].ToString());
                                oCampos.DMC = Int32.Parse(dr["DMC"].ToString());
                                oCampos.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                oCampos.ZONA = dr["ZONA"].ToString();
                                oCampos.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.CODIGO_GPS = dr["CODIGO_GPS"].ToString();
                                oCampos.COD_SISTEMA = dr["CODIGO_SISTEMA"].ToString();
                                oCampos.ESTADO_MUESTRA = Convert.ToBoolean(dr["ESTADO_MUESTRA"]);
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.ESTADO_MUESTRA2 = Convert.ToBoolean(dr["ESTADO_MUESTRA2"]);
                                oCampos.ESTADO_MUESTRA3 = Convert.ToBoolean(dr["ESTADO_MUESTRA3"]);
                                oCampos.NUM_MUESTRA = Int32.Parse(dr["NUM_MUESTRA"].ToString());
                                oCampos.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                oCampos.ESPECIES_ARESOLUCION = dr["ESPECIES_ARESOLUCION"].ToString();
                                oCampos.PCA = dr["PCA"].ToString();
                                oCampos.RegEstado = 0;
                                ListCEntSDetMarable.Add(oCampos);
                                num_fila++;
                            }
                        }
                        lsCEntidad.ListSDETMADERABLE = ListCEntSDetMarable;
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarPoaDetNoMadCensoLista(OracleConnection cn, CEntSDetMarable oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            List<CEntSDetMarable> ListCEntSDetMarable = new List<CEntSDetMarable>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_CENSO_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntSDetMarable oCampos;
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                oCampos = new CEntSDetMarable();
                                oCampos.NUMERO_FILA = num_fila;
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DIAMETRO = Decimal.Parse(dr["DIAMETRO"].ToString());
                                oCampos.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
                                oCampos.PRODUCCION_LATAS = Decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCampos.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                oCampos.ZONA = dr["ZONA"].ToString();
                                oCampos.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.CODIGO_GPS = dr["CODIGO_GPS"].ToString();
                                oCampos.COD_SISTEMA = dr["CODIGO_SISTEMA"].ToString();
                                oCampos.ESTADO_MUESTRA = Convert.ToBoolean(dr["ESTADO_MUESTRA"]);
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.ESTADO_MUESTRA2 = Convert.ToBoolean(dr["ESTADO_MUESTRA2"]);
                                oCampos.ESTADO_MUESTRA3 = Convert.ToBoolean(dr["ESTADO_MUESTRA3"]);
                                oCampos.NUM_MUESTRA = Int32.Parse(dr["NUM_MUESTRA"].ToString());
                                oCampos.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                oCampos.ESPECIES_ARESOLUCION = dr["ESPECIES_ARESOLUCION"].ToString();
                                oCampos.RegEstado = 0;
                                num_fila++;
                                ListCEntSDetMarable.Add(oCampos);
                            }
                        }
                        lsCEntidad.ListSDETMADERABLE = ListCEntSDetMarable;
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarDevolDetTrozaCensoLista(SqlConnection cn, CEntSDetDevol oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    List<CEntSDetDevol> ListCEntSDetDevol = new List<CEntSDetDevol>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spDEVOL_DET_TROZA_CENSO_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p2 = dr.GetOrdinal("COD_DEVOLUCION");
        //                    int p3 = dr.GetOrdinal("COD_ESPECIES");
        //                    int p4 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int p5 = dr.GetOrdinal("DESC_ESPECIES");
        //                    int p6 = dr.GetOrdinal("DAP");
        //                    int p7 = dr.GetOrdinal("CODIGO");
        //                    int p8 = dr.GetOrdinal("ALTURA");
        //                    int p9 = dr.GetOrdinal("VOLUMEN");
        //                    int p10 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int p11 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int p12 = dr.GetOrdinal("NUM_TROZAS");
        //                    int p13 = dr.GetOrdinal("DESCRIPCION");
        //                    int p14 = dr.GetOrdinal("OBSERVACION");
        //                    int p15 = dr.GetOrdinal("ESTADO_MUESTRA");
        //                    CEntSDetDevol oCampos;
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntSDetDevol();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCampos.COD_THABILITANTE = dr.GetString(p1);
        //                        oCampos.COD_DEVOLUCION = dr.GetString(p2);
        //                        oCampos.COD_ESPECIES = dr.GetString(p3);
        //                        oCampos.COD_SECUENCIAL = dr.GetInt32(p4);
        //                        oCampos.ESPECIES = dr.GetString(p5);
        //                        oCampos.DAP = Decimal.Parse(dr.GetString(p6));
        //                        oCampos.CODIGO = dr.GetString(p7);
        //                        oCampos.ALTURA = Decimal.Parse(dr.GetString(p8));
        //                        oCampos.VOLUMEN = Decimal.Parse(dr.GetString(p9));
        //                        oCampos.COORDENADA_ESTE = dr.GetInt32(p10);
        //                        oCampos.COORDENADA_NORTE = dr.GetInt32(p11);
        //                        oCampos.NUM_TROZAS = dr.GetInt32(p12);
        //                        oCampos.DESCRIPCION = dr.GetString(p13);
        //                        oCampos.OBSERVACION = dr.GetString(p14);
        //                        oCampos.ESTADO_MUESTRA = dr.GetBoolean(p15);
        //                        oCampos.RegEstado = 0;
        //                        oCampos.CONDICION = "";
        //                        oCampos.DESC_ESPECIES = "";
        //                        num_fila++;
        //                        ListCEntSDetDevol.Add(oCampos);
        //                    }
        //                }
        //                lsCEntidad.ListSDETDEVOLUCION = ListCEntSDetDevol;
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarDevolDetToconCensoLista(SqlConnection cn, CEntSDetDevol oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    List<CEntSDetDevol> ListCEntSDetDevol = new List<CEntSDetDevol>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spDEVOL_DET_TOCON_CENSO_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p2 = dr.GetOrdinal("COD_DEVOLUCION");
        //                    int p3 = dr.GetOrdinal("COD_ESPECIES");
        //                    int p4 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int p5 = dr.GetOrdinal("DESC_ESPECIES");
        //                    int p7 = dr.GetOrdinal("CODIGO");
        //                    int p6 = dr.GetOrdinal("DIAMETRO");
        //                    int p8 = dr.GetOrdinal("LARGO");
        //                    int p9 = dr.GetOrdinal("VOLUMEN");
        //                    int p10 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int p11 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int p12 = dr.GetOrdinal("CANTIDAD");
        //                    int p13 = dr.GetOrdinal("DESCRIPCION");
        //                    int p14 = dr.GetOrdinal("OBSERVACION");
        //                    int p15 = dr.GetOrdinal("ESTADO_MUESTRA");

        //                    CEntSDetDevol oCampos;
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntSDetDevol();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCampos.COD_THABILITANTE = dr.GetString(p1);
        //                        oCampos.COD_DEVOLUCION = dr.GetString(p2);
        //                        oCampos.COD_ESPECIES = dr.GetString(p3);
        //                        oCampos.COD_SECUENCIAL = dr.GetInt32(p4);
        //                        oCampos.ESPECIES = dr.GetString(p5);
        //                        oCampos.CODIGO = dr.GetString(p6);
        //                        oCampos.DIAMETRO = Decimal.Parse(dr.GetString(p7));
        //                        oCampos.LARGO = Decimal.Parse(dr.GetString(p8));
        //                        oCampos.VOLUMEN = Decimal.Parse(dr.GetString(p9));
        //                        oCampos.COORDENADA_ESTE = dr.GetInt32(p10);
        //                        oCampos.COORDENADA_NORTE = dr.GetInt32(p11);
        //                        oCampos.CANTIDAD = dr.GetInt32(p12);
        //                        oCampos.DESCRIPCION = dr.GetString(p13);
        //                        oCampos.OBSERVACION = dr.GetString(p14);
        //                        oCampos.ESTADO_MUESTRA = dr.GetBoolean(p15);
        //                        oCampos.RegEstado = 0;
        //                        oCampos.CONDICION = "";
        //                        oCampos.DESC_ESPECIES = oCampos.ESPECIES;
        //                        num_fila++;
        //                        ListCEntSDetDevol.Add(oCampos);
        //                    }
        //                }
        //                lsCEntidad.ListSDETDEVOLUCION = ListCEntSDetDevol;
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarDevolDetArbolCensoLista(SqlConnection cn, CEntSDetDevol oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    List<CEntSDetDevol> ListCEntSDetDevol = new List<CEntSDetDevol>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spDEVOL_DET_ARBOL_CENSO_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p2 = dr.GetOrdinal("COD_DEVOLUCION");
        //                    int p3 = dr.GetOrdinal("COD_ESPECIES");
        //                    int p4 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int p5 = dr.GetOrdinal("NUM_PCA");
        //                    int p6 = dr.GetOrdinal("DESC_ESPECIES");
        //                    int p7 = dr.GetOrdinal("DAP");
        //                    int p8 = dr.GetOrdinal("CODIGO");
        //                    int p9 = dr.GetOrdinal("ALTURA");
        //                    int p10 = dr.GetOrdinal("VOLUMEN");
        //                    int p11 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int p12 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int p13 = dr.GetOrdinal("COD_ECONDICION");
        //                    int p14 = dr.GetOrdinal("COD_EESTADO");
        //                    int p15 = dr.GetOrdinal("CONDICION");
        //                    int p16 = dr.GetOrdinal("ESTADO");
        //                    int p17 = dr.GetOrdinal("OBSERVACION");
        //                    int p18 = dr.GetOrdinal("ESTADO_MUESTRA");
        //                    CEntSDetDevol oCampos;
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntSDetDevol();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCampos.COD_THABILITANTE = dr.GetString(p1);
        //                        oCampos.COD_DEVOLUCION = dr.GetString(p2);
        //                        oCampos.COD_ESPECIES = dr.GetString(p3);
        //                        oCampos.COD_SECUENCIAL = dr.GetInt32(p4);
        //                        oCampos.NUM_PCA = dr.GetString(p5);
        //                        oCampos.ESPECIES = dr.GetString(p6);
        //                        oCampos.DAP = Decimal.Parse(dr.GetString(p7));
        //                        oCampos.CODIGO = dr.GetString(p8);
        //                        oCampos.ALTURA = Decimal.Parse(dr.GetString(p9));
        //                        oCampos.VOLUMEN = Decimal.Parse(dr.GetString(p10));
        //                        oCampos.COORDENADA_ESTE = dr.GetInt32(p11);
        //                        oCampos.COORDENADA_NORTE = dr.GetInt32(p12);
        //                        oCampos.COD_ECONDICION = dr.GetString(p13);
        //                        oCampos.COD_EESTADO = dr.GetString(p14);
        //                        oCampos.CONDICION = dr.GetString(p15);
        //                        oCampos.ESTADO = dr.GetString(p16);
        //                        oCampos.OBSERVACION = dr.GetString(p17);
        //                        oCampos.ESTADO_MUESTRA = dr.GetBoolean(p18);
        //                        oCampos.RegEstado = 0;
        //                        oCampos.DESC_ESPECIES = oCampos.ESPECIES;
        //                        num_fila++;
        //                        ListCEntSDetDevol.Add(oCampos);
        //                    }
        //                }
        //                lsCEntidad.ListSDETDEVOLUCION = ListCEntSDetDevol;
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public Int32 RegInsertar_Maderable_Muestra(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM01 = -1;
            CEntSDetMarable oCamposDet;
            CEntidad CampoEli;
            try
            {
                tr = cn.BeginTransaction();
                //Eliminar Total de la Muestra en un solo paso
                if (oCEntidad.ELIM_TOTAL_MUESTRA_M != null)
                {
                    if ((Boolean)oCEntidad.ELIM_TOTAL_MUESTRA_M)
                    {
                        CampoEli = new CEntidad();
                        CampoEli.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        CampoEli.COD_CNOTIFICACION = oCEntidad.COD_CNOTIFICACION;
                        CampoEli.EliTABLA = "POA_DET_MADERABLE";
                        CampoEli.ELIM_TOTAL_MUESTRA_M = oCEntidad.ELIM_TOTAL_MUESTRA_M;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCENSO_Eli_Muestra", CampoEli);
                    }
                }

                //ELIMINAR MUESTRAS
                if (oCEntidad.ListEliTABLACenso != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLACenso)
                    {
                        CampoEli = new CEntidad();
                        CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        CampoEli.NUM_POA = loDatos.NUM_POA;
                        CampoEli.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                        CampoEli.EliTABLA = "POA_DET_MADERABLE";
                        CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
                        CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCENSO_Eli_Muestra", CampoEli);
                    }
                }
                //Grabando Detalle THABILITANTE_DET_TITULARES
                if (oCEntidad.ListSDETMADERABLE_Muestra != null)
                {
                    CEntidad oCEntidadTemp = new CEntidad();
                    List<CEntidad> ListNUM_POA = new List<CEntidad>();
                    foreach (var loDatos in oCEntidad.ListSDETMADERABLE_Muestra)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntSDetMarable();
                            oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_CENSO_Mod_Muestra", oCamposDet);

                            if (oCEntidadTemp.NUM_POA != loDatos.NUM_POA)
                            {
                                oCEntidadTemp.NUM_POA = loDatos.NUM_POA;
                                CEntidad oCEntidadTemp1 = new CEntidad();


                                oCEntidadTemp1.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                oCEntidadTemp1.NUM_POA = loDatos.NUM_POA;
                                ListNUM_POA.Add(oCEntidadTemp1);
                            }

                        }
                    }
                    OUTPUTPARAM01 = 1;
                    if (ListNUM_POA.Count > 0)
                    {
                        List<CEntidad> listPOAsTemp = new List<CEntidad>();

                        listPOAsTemp = ListNUM_POA;
                        for (int j = 0; j < listPOAsTemp.Count; j++)
                        {
                            for (int k = 1; k < listPOAsTemp.Count - 1; k++)
                            {
                                if (listPOAsTemp[j].NUM_POA == listPOAsTemp[k].NUM_POA)
                                {
                                    listPOAsTemp.Remove(listPOAsTemp[j]);
                                }
                            }
                        }


                        for (int i = 0; i < listPOAsTemp.Count; i++)
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp = ListNUM_POA[i];
                            oCEntidadTemp.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            if (oCEntidadTemp.COD_THABILITANTE != "" && oCEntidadTemp.NUM_POA > -1 && oCEntidadTemp.COD_UCUENTA != "")
                            {   //Revisar si usan para implementar
                               // dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.zReporteCorreoMuestra", oCEntidadTemp);
                            }
                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM01;
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
        public Int32 RegInsertar_NoMaderable_Muestra(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM01 = -1;
            CEntSDetMarable oCamposDet;
            CEntidad CampoEli;
            try
            {
                tr = cn.BeginTransaction();
                //Eliminar Total de la Muestra en un solo paso
                if (oCEntidad.ELIM_TOTAL_MUESTRA_NM != null)
                {
                    if ((Boolean)oCEntidad.ELIM_TOTAL_MUESTRA_NM)
                    {
                        CampoEli = new CEntidad();
                        CampoEli.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        CampoEli.COD_CNOTIFICACION = oCEntidad.COD_CNOTIFICACION;
                        CampoEli.EliTABLA = "POA_DET_NOMADERABLE";
                        CampoEli.ELIM_TOTAL_MUESTRA_NM = oCEntidad.ELIM_TOTAL_MUESTRA_NM;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCENSO_Eli_Muestra", CampoEli);
                    }
                }
                //Eliminar
                if (oCEntidad.ListEliTABLACenso != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLACenso)
                    {
                        CampoEli = new CEntidad();
                        CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        CampoEli.NUM_POA = loDatos.NUM_POA;
                        CampoEli.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                        CampoEli.EliTABLA = "POA_DET_NOMADERABLE";
                        CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
                        CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCENSO_Eli_Muestra", CampoEli);
                    }
                }
                OUTPUTPARAM01 = 1;
                //Grabando Detalle THABILITANTE_DET_TITULARES
                if (oCEntidad.ListSDETMADERABLE_Muestra != null)
                {
                    foreach (var loDatos in oCEntidad.ListSDETMADERABLE_Muestra)
                    {
                        //if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        //{
                        oCamposDet = new CEntSDetMarable();
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_CENSO_Mod_Muestra", oCamposDet);
                        //}
                        OUTPUTPARAM01 = 1;
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
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
        //public Int32 RegInsertar_DevolTroza_Muestra(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetDevol oCamposDet;
        //    CEntidad CampoEli;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //ELIMINAR MUESTRAS
        //        if (oCEntidad.ListEliTABLACenso != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //            {
        //                CampoEli = new CEntidad();
        //                CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                CampoEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                CampoEli.EliTABLA = "DEVOL_DET_TROZA";
        //                CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra", CampoEli);
        //            }
        //        }
        //        //Grabando Detalle THABILITANTE_DET_TITULARES
        //        if (oCEntidad.ListSDETDEVOLUCION_Muestra != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListSDETDEVOLUCION_Muestra)
        //            {
        //                if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntSDetDevol();
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOL_DET_TROZA_CENSO_Mod_Muestra", oCamposDet);
        //                }
        //            }
        //            OUTPUTPARAM01 = 1;
        //        }
        //        tr.Commit();
        //        return OUTPUTPARAM01;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 RegInsertar_DevolTocon_Muestra(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetDevol oCamposDet;
        //    CEntidad CampoEli;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //ELIMINAR MUESTRAS
        //        if (oCEntidad.ListEliTABLACenso != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //            {
        //                CampoEli = new CEntidad();
        //                CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                CampoEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                CampoEli.EliTABLA = "DEVOL_DET_TOCON";
        //                CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra", CampoEli);
        //            }
        //        }
        //        //Grabando Detalle THABILITANTE_DET_TITULARES
        //        if (oCEntidad.ListSDETDEVOLUCION_Muestra != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListSDETDEVOLUCION_Muestra)
        //            {
        //                if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntSDetDevol();
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOL_DET_TOCON_CENSO_Mod_Muestra", oCamposDet);
        //                }
        //            }
        //            OUTPUTPARAM01 = 1;
        //        }
        //        tr.Commit();
        //        return OUTPUTPARAM01;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 RegInsertar_DevolArbol_Muestra(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;
        //    CEntSDetDevol oCamposDet;
        //    CEntidad CampoEli;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //ELIMINAR MUESTRAS
        //        if (oCEntidad.ListEliTABLACenso != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLACenso)
        //            {
        //                CampoEli = new CEntidad();
        //                CampoEli.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                CampoEli.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                CampoEli.EliTABLA = "DEVOL_DET_ARBOL";
        //                CampoEli.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                CampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spCENSO_Eli_Muestra", CampoEli);
        //            }
        //        }
        //        //Grabando Detalle THABILITANTE_DET_TITULARES
        //        if (oCEntidad.ListSDETDEVOLUCION_Muestra != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListSDETDEVOLUCION_Muestra)
        //            {
        //                if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntSDetDevol();
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOL_DET_ARBOL_CENSO_Mod_Muestra", oCamposDet);
        //                }
        //            }
        //            OUTPUTPARAM01 = 1;
        //        }
        //        tr.Commit();
        //        return OUTPUTPARAM01;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostDevol_Thabilitante_Lista_x_Numero(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDEVOL_THABILITANTE_Listar_x_Numero", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_DEVOLUCION");
                            int p2 = dr.GetOrdinal("FECHA_RESOLUCION");
                            int p3 = dr.GetOrdinal("NUM_RESOLUCION");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_DEVOLUCION = dr.GetString(p1);
                                oCampos.FECHA_RESOLUCION = dr.GetString(p2);
                                oCampos.NUM_RESOLUCION = dr.GetString(p3);
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
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostPoa_Thabilitante_Lista_x_Numero(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad.BusFormulario,
                    oCEntidad.BusCriterio,oCEntidad.BusValor,1,20, ""))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                oCampos.NUM_PCOMPLEMENTARIO = dr["NUM_PCOMPLEMENTARIO"].ToString();
                                oCampos.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                                oCampos.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("ARESOLUCION_NUM"));
                                oCampos.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO"));
                                oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCampos.NUM_ZAFRA = dr.GetString(dr.GetOrdinal("ZAFRA"));
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

        //public List<CEntidad> RegMostCNotificacion_Thabilitante_Lista_x_Numero(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
        //                        oCampos.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
        //                        oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                        oCampos.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
        //                        oCampos.MAE_CNTIPO = dr.GetString(dr.GetOrdinal("MAE_CNTIPO"));
        //                        lsCEntidad.Add(oCampos);
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

        //public Int32 RegActualizarNumeroMuestraPOA(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM01 = -1;

        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spPOA_DET_MADE_NOMADE_CENSO_Mod_Muestra", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();

        //            OUTPUTPARAM01 = 1;
        //        }
        //        tr.Commit();

        //        return OUTPUTPARAM01;
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

        #region SIGOsfc v3
        //Obtener las cartas de notificación aplicando diferentes filtros, estructura genérica
        public List<CEntidad> RegMostCNotificacion_Consulta(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spCNOTIFICACION_Consultar", oCEntidad.BusFormulario, oCEntidad.BusCriterio, oCEntidad.BusValor))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                                oCampos.NUMERO = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                                oCampos.MAE_CNTIPO = dr["MAE_CNTIPO"].ToString(); // dr.GetString(dr.GetOrdinal("MAE_CNTIPO"));
                                oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
                                oCampos.MTIPO = dr.GetString(dr.GetOrdinal("MODALIDAD_TIPO"));
                                oCampos.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                                oCampos.ESTADO_ORIGEN_TEXT = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN_TEXT"));

                                if (oCEntidad.BusFormulario == "DATA_CNOTIFICACION")
                                {
                                    oCampos.COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                                    oCampos.UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_UBIGEO"));
                                    oCampos.SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                                }

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

        public List<Dictionary<string, string>> ReportesCNotificacion(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCNotificacion", oCEntidad))
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
        #endregion
    }
}
