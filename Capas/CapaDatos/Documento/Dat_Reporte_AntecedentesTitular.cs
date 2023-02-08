using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_AntecedentesTitular;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reporte_AntecedentesTitular
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarReporte(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            CEntidad oCamposDet;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spREPORTE_ANTECEDENTESxTITULAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListAntecedentes = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            //Cabecera Reporte
                            dr.Read();
                            oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));

                            //Detalle Reporte
                            dr.NextResult(); 
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                    oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                    oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                    oCamposDet.INFRACCION = dr.GetString(dr.GetOrdinal("INFRACCION"));
                                    oCamposDet.SANCION = dr.GetString(dr.GetOrdinal("SANCION"));
                                    oCamposDet.MULTA = dr.GetDecimal(dr.GetOrdinal("MULTA"));
                                    oCamposDet.RESOLUCION = dr.GetString(dr.GetOrdinal("RESOLUCION"));
                                    oCamposDet.ESTADO_PAU = dr.GetString(dr.GetOrdinal("ESTADO_PAU"));
                                    oCamposDet.FECHA_NOTIFICACION = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICACION"));
                                    oCamposDet.NUMRESOLUCIONFORESTAL = dr.GetString(dr.GetOrdinal("NUMRESOLUCIONFORESTAL"));
                                    oCamposDet.FECRESOLUCIONFORESTAL = dr.GetString(dr.GetOrdinal("FECRESOLUCIONFORESTAL"));

                                    oCampos.ListAntecedentes.Add(oCamposDet);
                                }
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
    }
}
