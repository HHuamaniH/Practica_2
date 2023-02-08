using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using CapaLogica.Documento;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Areas.Supervision.Models.ManInforme;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_InfQuinquenal;
using CEntVM = CapaEntidad.ViewModel.VM_InformeQuinquenal;
using CLogica = CapaLogica.DOC.Log_InformeQuinquenal;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeQuinquenalController : Controller
    {
        // GET: Supervision/ManInformeQuinquenal
        /* public ActionResult Index()
         {
             return View();
         }*/
        public ActionResult DescargarPlantilla()
        {
            try
            {
                string ruta = "";
                ruta = Server.MapPath("~/Archivos/Plantilla/ResultadosHallazgos.xlsx");
                byte[] oBytes = System.IO.File.ReadAllBytes(ruta);

                return File(oBytes, "application/xlsx", "ResultadosHallazgos.xlsx");
            }
            catch (Exception)
            {
                return Content("Plantilla no encontrado");
            }
           
        }
        [HttpPost]
        public JsonResult UploadHallazgo()
        {
            List<CEntidad> list = new List<CEntidad>();
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

                            CEntidad oCampos;
                            string hallazgo = "";
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                hallazgo = "";
                                hallazgo = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                                if (!string.IsNullOrEmpty(hallazgo))
                                {
                                    oCampos = new CEntidad();
                                    oCampos.COD_SECUENCIAL = 0;
                                    oCampos.HALLAZGO = hallazgo;
                                    oCampos.RegEstado = 1;
                                    list.Add(oCampos);
                                }
                               
                            }                          
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, msj = "Sucedió un error" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, msj = "",data= list }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.Formulario = "INFORME_QUINQUENAL"; //INFORME_SUPERVISION INFORME_QUINQUENAL
            ViewBag.TituloFormulario = "Informe Quinquenal";
            ViewBag.AlertaInicial = _alertaIncial;

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe Quinquenal");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario(string valor="")
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuarioQuinquenal((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        public ActionResult DownloadRPT(string valor="")
        {
            int rowcount = 0;
            Log_BUSQUEDA log_BUSQUEDA = new Log_BUSQUEDA();
            List<VM_Reporte> list = new List<VM_Reporte>();
            list = log_BUSQUEDA.InformeQuinquenalReporte("REPORTE", valor, 1, 10000,"", ref rowcount);           

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/RPT_InformeQuinquenal.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (list.Count > 0)
                {                  
                    foreach (var item in list)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.FECHA_CREACION;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.NUM_INFORME;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.TIPO;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.RD_QUINQUENAL;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.NUM_THABILITANTE;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.TITULAR;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:G" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "RPT_InformeQuinquenal";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }

            }

        }

        #region "Mantenimiento Informe"
        public ActionResult AddEdit(string asCodInforme="")
        {
            try
            {
                CLogica exeInf = new CLogica();


                CEntVM vmInf = exeInf.iniDatosInformeQ(asCodInforme, (ModelSession.GetSession())[0].COD_UCUENTA); //(asCodInforme, asCodCNotificacion, (ModelSession.GetSession())[0].COD_UCUENTA);

                if (asCodInforme != "")
                {
                    CEntidad param = new CEntidad();
                    param.BusFormulario = "LIST_QUINQUENIO";
                    param.COD_INFORME = asCodInforme;
                    param.BusValor = "";

                    vmInf.cantidadQuinquenio = exeInf.ObtenerQuinquenios(param);
                }
                //vmInf.hdfCodMTipo = asCodMTipo;

                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe Quinquenal");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                vmInf.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vmInf);
                //return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        public ActionResult _renderQuinquenio(string asCodInforme,int quinquenio)
        {
            CLogica exeInf = new CLogica();
            Ent_InfQuinquenal_QUINQUENIO comInf = new Ent_InfQuinquenal_QUINQUENIO();
            comInf.COD_INFORME = asCodInforme;
            comInf = exeInf.RegMostrarItemsQuinquenio(asCodInforme, quinquenio);
            ViewData["tempVerificadores"] = comInf;
            comInf.COD_INFORME = asCodInforme;
            ViewBag.hdvQuinquenio = quinquenio;
            return PartialView(comInf);
        }
        public ActionResult GetQuinquenio(string asCodInforme, int quinquenio)
        {
            CLogica exeInf = new CLogica();
            Ent_InfQuinquenal_QUINQUENIO comInf = exeInf.RegMostrarItemsQuinquenio(asCodInforme, quinquenio);
            return Json(new { success = true,data= comInf },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddEdit(CEntidad oCampoEntrada)
        {
            bool success = true;
            string msj = string.Empty;
            string codInforme = "";
            try
            {
                CLogica exeInf = new CLogica();
                oCampoEntrada.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                oCampoEntrada.OUTPUTPARAM01 = "";
                oCampoEntrada.FECHA_EMISION = Convert.ToDateTime(oCampoEntrada.FECHA_EMISION);
                //Limpiar variables
                oCampoEntrada.APELLIDOS_NOMBRE = null;
                oCampoEntrada.USUARIO_REGISTRO = null;
                oCampoEntrada.USUARIO_CONTROL = null;

                if (oCampoEntrada.FECHA_INICIO_AUDITORIA != null)
                {
                    if (oCampoEntrada.FECHA_INICIO_AUDITORIA.ToString().Trim() == "") oCampoEntrada.FECHA_INICIO_AUDITORIA = null;
                    else oCampoEntrada.FECHA_INICIO_AUDITORIA = Convert.ToDateTime(oCampoEntrada.FECHA_INICIO_AUDITORIA);
                }
                if (oCampoEntrada.FECHA_FIN_AUDITORIA != null)
                {
                    if (oCampoEntrada.FECHA_FIN_AUDITORIA.ToString().Trim() == "") oCampoEntrada.FECHA_FIN_AUDITORIA = null;
                    else oCampoEntrada.FECHA_FIN_AUDITORIA = Convert.ToDateTime(oCampoEntrada.FECHA_FIN_AUDITORIA);
                }

                codInforme =exeInf.RegGrabarInfQuinv1(oCampoEntrada);
                switch (oCampoEntrada.RegEstado)
                {
                    case 1: msj = "Se registró conrrectamente la información";
                        break;
                    case 0:
                        msj = "Se modificó conrrectamente la información";
                        break;
                }        
            }
            catch (Exception ex)
            {
                success = false;
                msj = ex.Message;
            }
            return Json(new { success,msj, codInforme });
        }
        [HttpPost]
        public ActionResult AddEditQuinquenio(CEntidad oCampoEntrada)
        {
            bool success = true;
            string msj = string.Empty;
            try
            {
                CLogica exeInf = new CLogica();
                oCampoEntrada.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                oCampoEntrada.OUTPUTPARAM01 = "";
                oCampoEntrada.FECHA_EMISION = Convert.ToDateTime(oCampoEntrada.FECHA_EMISION);
                //Limpiar variables
                oCampoEntrada.APELLIDOS_NOMBRE = null;
                oCampoEntrada.USUARIO_REGISTRO = null;
                oCampoEntrada.USUARIO_CONTROL = null;

                exeInf.RegGrabarQuinquenio(oCampoEntrada);
                msj = "Se registró conrrectamente la información";
            }
            catch (Exception ex)
            {
                success = false;
                msj = ex.Message;
            }
            return Json(new { success, msj });
        }
        public ActionResult _BuscarCartaNotificacion()
        {
            return PartialView();
        }
        public JsonResult GetAllCartaNotificacion(string BusValor)
        {
            CLogica exeInf = new CLogica();
            try
            {
                List<CEntidad> consulta = exeInf.GetAllCartaNotificacion("CARTA_NOTIFICACION", "AQ_CN_NUMERO", BusValor, "");
                //int i = 1;

                //var result = from c in consulta
                //             select new
                //             {
                //                 ind = i++,
                //                 COD_CNOTIFICACION = c.COD_CNOTIFICACION,
                //                 NUM_CNOTIFICACION = c.NUM_CNOTIFICACION,
                //                 MODALIDAD = c.MODALIDAD,
                //                 COD_THABILITANTE = c.COD_THABILITANTE,
                //                 NUM_THABILITANTE = c.NUM_THABILITANTE,
                //                 TITULAR = c.TITULAR,
                //                 POA = c.POA

                //             };
                var jsonResult = Json(new { data = consulta, success = true, er = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, er = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        //[HttpGet]
        //public JsonResult buscarRDQuinquenal(string asBusValor)
        //{
        //    try
        //    {
        //        CEntidad oCEntidadBusq = new CEntidad();
        //        CLogica exeInf = new CLogica();
        //        oCEntidadBusq.BusFormulario = "LISTAR_INFORMES_RD_EXPADM";
        //        oCEntidadBusq.BusCriterio = "RD_QUINQUENAL";
        //        oCEntidadBusq.BusValor = asBusValor;
        //        List<CEntidad> lisRDQuinquenales = new List<CEntidad>();
        //        lisRDQuinquenales = exeInf.RegMostrarRDQ_Buscar(oCEntidadBusq);
        //        int i = 1;
        //        var result = from r in lisRDQuinquenales
        //                     select new
        //                     {
        //                         ind = i++,
        //                         COD_RESODIREC = r.COD_RESODIREC,
        //                         NUM_RESOLUCION = r.NUMERO_RESOLUCION,
        //                         TIP_FISCALIZA = r.TIPO_FISCALIZA,
        //                         TITULO = r.TITULO_TH,
        //                         RegEstado = 0
        //                     };
        //        var jsonResult = Json(new { data = result, success = true, er = "" }, JsonRequestBehavior.AllowGet);
        //        jsonResult.MaxJsonLength = int.MaxValue;
        //        return jsonResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { data = "", success = false, er = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpGet]
        public ActionResult _BuscarRDQuinquenal()
        {
            return PartialView();
        }
    }
}