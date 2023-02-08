using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_THabilitantePOI;
using CLogica = CapaLogica.DOC.Log_THABILITANTE_POI;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ManTHAuditarController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.TituloFormulario = "Lista de Títulos Habilitantes programados para auditar";
            ViewBag.ddlOptBuscar = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "Todos", Text = "Todos" },
                new SelectListItem() { Value = "Anio", Text = "Año" },
                //new SelectListItem() { Value = "Codigo", Text = "Código" }
            };

            return View();
        }

        [HttpGet]
        public JsonResult GetListTHabilitantePOI(string opc, string valor)
        {
            try
            {
                CLogica logExe = new CLogica();
                var lstTHPOI = logExe.GetListTHabilitantePOI(opc, valor, "POI");
                var jsonResult = Json(new { data = lstTHPOI, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddEdit(string cod = "")
        {
            CLogica logExe = new CLogica();
            var itemEdit = logExe.AddEditTHPOIInit(cod, "POI");
            return PartialView(itemEdit);
        }

        [HttpPost]
        public JsonResult AddEdit(CEntVM vm)
        {
            CLogica logExe = new CLogica();
            return Json(logExe.AddEditTHPOI(vm, (ModelSession.GetSession())[0].COD_UCUENTA, "POI"));
        }
    }
}