using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using CapaLogica.Documento;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class InformeLegalDigitalController : Controller
    {
        Log_Informe_Legal_Digital oLog_Informe_Legal_Digital;

        [HttpPost]
        public JsonResult GuardarIFI(VM_INFORME_LEGAL_DIGITAL informeDigital)
        {
            bool success = false; string msj = "";
            VM_INFORME_LEGAL_DIGITAL result = new VM_INFORME_LEGAL_DIGITAL();
            try
            {
                oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
                informeDigital.COD_USUARIO_OPERACION = (ModelSession.GetSession())[0].COD_UCUENTA;

                result.COD_INFORME_DIGITAL = oLog_Informe_Legal_Digital.RegInformeGrabar(informeDigital);
                result = oLog_Informe_Legal_Digital.ObtenerInforme(informeDigital.COD_INFORME); // COD_RESOLUCION

                success = true;
                msj = "Datos guardados Correctamente";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al guardar los datos";
            }

            return Json(new { success, msj, data = result });
        }

        [HttpGet]
        public JsonResult ObtenerIFI(string COD_RESOLUCION)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            var informe = oLog_Informe_Legal_Digital.ObtenerInforme(COD_RESOLUCION);
            //var inf_supervision = oLog_Informe_Legal_Digital.ObtenerRSDCabeceraByReferencia(COD_RESOLUCION, 3);
            return Json(new { informe }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerAntecedentes(string COD_RESOLUCION, string COD_THABILITANTE)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            var result = oLog_Informe_Legal_Digital.ObtenerAntecedentesRSD(COD_RESOLUCION, COD_THABILITANTE);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerExpediente(string NRO_DOCUMENTO)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            var result = oLog_Informe_Legal_Digital.ObtenerExpedienteSITD(NRO_DOCUMENTO);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PlantillaInforme()
        {
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/templates/_tmplInforme.cshtml");
        }

        [HttpGet]
        public ActionResult ObtenerInfraccion(string modalidad, string inciso)
        {
            string name = $"~/Areas/Fiscalizacion/Views/InformeLegal/templates/{modalidad}/infracciones/inciso_{inciso}.cshtml";

            ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
            if (result.View == null) return Content($"<h5>No se encontró información de la infracción para el inciso {inciso}</h5>");

            return PartialView(name);
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
                    Log_Informe_Legal_Digital logInforme = new Log_Informe_Legal_Digital();
                    logInforme.ModificarNumeroInforme(tramite.cod_Informe, tramite.cCodificacion, DateTime.Now);

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

        [HttpPost, ValidateInput(false)]
        public JsonResult Notificar(Informe_Notificacion notificacion)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            var result = oLog_Informe_Legal_Digital.Notificar(notificacion);            
            return Json(result);
        }

        [HttpPost]
        public JsonResult ParticipanteActualizar(List<VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE> participantes)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            foreach (var item in participantes)
            {
                oLog_Informe_Legal_Digital.ParticipanteActualizar(item);
            }

            return Json(true);
        }

        [HttpGet]
        public JsonResult ExtraerOpcionesBuscarRSD()
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();

            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = "RESOLUCION_SUBDIRECTORAL";

            var result = HelperSigo.LLenarCombos(exeBus.RegOpcionesCombo(paramsBus), "");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TransferirDocSITD(int tramiteId, string codInformeDigital, string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            string pathDocumentoOrigen = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
            string pathDocumentoDestino = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathTransferidoSITD"]);
            string pathGeneradoOrigen = string.Empty, pathGeneradoDestino = string.Empty, nombreDocumentoNuevo = string.Empty;
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            try
            {
                var usuarioLogin = ModelSession.GetSession().FirstOrDefault();               

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
                success = oLog_Informe_Legal_Digital.CambiarEstado(codInformeDigital, DateTime.Now, 5, usuarioLogin.COD_UCUENTA);

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

        [HttpPost]
        public JsonResult AnularFirmaPorInforme(string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            try
            {
                string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
                //var usuarioLogin = ModelSession.GetSession().FirstOrDefault();

                oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
                success = oLog_Informe_Legal_Digital.AnularFirmaPorInforme(codInforme);
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
        public JsonResult RegMostrarInfoDocumentResumenSupervisado(string COD_RESOLUCION)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            var result = oLog_Informe_Legal_Digital.RegMostrarInfoDocumentResumenSupervisado(COD_RESOLUCION);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
