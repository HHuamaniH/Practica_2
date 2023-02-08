using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Planificacion.Controllers
{
    public class ManCriterioController : Controller
    {
        private Log_PLANIFICACION _logPlan;
        private Log_BUSQUEDA _logBus;

        public ManCriterioController()
        {
            _logPlan = new Log_PLANIFICACION();
            _logBus = new Log_BUSQUEDA();
        }

        // GET: Planificacion/ManCriterio
        public ActionResult ListarPlanCriterio(string asCodPlan)
        {
            try
            {
                var result = _logPlan.ListarPlanCriterio(asCodPlan);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _PlanCriterio(string asCodPCriterio, string asCodPlan)
        {
            VM_PlanCriterio vm = _logPlan.InitPlanCriterio(asCodPCriterio, asCodPlan);

            return PartialView(vm);
        }

        [HttpPost]
        public JsonResult GrabarPlanCriterio(VM_PlanCriterio vm)
        {
            ListResult result = _logPlan.GrabarPlanCriterio(vm, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult EliminarPlanCriterio(string asCodPCriterio, string asCodPlan)
        {
            ListResult result = _logPlan.EliminarPlanCriterio( asCodPlan, asCodPCriterio);

            return Json(result);
        }

        public ActionResult ListarPlanCriterioValor(string asCodPCriterio)
        {
            try
            {
                var result = _logPlan.ListarPlanCriterioValor(asCodPCriterio);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _PlanCriterioValor(string asCodPCriterio, int aiCodSecuencial, string asCodPColumna, string asCodTAplicacion)
        {
            VM_PlanCriterioValor vm = _logPlan.InitPlanCriterioValor(asCodPCriterio, aiCodSecuencial, asCodPColumna, asCodTAplicacion);

            return PartialView(vm);
        }

        [HttpPost]
        public JsonResult GrabarPlanCriterioValor(Ent_PLAN_CRITERIO_VALOR dto)
        {
            ListResult result = _logPlan.GrabarPlanCriterioValor(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult EliminarPlanCriterioValor(string asCodPCriterio, int aiCodSecuencial)
        {
            ListResult result = _logPlan.EliminarPlanCriterioValor(asCodPCriterio, aiCodSecuencial);

            return Json(result);
        }

        [HttpPost]
        public JsonResult ObtenerPlanColumnaTipoDato(string asCodPColumna)
        {
            ListResult result = _logPlan.ObtenerPlanColumnaTipoDato(asCodPColumna);

            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _ReplicarPlanCriterio(string asCodPlan)
        {
            ViewBag.hdfCodPlan = asCodPlan;
            ViewBag.ddlPlanAnio = _logBus.RegMostComboIndividual("PLAN_ANIO", "");

            return PartialView();
        }

        [HttpPost]
        public JsonResult ReplicarPlanCriterio(string asCodPlanBase, string asCodPlan)
        {
            ListResult result = _logPlan.ReplicarPlanCriterio(asCodPlanBase, asCodPlan, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

    }
}