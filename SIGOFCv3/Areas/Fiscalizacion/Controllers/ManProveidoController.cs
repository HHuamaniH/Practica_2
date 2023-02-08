using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Reportes.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Proveido;
using CLogica = CapaLogica.DOC.Log_PROVEIDOARCH;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManProveidoController : Controller
    {
        private CLogica logProv = new CLogica();
        public static CEntVM vmpROV = new CEntVM();
        public static string tipo = "";
        public ActionResult IndexFisca()
        {
            // return View();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.Formulario = "PROVEIDO_ARCHIVO";
            ViewBag.TituloFormulario = "Memorándum/Proveídos";
            ViewBag.Criterio = "TODOS";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("MEMORANDUM", "");// PROVEIDO_ARCHIVO
            tipo = "";

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Memorándum/Proveídos");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }

        public ActionResult IndexSup()
        {

            // return View();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.Formulario = "PROVEIDO_ARCHIVO_SUP";
            ViewBag.TituloFormulario = "Archivo de Informe";
            ViewBag.Criterio = "TODOS_SUPERVISION";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("PROVEIDO_ARCHIVO_SUP", "");
            tipo = "0000006";

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Archivo de Informe");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        /// <summary>
        /// metodo para exportar los registros del usuario logeado
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();
            result = ReporteManGrilla.GenerarReporteManGrilla("PROVEIDO_ARCHIVO_SUP", "");
            //result = logProv.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA, tipo);
            return Json(result);
        }
        /// <summary>
        /// metodo para la edicion y creacion de proveidos
        /// </summary>
        /// <param name="asCodRD"></param>
        /// <param name="asCodTipoIL"></param>
        /// <returns></returns>
        public ActionResult CreateOrEdit(string asCodRD = "", string asCodTipoIL = "")
        {
            try
            {
                vmpROV = logProv.init(asCodRD, asCodTipoIL, tipo);
                ViewBag.Tittle = asCodRD == "" ? "Memorándum" : "Memorándum/Proveídos";
                ViewBag.SubTittle = asCodRD == "" ? "Tipo de Memorándum" : "Tipo Memorandum/Proveido";

                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Archivo de Informe");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmpROV.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vmpROV);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
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
    }
}
