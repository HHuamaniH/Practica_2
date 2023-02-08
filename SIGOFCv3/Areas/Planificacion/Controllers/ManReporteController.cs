using CapaLogica.DOC;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Planificacion.Controllers
{
    public class ManReporteController : Controller
    {
        private Log_BUSQUEDA _logBus;
        private Log_PLANIFICACION _logPlan;

        public ManReporteController()
        {
            _logBus = new Log_BUSQUEDA();
            _logPlan = new Log_PLANIFICACION();
        }

        // GET: Planificacion/ManReporte
        public ActionResult ReporteTHEstadoResumen()
        {
            ViewBag.ddlPlanAnio = _logBus.RegMostComboIndividual("PLAN_ANIO", "");

            return View();
        }

        public ActionResult ListarTHEstadoResumen(string asCodPlan)
        {
            try
            {
                var result = _logPlan.ListarReportePlan(asCodPlan, "TH_ESTADO_RESUMEN");

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ReporteTHModPorDpto()
        {
            ViewBag.ddlPlanAnio = _logBus.RegMostComboIndividual("PLAN_ANIO", "");

            return View();
        }

        public ActionResult ListarTHModPorDpto(string asCodPlan)
        {
            try
            {
                var result = _logPlan.ListarReportePlan(asCodPlan, "TH_MODxDEP_RESUMEN");

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}