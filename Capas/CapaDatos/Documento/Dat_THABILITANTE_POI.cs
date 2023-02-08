using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntVM = CapaEntidad.ViewModel.VM_THabilitantePOI;
using CEntidad = CapaEntidad.DOC.Ent_THABILITANTE_POI;

namespace CapaDatos.DOC
{
    public class Dat_THABILITANTE_POI
    {
        private DBOracle dBOracle = new DBOracle();
    
        public List<Dictionary<string, string>> GetAllTHPOI(CEntidad ent)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPTHABILITANTE_POI_LISTAR", ent))
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

        public CEntVM GetTHPOI(CEntidad ent)
        {
            CEntVM vm = new CEntVM();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPTHABILITANTE_POI_OBTENER", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.hdfCodTHPOI = dr["NV_CODIGO"].ToString();
                                    vm.ddlAnioId = dr["NU_ANIO"].ToString();
                                    vm.ddlTrimestreId = dr["NU_TRIMESTRE"].ToString();
                                    vm.txtValorAuditoria = dr["NU_VALOR_AUDITORIA"].ToString();
                                    vm.txtValorSupervision = dr["NU_VALOR_SUPERVISION"].ToString();
                                    vm.txtValorMedida = dr["NU_VALOR_MEDIDA"].ToString();
                                    vm.hdfEstado = Int32.Parse(dr["ESTADO"].ToString());
                                    vm.RegEstado = 2;
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

        public String SaveTHPOI(CEntidad ent)
        {
            String OUTPUTPARAM = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPTHABILITANTE_POI_GRABAR", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                        if (OUTPUTPARAM.Trim() == "")
                        {
                            throw new Exception("Error al procesar en DB.");
                        }
                        else if (OUTPUTPARAM.Split('|')[0] == "0")
                        {
                            throw new Exception(OUTPUTPARAM.Split('|')[1]);
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
            return OUTPUTPARAM;
        }
    }
}
