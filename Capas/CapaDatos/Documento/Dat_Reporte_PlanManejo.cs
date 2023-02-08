using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_PlanManejo;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reporte_PlanManejo
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public List<CEntidad> MostrarPlanesManejoXpersona_Resumen(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReportePlanesManejoXpersona", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        int npm = 0, npmi = 0, nas = 0, nai = 0;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.LOCADOR = dr.GetString(dr.GetOrdinal("LOCADOR"));
                                oCampos.NUM_PMANEJO = dr.GetInt32(dr.GetOrdinal("NUM_PMANEJO"));
                                oCampos.NUM_PMANEJO_INEX = dr.GetInt32(dr.GetOrdinal("NUM_PMANEJO_INEX"));
                                oCampos.NUM_ARBOL_SUPERV = dr.GetInt32(dr.GetOrdinal("NUM_ARBOL_SUPERV"));
                                oCampos.NUM_ARBOL_INEX = dr.GetInt32(dr.GetOrdinal("NUM_ARBOL_INEX"));
                                oCampos.PORC_ARBOL_INEX = dr.GetDecimal(dr.GetOrdinal("PORC_ARBOL_INEX"));
                                lsCEntidad.Add(oCampos);

                                npm += oCampos.NUM_PMANEJO;
                                npmi += oCampos.NUM_PMANEJO_INEX;
                                nas += oCampos.NUM_ARBOL_SUPERV;
                                nai += oCampos.NUM_ARBOL_INEX;
                            }
                        }

                        oCampos = new CEntidad();
                        oCampos.LOCADOR = "Total";
                        oCampos.NUM_PMANEJO = npm;
                        oCampos.NUM_PMANEJO_INEX = npmi;
                        oCampos.NUM_ARBOL_SUPERV = nas;
                        oCampos.NUM_ARBOL_INEX = nai;
                        oCampos.PORC_ARBOL_INEX = nas > 0 ? (nai * 100) / nas : 0;

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
        public List<CEntidad> MostrarPlanesManejoXpersona_Detalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReportePlanesManejoXpersona", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCampos.ANIO_SUPERV = dr.GetString(dr.GetOrdinal("ANIO_SUPERV"));
                                oCampos.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                oCampos.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                                oCampos.POA = dr.GetString(dr.GetOrdinal("POA"));
                                oCampos.RES_APRUEBA_POA = dr.GetString(dr.GetOrdinal("RES_APRUEBA_POA"));
                                oCampos.VOL_APROBADO = dr.GetDecimal(dr.GetOrdinal("VOL_APROBADO"));
                                oCampos.NUM_ARBOL_APROBADO = dr.GetInt32(dr.GetOrdinal("NUM_ARBOL_APROBADO"));
                                oCampos.NUM_ARBOL_SUPERV = dr.GetInt32(dr.GetOrdinal("NUM_ARBOL_SUPERV"));
                                oCampos.NUM_ARBOL_INEX = dr.GetInt32(dr.GetOrdinal("NUM_ARBOL_INEX"));
                                oCampos.RD_INICIO_PAU = dr.GetString(dr.GetOrdinal("RD_INICIO_PAU"));
                                oCampos.RD_TERMINO_PAU = dr.GetString(dr.GetOrdinal("RD_TERMINO_PAU"));
                                oCampos.ESTADO_PAU = dr.GetString(dr.GetOrdinal("ESTADO_PAU"));
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
