using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.GENE.Ent_UBIGEO;
using SQL = GeneralSQL.Data.SQL;
//using GeneralSQL;

namespace CapaDatos.GENE
{
    public class Dat_UBIGEO
    {
        private SQL oGDataSQL = new SQL();

        private DBOracle dBOracle = new DBOracle();

        public string RegMostrarUbigeoV3(OracleConnection cn, CEntidad oCEntidad)
        {
            string resultado = "";
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    dr.Read();
                    resultado = dr["listado"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public CEntidad RegMostrarUbigeo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        List<CEntidad> lsDetDepartamento = new List<CEntidad>();
                        List<CEntidad> lsDetProvincia = new List<CEntidad>();
                        List<CEntidad> lsDetDistrito = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //String COD_UBIDEPARTAMENTO = "";
                        //String COD_UBIPROVINCIA = "";
                        //
                        if (dr.HasRows)
                        {                            
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();

                                if (oCEntidad.BusCriterio == "DEPARTAMENTO")
                                {
                                    oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(dr.GetOrdinal("COD_UBIDEPARTAMENTO"));
                                    oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                    lsDetDepartamento.Add(oCamposDet);
                                    //COD_UBIDEPARTAMENTO = dr.GetString(p1);
                                }
                                //Cargando Provincia
                                else if (oCEntidad.BusCriterio == "PROVINCIA")
                                {
                                    oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(dr.GetOrdinal("COD_UBIDEPARTAMENTO"));
                                    oCamposDet.COD_UBIPROVINCIA = dr.GetString(dr.GetOrdinal("COD_UBIPROVINCIA"));
                                    oCamposDet.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                    lsDetProvincia.Add(oCamposDet);
                                    //COD_UBIPROVINCIA = dr.GetString(p2);
                                }
                                else if (oCEntidad.BusCriterio == "DISTRITO")
                                {
                                    oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(dr.GetOrdinal("COD_UBIDEPARTAMENTO"));
                                    oCamposDet.COD_UBIPROVINCIA = dr.GetString(dr.GetOrdinal("COD_UBIPROVINCIA"));
                                    oCamposDet.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                                    oCamposDet.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                    lsDetDistrito.Add(oCamposDet);
                                }
                            }
                        }

                        oCampos.ListDepartamento = lsDetDepartamento;
                        oCampos.ListProvincia = lsDetProvincia;
                        oCampos.ListDistrito = lsDetDistrito;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        /*public CEntidad RegMostrarUbigeo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        List<CEntidad> lsDetDepartamento = new List<CEntidad>();
                        List<CEntidad> lsDetProvincia = new List<CEntidad>();
                        List<CEntidad> lsDetDistrito = new List<CEntidad>();
                        CEntidad oCamposDet;
                        String COD_UBIDEPARTAMENTO = "";
                        String COD_UBIPROVINCIA = "";
                        //
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_UBIDEPARTAMENTO");
                            int p2 = dr.GetOrdinal("COD_UBIPROVINCIA");
                            int p3 = dr.GetOrdinal("COD_UBIGEO");
                            int p4 = dr.GetOrdinal("DEPARTAMENTO");
                            int p5 = dr.GetOrdinal("PROVINCIA");
                            int p6 = dr.GetOrdinal("DISTRITO");
                            while (dr.Read())
                            {
                                if (COD_UBIDEPARTAMENTO == "" || COD_UBIDEPARTAMENTO != dr.GetString(p1))
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(p1);
                                    oCamposDet.DEPARTAMENTO = dr.GetString(p4);
                                    lsDetDepartamento.Add(oCamposDet);
                                    COD_UBIDEPARTAMENTO = dr.GetString(p1);
                                }
                                //Cargando Provincia
                                if (COD_UBIPROVINCIA == "" || COD_UBIPROVINCIA != dr.GetString(p2))
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(p1);
                                    oCamposDet.COD_UBIPROVINCIA = dr.GetString(p2);
                                    oCamposDet.PROVINCIA = dr.GetString(p5);
                                    lsDetProvincia.Add(oCamposDet);
                                    COD_UBIPROVINCIA = dr.GetString(p2);
                                }
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(p1);
                                oCamposDet.COD_UBIPROVINCIA = dr.GetString(p2);
                                oCamposDet.COD_UBIGEO = dr.GetString(p3);
                                oCamposDet.DISTRITO = dr.GetString(p6);
                                lsDetDistrito.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDepartamento = lsDetDepartamento;
                        oCampos.ListProvincia = lsDetProvincia;
                        oCampos.ListDistrito = lsDetDistrito;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }*/

    }
}
