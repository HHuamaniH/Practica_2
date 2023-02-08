using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Areas.Capacitacion.Models.ManProgramaCapacitacion;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_ProgramaCapacitacion;
using CLogica = CapaLogica.DOC.Log_PROGRAMA_CAPACITACION;

namespace SIGOFCv3.Areas.Capacitacion.Controllers
{
    public class ManProgramaCapacitacionController : Controller
    {
        // GET: Capacitacion/ManProgramaCapacitacion
        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "PROGRAMA_CAPACITACION";
            ViewBag.TituloFormulario = "Programación de Capacitaciones";
            ViewBag.AlertaInicial = _alertaIncial;

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO CAPACITACION", "Programación Capacitaciones");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }
        [HttpGet]
        public ActionResult AddEdit(string asCodPCapacitacion)
        {
            try
            {
                CEntVM VM_PC;
                CLogica exePCap = new CLogica();
                VM_PC = exePCap.IniDatosPCapacitacion(asCodPCapacitacion, (ModelSession.GetSession())[0].COD_UCUENTA);

                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO CAPACITACION", "Programación Capacitaciones");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;


                return View(VM_PC);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        [HttpPost]
        public JsonResult AddEdit(CEntVM dto)
        {
            CLogica exePCap = new CLogica();
            ListResult result = exePCap.GuardarDatosPCapacitacion(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        [HttpGet]
        public JsonResult GetListCapacitacionProgramadaOd(string asCodOd, string asFormularioConsulta)
        {
            try
            {
                string busCriterio = asFormularioConsulta == "CAPACITACION" ? "CAPACITACIONES_PROGRAMADAS_OD" : "CAPACITACIONES_PROGRAMADAS_OD_OTROS";
                CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                List<VM_Cbo> lstResult = exeBus.RegMostComboIndividual(busCriterio, asCodOd);

                var jsonResult = Json(new { data = lstResult, success = true, e = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetCapacitacionProgramada(string asCodPCapacitacion)
        {
            try
            {
                CEntVM VM_PC = new CEntVM();
                CLogica exePCap = new CLogica();

                if (asCodPCapacitacion != "0000000")//Código por defecto de los combos (opción "Seleccionar")
                {
                    VM_PC = exePCap.IniDatosPCapacitacion(asCodPCapacitacion, (ModelSession.GetSession())[0].COD_UCUENTA);
                }

                var jsonResult = Json(new { data = VM_PC, success = true, e = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
    }
}