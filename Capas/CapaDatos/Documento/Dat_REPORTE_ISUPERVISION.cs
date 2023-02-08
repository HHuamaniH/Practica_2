using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_ISUPERVISION;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;



namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_REPORTE_ISUPERVISION
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //LISTADO DE SUPERVISION
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarSUPERVISION_anio(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.new_SUPERVISION_MODALIDAD_ANIO_REGION", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("ZONA");
        //                    int p2 = dr.GetOrdinal("ISUP");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.ZONA = dr.GetString(p1);
        //                        oCampos.ISUP = dr.GetInt32(p2);
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
        //public List<CEntidad> MostrarArbol_Mayor_Aprovechamiento(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_ARB_MAYOR_APROV", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
        //                    int p2 = dr.GetOrdinal("VOL_AUTORIZADO");
        //                    int p3 = dr.GetOrdinal("VOL_MOVILIZADO");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.NOMBRE_CIENTIFICO = dr.GetString(p1);
        //                        oCampos.DESCRIPCION = dr.GetString(p2);
        //                        oCampos.VOL_MOVILIZADO = dr.GetDecimal(p3);
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
        //public List<CEntidad> MostrarConsultor_Mayor_Poa(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_CONSULT_POA", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("CONSULTOR");
        //                    int p2 = dr.GetOrdinal("NUM_POA");
        //                    // int p3 = dr.GetOrdinal("VOL_MOVILIZADO");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.CONSULTOR = dr.GetString(p1);
        //                        oCampos.NUM_POA = dr.GetInt32(p2);
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
        //public CEntidad MostraraArbol_Inexistente(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    CEntidad oCampos;
        //    lsCEntidad.ListRankingEspecies = new List<CEntidad>();
        //    lsCEntidad.ListRankingDepartamento = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_ARBOLES_INEXISTENTES", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
        //                    int p2 = dr.GetOrdinal("NOMBRE_COMUN");
        //                    int p3 = dr.GetOrdinal("VALOR");
        //                    int p4 = dr.GetOrdinal("VOLUMEN");


        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.NOMBRE_CIENTIFICO = dr.GetString(p1);
        //                        oCampos.NOMBRE_COMUN = dr.GetString(p2);
        //                        oCampos.DESCRIPCION = dr.GetString(p3);
        //                        oCampos.CONSULTOR = dr.GetString(p4);
        //                        lsCEntidad.ListRankingEspecies.Add(oCampos);
        //                    }
        //                }
        //                //Departamentos
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("DEPARTAMENTO");
        //                    int pt2 = dr.GetOrdinal("CANT");

        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.DESCRIPCION = dr.GetString(pt1);
        //                        oCampos.VALOR = dr.GetInt32(pt2);
        //                        lsCEntidad.ListRankingDepartamento.Add(oCampos);
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
        //public List<CEntidad> MostrarInicio_PAU(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_TITULARES_INICIO_PAU", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("ZONA");
        //                    int p2 = dr.GetOrdinal("VALOR");


        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.ZONA = dr.GetString(p1);
        //                        oCampos.VALOR = dr.GetInt32(p2);
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
        //public List<CEntidad> MostrarInfraccion_PAU(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_INFRACCION_INICIO_PAU", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("DESCRIPCION");
        //                    int p2 = dr.GetOrdinal("VALOR");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.DESCRIPCION = dr.GetString(p1);
        //                        oCampos.VALOR = dr.GetInt32(p2);
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
        //public List<CEntidad> MostrarVolumen_Inicio_PAU(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_VOLUMEN_ESPECIE_INICIO_PAU", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
        //                    int p2 = dr.GetOrdinal("I");
        //                    int p3 = dr.GetOrdinal("W");
        //                    int p4 = dr.GetOrdinal("K");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.NOMBRE_CIENTIFICO = dr.GetString(p1);
        //                        oCampos.I = dr.GetDecimal(p2);
        //                        oCampos.W = dr.GetDecimal(p3);
        //                        oCampos.K = dr.GetDecimal(p4);
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
        //public List<CEntidad> RegPopupBuscarPersonas(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteProduccionXDigitadoresUsuarios", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_UCUENTA");
        //                    int p2 = dr.GetOrdinal("COD_UGRUPO");
        //                    int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int p4 = dr.GetOrdinal("N_DOCUMENTO");

        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_UCUENTA = dr.GetString(p1);
        //                        oCamposDet.COD_UGRUPO = dr.GetString(p2);
        //                        oCamposDet.APELLIDOS_NOMBRES = dr.GetString(p3);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(p4);
        //                        lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> MostrarOportunidadSupervisiones_Resumen(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteOportunidadSupervisiones", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        int iantes = 0, idurante = 0, idespues = 0, i = 0, isu = 0;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_MES = dr.GetString(dr.GetOrdinal("COD_MES"));
                                oCampos.MES = dr.GetString(dr.GetOrdinal("MES"));
                                oCampos.NPLANSUPERVISADO_ANTES = dr.GetInt32(dr.GetOrdinal("NPLANSUPERVISADO_ANTES"));
                                oCampos.NPLANSUPERVISADO_DURANTE = dr.GetInt32(dr.GetOrdinal("NPLANSUPERVISADO_DURANTE"));
                                oCampos.NPLANSUPERVISADO_DESPUES = dr.GetInt32(dr.GetOrdinal("NPLANSUPERVISADO_DESPUES"));
                                oCampos.NPLANSUPERVISADO = dr.GetInt32(dr.GetOrdinal("NPLANSUPERVISADO"));
                                oCampos.NISUPERVISION = dr.GetInt32(dr.GetOrdinal("NISUPERVISION"));
                                lsCEntidad.Add(oCampos);

                                iantes += oCampos.NPLANSUPERVISADO_ANTES;
                                idurante += oCampos.NPLANSUPERVISADO_DURANTE;
                                idespues += oCampos.NPLANSUPERVISADO_DESPUES;
                                i += oCampos.NPLANSUPERVISADO;
                                isu += oCampos.NISUPERVISION;
                            }
                        }

                        oCampos = new CEntidad();
                        oCampos.COD_MES = "";
                        oCampos.MES = "Total";
                        oCampos.NPLANSUPERVISADO_ANTES = iantes;
                        oCampos.NPLANSUPERVISADO_DURANTE = idurante;
                        oCampos.NPLANSUPERVISADO_DESPUES = idespues;
                        oCampos.NPLANSUPERVISADO = i;
                        oCampos.NISUPERVISION = isu;
                        lsCEntidad.Add(oCampos);
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> MostrarOportunidadSupervisiones_Detalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteOportunidadSupervisiones", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUM_INFORME = dr["NUM_INFORME"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.ANIO = Convert.ToInt32(dr["ANIO"]);
                                oCampos.MES = dr["MES"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.DLINEA = dr["DLINEA"].ToString();
                                oCampos.MTIPO = dr["MTIPO"].ToString();
                                oCampos.OD = dr["OD"].ToString();
                                oCampos.EST_APROVECHA = dr["EST_APROVECHA"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.FECHA_APRUEBA_POA = dr["FECHA_APRUEBA_POA"].ToString();
                                oCampos.INICIO_VIGENCIA = dr["INICIO_VIGENCIA"].ToString();
                                oCampos.FIN_VIGENCIA = dr["FIN_VIGENCIA"].ToString();
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
    }
}
