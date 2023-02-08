using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformeSuspension;
using CLogica = CapaLogica.DOC.Log_ISUSPENSION;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInfSuspensionController : Controller
    {
        // GET: Supervision/ManInfSuspension
        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "INFORME_SUSPENSION";
            ViewBag.TituloFormulario = "Informe de Suspensión";
            ViewBag.AlertaInicial = _alertaIncial;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe de Suspensión");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        #region "Mantenimiento Informe"
        public ActionResult AddEdit(string asCodMTipo, string asCodInforme = "", string asCodCNotificacion = "")
        {
            try
            {
                CLogica exeInf = new CLogica();

                CEntVM vmInf = exeInf.InitDatosInforme(asCodInforme, asCodCNotificacion, (ModelSession.GetSession())[0].COD_UCUENTA);
                //vmInf.hdfCodMTipo = asCodMTipo;
                //return View(vmInf);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe de Suspensión");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                vmInf.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vmInf);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult SaveOrUpdate(CEntVM dto)
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
            CLogica exeBus = new CLogica();
            result = exeBus.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        #endregion
    }
}