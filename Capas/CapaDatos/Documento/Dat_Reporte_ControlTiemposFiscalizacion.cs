using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ControlTiemposFiscalizacion;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reporte_ControlTiemposFiscalizacion
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarControlTiemposResumen(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lstCEntidad;
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.spReporteControlTiemposFiscalizacion", oCEntidad))
                {
                    lstCEntidad = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = dr["COD_TPROCESO"].ToString();
                                oCampos.TIPO_PROCESO = dr["TIPO_PROCESO"].ToString();
                                oCampos.VERDE = Int32.Parse(dr["VERDE"].ToString());
                                oCampos.AMARILLO = Int32.Parse(dr["AMARILLO"].ToString());
                                oCampos.ROJO = Int32.Parse(dr["ROJO"].ToString());
                                oCampos.TOTAL = Int32.Parse(dr["TOTAL"].ToString());
                                oCampos.ORDEN = Int32.Parse(dr["ORDEN"].ToString());
                                lstCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCEntidad;
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
        public List<CEntidad> RegMostrarControlTiemposDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lstCEntidad;
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.spReporteControlTiemposFiscalizacion", oCEntidad))
                {
                    lstCEntidad = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_REGISTRO = dr["COD_REGISTRO"].ToString();
                                oCampos.NUM_DOCUMENTO = dr["NUM_DOCUMENTO"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.NOMBRE_RESPONSABLE = dr["NOMBRE_RESPONSABLE"].ToString();
                                oCampos.FECHA_INICIO = dr["FECHA_INICIO"].ToString();
                                oCampos.DIFFDIA = Int32.Parse(dr["DIFFDIA"].ToString());
                                oCampos.COLOR = dr["COLOR"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                if (oCEntidad.COD_TPROCESO == "0000009" || oCEntidad.COD_TPROCESO == "0000013")
                                {
                                    oCampos.FECHA_NOTIFICA = dr["FECHA_NOTIFICA"].ToString();

                                    if (oCEntidad.COD_TPROCESO == "0000013")
                                    {
                                        oCampos.NUM_RESOLUCION = dr["NUM_RESOLUCION"].ToString();
                                    }
                                }
                                lstCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
