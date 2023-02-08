using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_PlanTrabajo;
using CEntidad2 = CapaEntidad.DOC.Ent_PlanManejo_Especies;
using CEntidad3 = CapaEntidad.DOC.Ent_Especie;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_PlanTrabajo
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        public List<VM_PlanTrabajoDetalle> ListaPlanManejo(OracleConnection cn, CEntidad ent)
        {
            List<VM_PlanTrabajoDetalle> respuesta = new List<VM_PlanTrabajoDetalle>();
            VM_PlanTrabajoDetalle oCampos;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Detalle", ent))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new VM_PlanTrabajoDetalle();
                                oCampos.titular = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCampos.titulo_habilitante = dr.GetString(dr.GetOrdinal("TITULO_HABILITANTE"));
                                oCampos.modalidad = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCampos.plan_manejo = dr.GetString(dr.GetOrdinal("PLAN_MANEJO"));
                                oCampos.departamento = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCampos.provincia = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                oCampos.distrito = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                oCampos.tipo_supervision = dr.GetString(dr.GetOrdinal("TIPO_SUPERVISION"));
                                oCampos.criterios_focalizacion = dr.GetString(dr.GetOrdinal("CRITERIOS_FOCALIZACION"));
                                oCampos.oportunidad = dr.GetString(dr.GetOrdinal("OPORTUNIDAD"));
                                oCampos.maderable = dr.GetString(dr.GetOrdinal("MADERABLE"));
                                oCampos.cod_paspeq_detalle_mensual = dr.GetInt32(dr.GetOrdinal("COD_PASPEQ_DETALLE_MENSUAL"));
                                oCampos.cod_paspeq_detalle = dr.GetInt32(dr.GetOrdinal("COD_PASPEQ_DETALLE"));
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

        public List<VM_PlanManejoEspecies> ListaPlanManejoEspecies(OracleConnection cn, CEntidad2 ent)
        {
            List<VM_PlanManejoEspecies> respuesta = new List<VM_PlanManejoEspecies>();
            VM_PlanManejoEspecies oCampos;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.GENERAR_LISTA_ESPECIES_SUPERVISAR", ent))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new VM_PlanManejoEspecies();
                                oCampos.cod_especies = dr.GetString(0);
                                oCampos.especie = dr.GetString(1);
                                oCampos.aprovechables_minimo = Convert.ToInt32(dr.GetDouble(10));
                                oCampos.semilleros_minimo = Convert.ToInt32(dr.GetDouble(9));
                                oCampos.aprovechables_supervisar = dr.GetInt32(12);
                                oCampos.semilleros_supervisar = dr.GetInt32(11);
                                oCampos.cantidad_aprobada = dr.GetInt32(13);
                                oCampos.volumen_aprobado = Convert.ToDouble(dr.GetDecimal(14));
                                oCampos.cod_paspeq_plan_trabajo_especies = Convert.ToInt32(dr.GetValue(15));
                                oCampos.cod_paspeq_detalle_mensual = dr.GetInt32(16);
                                oCampos.total = oCampos.aprovechables_supervisar + oCampos.semilleros_supervisar;
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

        public bool GuardarEspecie(CEntidad3 ent)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                int resultado = 0;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Especie_Edicion", ent))
                    {
                        cmd.ExecuteNonQuery();
                        resultado = Int32.Parse(cmd.Parameters["RESULTADO"].Value.ToString());
                    }
                    if (resultado == 1)
                    {
                        tr.Commit();
                        return true;
                    }
                    else
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    return false;
                    throw ex;
                }
            }
        }

        public bool EliminarPlanTrabajo(CEntidad ent)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Eliminar", ent);
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    return false;
                    throw ex;
                }
            }
        }

        public bool AprobarPlanTrabajo(CEntidad ent)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Aprobar", ent);
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    return false;
                    throw ex;
                }
            }
        }

        public bool CreatePlanTrabajo(CEntidad ent)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Crear", ent);
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    return false;
                    throw ex;
                }
            }
        }


        public bool actualizarCalidadPlan(VM_ControlCalidad_2 vm, string cod_ucuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanManejo_ValidarCalidad", vm.hdIdControl, cod_ucuenta, vm.ddlIndicadorId, 0))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                string bandera = "", obs = "";
                                bandera = dr["obsBandera"].ToString();
                                obs = dr["obsValidacion"].ToString();
                                if (bandera != "EXITO")
                                    throw new Exception(obs);
                            }
                        }
                    }
                    tr = cn.BeginTransaction();
                    //validando

                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanManejo_GuardarCalidad",
                           vm.hdIdControl, null, vm.ddlIndicadorId, vm.txtControlCalidadObservaciones,
                           vm.chkObsSubsanada, cod_ucuenta, 1);
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }
        public List<Dictionary<string, string>> planManejoListar(int COD_PASPEQ_PLAN_TRABAJO, string periodo = null, string sedeId = null)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanManejo_Listar", COD_PASPEQ_PLAN_TRABAJO, periodo, sedeId))
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lstResult;
        }
        public List<Dictionary<object, object>> planTrabajoItemsListar(int COD_PASPEQ_PLAN_TRABAJO)
        {
            List<Dictionary<object, object>> lstResult = new List<Dictionary<object, object>>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Detalle", COD_PASPEQ_PLAN_TRABAJO))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<object, object> sFila;
                                string sColumn = "";
                                while (dr.Read())
                                {
                                    sFila = new Dictionary<object, object>();
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lstResult;
        }
        public List<VM_PlanTrabajoDetalle> planTrabajoItemsListarExcel(int COD_PASPEQ_PLAN_TRABAJO)
        {
            List<VM_PlanTrabajoDetalle> lstResult = new List<VM_PlanTrabajoDetalle>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Detalle", COD_PASPEQ_PLAN_TRABAJO))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                VM_PlanTrabajoDetalle item;
                                while (dr.Read())
                                {
                                    item = new VM_PlanTrabajoDetalle();
                                    item.titular = dr["TITULAR"].ToString();
                                    item.titulo_habilitante = dr["TITULO_HABILITANTE"].ToString();
                                    item.modalidad = dr["MODALIDAD"].ToString();
                                    item.plan_manejo = dr["PLAN_MANEJO"].ToString();
                                    item.departamento = dr["DEPARTAMENTO"].ToString();
                                    item.provincia = dr["PROVINCIA"].ToString();
                                    item.distrito = dr["DISTRITO"].ToString();
                                    item.tipo_supervision = dr["TIPO_SUPERVISION"].ToString();
                                    item.oportunidad = dr["OPORTUNIDAD"].ToString();
                                    item.criterios_focalizacion = dr["CRITERIOS_FOCALIZACION"].ToString();
                                    lstResult.Add(item);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lstResult;
        }

        public List<VM_PlanTrabajoMuestra> PlanTrabajoMuestraListarExcel(int COD_PASPEQ_PLAN_TRABAJO)
        {
            List<VM_PlanTrabajoMuestra> lstResult = new List<VM_PlanTrabajoMuestra>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Muestra", COD_PASPEQ_PLAN_TRABAJO))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                VM_PlanTrabajoMuestra item;
                                while (dr.Read())
                                {
                                    item = new VM_PlanTrabajoMuestra();
                                    item.titular = dr["TITULAR"].ToString();
                                    item.titulo_habilitante = dr["TITULO_HABILITANTE"].ToString();
                                    item.plan_manejo = dr["PLAN_MANEJO"].ToString();
                                    item.especie = dr["ESPECIE"].ToString();
                                    item.aprovechables = Convert.ToInt32(dr["SUPERVISION_APROVECHABLES"]);
                                    item.semilleros = Convert.ToInt32(dr["SUPERVISION_SEMILLEROS"]);
                                    item.total = Convert.ToInt32(dr["TOTAL"]);
                                    lstResult.Add(item);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lstResult;
        }

        public bool CreatePlanTrabajoItems(List<VM_Paspeq_Detalle_Mensual> vms, string cod_ucuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    DateTime dateTime = DateTime.Now;
                    foreach (var item in vms)
                    {
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Items_Crear",
                            item.cod_paspeq_plan_t, item.cod_paspeq_detalle, dateTime,
                            item.tipo_supervision, item.oportunidad_supervision, cod_ucuenta);
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }
        public bool deletePlanTrabajoItem(int COD_PASPEQ_DETALLE_MENSUAL, string cod_ucuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Items_Eliminar", COD_PASPEQ_DETALLE_MENSUAL, cod_ucuenta);
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Regitr datos en la tabla DOC.PASPEQ_DETALLE y DOC.PASPEQ_DETALLE_MENSUAL
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public bool CreatePaspeqDetalle_Mensual(Ent_Paspeq_Detalle_V3 ent, int tipo_supervision,
                    int oportunidad_supervision, string cod_ucuenta)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    int COD_PASPEQ_DETALLE = 0;
                    DateTime dateTime = DateTime.Now;
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_Detalle_Crear", ent))
                    {
                        cmd.ExecuteNonQuery();
                        COD_PASPEQ_DETALLE = Convert.ToInt32(cmd.Parameters["OUTPUTPARAM01"].Value);
                    }
                    //creando registro en DOC.PASPEQ_DETALLE_MENSUAL
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPASPEQ_PlanTrabajo_Items_Crear",
                           ent.COD_PASPEQ_PLAN_TRABAJO, COD_PASPEQ_DETALLE, dateTime,
                           tipo_supervision, oportunidad_supervision, cod_ucuenta);
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }

    }
}
