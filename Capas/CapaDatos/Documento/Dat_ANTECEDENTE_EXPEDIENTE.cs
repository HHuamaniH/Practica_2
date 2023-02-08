using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_ANTECEDENTE_EXPEDIENTE
    {
        private SQL oGDataSQL = new SQL();

        private DBOracle dBOracle = new DBOracle();

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
        //                        oCampo.COD_AEXPEDIENTE_SITD = dr.GetInt32(dr.GetOrdinal("COD_AEXPEDIENTE_SITD"));
        //                        oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
        //                        oCampo.COD_DREFERENCIA = dr.GetString(dr.GetOrdinal("COD_DREFERENCIA"));
        //                        oCampo.DOC_REFERENCIA = dr.GetString(dr.GetOrdinal("DOC_REFERENCIA"));
        //                        oCampo.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                        oCampo.RESOLUCION_POA = dr.GetString(dr.GetOrdinal("RESOLUCION_POA"));
        //                        oCampo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                        oCampo.OBSERVACION_TRANSFERENCIA = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERENCIA"));
        //                        oCampo.FECHA_SITD = dr.GetString(dr.GetOrdinal("FECHA_SITD"));
        //                        oCampo.ESTADO_AEXPEDIENTE = dr.GetString(dr.GetOrdinal("ESTADO_AEXPEDIENTE"));
        //                        oCampo.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                        oCampo.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
        //                        oCampo.COD_PGMF = dr.GetString(dr.GetOrdinal("COD_PGMF"));
        //                        oCampo.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO"));
        //                        oCampo.NUM_ACTO = dr.GetInt32(dr.GetOrdinal("NUM_ACTO"));
        //                        oCampo.PDF_TRAMITE_SITD = dr.GetString(dr.GetOrdinal("PDF_TRAMITE_SITD"));
        //                        oCampo.NUM_DOCUMENTO = dr.GetString(dr.GetOrdinal("cNroDocumento"));
        //                        oCampo.NUM_TRAMITE = dr.GetString(dr.GetOrdinal("cCodificacion"));
        //                        oCampo.OD = dr.GetString(dr.GetOrdinal("cNomOficina"));
        //                        oCampo.ESTADO_ORIGEN_PADRE = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN_PADRE"));
        //                        oCampo.COD_GORE = dr.GetString(dr.GetOrdinal("idGore"));
        //                        oCampo.COD_SIADO = dr.GetString(dr.GetOrdinal("cCodDoc"));

        //                        oCampo.FECHA_SIADO = dr.GetString(dr.GetOrdinal("FECHA_SIADO"));
        //                        oCampo.TIPO_SIADO = dr.GetString(dr.GetOrdinal("TIPO_SIADO"));
        //                        oCampo.SUB_TIPO_SIADO = dr.GetString(dr.GetOrdinal("SUB_TIPO_SIADO"));

        //                        oCampo.SUBTIPODETALLE = dr.GetString(dr.GetOrdinal("DESDETALLESUBTIPODOC"));
        //                        oCampo.DIAS_DD = dr.GetString(dr.GetOrdinal("DIAS"));

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
                        oCampos.ListMComboModalidad = new List<CEntidad>();
                        oCampos.ListMComboDocReferencia = new List<CEntidad>();

                        CEntidad oCamposDet;
                        //Listado Modalidad
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboModalidad.Add(oCamposDet);
                            }
                        }
                        //Listado documentos de referencia (ATFFS)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboDocReferencia.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampo = new CEntidad();
            oCampo.ListMComboPOA = new List<CEntidad>();
            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spANTECEDENTE_EXPEDIENTEMostrarItems", oCEntidad))
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spANTECEDENTE_EXPEDIENTEMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampoDet;

                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                oCampo.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE")).Trim();
                                oCampo.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO")).Trim();
                                oCampo.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                oCampo.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA")).Trim();
                                oCampo.COD_PGMF = dr.GetString(dr.GetOrdinal("COD_PGMF")).Trim();
                                oCampo.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO")).Trim();
                                oCampo.NUM_ACTO = dr.GetInt32(dr.GetOrdinal("NUM_ACTO"));
                                oCampo.NOMBRE_ACTO = dr.GetString(dr.GetOrdinal("NOMBRE_ACTO")).Trim();
                                oCampo.SINCRO_PGMF = dr.GetBoolean(dr.GetOrdinal("SINCRO_PGMF"));
                                oCampo.SINCRO_PM = dr.GetBoolean(dr.GetOrdinal("SINCRO_PM"));
                                oCampo.SINCRO_POA = dr.GetBoolean(dr.GetOrdinal("SINCRO_POA"));
                                oCampo.SINCRO_TH = dr.GetBoolean(dr.GetOrdinal("SINCRO_TH"));
                            }
                        }
                        //Listar los Planes de Manejo del TH
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampoDet = new CEntidad();
                                oCampoDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO")).Trim();
                                oCampoDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION")).Trim();
                                oCampo.ListMComboPOA.Add(oCampoDet);
                            }
                        }
                    }
                }

                return oCampo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spANTECEDENTE_EXPEDIENTEGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
        public String RegGrabarV3(OracleConnection cn, CEntidad oCEntidad, OracleTransaction tr)
        {
            //tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                //tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spANTECEDENTE_EXPEDIENTEGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }

                }                
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarSITD(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = cn.BeginTransaction();
            String OUTPUTPARAM01 = "";
            try
            {
                //tr = cn.BeginTransaction();
                //Grabando Cabecera
               // using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.Tra_M_Documento_Previo_SITDGrabar", oCEntidad))
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.Tra_M_Documento_Previo_SITDGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }

                }
                tr.Commit();

                //OracleTransaction tr1 = cn.BeginTransaction();
                //try
                //{                
                //    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr1, "DOC_OSINFOR_ERP_MIGRACION.Tra_M_Documento_Previo_SITDGrabar2", oCEntidad))
                //    {
                //        cmd.ExecuteNonQuery();
                //        OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                //        if (OUTPUTPARAM01 == "99")
                //        {
                //            tr1.Rollback();
                //            tr1 = null;
                //            throw new Exception("Ud. no tiene permiso para realizar esta acción");
                //        }
                //    }
                //    tr1.Commit();
                //    return OUTPUTPARAM01;
                //}
                //catch (Exception ex)
                //{
                //    if (tr1 != null)
                //    {
                //        tr1.Rollback();
                //    }
                //    throw ex;
                //}  
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


        public List<CEntidad> ReporteAntecedenteExpediente(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteAntecedenteExpediente", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_AEXPEDIENTE_SITD = dr.GetInt32(dr.GetOrdinal("COD_AEXPEDIENTE_SITD"));
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.ADICIONAL = dr.GetString(dr.GetOrdinal("ADICIONAL"));
                                oCampo.DOC_REFERENCIA = dr.GetString(dr.GetOrdinal("DOC_REFERENCIA"));
                                oCampo.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampo.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                oCampo.RESOLUCION_POA = dr.GetString(dr.GetOrdinal("RESOLUCION_POA"));
                                oCampo.FUENTE = dr.GetString(dr.GetOrdinal("FUENTE"));
                                oCampo.FECHA = dr.GetString(dr.GetOrdinal("FECHA"));
                                oCampo.ESTADO_AEXPEDIENTE = dr.GetString(dr.GetOrdinal("ESTADO_AEXPEDIENTE"));
                                oCampo.ESTADO_SIGO = dr.GetString(dr.GetOrdinal("ESTADO_SIGO"));
                                oCampo.CENSO = dr.GetInt32(dr.GetOrdinal("CENSO"));
                                oCampo.SUPERVISADO = dr.GetString(dr.GetOrdinal("SUPERVISADO"));

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

        public List<Dictionary<string, string>> ReporteExcel(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteVentanillaAntecedenteExpediente", oCEntidad))
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
    }
}
