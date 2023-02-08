using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Reportes.Paspeq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SIGOFCv3.Areas.PlanFocalizacion.Controllers
{
    public class PriorizacionController : Controller
    {
        private Log_Priorizacion logPriorizacion;
        // GET: PlanFocalizacion/Priorizacion
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

        [HttpPost]
        public JsonResult ExportarPriorizacion(string cod_od, string periodo)
        {
            ListResult result = ReportePriorizacion.GenerarReportePriorizacion(cod_od, periodo);

            return Json(result);
        }

        [HttpGet]
        public JsonResult GetListCriterios()
        {
            bool success = true;
            object retorna = new object();
            string msj = "";

            logPriorizacion = new Log_Priorizacion();
            retorna = logPriorizacion.GetListCriterios();

            var jsonResult = Json(new { success = success, msj = msj, data = retorna }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetListPlanManejoSupervisado(string cod_od, string periodo)
        {
            bool success = true;
            object retorna = new object();
            string msj = "";

            logPriorizacion = new Log_Priorizacion();
            retorna = logPriorizacion.GetListPlanManejoSupervisado(cod_od, periodo);

            var jsonResult = Json(new { success = success, msj = msj, data = retorna }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadPriorizacion(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }

        [HttpPost]
        public JsonResult ImportarDataExcel()
        {
            bool success = true;
            object retorna = new object();
            string msj = "";

            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {

                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;

                            Ent_Priorizacion_Detalle oCampos;
                            string hdfExcelImportar = Request["TVentana"];
                            string hdfPeriodo = Request["hdfPeriodo"];
                            string hdfCod_OD = Request["hdfCod_OD"];
                            List<Ent_Priorizacion_Detalle> ListPriorizacion = new List<Ent_Priorizacion_Detalle>();

                            if (hdfExcelImportar == "PRIORIZACION")
                            {
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    oCampos = new Ent_Priorizacion_Detalle();
                                    oCampos.COD_PASPEQ_DETALLE = workSheet.Cells[rowIterator, 2].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                    oCampos.A1 = workSheet.Cells[rowIterator, 5].Value == null ? 0 : 1;
                                    oCampos.A2 = workSheet.Cells[rowIterator, 6].Value == null ? 0 : 1;
                                    oCampos.A3 = workSheet.Cells[rowIterator, 7].Value == null ? 0 : 1;
                                    oCampos.A4 = workSheet.Cells[rowIterator, 8].Value == null ? 0 : 1;
                                    oCampos.A5 = workSheet.Cells[rowIterator, 9].Value == null ? 0 : 1;
                                    oCampos.A6 = workSheet.Cells[rowIterator, 10].Value == null ? 0 : 1;
                                    oCampos.A7 = workSheet.Cells[rowIterator, 11].Value == null ? 0 : 1;
                                    oCampos.A8 = workSheet.Cells[rowIterator, 12].Value == null ? 0 : 1;
                                    oCampos.B1 = workSheet.Cells[rowIterator, 13].Value == null ? 0 : 1;
                                    oCampos.B2 = workSheet.Cells[rowIterator, 14].Value == null ? 0 : 1;
                                    oCampos.B3 = workSheet.Cells[rowIterator, 15].Value == null ? 0 : 1;
                                    oCampos.B4 = workSheet.Cells[rowIterator, 16].Value == null ? 0 : 1;
                                    oCampos.B5 = workSheet.Cells[rowIterator, 17].Value == null ? 0 : 1;
                                    oCampos.B6 = workSheet.Cells[rowIterator, 18].Value == null ? 0 : 1;
                                    ListPriorizacion.Add(oCampos);
                                }
                                logPriorizacion = new Log_Priorizacion();
                                Ent_Priorizacion ent = new Ent_Priorizacion();
                                ent.COD_OD = hdfCod_OD;
                                ent.PERIODO = hdfPeriodo;
                                retorna = logPriorizacion.SeleccionarCriterios(ListPriorizacion, ent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                else msj = ex.Message;
            }

            var jsonResult = Json(new { success = success, msj = msj, data = retorna }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}