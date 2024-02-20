using CapaEntidad.DOC;
using Oracle.ManagedDataAccess.Client;
using GeneralSQL.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos.DOC
{
    public class Dat_BEXTRACCION
    {
        private SQL oGDataSQL;
        private GeneralSQL.DBOracle dBOracle = new GeneralSQL.DBOracle();
        private OracleTransaction transaction;

        public Dat_BEXTRACCION()
        {
            oGDataSQL = new SQL();
            transaction = null;
        }

        public Ent_BEXTRACCION RegMostrarItems(Ent_BEXTRACCION oCEntidad)
        {
            Ent_BEXTRACCION lsCEntidad = new Ent_BEXTRACCION();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    Ent_BEXTRACCION oExtra = new Ent_BEXTRACCION();
                    oExtra.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                    oExtra.NUM_POA = oCEntidad.NUM_POA;
                    cn.Open();
                    //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spBEXTRACCIONMostItems", oCEntidad))
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spBEXTRACCIONMostItems", oExtra))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                #region "Cargar datos generales"
                                dr.Read();
                                lsCEntidad.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                lsCEntidad.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                lsCEntidad.ARESOLUCION_NUM = dr.GetString(dr.GetOrdinal("ARESOLUCION_NUM"));
                                lsCEntidad.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                lsCEntidad.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                lsCEntidad.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
                                lsCEntidad.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                lsCEntidad.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                                lsCEntidad.INDICADOR = dr.GetString(dr.GetOrdinal("INDICADOR"));
                                #endregion
                            }
                        }
                    }
                    cn.Close();
                }

                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public List<Ent_BEXTRACCION_FECEMI> ListarBExtraccionPorPlan(Ent_BEXTRACCION oCEntidad)
        {
            List<Ent_BEXTRACCION_FECEMI> olResult = new List<Ent_BEXTRACCION_FECEMI>();
            int ind = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    Ent_BEXTRACCION oExtra = new Ent_BEXTRACCION();
                    oExtra.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                    oExtra.NUM_POA = oCEntidad.NUM_POA;
                    //using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spBEXTRACCION_FechaEmision_Listar", oCEntidad))
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spBEXTRACCION_FechaEmision_Listar", oExtra))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_BEXTRACCION_FECEMI oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_BEXTRACCION_FECEMI();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampos.BEXTRACCION_FEMISION = dr["BEXTRACCION_FEMISION"].ToString();
                                    oCampos.RegEstado = 2;
                                    oCampos.SELECTED = ind == 0 ? 1 : -1;
                                    olResult.Add(oCampos);
                                    ind++;
                                }
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarBExtraccionFecEmi(Ent_BEXTRACCION_FECEMI oCEntidad)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    //oGDataSQL.ManExecute(cn, transaction, "DOC.spPOA_DET_BEXTRACCIONGrabar", oCEntidad);
                    dBOracle.ManExecute(cn, transaction, "doc_osinfor_erp_migracion.spPOA_DET_BEXTRACCIONGrabar", oCEntidad);
                    transaction.Commit();
                    
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
                cn.Close();
            }
        }

        public void EliminarBExtraccion(Ent_BEXTRACCION_EliTABLA oCEntidad)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    //oGDataSQL.ManExecute(cn, transaction, "DOC.spBEXTRACCIONEliminar", oCEntidad);
                    dBOracle.ManExecute(cn, transaction, "doc_osinfor_erp_migracion.spBEXTRACCIONEliminar", oCEntidad);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw ex;
                }
                finally { transaction = null; }
                cn.Close();
            }
        }

        public List<Ent_BEXTRACCION_MADE> ListarBExtraccionMaderable(Ent_BEXTRACCION_FECEMI oCEntidad)
        {
            List<Ent_BEXTRACCION_MADE> olResult = new List<Ent_BEXTRACCION_MADE>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    //using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spBEXTRACCION_MADERABLE_Listar", oCEntidad))
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spBEXTRACCION_MADERABLE_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_BEXTRACCION_MADE oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_BEXTRACCION_MADE();
                                    oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampos.ESPECIES = dr["ESPECIES"].ToString();
                                    oCampos.DMC = Int32.Parse(dr["DMC"].ToString());//Maderable
                                    oCampos.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL_ARBOLES"].ToString());//Maderable
                                    oCampos.VOLUMEN_MOVILIZADO = decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    oCampos.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oCampos.SALDO = decimal.Parse(dr["SALDO"].ToString());
                                    oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampos.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();//Maderable
                                    oCampos.COD_ESPECIES_SERFOR = dr["COD_ESPECIES_SERFOR"].ToString();
                                    oCampos.ESPECIES_SERFOR = dr["ESPECIES_SERFOR"].ToString();
                                    oCampos.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                    oCampos.COD_PARCELA = dr["COD_PARCELA"].ToString();
                                    oCampos.PC = dr["PC"].ToString();
                                    oCampos.AUTORIZADO = decimal.Parse(dr["AUTORIZADO"].ToString());//No Maderable
                                    oCampos.EXTRAIDO = decimal.Parse(dr["EXTRAIDO"].ToString());//No Maderable
                                    oCampos.FECHA1 = dr["FECHA1"].ToString();//No Maderable
                                    oCampos.FECHA2 = dr["FECHA2"].ToString();//No Maderable
                                    oCampos.GUIA_TRANSPORTE = dr["GUIA_TRANSPORTE"].ToString();//No Maderable
                                    oCampos.CANTIDAD = Int32.Parse(dr["CANTIDAD"].ToString());//No Maderable
                                    oCampos.RECIBO = dr["RECIBO"].ToString();//No Maderable
                                    oCampos.RegEstado = 2;

                                    if (oCampos.UNIDAD_MEDIDA.Trim().Equals("") || oCampos.UNIDAD_MEDIDA.Equals("-"))
                                    {
                                        if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                        //else if (oCampos.TIPOMADERABLE.Equals("CARBON")) oCampos.UNIDAD_MEDIDA = "KG";
                                        else if (oCampos.TIPOMADERABLE.Equals("CARBON") || oCampos.TIPOMADERABLE.Equals("NO MADERABLES")) oCampos.UNIDAD_MEDIDA = "KG";
                                    }

                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarBExtraccionMaderable(List<Ent_BEXTRACCION_MADE> olCEntidad, string asCodUCuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    foreach (var item in olCEntidad)
                    {
                        item.COD_UCUENTA = asCodUCuenta;
                        item.COD_ESPECIES_SERFOR = item.COD_ESPECIES_SERFOR == "-" ? null : item.COD_ESPECIES_SERFOR;
                        if (item.FECHA1 != null) item.FECHA1 = (item.FECHA1.Trim() == "") ? null : item.FECHA1;
                        if (item.FECHA2 != null) item.FECHA2 = (item.FECHA2.Trim() == "") ? null : item.FECHA2;
                        //oGDataSQL.ManExecute(cn, transaction, "DOC.spPOA_DET_MADERABLE_BEXTRACCIONGrabarV3", item);
                        dBOracle.ManExecute(cn, transaction, "doc_osinfor_erp_migracion.spPOA_DET_MADERABLE_BEXTRACCIONGrabarV3", item);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public List<Ent_BEXTRACCION_NOMADE> ListarBExtraccionNoMaderable(Ent_BEXTRACCION_FECEMI oCEntidad)
        {
            List<Ent_BEXTRACCION_NOMADE> olResult = new List<Ent_BEXTRACCION_NOMADE>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    //using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spBEXTRACCION_NO_MADERABLE_Listar", oCEntidad))
                    Ent_BEXTRACCION_FECEMI oEnt = new Ent_BEXTRACCION_FECEMI();
                    oEnt.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                    oEnt.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                    oEnt.NUM_POA = oCEntidad.NUM_POA;
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spBEXTRACCION_NO_MADERABLE_Listar", oEnt))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_BEXTRACCION_NOMADE oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_BEXTRACCION_NOMADE();
                                    oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampos.ESPECIES = dr["ESPECIES"].ToString(); //dr.GetDecimal(dr.GetOrdinal("VOLUMEN_KILOGRAMOS"));
                                    oCampos.KILOGRAMO_AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("KILOGRAMO_AUTORIZADO")); //decimal.Parse(dr["KILOGRAMO_AUTORIZADO"].ToString());
                                    oCampos.KILOGRAMO_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("KILOGRAMO_MOVILIZADO")); //decimal.Parse(dr["KILOGRAMO_MOVILIZADO"].ToString());
                                    oCampos.SALDO = dr.GetDecimal(dr.GetOrdinal("SALDO")); //decimal.Parse(dr["SALDO"].ToString());
                                    oCampos.FECHA1 = dr["FECHA1"].ToString();
                                    oCampos.FECHA2 = dr["FECHA2"].ToString();
                                    oCampos.GUIA_TRANSPORTE = dr["GUIA_TRANSPORTE"].ToString();
                                    oCampos.CANTIDAD = Int32.Parse(dr["CANTIDAD"].ToString());
                                    oCampos.RECIBO = dr["RECIBO"].ToString();
                                    oCampos.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                    oCampos.AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("AUTORIZADO")); //decimal.Parse(dr["AUTORIZADO"].ToString());
                                    oCampos.EXTRAIDO = dr.GetDecimal(dr.GetOrdinal("EXTRAIDO")); //decimal.Parse(dr["EXTRAIDO"].ToString());
                                    oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampos.COD_ESPECIES_SERFOR = dr["COD_ESPECIES_SERFOR"].ToString();
                                    oCampos.ESPECIES_SERFOR = dr["ESPECIES_SERFOR"].ToString();
                                    oCampos.RegEstado = 2;
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarBExtraccionNoMaderable(List<Ent_BEXTRACCION_NOMADE> olCEntidad, string asCodUCuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    foreach (var item in olCEntidad)
                    {
                        item.COD_UCUENTA = asCodUCuenta;
                        item.COD_ESPECIES_SERFOR = item.COD_ESPECIES_SERFOR == "-" ? null : item.COD_ESPECIES_SERFOR;
                        //oGDataSQL.ManExecute(cn, transaction, "DOC.spPOA_DET_NOMADERABLE_BEXTRACCIONGrabarV3", item);
                        dBOracle.ManExecute(cn, transaction, "doc_osinfor_erp_migracion.spPOA_DET_NOMADERABLE_BEXTRACCIONGrabarV3", item);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public List<Ent_BEXTRACCION_KARDEX> ListarBExtraccionKardex(Ent_BEXTRACCION oCEntidad)
        {
            List<Ent_BEXTRACCION_KARDEX> olResult = new List<Ent_BEXTRACCION_KARDEX>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    /*Ent_BEXTRACCION oExtra2 = new Ent_BEXTRACCION();
                    oExtra2.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                    oExtra2.NUM_POA = oCEntidad.NUM_POA;
                    oExtra2.NOMBRE_POA = " ";
                    oExtra2.ARESOLUCION_NUM = " ";
                    oExtra2.NUM_THABILITANTE = " ";
                    oExtra2.TITULAR = " ";
                    oExtra2.MODALIDAD = " ";
                    oExtra2.ESTADO_ORIGEN = " ";
                    oExtra2.COD_MTIPO = " ";
                    oExtra2.INDICADOR = " ";
                    */

                    cn.Open();
                    //using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spBEXTRACCION_KARDEX_Listar", oCEntidad))
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spBEXTRACCION_KARDEX_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_BEXTRACCION_KARDEX oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_BEXTRACCION_KARDEX();
                                    oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampos.ESPECIES = dr["ESPECIES"].ToString();
                                    oCampos.FECHA_EMISIONKARDEX = dr["FECHA_EMISIONKARDEX"].ToString();
                                    oCampos.GUIA_TRANSPORTE = dr["GUIA_TRANSPORTE"].ToString();
                                    oCampos.COD_KARDEX_PRODUCTO = dr["COD_KARDEX_PRODUCTO"].ToString();
                                    oCampos.COD_KARDEX_DESCRIPCION = dr["COD_KARDEX_DESCRIPCION"].ToString();
                                    oCampos.CANTIDAD = Int32.Parse(dr["CANTIDAD"].ToString());
                                    oCampos.KILOGRAMOS_KARDEX = decimal.Parse(dr["KILOGRAMOS_KARDEX"].ToString());
                                    oCampos.M3 = decimal.Parse(dr["M3"].ToString());
                                    oCampos.ACUMULADO = decimal.Parse(dr["ACUMULADO"].ToString());
                                    oCampos.SALDO_KARDEX = decimal.Parse(dr["SALDO_KARDEX"].ToString());
                                    oCampos.OBSERVACION_KARDEX = dr["OBSERVACION_KARDEX"].ToString();
                                    oCampos.KARDEX_PRODUCTO = dr["PRODUCTO"].ToString();
                                    oCampos.KARDEX_DESCRIPCION = dr["DESCRIPCION_KARDEX"].ToString();
                                    oCampos.RegEstado = 2;
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarBExtraccionKardex(List<Ent_BEXTRACCION_KARDEX> olCEntidad, string asCodUCuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    foreach (var item in olCEntidad)
                    {
                        item.COD_UCUENTA = asCodUCuenta;
                        //oGDataSQL.ManExecute(cn, transaction, "DOC.spPOA_DET_KARDEXGrabarV3", item);
                        dBOracle.ManExecute(cn, transaction, "doc_osinfor_erp_migracion.spPOA_DET_KARDEXGrabarV3", item);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }
    }
}
