using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.Documento;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Areas.General.Controllers;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Focalizacion.Controllers
{
    public class PriorizacionController : Controller
    {
        // GET: Focalizacion/Priorizacion
        private Log_Focalizacion _log;
        public ActionResult Index()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            List<VM_Cbo> ods = exeBus.RegMostComboIndividual("FOCALIZACION_OD", "");
            // ods.Remove(ods.Single(r => r.Value == "0000000"));
            ViewBag.ddlOD = ods;
            ViewBag.ddlPeriodo = exeBus.RegMostComboIndividual("FOCALIZACION_PERIODO_PRIORIZACION", "");
            
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE FOCALIZACIÓN", "Priorización de planes de manejo");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpGet]
        public JsonResult PaspeqPriorizacionListar(string periodo, string codOd, string numTH = null)
        {
            _log = new Log_Focalizacion();
            List<VM_Focalizacion_Priorizacion> result = new List<VM_Focalizacion_Priorizacion>();
            numTH = numTH ?? "";
            result = _log.PaspeqPriorizacionListar(periodo, codOd, numTH);
            var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public ActionResult _Calificación(string codPlan, int codSecuencial)
        {

            _log = new Log_Focalizacion();
            VM_Focalizacion_Priorizacion item = _log.PaspeqPriorizacionGetById(codPlan, codSecuencial);
            return PartialView(item);
        }
        [HttpPost]
        public JsonResult GuardarCalificacion(List<VM_Focalizacion_Priorizacion_> calificacion)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PaspeqPriorizacionInsertarEliminar(calificacion, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se registró la calificación correctamente" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }
        }
        public ActionResult DownloadPaspeqPriorizacion(string periodo, string codOd, string numTH = null)
        {
            //obteniendo data
            numTH = numTH ?? "";
            _log = new Log_Focalizacion();
            List<VM_Focalizacion_Priorizacion> items = new List<VM_Focalizacion_Priorizacion>();
            items = _log.PaspeqPriorizacionListar(periodo, codOd, numTH);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Focalizacion/Plantilla_PriorizacionV1.xlsx"));
            int rowStart = 10;
            int contador = 0;
            int colInitFormula = 9;

            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                //obteniendo OD
                CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                List<VM_Cbo> ods = exeBus.RegMostComboIndividual("FOCALIZACION_OD", "");
                var odSelecionado = ods.Single(r => r.Value == codOd);
                worksheet.Cells["C4"].Value = odSelecionado.Text;
                worksheet.Cells["C5"].Value = periodo;
                worksheet.Cells["C6"].Value = numTH;
                //worksheet.Cells["B2"].Value = mes;
                if (items.Count > 0)
                {
                    string a1, a2, a3, a4, a5, a6, a7, a8;
                    string b1, b2, b3, b4, b5, b6;
                    string forTotal;
                    foreach (var item in items)
                    {
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.codPlan + "|" + item.codSecuencial.ToString();
                        // worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.codSecuencial;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.numTH;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.planManejo;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.a1 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.a2 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.a3 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.a4 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.a5 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.a6 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.a7 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.a8 > 0 ? 1 : (Int32?)null;
                        //$"Hello {userName}. Today is {date}.";
                        a1 = $"{HelperSigo.GetColum(6)}{rowStart.ToString()}*{HelperSigo.GetColum(6)}{(colInitFormula).ToString()}";
                        a2 = $"{HelperSigo.GetColum(7)}{rowStart.ToString()}*{HelperSigo.GetColum(7)}{(colInitFormula).ToString()}";
                        a3 = $"{HelperSigo.GetColum(8)}{rowStart.ToString()}*{HelperSigo.GetColum(8)}{(colInitFormula).ToString()}";
                        a4 = $"{HelperSigo.GetColum(9)}{rowStart.ToString()}*{HelperSigo.GetColum(9)}{(colInitFormula).ToString()}";
                        a5 = $"{HelperSigo.GetColum(10)}{rowStart.ToString()}*{HelperSigo.GetColum(10)}{(colInitFormula).ToString()}";
                        a6 = $"{HelperSigo.GetColum(11)}{rowStart.ToString()}*{HelperSigo.GetColum(11)}{(colInitFormula).ToString()}";
                        a7 = $"{HelperSigo.GetColum(12)}{rowStart.ToString()}*{HelperSigo.GetColum(12)}{(colInitFormula).ToString()}";
                        a8 = $"{HelperSigo.GetColum(13)}{rowStart.ToString()}*{HelperSigo.GetColum(13)}{(colInitFormula).ToString()}";
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Formula = $"={a1}+{a2}+{a3}+{a4}+{a5}+{a6}+{a7}+{a8}"; //"=G10*G9+H10*H9";
                        worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = item.b1 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = item.b2 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = item.b3 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = item.b4 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = item.b5 > 0 ? 1 : (Int32?)null;
                        worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = item.b6 > 0 ? 1 : (Int32?)null;
                        b1 = $"{HelperSigo.GetColum(15)}{rowStart.ToString()}*{HelperSigo.GetColum(15)}{(colInitFormula).ToString()}";
                        b2 = $"{HelperSigo.GetColum(16)}{rowStart.ToString()}*{HelperSigo.GetColum(16)}{(colInitFormula).ToString()}";
                        b3 = $"{HelperSigo.GetColum(17)}{rowStart.ToString()}*{HelperSigo.GetColum(17)}{(colInitFormula).ToString()}";
                        b4 = $"{HelperSigo.GetColum(18)}{rowStart.ToString()}*{HelperSigo.GetColum(18)}{(colInitFormula).ToString()}";
                        b5 = $"{HelperSigo.GetColum(19)}{rowStart.ToString()}*{HelperSigo.GetColum(19)}{(colInitFormula).ToString()}";
                        b6 = $"{HelperSigo.GetColum(20)}{rowStart.ToString()}*{HelperSigo.GetColum(20)}{(colInitFormula).ToString()}";
                        worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Formula = $"={b1}+{b2}+{b3}+{b4}+{b5}+{b6}";
                        forTotal = $"{HelperSigo.GetColum(14)}{rowStart.ToString()}+{HelperSigo.GetColum(21)}{rowStart.ToString()}"; ;
                        worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Formula = $"={forTotal}";
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "B10:W" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "PaspeqPriorizacion";
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
        [HttpPost]
        public JsonResult UploadPaspeqPriorizacion()
        {
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

                            VM_Focalizacion_Priorizacion_ oCampos;
                            List<VM_Focalizacion_Priorizacion_> ListPriorizacion = new List<VM_Focalizacion_Priorizacion_>();
                            for (int rowIterator = 10; rowIterator <= noOfRow; rowIterator++)
                            {
                                oCampos = new VM_Focalizacion_Priorizacion_();
                                oCampos.codPlan = workSheet.Cells[rowIterator, 3].Value.ToString().Split('|')[0];
                                oCampos.codSecuencial = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString().Split('|')[1]);
                                oCampos.a1 = workSheet.Cells[rowIterator, 6].Value == null ? 0 : 1;
                                oCampos.a2 = workSheet.Cells[rowIterator, 7].Value == null ? 0 : 1;
                                oCampos.a3 = workSheet.Cells[rowIterator, 8].Value == null ? 0 : 1;
                                oCampos.a4 = workSheet.Cells[rowIterator, 9].Value == null ? 0 : 1;
                                oCampos.a5 = workSheet.Cells[rowIterator, 10].Value == null ? 0 : 1;
                                oCampos.a6 = workSheet.Cells[rowIterator, 11].Value == null ? 0 : 1;
                                oCampos.a7 = workSheet.Cells[rowIterator, 12].Value == null ? 0 : 1;
                                oCampos.a8 = workSheet.Cells[rowIterator, 13].Value == null ? 0 : 1;
                                oCampos.b1 = workSheet.Cells[rowIterator, 15].Value == null ? 0 : 1;
                                oCampos.b2 = workSheet.Cells[rowIterator, 16].Value == null ? 0 : 1;
                                oCampos.b3 = workSheet.Cells[rowIterator, 17].Value == null ? 0 : 1;
                                oCampos.b4 = workSheet.Cells[rowIterator, 18].Value == null ? 0 : 1;
                                oCampos.b5 = workSheet.Cells[rowIterator, 19].Value == null ? 0 : 1;
                                oCampos.b6 = workSheet.Cells[rowIterator, 20].Value == null ? 0 : 1;
                                ListPriorizacion.Add(oCampos);
                            }
                            if (ListPriorizacion.Count > 0)
                            {
                                _log = new Log_Focalizacion();
                                _log.PaspeqPriorizacionInsertarEliminar(ListPriorizacion, (ModelSession.GetSession())[0].COD_UCUENTA);
                            }
                        }
                    }
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json(new { success = false, msj = "Sucedió un error" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, msj = "Se registró la calificación del PASPEQ correctamente" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Focalizacion/Priorizacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
