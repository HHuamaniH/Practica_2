using CapaEntidad.GENE;
using CapaEntidad.ViewModel;
using CapaLogica.GENE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManCalculoMultaController : Controller
    {
        // GET: Fiscalizacion/ManCalculoMulta
        public ActionResult Index()
        {          
            return View();
        }
        public ActionResult ModalCalculo()
        {
            Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            ViewBag.ddlModalidad = log_MANCALCULOMULTA.RegMostComboIndividual_v3("MODALIDAD", "0");
            ViewBag.ddlIPC = log_MANCALCULOMULTA.RegMostComboIndividual_v3("IPC", "");
            ViewBag.ddlLiteral = log_MANCALCULOMULTA.RegMostComboIndividual_v3("LITERALMANCALMUL", "");
            return PartialView("~/Areas/Fiscalizacion/Views/ManCalculoMulta/Shared/_modalCalculoMulta.cshtml");
        }
        [HttpGet]
        public JsonResult ObtenerEspecie(string cod_especie)
        {
            //string cod_especie;
            Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            List<VM_Cbo> especieList = log_MANCALCULOMULTA.RegMostComboIndividual_v3("VENESPECIE", cod_especie);          

            var jsonResult = Json(new
            {
                success = true,
                ven = especieList
            },JsonRequestBehavior.AllowGet);

            return jsonResult;
        }
        [HttpGet]
        public JsonResult ObtenerIPC(string cod_fecha)
        {
            //string cod_especie;
            Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            List<VM_Cbo> especieList = log_MANCALCULOMULTA.RegMostComboIndividual_v3("IPCFECHA", cod_fecha);          

            var jsonResult = Json(new
            {
                success = true,
                ven = especieList
            },JsonRequestBehavior.AllowGet);

            return jsonResult;
        } 
        [HttpGet]
        public JsonResult ObtenerPd(string literal)
        {
            //string cod_especie;
            Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            List<VM_Cbo> pdList = log_MANCALCULOMULTA.RegMostComboIndividual_v3("LITERALPD", literal);          

            var jsonResult = Json(new
            {
                success = true,
                Pd = pdList
            },JsonRequestBehavior.AllowGet);

            return jsonResult;
        }
        
    }
}