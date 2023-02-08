using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Reportes.Paspeq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.PlanFocalizacion.Controllers
{
    public class PaspeqController : Controller
    {
        // GET: PlanFocalizacion/Paspeq   
        private Log_Paspeq logPaspeq;
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Formulario = "PASPEQ";
            ViewBag.TituloFormulario = "Listado de formulación del Paspeq";
            return View();
        }
        [HttpGet]
        public ActionResult _Paspeq()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _PaspeqSeleccion(int num_paspeq = 0, string periodo = "")
        {
            logPaspeq = new Log_Paspeq();
            return PartialView(logPaspeq.PaspeqSeleccion(num_paspeq, periodo));
        }
        [HttpGet]
        public ActionResult _PaspeqDetalle(int num_paspeq = 0, string periodo = "")
        {
            ViewBag.num_paspeq = num_paspeq;
            ViewBag.periodo = periodo;
            return PartialView();
        }
        [HttpGet]
        public ActionResult _PaspeqEliminar(int num_paspeq = 0, string periodo = "")
        {
            logPaspeq = new Log_Paspeq();
            return PartialView(logPaspeq.PaspeqSeleccion(num_paspeq, periodo));
        }

        //[HttpGet]
        //public JsonResult CreatePaspeq()
        //{
        //    try
        //    {
        //        String codFormulario = "0000051";
        //        String tipoAccion = "INSERT";
        //        ListResult result;
        //        logPaspeq = new Log_Paspeq();
        //        result = logPaspeq.CreatePaspeq();
        //        registrarFormularioAuditoria(codFormulario, tipoAccion);
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { data = "", msj = "El Paspeq no se pudo generar", success = false, msjError = ex.Message });
        //    }
        //}
        //[HttpPost]
        //public JsonResult SeleccionarPaspeq(VM_PaspeqDetalle vm)
        //{
        //    try
        //    {
        //        logPaspeq = new Log_Paspeq();
        //        var resultado = logPaspeq.SeleccionarPaspeq(vm);
        //        if (resultado)
        //        {
        //            var jsonResult = Json(new { data = "", success = true }, JsonRequestBehavior.AllowGet);
        //            return jsonResult;
        //        }
        //        else
        //        {
        //            return Json(new { data = "", success = false, msjError = "Falló la selección del Paspeq" });
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { data = "", success = false, msjError = ex.Message });
        //    }
        //}
        //[HttpPost]
        //public JsonResult EliminarPaspeq(VM_PaspeqDetalle vm)
        //{
        //    try
        //    {
        //        logPaspeq = new Log_Paspeq();
        //        var resultado = logPaspeq.EliminarPaspeq(vm);
        //        if (resultado)
        //        {
        //            var jsonResult = Json(new { data = "", success = true }, JsonRequestBehavior.AllowGet);
        //            return jsonResult;
        //        }
        //        else
        //        {
        //            return Json(new { data = "", success = false, msjError = "Falló la eliminación del Paspeq" });
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { data = "", success = false, msjError = ex.Message });
        //    }
        //}
        //[HttpPost]
        //public JsonResult GetListPaspeq(VM_PaspeqDetalle vm)
        //{
        //    try
        //    {
        //        logPaspeq = new Log_Paspeq();
        //        var lstPaspeq = logPaspeq.GetAllPaspeq(vm);
        //        var jsonResult = Json(new { data = lstPaspeq, success = true }, JsonRequestBehavior.AllowGet);
        //        jsonResult.MaxJsonLength = int.MaxValue;
        //        return jsonResult;
        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { data = "", success = false, msjError = ex.Message });
        //    }
        //}
        //[HttpPost]
        //public JsonResult ExportarPaspeq(int num_paspeq, string periodo)
        //{
        //    System.Diagnostics.Debug.WriteLine("parametros : " + num_paspeq + " " + periodo);
        //    ListResult result = ReportePaspeq.GenerarReportePaspeq(num_paspeq, periodo);

        //    return Json(result);
        //}
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadPaspeq(string file)
        {
            String codFormulario = "0000051";
            String tipoAccion = "DOWNLOAD";
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            registrarFormularioAuditoria(codFormulario, tipoAccion);
            return File(fullPath, "application/vnd.ms-excel", file);
        }

        private void registrarFormularioAuditoria(String codFormulario, String tipoAccion)
        {
            Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
            CapaEntidad.GENE.Ent_AUDITORIA auditoria = new CapaEntidad.GENE.Ent_AUDITORIA();
            auditoria.codCuentaUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            auditoria.hostName = Convert.ToString(ipEntry.HostName);
            auditoria.ipServer = Convert.ToString(ipEntry.AddressList[ipEntry.AddressList.Length - 1]);
            String ipClient = "";
            ipClient = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(ipClient)) { ipClient = Request.ServerVariables["REMOTE_ADDR"]; }
            auditoria.ipCliente = ipClient;
            String camposAfectados = "";
            oCLogica.logRegistroAccion(codFormulario, auditoria.ipServer, auditoria.hostName, auditoria.ipCliente, camposAfectados, tipoAccion, auditoria.codCuentaUsuario);
        }

        //[HttpPost]
        //public JsonResult ImportarDataExcel()
        //{
        //    bool success = true;
        //    object retorna = new object();
        //    string msj = "";

        //    try
        //    {
        //        if (Request != null)
        //        {
        //            HttpPostedFileBase file = Request.Files[0];
        //            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
        //            {

        //                using (var package = new ExcelPackage(file.InputStream))
        //                {
        //                    var currentSheet = package.Workbook.Worksheets;
        //                    var workSheet = currentSheet.First();
        //                    var noOfCol = workSheet.Dimension.End.Column;
        //                    var noOfRow = workSheet.Dimension.End.Row;

        //                    VM_PaspeqDetalle oCampos;
        //                    string hdfItemExcelImportar = Request["TVentana"];
        //                    string hdfItemPeriodo = Request["hdfItemPeriodo"];
        //                    string hdfItemNum_Paspeq = Request["hdfItemNum_Paspeq"];
        //                    List<VM_PaspeqDetalle> ListPaspeqDetalle = new List<VM_PaspeqDetalle>();

        //                    if (hdfItemExcelImportar == "LISTAPASPEQ")
        //                    {
        //                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
        //                        {
        //                            oCampos = new VM_PaspeqDetalle();
        //                            oCampos.cod_thabilitante = workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
        //                            oCampos.num_poa = workSheet.Cells[rowIterator, 3].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
        //                            oCampos.cod_pmanejo = workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
        //                            oCampos.tabla_plan_manejo = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
        //                            oCampos.thabilitante = workSheet.Cells[rowIterator, 6].Value == null ? "" : workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
        //                            oCampos.ubicacion = workSheet.Cells[rowIterator, 9].Value == null ? "" : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
        //                            oCampos.oficina = workSheet.Cells[rowIterator, 17].Value == null ? "" : workSheet.Cells[rowIterator, 17].Value.ToString().Trim();
        //                            oCampos.plan_manejo = workSheet.Cells[rowIterator, 18].Value == null ? "" : workSheet.Cells[rowIterator, 18].Value.ToString().Trim();
        //                            oCampos.resolucion_aprobacion = workSheet.Cells[rowIterator, 19].Value == null ? "" : workSheet.Cells[rowIterator, 19].Value.ToString().Trim();
        //                            oCampos.num_paspeq = Convert.ToInt32(hdfItemNum_Paspeq);
        //                            oCampos.periodo = hdfItemPeriodo;
        //                            ListPaspeqDetalle.Add(oCampos);
        //                        }
        //                        logPaspeq = new Log_Paspeq();
        //                        Ent_Paspeq ent = new Ent_Paspeq();
        //                        ent.NUM_PASPEQ = Convert.ToInt32(hdfItemNum_Paspeq);
        //                        ent.PERIODO = hdfItemPeriodo;
        //                        retorna = logPaspeq.AjustePaspeq(ListPaspeqDetalle, ent);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        string[] mensaje = ex.Message.Split('|');
        //        if (mensaje[0] == "0")
        //            msj = mensaje[1];
        //        else msj = ex.Message;
        //    }

        //    var jsonResult = Json(new { success = success, msj = msj, data = retorna }, JsonRequestBehavior.AllowGet);
        //    jsonResult.MaxJsonLength = int.MaxValue;
        //    return jsonResult;
        //}
    }
}