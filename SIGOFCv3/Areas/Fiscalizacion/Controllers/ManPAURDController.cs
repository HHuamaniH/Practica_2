using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManPAURDController : Controller
    {
        Log_PAU_RD_Digital CLogInforme;        

        [HttpPost]
        public JsonResult GuardarRD(VM_PAU_RD_DIGITAL informeDigital)
        {
            bool success = false; string msj = "";
            VM_PAU_RD_DIGITAL result = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    // Acceder a los errores de validación
                    var erroresDeValidacion = ModelState
                    .Where(v => v.Value.Errors.Any())
                    .SelectMany(kvp => kvp.Value.Errors.Select(e => new { Key = kvp.Key, Value = e.ErrorMessage }))
                    .ToList();

                    throw new Exception($"Datos inválidos en el modelo:<br> {string.Join("<br>", erroresDeValidacion.Select(x => x.Key + ": " + x.Value))}");
                }

                CLogInforme = new Log_PAU_RD_Digital();
                informeDigital.COD_USUARIO_OPERACION = (ModelSession.GetSession())[0].COD_UCUENTA;

                result = new VM_PAU_RD_DIGITAL();
                result.COD_INFORME_DIGITAL = CLogInforme.RegRDGrabar(informeDigital);
                result = CLogInforme.ObtenerRD(informeDigital.COD_RESOLUCION); // COD_RESOLUCION

                success = true;
                msj = "Datos guardados Correctamente";
            }
            catch (Exception ex)
            {
                success = false;
                msj = ex.Message ?? "Error al guardar los datos";
            }

            return Json(new { success, msj, data = result });
        }

        [HttpGet]
        public JsonResult ObtenerResumenInformeLegal(string COD_ILEGAL)
        {
            CLogInforme = new Log_PAU_RD_Digital();
            var result = CLogInforme.ObtenerResumenInformeLegal(COD_ILEGAL);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CargarDocumento()
        {
            string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
            if (Request.Files.Count > 0)
            {
                try
                {
                    var usuarioLogin = (ModelSession.GetSession())[0];
                    string documentName = Request["documentName"].ToString();

                    if (documentName.IndexOfAny(Path.GetInvalidFileNameChars()) > -1)
                    {
                        throw new Exception("El nombre del archivo a cargar es incorrecto");
                    }

                    string pathGenerado = "";

                    if (!Directory.Exists(pathDocumento))
                    {
                        Directory.CreateDirectory(pathDocumento);
                    }
                    HttpPostedFileBase file = Request.Files[0];

                    pathGenerado = Path.Combine(pathDocumento, $"{documentName}");

                    file.SaveAs(pathGenerado);

                    return Json(new { fileName = documentName, success = true, msj = "Archivo subido correctamente" });
                }
                catch (Exception)
                {
                    return Json(new { success = false, msj = "Sucedió un error al subir el archivo" });
                }
            }
            else
            {
                return Json(new { success = false, msj = "Seleccione un archivo correctamente" });
            }
        }

        [HttpGet]
        public JsonResult ObtenerRD(string COD_RESOLUCION)
        {
            CLogInforme = new Log_PAU_RD_Digital();
            var informe = CLogInforme.ObtenerRD(COD_RESOLUCION);

            return Json(new { informe }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerAntecedentes(string COD_RESOLUCION)
        {
            CLogInforme = new Log_PAU_RD_Digital();
            var result = CLogInforme.ObtenerAntecedentes(COD_RESOLUCION);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Notificar(VM_PAU_DIGITAL_ALERTA notificacion)
        {
            CLogInforme = new Log_PAU_RD_Digital();
            string result = CLogInforme.Notificar(notificacion);

            return Json(result);
        }

        [HttpPost]
        public JsonResult ParticipanteActualizar(List<VM_PAU_RD_DIGITAL_PARTICIPANTE> participantes)
        {
            CLogInforme = new Log_PAU_RD_Digital();
            foreach (var item in participantes)
            {
                CLogInforme.ParticipanteActualizar(item);
            }

            return Json(true);
        }

        [HttpGet]
        public ActionResult PlantillaInforme()
        {
            return PartialView("~/Areas/Fiscalizacion/Views/ManPAURD/templates/_tmplRDInforme.cshtml");
        }

        [HttpGet]
        public ActionResult ObtenerInfraccion(string modalidad, string inciso)
        {
            string name = $"~/Areas/Fiscalizacion/Views/ManPAURD/templates/{modalidad}/infracciones/inciso_{inciso}.cshtml";

            ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
            if (result.View == null) return Content($"<p>No se encontró información de la infracción para el inciso {inciso}</p>");

            return PartialView(name);
        }

        [HttpPost]
        public JsonResult AnularFirmaPorInforme(string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            try
            {
                string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
                //var usuarioLogin = ModelSession.GetSession().FirstOrDefault();

                CLogInforme = new Log_PAU_RD_Digital();
                success = CLogInforme.AnularFirmaPorInforme(codInforme);
                if (success)
                {
                    string pathGenerado = Path.Combine(pathDocumento, $"{codificacion}");
                    if (System.IO.File.Exists(pathGenerado)) System.IO.File.Delete(pathGenerado);
                }
                msj = "Se anularon las firmas correctamente";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al anular firmas";
            }

            return Json(new { success, msj });
        }

        [HttpGet]
        public JsonResult TramiteGetById(int id, string codTHabilitante = "", string codInforme = "")
        {
            bool success = true; string msj = "";
            VM_TRAMITE tramite = new Log_Informe_Digital().TramiteGetById(id, codTHabilitante, codInforme);
            return Json(new { success, msj, data = tramite }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TramiteGeneralByCriterio(string criterio, string valor = "")
        {
            bool success = true; string msj = "";
            var data = new Log_Informe_Digital().TramiteGeneralListar_Dictionary(criterio, valor);
            return Json(new { success, msj, data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TramiteGeneral()
        {
            bool success = true; string msj = "";
            Log_Informe_Digital oLog_Informe_Digital = new Log_Informe_Digital();
            var oficina = oLog_Informe_Digital.TramiteGeneralListar("OFICINA_PAU", "");
            var tipoDocumento = oLog_Informe_Digital.TramiteGeneralListar("PAU_DIGITAL_DOC", "");
            var indicacion = oLog_Informe_Digital.TramiteGeneralListar("INDICACION_MOTIVO", "");
            var prioridad = new List<VM_Cbo>() {
                new VM_Cbo { Value = "Alta", Text = "Alta" },
                new VM_Cbo { Value="Media",Text="Media"},
                new VM_Cbo { Value="Baja",Text="Baja"}
            };
            return Json(new { success, msj, oficina, tipoDocumento, indicacion, prioridad }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TramiteGuardar(VM_TRAMITE tramite)
        {
            bool success = false; string msj = "";
            VM_TRAMITE tramiteVerificar = null;

            try
            {
                Log_Informe_Digital oLog_Informe_Digital = new Log_Informe_Digital();
                tramiteVerificar = oLog_Informe_Digital.TramiteGetById(tramite.iCodTramite, tramite.cod_THabilitante, tramite.cod_Informe);

                if (tramiteVerificar == null)
                {
                    //Obtener el usuario que realiza el registro
                    tramite.cUsuario = (ModelSession.GetSession())[0].USUARIO_LOGIN;

                    tramite.iCodTramite = oLog_Informe_Digital.TramiteGrabar(tramite);

                    //Obtenemos los datos grabados
                    tramite = oLog_Informe_Digital.TramiteGetById(tramite.iCodTramite, tramite.cod_THabilitante, tramite.cod_Informe);
                }
                else
                {
                    tramite = tramiteVerificar;
                }

                if (tramite.iCodTramite > 0)
                {
                    //actualizando número de informe
                    Log_PAU_RD_Digital logInforme = new Log_PAU_RD_Digital();
                    logInforme.ModificarNumeroInforme(tramite.cod_Informe, tramite.cCodificacion, tramite.fechaRegistro);

                    success = true;
                    msj = "Datos guardados Correctamente";
                }
                else
                {
                    success = false;
                    msj = "Error al guardar los datos";
                }

            }
            catch (Exception ex)
            {
                success = false;
                msj = ex.Message;
            }

            return Json(new { success, msj, data = tramite, iCodTramite = tramite.iCodTramite });
        }

        [HttpPost]
        public JsonResult TramiteModificar(VM_TRAMITE tramite)
        {
            bool success = false; string msj = "";
            try
            {
                Log_Informe_Digital CLogInforme = new Log_Informe_Digital();
                CLogInforme.TramiteModificar(tramite);
                success = true;
                msj = "Datos actualizados Correctamente";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al actualizar los datos";
            }

            return Json(new { success, msj });
        }

        [HttpPost]
        public JsonResult TransferirDocSITD(int tramiteId, string codInformeDigital, string codificacion)
        {
            bool success = false; string msj = "";
            string pathDocumentoOrigen = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
            string pathDocumentoDestino = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathTransferidoSITD"]);
            string pathGeneradoOrigen = string.Empty,
                pathGeneradoDestino = string.Empty,
                nombreDocumentoNuevo = string.Empty;

            Log_PAU_RD_Digital CLogInforme = null;

            try
            {
                var usuarioLogin = ModelSession.GetSession().FirstOrDefault();
                CLogInforme = new Log_PAU_RD_Digital();

                pathGeneradoOrigen = Path.Combine(pathDocumentoOrigen, $"{codificacion}");
                if (!System.IO.File.Exists(pathGeneradoOrigen))
                {
                    throw new Exception($"0|No existe el documento {codificacion} a transferir");
                }
                if (!Directory.Exists(pathDocumentoDestino))
                {
                    Directory.CreateDirectory(pathDocumentoDestino);
                }

                VM_TRAMITE tramite = new Log_Informe_Digital().TramiteGetById(tramiteId, "", "");
                tramite.cDescTipoDoc = tramite.cDescTipoDoc.Trim().Replace(' ', '-');
                tramite.cCodificacion = tramite.cCodificacion.Trim().Replace('/', '-');
                nombreDocumentoNuevo = $"{tramite.cDescTipoDoc}-{tramite.cCodificacion}.pdf";
                pathGeneradoDestino = Path.Combine(pathDocumentoDestino, nombreDocumentoNuevo);

                //cambiando de ubicación el archivo
                try
                {
                    if (System.IO.File.Exists(pathGeneradoDestino))
                    {
                        System.IO.File.Delete(pathGeneradoDestino);
                    }
                    System.IO.File.Move(pathGeneradoOrigen, pathGeneradoDestino);
                }
                catch (Exception)
                {
                    throw new Exception($"0|Sucedió un error al mover el archivo al repositorio de trámite");
                }

                //cambiando a estado 5 Transferido documento a trámite
                success = CLogInforme.CambiarEstado(codInformeDigital, DateTime.Now, 5, usuarioLogin.COD_UCUENTA);

                if (success)
                {
                    var oLog_Informe_Digital = new Log_Informe_Digital();
                    oLog_Informe_Digital.TramiteDigitalGrabar(tramiteId, codificacion, nombreDocumentoNuevo, DateTime.Now);
                }

                msj = "Se transfirió correctamente el documento";
            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                else msj = "Sucedió un error, no se puede continuar";
            }

            return Json(new { success, msj });
        }
    }

}