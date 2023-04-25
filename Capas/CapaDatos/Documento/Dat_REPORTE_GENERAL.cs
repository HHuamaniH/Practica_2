using CapaEntidad.DOC;
using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_GENERAL;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_REPORTE_GENERAL
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        #region SIGOsfc v3
        public List<Ent_PreVisualizarv1> Reporte_EstadodeGuiaTransporte(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Ent_PreVisualizarv1> lstResult = new List<Ent_PreVisualizarv1>();

            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.RPTESTADODEGUIATRANSPORTE", criterio, valorBusqueda, currentPage, pageSize, sort))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PreVisualizarv1 oCampos;

                                while (dr.Read())
                                {
                                    oCampos = new Ent_PreVisualizarv1();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.PERMISO_AUTORIZACION = dr["PERMISO_AUTORIZACION"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString() + " - " + dr["PROVINCIA"].ToString() + " - " + dr["DISTRITO"].ToString();
                                    oCampos.DEPARTAMENTO = dr["REGION"].ToString();
                                    oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
                                    oCampos.DISTRITO = dr["DISTRITO"].ToString();
                                    oCampos.SECTOR = dr["SECTOR"].ToString();
                                    oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampos.POA = dr["POA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA_PCA"].ToString();
                                    oCampos.ARESOLUCION_NUM = dr["ARESOLUCION_NUM"].ToString();
                                    oCampos.REFORMULA_NUM = dr["REFORMULA_NUM"].ToString(); ;
                                    oCampos.INICIO_VIGENCIA = dr["INICIO_VIGENCIA"].ToString();
                                    oCampos.BEXTRACCION_FEMISION = dr["BEXTRACCION_FEMISION"].ToString();
                                    oCampos.COD_INFORME = dr["COD_INF"].ToString();
                                    oCampos.INF_NUMERO = dr["INF_NUMERO"].ToString();
                                    oCampos.COD_ITIPO = dr["COD_ITIPO"].ToString();
                                    oCampos.ANIO_SUPER = dr["ANIO_SUPER"].ToString();
                                    oCampos.FECHA_INI = dr["FECHA_INI"].ToString();
                                    oCampos.FECHA_TERMINO = dr["FECHA_TERMINO"].ToString();
                                    oCampos.INF_LEGAL = dr["ILEGAL"].ToString();
                                    oCampos.DETER_INF_LEGAL = dr["DETER_ILEGAL"].ToString();
                                    oCampos.MOTIVO_ARCHIVO = dr["MOTIVO_ARCHIVO"].ToString();

                                    oCampos.DOC_SIADO_ARESOL = dr["DOC_SIADO_ARESOL"].ToString();
                                    oCampos.DOC_ORIGEN_ARESOL = dr["DOC_ORIGEN_ARESOL"].ToString();
                                    oCampos.DOC_SIADO_REFOR = dr["DOC_SIADO_REFOR"].ToString();
                                    oCampos.DOC_ORIGEN_REFOR = dr["DOC_ORIGEN_REFOR"].ToString();
                                    oCampos.DOC_SIADO_INFORME = dr["DOC_SIADO_INFORME"].ToString();
                                    oCampos.DOC_SIADO_ILEGAL = dr["DOC_SIADO_ILEGAL"].ToString();
                                    //14/11/2019 carr adicion de tipo informe
                                    oCampos.TIPO_DOCUMENTO = dr["TIPO_INFORME"].ToString();
                                    oCampos.FECHA_INFORME = dr["FECHA_INFORME"].ToString();


                                    lstResult.Add(oCampos);
                                }

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
                                }
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
        public List<Dictionary<string, string>> ReporteGeneral(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteGeneral_SIGOsfc_v3", oCEntidad))
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

        public List<Dictionary<string, string>> ReporteTitularResumen(Ent_REPORTE_TITULAR_RESUMEN oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spzTitularResumen_v3", oCEntidad))
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public List<VM_ALERTA_SUPERVISION> AlertaSupervision(OracleConnection cn)
        {
            List<VM_ALERTA_SUPERVISION> listInfASupervision = new List<VM_ALERTA_SUPERVISION>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.uspResumenAlertaOsinfor", null))
                {
                    if (dr != null)
                    {
                        VM_ALERTA_SUPERVISION oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {//  dr.Read();
                                oCamposDet = new VM_ALERTA_SUPERVISION();
                                oCamposDet.COD_TH = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCamposDet.TITULO = dr.GetString(dr.GetOrdinal("TITULO"));
                                oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCamposDet.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                oCamposDet.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                oCamposDet.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                oCamposDet.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA")).ToString();
                                oCamposDet.POA_RESOLUCION = dr.GetString(dr.GetOrdinal("RD_APROVECHAMIENTO"));
                                oCamposDet.FECHA_ENVIO_ALERTA = dr.GetString(dr.GetOrdinal("FECHA_ENVIO_ALERTA"));
                                oCamposDet.RES_MC_ANT_PAU = dr.GetString(dr.GetOrdinal("RES_MC_ANT_PAU"));
                                oCamposDet.COD_DOC_SIADO = dr.GetString(dr.GetOrdinal("COD_DOC_SIADO"));
                                oCamposDet.ORIGEN_SIADO = dr.GetString(dr.GetOrdinal("ORIGEN_SIADO"));
                                oCamposDet.VOLINJUS = dr["VOLINJUS"].ToString();

                                listInfASupervision.Add(oCamposDet);
                            }
                        }

                    }
                }
                return listInfASupervision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
