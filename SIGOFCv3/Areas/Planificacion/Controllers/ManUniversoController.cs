using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using SIGOFCv3.Areas.Planificacion.Models;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Planificacion.Controllers
{
    public class ManUniversoController : Controller
    {
        private Log_PLANIFICACION _logPlan;

        public ManUniversoController()
        {
            _logPlan = new Log_PLANIFICACION();
        }

        // GET: Planificacion/ManUniverso/AddEdit
        public ActionResult AddEdit(string asCodPlan)
        {
            try
            {
                VM_PlanUniverso vm = _logPlan.InitPlanUniverso(asCodPlan);

                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        public ActionResult ListarPlanUniverso(string asCodPlan)
        {
            try
            {
                var result = _logPlan.ListarPlanUniverso(asCodPlan);

                var jsonResult = Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GenerarPlanUniverso(string asCodPlan, string asFechaCorte, string asHoraCorte)
        {
            ListResult result = _logPlan.GenerarPlanUniverso(asCodPlan, asFechaCorte, asHoraCorte);

            return Json(result);
        }

        [HttpPost]
        public JsonResult LimpiarPlanUniverso(string asCodPlan)
        {
            ListResult result = _logPlan.LimpiarPlanUniverso(asCodPlan);

            return Json(result);
        }

        [HttpPost]
        public JsonResult ActualizarPlanUniverso(string asCodPlan)
        {
            ListResult result = _logPlan.ActualizarPlanUniverso(asCodPlan);

            return Json(result);
        }

        public FileResult ExportarPlanUniverso(string asCodPlan)
        {
            /*En caso se experimente problemas al exportar, revisar los caracteres especiales como ', "*/
            ListResult result = ExportarDatos.PlanUniverso(asCodPlan);

            return File(result.byteFile, "application/xlsx", "Universo_PASPEQ.xlsx");
        }
    }
}