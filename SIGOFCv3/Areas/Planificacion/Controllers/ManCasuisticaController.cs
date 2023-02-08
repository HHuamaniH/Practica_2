using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using SIGOFCv3.Areas.Planificacion.Models;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Planificacion.Controllers
{
    public class ManCasuisticaController : Controller
    {
        private Log_PLANIFICACION _logPlan;
        private Log_BUSQUEDA _logBus;

        public ManCasuisticaController()
        {
            _logPlan = new Log_PLANIFICACION();
            _logBus = new Log_BUSQUEDA();
        }

        // GET: Planificacion/ManCasuistica
        public ActionResult ListarPlanCasuistica(string asCodPlan)
        {
            try
            {
                var result = _logPlan.ListarPlanCasuistica(asCodPlan);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE PLANIFICACIÓN", "Revisión OD");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _PlanCasuistica(string asCodPCasuistica, string asCodPlan)
        {
            VM_PlanCasuistica vm = _logPlan.InitPlanCasuistica(asCodPCasuistica, asCodPlan);

            return PartialView(vm);
        }

        [HttpPost]
        public JsonResult GrabarPlanCasuistica(VM_PlanCasuistica vm)
        {
            ListResult result = _logPlan.GrabarPlanCasuistica(vm, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult EliminarPlanCasuistica(string asCodPCasuistica, string asCodPlan)
        {
            ListResult result = _logPlan.EliminarPlanCasuistica(asCodPlan, asCodPCasuistica);

            return Json(result);
        }

        public ActionResult ListarPlanCasuisticaCriterio(string asCodPCasuistica, string asCodTCriterio)
        {
            try
            {
                var result = _logPlan.ListarPlanCasuisticaCriterio(asCodPCasuistica, asCodTCriterio);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GrabarPlanCasuisticaCriterio(string asCodPCasuistica, string asCodPCriterio, bool abAsignar)
        {
            ListResult result = _logPlan.GrabarPlanCasuisticaCriterio(asCodPCasuistica, asCodPCriterio, abAsignar, (ModelSession.GetSession())[0].COD_UCUENTA);
            if (result.success)
            {
                if (!_logPlan.CalcularPlanCasuisticaUniverso(asCodPCasuistica).success)
                {
                    result.AddResultado("Ocurrió un error al aplicar los criterios", false);
                }
            }

            return Json(result);
        }

        public ActionResult ListarPlanCasuisticaUniverso(string asCodPlan, string asCodPCasuistica)
        {
            try
            {
                var result = _logPlan.ListarPlanCasuisticaUniverso(asCodPlan, asCodPCasuistica);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ImportarPlanCasuisticaUniverso(string asCodPlan, string asCodPCasuistica)
        {
            ListResult result = new ListResult();

            try
            {
                if (Request != null)
                {
                    var lstUniverso = ImportarDatos.PlanCasuisticaUniverso(Request, asCodPlan, asCodPCasuistica);
                    if (lstUniverso.Count > 0)
                    {
                        result = _logPlan.EliminarPlanCasuisticaUniverso(asCodPCasuistica);
                        if (result.success)
                        {
                            result = _logPlan.GrabarPlanCasuisticaUniverso(lstUniverso);
                            if (result.success)
                            {
                                if (!_logPlan.CalcularPlanCasuisticaUniverso(asCodPCasuistica).success)
                                {
                                    throw new Exception("Ocurrió un error al aplicar los criterios");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("No se pudo eliminar el universo anterior para registrar el nuevo");
                        }
                    }
                    else
                    {
                        throw new Exception("No se encontraron registros en la plantilla cargada");
                    }
                }
                else
                {
                    throw new Exception("No se encontró la plantilla del universo a registrar");
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = result.success, msj = result.msj, data = new List<string>() { "" } });
        }

        public FileResult ExportarPlanCasuisticaUniverso(string asCodPlan, string asCodPCasuistica)
        {
            /*En caso se experimente problemas al exportar, revisar los caracteres especiales como ', "*/
            ListResult result = ExportarDatos.PlanCasuisticaUniverso(asCodPlan, asCodPCasuistica);

            return File(result.byteFile, "application/xlsx", "Universo_PASPEQ_Casuística.xlsx");
        }

        public ActionResult ListarConsolidadoPlanCasuisticaUniverso(string asCodPlan, string asCodOd = "0000000", string asCodEstadoPriorizar = "0000000")
        {
            try
            {
                var result = _logPlan.ConsolidadoPlanCasuisticaUniverso(asCodPlan, asCodOd, asCodEstadoPriorizar);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public FileResult ExportarConsolidadoPlanCasuisticaUniverso(string asCodPlan)
        {
            /*En caso se experimente problemas al exportar, revisar los caracteres especiales como ', "*/
            ListResult result = ExportarDatos.ConsolidadoPlanCasuisticaUniverso(asCodPlan);

            return File(result.byteFile, "application/xlsx", "Universo_PASPEQ_Consolidado.xlsx");
        }

        [HttpPost]
        public JsonResult ImportarPriorizarConsolidadoPlanCasuisticaUniverso(string asCodPlan)
        {
            try
            {
                if (Request != null)
                {
                    var lstPriorizar = ImportarDatos.PriorizarPlanCasuisticaUniverso(Request, asCodPlan);
                    if (lstPriorizar.Count == 0)
                    {
                        throw new Exception("No se encontraron registros en la plantilla cargada");
                    }

                    var result = _logPlan.PriorizarConsolidadoPlanCasuisticaUniverso(lstPriorizar);

                    return Json(new { success = result.success, msj = result.msj, data = new List<string>() { "" } });
                }
                else
                {
                    throw new Exception("No se encontró la plantilla del consolidado priorizado a registrar");
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult PriorizarConsolidadoPlanCasuisticaUniverso(string asCodPlan, int aiCodSecuencial, string asCodPCasuistica, int abPriorizar)
        {
            ListResult result = _logPlan.PriorizarConsolidadoPlanCasuisticaUniverso(new List<Ent_PLAN_CASUISTICA_UNIVERSO>()
            {
                new Ent_PLAN_CASUISTICA_UNIVERSO()
                {
                    COD_PLAN=asCodPlan, COD_SECUENCIAL=aiCodSecuencial, COD_PCASUISTICA=asCodPCasuistica, PRIORIZAR=abPriorizar
                }
            });

            return Json(result);
        }

        public ActionResult RevisionConsolidadoOd()
        {
            try
            {
                ViewBag.ddlPlanAnio = _logBus.RegMostComboIndividual("PLAN_ANIO", "");
                ViewBag.ddlOd = _logBus.RegMostComboIndividual("OD", "");
                ViewBag.ddlEstadoPriorizar = new List<VM_Cbo>()
                {
                    new VM_Cbo(){Value="0000000", Text="Seleccionar"},
                    new VM_Cbo(){Value="SI", Text="Priorizado"},
                    new VM_Cbo(){Value="NO", Text="No Priorizado"}
                };

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult ObservarConsolidadoPlanCasuisticaUniverso(VM_PlanCasuisticaUniverso vm)
        {
            ListResult result = _logPlan.ObservarConsolidadoPlanCasuisticaUniverso(vm, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult RevisarConsolidadoPlanCasuisticaUniverso(VM_PlanCasuisticaUniverso vm)
        {
            ListResult result = _logPlan.RevisarConsolidadoPlanCasuisticaUniverso(vm);

            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _PlanCasuisticaUniverso(string asCodPCasuistica, string asCodPlan, int aiCodSecuencial, string asTipo)
        {
            VM_PlanCasuisticaUniverso vm = _logPlan.InitPlanCasuisticaUniverso(asCodPCasuistica, asCodPlan, aiCodSecuencial);
            vm.hdfTipo = asTipo;

            return PartialView(vm);
        }
    }
}