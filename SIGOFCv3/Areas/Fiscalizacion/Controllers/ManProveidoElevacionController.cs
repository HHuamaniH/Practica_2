using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_ProveidoElevacion;
using CLogica = CapaLogica.DOC.Log_PROVEIDO;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManProveidoElevacionController : Controller
    {
        private CLogica logProv = new CLogica();
        public static CEntVM vmProv = new CEntVM();
        public static string tipo = "";

        // GET: Fiscalizacion/ManProveidoElevacion
        public ActionResult Index()
        {
            // return View();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.Formulario = "PROVEIDO_ELEVACION";
            ViewBag.TituloFormulario = "Proveido Nota Elevacion";
            ViewBag.Criterio = "TODOS";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("PROVEIDO_ELEVACION", "");
            
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Proveído/Nota de Elevación");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }

        public ActionResult CreateOrEdit(string asCodigo = "")
        {
            try
            {
                vmProv = logProv.init(asCodigo);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Proveído/Nota de Elevación");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmProv.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                return View(vmProv);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
                //return RedirectToAction("ErrorC", "Index");
            }

        }

        [HttpPost]
        public JsonResult AddEditRD(CEntVM dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica exeBus = new CLogica();
            ListResult result = exeBus.GuardarDatos(dto, codCuenta);
            return Json(result);
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();
            result = logProv.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

    }
}