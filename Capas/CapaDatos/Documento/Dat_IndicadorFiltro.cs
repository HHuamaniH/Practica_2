using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidad = CapaEntidad.DOC.Ent_IndicadorFiltro;

namespace CapaDatos.DOC
{
    public class Dat_IndicadorFiltro
    {
        private DBOracle dBOracle = new DBOracle();

        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDSFFS_Indicadores_listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListIndicador = new List<CEntidad>();
                        CEntidad oCamposDet;

                        //Tab MAPRO Filtro Indicador
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_INDICADOR = dr.GetString(dr.GetOrdinal("COD_INDICADOR"));
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCamposDet.META = dr.GetString(dr.GetOrdinal("META"));
                                oCampos.ListIndicador.Add(oCamposDet);
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

        public CEntidad RegMostComboAnio(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDSFFS_Lista", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListAnio = new List<CEntidad>();
                        CEntidad oCamposDet;

                        //Tab MAPRO Filtro Anio
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListAnio.Add(oCamposDet);
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

        public List<Dictionary<string, string>> Reporte(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDSFFS_Lista", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            string sColumn = "";

                            while (dr.Read())
                            {
                                sFila = new Dictionary<string, string>();
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    sColumn = dr.GetName(i);
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostMeta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCPDETIND_META_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.NV_CODIGO = dr.GetString(dr.GetOrdinal("NV_CODIGO"));
                            oCampos.NV_INDICADOR = dr.GetString(dr.GetOrdinal("NV_INDICADOR"));
                            oCampos.NU_META = dr.GetDecimal(dr.GetOrdinal("NU_META"));
                            oCampos.NU_ANIO = dr.GetInt32(dr.GetOrdinal("NU_ANIO"));
                            oCampos.NV_PERIODO = dr.GetString(dr.GetOrdinal("NV_PERIODO"));
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
