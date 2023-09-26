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
    public class ManPAUController : Controller
    {
        Log_PAU_Digital CLogInforme;

        [HttpGet]
        public JsonResult ObtenerConfiguracion()
        {
            CLogInforme = new Log_PAU_Digital();
            var infracciones = CLogInforme.ListarInfracciones();
            var causales_caducidad = CLogInforme.ListarCausalesCaducidad();
            var result = new { infracciones, causales_caducidad };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRSD(VM_RSD_DIGITAL informeDigital)
        {
            bool success = false; string msj = "";
            VM_RSD_DIGITAL result = new VM_RSD_DIGITAL();
            try
            {
                CLogInforme = new Log_PAU_Digital();
                informeDigital.COD_USUARIO_OPERACION = (ModelSession.GetSession())[0].COD_UCUENTA;

                result.COD_INFORME_DIGITAL = CLogInforme.RegRSDGrabar(informeDigital);
                result = CLogInforme.ObtenerRSD(informeDigital.COD_RES_SUB); // COD_RESOLUCION

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
        public JsonResult ListarPlanesManejo(string COD_INFORME, string COD_THABILITANTE, int? NUM_POA, string V_OPCION)
        {
            CLogInforme = new Log_PAU_Digital();
            var result = CLogInforme.ListarPlanesManejo(COD_INFORME, COD_THABILITANTE, NUM_POA, V_OPCION);
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
                    //string codInformeDigital = Request["codInformeDigital"].ToString();
                    string pathGenerado = "";

                    if (!Directory.Exists(pathDocumento))
                    {
                        Directory.CreateDirectory(pathDocumento);
                    }
                    HttpPostedFileBase file = Request.Files[0];

                    pathGenerado = Path.Combine(pathDocumento, $"{documentName}");

                    /*if (System.IO.File.Exists(pathGenerado))
                    {
                        return Json(new { success = true, msj = "El archivo ya se encuentra cargado al sistema" });
                    }*/
                    file.SaveAs(pathGenerado);

                    //cambiando estado 3 - Cargado archivo 
                    //new Log_Informe_Digital().CambiarEstado(codInformeDigital, DateTime.Now, 3, usuarioLogin.COD_UCUENTA);

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

        [HttpPost]
        public JsonResult ObtenerRSD(string COD_RESOLUCION)
        {
            CLogInforme = new Log_PAU_Digital();
            //var cabecera = CLogInforme.ObtenerRSDCabecera(COD_RESOLUCION);
            var informe = CLogInforme.ObtenerRSD(COD_RESOLUCION);
            var inf_supervision = CLogInforme.ObtenerRSDCabeceraByReferencia(COD_RESOLUCION, 3);
            return Json(new { informe, inf_supervision }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarReferencia(string NRO_REFERENCIA, int TIPO)
        {
            CLogInforme = new Log_PAU_Digital();
            var data = CLogInforme.ObtenerRSDCabeceraByReferencia(NRO_REFERENCIA, TIPO);
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }        

        [HttpPost, ValidateInput(false)]
        public JsonResult Notificar(RSD_Notificacion notificacion)
        {
            CLogInforme = new Log_PAU_Digital();
            string result = CLogInforme.NotificarRSD(notificacion);

            return Json(result);
        }

        [HttpPost]
        public JsonResult RSDFirmaActualizar(List<VM_RSD_DIGITAL_FIRMA> participantes)
        {
            CLogInforme = new Log_PAU_Digital();
            foreach (var item in participantes)
            {
                CLogInforme.RSDFirmaActualizar(item);
            }

            return Json(true);
        }

        [HttpGet]
        public ActionResult PlantillaInforme()
        {
            return PartialView("~/Areas/Fiscalizacion/Views/ManPAU/templates/_tmplRSDInforme.cshtml");
        }

        public PartialViewResult TemplateRSDObligaciones()
        {
            return PartialView("~/Areas/Fiscalizacion/Views/ManPAU/templates/_tmplRSDObligaciones.cshtml");
        }

        [HttpPost]
        public JsonResult AnularFirmaPorInforme(string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            try
            {
                string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
                //var usuarioLogin = ModelSession.GetSession().FirstOrDefault();

                CLogInforme = new Log_PAU_Digital();
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
                    Log_PAU_Digital logInforme = new Log_PAU_Digital();
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

        [HttpPost]
        public JsonResult TransferirDocSITD(int tramiteId, string codInformeDigital, string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            string pathDocumentoOrigen = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInvoker"]);
            string pathDocumentoDestino = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathTransferidoSITD"]);
            string pathGeneradoOrigen = string.Empty, pathGeneradoDestino = string.Empty, nombreDocumentoNuevo = string.Empty;
            Log_PAU_Digital CLogInforme = null;
            try
            {
                var usuarioLogin = ModelSession.GetSession().FirstOrDefault();
                CLogInforme = new Log_PAU_Digital();

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