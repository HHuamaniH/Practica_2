using CapaEntidad.ViewModel.DOC;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManVentanillaDenunciaController : Controller
    {
        // GET: THabilitante/ManVentanillaDenuncia
        Log_DENUNCIA_SITD log = new Log_DENUNCIA_SITD();
        public ActionResult Index()
        {
            ViewBag.vbOpciones = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" } , new SelectListItem() { Text = "Pendiente", Value = "Pendiente" } , new SelectListItem() { Text = "Revisado", Value = "Revisado" },
                                                               new SelectListItem() { Text = "Anulado", Value = "Anulado" }};
            ViewBag.vbOpciones1 = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" }, new SelectListItem() { Text = "Nro. Documento Referencia", Value = "NUM_DREFERENCIA" } };
            return View();
        }
        [HttpPost]
        public JsonResult AnularDenuncia(VM_SOLINF_THABILITANTE vm)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(log.AnularDenuncia(vm, codCuenta));
        }
        [HttpGet]
        public ActionResult RevisarDenuncia(int tramiteId)
        {
            try
            {
                return View(log.RegMostrarListaItems_V3(tramiteId));
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }

        }
    }
}