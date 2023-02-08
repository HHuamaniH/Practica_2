using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_GENERAL;
using CEntidadR = CapaEntidad.DOC.Ent_RESODIREC;
using CLogica = CapaLogica.DOC.Log_REPORTE_GENERAL;
using CLogicaR = CapaLogica.DOC.Log_RESODIREC;
using VM = CapaEntidad.ViewModel.VM_ReporteGeneral;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ReportesController : Controller
    {
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        EpplusExcel epplus = new EpplusExcel();

        [HttpGet]
        public ActionResult Reporte(string _idTipoReporte)
        {
            string tipoReporte = "";
            CLogica exeRpt = new CLogica();

            switch (_idTipoReporte)
            {
                case "0": tipoReporte = "SABANA_INFORME"; break;
                case "1": tipoReporte = "SABANA_PLAN_MANEJO"; break;
                default: tipoReporte = "SABANA_INFORME"; break;
            }


            VM _dto = exeRpt.InitReporteGeneral(tipoReporte);

            return View(_dto);
        }
        [HttpPost]
        public JsonResult Reporte(VM dto)
        {
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            CEntidad paramRpt = new CEntidad();
            CLogica exeRpt = new CLogica();

            try
            {
                paramRpt.TIPO_REPORTE = dto.hdfTipoReporte;
                paramRpt.ANIO = (dto.lstChkAnioId ?? "").Replace(',', '|');
                paramRpt.COD_OD = (dto.lstChkOdId ?? "").Replace(';', '|');
                paramRpt.COD_MTIPO = (dto.lstChkModalidadId ?? "").Replace(',', '|');
                paramRpt.COD_DPTO = (dto.lstChkDepartamentoId ?? "").Replace(',', '|');
                paramRpt.COD_DLINEA = (dto.lstChkDLineaId ?? "").Replace(',', '|');

                olResult = exeRpt.ReporteGeneral(paramRpt);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public ActionResult ReporteMandatos()
        {
            ViewBag.Formulario = "REPORTE_MANDATO";
            ViewBag.TituloFormulario = "Listado";
            return View();
        }

        public ActionResult MedidasCorrectivas()
        {
            ViewBag.Formulario = "REPORTE_MEDIDA_CORRECTIVA";
            ViewBag.TituloFormulario = "Listado de Medidas Correctivas";
            return View();
        }

        public ActionResult ReporteTitularResumen()
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            VM_ReporteTitularResumen rpte = new VM_ReporteTitularResumen();
            List<VM_Chk> lstChkItem;

            rpte.lstChkUbicacion = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            rpte.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            rpte.lstChkDLinea = exeBus.RegMostComboIndividual("DLINEA", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            rpte.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

            lstChkItem = new List<VM_Chk>();
            for (int i = DateTime.Now.Year; i >= 2005; i--)
            {
                lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
            }
            rpte.lstChkAnioSuperv = lstChkItem;
            rpte.lstChkAnioRDTermino = lstChkItem;
            rpte.lstChkAnioProveido = lstChkItem;
            rpte.lstChkAnioFirmeza = lstChkItem;

            lstChkItem = new List<VM_Chk>() {
                        new VM_Chk() { Value="1",Text="Enero" },new VM_Chk() { Value="2",Text="Febrero" },new VM_Chk() { Value="3",Text="Marzo" },
                        new VM_Chk() { Value="4",Text="Abril" },new VM_Chk() { Value="5",Text="Mayo" },new VM_Chk() { Value="6",Text="Junio" },
                        new VM_Chk() { Value="7",Text="Julio" },new VM_Chk() { Value="8",Text="Agosto" },new VM_Chk() { Value="9",Text="Septiembre" },
                        new VM_Chk() { Value="10",Text="Octubre" },new VM_Chk() { Value="11",Text="Noviembre" },new VM_Chk() { Value="12",Text="Diciembre" }
                    };
            rpte.lstChkMesRDTermino = lstChkItem;

            rpte.ddlFiltroAdicional = exeBus.RegMostComboIndividual("REPORTE_TITULAR_RESUMEN", "");

            return View(rpte);
        }

        [HttpPost]
        public JsonResult ReporteTitularResumen(VM_ReporteTitularResumen vm)
        {
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            CLogica exeRpt = new CLogica();

            try
            {
                olResult = exeRpt.ReporteTitularResumen(vm);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        #region EXCEL
        [HttpPost]
        public JsonResult ExportarTablaCorrectivas(CEntidadR dto)
        {
            string nombre_reporte = "Reporte_MCorrectiva";
            ListResult result = new ListResult();
            try
            {
                CLogicaR exeInf = new CLogicaR();
                List<CEntidadR> dataList = new List<CEntidadR>(); //CLHC: exeInf.SP_SELECT_MEDIDAS_CORRECTIVAS(dto);

                string nombre = string.Empty;
                using (var excelPackage = new ExcelPackage())
                {
                    string OCLfolder = AppDomain.CurrentDomain.BaseDirectory + "Archivos/MCorrectivas/";
                    nombre = nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
                    string savepath = OCLfolder + "/" + nombre;

                    System.IO.FileInfo strfilePath = new System.IO.FileInfo(savepath);
                    excelPackage.Workbook.Properties.Author = nombre_reporte;
                    excelPackage.Workbook.Properties.Title = nombre_reporte;
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte);
                    _genericSheet.View.ZoomScale = 100;
                    List<string> _cabecera = new List<string>
                    {
                        "NUMERO_RESOLUCION",
                        "NUMEROS_EXPEDIENTES",
                        "DESCRIPCION_MED_CORRECTIVAS",
                        "DESDE",
                        "HASTA",
                        "HASTAFIN",
                        "HASTA_INF",
                        "HASTAFIN_INF"
                    };
                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, nombre_reporte);
                    _genericSheet.Cells["A3:H3"].AutoFilter = true;
                    int rowIndex = 4;
                    foreach (var itemPart in dataList)
                    {
                        int col = 1;
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.NUMERO_RESOLUCION ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.NUMERO_EXPEDIENTE ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.DESCRIPCION_MED_CORRECTIVAS ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHA_INI ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHA_FIN ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHA_FIN2 ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHAINF_FIN ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHAINF_FIN2 ?? string.Empty);
                        rowIndex++;
                    }

                    _genericSheet.View.FreezePanes(4, 2);
                    byte[] bin = excelPackage.GetAsByteArray();
                    strfilePath.Directory.Create();
                    System.IO.File.WriteAllBytes(savepath, bin);
                }

                result.success = true;
                result.msj = nombre;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult ExportarTablaMandato(CEntidadR dto)
        {
            string nombre_reporte = "Reporte_Mandato";
            ListResult result = new ListResult();
            try
            {
                CLogicaR exeInf = new CLogicaR();
                List<CEntidadR> result1 = new List<CEntidadR>(); //CLHC: exeInf.SP_SELECT_MANDATOS(dto);


                string nombre = string.Empty;
                using (var excelPackage = new ExcelPackage())
                {
                    string OCLfolder = AppDomain.CurrentDomain.BaseDirectory + "Archivos/Mandato/";
                    nombre = nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
                    string savepath = OCLfolder + "/" + nombre;

                    System.IO.FileInfo strfilePath = new System.IO.FileInfo(savepath);
                    excelPackage.Workbook.Properties.Author = nombre_reporte;
                    excelPackage.Workbook.Properties.Title = nombre_reporte;
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte);
                    _genericSheet.View.ZoomScale = 100;
                    List<string> _cabecera = new List<string>
                    {
                        "NUMERO_RESOLUCION",
                        "NUMEROS_EXPEDIENTES",
                        "Mandato",
                        "DESDE",
                        "HASTA"
                    };
                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, nombre_reporte);
                    _genericSheet.Cells["A3:E3"].AutoFilter = true;
                    int rowIndex = 4;
                    foreach (var itemPart in result1)
                    {
                        int col = 1;
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.NUMERO_RESOLUCION ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.NUMERO_EXPEDIENTE ?? string.Empty);
                        //CLHC: epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.MANDATO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHA_INI ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHA_FIN ?? string.Empty);
                        rowIndex++;
                    }

                    _genericSheet.View.FreezePanes(4, 2);
                    byte[] bin = excelPackage.GetAsByteArray();
                    strfilePath.Directory.Create();
                    System.IO.File.WriteAllBytes(savepath, bin);
                }

                result.success = true;
                result.msj = nombre;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return Json(result);
        }

        public ActionResult DownloadMandato(string asCriterio, string asValor)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;

            paramsBus.BusFormulario = "REPORTE_MANDATO";
            paramsBus.BusCriterio = asCriterio;
            paramsBus.BusValor = asValor;
            paramsBus.pagesize = 10000;
            paramsBus.currentpage = 1;

            lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Mandato/Plantilla_Mandato.xlsx"));
            int rowStart = 4;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item["NUM_RESOLUCION"];
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item["NUM_EXPEDIENTE"];
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item["TITULAR"];
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item["MODALIDAD"];
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item["MEDIDA"];
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item["PLAZO_IMPL_DIA"];
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item["PLAZO_IMPL_MES"];
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item["PLAZO_INF_DIA"];
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item["PLAZO_INF_MES"];

                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A4:K" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteMandato";
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

        public ActionResult DownloadCorrectiva(string asCriterio, string asValor)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;

            paramsBus.BusFormulario = "REPORTE_MEDIDA_CORRECTIVA";
            paramsBus.BusCriterio = asCriterio;
            paramsBus.BusValor = asValor;
            paramsBus.pagesize = 10000;
            paramsBus.currentpage = 1;

            lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/MCorrectivas/Plantilla_MCorrectiva.xlsx"));
            int rowStart = 4;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item["NUM_RESOLUCION"];
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item["NUM_EXPEDIENTE"];
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item["TITULAR"];
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item["MODALIDAD"];
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item["MEDIDA"];
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item["PLAZO_IMPL_DIA"];
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item["PLAZO_IMPL_MES"];
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item["PLAZO_IMPL_ANIO"];
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item["PLAZO_POST_DIA"];
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item["PLAZO_POST_MES"];
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item["PLAZO_POST_ANIO"];
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item["PLAZO_INF_DIA"];
                        worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = item["PLAZO_INF_MES"];
                        worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = item["PLAZO_INF_ANIO"];

                        rowStart = rowStart + 1;
                    }

                    string modelRange = "A4:P" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                string excelName = "ReporteMedidaCorrectiva";
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
        #endregion

        public ActionResult SupervisioneSegunOportunidad()
        {
           
            VM_ReporteInformacion model = new VM_ReporteInformacion();

            String Parametros = "6|1|1|0|1|0|0|1|0";
            if (Parametros.Split('|').Length == 10) { Parametros += "|0"; }
            else if (Parametros.Split('|').Length == 9) { Parametros += "|0|0"; }
            else if (Parametros.Split('|').Length == 8) { Parametros += "|0|0|0"; }

            Ent_MasterFiltro oCampos = new Ent_MasterFiltro();
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            oCampos.BusValor = Parametros;
            oCampos = oCLogica.RegMostFiltro(oCampos);

            model.lstChkAnio = oCampos.ListAnios.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkOd = oCampos.ListOD.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkModalidad = oCampos.ListModalidad.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkRegion = oCampos.ListRegion.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkSubDireccion = oCampos.ListDLinea.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            Session["ListReporteResumen"] = null;
            Session["ListReporteDetalle"] = null;
            return View(model);
        }
        [HttpPost]
        public PartialViewResult _SupervisioneSegunOportunidadResumen(VM_ReporteInformacion dto)
        {
            Ent_REPORTE_ISUPERVISION oParamsReporte = new Ent_REPORTE_ISUPERVISION();
            Log_REPORTE_ISUPERVISION oLogReporte = new Log_REPORTE_ISUPERVISION();

            oParamsReporte.Busanio = (dto.lstChkAnioId ?? "").Replace(',', '|');
            oParamsReporte.BusDLinea = (dto.lstChkSubDireccionId ?? "").Replace(',', '|');
            oParamsReporte.BusModalidad = (dto.lstChkModalidadId ?? "").Replace(',', '|');
            oParamsReporte.BusOD = (dto.lstChkOdId ?? "").Replace(',', '|');
            oParamsReporte.BusRegion = (dto.lstChkRegionId ?? "").Replace(',', '|');
            List<Ent_REPORTE_ISUPERVISION> olReporteResumen = oLogReporte.MostrarOportunidadSupervisiones_Resumen(oParamsReporte);
            Session["ListReporteResumen"] = olReporteResumen;

            ViewBag.Busanio = oParamsReporte.Busanio;
            ViewBag.BusDLinea= oParamsReporte.BusDLinea;
            ViewBag.BusModalidad= oParamsReporte.BusModalidad;
            ViewBag.BusOD = oParamsReporte.BusOD;
            ViewBag.BusRegion= oParamsReporte.BusRegion;

            return PartialView(olReporteResumen);
        }
        [HttpGet]
        public JsonResult ListReporteResumenOportunidad()
        {
            List<Ent_REPORTE_ISUPERVISION> olReporteResumen;

            try
            {
                olReporteResumen = (List<Ent_REPORTE_ISUPERVISION>)Session["ListReporteResumen"];
              
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = "",
                    success = false,
                    msj = ex.Message
                });
            }
            var jsonResult = Json(new
            {
                data = olReporteResumen,
                success = true,
                msj = ""
            },JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public PartialViewResult _SupervisioneSegunOportunidadDetalle(string Busanio,string BusDLinea,string BusModalidad,string BusOD,string BusRegion,string cod)
        {
            Ent_REPORTE_ISUPERVISION oParamsReporte = new Ent_REPORTE_ISUPERVISION();
            Log_REPORTE_ISUPERVISION oLogReporte = new Log_REPORTE_ISUPERVISION();
            string cod_mes = cod.Split('|')[0];
            string cod_est_aprovecha = cod.Split('|')[1];
            cod_mes = cod_mes == "" ? "TODOS" : cod_mes;
            cod_est_aprovecha = cod_est_aprovecha == "" ? "TODOS" : cod_est_aprovecha;

            oParamsReporte.Busanio = Busanio;
            oParamsReporte.BusDLinea = BusDLinea;
            oParamsReporte.BusModalidad = BusModalidad;
            oParamsReporte.BusOD = BusOD;
            oParamsReporte.BusRegion = BusRegion;
            oParamsReporte.MAE_EST_APROVECHA = cod_est_aprovecha;
            oParamsReporte.COD_MES = cod_mes;

            List<Ent_REPORTE_ISUPERVISION> olDetalle = oLogReporte.MostrarOportunidadSupervisiones_Detalle(oParamsReporte);
            Session["ListReporteDetalle"] = olDetalle;

            return PartialView(olDetalle);

        }
        public ActionResult ReporteOportunidadDetalle()
        {
            List<Ent_REPORTE_ISUPERVISION> lstResult;
            lstResult =(List<Ent_REPORTE_ISUPERVISION>)Session["ListReporteDetalle"];

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteSupervisioneSegunOportunidad.xlsx"));
            int rowStart = 2;
            //int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = item.NUM_INFORME;                       
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.POA;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.FECHA_APRUEBA_POA.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.FECHA_APRUEBA_POA);
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.INICIO_VIGENCIA.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.INICIO_VIGENCIA);
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.FIN_VIGENCIA.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.FIN_VIGENCIA);
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.NUM_THABILITANTE;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.TITULAR;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.ANIO;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.MES;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.DLINEA;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.MTIPO;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.OD;
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item.EST_APROVECHA;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:N" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteOportunidadDet";
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
    }
}