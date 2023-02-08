using CapaEntidad.ViewModel.DOC;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManVentanillaSolicitudController : Controller
    {
        // GET: THabilitante/ManVentanillaSolicitud
        Log_SOLINF_THABILITANTE_SITD log = new Log_SOLINF_THABILITANTE_SITD();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.vbOpciones = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" } , new SelectListItem() { Text = "Pendiente", Value = "Pendiente" } , new SelectListItem() { Text = "Transferido", Value = "Transferido" },
                                                               new SelectListItem() { Text = "Anulado", Value = "Anulado" }};
            ViewBag.vbOpciones1 = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" }, new SelectListItem() { Text = "Nro. Documento Referencia", Value = "NUM_DREFERENCIA" }, new SelectListItem() { Text = "Entidad Remitente", Value = "ENTIDAD" } };
            return View();
        }
        [HttpGet]
        public ActionResult Transferir(int tramiteId)
        {
            try
            {
                return View(log.IniciarTransferencia(tramiteId));
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }

        }
        [HttpGet]
        public ActionResult _Transferir()
        {

            return PartialView();
        }
        [HttpGet]
        public JsonResult ObtenerTH_Solicitados(int tramiteId)
        {
            try
            {
                var lst = log.RegMostrarListaItems_Detalle(tramiteId);
                var jsonResult = Json(new { data = lst, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult TransferirCabecera(string tramideId, string obsTransferencia)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(log.RegGrabar_Transferenia_Cabecera(tramideId, obsTransferencia, codCuenta));
        }
        [HttpPost]
        public JsonResult TransferirDetalle(VM_SOLINF_THABILITANTE_DETALLE vm)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(log.RegGrabar_Transferencia_Detalle(vm, codCuenta));
        }
        [HttpPost]
        public JsonResult EliminarSolicitadosDetalle(List<VM_SOLINF_THABILITANTE_DETALLE> lstVM)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(log.Eliminar_Transferencia_Detalle(lstVM, codCuenta));
        }
        [HttpPost]
        public JsonResult AnularSolicitud(VM_SOLINF_THABILITANTE vm)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(log.AnularSolicitud(vm, codCuenta));
        }
    }
}
