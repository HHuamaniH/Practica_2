using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Planificacion.Controllers
{
    public class ManPlanController : Controller
    {
        private Log_PLANIFICACION _logPlan;

        public ManPlanController()
        {
            _logPlan = new Log_PLANIFICACION();
        }

        // GET: Planificacion/ManPlan
        public ActionResult Index(string _alertaIncial)
        {
            ViewBag.Formulario = "PLAN_";
            ViewBag.TituloFormulario = "PASPEQ";
            ViewBag.AlertaInicial = _alertaIncial;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE PLANIFICACIÓN", "PASPEQ");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }

        public ActionResult AddEdit(string asCodPlan)
        {
            try
            {
                VM_Plan vm = _logPlan.InitPlan(asCodPlan);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE PLANIFICACIÓN", "PASPEQ");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vm.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult AddEdit(VM_Plan vm)
        {
            ListResult result = _logPlan.GrabarPlan(vm, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult GrabarPlanColaborador(Ent_PLAN_COLABORADOR dto)
        {
            ListResult result = _logPlan.GrabarPlanColaborador(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        public ActionResult ListarPlanColaborador(string asCodPlan)
        {
            try
            {
                var result = _logPlan.ListarPlanColaborador(asCodPlan);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EliminarPlanColaborador(string asCodPlan, string asCodColaborador)
        {
            ListResult result = _logPlan.EliminarPlanColaborador(asCodPlan, asCodColaborador);

            return Json(result);
        }
    }
}