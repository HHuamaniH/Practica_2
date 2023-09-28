using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Areas.THabilitante.Models.ManCertificadoPlanta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidadUC = CapaEntidad.GENE.Ent_USUARIO_CUENTA;
using DocumentFormat.OpenXml.Packaging;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManCertificadoPlantaController : Controller
    {
        // GET: THabilitante/ManCertificadoPlanta
        public ActionResult Index()
        {
            ViewBag.thTipoFrmulario = "CERTIFICADO_PLANTA";
            ViewBag.thBusFormulario = "CERTIFICADO_PLANTA";
            ViewBag.thTitleMenu = "Certificado de Inscripción en el Registro Nacional de Plantaciones Forestales";
            ViewBag.thBusCriterio = "TODOS";
            ViewBag.hdfTipoFormulario = "1";
            //invocamos el rol del usuario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Certificado de Plantaciones");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpGet]
        public ActionResult AddEdit(string codCertificacionPlanta)
        {
            try
            {
                VM_CertificadoPlanta objVM = new VM_CertificadoPlanta();
                Log_CertificadoPlanta objLog = new Log_CertificadoPlanta();
                CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

                int nuevo = 1; Int16 opRegresar = 0;
                string codigo = "", descripcion = "", tipoFrmulario = "", lstMenu = "";
                string appClient = Request.QueryString["appClient"]; string appData = Request.QueryString["appData"];                
                nuevo = Convert.ToInt32(Request.QueryString["nuevo"]);
                codigo = Request.QueryString["codigo"];
                descripcion = Request.QueryString["descripcion"];
                tipoFrmulario = Request.QueryString["tipoFrmulario"];//CERTIFICADO_PLANTA
                VM_Menu_Rol mr = new VM_Menu_Rol();
                //obtenemos el rol sobre el formulario
                mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "PMFI");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;                

                objVM = objLog.IniDatosCertificadoPlanta(
                   codCertificacionPlanta,
                   codigo,
                   descripcion,
                   (ModelSession.GetSession())[0].COD_UCUENTA,
                   nuevo);                
                objVM.appClient = appClient;
                objVM.appData = appData;
                objVM.opRegresar = opRegresar;
                objVM.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                ViewBag.ddlZonaUTM = exeBus.RegMostComboIndividual("ZONA_UTM", "");

                return View(objVM);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult RegistrarCertificadoPlanta(VM_CertificadoPlanta dto)
        {
            Log_CertificadoPlanta objLog = new Log_CertificadoPlanta();
            ListResult resultado;
            resultado = objLog.GuardarDatosCertificadoPlanta(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }

        #region "Especies Establecidas"
        [HttpPost]
        public PartialViewResult _EspeciesEstablecidas()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlUnidadMedida = exeBus.RegMostComboIndividual("UNIDAD_MEDIDA_ESPESTABLECIDA", "");

            return PartialView();
        }
        #endregion

        #region "Importar"
        [HttpPost]
        public JsonResult ImportarDatosCP(string asTipo)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipo)
                    {
                        case "ESPECIES_ESTABLECIDAS": result = ImportarDatos.EspeciesEstablecidas(Request); break;                       
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = result });
        }
        #endregion
    }
}