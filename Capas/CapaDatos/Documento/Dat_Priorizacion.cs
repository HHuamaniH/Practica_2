using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using CEntidad = CapaEntidad.DOC.Ent_Priorizacion;
using CEntidad2 = CapaEntidad.DOC.Ent_Priorizacion_Detalle;
using CEntidad3 = CapaEntidad.DOC.Ent_Criterio_Focalizacion;
//using SQL = GeneralSQL.Data.SQL;
//using System.Xml;

namespace CapaDatos.DOC
{
    public class Dat_Priorizacion
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        public List<Ent_Plan_Manejo_Supervisado> GetListPlanManejoSupervisado(OracleConnection cn, Ent_Plan_Manejo_Supervisado ent)
        {
            List<Ent_Plan_Manejo_Supervisado> respuesta = new List<Ent_Plan_Manejo_Supervisado>();
            Ent_Plan_Manejo_Supervisado oCampos;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_Planes_Manejo_Supervisados", ent))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new Ent_Plan_Manejo_Supervisado();
                                oCampos.NUM_THABILITANTE = dr.GetString(0);
                                oCampos.NOMBRE_POA = dr.GetString(1);
                                oCampos.MODALIDAD = dr.GetString(2);
                                respuesta.Add(oCampos);
                            }
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad3> GetListCriterios(OracleConnection cn)
        {
            List<CEntidad3> respuesta = new List<CEntidad3>();
            CEntidad3 oCampos;
            CEntidad3 ent = new CEntidad3();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_Criterios_Lista", ent))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad3();
                                oCampos.CODIGO = dr.GetString(0);
                                oCampos.DESCRIPCION = dr.GetString(1);
                                oCampos.PUNTAJE = dr.GetDecimal(2);
                                respuesta.Add(oCampos);
                            }
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad2> DatosReportePriorizacion(OracleConnection cn, CEntidad ent)
        {
            List<CEntidad2> respuesta = new List<CEntidad2>();
            CEntidad2 oCampos;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_Priorizacion_Lista", ent))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad2();
                                //COD_PASPEQ_DETALLE
                                oCampos.COD_PASPEQ_DETALLE = Convert.ToInt32(dr["COD_PASPEQ_DETALLE"]);
                                //NUM_THABILITANTE
                                oCampos.NUM_THABILITANTE = dr.GetString(1);
                                //OD_AMBITO
                                oCampos.OD_AMBITO = dr.GetString(2);
                                //NOMBRE_POA
                                oCampos.NOMBRE_POA = dr.GetString(3);
                                //A1
                                oCampos.A1 = Convert.ToDouble(dr["A1"]);
                                //A2
                                oCampos.A2 = Convert.ToDouble(dr["A2"]);
                                //A3
                                oCampos.A3 = Convert.ToDouble(dr["A3"]);
                                //A4
                                oCampos.A4 = Convert.ToDouble(dr["A4"]);
                                //A5
                                oCampos.A5 = Convert.ToDouble(dr["A5"]);
                                //A6
                                oCampos.A6 = Convert.ToDouble(dr["A6"]);
                                //A7
                                oCampos.A7 = Convert.ToDouble(dr["A7"]);
                                //A8
                                oCampos.A8 = Convert.ToDouble(dr["A8"]);
                                //B1
                                oCampos.B1 = Convert.ToDouble(dr["B1"]);
                                //B2
                                oCampos.B2 = Convert.ToDouble(dr["B2"]);
                                //B3
                                oCampos.B3 = Convert.ToDouble(dr["B3"]);
                                //B4
                                oCampos.B4 = Convert.ToDouble(dr["B4"]);
                                //B5
                                oCampos.B5 = Convert.ToDouble(dr["B5"]);
                                //B6
                                oCampos.B6 = Convert.ToDouble(dr["B6"]);
                                //TOTAL
                                oCampos.TOTAL = Convert.ToDouble(dr["TOTAL"]);
                                respuesta.Add(oCampos);
                            }
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean SeleccionarCriterios(OracleConnection cn, List<Ent_Priorizacion_Detalle> listaPriorizacion, Ent_Priorizacion ent)
        {
            OracleTransaction tr = null;
            //List<Ent_Priorizacion_Detalle> respuesta = new List<Ent_Priorizacion_Detalle>();
            //Ent_Priorizacion_Detalle oCampos;
            try
            {
                tr = cn.BeginTransaction();

                foreach (var oDatos in listaPriorizacion)
                {
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_Priorizacion_Modificar", oDatos);
                }
                tr.Commit();
                return true;
                /*
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spPASPEQ_Priorizacion_Lista", ent))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad2();
                                oCampos.COD_PASPEQ_DETALLE = dr.GetInt32(dr.GetOrdinal("COD_PASPEQ_DETALLE"));
                                oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampos.OD_AMBITO = dr.GetString(dr.GetOrdinal("OD_AMBITO"));
                                oCampos.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                oCampos.A1 = dr.GetDouble(dr.GetOrdinal("A1"));
                                oCampos.A2 = dr.GetDouble(dr.GetOrdinal("A2"));
                                oCampos.A3 = dr.GetDouble(dr.GetOrdinal("A3"));
                                oCampos.A4 = dr.GetDouble(dr.GetOrdinal("A4"));
                                oCampos.A5 = dr.GetDouble(dr.GetOrdinal("A5"));
                                oCampos.A6 = dr.GetDouble(dr.GetOrdinal("A6"));
                                oCampos.A7 = dr.GetDouble(dr.GetOrdinal("A7"));
                                oCampos.A8 = dr.GetDouble(dr.GetOrdinal("A8"));
                                oCampos.B1 = dr.GetDouble(dr.GetOrdinal("B1"));
                                oCampos.B2 = dr.GetDouble(dr.GetOrdinal("B2"));
                                oCampos.B3 = dr.GetDouble(dr.GetOrdinal("B3"));
                                oCampos.B4 = dr.GetDouble(dr.GetOrdinal("B4"));
                                oCampos.B5 = dr.GetDouble(dr.GetOrdinal("B5"));
                                oCampos.B6 = dr.GetDouble(dr.GetOrdinal("B6"));
                                oCampos.TOTAL = dr.GetDouble(dr.GetOrdinal("TOTAL"));
                                respuesta.Add(oCampos);
                            }
                        }
                    }
                }
                */

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
