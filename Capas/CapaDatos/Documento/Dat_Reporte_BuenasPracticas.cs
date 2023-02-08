using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_BuenasPracticas;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_Reporte_BuenasPracticas
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad Dat_ArchivoBuenaPracticaGeneral(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_BuenasPracticasForestal", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;

                        //Tipor de Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO_SUP");
                            int p2 = dr.GetOrdinal("BOSQUES_SECOS");
                            int p3 = dr.GetOrdinal("PREDIO_PRIVADO");
                            int p4 = dr.GetOrdinal("CC_NNN");
                            int p5 = dr.GetOrdinal("TOTAL_AUT_PER");
                            int p6 = dr.GetOrdinal("CONCESIONES_MADERABLE");
                            int p7 = dr.GetOrdinal("CONCESIONES_NOMADE");
                            int p8 = dr.GetOrdinal("TOTAL_CONC");
                            int p9 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.BusAnio = dr.GetString(p1);
                                oCamposDet.BOSQUES_SECOS = dr.GetInt32(p2);
                                oCamposDet.PREDIO_PRIVADO = dr.GetInt32(p3);
                                oCamposDet.CCNN = dr.GetInt32(p4);
                                oCamposDet.TOTAL_AUT_PER = dr.GetInt32(p5);
                                oCamposDet.CONCESIONES_MADERABLES = dr.GetInt32(p6);
                                oCamposDet.CONCESIONES_NOMADERABLES = dr.GetInt32(p7);
                                oCamposDet.TOTAL_CONC = dr.GetInt32(p8);
                                oCamposDet.TOTAL = dr.GetInt32(p9);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListGeneral = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p2 = dr.GetOrdinal("ANIO_SUP");
                            int p3 = dr.GetOrdinal("COD_MTIPO");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.TITULAR = dr.GetString(p1);
                                oCamposDet.BusAnio = dr.GetString(p2);
                                oCamposDet.BusModalidad = dr.GetString(p3);
                                oCamposDet.THABILITANTE = dr.GetString(p4);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListRanking = lsDetDetalles;
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
        public List<CEntidad> Dat_ArchivoBuenaPracticaDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_BuenasPracticasForestal", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("TITULAR");
                            int p2 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p3 = dr.GetOrdinal("NUM_ISUPERVISION");
                            int p4 = dr.GetOrdinal("ILEGAL_NUMERO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.TITULAR = dr.GetString(p1);
                                oCampos.THABILITANTE = dr.GetString(p2);
                                oCampos.ISUPERVISION = dr.GetString(p3);
                                oCampos.ILEGAL = dr.GetString(p4);
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
        public CEntidad Dat_ArchivoBuenaPracticaGeneralFauna(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_BuenasPracticasFauna", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;

                        //Tipor de Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO_SUP");
                            int p2 = dr.GetOrdinal("Zoologicos");
                            int p3 = dr.GetOrdinal("Zoocriaderos");
                            int p4 = dr.GetOrdinal("CentrodeRescate");
                            int p5 = dr.GetOrdinal("CentroCustodiaTemporal");
                            int p6 = dr.GetOrdinal("Fauna_silvestre");
                            int p7 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.BusAnio = dr.GetString(p1);
                                oCamposDet.BOSQUES_SECOS = dr.GetInt32(p2); //Zoológicos
                                oCamposDet.CCNN = dr.GetInt32(p3);//Zoocriaderos
                                oCamposDet.PREDIO_PRIVADO = dr.GetInt32(p4); //CentrodeRescate
                                oCamposDet.TOTAL_AUT_PER = dr.GetInt32(p5); //CentroCustodiaTemporal
                                oCamposDet.CONCESIONES_MADERABLES = dr.GetInt32(p6); //Fauna_silvestre
                                oCamposDet.TOTAL = dr.GetInt32(p7);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListGeneral = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p2 = dr.GetOrdinal("ANIO_SUP");
                            int p3 = dr.GetOrdinal("COD_MTIPO");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.TITULAR = dr.GetString(p1);
                                oCamposDet.BusAnio = dr.GetString(p2);
                                oCamposDet.BusModalidad = dr.GetString(p3);
                                oCamposDet.THABILITANTE = dr.GetString(p4);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListRanking = lsDetDetalles;
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
        public List<CEntidad> Dat_ArchivoBuenaPracticaDetalleFauna(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_BuenasPracticasFauna", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("TITULAR");
                            int p2 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p3 = dr.GetOrdinal("NUM_ISUPERVISION");
                            int p4 = dr.GetOrdinal("ILEGAL_NUMERO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.TITULAR = dr.GetString(p1);
                                oCampos.THABILITANTE = dr.GetString(p2);
                                oCampos.ISUPERVISION = dr.GetString(p3);
                                oCampos.ILEGAL = dr.GetString(p4);
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
