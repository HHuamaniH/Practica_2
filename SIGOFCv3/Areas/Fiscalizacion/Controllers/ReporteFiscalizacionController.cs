using CapaEntidad.ViewModel;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad.DOC;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION;
using CLogica = CapaLogica.DOC.Log_REPORTE_FISCALIZACION;
using System.IO;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using CapaEntidad.ViewModel.General;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ReporteFiscalizacionController : Controller
    {
        CLogica oCLogica;

        public ActionResult Index(string lstManMenu)
        {
            string tipoReporte = "";
            CLogica exeCap = new CLogica();

            switch (lstManMenu)
            {
                case "12": tipoReporte = "ARCHIVADOS"; break;
            }

            VM_ReporteFiscalizacion _dto = exeCap.IniDatosReporteFiscalizacion(tipoReporte, (ModelSession.GetSession())[0].COD_UCUENTA);
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Notificaciones");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View(_dto);
        }

        [HttpPost]
        public JsonResult Reporte(VM_ReporteFiscalizacion dto)
        {
            List<CEntidad> olResult = new List<CEntidad>();
            CEntidad paramCap = new CEntidad();
            CLogica exeCap = new CLogica();

            try
            {
                paramCap.BusModalidad = (dto.lstChkModalidadId ?? "").Replace(',', '|');
                paramCap.BusRegion = (dto.lstChkRegionId ?? "").Replace(',', '|');

                olResult = exeCap.LogArchivos(paramCap);

                var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DetalleReporte(VM_ReporteFiscalizacion dto)
        {
            List<CEntidad> olResult = new List<CEntidad>();
            CEntidad paramCap = new CEntidad();
            CLogica exeCap = new CLogica();

            try
            {
                paramCap.BusModalidad = (dto.lstChkModalidadId ?? "").Replace(',', '|');
                paramCap.BusRegion = (dto.lstChkRegionId ?? "").Replace(',', '|');
                paramCap.BusAnio = dto.txtanio;
                paramCap.TIPO_ARCHIVADO = dto.hdfTipoArchivados;

                switch (dto.hdfTipoReporte)
                {
                    case "ARCHIVADOS_DETALLE":
                        olResult = exeCap.LogArchivosDetalle(paramCap);
                        break;
                }

                var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        #region Recursos Impugnatorios

        public ActionResult RecursosImpugnatorios()
        {
            return View();
        }

        public JsonResult RecursosImpugnatorios_Resumen()
        {
            var oCEntidadSupervision = new CEntidad();
            oCEntidadSupervision.BusCriterio = "TOTAL";
            oCLogica = new CLogica();
            var listCEntidad = oCLogica.logListRecursosImpugnatorios(oCEntidadSupervision);
            return Json(listCEntidad, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RecursosImpugnatorios_Detalle(CEntidad oCEntidadSupervision)
        {
            oCLogica = new CLogica();
            var listCEntidad = oCLogica.logListRecursosImpugDetalle(oCEntidadSupervision);
            var json = Json(listCEntidad);
            json.MaxJsonLength = Int32.MaxValue;
            return json;
        }

        [HttpPost]
        public ActionResult RecursosImpugnatorios_Excel(List<Ent_REPORTE_FISCALIZACION> detalle)
        {
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ExportarReporteRecImpugnatorios.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (detalle != null)
                {
                    int column = 0;

                    foreach (var item in detalle)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUMERO_INFTIT;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TIPO_DOCUMENTO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.FECHA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ANIO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULAR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MODALIDAD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUMERO_EXPEDIENTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUMERO_RD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DIAS_TRANSC;
                        rowStart++;
                    }
                }
                string excelName = "ReporteItinerarioSupervision";
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

        #region Notificaciones
        public ActionResult Notificaciones()
        {
            var result = new VM_ReporteFiscalizacion();
            try
            {
                var exeCtrl = new CapaLogica.DOC.Log_ControlCalidad();
                var exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                var exeUbi = new CapaLogica.GENE.Log_UBIGEO();
                result.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text }).ToList();
                result.lstChkRegion = exeUbi.RegMostrarUbigeo("DEPARTAMENTO").ListDepartamento.Select(i => new VM_Chk { Value = i.COD_UBIDEPARTAMENTO, Text = i.DEPARTAMENTO }).ToList();
                ViewBag.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            }
            catch (Exception) { }

            return View(result);
        }

        [HttpPost]
        public JsonResult ExportarNotificaciones(CEntidad oCEntidad)
        {
            ListResult listresult = new ListResult();
            List<CEntidad> olResult = new List<CEntidad>();
            CLogica exeCap = new CLogica();
           // object result = new object();

            string nombreFile = "";
            string directorio = System.Web.HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
            nombreFile = DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() +
                DateTime.Now.Millisecond.ToString() + ".xlsx";


            try
            {
                string nomPlantilla = "NOTIFICACIONES.xlsx";

                FileInfo template = new FileInfo(directorio + nomPlantilla);
                int rowStart = 2;
                using (var package = new ExcelPackage(template))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();

                    olResult = exeCap.ReporteNotificaciones(oCEntidad);
                    int ind = 1;
                    int column = 0;
                    foreach (var itemPart in olResult)
                    {

                        column = 0;

                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ind.ToString();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.FECHA_CREACION;// (itemPart["FECHA_CREACION"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.TIPO_DOCUMENTO;//(itemPart["N_DOC"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.N_DOC;//(itemPart["N_DOC"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.DESTINATARIO;//(itemPart["DESTINATARIO"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.DIRECCION;//(itemPart["DIRECCION"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.FECHA_ADMINISTRADO;//(itemPart["FECHA_ADMINISTRADO"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.FECHA_PRIMERA_VISITA.Length > 1 ? itemPart.FECHA_PRIMERA_VISITA.Split(' ')[0]: string.Empty;//(itemPart["FECHA_PRIMERA_VISITA"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.FECHA_SEGUNDA_VISITA.Length > 1 ? itemPart.FECHA_SEGUNDA_VISITA.Split(' ')[0] : string.Empty;//(itemPart["FECHA_SEGUNDA_VISITA"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.PERSONA_NOT;//(itemPart["PERSONA_NOT"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.VINCULO;//(itemPart["VINCULO"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.DIRECCION_NOT;//(itemPart["DIRECCION_NOT"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.VARIACION_DOMICILIO;//(itemPart["VARIACION_DOMICILIO"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.OD_RESPONSABLE;//(itemPart["OD_RESPONSABLE"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.ESTADO;//(itemPart["ESTADO"] ?? "");
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = itemPart.OBSERVACIONES;//(itemPart["ESTADO"] ?? "");
                        rowStart++;
                        ind++;
                    }

                    package.SaveAs(new FileInfo(directorio + nombreFile));

                    List<string> lstResult = new List<string> { nombreFile };

                    listresult.AddResultado("Ok", true, lstResult);

                }
            }
            catch (Exception ex)
            {
                listresult.AddResultado(ex.Message, false);

            }
           
            return Json(listresult);

           
        }
        


        #endregion

        #region Reporte de Titulares con Sanción y/o Caducidad

        public ActionResult TitularesSancionCaducidad()
        {
            var result = new VM_ReporteFiscalizacion();
            try
            {
                var exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                var exeUbi = new CapaLogica.GENE.Log_UBIGEO();
                result.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text }).ToList();
                result.lstChkRegion = exeUbi.RegMostrarUbigeo("DEPARTAMENTO").ListDepartamento.Select(i => new VM_Chk { Value = i.COD_UBIDEPARTAMENTO, Text = i.DEPARTAMENTO }).ToList();
            }
            catch (Exception) { }

            return View(result);
        }

        [HttpPost]
        public JsonResult TitularesSancionCaducidad_Resumen(string modalidad, string region)
        {
            oCLogica = new CLogica();
            CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION entidad = new CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION();
            entidad.BusRegion = region;
            entidad.BusModalidad = modalidad;
            var result = oCLogica.Log_Caducidad(entidad).ListGeneral.OrderBy(x => x.DEPARTAMENTO).ToList();

            return Json(result);
        }

        [HttpPost]
        public JsonResult TitularesSancionCaducidad_Detalle(string modalidad, string region, string departamento)
        {
            oCLogica = new CLogica();
            CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION entidad = new CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION();
            entidad.BusRegion = region;
            entidad.BusModalidad = modalidad;
            entidad.DEPARTAMENTO = departamento;
            var result = oCLogica.Log_CaducidadDetalle(entidad);

            var json = Json(result);
            json.MaxJsonLength = Int32.MaxValue;
            return json;
        }

        [HttpPost]
        public ActionResult TitularesSancionCaducidad_Excel(List<Ent_REPORTE_FISCALIZACION> detalle)
        {
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteDetalleCaducidad.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (detalle != null)
                {
                    int column = 0;

                    foreach (var item in detalle)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULAR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TH_NUMERO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MODALIDAD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULAR_SANCIONADO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDCADUCA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CADUCIDAD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDCADUCA_PUBLICAR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDRECONSIDERA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDRECONSIDERA_PUBLICAR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PROVEIDO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PROVEIDO_FECHA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RTFFS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RTFFS_PUBLICAR;
                        rowStart++;
                    }
                }
                string excelName = "ReporteDetalleCaducidad";
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

        #region Documentos Presentados por el Titular

        public ActionResult DocumentosTitular()
        {
            var result = new VM_ReporteFiscalizacion();
            try
            {
                var exeCtrl = new CapaLogica.DOC.Log_ControlCalidad();
                var exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                var exeUbi = new CapaLogica.GENE.Log_UBIGEO();
                result.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text }).ToList();
                result.lstChkRegion = exeUbi.RegMostrarUbigeo("DEPARTAMENTO").ListDepartamento.Select(i => new VM_Chk { Value = i.COD_UBIDEPARTAMENTO, Text = i.DEPARTAMENTO }).ToList();
                ViewBag.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            }
            catch (Exception) { }

            return View(result);
        }

        [HttpPost]
        public JsonResult DocumentosTitular_Resumen(string anios, string modalidad, string region, string OD)
        {
            var oCampos = new CEntidad();
            oCampos.BusCriterio = "01";
            oCampos.BusValor = OD;
            oCampos.BusAnio = anios;
            oCampos.BusRegion = region;
            oCampos.BusModalidad = modalidad;
            oCLogica = new CLogica();
            var result = oCLogica.logListDocumentosTH(oCampos);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Notificaciones_Resumen(string anios, string modalidad, string region, string OD)
        {
            var oCampos = new CEntidad();
            oCampos.BusCriterio = "01";
            oCampos.BusValor = OD;
            oCampos.BusAnio = anios;
            oCampos.BusRegion = region;
            oCampos.BusModalidad = modalidad;
            oCLogica = new CLogica();
            //var result = oCLogica.logListDocumentosTH(oCampos);
            var result = oCLogica.logListNotificaciones(oCampos);
            return Json(result);
        }

        [HttpPost]
        public JsonResult DocumentosTitular_Detalle(string anios, string tipo, string modalidad, string region, string OD)
        {
            var oCampos = new CEntidad();
            oCampos.BusCriterio = "02";
            oCampos.BusValor = OD;
            oCampos.BusTipo = tipo;
            oCampos.BusAnio = anios;
            oCampos.BusRegion = region;
            oCampos.BusModalidad = modalidad;
            oCLogica = new CLogica();
            var result = oCLogica.logListDocumentosTHDetalle(oCampos);
            return Json(result);
        }

        #endregion

        #region Medidas cautelares o provisiorias

        public ActionResult MedidasCautelares()
        {
            var result = new VM_ReporteFiscalizacion();
            try
            {
                var exeCtrl = new CapaLogica.DOC.Log_ControlCalidad();
                var exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                var exeUbi = new CapaLogica.GENE.Log_UBIGEO();
                result.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text }).ToList();
                result.lstChkRegion = exeUbi.RegMostrarUbigeo("DEPARTAMENTO").ListDepartamento.Select(i => new VM_Chk { Value = i.COD_UBIDEPARTAMENTO, Text = i.DEPARTAMENTO }).ToList();
            }
            catch (Exception) { }

            return View(result);
        }

        [HttpPost]
        public JsonResult MedidasCautelares_Resumen(string modalidad, string region)
        {
            var oCampos = new CEntidad();
            oCampos.BusRegion = region;
            oCampos.BusModalidad = modalidad;
            oCLogica = new CLogica();
            var result = oCLogica.LogMedidasCautelares(oCampos);
            return Json(result.ListGeneral);
        }

        [HttpPost]
        public JsonResult MedidasCautelares_Detalle(string modalidad, string region, string departamento, string criterio)
        {
            var oCampos = new CEntidad();
            oCampos.BusRegion = region;
            oCampos.BusModalidad = modalidad;
            oCampos.DEPARTAMENTO = departamento;
            oCampos.BusCriterio = criterio; //MEDCAU_PAU | MEDPRECAU_PAU
            oCLogica = new CLogica();
            var result = oCLogica.LogDetMedidasCautelares(oCampos);
            var json = Json(result);
            json.MaxJsonLength = Int32.MaxValue;
            return json;
        }

        [HttpPost]
        public ActionResult MedidasCautelares_Excel(string criterio, List<Ent_REPORTE_FISCALIZACION> detalle)
        {
            string file = "ReporteDetalleMedidasCautelares";
            if (criterio == "MEDPRECAU_PAU") file = "ReporteDetalleMedidasPrecautorias";

            FileInfo template = new FileInfo(Server.MapPath(string.Format("~/Archivos/Plantilla/{0}.xlsx", file)));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (detalle != null)
                {
                    int column = 0;

                    foreach (var item in detalle)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULAR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.THABILITANTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MODALIDAD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULAR_SANCIONADO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDMEDIDAS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.FECHA_EMISION;

                        if (criterio == "MEDPRECAU_PAU")
                        {
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDRECONSIDERA;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RDRECONSIDERA_PUBLICAR;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.REC_APELACION;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RTFFS;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.RTFFS_PUBLICAR;
                        }

                        rowStart++;
                    }
                }
                string excelName = "ReporteMedidasCautelares";
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

    }
}