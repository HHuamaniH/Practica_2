using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using CapaLogica.Documento;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public JsonResult ObtenerIFI(string COD_RESOLUCION)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            var informe = oLog_Informe_Legal_Digital.ObtenerInforme(COD_RESOLUCION);
            //var inf_supervision = oLog_Informe_Legal_Digital.ObtenerRSDCabeceraByReferencia(COD_RESOLUCION, 3);
            return Json(new { informe }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerCorreos(List<string> CPERSONAS)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();
            List<VM_PERSONA_DET_CORREO> result = new List<VM_PERSONA_DET_CORREO>();

            foreach (var COD_PERSONA in CPERSONAS)
            {
                var data = oLog_Informe_Legal_Digital.PersonaCorreo(COD_PERSONA);
                if (data != null) result.Add(data);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PlantillaInforme()
        {
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/templates/_tmplInforme.cshtml");
        }

        [HttpGet]
        public ActionResult ObtenerInfraccion(string inciso)
        {
            string name = $"~/Areas/Fiscalizacion/Views/InformeLegal/templates/infracciones/inciso_{inciso}.cshtml";

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
        public JsonResult Notificar(Informe_Notificacion notificacion, List<VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE> participantes)
        {
            oLog_Informe_Legal_Digital = new Log_Informe_Legal_Digital();

            var result = oLog_Informe_Legal_Digital.Notificar(notificacion);

            if (!string.IsNullOrEmpty(result))
            {
                foreach (var item in participantes)
                {
                    oLog_Informe_Legal_Digital.ParticipanteActualizar(item);
                }
            }

            return Json(result);
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

    }
}
