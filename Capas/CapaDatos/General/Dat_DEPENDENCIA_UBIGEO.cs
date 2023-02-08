using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.GENE.Ent_DEPENDENCIA_UBIGEO;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.GENE
{
    public class Dat_DEPENDENCIA_UBIGEO
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();


        public CEntidad RegMostrarCombo(CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {

                            CEntidad oCamposDet;

                            if (dr.HasRows)
                            {
                                int p1 = dr.GetOrdinal("CODIGO");
                                int p2 = dr.GetOrdinal("DESCRIPCION");
                                oCampos.ListDependencia = new List<CEntidad>();
                                while (dr.Read())
                                {

                                    oCamposDet = new CEntidad();
                                    oCamposDet.CODIGO = dr.GetInt32(p1).ToString();
                                    oCamposDet.DESCRIPCION = dr.GetString(p2);
                                    oCampos.ListDependencia.Add(oCamposDet);
                                }
                            }

                        }
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

    }
}
