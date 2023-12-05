using CapaEntidad.Documento;
using CapaEntidad.General;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;


namespace CapaDatos.Documento
{
    public class Dat_Periodo
    {
        private DBOracle dBOracle = new DBOracle();
        public List<Dictionary<string, string>> GetAllPeriodo(Ent_BUSQUEDA_V3 ent)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.USP_PERIODO_LISTAR", ent))
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
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_Periodo GetIdPeriodo(Ent_BUSQUEDA_V3 ent)
        {
            VM_Periodo vm = new VM_Periodo();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.USP_PERIODO_LISTAR", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.id = dr["DIA_FERIADO"].ToString();
                                    vm.motivo = dr["MOTIVO"].ToString();
                                    vm.act = Convert.ToBoolean(dr["ESTADO"]);
                                    vm.estado = (Convert.ToBoolean(dr["ESTADO"]) ? 1 : 0);
                                }
                            }
                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SavePeriodo(Ent_Periodo entity)
        {
            string OUTPUTPARAM02 = "";
            string OUTPUTPARAM01 = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.USP_PERIODO_GRABAR", entity))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (string)cmd.Parameters["OUTPUTPARAM02"].Value;
                        OUTPUTPARAM01 = (string)cmd.Parameters["OUTPUTPARAM01"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception(OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
    }
}
