using CapaEntidad.ViewModel;
using Newtonsoft.Json;
using SIGOFCv3.Areas.Capacitacion.Models.ManCapacitacion;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_CAPACITACION;
using CEntVM = CapaEntidad.ViewModel.VM_Capacitacion;
using CLogica = CapaLogica.DOC.Log_CAPACITACION;
using Microsoft.Reporting.WebForms;
using System.IO;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
using CapaEntidad.DOC;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;
using OfficeOpenXml;

namespace SIGOFCv3.Areas.Capacitacion.Controllers
{
    public class ManCapacitacionController : Controller
    {
        // GET: Capacitacion/ManCapacitacion
        [HttpGet]
        public ActionResult Index(string _alertaIncial = "", string _tipoFormulario = "0")
        {
            if (_tipoFormulario == "0")//Formulario de Capacitación
            {
                ViewBag.Formulario = "CAPACITACION";
                ViewBag.TituloFormulario = "Capacitaciones";
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO CAPACITACION", "Capacitaciones");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
            }
            else//Formulario Otros Eventos
            {
                ViewBag.Formulario = "OTROS_EVENTOS";
                ViewBag.TituloFormulario = "Otros Eventos";
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO CAPACITACION", "Otros Eventos");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
            }

            ViewBag.AlertaInicial = _alertaIncial;

            return View();
        }
        [HttpGet]
        public ActionResult AddEdit(string asCodCapacitacion, string asFormulario)
        {
            try
            {
                CEntVM VM_CAP = new CEntVM();
                CLogica exeCap = new CLogica();
                VM_CAP = exeCap.IniDatosCapacitacion(asCodCapacitacion, asFormulario, (ModelSession.GetSession())[0].COD_UCUENTA);
                ViewBag.Formulario = asFormulario;
                ViewBag.codCapacitacionreporte = asCodCapacitacion;
                Session["CodCapacitacion"] = asCodCapacitacion;
                VM_Menu_Rol mr = new VM_Menu_Rol();
                if ("CAPACITACION" == asFormulario)
                {
                    //obtenemos el rol sobre el formulario
                    mr = HelperSigo.GetRol("MODULO CAPACITACION", "Capacitaciones");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                else
                {
                    //obtenemos el rol sobre el formulario
                    mr = HelperSigo.GetRol("MODULO CAPACITACION", "Otros Eventos");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                //Pasamos el Rol del usuario
                VM_CAP.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                return View(VM_CAP);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public ActionResult ReporteNC(string id, string asCodCapacitacion)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Areas/Capacitacion/Reporte"), "ReporteNotaConceptual.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");

            }

            List<CEntidad> cm2 = new List<CEntidad>();
            List<CEntidad> cm3 = new List<CEntidad>();
            List<CEntidad> cm4 = new List<CEntidad>();
            //CEntVM VM_CAP = new CEntVM();
            CLogica exeCap = new CLogica();
            cm2 = exeCap.ReporteNOTACONCEPTUAL(asCodCapacitacion);
            cm3 = exeCap.ReporteMEMORIAProgramacion(asCodCapacitacion);
            cm4 = exeCap.ReporteMEMORIACronograma(asCodCapacitacion);

            ReportDataSource rd = new ReportDataSource("DataSet1", cm2);
            ReportDataSource rd2 = new ReportDataSource("DataSet2", cm3);
            ReportDataSource rd3 = new ReportDataSource("DataSet3", cm4);
            lr.DataSources.Add(rd);
            lr.DataSources.Add(rd2);
            lr.DataSources.Add(rd3);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);

        }
        [HttpGet]
        public ActionResult ReporteMEMORIA(string id, string asCodCapacitacion)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Areas/Capacitacion/Reporte"), "ReporteMemoria.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");

            }

            List<CEntidad> cm3 = new List<CEntidad>();
            //CEntVM VM_CAP = new CEntVM();
            CLogica exeCap = new CLogica();
            cm3 = exeCap.ReporteMEMORIA(asCodCapacitacion);

