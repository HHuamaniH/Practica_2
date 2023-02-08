using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidadC = CapaEntidad.DOC.Ent_REPORTEGERENCIAL;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;


namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_REPORTEGERENCIAL
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> ListarInformesSupervision(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spREPORTE_ESPCIES_FORESTALES_ILEGAL_INFORME_SUPERVISION", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt3 = dr.GetOrdinal("PROVINCIA");
                            int pt4 = dr.GetOrdinal("DISTRITO");
                            int pt5 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt6 = dr.GetOrdinal("NUMERO_ISUPERVISION");


                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCampos.DEPARTAMENTO = dr.GetString(pt2);
                                oCampos.PROVINCIA = dr.GetString(pt3);
                                oCampos.DISTRITO = dr.GetString(pt4);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(pt5);
                                oCampos.NUMERO_ISUPERVISION = dr.GetString(pt6);

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
        public List<CEntidadC> ListarInformeLegal(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spREPORTE_ESPCIES_FORESTALES_ILEGAL_INFORME_LEGAL", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("NUMERO_TH_HABILITANTE");
                            int pt3 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt4 = dr.GetOrdinal("PROVINCIA");
                            int pt5 = dr.GetOrdinal("DISTRITO");
                            int pt6 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt7 = dr.GetOrdinal("NUMERO_ISUPERVISION");
                            int pt8 = dr.GetOrdinal("NUMERO_LEGAL");
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCampos.NUMERO_TH_HABILITANTE = dr.GetString(pt2);
                                oCampos.DEPARTAMENTO = dr.GetString(pt3);
                                oCampos.PROVINCIA = dr.GetString(pt4);
                                oCampos.DISTRITO = dr.GetString(pt5);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(pt6);
                                oCampos.NUMERO_ISUPERVISION = dr.GetString(pt7);
                                oCampos.NUMERO_LEGAL = dr.GetString(pt8);

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
        public List<CEntidadC> ListarDeficienciaTecnica(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spREPORTE_ESPCIES_FORESTALES_ILEGAL_DEFICIENCIA_TECNICA", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("NUMERO_TH_HABILITANTE");
                            int pt3 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt4 = dr.GetOrdinal("PROVINCIA");
                            int pt5 = dr.GetOrdinal("DISTRITO");
                            int pt6 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt7 = dr.GetOrdinal("NUMERO_ISUPERVISION");
                            int pt8 = dr.GetOrdinal("NUMERO_LEGAL");
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCampos.NUMERO_TH_HABILITANTE = dr.GetString(pt2);
                                oCampos.DEPARTAMENTO = dr.GetString(pt3);
                                oCampos.PROVINCIA = dr.GetString(pt4);
                                oCampos.DISTRITO = dr.GetString(pt5);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(pt6);
                                oCampos.NUMERO_ISUPERVISION = dr.GetString(pt7);
                                oCampos.NUMERO_LEGAL = dr.GetString(pt8);

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
        public List<CEntidadC> ListarEvidenciaIrregularidad(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spREPORTE_ESPCIES_FORESTALES_ILEGAL_EVIDENCIA_IRREGULARIDAD", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("NUMERO_TH_HABILITANTE");
                            int pt3 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt4 = dr.GetOrdinal("PROVINCIA");
                            int pt5 = dr.GetOrdinal("DISTRITO");
                            int pt6 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt7 = dr.GetOrdinal("NUMERO_ISUPERVISION");
                            int pt8 = dr.GetOrdinal("NUMERO_LEGAL");
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCampos.NUMERO_TH_HABILITANTE = dr.GetString(pt2);
                                oCampos.DEPARTAMENTO = dr.GetString(pt3);
                                oCampos.PROVINCIA = dr.GetString(pt4);
                                oCampos.DISTRITO = dr.GetString(pt5);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(pt6);
                                oCampos.NUMERO_ISUPERVISION = dr.GetString(pt7);
                                oCampos.NUMERO_LEGAL = dr.GetString(pt8);

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
        public List<CEntidadC> ListarTotalArchivo(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spREPORTE_ESPCIES_FORESTALES_ILEGAL_TOTAL_ARCHIVO", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("NUMERO_TH_HABILITANTE");
                            int pt3 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt4 = dr.GetOrdinal("PROVINCIA");
                            int pt5 = dr.GetOrdinal("DISTRITO");
                            int pt6 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt7 = dr.GetOrdinal("NUMERO_ISUPERVISION");
                            int pt8 = dr.GetOrdinal("NUMERO_LEGAL");
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCampos.NUMERO_TH_HABILITANTE = dr.GetString(pt2);
                                oCampos.DEPARTAMENTO = dr.GetString(pt3);
                                oCampos.PROVINCIA = dr.GetString(pt4);
                                oCampos.DISTRITO = dr.GetString(pt5);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(pt6);
                                oCampos.NUMERO_ISUPERVISION = dr.GetString(pt7);
                                oCampos.NUMERO_LEGAL = dr.GetString(pt8);

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
        public List<CEntidadC> ListarTotalPAUConcluidos(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.REPORTE_INICIO_PAU_TERMINO_PAU", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("NUMERO_TH_HABILITANTE");
                            int pt3 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt4 = dr.GetOrdinal("PROVINCIA");
                            int pt5 = dr.GetOrdinal("DISTRITO");
                            int pt6 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt7 = dr.GetOrdinal("NUMERO_ISUPERVISION");
                            //     int pt8 = dr.GetOrdinal("NUMERO_EXPEDIENTE");
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCampos.NUMERO_TH_HABILITANTE = dr.GetString(pt2);
                                oCampos.DEPARTAMENTO = dr.GetString(pt3);
                                oCampos.PROVINCIA = dr.GetString(pt4);
                                oCampos.DISTRITO = dr.GetString(pt5);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(pt6);
                                oCampos.NUMERO_ISUPERVISION = dr.GetString(pt7);
                                //       oCampos.NUMERO_EXPEDIENTE = dr.GetString(pt8);

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
        public List<CEntidadC> ListarVolMovIlegal(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.REPORTE_INICIO_PAU_TERMINO_PAU", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("ESPECIE");
                            int pt2 = dr.GetOrdinal("VOLUMEN");
                            int pt3 = dr.GetOrdinal("NUMERO_RESOLUCION");

                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidadC();
                                oCampos.ESPECIE = dr.GetString(pt1);
                                oCampos.VOLUMEN = dr.GetDecimal(pt2);
                                oCampos.NUMERO_RESOLUCION = dr.GetString(pt3);

                                //       oCampos.NUMERO_EXPEDIENTE = dr.GetString(pt8);

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
