using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;

//using HtmlToOpenXml;
using Newtonsoft.Json;
using OfficeOpenXml;
using SIGOFCv3.Areas.Supervision.Models.ManInforme;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;

using System.Web;
using System.Web.Mvc;
using wp = DocumentFormat.OpenXml.Wordprocessing;
using CEntidad = CapaEntidad.DOC.Ent_INFORME;
using CEntVM = CapaEntidad.ViewModel.VM_Informe;
using CLogica = CapaLogica.DOC.Log_INFORME;
using CLogica_Denuncia = CapaLogica.DOC.Log_Denuncia;
using DocumentFormat.OpenXml.Packaging;
using SIGOFCv3.Areas.THabilitante.Models;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeController : Controller
    {

        SIGOFCv3.Helper.EpplusExcel epplus = new SIGOFCv3.Helper.EpplusExcel();

        #region "Vista General"
        // GET: Supervision/ManInforme
        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "INFORME_SUPERVISION";
            ViewBag.TituloFormulario = "Informe de Supervisión";
            ViewBag.AlertaInicial = _alertaIncial;

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe de Supervisión");
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
        [HttpPost]
        public PartialViewResult _THabilitanteGeneral(string asCodCNotificacion)
        {
            CapaLogica.DOC.Log_THABILITANTE exeTh = new CapaLogica.DOC.Log_THABILITANTE();
            CapaEntidad.DOC.Ent_THABILITANTE entTh = new CapaEntidad.DOC.Ent_THABILITANTE()
            {
                COD_CNOTIFICACION = asCodCNotificacion
            };
            entTh = exeTh.GetDatosGeneralesTituloHabilitante(entTh);

            return PartialView(entTh);
        }
        [HttpPost]
        public JsonResult ImportarDatosInformeSimple(string asTipo)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipo)
                    {
                        case "VERTICE_THABILITANTE_CAMPO": result = ImportarDatos.VerticeTHabilitanteCampo(Request); break;
                        case "AVISTAMIENTO_FAUNA": result = ImportarDatos.AvistamientoFauna(Request); break;
                        case "VERTICE_AREA": result = ImportarDatos.VerticeArea(Request); break;
                        case "EVALUACION_ARBOL": result = ImportarDatos.EvaluacionArbol(Request); break;
                        case "HUAYRONA": result = ImportarDatos.Huayrona(Request); break;
                        case "ACTIVIDAD_SILVICULTURAL": result = ImportarDatos.ActividadSilvicultural(Request); break;
                        case "EVALUACION_OTRO": result = ImportarDatos.EvaluacionOtro(Request); break;
                        case "VOLUMEN_ANALIZADO": result = ImportarDatos.VolumenAnalizado(Request); break;
                        case "DESPLAZAMIENTO_SUPERVISION": result = ImportarDatos.DesplazamientoSupervision(Request); break;
                        case "COBERTURA_BOSCOSA": result = ImportarDatos.CoberturaBoscosa(Request); break;
                        case "ESPECIESFOREST": result = ImportarDatos.EspecieForestalEstablecida(Request); break;
                        case "COBERTURABOSNAT": result = ImportarDatos.CoberturaBosquesNaturales(Request); break;
                        case "DIVISIONPREDIO": result = ImportarDatos.DivisionPredio(Request); break;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false, msj = ex.Message
                });
            }

            return Json(new { success = true, msj = "", data = result });
        }
        /// <summary>
        /// Obtener los POA's asociados a las Cartas de Notificación
        /// </summary>
        /// <param name="asCodCNotificacion">Cadena de códigos de Cartas de Notificación cada código entre comillas simples y separados por coma: "'cod1','cod2','etc'"</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetListPoaCNotificacion(string asCodCNotificacion)
        {
            try
            {
                CEntidad entInfPoa = new CEntidad();
                CLogica exeInfPoa = new CLogica();
                entInfPoa.BusFormulario = "INFORME_SUPERVISION";
                entInfPoa.BusCriterio = "LISTA_POAS";
                entInfPoa.TIPO = "CN";
                //entInfPoa.TIPO = "FN";
                entInfPoa.BusValor = asCodCNotificacion;
                var lstPoa = exeInfPoa.RegMostListPOAs(entInfPoa).ListPOAs;

                var jsonResult = Json(new { success = true, data = lstPoa.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult EliminarRegistroDetalle(List<CEntidad> olCEntidad)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.RegEliminarList(olCEntidad);
            return Json(result);
        }
        public FileResult SimularObservatorio(string asCodInforme, Int32 aiNumPoa)
        {
            string ruta = "";
            ListResult result = ExportarDatos.PrevisualizarObservatorio(asCodInforme, aiNumPoa);
            if (result.success)
            {
                ruta = Server.MapPath("~/PlantillaPDF/Descargas/" + result.msj + ".pdf");
            }

            byte[] oBytes = System.IO.File.ReadAllBytes(ruta);

            return File(oBytes, "application/pdf");
        }
        public FileResult DescargarDatosInforme(string asCodInforme)
        {
            string ruta = "", nombreDescarga = "ReporteSupervision_";
            ListResult result = ExportarDatos.DatosInforme(asCodInforme);
            if (result.success)
            {
                ruta = Server.MapPath("~/Archivos/Plantilla/InformeSup/" + result.msj);
                nombreDescarga += string.IsNullOrEmpty(result.data) ? asCodInforme : result.data.Substring(result.data.Length - 4, 4);
            }

            byte[] oBytes = System.IO.File.ReadAllBytes(ruta);

            return File(oBytes, "application/xlsx", nombreDescarga + ".xls");
        }
        #endregion
        #region "Mantenimiento Informe"
        public ActionResult AddEdit(string asCodMTipo, string asCodInforme = "", string asCodCNotificacion = "")
        {
            try
            {
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe de Supervisión");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                CLogica exeInf = new CLogica();
                string codEspecialista = string.Empty, especialista = string.Empty, correo = string.Empty;
                Log_Informe_Digital logDigital = new Log_Informe_Digital();
                if (!string.IsNullOrEmpty(asCodInforme))
                {
                    logDigital.IDigitalEspecialistaCalidadObtener(asCodInforme, out codEspecialista, out especialista, out correo);
                }
                switch (asCodMTipo)
                {
                    case "0000005"://Tara
                        VM_Informe_Tara vmInfTara = exeInf.InitDatosInformeTara(asCodInforme, asCodCNotificacion);
                        vmInfTara.Nombre_Supervisor_Calidad = especialista;
                        vmInfTara.hdSupervisor_Calidad = codEspecialista;
                        //Actualizamos el valor para el control de calidad
                        vmInfTara.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                        vmInfTara.hdfPerfil = mr.PERFIL;
                        return View("~/Areas/Supervision/Views/ManInformeTara/AddEditTara.cshtml", vmInfTara);
                    case "0000011":
                    case "0000012"://Conservación
                        VM_Informe_Conservacion vmInfConserv = exeInf.InitDatosInformeConservacion(asCodInforme, asCodCNotificacion);
                        vmInfConserv.hdfCodMTipo = asCodMTipo;
                        vmInfConserv.Nombre_Supervisor_Calidad = especialista;
                        vmInfConserv.hdSupervisor_Calidad = codEspecialista;
                        //Actualizamos el valor para el control de calidad
                        vmInfConserv.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                        vmInfConserv.hdfPerfil = mr.PERFIL;
                        return View("~/Areas/Supervision/Views/ManInformeConservacion/AddEditConservacion.cshtml", vmInfConserv);
                    case "0000013"://Concesión Fauna
                    case "0000028"://Permiso Fauna
                    case "0000032"://Comunidad Campesina
                    case "0000033"://Predio Privado
                        VM_Informe_Fauna vmInfFauna = exeInf.InitDatosInformeFauna(asCodInforme, asCodCNotificacion);
                        vmInfFauna.hdfCodMTipo = asCodMTipo;
                        vmInfFauna.Nombre_Supervisor_Calidad = especialista;
                        vmInfFauna.hdSupervisor_Calidad = codEspecialista;
                        ViewBag.hdfCodGrupoUsuario = (ModelSession.GetSession())[0].COD_UGRUPO;
                        //Actualizamos el valor para el control de calidad
                        vmInfFauna.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                        vmInfFauna.hdfPerfil = mr.PERFIL;
                        return View("~/Areas/Supervision/Views/ManInformeFauna/AddEditFauna.cshtml", vmInfFauna);
                    case "0000001":
                    case "0000002":
                    case "0000003":
                    case "0000004":
                    case "0000023"://ExSitu
                        VM_Informe_ExSitu vmInfExSitu = exeInf.InitDatosInformeExSitu(asCodInforme, asCodCNotificacion);
                        vmInfExSitu.hdfCodMTipo = asCodMTipo;
                        vmInfExSitu.Nombre_Supervisor_Calidad = especialista;
                        vmInfExSitu.hdSupervisor_Calidad = codEspecialista;
                        CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                        ViewBag.ddlEquipoLimpieza = exeBus.RegMostComboIndividual("EQUIPO_LIMPIEZA_EXSITU", "");
                        ViewBag.ddlMaterialDesinfeccion = exeBus.RegMostComboIndividual("MATERIAL_DESINFECCION_EXSITU", "");
                        //Actualizamos el valor para el control de calidad
                        vmInfExSitu.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                        vmInfExSitu.hdfPerfil = mr.PERFIL;
                        return View("~/Areas/Supervision/Views/ManInformeExSitu/AddEditExSitu.cshtml", vmInfExSitu);
                    default:
                        CEntVM vmInf = exeInf.InitDatosInforme(asCodInforme, asCodCNotificacion, asCodMTipo, (ModelSession.GetSession())[0].COD_UCUENTA);
                        vmInf.hdfCodMTipo = asCodMTipo;
                        ViewBag.hdfCodGrupoUsuario = (ModelSession.GetSession())[0].COD_UGRUPO;
                        vmInf.Nombre_Supervisor_Calidad = especialista;
                        vmInf.hdSupervisor_Calidad = codEspecialista;
                        //Actualizamos el valor para el control de calidad
                        vmInf.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                        vmInf.hdfPerfil = mr.PERFIL;
                        return View(vmInf);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
                //return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        /*
        public ActionResult AddEdit(string asCodMTipo, string asCodInforme = "", string asCodNotificacion = "")
        {
            try
            {
                CLogica exeInf = new CLogica();

                switch (asCodMTipo)
                {
                    case "0000005"://Tara
                        VM_Informe_Tara vmInfTara = exeInf.InitDatosInformeTara(asCodInforme, asCodNotificacion);
                        return View("~/Areas/Supervision/Views/ManInformeTara/AddEditTara.cshtml", vmInfTara);
                    case "0000011":
                    case "0000012"://Conservación
                        VM_Informe_Conservacion vmInfConserv = exeInf.InitDatosInformeConservacion(asCodInforme, asCodNotificacion);
                        vmInfConserv.hdfCodMTipo = asCodMTipo;
                        return View("~/Areas/Supervision/Views/ManInformeConservacion/AddEditConservacion.cshtml", vmInfConserv);
                    case "0000013"://Fauna
                        VM_Informe_Fauna vmInfFauna = exeInf.InitDatosInformeFauna(asCodInforme, asCodNotificacion);
                        ViewBag.hdfCodGrupoUsuario = (ModelSession.GetSession())[0].COD_UGRUPO;
                        return View("~/Areas/Supervision/Views/ManInformeFauna/AddEditFauna.cshtml", vmInfFauna);
                    case "0000001":
                    case "0000002":
                    case "0000003":
                    case "0000004":
                    case "0000023"://ExSitu
                        VM_Informe_ExSitu vmInfExSitu = exeInf.InitDatosInformeExSitu(asCodInforme, asCodNotificacion);
                        CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                        ViewBag.ddlEquipoLimpieza = exeBus.RegMostComboIndividual("EQUIPO_LIMPIEZA_EXSITU", "");
                        ViewBag.ddlMaterialDesinfeccion = exeBus.RegMostComboIndividual("MATERIAL_DESINFECCION_EXSITU", "");
                        return View("~/Areas/Supervision/Views/ManInformeExSitu/AddEditExSitu.cshtml", vmInfExSitu);
                    default:
                        CEntVM vmInf = exeInf.InitDatosInforme(asCodInforme, asCodNotificacion, asCodMTipo, (ModelSession.GetSession())[0].COD_UCUENTA);
                        vmInf.hdfCodMTipo = asCodMTipo;
                        ViewBag.hdfCodGrupoUsuario = (ModelSession.GetSession())[0].COD_UGRUPO;
                        return View(vmInf);
                } 
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        */
        [HttpPost]
        public JsonResult AddEdit(VM_Informe dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GuardarDatosInforme(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        #endregion
        #region "Avistamiento Fauna"
        [HttpPost]
        public PartialViewResult _AvistamientoFauna()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlTipoAvistRegistro = exeBus.RegMostComboIndividual("TIPO_AVISTAMIENTO_FAUNA_REGISTRO", "");
            ViewBag.ddlTipoAvistEstrato = exeBus.RegMostComboIndividual("TIPO_AVISTAMIENTO_FAUNA_ESTRATO", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");

            return PartialView();
        }
        #endregion
        #region "Especie Forestal Establecida"
        [HttpPost]
        public PartialViewResult _EspecieForEst()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            return PartialView();
        }
        #endregion
        #region "Actividad Productiva"
        [HttpPost]
        public PartialViewResult _ActividadProd()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            paramsBus.BusFormulario = "DESTINO_PRODUCCION";
            ViewBag.ddlDestinoActProd = exeBus.RegOpcionesCombo(paramsBus).Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            paramsBus.BusFormulario = "ESTADO_CULTIVO";
            ViewBag.ddlEstadoCulActProd = exeBus.RegOpcionesCombo(paramsBus).Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            return PartialView();
        }
        #endregion
        #region "Cobertura de Bosques Naturales"
        [HttpPost]
        public PartialViewResult _CoberturaBosNat()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            paramsBus.BusFormulario = "AREA_COBERTURA";
            ViewBag.ddlAreaCobertura = exeBus.RegOpcionesCombo(paramsBus).Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });           
            return PartialView();
        }
        #endregion
        #region "División Interna del Predio"
        [HttpPost]
        public PartialViewResult _DivisionPredio(CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO entDivisionPredio)
        {
            entDivisionPredio = entDivisionPredio == null ? new CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO() : entDivisionPredio;
            return PartialView(entDivisionPredio);
        }
        #endregion
        #region "Vertice THabilitante"
        [HttpPost]
        public PartialViewResult _VerticeTHCampo(string asCodCNotificacion)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlVetice = exeBus.RegMostComboIndividual("VERTICE_TH_CAMPO", asCodCNotificacion);
            ViewBag.ddlZona = new List<VM_Cbo>()
            {
                new VM_Cbo() {Value="0000000",Text="Seleccionar" },new VM_Cbo() {Value="17S",Text="17S" },new VM_Cbo() {Value="18S",Text="18S" },new VM_Cbo() {Value="19S",Text="19S" }
            };

            return PartialView();
        }
        [HttpPost]
        public JsonResult ExportarVerticeTHabilitante(string asCodInforme, string asCodCNotificacion)
        {
            try
            {
                ListResult result = new ListResult();
                result = ExportarDatos.VerticeTHCampo(asCodInforme, asCodCNotificacion);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion

        #region "Cobertura Boscosa"
        [HttpPost]
        public PartialViewResult _CoberturaBoscosa(string asCodCNotificacion)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlZona = new List<VM_Cbo>()
            {
                new VM_Cbo() {Value="0000000",Text="Seleccionar" },new VM_Cbo() {Value="17S",Text="17S" },new VM_Cbo() {Value="18S",Text="18S" },new VM_Cbo() {Value="19S",Text="19S" }
            };

            return PartialView();
        }
        [HttpPost]
        public JsonResult ExportarCoberturaBoscosa(string asCodInforme, string asCodCNotificacion)
        {
            try
            {
                ListResult result = new ListResult();
                result = ExportarDatos.CoberturaBoscosa(asCodInforme, asCodCNotificacion);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion

        #region "Otros Puntos de Evaluación"
        [HttpPost]
        public PartialViewResult _OtrosPuntosEval(string asCodCNotificacion)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlZona = new List<VM_Cbo>()
            {
                new VM_Cbo() {Value="0000000",Text="Seleccionar" },new VM_Cbo() {Value="17S",Text="17S" },new VM_Cbo() {Value="18S",Text="18S" },new VM_Cbo() {Value="19S",Text="19S" }
            };

            return PartialView();
        }
        [HttpPost]
        public JsonResult ExportarOtrosPuntosEvaluacion(string asCodInforme, string asCodCNotificacion)
        {
            try
            {
                ListResult result = new ListResult();
                result = ExportarDatos.OtrosPuntosEval(asCodInforme, asCodCNotificacion);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion

        #region "Infraestructura"
        [HttpPost]
        public PartialViewResult _Infraestructura(string asCodCNotificacion)
        {
            return PartialView();
        }
        #endregion
        #region "Zonificación de la Distribución de Especie"
        [HttpPost]
        public PartialViewResult _ZonifDistribEspecie(string asCodCNotificacion)
        {
            return PartialView();
        }
        #endregion
        #region "Aprovechamiento sostenible"
        [HttpPost]
        public PartialViewResult _AprovSostenible(string asCodCNotificacion)
        {
            return PartialView();
        }
        #endregion

        #region "Mantenimiento Foto de Supervisión"
        [HttpPost]
        public PartialViewResult _FotoSupervision(string asCodInforme)
        {
            CLogica exeInf = new CLogica();
            CEntidad entInf = exeInf.RegMostrarDatosCabecera(asCodInforme);
            VM_Informe_Foto vm = new VM_Informe_Foto();

            if (!string.IsNullOrEmpty(entInf.COD_INFORME))
            {
                vm.hdfCodInforme = entInf.COD_INFORME;
                vm.hdfNumInforme = entInf.NUMERO;
                vm.txtNumTHabilitante = entInf.NUM_THABILITANTE;
                vm.txtUsuarioRegistro = (ModelSession.GetSession())[0].PERSONA;
                vm.txtFechaRegistro = DateTime.Now.ToShortDateString();
            }

            return PartialView(vm);
        }
        [HttpPost]
        public JsonResult GrabarFotoSupervision()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    VM_Informe_Foto datoFoto = JsonConvert.DeserializeObject<VM_Informe_Foto>(Request.Form["data"]);
                    //  Get all files from Request object  
                    HttpPostedFileBase file = Request.Files[0];
                    CLogica exeInf = new CLogica();

                    //Subir foto al servidor
                    string fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                        + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()
                        + DateTime.Now.Millisecond.ToString() + "." + file.FileName.Substring(file.FileName.LastIndexOf(".") + 1).ToLower();
                    string titulo = Regex.Replace(datoFoto.txtNumTHabilitante, @"\W+", "_").Trim('_');
                    string informe = Regex.Replace(datoFoto.hdfNumInforme, @"\W+", "_").Trim('_');
                    string url_base = Server.MapPath("~/Fotos/") + titulo + "/" + informe;
                    string url_foto = Path.Combine(url_base, fname);

                    // Si el directorio no existe, crearlo
                    if (!Directory.Exists(url_base))
                        Directory.CreateDirectory(url_base);
                    //Get the complete folder path and store the file inside it.
                    file.SaveAs(url_foto);

                    //Registrar en la base de datos, los datos de la foto
                    datoFoto.txtUrlFoto = "Fotos/" + titulo + "/" + informe + "/" + fname;
                    datoFoto = exeInf.RegInsertarFotoSupervision(datoFoto, (ModelSession.GetSession())[0].COD_UCUENTA);

                    // Returns message that successfully uploaded  
                    return Json(new { success = true, msj = "La foto se registro correctamente", data = datoFoto });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, msj = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontró la foto a subir" });
            }
        }
        [HttpPost]
        public JsonResult EliminarFotoSupervision(VM_Informe_Foto _dto)
        {
            try
            {
                var ruta = Server.MapPath("~/" + _dto.txtUrlFoto);
                if (System.IO.File.Exists(ruta)) System.IO.File.Delete(ruta);

                CLogica exeInf = new CLogica();
                exeInf.RegEliminar(new CEntidad()
                {
                    EliTABLA = "INFORME_FOTOS",
                    COD_INFORME = _dto.hdfCodInforme,
                    COD_INFORME_FOTOS = _dto.hdfCodInformeFoto
                });

                return Json(new { success = true, msj = "La foto ha sido eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion
        #region "Mantenimiento Datos POA Supervisado"
        [HttpPost]
        public PartialViewResult _POASupervisado(string asCodInforme, Int32 aiNumPoa, int B_POA)
        {
            CLogica exeInf = new CLogica();
            VM_Informe_POASupervisado vm = exeInf.InitDatosPOASupervisado(asCodInforme, aiNumPoa, B_POA, null);
            ViewBag.hdfCodInforme = vm.hdfCodInforme;
            ViewBag.hdfNumPoa = vm.hdfNumPoa;
            return PartialView(vm);
        }
        [HttpPost]
        public JsonResult _POAGetParcelaCorta(VM_Informe_POASupervisado dto)
        {
            try
            {
                CLogica exeInf = new CLogica();
                VM_Informe_POASupervisado vm = exeInf.RegMostParcelaCorta(dto);

                return Json(new { success = true, result = vm });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }
        [HttpPost]
        public PartialViewResult _ArbolesSinPoa(string asCodInforme, int B_POA, string CODIGO_SEC_NOPOA, string hdfCodMTipo)
        {
            CLogica exeInf = new CLogica();
            VM_Informe_POASupervisado vm = exeInf.InitDatosPOASupervisado(asCodInforme, 0, B_POA, CODIGO_SEC_NOPOA, hdfCodMTipo);
            ViewBag.hdPartMenoresCUSAF = vm.rbtnPartMenoresCUSAF;
            ViewBag.hdAsistenciaTecnicaCUSAF = vm.rbtnAsistenciaTecnicaCUSAF;
            ViewBag.hdFrecuenciaCUSAF = vm.rbtnFrecuenciaCUSAF;
            return PartialView(vm);
        }
        [HttpPost]
        public JsonResult GrabarPOASupervisado(VM_Informe_POASupervisado dto)
        {
            CLogica exeInf = new CLogica();
            if (dto.hdfCodInforme == null)
            {
                dto.hdfCodInforme = ViewBag.hdfCodInforme;
            }
            ListResult result = exeInf.GuardarDatosPOASupervisado(dto, (ModelSession.GetSession())[0].COD_UCUENTA);            
            return Json(result);
        }
        [HttpPost]
        public JsonResult GrabarPOArboles(VM_Informe_POASupervisado dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GrabarPOArboles(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        #endregion
        #region "Mantenimiento Datos Vértices del Área"
        [HttpPost]
        public PartialViewResult _VerticeArea(string asCodTHabilitante, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            string valor = asCodTHabilitante + "," + aiNumPoa.ToString();
            ViewBag.ddlVetice = exeBus.RegMostComboIndividual("VERTICE_AREA", valor);
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");

            string valor2 = asCodTHabilitante + "," + aiNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor2);

            return PartialView();
        }

        [HttpPost]
        public JsonResult ExportarVerticePoa(string asCodInforme, int aiNumPoa)
        {
            try
            {
                ListResult result = new ListResult();
                result = ExportarDatos.VerticePOACampo(asCodInforme, aiNumPoa);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion
        #region "Mantenimiento Datos Evaluación de Árboles (adicionales y no autorizados)"
        [HttpPost]
        public PartialViewResult _EvaluacionArbol()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlMetodoMedirDap = exeBus.RegMostComboIndividual("METODOLOGIA_MEDIR_DAP", "");
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");

            return PartialView();
        }
        #endregion
        #region "Mantenimiento Datos Huayronas"
        [HttpPost]
        public PartialViewResult _Huayrona()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");

            return PartialView();
        }
        #endregion
        #region "Mantenimiento Datos Actividad Silvicultural"
        [HttpPost]
        public PartialViewResult _ActividadSilvicultural()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlActSilvicultural = exeBus.RegMostComboIndividual("ACTIVIDAD_SILVICULTURAL", "");

            return PartialView();
        }
        #endregion
        #region "Mantenimiento Datos Cambio de Uso"
        [HttpPost]
        public PartialViewResult _CambioUso()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlCambioUso = exeBus.RegMostComboIndividual("CAMBIO_USO", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlAutorizado = exeBus.RegMostComboIndividual("AUTORIZADO", "");

            return PartialView();
        }
        #endregion
        #region "Mantenimiento Datos Evaluación Otros"
        [HttpPost]
        public PartialViewResult _EvaluacionOtro()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");

            return PartialView();
        }
        #endregion
        #region "Mantenimiento Datos Volumen Analizado"
        [HttpPost]
        public PartialViewResult _VolumenAnalizado(string asCodTHabilitante, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            string valor = asCodTHabilitante + "," + aiNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor);
            return PartialView();
        }
        #endregion
        #region "Mantenimiento Datos de Campo"
        public PartialViewResult _DatosCampo(string asCodInforme, Int32 aiNumPoa, bool abMaderable = false, bool abNoMaderable = false)
        {
            CLogica exeInf = new CLogica();
            CEntidad datInf = exeInf.RegMostrarDatosCabecera(asCodInforme);
            CEntidad muestraInf;
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            string cod_mtipo_nomade = "0000008,0000009,0000018";
            string cod_mtipo_made = "0000007,0000010,0000014,0000015,0000016,0000017";

            //llanos
            ViewBag.hdfCodTHabilitante = datInf.COD_THABILITANTE;
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            ViewBag.hdfCodMTipo = datInf.COD_MTIPO;
            ViewBag.hdfEstadoOrigen = datInf.ESTADO_ORIGEN;
            ViewBag.hdfMaderable = abMaderable;
            ViewBag.hdfNoMaderable = abNoMaderable;

            //Mostrar los datos de campo de devolución de mandera (troza, tocón y árbol)
            ViewBag.hdfDatosDevolTroza = 0;
            ViewBag.hdfDatosDevolTocon = 0;
            ViewBag.hdfDatosDevolArbol = 0;

            string valor = datInf.COD_THABILITANTE + "," + aiNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor);

            if (datInf.ESTADO_ORIGEN == "DM")
            {
                muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("DEVOLUCION_TROZA", asCodInforme, aiNumPoa);
                ViewBag.hdfDatosDevolTroza = muestraInf.CANTIDAD;
                muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("DEVOLUCION_TOCON", asCodInforme, aiNumPoa);
                ViewBag.hdfDatosDevolTocon = muestraInf.CANTIDAD;
                muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("DEVOLUCION_ARBOL", asCodInforme, aiNumPoa);
                ViewBag.hdfDatosDevolArbol = muestraInf.CANTIDAD;
            }
            else
            {
                //Mostrar datos de campo maderable, bosques secos y semilleros
                ViewBag.hdfMuestraMade = 0;
                ViewBag.hdfDatosCampoMade = 0;
                ViewBag.hdfMuestraSemi = 0;
                ViewBag.hdfDatosCampoSemi = 0;
                if (cod_mtipo_made.Contains(datInf.COD_MTIPO) || cod_mtipo_nomade.Contains(datInf.COD_MTIPO) || datInf.COD_MTIPO == "0000006")
                {
                    muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("MADERABLE", asCodInforme, aiNumPoa);
                    ViewBag.hdfMuestraMade = muestraInf.CANTIDAD;
                    ViewBag.hdfDatosCampoMade = muestraInf.CANTIDAD_CAMPO;
                    muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("SEMILLERO", asCodInforme, aiNumPoa);
                    ViewBag.hdfMuestraSemi = muestraInf.CANTIDAD;
                    ViewBag.hdfDatosCampoSemi = muestraInf.CANTIDAD_CAMPO;
                }
                //Mostrar datos de campo no maderable (shiringa, castaña y aguaje) y semillero no maderable
                ViewBag.hdfMuestraNoMade = 0;
                ViewBag.hdfDatosNoMade = 0;
                ViewBag.hdfMuestraSemiNoMade = 0;
                ViewBag.hdfDatosSemiNoMade = 0;
                if (cod_mtipo_nomade.Contains(datInf.COD_MTIPO) || abNoMaderable == true)
                {
                    muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("NO_MADERABLE", asCodInforme, aiNumPoa);
                    ViewBag.hdfMuestraNoMade = muestraInf.CANTIDAD;
                    ViewBag.hdfDatosNoMade = muestraInf.CANTIDAD_CAMPO;
                    muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("SEMILLERO_NO_MADERABLE", asCodInforme, aiNumPoa);
                    ViewBag.hdfMuestraSemiNoMade = muestraInf.CANTIDAD;
                    ViewBag.hdfDatosSemiNoMade = muestraInf.CANTIDAD_CAMPO;
                }
                //Mostrar datos de carrizo, plantas medicinales y vértices verificados
                ViewBag.hdfDatosCarrizoCampo = 0;
                ViewBag.hdfDatosPlantaMedicinalCampo = 0;
                ViewBag.hdfDatosVerticeVerifCampo = 0;
                if (datInf.COD_MTIPO == "0000020" || datInf.COD_MTIPO == "0000021")
                {
                    muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("VERTICE_VERIFICADO", asCodInforme, aiNumPoa);
                    ViewBag.hdfDatosVerticeVerifCampo = muestraInf.CANTIDAD_CAMPO;
                    muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("CARRIZO_CAMPO", asCodInforme, aiNumPoa);
                    ViewBag.hdfDatosCarrizoCampo = muestraInf.CANTIDAD_CAMPO;
                }

                //Mostrar datos de traza y madera aserrada en campo
                muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("TROZA_CAMPO", asCodInforme, aiNumPoa);
                ViewBag.hdfDatosTrozaCampo = muestraInf.CANTIDAD_CAMPO;
                muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo("MADERA_ASERRADA", asCodInforme, aiNumPoa);
                ViewBag.hdfDatosMaderaAserradaCampo = muestraInf.CANTIDAD_CAMPO;
            }

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult _DatosCampoMaderable(string asCodInforme)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> olMade = exeInf.RegMostrarMuestraDatosCampoMade(asCodInforme);

            ViewBag.hdfCodInforme = asCodInforme;
            return PartialView(olMade);
        }
        [HttpPost]
        public PartialViewResult _EspecieMaderable(string asCodInforme, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlCoincideEspecie = new List<VM_Cbo>() {
                new VM_Cbo() { Value="-",Text="Seleccionar"},new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"},new VM_Cbo() { Value="NN",Text="Ninguno"}
            };
            ViewBag.ddlMetodoMedirDap = exeBus.RegMostComboIndividual("METODOLOGIA_MEDIR_DAP", "");
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlCondicionEsp = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},new VM_Cbo() { Value="0000005",Text="Aprovechable"},
                new VM_Cbo() { Value="0000015",Text="No Aprovechable"},new VM_Cbo() { Value="0000017",Text="Ninguno"}
            };
            ViewBag.hdfCodInforme = asCodInforme;

            CLogica exeInf = new CLogica();
            CEntidad datInf = exeInf.RegMostrarDatosCabecera(asCodInforme);
            string valor = datInf.COD_THABILITANTE + "," + aiNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor);

            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieMaderable(CapaEntidad.DOC.Ent_INFORME_MADERABLE dto)
        {
            CLogica exeInf = new CLogica();
            //ListResult result = exeInf.RegInsertarMuestraDatosCampoMade(dto);
            ListResult result = new ListResult();
            try
            {
                result = exeInf.RegInsertarMuestraDatosCampoMade(dto);
                if (result.msj != "Ok")
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosCampoBosqueSeco(string asCodInforme)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO> olBosque = exeInf.RegMostrarMuestraDatosCampoBosqueSeco(asCodInforme);
            ViewBag.hdfCodInforme = asCodInforme;
            return PartialView(olBosque);
        }
        [HttpPost]
        public PartialViewResult _EspecieBosqueSeco(string asCodInforme)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodInforme = asCodInforme;
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieBosqueSeco(CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.RegInsertarMuestraDatosCampoBosqueSeco(dto);
            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosCampoSemillero(string asCodInforme)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> olMade = exeInf.RegMostrarMuestraDatosCampoSemi(asCodInforme);
            ViewBag.hdfCodInforme = asCodInforme;
            return PartialView(olMade);
        }
        [HttpPost]
        public PartialViewResult _EspecieSemillero(string asCodInforme, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlCoincideEspecie = new List<VM_Cbo>() {
                new VM_Cbo() { Value="-",Text="Seleccionar"},new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"},new VM_Cbo() { Value="NN",Text="Ninguno"}
            };
            ViewBag.ddlMetodoMedirDap = exeBus.RegMostComboIndividual("METODOLOGIA_MEDIR_DAP", "");
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlFenologia = exeBus.RegMostComboIndividual("EFENOLOGICO", "");
            ViewBag.ddlCFuste = exeBus.RegMostComboIndividual("CFUSTE", "");
            ViewBag.ddlFCopa = exeBus.RegMostComboIndividual("FCOPA", "");
            ViewBag.ddlPCopa = exeBus.RegMostComboIndividual("PCOPA", "");
            ViewBag.ddlEstadoFito = exeBus.RegMostComboIndividual("ESANITARIO", "");
            ViewBag.ddlGradoInfest = exeBus.RegMostComboIndividual("ILIANAS", "");
            ViewBag.hdfCodInforme = asCodInforme;

            CLogica exeInf = new CLogica();
            CEntidad datInf = exeInf.RegMostrarDatosCabecera(asCodInforme);
            string valor = datInf.COD_THABILITANTE + "," + aiNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor);
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieSemillero(CapaEntidad.DOC.Ent_INFORME_SEMILLERO dto)
        {
            CLogica exeInf = new CLogica();
            //ListResult result = exeInf.RegInsertarMuestraDatosCampoSemi(dto);
            ListResult result = new ListResult();
            try
            {
                result = exeInf.RegInsertarMuestraDatosCampoSemi(dto);
                if (result.msj != "Ok")
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosCampoNoMaderable(string asCodInforme)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> olMade = exeInf.RegMostrarMuestraDatosCampoNoMade(asCodInforme);
            ViewBag.hdfCodInforme = asCodInforme;
            return PartialView(olMade);
        }
        [HttpPost]
        public PartialViewResult _EspecieNoMaderable(string asCodInforme)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            //ViewBag.ddlFenologia = exeBus.RegMostComboIndividual("EFENOLOGICO", "");
            // ViewBag.ddlCFuste = exeBus.RegMostComboIndividual("CFUSTE", "");
            //ViewBag.ddlFCopa = exeBus.RegMostComboIndividual("FCOPA", "");
            //ViewBag.ddlPCopa = exeBus.RegMostComboIndividual("PCOPA", "");
            ViewBag.ddlEstadoFito = exeBus.RegMostComboIndividual("ESANITARIO", "");
            ViewBag.ddlGradoInfest = exeBus.RegMostComboIndividual("ILIANAS", "");
            ViewBag.ddlCondicion = exeBus.RegMostComboIndividual("ECONDICION", "");
            ViewBag.hdfCodInforme = asCodInforme;
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieNoMaderable(CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = new ListResult();
            try
            {
                result = exeInf.RegInsertarMuestraDatosCampoNoMade(dto);
                if (result.msj != "Ok")
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosTrozaCampo(string asCodInforme, Int32 aiNumPoa)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> olTroza = exeInf.RegMostrarDatosTrozaCampo(asCodInforme, aiNumPoa);
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView(olTroza);
        }
        [HttpPost]
        public PartialViewResult _EspecieTrozaCampo(string asCodInforme, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieTrozaCampo(CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.RegInsertarDatosTrozaCampo(new List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO>() { dto }, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosMaderaAserrada(string asCodInforme, Int32 aiNumPoa)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> olMade = exeInf.RegMostrarDatosMaderaAserrada(asCodInforme, aiNumPoa);
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView(olMade);
        }
        [HttpPost]
        public PartialViewResult _EspecieMaderaAserrada(string asCodInforme, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieMaderaAserrada(CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.RegInsertarDatosMaderaAserrada(new List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA>() { dto }, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosCarrizoCampo(string asCodInforme, Int32 aiNumPoa)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> olMade = exeInf.RegMostrarDatosCarrizoCampo(asCodInforme, aiNumPoa);
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            string cod_mtipo = exeInf.RegMostrarDatosCabecera(asCodInforme).COD_MTIPO;
            if (cod_mtipo == "0000020")//Carrizo
            {
                return PartialView(olMade);
            }
            else
            {
                return PartialView("_DatosPlantaMedicinal", olMade);
            }
        }
        [HttpPost]
        public PartialViewResult _EspecieCarrizoCampo(string asCodInforme, Int32 aiNumPoa, string asCodMTipo)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlProducto = exeBus.RegMostComboIndividual("PRODUCTOE", "");
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            ViewBag.hdfCodMTipo = asCodMTipo;
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarEspecieCarrizoCampo(CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.RegInsertarDatosCarrizoCampo(new List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO>() { dto }, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _DatosVerticeVerificado(string asCodInforme, Int32 aiNumPoa)
        {
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> olVert = exeInf.RegMostrarDatosVerticeVerificado(asCodInforme, aiNumPoa);
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView(olVert);
        }
        [HttpPost]
        public PartialViewResult _VerticeVerificado(string asCodInforme, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarVerticeVerificado(CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.RegInsertarDatosVerticeVerificado(new List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO>() { dto }, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetCantidadMuestraDatosCampo(string asTipo, string asCodInforme, Int32 aiNumPoa)
        {
            try
            {
                CLogica exeInf = new CLogica();
                CEntidad muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo(asTipo, asCodInforme, aiNumPoa);

                int cantidad2 = 0, cantidad_campo2 = 0;
                if (asTipo == "NO_MADERABLE")
                {
                    CEntidad oCantidad2 = exeInf.RegMostrarCantidadMuestraDatosCampo("SEMILLERO_NO_MADERABLE", asCodInforme, aiNumPoa);
                    cantidad2 = oCantidad2.CANTIDAD; cantidad_campo2 = oCantidad2.CANTIDAD_CAMPO;
                }

                return Json(new { CANTIDAD = muestraInf.CANTIDAD, CANTIDAD_CAMPO = muestraInf.CANTIDAD_CAMPO, success = true, CANTIDAD_2 = cantidad2, CANTIDAD_CAMPO_2 = cantidad_campo2 });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult ImportarDatosCampo(string asTipo, string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();
            try
            {
                if (Request != null)
                {
                    switch (asTipo)
                    {
                        case "MADERABLE": result = ImportarDatos.DatosCampoMaderable(Request, asCodInforme); break;
                        case "BOSQUE_SECO": result = ImportarDatos.DatosCampoBosqueSeco(Request, asCodInforme); break;
                        case "SEMILLERO": result = ImportarDatos.DatosCampoSemillero(Request, asCodInforme); break;
                        case "NO_MADERABLE": result = ImportarDatos.DatosCampoNoMaderable(Request, asCodInforme); break;
                        case "TROZA_CAMPO": result = ImportarDatos.DatosTrozaCampo(Request, asCodInforme, aiNumPoa, (ModelSession.GetSession())[0].COD_UCUENTA); break;
                        case "MADERA_ASERRADA": result = ImportarDatos.DatosMaderaAserrada(Request, asCodInforme, aiNumPoa, (ModelSession.GetSession())[0].COD_UCUENTA); break;
                        case "CARRIZO_CAMPO": result = ImportarDatos.DatosCarrizoCampo(Request, asCodInforme, aiNumPoa, (ModelSession.GetSession())[0].COD_UCUENTA); break;
                        case "PLANTA_MEDICINAL": result = ImportarDatos.DatosPlantaMedicinal(Request, asCodInforme, aiNumPoa, (ModelSession.GetSession())[0].COD_UCUENTA); break;
                        case "VERTICE_VERIFICADO": result = ImportarDatos.DatosVerticeVerificado(Request, asCodInforme, aiNumPoa, (ModelSession.GetSession())[0].COD_UCUENTA); break;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
            return Json(new { success = result.success, msj = result.msj, data = new List<string>() { "0", "1" } });//data con valores que no significan nada, usado para saltar condición del upload
        }
        [HttpPost]
        public JsonResult ExportarDatosCampo(string asTipo, string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();
            try
            {
                switch (asTipo)
                {
                    case "MADERABLE": result = ExportarDatos.DatosCampoMaderable(asCodInforme); break;
                    case "BOSQUE_SECO": result = ExportarDatos.DatosCampoBosqueSeco(asCodInforme); break;
                    case "SEMILLERO": result = ExportarDatos.DatosCampoSemillero(asCodInforme); break;
                    case "NO_MADERABLE": result = ExportarDatos.DatosCampoNoMaderable(asCodInforme); break;
                    case "TROZA_CAMPO": result = ExportarDatos.DatosTrozaCampo(asCodInforme, aiNumPoa); break;
                    case "MADERA_ASERRADA": result = ExportarDatos.DatosMaderaAserrada(asCodInforme, aiNumPoa); break;
                    case "CARRIZO_CAMPO": result = ExportarDatos.DatosCarrizoCampo(asCodInforme, aiNumPoa); break;
                    case "PLANTA_MEDICINAL": result = ExportarDatos.DatosPlantaMedicinal(asCodInforme, aiNumPoa); break;
                    case "VERTICE_VERIFICADO": result = ExportarDatos.DatosVerticeVerificado(asCodInforme, aiNumPoa); break;
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult AjustarDatosCampo(string asTipo, string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();
            CEntidad muestraInf = new CEntidad();
            int cantidad2 = 0, cantidad_campo2 = 0;

            string msjAjuste = "";
            try
            {
                CLogica exeInf = new CLogica();
                CEntidad entInf = new CEntidad();
                Int32 iAjuste = 0;
                entInf.COD_INFORME = asCodInforme;

                switch (asTipo)
                {
                    case "MADERABLE":
                        entInf.TIPO = "M";
                        iAjuste = Int32.Parse(exeInf.RegAjustarMuestra(entInf));
                        msjAjuste = "Se ajustaron " + iAjuste.ToString() + " individuos Maderables";
                        break;
                    case "BOSQUE_SECO":
                        entInf.TIPO = "BS";
                        iAjuste = Int32.Parse(exeInf.RegAjustarMuestra(entInf));
                        msjAjuste = "Se ajustaron " + iAjuste.ToString() + " individuos de Bosques Secos";
                        break;
                    case "SEMILLERO":
                        entInf.TIPO = "MSEM";
                        iAjuste = Int32.Parse(exeInf.RegAjustarMuestra(entInf));
                        msjAjuste = "Se ajustaron " + iAjuste.ToString() + " individuos Semilleros Maderables";
                        break;
                    case "NO_MADERABLE":
                        entInf.TIPO = "NMSEM";
                        iAjuste = Int32.Parse(exeInf.RegAjustarMuestra(entInf));
                        msjAjuste = "Se ajustaron " + iAjuste.ToString() + " individuos No Maderables";

                        CEntidad oCantidad2 = exeInf.RegMostrarCantidadMuestraDatosCampo("SEMILLERO_NO_MADERABLE", asCodInforme, aiNumPoa);
                        cantidad2 = oCantidad2.CANTIDAD; cantidad_campo2 = oCantidad2.CANTIDAD_CAMPO;
                        break;
                }
                muestraInf = exeInf.RegMostrarCantidadMuestraDatosCampo(asTipo, asCodInforme, aiNumPoa);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
            return Json(new { success = true, msj = msjAjuste, CANTIDAD = muestraInf.CANTIDAD, CANTIDAD_CAMPO = muestraInf.CANTIDAD_CAMPO, CANTIDAD_2 = cantidad2, CANTIDAD_CAMPO_2 = cantidad_campo2 });
        }

        #region llanos

        /// <summary>
        /// Registro Maderable
        /// </summary>
        /// <param name="asCodInforme"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _EspecieMaderableEdit(string asCodInforme)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlCoincideEspecie = new List<VM_Cbo>() {
                new VM_Cbo() { Value="-",Text="Seleccionar"},new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"},new VM_Cbo() { Value="NN",Text="Ninguno"}
            };
            ViewBag.ddlMetodoMedirDap = exeBus.RegMostComboIndividual("METODOLOGIA_MEDIR_DAP", "");
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlCondicionEsp = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},new VM_Cbo() { Value="0000005",Text="Aprovechable"},
                new VM_Cbo() { Value="0000015",Text="No Aprovechable"},new VM_Cbo() { Value="0000017",Text="Ninguno"}
            };

            //llanos
            ViewBag.ddlVigencia = new List<VM_Cbo>() {
                new VM_Cbo() { Value="SI",Text="SI"}, new VM_Cbo() { Value="NO",Text="NO"}
            };

            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> olMade = exeInf.RegMostrarMuestraDatosCampoMade(asCodInforme);

            ViewBag.hdfCodTHabilitante = olMade[0].COD_THABILITANTE.ToString();
            ViewBag.hdfNumPoa = olMade[0].NUM_POA;
            ViewBag.hdfCodInforme = asCodInforme;

            string valor2 = ViewBag.hdfCodTHabilitante + "," + ViewBag.hdfNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor2);

            return PartialView();
        }

        /// <summary>
        /// Busqueda Maderable
        /// </summary>
        /// <param name="asCodInforme"></param>
        /// <param name="asCodTHabilitante"></param>
        /// <param name="asNumPoa"></param>
        /// <param name="asBloque"></param>
        /// <param name="asFaja"></param>
        /// <param name="asCodigo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDatosMaderable(string asCodInforme, string asCodTHabilitante, string asNumPoa, string asBloque, string asFaja, string asCodigo, string asCodSecuencial, string asPCA)
        {
            try
            {
                CEntidad entInfPoa = new CEntidad();
                CLogica exeInfPoa = new CLogica();
                entInfPoa.COD_INFORME = asCodInforme;
                entInfPoa.COD_THABILITANTE = asCodTHabilitante;
                entInfPoa.NUM_POA = Convert.ToInt32(asNumPoa);
                entInfPoa.COD_SECUENCIAL = Convert.ToInt32(String.IsNullOrEmpty(asCodSecuencial) ? "0" : asCodSecuencial);
                entInfPoa.BLOQUE = asBloque;
                entInfPoa.FAJA = asFaja;
                entInfPoa.CODIGO = asCodigo;
                if (asPCA != "0000000")
                {
                    entInfPoa.PCA = asPCA;
                }
                else
                {
                    entInfPoa.PCA = "";
                }
                List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> olMade = exeInfPoa.DatosMaderable(entInfPoa);
                //var lstPoa = exeInfPoa.DatosMaderable(entInfPoa).ListPOAs;

                var jsonResult = Json(new { success = true, data = olMade }, JsonRequestBehavior.AllowGet);
                //var jsonResult = Json(new { success = true, data = lstPoa.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        /// <summary>
        /// Registro Semillero 
        /// </summary>
        /// <param name="asCodInforme"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _EspecieSemilleroEdit(string asCodInforme)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlCoincideEspecie = new List<VM_Cbo>() {
                new VM_Cbo() { Value="-",Text="Seleccionar"},new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"},new VM_Cbo() { Value="NN",Text="Ninguno"}
            };
            ViewBag.ddlMetodoMedirDap = exeBus.RegMostComboIndividual("METODOLOGIA_MEDIR_DAP", "");
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlFenologia = exeBus.RegMostComboIndividual("EFENOLOGICO", "");
            ViewBag.ddlCFuste = exeBus.RegMostComboIndividual("CFUSTE", "");
            ViewBag.ddlFCopa = exeBus.RegMostComboIndividual("FCOPA", "");
            ViewBag.ddlPCopa = exeBus.RegMostComboIndividual("PCOPA", "");
            ViewBag.ddlEstadoFito = exeBus.RegMostComboIndividual("ESANITARIO", "");
            ViewBag.ddlGradoInfest = exeBus.RegMostComboIndividual("ILIANAS", "");
            ViewBag.hdfCodInforme = asCodInforme;

            //llanos
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> olMade = exeInf.RegMostrarMuestraDatosCampoSemi(asCodInforme);
            ViewBag.hdfCodTHabilitante = olMade[0].COD_THABILITANTE.ToString();
            ViewBag.hdfNumPoa = olMade[0].NUM_POA;

            string valor2 = ViewBag.hdfCodTHabilitante + "," + ViewBag.hdfNumPoa.ToString();
            ViewBag.ddParcelas = exeBus.RegMostComboIndividual("PARCELAS", valor2);


            return PartialView();
        }

        /// <summary>
        /// Busqueda Semillero
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDatosSemillero(string asCodInforme, string asCodTHabilitante, string asNumPoa, string asBloque, string asFaja, string asCodigo, string asPCA, string asCodSecuencial)
        {
            try
            {
                CEntidad entInfPoa = new CEntidad();
                CLogica exeInfPoa = new CLogica();
                entInfPoa.COD_INFORME = asCodInforme; // "000120180000803";
                entInfPoa.COD_THABILITANTE = asCodTHabilitante; // "20130002078";
                entInfPoa.NUM_POA = Convert.ToInt32(asNumPoa); //0;
                //entInfPoa.COD_ESPECIES = "0000117";
                //entInfPoa.COD_SECUENCIAL = Convert.ToInt32(asCodSecuencial);
                entInfPoa.BLOQUE = asBloque;
                entInfPoa.FAJA = asFaja;
                entInfPoa.CODIGO = asCodigo;
                entInfPoa.COD_SECUENCIAL = Convert.ToInt32(String.IsNullOrEmpty(asCodSecuencial) ? "0" : asCodSecuencial);

                if (asPCA != "0000000")
                {
                    entInfPoa.PCA = asPCA;
                }
                else
                {
                    entInfPoa.PCA = "";
                }
                List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> olMade = exeInfPoa.DatosSemillero(entInfPoa);
                //var lstPoa = exeInfPoa.DatosMaderable(entInfPoa).ListPOAs;

                var jsonResult = Json(new { success = true, data = olMade }, JsonRequestBehavior.AllowGet);
                //var jsonResult = Json(new { success = true, data = lstPoa.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _EspecieNoMaderableEdit(string asCodInforme)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlEstado = exeBus.RegMostComboIndividual("ESTADO_ESPECIE", "");
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlFenologia = exeBus.RegMostComboIndividual("EFENOLOGICO", "");
            ViewBag.ddlCFuste = exeBus.RegMostComboIndividual("CFUSTE", "");
            ViewBag.ddlFCopa = exeBus.RegMostComboIndividual("FCOPA", "");
            ViewBag.ddlPCopa = exeBus.RegMostComboIndividual("PCOPA", "");
            ViewBag.ddlEstadoFito = exeBus.RegMostComboIndividual("ESANITARIO", "");
            ViewBag.ddlGradoInfest = exeBus.RegMostComboIndividual("ILIANAS", "");
            ViewBag.ddlCondicion = exeBus.RegMostComboIndividual("ECONDICION", "");
            ViewBag.hdfCodInforme = asCodInforme;
            CLogica exeInf = new CLogica();
            List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> olMade = exeInf.RegMostrarMuestraDatosCampoNoMade(asCodInforme);
            if (olMade.Count > 0)
            {
                ViewBag.hdfCodTHabilitante = olMade[0].COD_THABILITANTE.ToString();
                ViewBag.hdfNumPoa = olMade[0].NUM_POA;
            }
            return PartialView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asCodInforme"></param>
        /// <param name="asCodTHabilitante"></param>
        /// <param name="asNumPoa"></param>
        /// <param name="asBloque"></param>
        /// <param name="asFaja"></param>
        /// <param name="asCodigo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDatosNoMaderable(string asCodInforme, string asCodTHabilitante, string asNumPoa, string asCodigo, int asCodSecuencial)
        {
            try
            {
                CEntidad entInfPoa = new CEntidad();
                CLogica exeInfPoa = new CLogica();
                entInfPoa.COD_INFORME = asCodInforme;
                entInfPoa.COD_THABILITANTE = asCodTHabilitante;
                entInfPoa.NUM_POA = Convert.ToInt32(asNumPoa);
                entInfPoa.CODIGO = asCodigo;
                entInfPoa.COD_SECUENCIAL = asCodSecuencial;

                List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> olMade = exeInfPoa.DatosNoMaderable(entInfPoa);
                //var lstPoa = exeInfPoa.DatosMaderable(entInfPoa).ListPOAs;

                var jsonResult = Json(new { success = true, data = olMade }, JsonRequestBehavior.AllowGet);
                //var jsonResult = Json(new { success = true, data = lstPoa.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asCodInforme"></param>
        /// <param name="aiNumPoa"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _EspecieTrozaCampoEdit(string asCodInforme, string asCodTHabilitante, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodTHabilitante = asCodTHabilitante;
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        [HttpPost]
        public JsonResult GetDatosTrozaCampo(string asCodInforme, string asNumPoa, string asCodigo)
        {
            try
            {
                CEntidad entInfPoa = new CEntidad();
                CLogica exeInfPoa = new CLogica();
                entInfPoa.COD_INFORME = asCodInforme;
                entInfPoa.NUM_POA = Convert.ToInt32(asNumPoa);
                entInfPoa.CODIGO = asCodigo;

                List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> olMade = exeInfPoa.DatosTrozaCampo(entInfPoa);

                var jsonResult = Json(new { success = true, data = olMade }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asCodInforme"></param>
        /// <param name="aiNumPoa"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _EspecieMaderaAserradaEdit(string asCodInforme, string asCodTHabilitante, Int32 aiNumPoa)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfCodTHabilitante = asCodTHabilitante;
            ViewBag.hdfNumPoa = aiNumPoa;
            return PartialView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        [HttpPost]
        public JsonResult GetDatosMaderaAserrada(string asCodInforme, string asNumPoa, string asCodigo)
        {
            try
            {
                CEntidad entInfPoa = new CEntidad();
                CLogica exeInfPoa = new CLogica();
                entInfPoa.COD_INFORME = asCodInforme;
                entInfPoa.NUM_POA = Convert.ToInt32(asNumPoa);
                entInfPoa.CODIGO = asCodigo;

                List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> olMade = exeInfPoa.DatosMaderaAserrada(entInfPoa);

                var jsonResult = Json(new { success = true, data = olMade }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _EspecieCarrizoCampoEdit(string asCodInforme, Int32 aiNumPoa, string asCodMTipo)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlProducto = exeBus.RegMostComboIndividual("PRODUCTOE", "");
            ViewBag.hdfCodInforme = asCodInforme;
            ViewBag.hdfNumPoa = aiNumPoa;
            ViewBag.hdfCodMTipo = asCodMTipo;
            return PartialView();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _ReporteAnalisis(string asCodInforme)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.hdfCodInforme = asCodInforme;

            return PartialView();
        }

        #endregion

        #endregion

        #region "Mantenimiento Datos Desplazamiento Supervisión"
        [HttpPost]
        public PartialViewResult _Desplazamiento()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            ViewBag.ddlTipoVia = exeBus.RegMostComboIndividual("DESPLAZAMIENTO_SUPERVISION", "");
            return PartialView();
        }
        #endregion
        #region "Informe Digital - Tramite"
        [HttpPost]
        public JsonResult TramiteGuardar(VM_TRAMITE tramite)
        {
            bool success = false; string msj = "";
            VM_TRAMITE tramiteVerificar = null;
            // VM_INFORME_DIGITAL iDigital = null;
            int tramiteId = 0;
            try
            {
                Log_Informe_Digital CLogInforme = new Log_Informe_Digital();


                /* prueba
                 iDigital = CLogInforme.ObtenerInformeDigitalShort(tramite.cod_Informe);

                this.ModificarInformeWord(iDigital.COD_INFORME_DIGITAL, iDigital.ARCHIVO, "correlativo", "clave");

                return Json(new { success, msj, data = tramiteVerificar });*/

                tramiteVerificar = CLogInforme.TramiteGetById(tramiteId, tramite.cod_THabilitante, tramite.cod_Informe);

                if (tramiteVerificar == null)
                {
                    tramiteId = CLogInforme.TramiteGrabar(tramite);
                    if (tramiteId > 0)
                    {

                        tramiteVerificar = CLogInforme.TramiteGetById(tramiteId, tramite.cod_THabilitante, tramite.cod_Informe);

                        //actualizando número de informe de supervisión
                        tramiteVerificar.cCodificacion = tramiteVerificar.cCodificacion ?? "";

                        CLogica logInforme = new CLogica();
                        logInforme.ModificarNumeroInforme(tramiteVerificar.cod_Informe, tramiteVerificar.cCodificacion, tramiteVerificar.cAsunto, DateTime.Now);

                        //actualizando Informe digital
                        CLogInforme.ActualizarDatosSITD(tramiteVerificar.cod_Informe, tramiteVerificar.cCodificacion, tramiteVerificar.iCodTramite,
                                                         tramiteVerificar.fechaRegistro, DateTime.Now, (ModelSession.GetSession())[0].COD_UCUENTA);
                        success = true;
                        msj = "Datos guardados Correctamente";
                    }
                    else
                    {
                        success = false;
                        msj = "Error al guardar los datos";
                    }
                }
                else
                {
                    success = false;
                    msj = "Existe datos registrados referente al informe, no se puede continuar con la operación";
                }

            }
            catch (Exception ex)
            {
                success = false;
                msj = ex.Message;
            }

            return Json(new { success, msj, data = tramiteVerificar });
        }
        private void GuardarMemoryStream(MemoryStream ms, string fileName)
        {
            FileStream outStream = System.IO.File.OpenWrite(fileName);
            ms.WriteTo(outStream);
            outStream.Flush();
            outStream.Close();
        }
        private void ModificarInformeWord(string codInformeDigital, string archivo, string correlativo, string clave)
        {
            string path = Server.MapPath("~/" +
                System.Configuration.ConfigurationManager.AppSettings["pathInformeDigital"]);
            string pathFolder = Path.Combine(path, codInformeDigital);
            string pathFile = Path.Combine(pathFolder, archivo);
            if (System.IO.File.Exists(pathFile))
            {
                byte[] byteFile = System.IO.File.ReadAllBytes(pathFile);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteFile, 0, (int)byteFile.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        var body = wordDoc.MainDocumentPart.Document.Body;
                        var paras = body.Elements<wp.Paragraph>();
                        HelperWord.BuscarReemplazarTexto(paras, "VAR_CORRELATIVO_SITD", correlativo);
                        HelperWord.SearchAndReplace(wordDoc, "VAR_PASSWORD_SITD", clave, true);
                        wordDoc.Close();
                    }
                    this.GuardarMemoryStream(mem, pathFile);
                }
            }
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
            var oficina = new Log_Informe_Digital().TramiteGeneralListar("OFICINA", "");
            var tipoDocumento = new Log_Informe_Digital().TramiteGeneralListar("TIPO_DOCUMENTO", "");
            var indicacion = new Log_Informe_Digital().TramiteGeneralListar("INDICACION_MOTIVO", "");
            var prioridad = new List<VM_Cbo>() {
                new VM_Cbo { Value = "Alta", Text = "Alta" },
                new VM_Cbo { Value="Media",Text="Media"},
                new VM_Cbo { Value="Baja",Text="Baja"}
            };
            return Json(new { success, msj, oficina, tipoDocumento, indicacion, prioridad }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult TramiteModificar(VM_TRAMITE tramite)
        {
            bool success = false; string msj = "";
            VM_TRAMITE tramiteVerificar = null;
            try
            {
                Log_Informe_Digital CLogInforme = new Log_Informe_Digital();
                tramiteVerificar = CLogInforme.TramiteGetById(tramite.iCodTramite, tramite.cod_THabilitante, tramite.cod_Informe);
                if (tramiteVerificar != null)
                {
                    CLogInforme.TramiteModificar(tramite);

                    //actualizando número de informe de supervisión
                    CLogica logInforme = new CLogica();

                    tramiteVerificar.cCodificacion = tramiteVerificar.cCodificacion ?? "";
                    logInforme.ModificarNumeroInforme(tramiteVerificar.cod_Informe, tramiteVerificar.cCodificacion, tramiteVerificar.cAsunto, DateTime.Now);

                    //actualizando Informe digital
                    CLogInforme.ActualizarDatosSITD(tramiteVerificar.cod_Informe, tramiteVerificar.cCodificacion, tramiteVerificar.iCodTramite,
                                                     tramiteVerificar.fechaRegistro, DateTime.Now, (ModelSession.GetSession())[0].COD_UCUENTA);
                }


                success = true;
                msj = "Datos actualizados Correctamente";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al actualizar los datos";
            }

            return Json(new { success, msj, data = tramiteVerificar });
        }
        #endregion
        #region Informe Digital
        //public PartialViewResult _InformeDigital()
        //{
        //var CLogInforme = new Log_Informe_Digital();
        //var result = CLogInforme.GeneralListar("INFORME_DIGITAL_DESTINATARIO", "");
        //return PartialView();
        //}

        public string UrlBase {
            get {
                return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            }
        }

        public string PathCkeditor {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["pathCkeditor"];
            }
        }

        public JsonResult ckEditor()
        {
            //string command = Request["command"];

            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;

                HttpPostedFileBase file = files[0];
                string extension = Path.GetExtension(file.FileName);
                string name = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), extension);

                //Configuracion base
                string folderBase = this.PathCkeditor;

                string folder = Server.MapPath("~/" + folderBase);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                file.SaveAs(folder + "/" + name);

                string url = string.Format("{0}{1}/{2}", this.UrlBase, folderBase, name);

                return Json(new { fileName = name, uploaded = 1, url = url });
            }

            return Json(new { error = new { message = "No hay imágenes para cargar" } });
        }

        [HttpPost]
        public JsonResult NotificarAEspecialista(string codInforme, string codInformeDigital, string numTH)
        {
            bool success = false; string msj = "";
            Log_Informe_Digital logInforme = new Log_Informe_Digital();
            bool existeArchivo = false;
            bool existeEspecialista = false;
            string codEspecialista = string.Empty, especialista = string.Empty, correo = string.Empty;
            VM_INFORME_DIGITAL iDigital = null;


            try
            {
                iDigital = logInforme.ObtenerInformeDigitalShort(codInforme);
                if (iDigital == null) throw new Exception();

                iDigital.ARCHIVO = iDigital.ARCHIVO == null ? "" : iDigital.ARCHIVO.Trim();
                existeArchivo = !string.IsNullOrEmpty(iDigital.ARCHIVO);
                logInforme.IDigitalEspecialistaCalidadObtener(codInforme, out codEspecialista, out especialista, out correo);
                existeEspecialista = !string.IsNullOrEmpty(codEspecialista);
                if (!existeArchivo) throw new Exception("0|No existe archivo");
                if (!existeEspecialista) throw new Exception("0|Por favor registre un especialista de control de calidad para continuar con la operación");

                //validando correo
                bool isEmail = Regex.IsMatch(correo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    throw new Exception($"0|El correo del especialista {especialista} no tiene un formato adecuado");
                }

                //notificar
                logInforme.NotificarControlCalidad(codInforme, numTH, correo, especialista);
                //Actualizar estado
                //1-Creado  5-Revisión  2-Cerrado  3-Archivo cargado  4-Transferido al SITD
                logInforme.CambiarEstado(codInformeDigital, DateTime.Now, 5, (ModelSession.GetSession())[0].COD_UCUENTA);


                success = true;
                msj = $"Se notifico correctamente al correo {correo} del especialista {especialista}";

            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                else msj = "Error al notificar al especialista";
                success = false;
            }
            return Json(new { success, msj });
        }
        [HttpGet]
        public JsonResult GetInfoInformeDigital(string COD_INFORME, string COD_MTIPO)
        {
            bool success = false; string message = string.Empty;
            Log_Informe_Digital CLogInforme = new Log_Informe_Digital();
            List<VM_INFORME_DIGITAL> cabecera = null;
            VM_INFORME_DIGITAL iDigital = null;
            List<VM_INFORME_DIGITAL_ANTECEDENTE> antecedentes = null;
            List<THabilitantePOA> planManejoTH_Obs = null;
            List<VM_INFORME_DIGITAL_VERTICE> vertices = null;
            List<VM_INFORME_DIGITAL_PM> planManejo = null;
            List<VM_EVALUACION_VERTICE> verticeTHSupervisado = new List<VM_EVALUACION_VERTICE>();
            string oficinaDefault = string.Empty;
            try
            {
                switch (COD_MTIPO)
                {   //modalidad Maderable
                    case "0000019":  //Sistemas Agroforestales	   
                    case "0000006":  //Bosques Secos	            
                    case "0000014":  //  Predio Privado
                    case "0000016":  // Comunidad Campesina	    
                    case "0000015":  // Comunidad Nativa
                    case "0000007": //Maderables
                    case "0000010"://Forestación y/o Reforestación
                    case "0000017": //Bosques Locales	                  
                        cabecera = CLogInforme.ObtenerCabeceraMaderable(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesMaderable(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);

                        planManejoTH_Obs = CLogInforme.getPlanManejoTHabilitanteObservatorio(cabecera.FirstOrDefault().COD_THABILITANTE);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_PLANMaderable(cabecera.FirstOrDefault().COD_THABILITANTE, cabecera.FirstOrDefault().NUM_POA_PRINCIPAL) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = CLogInforme.PlanManejoListarMaderable(COD_INFORME);
                        verticeTHSupervisado = CLogInforme.ObtenerVerticeTHSupervisado(COD_INFORME);
                        success = true;
                        break;
                    //Modalidad no Maderable
                    case "0000018": //No Maderables Aguaje
                    case "0000008": //No Maderables Castaña
                    case "0000009": //No Maderables Shiringa
                        cabecera = CLogInforme.ObtenerCabeceraNoMaderable(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesNoMaderable(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);

                        planManejoTH_Obs = CLogInforme.getPlanManejoTHabilitanteObservatorio(cabecera.FirstOrDefault().COD_THABILITANTE);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_PLANMaderable(cabecera.FirstOrDefault().COD_THABILITANTE, cabecera.FirstOrDefault().NUM_POA_PRINCIPAL) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = CLogInforme.PlanManejoListarMaderable(COD_INFORME);
                        verticeTHSupervisado = CLogInforme.ObtenerVerticeTHSupervisado(COD_INFORME);
                        success = true;
                        break;
                    case "0000027": //Musgo
                    case "0000022"://Shiringa
                    case "0000021": //Plantas medicinales
                    case "0000020": //Carrizo, bambú, totora, junco, otros acuáticos
                    case "0000026": //Plantas medicinales
                    case "0000025": //Carrizo, bambú, totora, junco, otros acuáticos
                        cabecera = CLogInforme.ObtenerCabeceraNoMaderable(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesNoMaderable(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);

                        planManejoTH_Obs = CLogInforme.getPlanManejoTHabilitanteObservatorio(cabecera.FirstOrDefault().COD_THABILITANTE);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_PLANMaderable(cabecera.FirstOrDefault().COD_THABILITANTE, cabecera.FirstOrDefault().NUM_POA_PRINCIPAL) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = CLogInforme.PlanManejoListarMaderable(COD_INFORME);
                        verticeTHSupervisado = CLogInforme.ObtenerVerticeTHSupervisado(COD_INFORME);
                        success = true;
                        break;
                    case "0000005"://Tara
                        cabecera = CLogInforme.ObtenerCabeceraNoMaderableEC(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesNoMaderableEC(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);
                        planManejoTH_Obs = CLogInforme.getPlanManejoTHabilitanteObservatorio(cabecera.FirstOrDefault().COD_THABILITANTE);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_PLANMaderable(cabecera.FirstOrDefault().COD_THABILITANTE, 0) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = new List<VM_INFORME_DIGITAL_PM>();
                        success = true;
                        break;
                    case "0000011"://Ecoturismo
                    case "0000012"://Conservación
                        cabecera = CLogInforme.ObtenerCabeceraNoMaderableEC(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesNoMaderableEC(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);
                        planManejoTH_Obs = CLogInforme.getPlanManejoTHabilitanteObservatorio(cabecera.FirstOrDefault().COD_THABILITANTE);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_PLANMaderable(cabecera.FirstOrDefault().COD_THABILITANTE, 0) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = new List<VM_INFORME_DIGITAL_PM>();
                        success = true;
                        break;
                    //Fauna
                    case "0000013"://Fauna Silvestre
                        cabecera = CLogInforme.ObtenerCabeceraFaunaConcesiones(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesFaunaConcesiones(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_Fauna(cabecera.FirstOrDefault().COD_THABILITANTE) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = CLogInforme.PlanManejoListarMaderable(COD_INFORME);
                        //  planManejo = new List<VM_INFORME_DIGITAL_PM>();
                        success = true;
                        break;
                    //Fauna Autorizaciones
                    case "0000001"://Zoológicos
                    case "0000002"://Zoocriaderos
                    case "0000003"://Centros de Rescate
                    case "0000004"://Centros de Custodia Temporal 
                    case "0000023"://Centro de Conservación
                    case "0000028"://Comunidad Nativa
                        cabecera = CLogInforme.ObtenerCabeceraFauna(COD_INFORME);//se trae informacion de las distitntas fuentes
                        iDigital = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ COD_INFORME); //se trae informacion de la base de datos de informe digital
                        antecedentes = CLogInforme.ObtenerAntecedentesFauna(COD_INFORME, cabecera.FirstOrDefault().COD_THABILITANTE, COD_MTIPO);
                        // planManejoTH_Obs = CLogInforme.getPlanManejoTHabilitanteObservatorio(cabecera.FirstOrDefault().COD_THABILITANTE);
                        vertices = cabecera.Count() > 0 ? CLogInforme.ObtenerVerticeTH_Fauna(cabecera.FirstOrDefault().COD_THABILITANTE) : new List<VM_INFORME_DIGITAL_VERTICE>();
                        planManejo = new List<VM_INFORME_DIGITAL_PM>();
                        success = true;
                        break;
                    default:
                        message = $"Falta implementar la obtención de datos para la modalidad con código {COD_MTIPO}";
                        break;


                }
                oficinaDefault = CLogInforme.ObtenerOficinaXModalidad(COD_MTIPO);
            }
            catch (Exception ex)
            {
                message = $"Sucedió un error en el servidor. {ex.Message}";
            }
            var jsonResult = Json(new { success, message, cabecera, antecedentes, planManejoTH_Obs, vertices, verticeTHSupervisado, iDigital, planManejo, oficinaDefault }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult InformeDigitalGeneralListar(string busCriterio, string busValor)
        {
            var CLogInforme = new Log_Informe_Digital();
            var result = CLogInforme.GeneralListar(busCriterio, busValor);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #region "Mantenimiento PersonalTécnicoProfesional"
        [HttpPost]
        public PartialViewResult _PersonalTecProf()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlTipoPersonalTECPROF = exeBus.RegMostComboIndividual("TIPO_PERSONAL", "");
            return PartialView();
        }
        #endregion        
        [HttpPost]
        public JsonResult CambiarEstadoDigital(string codInformeDigital, int estado)
        {
            bool success = false; string msj = "";

            try
            {
                Log_Informe_Digital CLogInforme = new Log_Informe_Digital();
                success = CLogInforme.CambiarEstado(codInformeDigital, DateTime.Now, estado, (ModelSession.GetSession())[0].COD_UCUENTA);
                msj = success ? "Estado actualizado Correctamente" : "No se pudo actualizar el estado";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al actualizar el estado";
            }

            return Json(new { success, msj });
        }
        [HttpPost]
        public JsonResult EliminarDigital(string COD_INFORME)
        {
            bool success = false; string msj = "";

            try
            {
                Log_Informe_Digital CLogInforme = new Log_Informe_Digital();
                success = CLogInforme.Eliminar(COD_INFORME, (ModelSession.GetSession())[0].COD_UCUENTA, DateTime.Now);
                msj = "Informe digital eliminado Correctamente";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al eliminar los datos";
            }

            return Json(new { success, msj });
        }
        [HttpPost]
        public JsonResult GuardarInformeDigital(VM_INFORME_DIGITAL informeDigital)
        {
            bool success = false; string msj = "", codInformeDigital = "";
            VM_INFORME_DIGITAL result = null;
            try
            {
                Log_Informe_Digital CLogInforme = new Log_Informe_Digital();
                informeDigital.COD_USUARIO_OPERACION = (ModelSession.GetSession())[0].COD_UCUENTA;
                codInformeDigital = CLogInforme.RegGrabar(informeDigital);
                result = CLogInforme.ObtenerInformeDigital(/*codInformeDigital,*/ informeDigital.COD_INFORME);
                success = true;
                msj = "Datos guardados Correctamente";
            }
            catch (Exception)
            {
                success = false;
                msj = "Error al guardar los datos";
            }

            var jsonResult = Json(new { success, msj, data = result });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult ValidarAntesIniciarFirma(string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInformeDigitalPDF"]);
            try
            {
                var usuarioLogin = (ModelSession.GetSession())[0];

                //validar existencia del documento 
                string pathGenerado = Path.Combine(pathDocumento, $"{codificacion}");
                if (!System.IO.File.Exists(pathGenerado))
                {
                    throw new Exception($"0|No existe el documento {codificacion} a firmar");
                }

                List<VM_SUPERVISOR> supervisores = new Log_Informe_Digital().SupervisorObtenerPorInformeAll(codInforme);
                if (supervisores.Count == 0)
                {
                    throw new Exception("0|El informe no tiene supervisor asignado para continuar con la firma");
                }
                if (supervisores.Count > 0)
                {
                    int cantidadSupervisor = supervisores.Count();
                    int cantidadFirmados = 0;
                    foreach (var item in supervisores)
                    {
                        if (item.FLAG_FIRMA == 1) cantidadFirmados = cantidadFirmados + 1;
                    }
                    if (cantidadSupervisor == cantidadFirmados)
                    {
                        if (cantidadFirmados == 1) throw new Exception($"0|El informe ya cuenta con {cantidadFirmados} firma");
                        else throw new Exception($"0|El informe ya cuenta con {cantidadFirmados} firmas");
                    }
                }
                VM_SUPERVISOR supervisor = new Log_Informe_Digital().SupervisorObtenerPorInforme(codInforme, usuarioLogin.COD_PERSONA);
                if (supervisor == null)
                {
                    throw new Exception($"0|El usuario {usuarioLogin.USUARIO_LOGIN} no tiene permisos para firmar el documento");
                }
                else
                {
                    if (supervisor.FLAG_FIRMA == 1) throw new Exception($"0|El usuario {usuarioLogin.USUARIO_LOGIN} ya firmó el documento");
                }

                success = true;
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
                string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInformeDigitalPDF"]);
                var usuarioLogin = (ModelSession.GetSession())[0];
                success = new Log_Informe_Digital().AnularFirmaPorInforme(codInforme);
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
        [HttpPost]
        public JsonResult TransferirDocSITD(int tramiteId, string codInformeDigital, string codInforme, string codificacion)
        {
            bool success = false; string msj = "";
            string pathDocumentoOrigen = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInformeDigitalPDF"]);
            string pathDocumentoDestino = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathTransferidoSITD"]);
            string pathGeneradoOrigen = string.Empty, pathGeneradoDestino = string.Empty, nombreDocumentoNuevo = string.Empty;
            Log_Informe_Digital CLogInforme = null;
            try
            {
                var usuarioLogin = (ModelSession.GetSession())[0];
                CLogInforme = new Log_Informe_Digital();

                //validando antes de transferir
                List<VM_SUPERVISOR> supervisores = new Log_Informe_Digital().SupervisorObtenerPorInformeAll(codInforme);
                if (supervisores.Count == 0)
                {
                    throw new Exception("0|El informe no tiene supervisor asignado para continuar con la operación");
                }
                if (supervisores.Count > 0)
                {
                    int cantidadSupervisor = supervisores.Count();
                    int cantidadFirmados = 0;
                    foreach (var item in supervisores)
                    {
                        if (item.FLAG_FIRMA == 1) cantidadFirmados = cantidadFirmados + 1;
                    }
                    if (cantidadSupervisor != cantidadFirmados)
                    {
                        if (cantidadSupervisor == 1)
                        {
                            throw new Exception($"0|Falta firmar el informe por el supervisor {supervisores[0].APELLIDOS_NOMBRES} para continuar con la operación");
                        }
                        else
                        {
                            throw new Exception($"0|Falta firmar el informe para continuar con la operación");
                        }

                    }
                }
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



                if (System.IO.File.Exists(pathGeneradoDestino))
                { //si existe no se debe poder reemplazar ni eliminar del repositorio del SITD
                    throw new Exception($"0|El documento con el nombre {nombreDocumentoNuevo} existe en el repositorio del SITD, por lo tanto no se puede transferir. !!Comunicar a Soporte");
                }
                //cambiando de ubicación el archivo
                try
                {  /*
                    if (System.IO.File.Exists(pathGeneradoDestino))
                    {
                        System.IO.File.Delete(pathGeneradoDestino);
                    }*/
                    System.IO.File.Move(pathGeneradoOrigen, pathGeneradoDestino);
                }
                catch (Exception)
                {
                    throw new Exception($"0|Sucedió un error al mover el archivo al repositorio de trámite");
                }

                //cambiando a estado 4 Transferido documento a trámite
                success = CLogInforme.CambiarEstado(codInformeDigital, DateTime.Now, 4, (ModelSession.GetSession())[0].COD_UCUENTA);

                if (success)
                {
                    CLogInforme.TramiteDigitalGrabar(tramiteId, codificacion, nombreDocumentoNuevo, DateTime.Now);
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
        public JsonResult ActualizarEstadoFirmaSupervisor(string codInforme)
        {
            bool success = false; string msj = "";
            var usuarioLogin = (ModelSession.GetSession())[0];
            try
            {

                success = new Log_Informe_Digital().ActualizarFirmaPorInformeSupervisor(codInforme, usuarioLogin.COD_PERSONA);

            }
            catch (Exception)
            {
                success = false;
                msj = "Error al actualizar el estado de firma del supervisor";
            }

            return Json(new { success, msj, codPersona = usuarioLogin.COD_PERSONA });
        }
        [HttpPost]
        public JsonResult EliminarInformeDigital(String COD_INFORME_DIGITAL, string COD_INFORME)
        {
            string nombreArchivo = "";
            try
            {
                var iDigital = new Log_Informe_Digital().ObtenerInformeDigitalShort(COD_INFORME);
                nombreArchivo = iDigital.ARCHIVO;
                VM_INFORME_DIGITAL informeDigital = new VM_INFORME_DIGITAL();
                informeDigital.COD_INFORME_DIGITAL = COD_INFORME_DIGITAL;
                informeDigital.INFORME_DIGITAL = "";
                new Log_Informe_Digital().ImportarInformeDigital(informeDigital, "DELETE");


                try
                {
                    //eliminando archivo
                    string pathDocumento = Server.MapPath("~/" +
                     System.Configuration.ConfigurationManager.AppSettings["pathInformeDigital"]);

                    string codInformeDigital = COD_INFORME_DIGITAL;
                    string pathFolderGenerado = Path.Combine(pathDocumento, codInformeDigital);
                    if (System.IO.File.Exists(Path.Combine(pathFolderGenerado, nombreArchivo)))
                        System.IO.File.Delete(Path.Combine(pathFolderGenerado, nombreArchivo));
                }
                catch (Exception) { }
                return Json(new { success = true, msj = "Archivo eliminado correctamente" });
            }
            catch (Exception)
            {
                return Json(new { success = false, msj = "Sucedió un error al eliminar el archivo" });
            }
        }
        [HttpPost]
        public JsonResult CargarInformeDigital()
        {
            string pathDocumento = Server.MapPath("~/" +
                System.Configuration.ConfigurationManager.AppSettings["pathInformeDigital"]);
            if (Request.Files.Count > 0)
            {
                try
                {
                    var usuarioLogin = (ModelSession.GetSession())[0];
                    string codInformeDigital = Request["codInformeDigital"].ToString();
                    string pathFolderGenerado = Path.Combine(pathDocumento, codInformeDigital);
                    if (!Directory.Exists(pathFolderGenerado))
                    {
                        Directory.CreateDirectory(pathFolderGenerado);
                    }
                    HttpPostedFileBase file = Request.Files[0];
                    file.SaveAs(Path.Combine(pathFolderGenerado, file.FileName));
                    VM_INFORME_DIGITAL informeDigital = new VM_INFORME_DIGITAL();
                    informeDigital.COD_INFORME_DIGITAL = codInformeDigital;
                    informeDigital.INFORME_DIGITAL = file.FileName;
                    new Log_Informe_Digital().ImportarInformeDigital(informeDigital);

                    return Json(new { success = true, archivo = informeDigital.INFORME_DIGITAL, msj = "Archivo subido correctamente" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, msj = "Sucedió un error al subir el archivo", error = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "Seleccione un archivo correctamente" });
            }
        }
        [HttpPost]
        public JsonResult CargarDocumentoFinal()
        {
            string pathDocumento = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["pathInformeDigitalPDF"]);
            if (Request.Files.Count > 0)
            {
                try
                {
                    var usuarioLogin = (ModelSession.GetSession())[0];
                    string codificacion = Request["codificacion"].ToString();
                    string codInformeDigital = Request["codInformeDigital"].ToString();
                    string pathGenerado = "";
                    if (!Directory.Exists(pathDocumento))
                    {
                        Directory.CreateDirectory(pathDocumento);
                    }
                    HttpPostedFileBase file = Request.Files[0];
                    // codificacion = this.LimpiarCadena(codificacion);
                    // pathGenerado = Path.Combine(pathDocumento, $"{codificacion}.pdf");
                    pathGenerado = Path.Combine(pathDocumento, $"{codificacion}");

                    /*if (System.IO.File.Exists(pathGenerado))
                    {
                        return Json(new { success = true, msj = "El archivo ya se encuentra cargado al sistema" });
                    }*/
                    file.SaveAs(pathGenerado);

                    //cambiando estado 3 - Cargado archivo 
                    new Log_Informe_Digital().CambiarEstado(codInformeDigital, DateTime.Now, 3, usuarioLogin.COD_UCUENTA);

                    return Json(new { success = true, msj = "Archivo subido correctamente" });
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
        private string LimpiarCadena(string cadena)
        {
            try
            {
                // Quitando Tilde de cadena

                string accentedStr = cadena;
                byte[] tempBytes;
                tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
                string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
                cadena = asciiStr;
                // Quitando caracteres especiales de cadena
                cadena = System.Text.RegularExpressions.Regex.Replace(cadena, @"[^\w\s.!@$%^&*()\-\/]+", "").Replace("/", "-");
                //cadena = cadena.Replace(".", "_");
            }
            catch (Exception) { }
            return cadena;
        }
        //[HttpPost, ValidateInput(false)]
        //public ActionResult InformeDigitalDescarga(InformeDigitalSupervision data)
        //{
        //    byte[] bytePlantilla = System.IO.File.ReadAllBytes(Server.MapPath("~/Archivos/Plantilla/InformeSup/InformeDigital.docx"));

        //    using (MemoryStream mem = new MemoryStream())
        //    {
        //        mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
        //        using (WordprocessingDocument package = WordprocessingDocument.Open(mem, true))
        //        {
        //            MainDocumentPart mainPart = package.MainDocumentPart;
        //            if (mainPart == null)
        //            {
        //                mainPart = package.AddMainDocumentPart();
        //                new Document(new Body()).Save(mainPart);
        //            }

        //            HtmlConverter converter = new HtmlConverter(mainPart);
        //            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls;

        //            Body body = mainPart.Document.Body;

        //            //MARCADORES
        //            /*
        //            var bookmarks = body.Descendants<BookmarkStart>();

        //            foreach (var bookmark in bookmarks)
        //            {
        //                switch (bookmark.Name.Value)
        //                {
        //                    case "RESOLUCION_POA": ReemplazarMarcador(converter, bookmark, data.Cabecera.RESOLUCION_POA, false); break;
        //                    case "ANTECEDENTES": ReemplazarMarcador(converter, bookmark, data.Antecedentes); break;
        //                }
        //            }
        //            */

        //            var paras = body.Elements();

        //            //var paragraphs = converter.Parse(data.Antecedentes);

        //            //if (data.Cabecera != null)
        //            //{
        //            //    var tables = body.Elements<Table>();
        //            //    //var tables = paras.Where(x => x.GetType() == typeof(Table)).AsEnumerable<Table>();
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_TITULAR_SUPERVISADO", data.Cabecera.TITULAR_SUPERVISADO);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_REPRESENTANTE_LEGAL", data.Cabecera.REPRESENTANTE_LEGAL);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_NUM_THABILITANTE", data.Cabecera.NUM_THABILITANTE);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_RUC_TITULAR", data.Cabecera.RUC_TITULAR);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_DIRECCION_LEGAL", data.Cabecera.DIRECCION_LEGAL);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_TELEFONO_TITULAR", data.Cabecera.TELEFONO_TITULAR);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_AREA_THABILITANTE", data.Cabecera.AREA_THABILITANTE.ToString("#,0.#"));
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_NUMERO_PGMF", data.Cabecera.NUMERO_PGMF);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_TIPO_POA", data.Cabecera.TIPO_POA);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_FECHA_PRESENTACION_POA", data.Cabecera.FECHA_PRESENTACION_POA.HasValue ? data.Cabecera.FECHA_PRESENTACION_POA.Value.ToShortDateString() : "");
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_CONSULTOR_PGMF", data.Cabecera.CONSULTOR_PGMF);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_VIGENCIA", "2");
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_AREA_POA", data.Cabecera.AREA_POA.ToString("#,0.#"));
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_RESOLUCION_POA", data.Cabecera.RESOLUCION_POA);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_PROFESIONAL_IOCULAR_POA", data.Cabecera.PROFESIONAL_IOCULAR_POA);
        //            //    BuscarReemplazarTextoTabla(tables, "TAG_FUNCIONARIO_APROBACION_POA", data.Cabecera.FUNCIONARIO_APROBACION_POA);
        //            //}

        //            BuscarReemplazarTexto(paras, "TAG_NUM_INFORME", data.NUM_INFORME);
        //            BuscarReemplazarTexto(paras, "TAG_SUBDIRECTOR", data.DESTINATARIO);
        //            BuscarReemplazarTexto(paras, "TAG_ASUNTO", data.ASUNTO);
        //            BuscarReemplazarTexto(paras, "TAG_FECHA_CREACION", data.FECHA_CREACION);
        //            BuscarReemplazarTexto(paras, "TAG_CONTENIDO", data.CONTENIDO);
        //            BuscarReemplazarHtml(paras, converter, "TAG_TABLA_GENERAL", data.GENERAL);
        //            BuscarReemplazarHtml(paras, converter, "TAG_ANTECEDENTES", data.ANTECEDENTES);
        //            BuscarReemplazarHtml(paras, converter, "TAG_OBJETIVOS", data.OBJETIVOS);
        //            BuscarReemplazarHtml(paras, converter, "TAG_METODOLOGIA", data.METODOLOGIA);
        //            BuscarReemplazarHtml(paras, converter, "TAG_RESULTADOS", data.RESULTADOS);
        //            BuscarReemplazarHtml(paras, converter, "TAG_ANALISIS", data.ANALISIS);
        //            BuscarReemplazarHtml(paras, converter, "TAG_CONCLUSIONES", data.CONCLUSIONES);
        //            BuscarReemplazarHtml(paras, converter, "TAG_RECOMENDACIONES", data.RECOMENDACIONES);

        //            //test xml
        //            var xml = body.InnerXml;

        //            mainPart.Document.Save();

        //            package.Close();
        //        }

        //        return new BinaryContentResultDowload
        //        {
        //            FileName = "Informe" + ".docx",
        //            ContentType = "application/octet-stream",
        //            Content = mem.ToArray()
        //        };
        //    }
        //}

        //private void ReemplazarMarcador(HtmlConverter converter, OpenXmlElement bookmark, string texto, bool isHtml = true)
        //{
        //    var parent = bookmark.Parent;
        //    if (!isHtml)
        //    {
        //        texto = $"<p>{texto}</p>";
        //    }

        //    var paragraphs = converter.Parse(texto);

        //    for (int i = 0; i < paragraphs.Count(); i++)
        //    {
        //        parent.InsertBeforeSelf(paragraphs[i]);
        //    }
        //}

        //private void BuscarReemplazarHtml(IEnumerable<OpenXmlElement> paragraphs, HtmlConverter converter, string textoBuscar, string html)
        //{
        //    var elements = converter.Parse(html);

        //    //search & replace string
        //    foreach (var para in paragraphs)
        //    {
        //        foreach (var run in para.Elements<Run>())
        //        {
        //            foreach (var text in run.Elements<Text>())
        //            {
        //                if (text.Text.Trim().Contains(textoBuscar))
        //                {
        //                    text.Text = "";

        //                    for (int i = 0; i < elements.Count(); i++)
        //                    {
        //                        if (elements[i].GetType() == typeof(Table))
        //                        {
        //                            var table = (Table)elements[i];
        //                            TableProperties props = table.Elements<TableProperties>().First();
        //                            TableStyle tableStyle = new TableStyle { Val = "TableNormal" };

        //                            // Make the table width 100% of the page width.
        //                            TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

        //                            //Borders
        //                            TableBorders tableBorders = new TableBorders();

        //                            TopBorder topBorder = new TopBorder();
        //                            topBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
        //                            topBorder.Color = "BFBFBF";
        //                            tableBorders.AppendChild(topBorder);

        //                            BottomBorder bottomBorder = new BottomBorder();
        //                            bottomBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
        //                            bottomBorder.Color = "BFBFBF";
        //                            tableBorders.AppendChild(bottomBorder);

        //                            RightBorder rightBorder = new RightBorder();
        //                            rightBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
        //                            rightBorder.Color = "BFBFBF";
        //                            tableBorders.AppendChild(rightBorder);

        //                            LeftBorder leftBorder = new LeftBorder();
        //                            leftBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
        //                            leftBorder.Color = "BFBFBF";
        //                            tableBorders.AppendChild(leftBorder);

        //                            InsideHorizontalBorder insideHBorder = new InsideHorizontalBorder();
        //                            insideHBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
        //                            insideHBorder.Color = "BFBFBF";
        //                            tableBorders.AppendChild(insideHBorder);

        //                            InsideVerticalBorder insideVBorder = new InsideVerticalBorder();
        //                            insideVBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
        //                            insideVBorder.Color = "BFBFBF";
        //                            tableBorders.AppendChild(insideVBorder);

        //                            //props.Append(tableStyle, tableWidth);
        //                            props.TableStyle = tableStyle;
        //                            props.TableWidth = tableWidth;
        //                            props.TableBorders = tableBorders;

        //                            //elements[i] = table;
        //                        }

        //                        run.AppendChild(elements[i]);
        //                    }

        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}

        //private void BuscarReemplazarTexto(IEnumerable<OpenXmlElement> paragraphs, string textoBuscar, string textoReemplazar)
        //{
        //    //search & replace string
        //    foreach (var para in paragraphs)
        //    {
        //        foreach (var run in para.Elements())
        //        {
        //            foreach (var text in run.Elements<Text>())
        //            {
        //                if (text.Text.Trim().Contains(textoBuscar))
        //                {
        //                    text.Text = text.Text.Trim().Replace(textoBuscar, textoReemplazar);
        //                    //break;
        //                }
        //            }
        //        }
        //    }
        //}

        //private void BuscarReemplazarTextoTabla(IEnumerable<Table> tables, string textoBuscar, string textoReemplazar)
        //{
        //    foreach (var table in tables)
        //    {
        //        foreach (var row in table.Elements<TableRow>())
        //        {
        //            foreach (var cell in row.Elements<TableCell>())
        //            {
        //                BuscarReemplazarTexto(cell.Elements<Paragraph>(), textoBuscar, textoReemplazar);
        //            }
        //        }
        //    }
        //}

        #endregion
        //#region "Mantenimiento PersonalTécnicoProfesional"
        //[HttpPost]
        //public PartialViewResult _PersonalTecProf()
        //{
        //    CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();            
        //    ViewBag.ddlTipoPersonalTECPROF = exeBus.RegMostComboIndividual("TIPO_PERSONAL", "");
        //    return PartialView();
        //}
        //#endregion

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaInformePaging(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.pagesize = request.Length;
            paramsBus.currentpage = page;

            if (request.Order.Length != 0)
            {
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

            var jsonResult = Json(new
            {
                data = lstResult.ToArray(),
                draw = request.Draw,
                recordsTotal = rowcount,
                recordsFiltered = rowcount,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion

        #region "Formato Control de Calidad"
        [HttpGet]
        public ActionResult _FormatoControlCalidad(string COD_INFORME)
        {
            CLogica log = new CLogica();
            COD_INFORME = String.IsNullOrEmpty(COD_INFORME) ? "" : COD_INFORME.Trim();
            var lista = log.obtenerFControlCalidad(COD_INFORME);
            return PartialView(lista);
        }
        [HttpPost]
        public ActionResult GuardarFormatoControlCalidad(VM_FControlCalidadSupervision vm)
        {
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe de Supervisión");
            vm.codPerfil = mr.PERFIL;
            string codUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica log = new CLogica();
            return Json(log.registrarFControlCalidad(vm, codUsuario));
        }
        #endregion

        #region DENUNCIAS
        [HttpPost]
        public JsonResult ConsultarExpediente(IDENUNCIA dto)
        {
            CLogica_Denuncia exeInf = new CLogica_Denuncia();
            Tra_M_Tramite result = exeInf.ConsultarTramite(dto);
            return Json(result);
        }
        [HttpPost]
        public JsonResult ConsultarExpediente2(IDENUNCIA dto)
        {
            CLogica_Denuncia exeInf = new CLogica_Denuncia();
            Tra_M_Tramite result = exeInf.ConsultarTramite2(dto);
            return Json(result);
        }
        [HttpPost]
        public JsonResult listarProtocolos(IINCIDENCIA_PROTOCOLOS dto)
        {
            CLogica_Denuncia exeInf = new CLogica_Denuncia();
            List<IINCIDENCIA_PROTOCOLOS> result = exeInf.listarProtocolos(dto);
            return Json(result);
        }

        [HttpGet]
        public ActionResult modalExpediente()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult modalInforme()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult modalCartaOficios()
        {
            return PartialView();
        }
        #endregion

        //#region EXCEL
        //public FileResult ExportarTabla()
        //{
        //    string nombre_reporte = "Reporte_Informe_Supervision";
        //    try
        //    {
        //        VW_REPORTE_INFORME_SUPERVISION olResult = new CLogica_Denuncia().InformeDeSupervision();
        //        using (var excelPackage = new ExcelPackage())
        //        {
        //            excelPackage.Workbook.Properties.Author = nombre_reporte.Replace("_", " ");
        //            excelPackage.Workbook.Properties.Title = nombre_reporte.Replace("_", " ");
        //            var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte.Replace("_", " "));
        //            _genericSheet.View.ZoomScale = 100;
        //            List<string> _cabecera = new List<string>
        //            {
        //                "N° INFORME",
        //                "MODALIDAD",
        //                "TITULO HABILITANTE",
        //                "TITULAR",
        //                "Área TH Supervisado",
        //                "Aárea Plan de Manejo Supervisado",
        //                "Usuario que ingresó el registro",
        //                "Supervisor(es)",
        //                "Especialista/Jefe OD que efectúa el control de calidad",
        //                "O.D. desde donde registra la información",
        //                "Fecha salida a campo",
        //                "Fecha recepción del cheque",
        //                "Fecha cobro del cheque",
        //                "Fecha de regreso de campo",
        //                "Fecha de inicio de labores en la oficina",
        //                "Fecha de Entrega del Informe",
        //                "Año",
        //                "Fecha de recepción del Inf. de Supervisión por el Especialista de Control de Calidad",
        //                "Informe Elaborado por Tercero Supervisor",
        //            };
        //            foreach (var fechas in olResult.listadoFechas)
        //            {
        //                _cabecera.Add(fechas.padre);
        //            }
        //            int finish = epplus.pintarcabecerasInformeSupervision(_cabecera, olResult.listadoitems, _genericSheet, nombre_reporte.Replace("_", " "));
        //            _genericSheet.Cells["A3:" + epplus.convertNumberToLetter(finish) + "3"].AutoFilter = true;
        //            int rowIndex = 4;
        //            foreach (var objeto in olResult.iNFORME_CONTROL_CALIDADs)
        //            {
        //                var item = olResult.respuestasLista
        //                    .Find(info =>
        //                        info.Ent_Informe.COD_INFORME.Trim() == objeto.Ent_Informe.COD_INFORME.Trim()
        //                    );

        //                if (item != null)
        //                {
        //                    int col = 1;
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.NUMERO ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.MODALIDAD_TIPO ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.NUM_THABILITANTE ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.TITULAR ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.AREA_TH.ToString() ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.AREA_POA.ToString() ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.USUARIO_REGISTRO ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.SUPERVISOR ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.vM_FControlCalidadSupervision.eJefeODC ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.COD_OD_REGISTRO ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.FECHA_SALIDA_CAMPO ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.FECHA_RECEPCION_CHEQUE ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.FECHA_COBRO_CHEQUE ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.FECHA_REGRESO_CAMPO ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.FECHA_INICIO_LABORES ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.FECHA_ENTREGA ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.ANO.ToString() ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.vM_FControlCalidadSupervision.fechaRecepcionIS ?? string.Empty);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, objeto.Ent_Informe.ELAB_TERCERO ?? string.Empty);

        //                    VM_FControlCalidadSupervision_Det info = null;
        //                    info = item.vM_FControlCalidadSupervision.lstISupervision.Find(data => data.id == 135);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, info == null ? string.Empty : info.FECHA_VARIOS);
        //                    info = item.vM_FControlCalidadSupervision.lstISupervision.Find(data => data.id == 84);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, info == null ? string.Empty : info.FECHA_VARIOS);
        //                    info = item.vM_FControlCalidadSupervision.lstISupervision.Find(data => data.id == 85);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, info == null ? string.Empty : info.FECHA_VARIOS);
        //                    info = item.vM_FControlCalidadSupervision.lstISupervision.Find(data => data.id == 86);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, info == null ? string.Empty : info.FECHA_VARIOS);
        //                    info = item.vM_FControlCalidadSupervision.lstISupervision.Find(data => data.id == 87);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, info == null ? string.Empty : info.FECHA_VARIOS);
        //                    info = item.vM_FControlCalidadSupervision.lstISupervision.Find(data => data.id == 136);
        //                    epplus._texto_row(_genericSheet, rowIndex, col++, info == null ? string.Empty : info.FECHA_VARIOS);
        //                    foreach (var items in olResult.listadoitems)
        //                    {
        //                        foreach (var rpta in item.vM_FControlCalidadSupervision.lstISupervision)
        //                        {
        //                            if (rpta.codigo.Equals(items.codigo))
        //                            {
        //                                epplus._texto_row(_genericSheet, rowIndex, col++, rpta.PRESENTA_OBS.Equals("S") ? rpta.PRESENTA_OBS + "-" + rpta.codigo : string.Empty);
        //                                epplus._texto_row(_genericSheet, rowIndex, col++, rpta.PRESENTA_OBS.Equals("N") ? rpta.PRESENTA_OBS + "-" + rpta.codigo : string.Empty);
        //                                epplus._texto_row(_genericSheet, rowIndex, col++, rpta.DETALLE.Trim());
        //                            }
        //                        }
        //                    }
        //                    rowIndex++;
        //                }
        //            }
        //            _genericSheet.Row(3).Height = 50;
        //            _genericSheet.View.FreezePanes(4, 2);
        //            return File(excelPackage.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string x = ex.Message;
        //        return File(System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Content\images\General\", "Delete-file-icon.png")), "image/png");
        //    }
        //}
        //#endregion

        #region "Reportes" 
        //llanos
        public FileResult ExportarConsolidado(string asCodInf, int iNumPoa, string idPC)
        {
            /*En caso se experimente problemas al exportar, revisar los caracteres especiales como ', "*/
            ListResult result = ExportarDatos.Consolidado(asCodInf, iNumPoa, idPC);

            return File(result.byteFile, "application/xlsx", "Consolidado.xlsx");
        }

        public FileResult ExportarMaderable(string asCodInf, int iNumPoa, string idPC)
        {
            /*En caso se experimente problemas al exportar, revisar los caracteres especiales como ', "*/
            ListResult result = ExportarDatos.Maderable(asCodInf, iNumPoa, idPC);

            return File(result.byteFile, "application/xlsx", "Maderable.xlsx");
        }

        #endregion

        #region Informe Digital
        [HttpGet]
        public ActionResult _InformeDigital()
        {
            //CLogica log = new CLogica();
            //COD_INFORME = String.IsNullOrEmpty(COD_INFORME) ? "" : COD_INFORME.Trim();
            //var lista = log.obtenerFControlCalidad(COD_INFORME);
            return PartialView();
        }
        #endregion

        #region Resumen Informe

        [HttpGet]
        public JsonResult _DataResumenInforme(string asCodInforme)
        {
            CLogica exeInf = new CLogica();
            //Volumenes
            VM_Informe_POASupervisado data = exeInf.InitDatosResumenSupervisado(asCodInforme);
            //Especies
            List<Ent_INFORME_MADERABLE> olMade = exeInf.RegMostrarMuestraDatosCampoMade(asCodInforme);
            return Json(new { volumenes = data.tbVolumenAnalizado, especies = olMade }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _ResumenInforme(string asCodInforme)
        {
            //CLogica exeInf = new CLogica();
            //VM_Informe_POASupervisado vm = exeInf.InitDatosResumenSupervisado(asCodInforme);
            ViewBag.COD_INFORME = asCodInforme;
            return PartialView();
        }

        #endregion
    }

    public class InformeDigitalSupervision
    {
        public VM_INFORME_DIGITAL Cabecera { get; set; }

        public string NUM_INFORME { get; set; }
        public string DESTINATARIO { get; set; }
        public string FECHA_CREACION { get; set; }
        public string ASUNTO { get; set; }
        public string CONTENIDO { get; set; }
        public string GENERAL { get; set; }
        public string ANTECEDENTES { get; set; }
        public string RESULTADOS { get; set; }
        public string OBJETIVOS { get; set; }
        public string METODOLOGIA { get; set; }
        public string ANALISIS { get; set; }
        public string CONCLUSIONES { get; set; }
        public string RECOMENDACIONES { get; set; }

    }
}