            ReportDataSource rd = new ReportDataSource("DataSet1", cm3);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);

        }
        [HttpPost]
        public JsonResult AddEdit(CEntVM dto)
        {
            CLogica exePCap = new CLogica();
            ListResult result = exePCap.GuardarDatosCapacitacion(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        [HttpPost]
        public PartialViewResult _Participante()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlItemPart_Institucion = exeBus.RegMostComboIndividual("INSTITUCION", "");
            ViewBag.ddlItemPart_Comunidad = exeBus.RegMostComboIndividual("COMUNIDAD_NATIVA", "");
            ViewBag.ddlItemPart_Etnia = exeBus.RegMostComboIndividual("ETNIA", "");
            ViewBag.ddlItemPart_Cargo = exeBus.RegMostComboIndividual("CARGO", "");
            ViewBag.ddlItemPart_GrupoPublico = exeBus.RegMostComboIndividual("GRUPO_PUBLICO_PARTICIPANTE", "");
            ViewBag.ddlItemPart_Publico = new List<VM_Cbo>() { new VM_Cbo() { Text = "Seleccionar", Value = "0000000" } };
            ViewBag.ddlItemPart_Mochila = new List<VM_Cbo>() {
                new VM_Cbo() { Text = "Seleccionar", Value = "0000000" },
                new VM_Cbo() { Text = "SI", Value = "SI" },
                new VM_Cbo() { Text = "NO", Value = "NO" },
            };

            return PartialView();
        }
        [HttpPost]
        public JsonResult GetPublicoParticipante(string codGrupoPublico)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            var result = exeBus.RegMostComboIndividual("PUBLICO_PARTICIPANTE", codGrupoPublico);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ImportarDatosCapacitacion(string hdfTipo)
        {
            List<CEntidad> olResult = new List<CEntidad>();

            try
            {
                if (Request != null)
                {
                    switch (hdfTipo)
                    {
                        case "PARTICIPANTE_ASISTENTE":
                            olResult = ImportarDatos.Participante_Asistentes(Request);
                            break;
                        case "PARTICIPANTE_EQUIPO":
                            olResult = ImportarDatos.Participante_EquipoApoyo(Request);
                            break;
                        case "PARTICIPANTE_PONENTE":
                            olResult = ImportarDatos.Participante_Ponentes(Request);
                            break;
                        case "EVALUACION_ENCUESTA":
                        case "EVALUACION_EVALINICIAL":
                        case "EVALUACION_EVALFINAL":
                            olResult = ImportarDatos.Evaluacion_Encuestas(Request);
                            break;
                        case "EVALUACION_EXAMEN":
                            olResult = ImportarDatos.Evaluacion_Examenes(Request);
                            break;
                        case "PROGRAMACION":
                            olResult = ImportarDatos.Programacion(Request);
                            break;
                        case "CRONOGRAMA":
                            olResult = ImportarDatos.Cronograma(Request);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = olResult.ToArray() });
        }
        [HttpPost]
        public PartialViewResult _PreguntaEncuesta()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _NotaExamen()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarDocumentoAdjunto()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    CEntidad datoDoc = JsonConvert.DeserializeObject<CEntidad>(Request.Form["data"]);
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 
                    CLogica exeCap = new CLogica();

                    datoDoc.COD_SECUENCIAL = 0;
                    datoDoc.RegEstado = 1;
                    datoDoc.OUTPUTPARAM01 = "";
                    datoDoc.NOMBRE_ARCHIVO = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
                    datoDoc.EXTENSION = file.FileName.Substring(file.FileName.LastIndexOf(".")).ToLower();

                    string resultado = exeCap.RegGrabarDetalle(datoDoc);
                    if (resultado != "")
                    {
                        datoDoc.COD_SECUENCIAL = Convert.ToInt32(resultado.Split('_')[1]);
                        datoDoc.RegEstado = 0;

                        //Guardar el doc ajunto
                        string url_base = "~/Archivos/Archivo_Capacitacion/";
                        string url_doc = url_base + datoDoc.COD_CAPACITACION + datoDoc.COD_SECUENCIAL.ToString() + datoDoc.EXTENSION;

                        //Get the complete folder path and store the file inside it.
                        file.SaveAs(Server.MapPath(url_doc));

                        // Returns message that successfully uploaded  
                        return Json(new { success = true, msj = "El documento se registro correctamente", data = datoDoc });
                    }
                    else { throw new Exception("No se pudo registrar el documento adjunto"); }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontró el documento a subir" });
            }
        }
        [HttpPost]
        public JsonResult EliminarDocumentoAdjunto(CEntidad _dto)
        {
            try
            {
                string url_base = "~/Archivos/Archivo_Capacitacion/";
                string url_doc = url_base + _dto.COD_CAPACITACION + _dto.COD_SECUENCIAL + _dto.EXTENSION;
                System.IO.File.Delete(Server.MapPath(url_doc));

                CLogica exeCap = new CLogica();
                exeCap.RegEliminar(new CEntidad()
                {
                    EliTABLA = "CAPACITACION_DETALLE",
                    COD_CAPACITACION = _dto.COD_CAPACITACION,
                    EliVALOR02 = _dto.COD_SECUENCIAL
                });

                return Json(new { success = true, msj = "El documento ha sido eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult ExportarRegistroUsuario(string asFormulario)
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA, asFormulario);

            return Json(result);
        }
        [HttpGet]
        public ActionResult Reporte(string _idTipoReporte)
        {
            string tipoReporte = "";
            CLogica exeCap = new CLogica();

            switch (_idTipoReporte)
            {
                case "0": tipoReporte = "CONSULTA_PARTICIPANTE"; break;
                case "1": tipoReporte = "PROGRAMA_VS_EJECUCION"; break;
                case "2": tipoReporte = "TOTAL_CAPACITACION"; break;
                case "3": tipoReporte = "CAPACITACION_MENSUAL"; break;
                case "4": tipoReporte = "RELACION_CAPACITACION"; break;
                case "5": tipoReporte = "GRUPO_PUBLICO_OBJETIVO"; break;
                case "6": tipoReporte = "CAPACITACION_DEPARTAMENTO_ANIO"; break;
                case "7": tipoReporte = "CAPACITACION_THABILITANTE"; break;
                case "8": tipoReporte = "GRUPO_PUBLICO_PARTICIPANTE"; break;
            }

            VM_Capacitacion_Reporte _dto = exeCap.IniCapacitacionReporte(tipoReporte, (ModelSession.GetSession())[0].COD_UCUENTA);

            return View(_dto);
        }
        /// <summary>
        /// Metodo que recibe el request post de la acción del boton Consultar del reporte de capacitación
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Reporte(VM_Capacitacion_Reporte dto)
        {
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            CEntidad paramCap = new CEntidad();
            CLogica exeCap = new CLogica();

            try
            {
                if (dto.hdfTipoReporte == "CAPACITACION_THABILITANTE" && dto.ddlTHCapacitadosId == "SI")
                { paramCap.TIPO_REPORTE = dto.hdfTipoReporte; }
                else if (dto.hdfTipoReporte == "CAPACITACION_THABILITANTE" && dto.ddlTHCapacitadosId == "NO")
                { paramCap.TIPO_REPORTE = "THABILITANTE_NO_CAPACITADO"; }
                else if (dto.hdfTipoReporte == "CAPACITACION_THABILITANTE_DETALLE" && dto.ddlTHCapacitadosId == "SI")
                { paramCap.TIPO_REPORTE = dto.hdfTipoReporte; }
                else if (dto.hdfTipoReporte == "CAPACITACION_THABILITANTE_DETALLE" && dto.ddlTHCapacitadosId == "NO")
                { paramCap.TIPO_REPORTE = "THABILITANTE_NO_CAPACITADO_DETALLE"; }
                else { paramCap.TIPO_REPORTE = dto.hdfTipoReporte; }

                paramCap.COD_PERSONA = dto.hdfCodPersona;
                paramCap.COD_THABILITANTE = dto.hdfCodTHabilitante;
                paramCap.ANIO = (dto.lstChkAnioId ?? "").Replace(',', '|');
                paramCap.MES = (dto.lstChkMesId ?? "").Replace(',', '|');
                paramCap.COD_OD = (dto.lstChkOdId ?? "").Replace(',', '|');
                paramCap.COD_CAPATIPO = (dto.lstChkTipCapacitacionId ?? "").Replace(',', '|');
                paramCap.COD_CAPATIPO += dto.ddlOtrosEventosId == "SI" ? "|0000006" : "";
                paramCap.POI = dto.ddlSumMetPoiId;
                paramCap.MAE_ENT_FINANCIA = dto.ddlEntFinanciaId;
                paramCap.COD_CCNN = (dto.ddlComunidadNativaId ?? "") == "0000000" ? "" : dto.ddlComunidadNativaId;
                paramCap.ETNIA = (dto.ddlEtniaId ?? "") == "0000000" ? "" : dto.ddlEtniaId;
                paramCap.COD_UBIGEO = (dto.lstChkDepartamentoId ?? "").Replace(',', '|');
                paramCap.COD_PUBLICO_OBJETIVO = (dto.lstChkPublicoObjetivoId ?? "").Replace(',', '|');
                paramCap.COD_MTIPO = dto.hdfCodMTipo ?? "";
                string[] lstInstitucion = (dto.lstChkInstitucionId ?? "").Split(',');
                paramCap.COD_INSTITUCION = "'0000000'";
                foreach (var item in lstInstitucion)
                {
                    paramCap.COD_INSTITUCION += ",'" + item + "'";
                }

                olResult = exeCap.ReportesCapacitacion(paramCap);

                if (dto.hdfTipoReporte == "GRUPO_PUBLICO_OBJETIVO")
                {
                    paramCap.TIPO_REPORTE = "PUBLICO_OBJETIVO";
                    List<Dictionary<string, string>> olResult2 = exeCap.ReportesCapacitacion(paramCap);
                    paramCap.TIPO_REPORTE = "PUBLICO_OBJETIVO_RESUMEN";
                    List<Dictionary<string, string>> olResult3 = exeCap.ReportesCapacitacion(paramCap);
                    return Json(new { success = true, msj = "", data = olResult.ToArray(), data2 = olResult2.ToArray(), data3 = olResult3.ToArray() });
                }
                if (dto.hdfTipoReporte == "GRUPO_PUBLICO_PARTICIPANTE")
                {
                    paramCap.TIPO_REPORTE = "PUBLICO_PARTICIPANTE";
                    List<Dictionary<string, string>> olResult2 = exeCap.ReportesCapacitacion(paramCap);
                    paramCap.TIPO_REPORTE = "PUBLICO_PARTICIPANTE_RESUMEN";
                    List<Dictionary<string, string>> olResult3 = exeCap.ReportesCapacitacion(paramCap);
                    return Json(new { success = true, msj = "", data = olResult.ToArray(), data2 = olResult2.ToArray(), data3 = olResult3.ToArray() });
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
        #region "Gestión de constancias"
        //USAR SharpZipLib PARA DESCARGA MASIVA
        [HttpGet]
        public ActionResult ConstanciaDescargarAll(String codCapacitacion)
        {
            string folderBase = "~/Archivos/CapConstancias";
            string folderZips = folderBase + "/Zips";
            byte[] dataByte = null;
            try
            {
                if (!Directory.Exists(Server.MapPath(folderZips)))
                {
                    Directory.CreateDirectory(Server.MapPath(folderZips));
                }

                CLogica exeCap = new CLogica();
                var constancias = exeCap.ConstanciaListar(codCapacitacion);

                var constanciasActivas = constancias.Where(x => x.ESTADO == 1).ToList();

                if (constanciasActivas.Count > 0)
                {
                    string file = Path.Combine(Server.MapPath(folderZips), string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now) + ".zip");
                    System.IO.FileStream fs = System.IO.File.Create(file);
                    using (ZipOutputStream zip = new ZipOutputStream(fs))
                    {
                        foreach (var item in constanciasActivas)
                        {

                            string constanciaName = item.ARCHIVO;
                            string pathFinal = System.IO.Path.Combine(Server.MapPath(folderBase), item.ARCHIVO_COD);
                            byte[] byteFile = System.IO.File.ReadAllBytes(pathFinal);
                            ZipEntry entry;
                            entry = new ZipEntry(constanciaName);
                            entry.DateTime = System.DateTime.Now;
                            zip.PutNextEntry(entry);
                            dataByte = byteFile;
                            zip.Write(dataByte, 0, dataByte.Length);
                        }
                        zip.Finish();
                        zip.Close();
                    }
                    fs.Dispose(); // must dispose of it
                    fs = System.IO.File.OpenRead(file); // must re-open the zip file
                    dataByte = new byte[fs.Length];
                    fs.Read(dataByte, 0, dataByte.Length);
                    fs.Close();
                }
                else
                {
                    return Content("No existen constancias");
                }
                return File(dataByte, "application/x-zip-compressed", string.Format("{0}{1}.zip", "Constancias_", string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now)));
            }
            catch (Exception ex)
            {
                return Content("Error al descargar los cargos. Por favor comunicarse con soporte");
            }
        }
        [HttpGet]
        public JsonResult ConstanciaListar(String codCapacitacion, int flagActivo = 0)
        {
            try
            {
                CLogica exeCap = new CLogica();
                var constancias = exeCap.ConstanciaListar(codCapacitacion, flagActivo);
                var jsonResult = Json(new { success = true, data = constancias, msj = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = "", msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult ConstanciaEliminar(String codConstancia)
        {
            string folderBase = "~/Archivos/CapConstancias";
            try
            {
                CLogica exeCap = new CLogica();
                var constancia = exeCap.ConstanciaObtener(codConstancia);
                if (constancia == null) throw new Exception("Constancia a eliminar no existe");
                if (constancia.ESTADO == 0) throw new Exception($"La Constancia {constancia.NRO_CONSTANCIA} ya se encuentra eliminada");

                exeCap.ConstanciaEliminar(codConstancia, (ModelSession.GetSession())[0].COD_UCUENTA);

                try
                {
                    string folderEli = folderBase + "/Eliminados";
                    if (!Directory.Exists(Server.MapPath(folderEli)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderEli));
                    }
                    string pathOrigenDoc = Path.Combine(Server.MapPath(folderBase), $"{constancia.ARCHIVO_COD}");
                    string pathDestinoDoc = Path.Combine(Server.MapPath(folderEli), $"{constancia.ARCHIVO_COD}");
                    if (System.IO.File.Exists(pathOrigenDoc))
                    {
                        System.IO.File.Move(pathOrigenDoc, pathDestinoDoc);
                    }
                }
                catch (Exception) { }

                return Json(new { success = true, msj = "Constancia eliminado correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ConstanciaVer(String codConstancia)
        {
            string folderBase = "~/Archivos/CapConstancias";
            try
            {
                CLogica exeCap = new CLogica();
                var constancia = exeCap.ConstanciaObtener(codConstancia);



                if (constancia == null) throw new Exception("0|Constancia no existe");

                if (constancia.ESTADO == 0) folderBase = "~/Archivos/CapConstancias/Eliminados";


                Stream stream;
                string pathFinal = System.IO.Path.Combine(Server.MapPath(folderBase), constancia.ARCHIVO_COD);

                if (!System.IO.File.Exists(pathFinal)) throw new Exception("0|No existe constancia");

                Byte[] byteFile = System.IO.File.ReadAllBytes(pathFinal);

                stream = new MemoryStream(byteFile);
                var contentDisposition = new System.Net.Mime.ContentDisposition
                {
                    FileName = constancia.ARCHIVO,
                    Inline = true
                };
                Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
                return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                string msj = "Error al descargar la constancia";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(msj, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GenerarConstancias(String codCapacitacion, int cantidad, string modalidad)
        {
            int ultimoCorrelativo = 0;
            int anioActual = 0;
            string abreviatura = string.Empty;
            string nroConstancia = string.Empty;
            List<Ent_CAPACITACION_CONSTANCIA> constancias = null;
            Ent_CAPACITACION_CONSTANCIA constancia = null;
            bool flagRegBD = false;
            //--------------------------
            string nombrePlantilla = "Capacitacion_Constancia_Plantilla.docx";
            string folderPlantilla = "~/Archivos/Plantilla/Capacitacion";
            string folderBase = "~/Archivos/CapConstancias";
            string folderTemp = folderBase + "/Temp";
            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;
            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;
            byte[] bytePlantilla = null;

            //-------------------------
            try
            {
                modalidad = modalidad.ToUpper();
                CLogica exeCap = new CLogica();
                constancias = new List<Ent_CAPACITACION_CONSTANCIA>();
                var capacitacion = exeCap.ObtenerPorId(codCapacitacion);
                if (capacitacion != null)
                {
                    DateTime fechaActual = DateTime.Now;
                    anioActual = fechaActual.Year;
                    ultimoCorrelativo = exeCap.ObtenerUltimoCorrelativoPorAnio(codCapacitacion);
                    abreviatura = exeCap.ObtenerAbreviatura(capacitacion.COD_CAPATIPO);
                    if (string.IsNullOrEmpty(abreviatura)) throw new Exception("No existe código de abreviatura para el tipo de capacitación");
                    if (cantidad <= 0) throw new Exception("Ingrese Número de constancia mayor a 0");
                    if (string.IsNullOrEmpty(modalidad)) throw new Exception("Ingrese modalidad válida");
                    if (modalidad.Length < 3) throw new Exception("Ingrese modalidad válida");

                    ultimoCorrelativo = ultimoCorrelativo + 1;
                    int final = ultimoCorrelativo + cantidad;

                    //validando existencia de plantilla de constancias
                    try
                    {
                        bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderPlantilla), nombrePlantilla));

                        if (!Directory.Exists(Server.MapPath(folderBase)))
                        {
                            Directory.CreateDirectory(Server.MapPath(folderBase));
                        }
                        if (!Directory.Exists(Server.MapPath(folderTemp)))
                        {
                            Directory.CreateDirectory(Server.MapPath(folderTemp));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al leer la plantilla de constancia");
                    }

                    for (int i = ultimoCorrelativo; i < final; i++)
                    {
                        constancia = new Ent_CAPACITACION_CONSTANCIA();
                        nroConstancia = abreviatura + capacitacion.COD_CAPACITACION.Substring((capacitacion.COD_CAPACITACION.Length - 3), 3) + "-" + i.ToString().PadLeft(3, '0') + "-" + anioActual;
                        constancia.COD_CAPACITACION = codCapacitacion;
                        constancia.CORRELATIVO = i;
                        constancia.CORRELATIVO_ANIO = anioActual;
                        constancia.NRO_CONSTANCIA = nroConstancia;
                        modalidad = System.Text.RegularExpressions.Regex.Replace(modalidad, "^[a-z]", m => m.Value.ToUpper());
                        constancia.MODALIDAD = modalidad;
                        constancia.ARCHIVO = nroConstancia + ".pdf";
                        constancia.ARCHIVO_COD = Guid.NewGuid().ToString();
                        constancia.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                        constancia.FECHA_CREACION = DateTime.Now;
                        constancia.ESTADO = 1;
                        constancias.Add(constancia);
                    }
                    //creando pdfs
                    foreach (var item in constancias)
                    {
                        pathDestinoWord = Path.Combine(Server.MapPath(folderTemp), $"{item.ARCHIVO_COD}.docx");
                        pathDestinoPdf = Path.Combine(Server.MapPath(folderBase), $"{item.ARCHIVO_COD}.pdf");
                        item.ARCHIVO_COD = item.ARCHIVO_COD + ".pdf";
                        using (MemoryStream mem = new MemoryStream())
                        {
                            mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                            using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(mem, true))
                            {
                                var body = wordDoc.MainDocumentPart.Document.Body;
                                var paras = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
                                var tables = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Table>();
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_TIPOTALLER", capacitacion.CAPATIPO.ToLower());
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_NOMBRETALLER", capacitacion.NOMBRE.Replace("\"", "").Replace("“", "").Replace("”", ""));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_DIRIGIDO", capacitacion.DIRIGIDO.ToLower());

                                HelperWord.BuscarReemplazarTexto(paras, "VAR_MODALIDAD", item.MODALIDAD.ToLower());

                                HelperWord.BuscarReemplazarTexto(paras, "VAR_HORAE", " " + capacitacion.DURACION.ToString() + " ");
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_LUGARE", capacitacion.SECTOR);
                                if (!string.IsNullOrEmpty(capacitacion.FECHA_INICIO.ToString()))
                                {
                                    fechaInicio = Convert.ToDateTime(capacitacion.FECHA_INICIO);
                                }
                                if (!string.IsNullOrEmpty(capacitacion.FECHA_TERMINO.ToString()))
                                {
                                    fechaFin = Convert.ToDateTime(capacitacion.FECHA_TERMINO);
                                }

                                if (fechaInicio != null)
                                {
                                    if (fechaInicio != null && fechaFin == null)
                                    {
                                        HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                        HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                    }
                                    if (fechaInicio != null && fechaFin != null)
                                    {
                                        HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", " del " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)) + " al " + HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                                        HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                                    }
                                    if (fechaInicio == fechaFin)
                                    {
                                        HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                        HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                    }

                                }

                                else
                                {
                                    HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día ..............");
                                    HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", " ..............");
                                }
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_NUMC", item.NRO_CONSTANCIA);
                                HelperWord.SearchAndReplace(wordDoc, "VAR_NUMC", item.NRO_CONSTANCIA, true);


                                wordDoc.Close();
                            }
                            this.GuardarMemoryStream(mem, pathDestinoWord);
                            //  this.GenerarPDF(pathDestinoWord, pathDestinoPdf, inscripcionId);
                            this.GenerarPDF(pathDestinoWord, pathDestinoPdf);
                        }
                        this.EliminarArchivo(pathDestinoWord);
                    }
                    //insertando en la base de datos
                    flagRegBD = exeCap.ConstanciaInsertarMasivo(constancias);

                    if (constancias.Count <= 0)
                    {
                        return Json(new { success = false, msj = "No se ha generado alguna constancia" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (constancias.Count == 1)
                    {
                        return Json(new { success = true, msj = "Se ha generado una constancia" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, msj = $"Se ha generado una total de {constancias.Count} constancias" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    throw new Exception("Capacitación no existe");
                }

            }
            catch (Exception ex)
            {
                if (constancias != null)
                {
                    foreach (var eli in constancias)
                    {
                        pathDestinoWord = Path.Combine(Server.MapPath(folderTemp), $"{eli.ARCHIVO_COD}.docx");
                        pathDestinoPdf = Path.Combine(Server.MapPath(folderBase), $"{eli.ARCHIVO_COD}.pdf");
                        this.EliminarArchivo(pathDestinoWord);
                        this.EliminarArchivo(pathDestinoPdf);
                    }
                }
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        private void GuardarMemoryStream(MemoryStream ms, string fileName)
        {
            FileStream outStream = System.IO.File.OpenWrite(fileName);
            ms.WriteTo(outStream);
            outStream.Flush();
            outStream.Close();
        }
        private void GenerarPDF(string fileNameOrigen, string fileNameDestino)
        {
            WnvWordToPdf.WordToPdfConverter wordToPdfConverter = new WnvWordToPdf.WordToPdfConverter();
            wordToPdfConverter.LicenseKey = "G5WGlIaHlIOFjICUhYGahJSHhZqFhpqNjY2NlIQ=";
            try
            {
                byte[] outPdfBuffer = wordToPdfConverter.ConvertWordFile(fileNameOrigen);
                System.IO.File.WriteAllBytes(fileNameDestino, outPdfBuffer);
            }
            catch (Exception e)
            {
                throw new Exception("Error al convertir a PDF");
            }
        }
        private void EliminarArchivo(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);
            }
            catch (Exception) { }
        }
        [HttpGet]
        public JsonResult ParticipanteListar(string codCapacitacion, string codTipoParticipante, string persona)
        {
            try
            {
                CLogica exeCap = new CLogica();
                List<CEntidad> consulta = exeCap.ParticipanteListar(codCapacitacion, codTipoParticipante, persona);
                int i = 1;
                var result = from c in consulta
                             select new
                             {
                                 ind = i++,
                                 COD_CAPACITACION = c.COD_CAPACITACION,
                                 COD_PERSONA = c.COD_PERSONA,
                                 MAE_COD_TIPOPARTICIPANTE = c.MAE_COD_TIPOPARTICIPANTE,
                                 N_DOCUMENTO = c.N_DOCUMENTO,
                                 APE_PATERNO = c.APE_PATERNO,
                                 APE_MATERNO = c.APE_MATERNO,
                                 NOMBRES = c.NOMBRES,
                                 APELLIDOS_NOMBRES = c.APELLIDOS_NOMBRES,
                                 COD_INSTITUCION = c.COD_INSTITUCION,
                                 NOM_INSTITUCION = c.NOM_INSTITUCION,
                                 CARGO = c.CARGO,
                                 GENERO = c.GENERO,
                                 EDAD = c.EDAD,
                                 TELEFONO = c.TELEFONO,
                                 CORREO = c.CORREO,
                                 OBSERVACION = c.OBSERVACION,
                                 COD_CONSTANCIA = c.COD_CONSTANCIA,
                                 FUNCION = c.FUNCION,
                                 COD_CCNN = c.COD_CCNN,
                                 CCNN = c.CCNN,
                                 ETNIA = c.ETNIA,
                                 COD_THABILITANTE = c.COD_THABILITANTE,
                                 NUM_THABILITANTE = c.NUM_THABILITANTE,
                                 MAE_COD_GRUPOPUBLICOPARTICIPANTE = c.MAE_COD_GRUPOPUBLICOPARTICIPANTE,
                                 GRUPOPUBLICOPARTICIPANTE = c.GRUPOPUBLICOPARTICIPANTE,
                                 MAE_COD_PUBLICOPARTICIPANTE = c.MAE_COD_PUBLICOPARTICIPANTE,
                                 PUBLICOPARTICIPANTE = c.PUBLICOPARTICIPANTE,
                                 FECHA_CREACION = c.FECHA_CREACION,
                                 MOCHILAFORESTAL = c.MOCHILAFORESTAL,
                                 COD_CONSTANCIA_CAP = c.COD_CONSTANCIA_CAP
                             };
                var jsonResult = Json(new { data = result, success = true, er = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, er = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult _ParticitanteBuscar(string codCapacitacion, string codTipoParticipante, string codConstancia)
        {
            ViewBag.hdCodCapacitacion = codCapacitacion;
            ViewBag.hdCodTipoParticipante = codTipoParticipante;
            ViewBag.hdCodConstancia = codConstancia;
            return PartialView();
        }
        [HttpGet]
        public JsonResult AsignarConstancia(string codCapacitacion, string codTipoParticipante, string codConstancia, string codPersona)
        {
            string nuevoCodigoConstancia;
            string nombrePlantilla = "Capacitacion_Constancia_PlantillaParticipante.docx";
            string folderPlantilla = "~/Archivos/Plantilla/Capacitacion";
            string folderBase = "~/Archivos/CapConstancias";
            string folderTemp = folderBase + "/Temp";
            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;
            byte[] bytePlantilla = null;
            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;
            try
            {
                CLogica exeCap = new CLogica();
                var participante = exeCap.ParticipanteObtener(codCapacitacion, codTipoParticipante, codPersona);
                if (participante == null) throw new Exception("Participante no existe");
                if (!string.IsNullOrEmpty(participante.COD_CONSTANCIA_CAP))
                {
                    throw new Exception("Participante ya tiene constania asignada");
                }
                var constancia = exeCap.ConstanciaObtener(codConstancia);
                if (constancia == null)
                {
                    throw new Exception("Constancia seleccionada no existe");
                }
                if (constancia.FLAG_ASIGNADO >= 1)
                {
                    throw new Exception($"La constancia {constancia.NRO_CONSTANCIA} ya ha sido asignada");
                }
                var capacitacion = exeCap.ObtenerPorId(codCapacitacion);
                if (capacitacion == null)
                {
                    throw new Exception("Capacitación no existe");
                }
                //validando existencia de plantilla de constancias
                try
                {
                    bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderPlantilla), nombrePlantilla));

                    if (!Directory.Exists(Server.MapPath(folderBase)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderBase));
                    }
                    if (!Directory.Exists(Server.MapPath(folderTemp)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderTemp));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al leer la plantilla de constancia");
                }
                nuevoCodigoConstancia = Guid.NewGuid().ToString();
                pathDestinoWord = Path.Combine(Server.MapPath(folderTemp), $"{nuevoCodigoConstancia}.docx");
                pathDestinoPdf = Path.Combine(Server.MapPath(folderBase), $"{nuevoCodigoConstancia}.pdf");
                nuevoCodigoConstancia = nuevoCodigoConstancia + ".pdf";
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                    using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(mem, true))
                    {
                        var body = wordDoc.MainDocumentPart.Document.Body;
                        var paras = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
                        var tables = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Table>();
                        string persona = participante.NOMBRES?.ToUpper() + " " + participante.APE_PATERNO?.ToUpper() + " " + participante.APE_MATERNO?.ToUpper();
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_PARTICIPANTE", persona);
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_TIPOTALLER", capacitacion.CAPATIPO.ToLower());
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_NOMBRETALLER", capacitacion.NOMBRE.Replace("\"", "").Replace("“", "").Replace("”", ""));
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_DIRIGIDO", capacitacion.DIRIGIDO.ToLower());

                        HelperWord.BuscarReemplazarTexto(paras, "VAR_MODALIDAD", constancia.MODALIDAD.ToLower());

                        HelperWord.BuscarReemplazarTexto(paras, "VAR_HORAE", " " + capacitacion.DURACION.ToString() + " ");
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_LUGARE", capacitacion.SECTOR);
                        if (!string.IsNullOrEmpty(capacitacion.FECHA_INICIO.ToString()))
                        {
                            fechaInicio = Convert.ToDateTime(capacitacion.FECHA_INICIO);
                        }
                        if (!string.IsNullOrEmpty(capacitacion.FECHA_TERMINO.ToString()))
                        {
                            fechaFin = Convert.ToDateTime(capacitacion.FECHA_TERMINO);
                        }
                        if (fechaInicio != null)
                        {
                            if (fechaInicio != null && fechaFin == null)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                            }

                            if (fechaInicio != null && fechaFin != null)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", " del " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)) + " al " + HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                            }
                            if (fechaInicio == fechaFin)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", " el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                            }

                        }
                        else
                        {
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", " el día ..............");
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", " ..............");
                        }
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_NUMC", constancia.NRO_CONSTANCIA);
                        HelperWord.SearchAndReplace(wordDoc, "VAR_NUMC", constancia.NRO_CONSTANCIA, true);


                        wordDoc.Close();
                    }
                    this.GuardarMemoryStream(mem, pathDestinoWord);
                    //  this.GenerarPDF(pathDestinoWord, pathDestinoPdf, inscripcionId);
                    this.GenerarPDF(pathDestinoWord, pathDestinoPdf);
                }
                this.EliminarArchivo(pathDestinoWord);

                //actualizando participante y constancia codCapacitacion, codTipoParticipante, codPersona
                var result = exeCap.ParticipanteAsignarConstancia(codCapacitacion, codTipoParticipante, codPersona, constancia.COD_CONSTANCIA, nuevoCodigoConstancia, (ModelSession.GetSession())[0].COD_UCUENTA, DateTime.Now);

                string folderEli = folderBase + "/Eliminados";
                if (!Directory.Exists(Server.MapPath(folderEli)))
                {
                    Directory.CreateDirectory(Server.MapPath(folderEli));
                }
                string pathOrigenDoc = Path.Combine(Server.MapPath(folderBase), $"{constancia.ARCHIVO_COD}");
                string pathDestinoDoc = Path.Combine(Server.MapPath(folderEli), $"{constancia.ARCHIVO_COD}");
                if (System.IO.File.Exists(pathOrigenDoc))
                {
                    System.IO.File.Move(pathOrigenDoc, pathDestinoDoc);
                }
                return Json(new { success = true, msj = "Constancia Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult DescargarPlantillaAsignacion(string codCapacitacion)
        {
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Capacitacion/CAPACITACIONES PLANTILLA CONSTANCIAS.xlsx"));
            CLogica exeCap = new CLogica();
            List<CEntidad> participantes = exeCap.ParticipanteListar(codCapacitacion, "0000016", "");
            int rowStart = 2;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (participantes != null)
                {
                    int column = 0;

                    foreach (var item in participantes)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COD_CAPACITACION + "|" + item.COD_PERSONA + "|" + item.MAE_COD_TIPOPARTICIPANTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.APE_PATERNO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.APE_MATERNO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NOMBRES;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.N_DOCUMENTO;
                        if (item.COD_CONSTANCIA_CAP.Length > 5)
                        {
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "SI";
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NRO_CONSTANCIA;
                        }
                        else
                        {
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "NO";
                        }

                        rowStart++;
                    }
                }
                string excelName = "ParticipantesConstancia";
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
        [HttpPost]
        public JsonResult UploadExcel()
        {

            string archivo = string.Empty;
            string nombreFinal = string.Empty;

            bool success = false; string message = string.Empty;
            string folderBase = "~/Archivos/Plantilla/Capacitacion";
            string folderTemp = folderBase + "/Temp";
            bool flagResultado; string msjResultado;
            int countConstanciasActualizadas = 0;
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
                            ExcelWorksheet workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;

                            if (noOfCol != 7) throw new Exception("Plantilla incorrecta");

                            string codigo = string.Empty;
                            string COD_CAPACITACION = string.Empty, COD_PERSONA = string.Empty, MAE_COD_TIPOPARTICIPANTE = string.Empty;
                            string nroConstancia, asignado;
                            int colCodigo = 1, colNroConstancia = 7;
                            int colResultado = 8, colAsignado = 6;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                codigo = workSheet.Cells[rowIterator, colCodigo].Value == null ? "" : workSheet.Cells[rowIterator, colCodigo].Value.ToString()?.Trim();
                                asignado = workSheet.Cells[rowIterator, colAsignado].Value == null ? "" : workSheet.Cells[rowIterator, colAsignado].Value.ToString()?.Trim();
                                string[] codigoSplit = codigo.Split('|');
                                COD_CAPACITACION = codigoSplit[0];
                                COD_PERSONA = codigoSplit[1];
                                MAE_COD_TIPOPARTICIPANTE = codigoSplit[2];

                                if (asignado != "SI")
                                {
                                    if (codigoSplit.Length == 3)
                                    {
                                        nroConstancia = workSheet.Cells[rowIterator, colNroConstancia].Value == null ? "" : workSheet.Cells[rowIterator, colNroConstancia].Value.ToString()?.Trim();

                                        if (!string.IsNullOrEmpty(nroConstancia))
                                        {
                                            AsignarConstanciasMasiva(COD_CAPACITACION, COD_PERSONA, MAE_COD_TIPOPARTICIPANTE, nroConstancia, out flagResultado, out msjResultado);

                                            if (flagResultado == true)
                                            {
                                                this.AgregarResultado(workSheet, rowIterator, colResultado, "OK");
                                                countConstanciasActualizadas++;
                                            }
                                            else
                                            {
                                                this.AgregarResultado(workSheet, rowIterator, colResultado, msjResultado);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.AgregarResultado(workSheet, rowIterator, colResultado, "CÓDIGO PARTICIPANTE ES INCORRECTO");
                                    }
                                }
                            }
                            string nombreArchivo = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
                            string extArch = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
                            nombreFinal = $"{nombreArchivo}_Resultado.{extArch}";

                            string pathGenerado = "";

                            if (!Directory.Exists(Server.MapPath(folderTemp)))
                            {
                                Directory.CreateDirectory(Server.MapPath(folderTemp));
                            }
                            pathGenerado = Path.Combine(Server.MapPath(folderTemp), nombreFinal);

                            byte[] data = package.GetAsByteArray();
                            System.IO.File.WriteAllBytes(pathGenerado, data);
                            archivo = "/Archivos/Plantilla/Capacitacion/Temp/" + nombreFinal;

                            try
                            {
                                foreach (string fileRpt in Directory.GetFiles(Server.MapPath(folderTemp)))
                                {
                                    FileInfo flInfo = new FileInfo(fileRpt);
                                    if (flInfo.CreationTime <= DateTime.Now.AddDays(-1))
                                    {
                                        System.IO.File.Delete(flInfo.FullName);
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }

                        }
                        success = true;
                    }
                    else
                    {
                        success = false;
                        message = "No existe archivo";
                    }
                }
                else
                {
                    success = false;
                    message = "No existe archivo";
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;

            }

            return Json(new { success, message, archivo, cantidad = countConstanciasActualizadas });

        }
        private void AgregarResultado(ExcelWorksheet workSheet, int row, int column, string resultado)
        {
            workSheet.Cells[row, column].Value = resultado;
            if (resultado == "OK") workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
            else workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Red);

        }
        public void AsignarConstanciasMasiva(string codCapacitacion, string codPersona, string codTipoParticipante, string nroConstancia, out bool flagResultado, out string msjResultado)
        {
            string nuevoCodigoConstancia;
            string nombrePlantilla = "Capacitacion_Constancia_PlantillaParticipante.docx";
            string folderPlantilla = "~/Archivos/Plantilla/Capacitacion";
            string folderBase = "~/Archivos/CapConstancias";
            string folderTemp = folderBase + "/Temp";
            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;
            byte[] bytePlantilla = null;
            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;
            flagResultado = false;
            msjResultado = string.Empty;
            try
            {
                CLogica exeCap = new CLogica();
                var participante = exeCap.ParticipanteObtener(codCapacitacion, codTipoParticipante, codPersona);
                if (participante == null) throw new Exception("Participante no existe");
                if (!string.IsNullOrEmpty(participante.COD_CONSTANCIA_CAP))
                {
                    throw new Exception("Participante ya tiene constania asignada");
                }
                var constancia = exeCap.ConstanciaObtenerPorNroConstancia(nroConstancia);
                if (constancia == null)
                {
                    throw new Exception("Constancia seleccionada no existe");
                }
                if (constancia.FLAG_ASIGNADO >= 1)
                {
                    throw new Exception($"La constancia {constancia.NRO_CONSTANCIA} ya ha sido asignada");
                }
                if (constancia.ESTADO != 1)
                {
                    throw new Exception($"La constancia {constancia.NRO_CONSTANCIA} esta eliminada");
                }
                var capacitacion = exeCap.ObtenerPorId(codCapacitacion);
                if (capacitacion == null)
                {
                    throw new Exception("Capacitación no existe");
                }
                //validando existencia de plantilla de constancias
                try
                {
                    bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderPlantilla), nombrePlantilla));

                    if (!Directory.Exists(Server.MapPath(folderBase)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderBase));
                    }
                    if (!Directory.Exists(Server.MapPath(folderTemp)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderTemp));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al leer la plantilla de constancia");
                }
                nuevoCodigoConstancia = Guid.NewGuid().ToString();
                pathDestinoWord = Path.Combine(Server.MapPath(folderTemp), $"{nuevoCodigoConstancia}.docx");
                pathDestinoPdf = Path.Combine(Server.MapPath(folderBase), $"{nuevoCodigoConstancia}.pdf");
                nuevoCodigoConstancia = nuevoCodigoConstancia + ".pdf";
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                    using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(mem, true))
                    {
                        var body = wordDoc.MainDocumentPart.Document.Body;
                        var paras = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
                        var tables = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Table>();
                        string persona = participante.NOMBRES?.ToUpper() + " " + participante.APE_PATERNO?.ToUpper() + " " + participante.APE_MATERNO?.ToUpper();
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_PARTICIPANTE", persona);
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_TIPOTALLER", capacitacion.CAPATIPO.ToLower());
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_NOMBRETALLER", capacitacion.NOMBRE.Replace("\"", "").Replace("“", "").Replace("”", ""));
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_DIRIGIDO", capacitacion.DIRIGIDO.ToLower());

                        HelperWord.BuscarReemplazarTexto(paras, "VAR_MODALIDAD", constancia.MODALIDAD.ToLower());

                        HelperWord.BuscarReemplazarTexto(paras, "VAR_HORAE", " " + capacitacion.DURACION.ToString() + " ");
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_LUGARE", capacitacion.LUGAR);
                        if (!string.IsNullOrEmpty(capacitacion.FECHA_INICIO.ToString()))
                        {
                            fechaInicio = Convert.ToDateTime(capacitacion.FECHA_INICIO);
                        }
                        if (!string.IsNullOrEmpty(capacitacion.FECHA_TERMINO.ToString()))
                        {
                            fechaFin = Convert.ToDateTime(capacitacion.FECHA_TERMINO);
                        }
                        if (fechaInicio != null && fechaFin != null)
                        {
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", " del " + fechaInicio.Value.ToString("dd/MM/yyyy") + " al " + fechaFin.Value.ToString("dd/MM/yyyy"));
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                        }
                        if (fechaInicio != null)
                        {
                            if (fechaInicio != null && fechaFin == null)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                            }

                            if (fechaInicio != null && fechaFin != null)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", " del " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)) + " al " + HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                            }
                            if (fechaInicio == fechaFin)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                            }

                        }

                        else
                        {
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día ..............");
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", " ..............");
                        }
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_NUMC", constancia.NRO_CONSTANCIA);
                        HelperWord.SearchAndReplace(wordDoc, "VAR_NUMC", constancia.NRO_CONSTANCIA, true);


                        wordDoc.Close();
                    }
                    this.GuardarMemoryStream(mem, pathDestinoWord);
                    //  this.GenerarPDF(pathDestinoWord, pathDestinoPdf, inscripcionId);
                    this.GenerarPDF(pathDestinoWord, pathDestinoPdf);
                }
                this.EliminarArchivo(pathDestinoWord);

                //actualizando participante y constancia codCapacitacion, codTipoParticipante, codPersona
                var result = exeCap.ParticipanteAsignarConstancia(codCapacitacion, codTipoParticipante, codPersona, constancia.COD_CONSTANCIA, nuevoCodigoConstancia, (ModelSession.GetSession())[0].COD_UCUENTA, DateTime.Now);

                string folderEli = folderBase + "/Eliminados";
                if (!Directory.Exists(Server.MapPath(folderEli)))
                {
                    Directory.CreateDirectory(Server.MapPath(folderEli));
                }
                string pathOrigenDoc = Path.Combine(Server.MapPath(folderBase), $"{constancia.ARCHIVO_COD}");
                string pathDestinoDoc = Path.Combine(Server.MapPath(folderEli), $"{constancia.ARCHIVO_COD}");
                if (System.IO.File.Exists(pathOrigenDoc))
                {
                    System.IO.File.Move(pathOrigenDoc, pathDestinoDoc);
                }
                flagResultado = true;
                msjResultado = "Constancia Actualizado Correctamente";
            }
            catch (Exception ex)
            {
                flagResultado = false;
                msjResultado = ex.Message;
            }
        }
        [HttpGet]
        public JsonResult RegenerarConstancia(string codCapacitacion, string codConstancia)
        {
            bool success = false;
            string message = string.Empty;
            bool flagResultado; string msjResultado;
            try
            {
                ProcesoReGenerarConstancia(codCapacitacion, codConstancia, out flagResultado, out msjResultado);
                success = flagResultado;
                message = msjResultado;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult RegenerarConstancias(string codCapacitacion)
        {
            bool success = false;
            string message = string.Empty;
            bool flagResultado; string msjResultado;
            int countConstanciasActualizadas = 0;
            try
            {
                CLogica exeCap = new CLogica();

                var constancias = exeCap.ConstanciaListar(codCapacitacion, 1);

                var costanciasRegenerar = constancias.Where(x => x.ESTADO == 1 && x.FLAG_ASIGNADO == 1);

                var costanciasRegenerarSinAsignar = constancias.Where(x => x.ESTADO == 1 && x.FLAG_ASIGNADO == 0); //pendiente a implementar la regeneracion 

                foreach (var item in costanciasRegenerar)
                {
                    ProcesoReGenerarConstancia(codCapacitacion, item.COD_CONSTANCIA, out flagResultado, out msjResultado);

                    if (flagResultado)
                    {
                        countConstanciasActualizadas++;
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message, cantidad = countConstanciasActualizadas }, JsonRequestBehavior.AllowGet);
        }

        public void ProcesoReGenerarConstancia(string codCapacitacion, string codConstancia, out bool flagResultado, out string msjResultado)
        {
            string nuevoCodigoConstancia;
            string nombrePlantilla = "Capacitacion_Constancia_PlantillaParticipante.docx";
            string folderPlantilla = "~/Archivos/Plantilla/Capacitacion";
            string folderBase = "~/Archivos/CapConstancias";
            string folderTemp = folderBase + "/Temp";
            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;
            byte[] bytePlantilla = null;
            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;
            flagResultado = false;
            msjResultado = string.Empty;
            try
            {
                CLogica exeCap = new CLogica();
                var participante = exeCap.ParticipanteObtenerPorConstancia(codCapacitacion, codConstancia);
                if (participante == null) throw new Exception("Participante no existe");

                var constancia = exeCap.ConstanciaObtener(codConstancia);
                if (constancia == null)
                {
                    throw new Exception("Constancia seleccionada no existe");
                }
                if (constancia.FLAG_ASIGNADO < 1)
                {
                    throw new Exception($"La constancia {constancia.NRO_CONSTANCIA} no esta asignada para continuar con el proceso de actualización");
                }
                if (constancia.ESTADO != 1)
                {
                    throw new Exception($"La constancia {constancia.NRO_CONSTANCIA} esta eliminada");
                }
                var capacitacion = exeCap.ObtenerPorId(codCapacitacion);
                if (capacitacion == null)
                {
                    throw new Exception("Capacitación no existe");
                }
                //validando existencia de plantilla de constancias
                try
                {
                    bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderPlantilla), nombrePlantilla));

                    if (!Directory.Exists(Server.MapPath(folderBase)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderBase));
                    }
                    if (!Directory.Exists(Server.MapPath(folderTemp)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderTemp));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al leer la plantilla de constancia");
                }
                nuevoCodigoConstancia = Guid.NewGuid().ToString();
                pathDestinoWord = Path.Combine(Server.MapPath(folderTemp), $"{nuevoCodigoConstancia}.docx");
                pathDestinoPdf = Path.Combine(Server.MapPath(folderBase), $"{nuevoCodigoConstancia}.pdf");
                nuevoCodigoConstancia = nuevoCodigoConstancia + ".pdf";
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                    using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(mem, true))
                    {
                        var body = wordDoc.MainDocumentPart.Document.Body;
                        var paras = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
                        var tables = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Table>();
                        string persona = participante.NOMBRES?.ToUpper() + " " + participante.APE_PATERNO?.ToUpper() + " " + participante.APE_MATERNO?.ToUpper();
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_PARTICIPANTE", persona);
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_TIPOTALLER", capacitacion.CAPATIPO.ToLower());
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_NOMBRETALLER", capacitacion.NOMBRE.Replace("\"", "").Replace("“", "").Replace("”", ""));
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_DIRIGIDO", capacitacion.DIRIGIDO.ToLower());

                        HelperWord.BuscarReemplazarTexto(paras, "VAR_MODALIDAD", constancia.MODALIDAD.ToLower());

                        HelperWord.BuscarReemplazarTexto(paras, "VAR_HORAE", " " + capacitacion.DURACION.ToString() + " ");
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_LUGARE", capacitacion.SECTOR);
                        if (!string.IsNullOrEmpty(capacitacion.FECHA_INICIO.ToString()))
                        {
                            fechaInicio = Convert.ToDateTime(capacitacion.FECHA_INICIO);
                        }
                        if (!string.IsNullOrEmpty(capacitacion.FECHA_TERMINO.ToString()))
                        {
                            fechaFin = Convert.ToDateTime(capacitacion.FECHA_TERMINO);
                        }

                        if (fechaInicio != null)
                        {
                            if (fechaInicio != null && fechaFin == null)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                            }

                            if (fechaInicio != null && fechaFin != null)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "del " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)) + " al " + HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaFin.Value)));
                            }
                            if (fechaInicio == fechaFin)
                            {
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día " + HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                                HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", HelperWord.FechaLetras(Convert.ToDateTime(fechaInicio.Value)));
                            }

                        }

                        else
                        {
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHATALLER", "el día ..............");
                            HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHAE", " ..............");
                        }
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_NUMC", constancia.NRO_CONSTANCIA);
                        HelperWord.SearchAndReplace(wordDoc, "VAR_NUMC", constancia.NRO_CONSTANCIA, true);


                        wordDoc.Close();
                    }
                    this.GuardarMemoryStream(mem, pathDestinoWord);
                    this.GenerarPDF(pathDestinoWord, pathDestinoPdf);
                }
                this.EliminarArchivo(pathDestinoWord);

                //actualizando participante y constancia codCapacitacion, codTipoParticipante, codPersona
                var result = exeCap.ParticipanteAsignarConstancia(codCapacitacion, participante.MAE_COD_TIPOPARTICIPANTE, participante.COD_PERSONA, constancia.COD_CONSTANCIA, nuevoCodigoConstancia, (ModelSession.GetSession())[0].COD_UCUENTA, DateTime.Now);

                string folderEli = folderBase + "/Eliminados";
                if (!Directory.Exists(Server.MapPath(folderEli)))
                {
                    Directory.CreateDirectory(Server.MapPath(folderEli));
                }
                string pathOrigenDoc = Path.Combine(Server.MapPath(folderBase), $"{constancia.ARCHIVO_COD}");
                string pathDestinoDoc = Path.Combine(Server.MapPath(folderEli), $"{constancia.ARCHIVO_COD}");
                if (System.IO.File.Exists(pathOrigenDoc))
                {
                    System.IO.File.Move(pathOrigenDoc, pathDestinoDoc);
                }
                flagResultado = true;
                msjResultado = "Constancia regenerado Correctamente";
            }
            catch (Exception ex)
            {
                flagResultado = false;
                msjResultado = ex.Message;
            }
        }
        #endregion
    }
}