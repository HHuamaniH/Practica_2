using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_CAPACITACION;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reporte_CAPACITACION
    {
        private SQL oGDataSQL = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarTotalCapacitacion(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.new_REPORTE_Capacitaciones", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("NUM_CAPACITACIONES");
                            int p3 = dr.GetOrdinal("NUM_PARTICIPANTES");
                            int p4 = dr.GetOrdinal("NUM_HOMBRES");
                            int p5 = dr.GetOrdinal("NUM_MUJERES");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetString(p1);
                                oCampos.NUM_CAPACITACIONES = dr.GetInt32(p2);
                                oCampos.NUM_PARTICIPANTES = dr.GetInt32(p3);
                                oCampos.NUM_HOMBRES = dr.GetInt32(p4);
                                oCampos.NUM_MUJERES = dr.GetInt32(p5);
                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
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
        public List<CEntidad> RegMostrarCapacxPublicoObj(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.new_REPORTE_Capacitaciones", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.DOSMILNUEVE = int.Parse(dr["DOSMILNUEVE"].ToString());
                                oCampos.DOSMILDIEZ = int.Parse(dr["DOSMILDIEZ"].ToString());
                                oCampos.DOSMILONCE = int.Parse(dr["DOSMILONCE"].ToString());
                                oCampos.DOSMILDOCE = int.Parse(dr["DOSMILDOCE"].ToString());
                                oCampos.DOSMILTRECE = int.Parse(dr["DOSMILTRECE"].ToString());
                                oCampos.DOSMILCATORCE = int.Parse(dr["DOSMILCATORCE"].ToString());
                                oCampos.DOSMILQUINCE = int.Parse(dr["DOSMILQUINCE"].ToString());
                                oCampos.DOSMILDIECISEIS = int.Parse(dr["DOSMILDIECISEIS"].ToString());
                                oCampos.DOSMILDIECISIETE = int.Parse(dr["DOSMILDIECISIETE"].ToString());
                                oCampos.DOSMILDIECIOCHO = int.Parse(dr["DOSMILDIECIOCHO"].ToString());
                                oCampos.TOTAL = int.Parse(dr["TOTAL"].ToString());

                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
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
        public List<CEntidad> RegMostrarCapRegion(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.new_REPORTE_Capacitaciones", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.REGION = dr["REGION"].ToString();
                                oCampos.DOSMILNUEVE = int.Parse(dr["DOSMILNUEVE"].ToString());
                                oCampos.DOSMILDIEZ = int.Parse(dr["DOSMILDIEZ"].ToString());
                                oCampos.DOSMILONCE = int.Parse(dr["DOSMILONCE"].ToString());
                                oCampos.DOSMILDOCE = int.Parse(dr["DOSMILDOCE"].ToString());
                                oCampos.DOSMILTRECE = int.Parse(dr["DOSMILTRECE"].ToString());
                                oCampos.DOSMILCATORCE = int.Parse(dr["DOSMILCATORCE"].ToString());
                                oCampos.DOSMILQUINCE = int.Parse(dr["DOSMILQUINCE"].ToString());
                                oCampos.DOSMILDIECISEIS = int.Parse(dr["DOSMILDIECISEIS"].ToString());
                                oCampos.DOSMILDIECISIETE = int.Parse(dr["DOSMILDIECISIETE"].ToString());
                                oCampos.DOSMILDIECIOCHO = int.Parse(dr["DOSMILDIECIOCHO"].ToString());
                                oCampos.TOTAL = int.Parse(dr["TOTAL"].ToString());

                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
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
        public List<CEntidad> RegMostrarRelacionCapac(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.new_REPORTE_Capacitaciones", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("NOM_TALLER");
                            int p2 = dr.GetOrdinal("TIPO_TALLER");
                            int p3 = dr.GetOrdinal("FECHA");
                            int p4 = dr.GetOrdinal("NUM_PARTICIPANTES");
                            int p5 = dr.GetOrdinal("OD");
                            int p6 = dr.GetOrdinal("UBICACION");
                            int p7 = dr.GetOrdinal("PUBLICO_OBJETIVO");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NOM_TALLER = dr.GetString(p1);
                                oCampos.TIPO_TALLER = dr.GetString(p2);
                                oCampos.FECHA = dr.GetString(p3);
                                oCampos.NUM_PARTICIPANTES = dr.GetInt32(p4);
                                oCampos.OD = dr.GetString(p5);
                                oCampos.UBICACION = dr.GetString(p6);
                                oCampos.PUBLICO_OBJETIVO = dr.GetString(p7);

                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
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
        public List<CEntidad> RegMostrarCapacMensual(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCapacitacionXAnioXMes", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("anio");
                            int p2 = dr.GetOrdinal("mes");
                            int p3 = dr.GetOrdinal("N_Capacitacion");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetString(p2);
                                oCampos.NUM_CAPACITACIONES = dr.GetInt32(p3);
                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
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
        public List<CEntidad> RegMostrarCapacAnio(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCapacitacionXAnio", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("anio");
                            int p2 = dr.GetOrdinal("N_Capacitacion");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetInt32(p1).ToString();
                                oCampos.NUM_CAPACITACIONES = dr.GetInt32(p2);
                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
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
        public List<CEntidad> RegMostrarCapacMesDetalle(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCapacitacionesAnios", oCEntidad))
                {
                    lsCEntidad.List_Reporte_CAPACITACION = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("NOM_TALLER");
                            int p2 = dr.GetOrdinal("TIPO_TALLER");
                            int p3 = dr.GetOrdinal("FECHA");
                            int p4 = dr.GetOrdinal("NUM_PARTICIPANTES");
                            int p5 = dr.GetOrdinal("OD");
                            int p6 = dr.GetOrdinal("UBICACION");
                            int p7 = dr.GetOrdinal("PUBLICO_OBJETIVO");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NOM_TALLER = dr.GetString(p1);
                                oCampos.TIPO_TALLER = dr.GetString(p2);
                                oCampos.FECHA = dr.GetString(p3);
                                oCampos.NUM_PARTICIPANTES = dr.GetInt32(p4);
                                oCampos.OD = dr.GetString(p5);
                                oCampos.UBICACION = dr.GetString(p6);
                                oCampos.PUBLICO_OBJETIVO = dr.GetString(p7);
                                lsCEntidad.List_Reporte_CAPACITACION.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Reporte_CAPACITACION;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
