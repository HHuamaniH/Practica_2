using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Notificacion.Models.ManNotificacion;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Notificacion;
using CLogica = CapaLogica.DOC.Log_NOTIFICACION;

namespace SIGOFCv3.Areas.Notificacion.Controllers
{
    public class ManNotificacionController : Controller
    {
        private CLogica logNotificacion = new CLogica();
        private CEntVM vmNotificacion;

        // GET: Notificacion/ManNotificacion
        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "NOTIFICACION";
            ViewBag.TituloFormulario = "Notificaciones";
            ViewBag.AlertaInicial = _alertaIncial;
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual("TIPO_NOTIFICACION", "");

            return View();
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();
            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        public ActionResult AddEdit(string asCodNotificacion = "")
        {
            try
            {
                vmNotificacion = logNotificacion.InitDatos(asCodNotificacion);
                return View(vmNotificacion);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult AddEdit(CEntVM aoDto)
        {
            CLogica exePCap = new CLogica();
            ListResult result = logNotificacion.GuardarDatos(aoDto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GrabarDocumentoCargo()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    string cod_notificacion, codificacion_sitd, docOriginal, extDocOriginal, docCargo, docCargoTemp;
                    //Capturar los parámetros recibidos
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 
                    cod_notificacion = Request.Form["cod_notificacion"].ToString();
                    codificacion_sitd = Request.Form["codificacion_sitd"].ToString();

                    if (cod_notificacion != "" && codificacion_sitd.Trim() != "")
                    {
                        //Obtener el nombre y extensión del archivo recibido
                        docOriginal = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
                        docOriginal = (docOriginal.Length >= 200 ? docOriginal.Substring(0, 200) : docOriginal);
                        extDocOriginal = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1).ToLower();
                        //Generar el nombre del cargo
                        docCargo = codificacion_sitd.Trim() + "-Cargo." + extDocOriginal;
                        docCargo = docCargo.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                        docCargoTemp = codificacion_sitd.Trim() + "-Cargo_" + DateTime.Now.ToShortDateString() + "." + extDocOriginal;
                        docCargoTemp = docCargoTemp.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');

                        //En caso exista un cargo previo, se realiza una copia del cargo
                        if (System.IO.File.Exists(Path.Combine(@"\\10.10.8.136\web\STD\cAlmacenArchivosPrueba\", docCargo)))
                        {
                            System.IO.File.Copy(Path.Combine(@"\\10.10.8.136\web\STD\cAlmacenArchivosPrueba\", docCargo), Path.Combine(@"\\10.10.8.136\web\STD\cAlmacenArchivosPrueba\Coactiva\Eliminados\", docCargoTemp), true);
                        }
                        //Subir nuevo cargo a la carpeta 
                        file.SaveAs(Path.Combine(@"\\10.10.8.136\web\STD\cAlmacenArchivosPrueba\", docCargo));

                        //Grabar información del cargo en la BD
                        CapaEntidad.DOC.Ent_NOTIFICACION_CARGO oCar = new CapaEntidad.DOC.Ent_NOTIFICACION_CARGO();
                        oCar.COD_FISNOTI = cod_notificacion;
                        oCar.DOCUMENTO_CARGO = docCargo;
                        oCar.DOCUMENTO_CARGO_ORIGINAL = docOriginal;
                        logNotificacion.GrabarDocumentoCargo(oCar);
                        return Json(new { success = true, msj = "El documento se registro correctamente", data = oCar });
                    }
                    else
                    {
                        throw new Exception("Se encontro más de un error al grabar los datos del cargo [1]");
                    }
                }
                catch (Exception)
                {
                    return Json(new { success = false, msj = "Ocurrió un error al subir el cargo" });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontró el cargo a subir" });
            }
        }

        #region "Mantenimiento Muestra"
        public ActionResult Muestra(string asCodNotificacion, string asTipoMuestra, string asCodTHabilitante)
        {
            try
            {
                VM_CNotificacionMuestra vmCNot = logNotificacion.InitDatosCNotificacionMuestra(asCodNotificacion, asTipoMuestra);
                vmCNot.hdfCodTHabilitante = asCodTHabilitante;

                return View(vmCNot);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        [HttpPost]
        public JsonResult Muestra(VM_CNotificacionMuestra dto)
        {
            ListResult result = logNotificacion.GuardarDatosCNotificacionMuestra(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        [HttpPost]
        public JsonResult SaveCensoAsMuestra(string asCodNotificacion, string asTipoMuestra)
        {
            ListResult result = logNotificacion.CuardarCensoComoMuestra(asCodNotificacion, asTipoMuestra, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        private IEnumerable<Object> SetFormatMuestraMaderable(List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodCn = item.COD_FISNOTI,
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
                             RegEst = item.RegEstado
                         };
            return result;
        }
        private IEnumerable<Object> SetFormatMuestraNoMaderable(List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> alMuestra)
        {
            var result = from item in alMuestra
                         select new
                         {
                             CodCn = item.COD_FISNOTI,
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

        public JsonResult GetCenso(string asCodNotificacion, string asTipoMuestra)
        {
            try
            {
                IEnumerable<Object> result = new List<Object>();
                switch (asTipoMuestra)
                {
                    case "M":
                    case "NM":
                        CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsMad = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
                        List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCensoMad = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();
                        paramsMad.COD_FISNOTI = asCodNotificacion;

                        if (asTipoMuestra == "M")
                        {
                            lstCensoMad = logNotificacion.RegMostrarPoaDetMadCensoLista_v3(paramsMad);
                            result = SetFormatMuestraMaderable(lstCensoMad);
                        }
                        else
                        {
                            lstCensoMad = logNotificacion.RegMostrarPoaDetNoMadCensoLista_v3(paramsMad);
                            result = SetFormatMuestraNoMaderable(lstCensoMad);
                        }
                        break;
                    case "DTR":
                    case "DTO":
                    case "DAR":
                        CapaEntidad.DOC.Ent_DEVOLUCION_MADERA paramsDev = new CapaEntidad.DOC.Ent_DEVOLUCION_MADERA();
                        List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA> lstCensoDev = new List<CapaEntidad.DOC.Ent_DEVOLUCION_MADERA>();
                        paramsDev.COD_FISNOTI = asCodNotificacion;

                        if (asTipoMuestra == "DTR")
                        {
                            lstCensoDev = logNotificacion.RegMostrarDevolDetTrozaCensoLista_v3(paramsDev);
                            result = SetFormatMuestraTroza(lstCensoDev);
                        }
                        else if (asTipoMuestra == "DTO")
                        {
                            lstCensoDev = logNotificacion.RegMostrarDevolDetToconCensoLista_v3(paramsDev);
                            result = SetFormatMuestraTocon(lstCensoDev);
                        }
                        else
                        {
                            lstCensoDev = logNotificacion.RegMostrarDevolDetArbolCensoLista_v3(paramsDev);
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
        public JsonResult ExportMuestra(string asCodNotificacion, string asTipoMuestra)
        {
            ListResult result = new ListResult();

            switch (asTipoMuestra)
            {
                case "M":
                    result = ExportarDatos.MuestraMaderable(asCodNotificacion);
                    break;
                case "NM":
                    result = ExportarDatos.MuestraNoMaderable(asCodNotificacion);
                    break;
                default:
                    result.success = false; result.msj = "Opción no implementada para esta muestra";
                    break;
            }

            return Json(result);
        }
        [HttpPost]
        public JsonResult ExportDatosGenerales(string asCodNotificacion)
        {
            ListResult result = ExportarDatos.DatosGenerales(asCodNotificacion);
            return Json(result);
        }
        [HttpPost]
        public JsonResult ImportMuestra(string asCodNotificacion, string asTipoMuestra)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipoMuestra)
                    {
                        case "M":
                            result = SetFormatMuestraMaderable(ImportarDatos.MuestraMaderable(asCodNotificacion, Request));
                            break;
                        case "NM":
                            result = SetFormatMuestraNoMaderable(ImportarDatos.MuestraNoMaderable(asCodNotificacion, Request));
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

            return Json(new { success = true, msj = "", data = result });
        }
        #endregion
    }
}