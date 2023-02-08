using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ProduccionItinerarioSupervision;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reporte_ProduccionItinerarioSupervision
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public List<CEntidad> MostReporteResumen(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProduccionItinerarioSupervision", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();

                                oCampos.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
                                oCampos.OD = dr.GetString(dr.GetOrdinal("OD"));
                                oCampos.TOTAL = dr.GetInt32(dr.GetOrdinal("TOTAL"));

                                oCampos.PFAUNA = dr.GetInt32(dr.GetOrdinal("PFAUNA"));
                                oCampos.M0000005 = dr.GetInt32(dr.GetOrdinal("M0000005"));
                                oCampos.M0000006 = dr.GetInt32(dr.GetOrdinal("M0000006"));
                                oCampos.M0000014 = dr.GetInt32(dr.GetOrdinal("M0000014"));
                                oCampos.CC_CC_NN = dr.GetInt32(dr.GetOrdinal("CC_CC_NN"));
                                oCampos.M0000017 = dr.GetInt32(dr.GetOrdinal("M0000017"));
                                oCampos.PNM = dr.GetInt32(dr.GetOrdinal("PNM"));
                                oCampos.M0000007 = dr.GetInt32(dr.GetOrdinal("M0000007"));
                                oCampos.NM = dr.GetInt32(dr.GetOrdinal("NM"));
                                oCampos.M0000010 = dr.GetInt32(dr.GetOrdinal("M0000010"));
                                oCampos.M0000011 = dr.GetInt32(dr.GetOrdinal("M0000011"));
                                oCampos.M0000012 = dr.GetInt32(dr.GetOrdinal("M0000012"));
                                oCampos.CFAUNA = dr.GetInt32(dr.GetOrdinal("CFAUNA"));

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

        public List<CEntidad> MostReporteDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos;
            //try
            //{
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProduccionItinerarioSupervision", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();

                                oCampos.OD = dr.GetString(dr.GetOrdinal("OD"));
                                oCampos.NUM_CNOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                                oCampos.SUPERVISOR = dr.GetString(dr.GetOrdinal("SUPERVISOR"));
                                oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCampos.POAS = dr.GetString(dr.GetOrdinal("POAS"));
                                oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCampos.FECHA_SALIDA = dr.GetString(dr.GetOrdinal("FECHA_SALIDA"));
                                oCampos.FECHA_LLEGADA = dr.GetString(dr.GetOrdinal("FECHA_LLEGADA"));
                                oCampos.SUPERVISADO_TEXT = dr.GetString(dr.GetOrdinal("SUPERVISADO_TEXT"));
                                oCampos.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                                oCampos.ALERTA = dr.GetString(dr.GetOrdinal("ALERTA"));
                                oCampos.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                oCampos.ABREVIADO_SUBPER = dr.GetString(dr.GetOrdinal("ABREVIADO_SUBPER"));
                                oCampos.NOMBRE_ARCH = dr.GetString(dr.GetOrdinal("NOMBRE_ARCH"));
                                oCampos.RUTA_ARCH = dr.GetString(dr.GetOrdinal("RUTA_ARCH"));
                                oCampos.EXTENSION_ARCH = dr.GetString(dr.GetOrdinal("EXTENSION_ARCH"));

                                lsCEntidad.Add(oCampos);
                            }

                        }
                    }
                }
                return lsCEntidad;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
