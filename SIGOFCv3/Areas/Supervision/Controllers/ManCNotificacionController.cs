using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Areas.Supervision.Models.ManCNotificacion;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_CNOTIFICACION;
using CEntVM = CapaEntidad.ViewModel.VM_CartaNotificacion;
using CLogica = CapaLogica.DOC.Log_CNOTIFICACION;
using CLogicaP = CapaLogica.DOC.Log_Persona;
using CEntidadP = CapaEntidad.DOC.Ent_Persona;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManCNotificacionController : Controller
    {
        #region "Vista General"
        // GET: Supervision/ManCNotificacion
        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "CARTA_NOTIFICACION";
            ViewBag.TituloFormulario = "Carta de Notificación";
            ViewBag.AlertaInicial = _alertaIncial;
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual("TIPO_CNOTIFICACION", "").Where(C => C.Value != "0000000").ToList();
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Carta de Notificación");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        #endregion
        #region "Mantenimiento CNotificación"
        public ActionResult AddEdit(string asCodCNotificacion = "", string asCodTipoCN = "")
        {
            try
            {
               

                CEntVM VM_CN = new CEntVM();
                CLogica exeCn = new CLogica();
                VM_CN = exeCn.IniDatosCNotificacion(asCodCNotificacion, asCodTipoCN, (ModelSession.GetSession())[0].COD_UCUENTA);
                
                TempData["tbPoaPo_Dema"] = VM_CN.tbPoaPo_Dema;
                VM_CN.tbPoaPo_Dema = null;
                TempData["tbDevolMadera"] = VM_CN.tbDevolMadera;
                VM_CN.tbDevolMadera = null;
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Carta de Notificación");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Actualizamos el valor para el control de calidad
                VM_CN.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                //Datos para las vistas de los datos del Titular
                CEntidadP entP = new CEntidadP();
                entP.BusFormulario = "PERSONA";
                entP.BusValor = "A";
                entP.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                entP = (new CLogicaP()).RegMostCombo(entP);
                ViewBag.ddlMItemTelefono_TTelefono = entP.ListCTipoTelefono.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                ViewBag.ddlMItemCorreo_TCorreo = entP.ListCTipoCorreo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                

                return View(VM_CN);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult AddEdit(CEntVM dto)
        {
            CLogica exePCap = new CLogica();
            ListResult result = exePCap.GuardarDatosCNotificacion(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        public JsonResult GetAllPoaPo_Dema()
        {
            var lstPoaPo_Dema = (List<CEntidad>)TempData["tbPoaPo_Dema"];

            var jsonResult = Json(new { data = lstPoaPo_Dema.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetAllDevolMadera()
        {
            var lstDevolMadera = (List<CEntidad>)TempData["tbDevolMadera"];

            var jsonResult = Json(new { data = lstDevolMadera.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /*public JsonResult GetAllPoaPo_Quinquenal()
        {
            var lstPoaPo_Quinquenal = (List<CEntidad>)TempData["tbPoaPo_Quinquenal"];
            if (lstPoaPo_Quinquenal == null)
            {
                lstPoaPo_Quinquenal = new List<CEntidad>();
            }
            var jsonResult = Json(new { data = lstPoaPo_Quinquenal.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }*/
        #endregion

        #region "Mantenimiento Muestra"
        public ActionResult Muestra(string asCodCNotificacion, string asTipoMuestra, string asCodTHabilitante)
        {
            try
            {
                CLogica exeCN = new CLogica();
                CapaEntidad.ViewModel.VM_CNotificacionMuestra vmCNot = exeCN.InitDatosCNotificacionMuestra(asCodCNotificacion, asTipoMuestra);
                vmCNot.hdfCodTHabilitante = asCodTHabilitante;

                return View(vmCNot);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        [HttpPost]
        public JsonResult Muestra(CapaEntidad.ViewModel.VM_CNotificacionMuestra dto)
        {
            CLogica exeCN = new CLogica();
            ListResult result = exeCN.GuardarDatosCNotificacionMuestra(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        [HttpPost]
        public JsonResult SaveCensoAsMuestra(string asCodCNotificacion, string asTipoMuestra)
        {
            CLogica exeCN = new CLogica();
            ListResult result = exeCN.CuardarCensoComoMuestra(asCodCNotificacion, asTipoMuestra, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        private IEnumerable<Object> SetFormatMuestraMaderable(List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodCn = item.COD_CNOTIFICACION,
                             CodTh = item.COD_THABILITANTE,
                             NumPoa = item.NUM_POA,
                             Poa = item.POA,
                             CodEsp = item.COD_ESPECIES,
                             EspCenso = item.DESC_ESPECIES,
                             EspResol = item.ESPECIES_ARESOLUCION,
                             CodSec = item.COD_SECUENCIAL,
                             Bloq = item.BLOQUE,
                             Faja = item.FAJA,
                             Cod = item.CODIGO,
                             Vol = item.VOLUMEN,
                             Dap = item.DAP,
                             Ac = item.AC,
                             Dmc = item.DMC,
                             EspCond = item.DESC_ECONDICION,
                             EspEst = item.DESC_EESTADO,
                             Zona = item.ZONA,
                             CEste = item.COORDENADA_ESTE,
                             CNorte = item.COORDENADA_NORTE,
                             EstM1 = item.ESTADO_MUESTRA,
                             EstM2 = item.ESTADO_MUESTRA2,
                             EstM3 = item.ESTADO_MUESTRA3,
                             NumM = item.NUM_MUESTRA,
                             RegEst = item.RegEstado,
                             PCA = item.PCA
                         };
            return result;
        }
        private IEnumerable<Object> SetFormatMuestraNoMaderable(List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodCn = item.COD_CNOTIFICACION,
                             CodTh = item.COD_THABILITANTE,
                             NumPoa = item.NUM_POA,
                             Poa = item.POA,
                             CodEsp = item.COD_ESPECIES,
                             EspCenso = item.DESC_ESPECIES,
                             EspResol = item.ESPECIES_ARESOLUCION,
                             CodSec = item.COD_SECUENCIAL,
                             NumEst = item.NUM_ESTRADA,
                             Cod = item.CODIGO,
                             Diam = item.DIAMETRO,
                             Alt = item.ALTURA,
                             ProLat = item.PRODUCCION_LATAS,
                             EspCond = item.DESC_ECONDICION,
                             Zona = item.ZONA,
                             CEste = item.COORDENADA_ESTE,
                             CNorte = item.COORDENADA_NORTE,
                             EstM1 = item.ESTADO_MUESTRA,
                             EstM2 = item.ESTADO_MUESTRA2,
                             EstM3 = item.ESTADO_MUESTRA3,
                             NumM = item.NUM_MUESTRA,
                             RegEst = item.RegEstado
                         };
            return result;
        }
        private IEnumerable<Object> SetFormatMuestraTroza(List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodTh = item.COD_THABILITANTE,
                             CodDev = item.COD_DEVOLUCION,
                             CodSec = item.COD_SECUENCIAL,
                             CodEsp = item.COD_ESPECIES,
                             Esp = item.ESPECIES,
                             Dap = item.DAP,
                             Cod = item.CODIGO,
                             Alt = item.ALTURA,
                             Vol = item.VOLUMEN,
                             CEste = item.COORDENADA_ESTE,
                             CNorte = item.COORDENADA_NORTE,
                             NumTro = item.NUM_TROZAS,
                             Desc = item.DESCRIPCION,
                             Obs = item.OBSERVACION,
                             EstM = item.ESTADO_MUESTRA,
                             RegEst = item.RegEstado
                         };
            return result;
        }
        private IEnumerable<Object> SetFormatMuestraTocon(List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodTh = item.COD_THABILITANTE,
                             CodDev = item.COD_DEVOLUCION,
                             CodSec = item.COD_SECUENCIAL,
                             CodEsp = item.COD_ESPECIES,
                             Esp = item.ESPECIES,
                             Cod = item.CODIGO,
                             Diam = item.DIAMETRO,
                             Lar = item.LARGO,
                             Vol = item.VOLUMEN,
                             CEste = item.COORDENADA_ESTE,
                             CNorte = item.COORDENADA_NORTE,
                             Cant = item.CANTIDAD,
                             Desc = item.DESCRIPCION,
                             Obs = item.OBSERVACION,
                             EstM = item.ESTADO_MUESTRA,
                             RegEst = item.RegEstado
                         };
            return result;
        }
        private IEnumerable<Object> SetFormatMuestraArbol(List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodTh = item.COD_THABILITANTE,
                             CodDev = item.COD_DEVOLUCION,
                             CodSec = item.COD_SECUENCIAL,
                             CodEsp = item.COD_ESPECIES,
                             Esp = item.ESPECIES,
                             Pca = item.NUM_PCA,
                             Dap = item.DAP,
                             Cod = item.CODIGO,
                             Alt = item.ALTURA,
                             Vol = item.VOLUMEN,
                             CEste = item.COORDENADA_ESTE,
                             CNorte = item.COORDENADA_NORTE,
                             EspCond = item.CONDICION,
                             EspEst = item.ESTADO,
                             Obs = item.OBSERVACION,
                             EstM = item.ESTADO_MUESTRA,
                             RegEst = item.RegEstado
                         };
            return result;
        }

        public JsonResult GetCenso(string asCodCNotificacion, string asTipoMuestra)
        {
            try
            {
                IEnumerable<Object> result = new List<Object>();
                CLogica exeCN = new CLogica();

                switch (asTipoMuestra)
                {
                    case "M":
                    case "NM":
                        CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsMad = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
                        List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCensoMad = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();
                        paramsMad.COD_CNOTIFICACION = asCodCNotificacion;

                        if (asTipoMuestra == "M")
                        {
                            lstCensoMad = exeCN.RegMostrarPoaDetMadCensoLista(paramsMad).ListSDETMADERABLE;
                            result = SetFormatMuestraMaderable(lstCensoMad);
                        }
                        else
                        {
                            lstCensoMad = exeCN.RegMostrarPoaDetNoMadCensoLista(paramsMad).ListSDETMADERABLE;
                            result = SetFormatMuestraNoMaderable(lstCensoMad);
                        }
                        break;
                    case "DTR":
                    case "DTO":
                    case "DAR":
                        CapaEntidad.DOC.Ent_DEVOLUCION_MADERA paramsDev = new CapaEntidad.DOC.Ent_DEVOLUCION_MADERA();
                        List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA> lstCensoDev = new List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA>();
                        paramsDev.COD_CNOTIFICACION = asCodCNotificacion;

                        if (asTipoMuestra == "DTR")
                        {
                            //lstCensoDev = exeCN.RegMostrarDevolDetTrozaCensoLista(paramsDev).ListSDETDEVOLUCION;
                            result = SetFormatMuestraTroza(lstCensoDev);
                        }
                        else if (asTipoMuestra == "DTO")
                        {
                            //lstCensoDev = exeCN.RegMostrarDevolDetToconCensoLista(paramsDev).ListSDETDEVOLUCION;
                            result = SetFormatMuestraTocon(lstCensoDev);
                        }
                        else
                        {
                            //lstCensoDev = exeCN.RegMostrarDevolDetArbolCensoLista(paramsDev).ListSDETDEVOLUCION;
                            result = SetFormatMuestraArbol(lstCensoDev);
                        }

                        break;
                }

                var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ExportMuestra(string asCodCNotificacion, string asTipoMuestra)
        {
            ListResult result = new ListResult();

            switch (asTipoMuestra)
            {
                case "M":
                    result = ExportarDatos.MuestraMaderable(asCodCNotificacion);
                    break;
                case "NM":
                    result = ExportarDatos.MuestraNoMaderable(asCodCNotificacion);
                    break;
                default:
                    result.success = false; result.msj = "Opción no implementada para esta muestra";
                    break;
            }

            return Json(result);
        }
        [HttpPost]
        public JsonResult ExportDatosGenerales(string asCodCNotificacion)
        {
            ListResult result = ExportarDatos.DatosGenerales(asCodCNotificacion);

            return Json(result);
        }
        [HttpPost]
        public JsonResult ImportMuestra(string asCodCNotificacion, string asTipoMuestra)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipoMuestra)
                    {
                        case "M":
                            result = SetFormatMuestraMaderable(ImportarDatos.MuestraMaderable(asCodCNotificacion, Request));
                            break;
                        case "NM":
                            result = SetFormatMuestraNoMaderable(ImportarDatos.MuestraNoMaderable(asCodCNotificacion, Request));
                            break;
                        default:
                            throw new Exception("Opción no implementada para esta muestra");
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            //return Json(new { success = true, msj = "", data = result });
            var jsonResult = Json(new { success = true, msj = "", data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
    }
}