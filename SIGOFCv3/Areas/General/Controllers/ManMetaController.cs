using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Meta;
using CLogica = CapaLogica.DOC.Log_Meta;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ManMetaController : Controller
    {
        // GET: General/ManMeta
        public ActionResult Index()
        {
            try
            {
                ViewBag.TituloFormulario = "Lista de Metas por Indicador";
                ViewBag.ddlOptBuscar = new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "Todos", Text = "Todos" },
                    new SelectListItem() { Value = "Anio", Text = "Año" }
                };

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public JsonResult GetListMeta(string opc, string valor)
        {
            try
            {
                CLogica logExe = new CLogica();
                var lstMeta = logExe.GetListMeta(opc, valor);
                var jsonResult = Json(new { data = lstMeta, success = true }, JsonRequestBehavior.AllowGet);
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
            string coducuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            var itemEdit = logExe.AddEditMetaInit(cod, coducuenta);
            return PartialView(itemEdit);
        }

        [HttpPost]
        public JsonResult FiltrarIndicador(string tipo)
        {
            Ent_IndicadorFiltro obj = new Ent_IndicadorFiltro();
            Log_IndicadorFiltro exe = new Log_IndicadorFiltro();

            try
            {
                obj = exe.RegMostCombo(new Ent_IndicadorFiltro() { TIPO = tipo });

                List<VM_Cbo> lstCboIndicadorItem = new List<VM_Cbo>();
                lstCboIndicadorItem.Add(new VM_Cbo() { Value = "-", Text = "Seleccionar" });
                foreach (var item in obj.ListIndicador)
                {
                    if (tipo == "MAPRO")
                    {
                        lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.CODIGO + " | " + item.DESCRIPCION, Tipo = item.META });
                    }
                    else
                    {
                        if (item.COD_INDICADOR == "0000017" || item.COD_INDICADOR == "0000019")
                        {
                            lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.DESCRIPCION });
                        }
                    }
                }

                return Json(new { success = true, result = lstCboIndicadorItem });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult FiltrarAnio(string codindicador, string tipo)
        {
            Ent_IndicadorFiltro obj = new Ent_IndicadorFiltro();
            Log_IndicadorFiltro exe = new Log_IndicadorFiltro();

            try
            {
                Ent_IndicadorFiltro param = new Ent_IndicadorFiltro();
                param.NV_CODIGO = codindicador;
                param.TIPO = tipo;
                param.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;

                obj = exe.RegMostComboAnio(param);

                List<VM_Cbo> lstCboAnioItem = new List<VM_Cbo>();
                lstCboAnioItem.Add(new VM_Cbo() { Value = "-", Text = "Seleccionar" });
                foreach (var item in obj.ListAnio)
                {
                    lstCboAnioItem.Add(new VM_Cbo() { Value = item.CODIGO, Text = item.DESCRIPCION });
                }

                return Json(new { success = true, result = lstCboAnioItem });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult AddEdit(CEntVM vm)
        {
            CLogica logExe = new CLogica();
            return Json(logExe.AddEditMeta(vm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
    }
}