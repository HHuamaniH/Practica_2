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
                if ("CAPACITACION"==asFormulario)
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
    }
}