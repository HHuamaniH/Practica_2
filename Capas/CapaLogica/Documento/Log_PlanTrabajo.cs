using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using CDatos = CapaDatos.DOC.Dat_PlanTrabajo;

namespace CapaLogica.DOC
{
    public class Log_PlanTrabajo
    {
        private CDatos oCDatos = new CDatos();

        public bool EliminarPlanTrabajo(VM_PlanTrabajo vm, string cod_ucuenta)
        {
            Ent_PlanTrabajo ent = new Ent_PlanTrabajo();
            ent.COD_PASPEQ_PLAN_TRABAJO = vm.cod_paspeq_plan_trabajo;
            ent.COD_UCUENTA = cod_ucuenta;

            try
            {
                return oCDatos.EliminarPlanTrabajo(ent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult GuardarEspecie(VM_PlanManejoEspecies vm, string cod_ucuenta)
        {
            ListResult result = new ListResult();
            Ent_Especie ent = new Ent_Especie();
            ent.COD_PASPEQ_PLAN_TRABAJO_ESPECIES = vm.cod_paspeq_plan_trabajo_especies;
            ent.APROVECHABLES_SUPERVISAR = vm.aprovechables_supervisar;
            ent.SEMILLEROS_SUPERVISAR = vm.semilleros_supervisar;
            ent.COD_ESPECIES = vm.cod_especies;
            ent.COD_PASPEQ_DETALLE_MENSUAL = vm.cod_paspeq_detalle_mensual;
            ent.COD_UCUENTA = cod_ucuenta;
            ent.RESULTADO = 0;
            string msj = "";
            bool respuesta = false;
            try
            {
                respuesta = oCDatos.GuardarEspecie(ent);

                if (respuesta)
                {
                    result.success = true;
                    msj = "Los datos se guardaron correctamente";
                    result.msj = msj;
                }
                else
                {
                    result.success = false;
                    msj = "Los datos no se pudieron guardar";
                    result.msj = msj;
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public bool AprobarPlanTrabajo(VM_PlanTrabajo vm, string cod_ucuenta)
        {
            Ent_PlanTrabajo ent = new Ent_PlanTrabajo();
            ent.COD_PASPEQ_PLAN_TRABAJO = vm.cod_paspeq_plan_trabajo;
            ent.COD_UCUENTA = cod_ucuenta;
            try
            {
                return oCDatos.AprobarPlanTrabajo(ent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult CreatePlanTrabajo(VM_PlanTrabajo vm, string cod_ucuenta)
        {
            ListResult result = new ListResult();
            try
            {

                Ent_PlanTrabajo ent = new Ent_PlanTrabajo();
                ent.PERIODO = vm.periodo;
                ent.MES_FOCALIZACION = vm.mes_focalizacion;
                ent.COD_OD = vm.cod_od;
                ent.COD_UCUENTA = cod_ucuenta;
                string msj = "";
                if (oCDatos.CreatePlanTrabajo(ent))
                {
                    result.success = true;
                    msj = "El plan de trabajo se generó correctamente";
                    result.msj = msj;
                }
                else
                {
                    result.success = false;
                    msj = "El plan de trabajo no se pudo generar";
                    result.msj = msj;
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public ListResult actualizarCalidadPlan(VM_ControlCalidad_2 vm, string cod_ucuenta)
        {
            ListResult result = new ListResult();

            try
            {
                if (oCDatos.actualizarCalidadPlan(vm, cod_ucuenta))
                {
                    result.success = true;
                    result.msj = "Se actualizo correctamente la información";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;// "Sucedio un error al actualizar la información";
            }
            return result;
        }

        public VM_PlanTrabajo PlanTrabajoSeleccion(int cod_paspeq_plan_trabajo = 0, string mes_focalizacion = "", string periodo = "")
        {
            VM_PlanTrabajo vm;
            vm = new VM_PlanTrabajo();
            vm.cod_paspeq_plan_trabajo = cod_paspeq_plan_trabajo;
            vm.periodo = periodo;
            vm.mes = mes_nombre(mes_focalizacion);
            return vm;
        }

        public VM_PlanManejoEspecies EspecieSeleccion(int cod_paspeq_plan_trabajo_especies = 0, int cod_paspeq_detalle_mensual = 0, string especie = "", string cod_especie = "", int aprovechables_supervisar = 0, int semilleros_supervisar = 0)
        {
            VM_PlanManejoEspecies vm;
            vm = new VM_PlanManejoEspecies();
            vm.cod_paspeq_plan_trabajo_especies = cod_paspeq_plan_trabajo_especies;
            vm.cod_paspeq_detalle_mensual = cod_paspeq_detalle_mensual;
            vm.especie = especie;
            vm.cod_especies = cod_especie;
            vm.aprovechables_supervisar = aprovechables_supervisar;
            vm.semilleros_supervisar = semilleros_supervisar;
            return vm;
        }

        private string mes_nombre(string mes_focalizacion = "")
        {
            string mes = "";
            switch (mes_focalizacion)
            {
                case "01": mes = "Enero"; break;
                case "02": mes = "Febrero"; break;
                case "03": mes = "Marzo"; break;
                case "04": mes = "Abril"; break;
                case "05": mes = "Mayo"; break;
                case "06": mes = "Junio"; break;
                case "07": mes = "Julio"; break;
                case "08": mes = "Agosto"; break;
                case "09": mes = "Setiembre"; break;
                case "10": mes = "Octubre"; break;
                case "11": mes = "Noviembre"; break;
                case "12": mes = "Diciembre"; break;

            }

            return mes;
        }

        public List<VM_PlanManejoEspecies> GetAllEspecies(VM_PlanManejoEspecies vm)
        {
            Ent_PlanManejo_Especies ent = new Ent_PlanManejo_Especies();
            ent.COD_PASPEQ_DETALLE_MENSUAL = vm.cod_paspeq_detalle_mensual;

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListaPlanManejoEspecies(cn, ent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VM_PlanTrabajoDetalle> GetAllPlanManejo(VM_PlanTrabajo vm)
        {
            Ent_PlanTrabajo ent = new Ent_PlanTrabajo();
            ent.COD_PASPEQ_PLAN_TRABAJO = vm.cod_paspeq_plan_trabajo;

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListaPlanManejo(cn, ent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult CreatePlanTrabajoItems(List<VM_Paspeq_Detalle_Mensual> vms, string cod_ucuenta)
        {
            ListResult result = new ListResult();
            try
            {
                if (vms == null) throw new Exception("No existe items a registrar");
                if (oCDatos.CreatePlanTrabajoItems(vms, cod_ucuenta))
                {
                    result.success = true;
                    result.msj = "Se registro correctamente la información";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;// "Sucedio un error al actualizar la información";
            }
            return result;
        }
        public ListResult CreatePlanTrabajoItemsExtra(VM_PaspeqDetalle vm, string cod_ucuenta)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Paspeq_Detalle_V3 ent = new Ent_Paspeq_Detalle_V3();
                ent.COD_PASPEQ_PLAN_TRABAJO = vm.cod_paspeq_plan_t;
                ent.COD_THABILITANTE = vm.cod_thabilitante;
                ent.TABLA_PLAN_MANEJO = vm.tabla_plan_manejo;
                if (ent.TABLA_PLAN_MANEJO == "POA")
                {
                    ent.COD_PMANEJO = null;
                    ent.NUM_POA = vm.num_poa;
                }
                else
                {
                    ent.NUM_POA = null;
                    ent.COD_PMANEJO = vm.cod_pmanejo;
                }
                ent.FASE_ADICION = "FOCALIZACION";
                ent.OUTPUTPARAM01 = 0;
                oCDatos.CreatePaspeqDetalle_Mensual(ent, vm.tipo_supervision, vm.oportunidad_supervision, cod_ucuenta);
                result.success = true;
                result.msj = "Se registro correctamente la información";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;// "Sucedio un error al actualizar la información";
            }
            return result;
        }
        public ListResult deletePlanTrabajoItem(int cod_paspeq_detalle_mensual, string cod_ucuenta)
        {
            ListResult result = new ListResult();
            try
            {
                if (oCDatos.deletePlanTrabajoItem(cod_paspeq_detalle_mensual, cod_ucuenta))
                {
                    result.success = true;
                    result.msj = "Se elimino correctamente el  Item seleccionado";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public List<Dictionary<string, string>> planManejoListar(int COD_PASPEQ_PLAN_TRABAJO, string periodo = null, string sedeId = null)
        {
            return oCDatos.planManejoListar(COD_PASPEQ_PLAN_TRABAJO, periodo, sedeId);
        }
        public List<Dictionary<object, object>> planTrabajoItemsListar(int COD_PASPEQ_PLAN_TRABAJO)
        {
            return oCDatos.planTrabajoItemsListar(COD_PASPEQ_PLAN_TRABAJO);
        }
        public List<VM_PlanTrabajoDetalle> planTrabajoItemsListarExcel(int COD_PASPEQ_PLAN_TRABAJO)
        {
            return oCDatos.planTrabajoItemsListarExcel(COD_PASPEQ_PLAN_TRABAJO);
        }
        public List<VM_PlanTrabajoMuestra> PlanTrabajoMuestraListarExcel(int COD_PASPEQ_PLAN_TRABAJO)
        {
            return oCDatos.PlanTrabajoMuestraListarExcel(COD_PASPEQ_PLAN_TRABAJO);
        }

    }
}
