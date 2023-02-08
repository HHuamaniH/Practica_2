using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_SINCRONIZACION;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_SINCRONIZACION
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarLista(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad(); ;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListSincronizaciones = new List<CEntidad>();
                        oCampos.ListConfCreated = new List<CEntidad>();
                        oCampos.ListConfAlter = new List<CEntidad>();
                        List<CEntidad> lsCEntidad;
                        CEntidad oCamposDet;
                        lsCEntidad = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SINCRONIZACION");
                            int pt2 = dr.GetOrdinal("COD_OD_SINCRO_ORIGEN");
                            int pt3 = dr.GetOrdinal("OD_ORIGEN");
                            int pt4 = dr.GetOrdinal("COD_OD_SINCRO_DESTINO");
                            int pt5 = dr.GetOrdinal("OD_DESTINO");
                            int pt6 = dr.GetOrdinal("DESCRIPCION_SINCRO");
                            int pt7 = dr.GetOrdinal("TIPO_SINCRO");
                            int pt8 = dr.GetOrdinal("FECHA_SINCRO");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SINCRONIZACION = dr.GetString(pt1);
                                oCamposDet.COD_OD_SINCRO_ORIGEN = dr.GetString(pt2);
                                oCamposDet.OD_ORIGEN = dr.GetString(pt3);
                                oCamposDet.COD_OD_SINCRO_DESTINO = dr.GetString(pt4);
                                oCamposDet.OD_DESTINO = dr.GetString(pt5);
                                oCamposDet.DESCRIPCION_SINCRO = dr.GetString(pt6);
                                oCamposDet.TIPO_SINCRO = dr.GetString(pt7);
                                oCamposDet.FECHA_SINCRO = dr.GetString(pt8);
                                lsCEntidad.Add(oCamposDet);
                            }
                        }
                        oCampos.ListSincronizaciones = lsCEntidad;
                        //Configuración Create
                        dr.NextResult();
                        lsCEntidad = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NAME_CREATE");
                            int pt2 = dr.GetOrdinal("FECHA_CREATE");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NAME_CREATE = dr.GetString(pt1);
                                oCamposDet.FECHA_CREATE = dr.GetString(pt2);
                                lsCEntidad.Add(oCamposDet);
                            }
                        }
                        oCampos.ListConfCreated = lsCEntidad;
                        //Configuración Alter
                        dr.NextResult();
                        lsCEntidad = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NAME_ALTER");
                            int pt2 = dr.GetOrdinal("FECHA_ALTER");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NAME_ALTER = dr.GetString(pt1);
                                oCamposDet.FECHA_ALTER = dr.GetString(pt2);
                                lsCEntidad.Add(oCamposDet);
                            }
                        }
                        oCampos.ListConfAlter = lsCEntidad;
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
        //public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                List<CEntidad> lsDetDetalle;
        //                CEntidad oCamposDet;
        //                //
        //                //OD ORIGEN
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListOD_Origen = lsDetDetalle;
        //                //
        //                //OD DESTINO
        //                dr.NextResult();
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListOD_Destino = lsDetDetalle;
        //                //
        //                //TABLAS SINCRO
        //                dr.NextResult();
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListTablas = lsDetDetalle;
        //                //                         
        //            }
        //        }
        //        return oCampos;
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
        public CEntidad RegSincronizar(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "HERR.spSINCRONIZACION", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("OUTPUTPARAM01");
                            int pt2 = dr.GetOrdinal("OUTPUTPARAM03");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.OUTPUTPARAM01 = dr.GetString(pt1);
                                oCampos.OUTPUTPARAM03 = dr.GetString(pt2);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegEliminar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_SINCRONIZACION = loDatos.COD_SINCRONIZACION;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oGDataSQL.ManExecute(cn, tr, "HERR.spSINCRONIZACIONEliminar", oCamposDet);
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
        public CEntidad RegProcedimientos(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "HERR.spPROCEDIMIENTOS", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }

                oCEntidad.OUTPUTPARAM01 = OUTPUTPARAM01;

                tr.Commit();
                return oCEntidad;
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
    }
}
