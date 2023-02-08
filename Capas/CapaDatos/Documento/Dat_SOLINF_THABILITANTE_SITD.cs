using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_SOLINF_THABILITANTE_SITD;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_SOLINF_THABILITANTE_SITD
    {
        private SQL oGDataSQL = new SQL();

        //public List<CEntidad> RegMostrarGeneral(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> olCampos = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCampo;

        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampo = new CEntidad();
        //                        oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
        //                        oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
        //                        oCampo.FECHA_SITD = dr.GetString(dr.GetOrdinal("FECHA_SITD"));
        //                        oCampo.ENTIDAD = dr.GetString(dr.GetOrdinal("ENTIDAD"));
        //                        oCampo.ESTADO_DREFERENCIA = dr.GetString(dr.GetOrdinal("ESTADO_DREFERENCIA"));
        //                        oCampo.OBSERVACION_TRANSFERENCIA = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERENCIA"));
        //                        oCampo.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
        //                        oCampo.PDF_TRAMITE_SITD = dr.GetString(dr.GetOrdinal("PDF_TRAMITE_SITD"));

        //                        olCampos.Add(oCampo);
        //                    }
        //                }
        //            }
        //        }

        //        return olCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void RegEliminarDetalle(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spSOLINF_THABILITANTE_SITDEliminarDetalle", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
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
        public VM_SOLINF_THABILITANTE RegMostrarListaItems_Cabecera(SqlConnection cn, params object[] paramsValue)
        {
            VM_SOLINF_THABILITANTE entidad = new VM_SOLINF_THABILITANTE();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "DOC.uspSOLINF_THABILITANTE_SITD_GET_V3", paramsValue))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                entidad.cod_Tramite_Id = Convert.ToInt32(dr["COD_TRAMITE_SITD"]);
                                entidad.nro_Referencia = dr["NUM_DREFERENCIA"].ToString();
                                entidad.entidad = dr["ENTIDAD"].ToString();
                                entidad.asunto = dr["ASUNTO"].ToString();
                                entidad.obs = dr["OBSERVACION_TRANSFERENCIA"].ToString();
                                entidad.nFlgTransferencia = Convert.ToInt32(dr["nFlgTransferencia"]);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidad;
        }
        public List<Dictionary<string, string>> RegMostrarListaItems_Detalle(SqlConnection cn, params object[] paramsValue)
        {
            List<Dictionary<string, string>> detalle = new List<Dictionary<string, string>>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "DOC.uspSOLINF_THABILITANTE_SITD_GET_V3", paramsValue))
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
                                    sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                }
                                detalle.Add(sFila);
                            }

                            //while (dr.Read())
                            //{
                            //    //detalle.Add(new VM_SOLINF_THABILITANTE_DETALLE()
                            //    //{
                            //    //    cod_secuencial = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL")),
                            //    //    cod_TH = dr["COD_THABILITANTE"].ToString(),
                            //    //    num_TH = dr["NUM_THABILITANTE"].ToString(),
                            //    //    num_poa = Convert.ToInt32(dr["NUM_POA"]),
                            //    //    nombre_poa = dr["NOMBRE_POA"].ToString(),
                            //    //    res_poa = dr["RESOLUCION_POA"].ToString(),
                            //    //    estado_supervision = dr["ESTADO_SUPERVISION"].ToString(),
                            //    //    obs = dr["OBSERVACION"].ToString(),
                            //    //    estado = 2 // 2 es en caso que se va modificar
                            //    //});
                            //}

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return detalle;
        }
        public CEntidad RegMostrarListaItems(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampo = new CEntidad();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spSOLINF_THABILITANTE_SITDMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            oCampo.ListTHabilitante = new List<CEntidad>();
                            oCampo.ListEliTABLA = new List<CEntidad>();
                            CEntidad oCampoDet;

                            if (dr.Read())
                            {
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.ENTIDAD = dr.GetString(dr.GetOrdinal("ENTIDAD"));
                                oCampo.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                                oCampo.OBSERVACION_TRANSFERENCIA = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERENCIA"));
                            }

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampoDet = new CEntidad();
                                    oCampoDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    oCampoDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                    oCampoDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                    oCampoDet.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                    oCampoDet.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                    oCampoDet.RESOLUCION_POA = dr.GetString(dr.GetOrdinal("RESOLUCION_POA"));
                                    oCampoDet.ESTADO_SUPERVISION = dr.GetString(dr.GetOrdinal("ESTADO_SUPERVISION"));
                                    oCampoDet.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                    oCampoDet.RegEstado = 0;
                                    oCampoDet.REGISTRO_SIGO = oCampoDet.COD_THABILITANTE == "" || oCampoDet.NUM_POA == 0 ? "No" : "Si";
                                    oCampo.ListTHabilitante.Add(oCampoDet);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oCampo;
        }
        public string RegGrabar_Cabecera(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            string OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.uspSOLINF_THABILITANTE_SITDGrabar_V3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
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
        public String RegGrabar_Detalle(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad.ListTHabilitante != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHabilitante)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_TRAMITE_SITD = loDatos.COD_TRAMITE_SITD;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_THABILITANTE = loDatos.NUM_THABILITANTE;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        oCamposDet.NOMBRE_POA = loDatos.NOMBRE_POA;
                        oCamposDet.RESOLUCION_POA = loDatos.RESOLUCION_POA;
                        oCamposDet.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.COD_UCUENTA = loDatos.COD_UCUENTA;
                        oCamposDet.RegEstado = loDatos.RegEstado;

                        oGDataSQL.ManExecute(cn, tr, "DOC.uspSOLINF_THABILITANTE_SITDGrabarDetalle_v3", oCamposDet);
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
        public String Eliminarv3(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_UCUENTA = loDatos.COD_UCUENTA;
                        oCamposDet.COD_TRAMITE_SITD = loDatos.COD_TRAMITE_SITD;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oGDataSQL.ManExecute(cn, tr, "DOC.uspSOLINF_THABILITANTE_SITDEliminarDetalle_V3", oCamposDet);
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
        public String AnularSolicitud(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
#pragma warning disable CS0168 // La variable 'oCamposDet' se ha declarado pero nunca se usa
            CEntidad oCamposDet;
#pragma warning restore CS0168 // La variable 'oCamposDet' se ha declarado pero nunca se usa
            try
            {
                tr = cn.BeginTransaction();
                oGDataSQL.ManExecute(cn, tr, "DOC.uspSOLINF_THABILITANTE_SITDEliminarDetalle_V3", oCEntidad);
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
        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spSOLINF_THABILITANTE_SITDGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_TRAMITE_SITD = Convert.ToInt32(OUTPUTPARAM01);
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_TRAMITE_SITD = oCEntidad.COD_TRAMITE_SITD;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spSOLINF_THABILITANTE_SITDEliminarDetalle", oCamposDet);
                    }
                }

                if (oCEntidad.ListTHabilitante != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHabilitante)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_TRAMITE_SITD = oCEntidad.COD_TRAMITE_SITD;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_THABILITANTE = loDatos.NUM_THABILITANTE;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        oCamposDet.NOMBRE_POA = loDatos.NOMBRE_POA;
                        oCamposDet.RESOLUCION_POA = loDatos.RESOLUCION_POA;
                        oCamposDet.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = loDatos.RegEstado;

                        oGDataSQL.ManExecute(cn, tr, "DOC.spSOLINF_THABILITANTE_SITDGrabarDetalle", oCamposDet);
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

        public List<CEntidad> ReporteSolicitudInformacionTH_Resumen(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporteSolicitudInformacionEntidades", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_ENTIDAD = dr.GetInt32(dr.GetOrdinal("COD_ENTIDAD"));
                                oCampo.ENTIDAD = dr.GetString(dr.GetOrdinal("ENTIDAD"));
                                oCampo.N_THABILITANTE = dr.GetInt32(dr.GetOrdinal("N_THABILITANTE"));
                                oCampo.N_PMANEJO = dr.GetInt32(dr.GetOrdinal("N_PMANEJO"));
                                oCampo.N_SI_SUPERVISADO = dr.GetInt32(dr.GetOrdinal("N_SI_SUPERVISADO"));
                                oCampo.N_NO_SUPERVISADO = dr.GetInt32(dr.GetOrdinal("N_NO_SUPERVISADO"));
                                oCampo.N_NO_SUPERVERVISABLE = dr.GetInt32(dr.GetOrdinal("N_NO_SUPERVERVISABLE"));

                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteSolicitudInformacionTH_Detalle(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporteSolicitudInformacionEntidades", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.ENTIDAD = dr.GetString(dr.GetOrdinal("ENTIDAD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampo.RESOLUCION_POA = dr.GetString(dr.GetOrdinal("RESOLUCION_POA"));
                                oCampo.ESTADO_SUPERVISION = dr.GetString(dr.GetOrdinal("ESTADO_SUPERVISION"));
                                oCampo.NUM_DRESPUESTA = dr.GetString(dr.GetOrdinal("NUM_DRESPUESTA"));

                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Reporte de planes de manejo registrados de diferentes fuentes de información (denuncias, solicitude información
        //de TH, antecedentes de expedientes de TH y de la interoperabilidad con los GORE's)
        public List<CEntidad> ReportePMPlanificacionSupervisiones(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReportePManejoPlanificacionSupervisiones", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampo.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCampo.OD = dr.GetString(dr.GetOrdinal("OD"));
                                oCampo.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                oCampo.RESOLUCION_POA = dr.GetString(dr.GetOrdinal("RESOLUCION_POA"));
                                oCampo.FUENTE = dr.GetString(dr.GetOrdinal("FUENTE"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.FECHA_RECEPCION = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION"));
                                oCampo.ESTADO_CALIDAD = dr.GetString(dr.GetOrdinal("ESTADO_CALIDAD"));
                                oCampo.NUM_CENSO = dr.GetInt32(dr.GetOrdinal("NUM_CENSO"));
                                oCampo.ESTADO_SUPERVISION = dr.GetString(dr.GetOrdinal("ESTADO_SUPERVISION"));
                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
