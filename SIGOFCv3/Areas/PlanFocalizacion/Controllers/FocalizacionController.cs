using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using CapaLogica.DOC;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Areas.General.Controllers;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Reportes.Paspeq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.PlanFocalizacion.Controllers
{
    public class FocalizacionController : Controller
    {
        // GET: PlanFocalizacion/PlanTrabajo
        private Log_PlanTrabajo logPlanTrabajo;

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Formulario = "FOCALIZACION";
            ViewBag.TituloFormulario = "Listado de planes de trabajo";
            ViewBag.vbOD = new List<SelectListItem>() { new SelectListItem() { Text = "Sede Principal", Value = "0000001" } , new SelectListItem() { Text = "Pucallpa", Value = "0000002" }, new SelectListItem() { Text = "Puerto Maldonado", Value = "0000003" },
                                                        new SelectListItem() { Text = "Tarapoto", Value = "0000004" }, new SelectListItem() { Text = "Chiclayo", Value = "0000005" }, new SelectListItem() { Text = "Atalaya", Value = "0000006" },
                                                        new SelectListItem() { Text = "La Merced", Value = "0000007" }, new SelectListItem() { Text = "Iquitos", Value = "0000008" }};
            ViewBag.vbPeriodo = new List<SelectListItem>() { new SelectListItem() { Text = "Periodo", Value = "Periodo" } };
            return View();
        }

        [HttpGet]
        public ActionResult _PlanTrabajoEliminar(int cod_paspeq_plan_trabajo = 0, string mes_focalizacion = "", string periodo = "")
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return PartialView(logPlanTrabajo.PlanTrabajoSeleccion(cod_paspeq_plan_trabajo, mes_focalizacion, periodo));
        }

        [HttpGet]
        public ActionResult _PlanTrabajoEspeciesEdit(int cod_paspeq_plan_trabajo_especies = 0, int cod_paspeq_detalle_mensual = 0, string especie = "", string cod_especies = "", int aprovechables_supervisar = 0, int semilleros_supervisar = 0)
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return PartialView(logPlanTrabajo.EspecieSeleccion(cod_paspeq_plan_trabajo_especies, cod_paspeq_detalle_mensual, especie, cod_especies, aprovechables_supervisar, semilleros_supervisar));
        }

        [HttpPost]
        public JsonResult EspecieEdicion(VM_PlanManejoEspecies vm)
        {
            try
            {
                ListResult result;
                logPlanTrabajo = new Log_PlanTrabajo();
                result = logPlanTrabajo.GuardarEspecie(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "", msj = "Los datos no se pudieron guardar", success = false, msjError = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EliminarPlanTrabajo(VM_PlanTrabajo vm)
        {
            try
            {
                logPlanTrabajo = new Log_PlanTrabajo();
                var resultado = logPlanTrabajo.EliminarPlanTrabajo(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                if (resultado)
                {
                    var jsonResult = Json(new { data = "", success = true }, JsonRequestBehavior.AllowGet);
                    return jsonResult;
                }
                else
                {
                    return Json(new { data = "", success = false, msjError = "Falló la eliminación del Plan de trabajo" });
                }

            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult _PlanTrabajo(string periodo = "", string cod_od = "")
        {
            ViewBag.periodo = periodo;
            ViewBag.cod_od = cod_od;
            ViewBag.mes_focalizacion = new List<SelectListItem>() { new SelectListItem() { Text = "Enero", Value = "01" },
                                                                    new SelectListItem() { Text = "Febrero", Value = "02" },
                                                                    new SelectListItem() { Text = "Marzo", Value = "03" },
                                                                    new SelectListItem() { Text = "Abril", Value = "04" },
                                                                    new SelectListItem() { Text = "Mayo", Value = "05" },
                                                                    new SelectListItem() { Text = "Junio", Value = "06" },
                                                                    new SelectListItem() { Text = "Julio", Value = "07" },
                                                                    new SelectListItem() { Text = "Agosto", Value = "08" },
                                                                    new SelectListItem() { Text = "Setiembre", Value = "09" },
                                                                    new SelectListItem() { Text = "Octubre", Value = "10" },
                                                                    new SelectListItem() { Text = "Noviembre", Value = "11" },
                                                                    new SelectListItem() { Text = "Diciembre", Value = "12" }
                                                                };
            return PartialView();
        }

        [HttpGet]
        public ActionResult _PlanTrabajoAprobar(int cod_paspeq_plan_trabajo = 0, string mes_focalizacion = "", string periodo = "")
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return PartialView(logPlanTrabajo.PlanTrabajoSeleccion(cod_paspeq_plan_trabajo, mes_focalizacion, periodo));
        }

        [HttpGet]
        public ActionResult _PlanTrabajoDetalle(int cod_paspeq_plan_trabajo = 0, string mes_focalizacion = "", string periodo = "", string od = "")
        {
            ViewBag.cod_paspeq_plan_trabajo = cod_paspeq_plan_trabajo;
            string mes = "";
            switch (mes_focalizacion)
            {
                case "01": mes = "Enero"; break;
                case "02": mes = "Febrero"; break;
                case "03": mes = "Marzo"; break;
                case "04": mes = "Abril"; break;
                case "05": mes = "Mayo"; break;
                case "06": mes = "Junio"; break;
                case "07": mes = "Julio"; break;
                case "08": mes = "Agosto"; break;
                case "09": mes = "Setiembre"; break;
                case "10": mes = "Octubre"; break;
                case "11": mes = "Noviembre"; break;
                case "12": mes = "Diciembre"; break;
            }
            ViewBag.mes_focalizacion = mes;
            ViewBag.periodo = periodo;
            ViewBag.OD_SEDE = od;
            return PartialView();
        }
        [HttpGet]
        public ActionResult _PlanTrabajoEspecies(int cod_paspeq_detalle_mensual = 0, string num_thabilitante = "", string nombre_poa = "")
        {
            ViewBag.cod_paspeq_detalle_mensual = cod_paspeq_detalle_mensual;
            ViewBag.num_thabilitante = num_thabilitante;
            ViewBag.nombre_poa = nombre_poa;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult _PlanManejoAdd()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult _PlanManejoAddExtra()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult _Calidad(string cod_paspeq_plan_trabajo)
        {
            ViewBag.cod_paspeq_id = cod_paspeq_plan_trabajo;
            return PartialView();
        }
        [HttpPost]
        public JsonResult actualizarCalidadPlan(VM_ControlCalidad_2 vm)
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return Json(logPlanTrabajo.actualizarCalidadPlan(vm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
        [HttpPost]
        public JsonResult CreatePlanTrabajo(VM_PlanTrabajo vm)
        {
            try
            {
                ListResult result;
                logPlanTrabajo = new Log_PlanTrabajo();
                result = logPlanTrabajo.CreatePlanTrabajo(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "", msj = "El Plan de trabajo no se pudo generar", success = false, msjError = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult AprobarPlanTrabajo(VM_PlanTrabajo vm)
        {
            try
            {
                logPlanTrabajo = new Log_PlanTrabajo();
                var resultado = logPlanTrabajo.AprobarPlanTrabajo(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                if (resultado)
                {
                    var jsonResult = Json(new { data = "", success = true }, JsonRequestBehavior.AllowGet);
                    return jsonResult;
                }
                else
                {
                    return Json(new { data = "", success = false, msjError = "Falló la selección del Paspeq" });
                }

            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetListPlanTrabajo(VM_PlanTrabajo vm)
        {
            try
            {
                logPlanTrabajo = new Log_PlanTrabajo();
                var lstPaspeq = logPlanTrabajo.GetAllPlanManejo(vm);
                var jsonResult = Json(new { data = lstPaspeq, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetListEspecies(VM_PlanManejoEspecies vm)
        {
            try
            {
                logPlanTrabajo = new Log_PlanTrabajo();
                var lstPaspeq = logPlanTrabajo.GetAllEspecies(vm);
                var jsonResult = Json(new { data = lstPaspeq, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }

        //[HttpPost]
        //public JsonResult ExportarPlanTrabajo(int num_paspeq, string periodo)
        //{
        //    System.Diagnostics.Debug.WriteLine("parametros : " + num_paspeq + " " + periodo);
        //    ListResult result = ReportePlanTrabajo.GenerarReportePlanTrabajo(num_paspeq, periodo);

        //    return Json(result);
        //}
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadPlanTrabajo(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpGet]
        public JsonResult planManejoListar(String COD_PASPEQ_PLAN_TRABAJO = "0")
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            var result = logPlanTrabajo.planManejoListar(int.Parse(COD_PASPEQ_PLAN_TRABAJO));
            var jsonResult = Json(new { data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult planTrabajoItemsListar(int cod_paspeq_plan_trabajo)
        {
            try
            {
                logPlanTrabajo = new Log_PlanTrabajo();
                var result = logPlanTrabajo.planTrabajoItemsListar(cod_paspeq_plan_trabajo);
                var jsonResult = Json(new { data = result, success = true, e = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult CreatePlanTrabajoItems(List<VM_Paspeq_Detalle_Mensual> vms)
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return Json(logPlanTrabajo.CreatePlanTrabajoItems(vms, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
        [HttpPost]
        public JsonResult deletePlanTrabajoItem(int cod_paspeq_detalle_mensual)
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return Json(logPlanTrabajo.deletePlanTrabajoItem(cod_paspeq_detalle_mensual, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
        [HttpPost]
        public JsonResult CreatePlanTrabajoItemsExtra(VM_PaspeqDetalle vm)
        {
            logPlanTrabajo = new Log_PlanTrabajo();
            return Json(logPlanTrabajo.CreatePlanTrabajoItemsExtra(vm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
        public ActionResult DownloadPlanTrabajoItems(int cod_paspeq_plan_trabajo, string mes = "", string od = "")
        {
            //obteniendo data
            logPlanTrabajo = new Log_PlanTrabajo();
            List<VM_PlanTrabajoDetalle> items = new List<VM_PlanTrabajoDetalle>();
            items = logPlanTrabajo.planTrabajoItemsListarExcel(cod_paspeq_plan_trabajo);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Paspeq/paspeq_plan_items.xlsx"));
            int rowStart = 5;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                //*** Sheet 1
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                worksheet.Cells["B1"].Value = od;
                worksheet.Cells["B2"].Value = mes;
                foreach (var item in items)
                {
                    worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                    worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.titular;
                    worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.titulo_habilitante;
                    worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.modalidad;
                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.plan_manejo;
                    worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.departamento;
                    worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.provincia;
                    worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.distrito;
                    worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.tipo_supervision;
                    worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.criterios_focalizacion;
                    worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.oportunidad;
                    rowStart = rowStart + 1;
                }
                string modelRange = "A5:K" + (rowStart - 1).ToString();
                var modelTable = worksheet.Cells[modelRange];
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                // package.SaveAs(new FileInfo(Server.MapPath("~/Archivos/Plantilla/Paspeq/temp/demo.xlsx")));
                string excelName = "planTrabajo";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResult
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }

        public ActionResult DownloadPlanTrabajoEspecies(int cod_paspeq_plan_trabajo, string mes = "", string od = "")
        {
            //obteniendo data
            logPlanTrabajo = new Log_PlanTrabajo();
            List<VM_PlanTrabajoMuestra> items = new List<VM_PlanTrabajoMuestra>();
            items = logPlanTrabajo.PlanTrabajoMuestraListarExcel(cod_paspeq_plan_trabajo);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Paspeq/muestra_supervisar.xlsx"));
            int rowStart = 5;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                string titulo_habilitante = "";
                string plan_manejo = "";
                //*** Sheet 1
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                worksheet.Cells["B1"].Value = od;
                worksheet.Cells["B2"].Value = mes;
                foreach (var item in items)
                {
                    if ((titulo_habilitante != item.titulo_habilitante) || (plan_manejo != item.plan_manejo))
                    {
                        titulo_habilitante = item.titulo_habilitante;
                        plan_manejo = item.plan_manejo;
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.titular;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.titulo_habilitante;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.plan_manejo;
                    }
                    else
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = "";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = "";
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = "";
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = "";
                    }

                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.especie;
                    worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.aprovechables;
                    worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.semilleros;
                    worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.total;
                    rowStart = rowStart + 1;
                }
                string modelRange = "A5:H" + (rowStart - 1).ToString();
                var modelTable = worksheet.Cells[modelRange];
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                string excelName = "planTrabajoMuestra";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResult
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
    }
}