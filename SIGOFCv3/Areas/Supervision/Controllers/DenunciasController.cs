using CapaEntidad.DOC;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_Denuncia;
using IDENUNCIA = CapaEntidad.DOC.IDENUNCIA;
using ListResult = CapaEntidad.ViewModel.ListResult;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class DenunciasController : Controller
    {
        // GET: Supervision/Denuncias
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        EpplusExcel epplus = new EpplusExcel();

        #region VISTAS
        public ActionResult IndexDenuncia()
        {
            ViewBag.Formulario = "TRAMITES_DENUNCIA";
            ViewBag.TituloFormulario = "Listado";
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Mantenimiento de Denuncia/Peticiones");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        public ActionResult TramiteDenuncia(string iCodTramite, string cCodificacion, string iCodTupa, string iCodTupaClase, string Destino, Tra_M_Tramite tramite)
        {
            ViewBag.iCodTramite = iCodTramite;
            ViewBag.cCodificacion = cCodificacion;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Mantenimiento de Denuncia/Peticiones");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            ViewBag.iCodTupa = iCodTupa;
            ViewBag.iCodTupaClase = iCodTupaClase;
            ViewBag.Destino = Destino;
            ViewBag.Tramite = tramite;
            return View(tramite);
        }
        [HttpGet]
        public ActionResult modalDocInforme()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult modalTHabilitante()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult modalInformesSITD()
        {
            return PartialView();
        }
        public ActionResult reporteDenuncia()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _ItemNuevo()
        {
            return PartialView();
        }
        public ActionResult VistaDenuncia(string id, Tra_M_Tramite tramite)
        {
            var data = id.Split(new[] { "_____" }, StringSplitOptions.None);
            ViewBag.cCodificacion = data[0];
            ViewBag.iCodTramite = data[1];
            ViewBag.iCodTupa = data[2];
            ViewBag.iCodTupaClase = data[3];
            //ViewBag.iCodTramite = data[2];
            return View(tramite);
        }
        #endregion

        #region EXCEL
        [HttpPost]
        public JsonResult ExportarTabla()
        {
            string nombre_reporte = "Reporte_Denuncia";
            ListResult result = new ListResult();
            try
            {
                IDENUNCIA paramCap = new IDENUNCIA();
                CLogica exeCap = new CLogica();
                List<IDENUNCIA> olResult = exeCap.exportarDenuncias();
                string nombre = string.Empty;
                using (var excelPackage = new ExcelPackage())
                {
                    string OCLfolder = AppDomain.CurrentDomain.BaseDirectory + "Archivos/Denuncia/";
                    nombre = nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
                    string savepath = OCLfolder + "/" + nombre;

                    System.IO.FileInfo strfilePath = new System.IO.FileInfo(savepath);
                    excelPackage.Workbook.Properties.Author = nombre_reporte;
                    excelPackage.Workbook.Properties.Title = nombre_reporte;
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte);
                    _genericSheet.View.ZoomScale = 100;
                    List<string> _cabecera = new List<string>
                    {
                        "N° TRAMITE",
                        "AÑO DOCUMENTO",
                        "FECHA DOCUMENTO",
                        "TRABAJADOR REGISTRO",
                        "TIPO DOC",
                        "N° DOC",
                        "REMITENTE",
                        "ASUNTO",
                        "TIPO DE REQUERIMIENTO",
                        "ESTADO",
                        "SUB ESTADO",
                        "INFORME DE SUPERVISION",
                        "INFORMES TECNICOS",
                        "ARCHIVOS AUDITORIA",
                        "T. HABILITANTE"
                    };
                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, nombre_reporte);
                    _genericSheet.Cells["A3:N3"].AutoFilter = true;
                    int rowIndex = 4;
                    foreach (var itemPart in olResult)
                    {
                        int col = 1;
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.cCodificacion ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.iAnio.ToString() ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.fFecDocumento ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.vTrabajador ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.cDescTipoDoc ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.cNroDocumento ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.cNombre ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.tra_M_Tramite.cAsunto ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.TIPO_REQUERIMIENTO + (itemPart.TIPO_REQUERIMIENTO == "Otro" ? " (" + itemPart.TIPO_REQUERIMIENTO + ")" : ""));
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.NOMBRE_DEPENDENCIA ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.TIPO_TRASLADO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.ENT_INFORME.NUMERO);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.Informes);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.Auditoria);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.THabilitante);
                        rowIndex++;
                    }
                    _genericSheet.Column(1).Width = 12.40;
                    _genericSheet.Column(2).Width = 5.40;
                    _genericSheet.Column(3).Width = 12.80;
                    _genericSheet.Column(4).Width = 43.60;
                    _genericSheet.Column(5).Width = 16.80;
                    _genericSheet.Column(6).Width = 15.30;
                    _genericSheet.Column(7).Width = 34;
                    _genericSheet.Column(8).Width = 41.80;
                    _genericSheet.Column(9).Width = 17;
                    _genericSheet.Column(10).Width = 14;
                    _genericSheet.Column(11).Width = 25;
                    _genericSheet.Column(12).Width = 26.15;
                    _genericSheet.Column(13).Width = 44.50;

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
        public JsonResult ExportarTablaGrl()
        {
            string nombre_reporte = "Reporte_Denuncia";
            ListResult result = new ListResult();
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            try
            {
                IDENUNCIA paramCap = new IDENUNCIA();
                CLogica exeCap = new CLogica();
                // List<IDENUNCIA> olResult = exeCap.exportarDenuncias();
                olResult = exeCap.exportarDenunciasGrl();

                string nombre = string.Empty;
                using (var excelPackage = new ExcelPackage())
                {
                    string OCLfolder = AppDomain.CurrentDomain.BaseDirectory + "Archivos/Denuncia/";
                    nombre = nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
                    string savepath = OCLfolder + "/" + nombre;

                    System.IO.FileInfo strfilePath = new System.IO.FileInfo(savepath);
                    excelPackage.Workbook.Properties.Author = nombre_reporte;
                    excelPackage.Workbook.Properties.Title = nombre_reporte;
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte);
                    _genericSheet.View.ZoomScale = 100;
                    List<string> _cabecera = new List<string>
                    {
                        "N° TRAMITE",
                        "AÑO DOCUMENTO",
                        "FECHA DOCUMENTO",
                        "NOMBRE TUPA",
                        "NOMBRE TUPA CLASE",
                        "TRABAJADOR REGISTRO",
                        "TIPO DOC",
                        "N° DOC",
                        "REMITENTE",
                        "ASUNTO",
                        "TIPO DE REQUERIMIENTO",
                        "ESTADO",
                        "SUB ESTADO",
                        "INFORME DE SUPERVISION",
                        "NOTIFICACION",
                        "FECHA DE SUPERVISIÓN INICIO",
                        "FECHA DE SUPERVISIÓN FIN",
                        "MODALIDAD",
                        "DEPARTAMENTO",
                        "PROVINCIA",
                        "DISTRITO",
                         "D LINEA",
                         "ESTHABILITANTE",
                        "NUMERO THABILITANTE",
                        "TITULAR",
                        "AREA DEL THABILITANTE",
                        "POA",
                        "AREA POA",
                        "N° ARBOLES POA",
                        "VOLUMEN POA",
                        "DOC SITD",
                        "DOC ADICIONALES",
                        "DESTINO",
                        "OFICINA"
                    };
                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, nombre_reporte);
                    _genericSheet.Cells["A3:AH3"].AutoFilter = true;
                    int rowIndex = 4;
                    foreach (var itemPart in olResult)
                    {
                        int col = 1;
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cCodificacion"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["IANIO"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["fFecDocumento"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cNomTupa"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cNomTupaClase"] ?? string.Empty);

                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["vTrabajador"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cDescTipoDoc"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cNroDocumento"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cNombre"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cAsunto"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["TIPO_REQUERIMIENTO"] + (itemPart["TIPO_REQUERIMIENTO"] == "Otro" ? " (" + itemPart["TIPO_REQUERIMIENTO"] + ")" : ""));
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NOMBRE_DEPENDENCIA"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["TIPO_TRASLADO"] ?? string.Empty);
                     epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUMEROINFORME"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUM_CNOTIFICACION"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["FECHA_SUPERVISION_INICIO"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["FECHA_SUPERVISION_FIN"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["MODALIDAD_TIPO"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["DEPARTAMENTO"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["PROVINCIA"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["DISTRITO"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["D_LINEA"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, (itemPart["ES_THABILITANTE"]=="1"?"SI": (itemPart["ES_THABILITANTE"] == "0" ? " " : "NO")));
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUM_THABILITANTE"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["TITULAR"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, (itemPart["AREA_THABILITANTE"] == "0" ?" ": itemPart["AREA_THABILITANTE"]));
                        if (itemPart["NUM_POA"] == "0")
                        {
                            epplus._texto_row(_genericSheet, rowIndex, col++, "");
                            epplus._texto_row(_genericSheet, rowIndex, col++, "");
                            epplus._texto_row(_genericSheet, rowIndex, col++, "");
                            epplus._texto_row(_genericSheet, rowIndex, col++, "");
                        }
                        else
                        {
                            epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["POA"]);
                            epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["AREA"]);
                            epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUM_ARBOLES"]);
                            epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["VOLUMEN"]);
                        }

                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["DESCP_SITD"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NOMBRE_ARCH_AD"]);
                        
                        //epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["Auditoria"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["Destino"]);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["cNomOficina"]);



                        rowIndex++;
                    }
                    _genericSheet.Column(1).Width = 12.40;
                    _genericSheet.Column(2).Width = 5.40;
                    _genericSheet.Column(3).Width = 12.80;
                    _genericSheet.Column(4).Width = 43.60;
                    _genericSheet.Column(5).Width = 16.80;
                    _genericSheet.Column(6).Width = 15.30;
                    _genericSheet.Column(7).Width = 34;
                    _genericSheet.Column(8).Width = 41.80;
                    _genericSheet.Column(9).Width = 17;
                    _genericSheet.Column(10).Width = 14;
                    _genericSheet.Column(11).Width = 25;
                    _genericSheet.Column(12).Width = 26.15;
                    _genericSheet.Column(13).Width = 44.50;
                    _genericSheet.Column(14).Width = 26.15;
                    _genericSheet.Column(15).Width = 26.15;
                    _genericSheet.Column(16).Width = 26.15;
                    _genericSheet.Column(17).Width = 26.15;
                    _genericSheet.Column(18).Width = 26.15;
                    _genericSheet.Column(19).Width = 26.15;
                    _genericSheet.Column(20).Width = 26.15;
                    _genericSheet.Column(21).Width = 26.15;
                    _genericSheet.Column(22).Width = 26.15;
                    _genericSheet.Column(23).Width = 26.15;
                    _genericSheet.Column(24).Width = 26.15;
                    _genericSheet.Column(25).Width = 26.15;
                    _genericSheet.Column(26).Width = 26.15;
                    _genericSheet.Column(27).Width = 26.15;
                    _genericSheet.Column(28).Width = 26.15;
                    _genericSheet.Column(29).Width = 26.15;
                    _genericSheet.Column(30).Width = 26.15;
                    _genericSheet.Column(31).Width = 26.15;
                    _genericSheet.Column(32).Width = 26.15;
                    _genericSheet.Column(32).Width = 26.15;
                    _genericSheet.Column(32).Width = 26.15;
                    _genericSheet.Column(33).Width = 40;
                    _genericSheet.Column(34).Width = 40;


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
        public JsonResult ExportarTablaIncidencia(IINCIDENCIA i)
        {
            string nombre_reporte = "Reporte_Incidencia";
            List<IINCIDENCIA> olResult = new List<IINCIDENCIA>();
            ListResult result = new ListResult();
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.crudIncidencias(i);
                string nombre = string.Empty;
                using (var excelPackage = new ExcelPackage())
                {
                    string OCLfolder = AppDomain.CurrentDomain.BaseDirectory + "Archivos/Incidencia/";
                    nombre = nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
                    string savepath = OCLfolder + "/" + nombre;
                    System.IO.FileInfo strfilePath = new System.IO.FileInfo(savepath);
                    excelPackage.Workbook.Properties.Author = nombre_reporte;
                    excelPackage.Workbook.Properties.Title = nombre_reporte;
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte);
                    _genericSheet.View.ZoomScale = 100;
                    List<string> _cabecera = new List<string>
                    {
                        "#",
                        "FECHA",
                        "HORA",
                        "RIESGO",
                        "PROCESO",
                        "CIRCUNSTANCIA",
                        "UBICACION",
                        "EFECTO",
                        "NIVEL 1",
                        "NIVEL 2",
                        "INCIDENCIA",
                        "OBSERVACIONES"
                    };
                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, nombre_reporte);
                    _genericSheet.Cells["A3:L3"].AutoFilter = true;
                    int rowIndex = 4;
                    int cont = 1;
                    foreach (var itemPart in olResult)
                    {
                        int col = 1;
                        epplus._texto_row(_genericSheet, rowIndex, col++, cont.ToString() ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.FECHA_SUCESO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.HORA_SUCESO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO.NOMBRE_PROTOCOLO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO.NOMBRE_PROTOCOLO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA.NOMBRE_PROTOCOLO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.UBICACION ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO.NOMBRE_PROTOCOLO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_1.NOMBRE_PROTOCOLO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_2.NOMBRE_PROTOCOLO ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.DSCRP_INCIDENCIA ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart.OBSERVACIONES ?? string.Empty);
                        rowIndex++;
                        cont++;
                    }

                    _genericSheet.Column(1).Width = 6;
                    _genericSheet.Column(2).Width = 11.14;
                    _genericSheet.Column(3).Width = 10.57;
                    _genericSheet.Column(4).Width = 35;
                    _genericSheet.Column(5).Width = 19.71;
                    _genericSheet.Column(6).Width = 31.43;
                    _genericSheet.Column(7).Width = 23.43;
                    _genericSheet.Column(8).Width = 35;
                    _genericSheet.Column(9).Width = 20;
                    _genericSheet.Column(10).Width = 20;
                    _genericSheet.Column(11).Width = 20;
                    _genericSheet.Column(11).Width = 20;
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
        #endregion

        #region METODOS
        [HttpPost]
        public JsonResult SubirArchivo()
        {
            Archivo archivo = new Archivo();
            try
            {
                if (Request.Files.Count > 0)
                {
                    archivo.ID = Int32.Parse(Path.GetFileName(Request.Files[0].FileName).Split(new[] { "__" }, StringSplitOptions.None).FirstOrDefault());
                    archivo.Archivos = new List<IDENUNCIA_ITECNICO_ARCHIVOS>();
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\Denuncia\", fileName);
                            file.SaveAs(path);
                            path = path.Split(new[] { AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\Denuncia\" }, StringSplitOptions.None).Last();
                            IDENUNCIA_ITECNICO_ARCHIVOS ar = new IDENUNCIA_ITECNICO_ARCHIVOS();
                            ar.URL_TECNICO = path;
                            ar.ARCHIVO_EXTENSION = file.ContentType;
                            ar.NOMBRE_ARCHIVO = file.FileName.Split(new[] { "__" }, StringSplitOptions.None).LastOrDefault();
                            archivo.Archivos.Add(ar);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return Json(archivo);
        }
        [HttpPost]
        public JsonResult SubirArchivosDenuncia()
        {
            Archivo archivo = new Archivo();
            try
            {
                if (Request.Files.Count > 0)
                {
                    archivo.ID = Int32.Parse(Path.GetFileName(Request.Files[0].FileName).Split(new[] { "__" }, StringSplitOptions.None).FirstOrDefault());
                    archivo.Archivos = new List<IDENUNCIA_ITECNICO_ARCHIVOS>();
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\Denuncia\", fileName);
                            file.SaveAs(path);
                            path = path.Split(new[] { AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\Denuncia\" }, StringSplitOptions.None).Last();
                            IDENUNCIA_ITECNICO_ARCHIVOS ar = new IDENUNCIA_ITECNICO_ARCHIVOS();
                            ar.COD_COD_IDENUNCIA_ITECNICO = file.FileName.Split(new[] { "__" }, StringSplitOptions.None).FirstOrDefault();
                            ar.URL_TECNICO = path;
                            ar.ARCHIVO_EXTENSION = file.ContentType;
                            ar.NOMBRE_ARCHIVO = file.FileName.Split(new[] { "__" }, StringSplitOptions.None).LastOrDefault();
                            archivo.Archivos.Add(ar);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return Json(archivo);
        }
        [HttpPost]
        public JsonResult SubirArchivoAuditoria()
        {
            List<Archivo> archivoList = new List<Archivo>();
            try
            {
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\Denuncia\", fileName);
                            file.SaveAs(path);
                            Archivo archivoFile = new Archivo();
                            archivoFile.path = fileName;
                            archivoFile.mineType = file.ContentType;
                            archivoFile.mensaje = file.FileName;
                            archivoList.Add(archivoFile);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return Json(archivoList);
        }
        [HttpPost]
        public JsonResult RegistrarDenuncia(IDENUNCIA ent_Denuncias)
        {
            IDENUNCIA olResult;
            try
            {
                CLogica exeCap = new CLogica();
                if (ent_Denuncias.ENT_INFORME == null) ent_Denuncias.ENT_INFORME = new Ent_INFORME();
                olResult = exeCap.InsertarDenunciaCabecera(ent_Denuncias, (ModelSession.GetSession())[0].COD_UCUENTA);
            }
            catch (Exception ex) { throw ex; }
            return Json(olResult);
        }
        [HttpPost]
        public JsonResult ObtenerDataDenuncica(IDENUNCIA ent)
        {
            try
            {
                CLogica exeCap = new CLogica();
                ent = exeCap.obtenerDenuncias(ent);
            }
            catch (Exception e) { throw e; }
            return Json(ent);
        }
        public FileResult descargarArchivo(string ruta, string nombre, string mineType)
        {
            byte[] oBytes;
            string rut1a = string.Empty;
            try
            {
                rut1a = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\Denuncia\", ruta);
                oBytes = System.IO.File.ReadAllBytes(rut1a);
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                rut1a = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Content\images\General\", "Delete-file-icon.png");
                oBytes = System.IO.File.ReadAllBytes(rut1a);
                mineType = "image/png";
            }
            return File(oBytes, mineType);
        }
        [HttpPost]
        public JsonResult crud_Incidencia(IINCIDENCIA i)
        {
            List<IINCIDENCIA> olResult;
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.crudIncidencias(i);
            }
            catch (Exception ex) { throw ex; }
            return Json(olResult);
        }
        [HttpPost]
        public JsonResult ConsultarInforme(Ent_INFORME _INFORME)
        {
            List<Ent_INFORME> olResult;
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.ConsultarInforme(_INFORME);
            }
            catch (Exception ex) { throw ex; }
            return Json(olResult);
        }
        [HttpPost]
        public JsonResult ConsultarPoas(IDENUNCIA _INFORME)
        {
            //_INFORME.IDenunciaDetInformeSupervision
            try
            {
                CLogica exeCap = new CLogica();
                _INFORME = exeCap.obtenerPoaPorInformeSupervision(_INFORME);
            }
            catch (Exception ex) { throw ex; }
            return Json(_INFORME.IDenunciaDetInformeSupervision);
        }
        [HttpPost]
        public JsonResult ConsultarTHabilitante(IDENUNCIA_THABILITANTE _INFORME)
        {
            List<IDENUNCIA_THABILITANTE> olResult;
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.ConsultarTHabilitante(_INFORME);
            }
            catch (Exception ex) { throw ex; }
            return Json(olResult);
        }
        [HttpPost]
        public JsonResult insertarTramiteDenuncia(IDENUNCIA _INFORME)
        {
            IDENUNCIA olResult = new IDENUNCIA();
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.insertarTramiteDenuncia(_INFORME);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex) { /*throw ex;*/ }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            return Json(olResult);
        }
        [HttpPost]
        public JsonResult obtenerDenunciaxInforme(IDENUNCIA _INFORME)
        {
            IDENUNCIA olResult;
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.obtenerDenunciaxInforme(_INFORME);
            }
            catch (Exception ex) { throw ex; }
            return Json(olResult);
        }


        [HttpPost]
        public JsonResult consultaGenerica()
        {
            List<IINCIDENCIA> olResult;
            try
            {
                CLogica exeCap = new CLogica();
                olResult = exeCap.consultaGenerica();
            }
            catch (Exception ex) { throw ex; }
            return Json(olResult);
        }
        [HttpPost]
        public JsonResult GetListaDocumentosSITD(Ent_BUSQUEDA paramsBus)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
           
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
           
            lstResult = exeBus.ListarDocumentosSITD_Paging(paramsBus, ref rowcount);

            return Json(lstResult);
        }
        [HttpGet]
        public ActionResult DowloadFile(string nombre)
        {
            string FilePath = "";
            FilePath = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=//10.10.8.20/sitd-almacen/cAlmacenAnexos/&file=" + nombre;
            return Redirect(FilePath);
        }

        #endregion
    }
}