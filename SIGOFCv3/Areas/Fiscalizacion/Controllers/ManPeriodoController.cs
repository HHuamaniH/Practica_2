using CapaEntidad.ViewModel;
using CapaLogica.Documento;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManPeriodoController : Controller
    {
        private Log_Periodo logPeriodo;
        // GET: Fiscalizacion/ManPeriodo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _AddEdit(string cod = "")
        {

            logPeriodo = new Log_Periodo();

            var itemEdit = logPeriodo.AddEditPeriodoInit(cod);
            if(cod!="") itemEdit.estado = 0;
            return PartialView(itemEdit);
        }

        [HttpGet]
        public JsonResult GetListPeriodo(string criterio = "", string valor = "")
        {
            try
            {
                logPeriodo = new Log_Periodo();
                criterio = criterio.Trim();
                valor = valor.Trim();
                var lstPerfil = logPeriodo.GetListPeriodo(criterio, valor);
                var jsonResult = Json(new { data = lstPerfil, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult _AddEdit(VM_Periodo vm)
        {
            logPeriodo = new Log_Periodo();
            return Json(logPeriodo.AddEditPeriodo(vm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }

        [HttpPost]
        public JsonResult _DeletePeriodo(string id)
        {
            DateTime fecha = Convert.ToDateTime(id);
            var test = fecha.ToString("dd/MM/yyyy");

            logPeriodo = new Log_Periodo();
            return Json(logPeriodo.DeletePeriodo(fecha.ToString("dd/MM/yyyy"), (ModelSession.GetSession())[0].COD_UCUENTA));
        }
    }
}