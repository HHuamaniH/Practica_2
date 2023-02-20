using CapaEntidad.ViewModel;
using Newtonsoft.Json;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Obligacion;
using CEntidad = CapaEntidad.DOC.Ent_Obligacion;
using System.Configuration;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManObligacionesController : Controller
    {
        string url = ConfigurationManager.AppSettings["urlMiBosque"].ToString();

        // GET: THabilitante/ManObligaciones
        public ActionResult Index()
        {
            try
            {
                ViewBag.TituloFormulario = "Obligación";

                using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                    obj.Encoding = UTF8Encoding.UTF8;

                    var data = obj.UploadString(new Uri(url + "Obligaciones/ListarTipos"),"{}");
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(data);

                    List<VM_Cbo> lstCboTipoObligacion = new List<VM_Cbo>();
                    lstCboTipoObligacion.Add(new VM_Cbo() { Value = "0", Text = "Todos" });

                    foreach (var item in jsonObject)
                    {
                        lstCboTipoObligacion.Add(new VM_Cbo() { Value = item.id, Text = item.vA_OBLIGACION });
                    }

                    ViewBag.ddlTipoObligacion = lstCboTipoObligacion;
                }

                ViewBag.ddlEstado = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "2", Text = "ENVIADO" },
                    new VM_Cbo { Value = "3", Text = "APROBADO" },
                    new VM_Cbo { Value = "4", Text = "OBSERVADO" }
                };

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public JsonResult GetListaObligacion(int tipo_obligacion, int estado)
        {
            try
            {
                dynamic jsonObject;

                using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                    obj.Encoding = UTF8Encoding.UTF8;

                    var param = "{\"NU_OBLIGACION_BUSQUEDA\": \""+ tipo_obligacion +"\","+
                                "\"NU_ESTADO_BUSQUEDA\": \""+ estado + "\"}";

                    var data = obj.UploadString(new Uri(url + "Obligaciones/listar"), param);
                    jsonObject = JsonConvert.DeserializeObject<CEntidad[]>(data);
                }

                var jsonResult = Json(new { data = jsonObject, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ValidarObligacion(string idobligacion, string tipo_obligacion, string desc_obligacion, string desc_estado)
        {
            try
            {
                CEntVM vm = new CEntVM();
                CEntidad objO = new CEntidad();

                //datos de obligacion
                /*using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                    obj.Encoding = UTF8Encoding.UTF8;

                    string rutacompleta = url + rutaObligacion(tipo_obligacion) + "/" + idobligacion;
                    var data = obj.DownloadString(new Uri(rutacompleta));
                    objO = JsonConvert.DeserializeObject<CEntidad>(data);
                }*/

                vm.lblTituloCabecera = "Obligación";
                vm.lblTituloEstado = "Validar Registro";
                vm.hdfCodObligacion = idobligacion;
                vm.hdfCodUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;

                using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                    obj.Encoding = UTF8Encoding.UTF8;

                    var param = "{\"NV_CODIGO_BUSQUEDA\": \"" + vm.hdfCodObligacion + "\"," +
                                "\"COD_UCUENTA\": \"" + vm.hdfCodUCuenta + "\"," +
                                "\"VANOMBREUSUARIO\": \"" + (ModelSession.GetSession())[0].PERSONA + "\"," +
                                "\"VAAPLICACIONNAME\": \"SIGO\"}";

                    var data = obj.UploadString(new Uri(url + rutaObligacion(tipo_obligacion,0) +"/Obtener"), param);
                    objO = JsonConvert.DeserializeObject<CEntidad>(data);
                }

                if (objO.isSuccess)
                {
                    objO = objO.data;

                    vm.txtUsuarioRegistro = objO.vaUsuRegistra;
                    vm.txtUsuarioControl = objO.vaUsuActualiza;

                    vm.hdfTipoObligacionId = tipo_obligacion;
                    vm.txtobservacion = objO.vaComentario;
                    vm.txttipoobligacion = desc_obligacion;
                    vm.txtfechaenviado = formatoFecha(objO.faFechaRegistro);
                    vm.hdfIdTH = objO.inIdTituloHabilitante;
                    vm.hdfIdPM = objO.inIdPlanManejo;

                    //datos del titulo habilitante
                    using (WebClient obj = new WebClient())
                    {
                        obj.Headers.Clear();
                        obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                        obj.Encoding = UTF8Encoding.UTF8;

                        var data = obj.DownloadString(new Uri(url + "TitHabilitante/?inIdTituloHabilitante=" + objO.inIdTituloHabilitante));
                        CEntidad objTH = JsonConvert.DeserializeObject<CEntidad>(data);

                        vm.txtthabilitante = objTH.result[0].vaCodigo;
                        vm.txtregion = objTH.result[0].vaDepartamento;

                    }

                    //datos del plan de manejo
                    using (WebClient obj = new WebClient())
                    {
                        obj.Headers.Clear();
                        obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                        obj.Encoding = UTF8Encoding.UTF8;

                        var data = obj.DownloadString(new Uri(url + "PlanManejo/?inIdPlanManejo=" + objO.inIdPlanManejo));
                        CEntidad objPM = JsonConvert.DeserializeObject<CEntidad>(data);

                        vm.txtmodalidad = objPM.result[0].vaModalidad;
                        vm.txttitular = objPM.result[0].vaTitularActual;
                        vm.txtpmanejo = objPM.result[0].vaResolucionAprueba;
                    }

                    vm.ddlEstado = new List<VM_Cbo>
                    {
                        new VM_Cbo { Value = "2", Text = "Seleccionar" },
                        new VM_Cbo { Value = "3", Text = "APROBADO" },
                        new VM_Cbo { Value = "4", Text = "OBSERVADO" }
                    };
                    vm.ddlEstadoId = objO.vaEstado;

                    vm.listEvento = objO.listaEvento;
                    List<CEntidad> listArchivoCoordenada;

                    switch (vm.hdfTipoObligacionId)
                    {
                        case "1": /** Informe de ejecución **/
                            vm.txtnumARFFS = objO.vaarffsNroRegistro;
                            vm.txtfechaARFFS = (!formatoFecha(objO.faarffsFecha).Equals("01/01/0001") && !formatoFecha(objO.faarffsFecha).Equals("01/01/1900")) ? formatoFecha(objO.faarffsFecha) : "";
                            vm.txtnumOSINFOR = objO.vaosinforNroRegistro;
                            vm.txtfechaOSINFOR = (!formatoFecha(objO.faosinforFecha).Equals("01/01/0001") && !formatoFecha(objO.faosinforFecha).Equals("01/01/1900")) ? formatoFecha(objO.faosinforFecha) : "";

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=1&vaNombreCategoria=EvidenciaReporteEjecucion&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado=="1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "2": /** Regente Forestal **/
                            vm.txtnomregente = objO.vaNombreRegente;
                            vm.txtfechaini = (!formatoFecha(objO.faFechaInicio).Equals("01/01/0001") && !formatoFecha(objO.faFechaInicio).Equals("01/01/1900")) ? formatoFecha(objO.faFechaInicio) : "";
                            vm.txtfechafin = (!formatoFecha(objO.faFechaFin).Equals("01/01/0001") && !formatoFecha(objO.faFechaFin).Equals("01/01/1900")) ? formatoFecha(objO.faFechaFin) : "";
                            vm.txtobsregente = objO.vaObservaciones;
                            vm.hdfCese = objO.chCese;
                            vm.txtfechacese = (!formatoFecha(objO.faFechaCese).Equals("01/01/0001") && !formatoFecha(objO.faFechaCese).Equals("01/01/1900")) ? formatoFecha(objO.faFechaCese) : "";
                            vm.txtmotivocese = objO.vaMotivoCese;

                            using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "Tipo/?vaNumGrupoTipo=6&vaNumObligacion=2&pageSize=11"));
                                var jsonObject = JsonConvert.DeserializeObject<dynamic>(data);

                                List<VM_Cbo> lstCboCategoria = new List<VM_Cbo>();

                                foreach (var item in jsonObject.result)
                                {
                                    if (item.vaNumTipo == objO.vaCategoria)
                                    {
                                        vm.txtcatregencia = item.vaTipoDescripcion;
                                    }
                                    lstCboCategoria.Add(new VM_Cbo() { Value = item.vaNumTipo, Text = item.vaTipoDescripcion });
                                }
                                vm.ddlCatRegencia = lstCboCategoria;
                                vm.ddlCatRegenciaId = objO.vaCategoria;
                            }

                            if (vm.ddlCatRegenciaId == "1" || vm.ddlCatRegenciaId == "2" || vm.ddlCatRegenciaId == "3")
                            {
                                vm.lblcomunidad_grupo = "Mención en comunidades nativas o campesinas";
                                vm.txtcomunidad_grupo = (objO.chMencionComunidades == "1") ? "SI" : "NO";
                            }
                            else if (vm.ddlCatRegenciaId == "4" || vm.ddlCatRegenciaId == "5")
                            {
                                vm.lblcomunidad_grupo = "Mención de grupo taxonómico";
                                vm.txtcomunidad_grupo = (objO.chMencionTaxonomico == "1") ? "SI" : "NO";
                            }

                            vm.listChkAlcance = new List<VM_Chk>
                            {
                                new VM_Chk { Value = "1", Text = "Elaboración del plan de manejo", Checked=(objO.chElaboracion=="1")?true:false },
                                new VM_Chk { Value = "2", Text = "Implementación del plan de manejo", Checked=(objO.chImplementacion=="1")?true:false },
                                new VM_Chk { Value = "3", Text = "Elaboración del informe de ejecución", Checked=(objO.chSuscripcion=="1")?true:false }
                            };

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=2&vaNombreCategoria=EvidenciaContratoRegencia&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "3": /** Libro de Operación **/
                            vm.txtnumregLibro = objO.vaNroRegistro;
                            vm.txtotrosistema = objO.vaOtroSistema;

                            using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "Tipo/?vaNumGrupoTipo=1&vaNumObligacion=3&pageSize=11"));
                                var jsonObject = JsonConvert.DeserializeObject<dynamic>(data);

                                List<VM_Cbo> lstCboFormaRegistro = new List<VM_Cbo>();

                                foreach (var item in jsonObject.result)
                                {
                                    if (item.vaNumTipo == objO.vaIdFormaRegistro)
                                    {
                                        vm.txtformareg = item.vaTipoDescripcion;
                                    }
                                    lstCboFormaRegistro.Add(new VM_Cbo() { Value = item.vaNumTipo, Text = item.vaTipoDescripcion });
                                }
                                vm.ddlFormaRegistro = lstCboFormaRegistro;
                                vm.ddlFormaRegistroId = objO.vaIdFormaRegistro;
                            }

                            using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "Tipo/?vaNumGrupoTipo=2&vaNumObligacion=3&pageSize=11"));
                                var jsonObject = JsonConvert.DeserializeObject<dynamic>(data);

                                List<VM_Cbo> lstCboTipoFoto = new List<VM_Cbo>();

                                foreach (var item in jsonObject.result)
                                {
                                    lstCboTipoFoto.Add(new VM_Cbo() { Value = item.vaNumTipo, Text = item.vaTipoDescripcion });
                                }
                                vm.ddlTipoFoto = lstCboTipoFoto;
                            }

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=3&vaNombreCategoria=&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;

                                foreach (var item in vm.listArchivo)
                                {
                                    foreach (var elem in vm.ddlTipoFoto)
                                    {
                                        if (elem.Value == item.vaNombreCategoria)
                                        {
                                            item.vaNombreCategoria = elem.Text;
                                        }
                                    }
                                }
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {              
                                    foreach (var elem in vm.ddlTipoFoto)
                                    {
                                        if (elem.Value == item.vaNombreCategoria)
                                        {
                                            item.vaNombreCategoria = elem.Text;
                                        }
                                    }

                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "4": /** Custodio Forestal **/
                            vm.chkactprogramada = (objO.chActividadProgramPatrullaje == "1") ? true : false;
                            vm.chkzonavulnerable = (objO.chVerificacionZonasVulnerables == "1") ? true : false;
                            vm.chkalertatemprana = (objO.chAlertaTemprana == "1") ? true : false;
                            vm.chkalertadeforest = (objO.chAlertaDesorestacion == "1") ? true : false;
                            vm.txtotromotivo = objO.vaOtroMotivo;
                            vm.chkmineriailegal = (objO.chMineriaIlegal == "1") ? true : false;
                            vm.chkcambiouso = (objO.chCambioUso == "1") ? true : false;
                            vm.chktalailegal = (objO.chTalaIlegal == "1") ? true : false;
                            vm.chkninguno = (objO.chNinguno == "1") ? true : false;
                            vm.txtotroresultado = objO.vaOtroResultado;
                            vm.txtfechapatrullaje = (!formatoFecha(objO.faFechaPatrullaje).Equals("01/01/0001") && !formatoFecha(objO.faFechaPatrullaje).Equals("01/01/1900")) ? formatoFecha(objO.faFechaPatrullaje) : "";
                            vm.txtdetallepatrullaje = objO.vaDescripcion;
                            vm.txtareaafectada = objO.vaAreaAfectada;
                            vm.txtzona = objO.vaZonaUTM;
                            vm.txtcoordEste = (objO.inCoordenadaEste == 0) ? "" : objO.inCoordenadaEste.ToString();
                            vm.txtcoordNorte = (objO.inCoordenadaNorte == 0) ? "" : objO.inCoordenadaNorte.ToString();

                            //Obtención de archivos que se adjuntarán a cada hallazgo
                            /* CEntidad objAH = new CEntidad();

                             using (WebClient obj = new WebClient())
                             {
                                 obj.Headers.Clear();
                                 obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                 obj.Encoding = UTF8Encoding.UTF8;

                                 var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=4&vaNombreCategoria=FindingCustodioForestal&vaEstado=1"));
                                 objAH = JsonConvert.DeserializeObject<CEntidad>(data);
                             }

                             //datos de hallazgo
                             using (WebClient obj = new WebClient())
                             {
                                 obj.Headers.Clear();
                                 obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                 obj.Encoding = UTF8Encoding.UTF8;

                                 var data = obj.DownloadString(new Uri(url + "CoordenadasFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=4&vaNombreCategoria=FindingCustodioForestal"));
                                 CEntidad objH = JsonConvert.DeserializeObject<CEntidad>(data);
                                 vm.listHallazgo = objH.result;

                                 foreach (var item in vm.listHallazgo)
                                 {
                                     item.objArchivo = objAH.result.Find(elem => elem.inIdElemento == item.inIdElemento);
                                 }
                             }

                             //datos de archivos de denuncia
                             using (WebClient obj = new WebClient())
                             {
                                 obj.Headers.Clear();
                                 obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                 obj.Encoding = UTF8Encoding.UTF8;

                                 var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=4&vaNombreCategoria=ResultCustodioForestal&vaEstado=1"));
                                 CEntidad objAD = JsonConvert.DeserializeObject<CEntidad>(data);
                                 vm.listArchivoDenuncia = objAD.result;
                             }

                             //datos de archivo
                             using (WebClient obj = new WebClient())
                             {
                                 obj.Headers.Clear();
                                 obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                 obj.Encoding = UTF8Encoding.UTF8;

                                 var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=4&vaNombreCategoria=EvidenciaCustodioForestal&vaEstado=1"));
                                 CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                 vm.listArchivo = objA.result;
                             }*/


                            listArchivoCoordenada = new List<CEntidad>();
                            vm.listArchivoDenuncia = new List<CEntidad>();
                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    if (item.vaNombreCategoria == "FindingCustodioForestal")
                                    {
                                        listArchivoCoordenada.Add(item);
                                    }
                                    if (item.vaNombreCategoria == "ResultCustodioForestal")
                                    {
                                        vm.listArchivoDenuncia.Add(item);
                                    }
                                    else if (item.vaNombreCategoria == "EvidenciaCustodioForestal")
                                    {
                                        vm.listArchivo.Add(item);
                                    }
                                }
                            }

                            vm.listHallazgo = new List<CEntidad>();
                            foreach (var item in objO.listaCoordenada)
                            {
                                item.objArchivo = listArchivoCoordenada.Find(elem => elem.inIdElemento == item.inIdElemento);
                                vm.listHallazgo.Add(item);
                            }
                            break;

                        case "5": /** Contrato con tercero **/
                            vm.txtfechaini = (!formatoFecha(objO.faFechaInicio).Equals("01/01/0001") && !formatoFecha(objO.faFechaInicio).Equals("01/01/1900")) ? formatoFecha(objO.faFechaInicio) : "";
                            vm.txtfechafin = (!formatoFecha(objO.faFechaFin).Equals("01/01/0001") && !formatoFecha(objO.faFechaFin).Equals("01/01/1900")) ? formatoFecha(objO.faFechaFin) : "";
                            vm.txtruc = objO.vaRucEmpresa;
                            vm.txtentidad = objO.vaNombre;
                            vm.hdfCese = objO.chCese;
                            vm.txtfechacese = (!formatoFecha(objO.faFechaCese).Equals("01/01/0001") && !formatoFecha(objO.faFechaCese).Equals("01/01/1900")) ? formatoFecha(objO.faFechaCese) : "";
                            vm.txtmotivocese = objO.vaMotivoCese;

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=5&vaNombreCategoria=EvidenciaContratoTerceros&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "6": /** Linderos, hitos u Otros **/
                            //Obtención de archivos que se adjuntarán a cada señal
                            /*CEntidad objAS = new CEntidad();

                            using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=6&vaNombreCategoria=&vaEstado=1"));
                                objAS = JsonConvert.DeserializeObject<CEntidad>(data);
                            }

                            //datos de señal
                            using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "CoordenadasFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=6&vaNombreCategoria="));
                                CEntidad objS = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listSenial = objS.result;

                                foreach (var item in vm.listSenial)
                                {
                                    item.objArchivo = objAS.result.Find(elem => elem.inIdElemento == item.inIdElemento);
                                }
                            }*/

                            listArchivoCoordenada = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    listArchivoCoordenada.Add(item);
                                }
                            }

                            vm.listSenial = new List<CEntidad>();
                            foreach (var item in objO.listaCoordenada)
                            {
                                item.objArchivo = listArchivoCoordenada.Find(elem => elem.inIdElemento == item.inIdElemento);
                                vm.listSenial.Add(item);
                            }
                            break;

                        case "7": /** Garantía de fiel cumplimiento **/
                            vm.txtfechaini = (!formatoFecha(objO.faVigenciaInicio).Equals("01/01/0001") && !formatoFecha(objO.faVigenciaInicio).Equals("01/01/1900")) ? formatoFecha(objO.faVigenciaInicio) : "";
                            vm.txtfechafin = (!formatoFecha(objO.faVigenciaFin).Equals("01/01/0001") && !formatoFecha(objO.faVigenciaFin).Equals("01/01/1900")) ? formatoFecha(objO.faVigenciaFin) : "";

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=7&vaNombreCategoria=EvidenciaCumplimiento&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "8": /** Movilización de frutos, productos y sub productos **/
                            vm.txtgtfprimera = objO.vaPrimeraSerieNumGTF;
                            vm.txtfechagtfprimera = (!formatoFecha(objO.faPrimeraSerieFechaEmision).Equals("01/01/0001") && !formatoFecha(objO.faPrimeraSerieFechaEmision).Equals("01/01/1900")) ? formatoFecha(objO.faPrimeraSerieFechaEmision) : "";
                            vm.txtprimernumtrozas_primera = objO.vaPrimeraSeriePrimerNumListasTrozas;
                            vm.txtultimonumtrozas_primera = objO.vaPrimeraSerieUltimoNumListasTrozas;
                            vm.txtgtfultima = objO.vaUltimaSerieNumGTF;
                            vm.txtfechagtfultima = (!formatoFecha(objO.faUltimaSerieFechaEmision).Equals("01/01/0001") && !formatoFecha(objO.faUltimaSerieFechaEmision).Equals("01/01/1900")) ? formatoFecha(objO.faUltimaSerieFechaEmision) : "";
                            vm.txtprimernumtrozas_ultima = objO.vaUltimaSeriePrimerNumListasTrozas;
                            vm.txtultimonumtrozas_ultima = objO.vaUltimaSerieUltimoNumListasTrozas;

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=8&vaNombreCategoria=EvidenciaMovimientoFrutos&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "9": /** Marcados de Trozas y Tocones **/
                            vm.hdfCodificacionTrozas = objO.chCodificacionTrozas;
                            vm.txtcodificado = (objO.chCodificacionTrozas == "1") ? "SI" : "NO";
                            vm.txtmotivo_nocodificado = objO.vaOtroMotivo;
                            vm.hdfOtroTipoMaterial = objO.chMatCodOtros;
                            vm.txtotrotipomaterial = objO.vaOtroMaterial;

                            vm.listChkTipoCodificado = new List<VM_Chk>
                            {
                                new VM_Chk { Value = "1", Text = "Placas de metal o plástico", Checked=(objO.chMatCodPlacas=="1")?true:false  },
                                new VM_Chk { Value = "2", Text = "Código de barras", Checked=(objO.chMatCodCodBarras=="1")?true:false },
                                new VM_Chk { Value = "3", Text = "Troquelado", Checked=(objO.chMatCodTroquelado=="1")?true:false },
                                new VM_Chk { Value = "4", Text = "Chips", Checked=(objO.chMatCodChips=="1")?true:false },
                                new VM_Chk { Value = "5", Text = "Pintura", Checked=(objO.chMatCodPintura=="1")?true:false },
                                new VM_Chk { Value = "6", Text = "Otros", Checked=(objO.chMatCodOtros=="1")?true:false }
                            };

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=9&vaNombreCategoria=EvidenciaMarcadoTrozas&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "10": /** Medidas Correctivas **/
                            vm.hdfTipoMedida = objO.chTipo;
                            vm.txttipomedida = (objO.chTipo == "1") ? "Medida correctiva" : "Mandato";
                            vm.txtnumresolucion = objO.vaNumResolucion;
                            vm.txtfechaplazo = (!formatoFecha(objO.faPresentacion).Equals("01/01/0001") && !formatoFecha(objO.faPresentacion).Equals("01/01/1900")) ? formatoFecha(objO.faPresentacion) : "";
                            vm.txtdescripcion = objO.vaDescripcion;

                            //datos de archivo
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=10&vaNombreCategoria=EvidenciaMedidaCorrectiva&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    vm.listArchivo.Add(item);
                                }
                            }
                            break;

                        case "11": /** Actos Administrativos **/
                            vm.txtresaprobacion = objO.vaNumResolucion;
                            vm.txtfechaini = (!formatoFecha(objO.faFechaInicio).Equals("01/01/0001") && !formatoFecha(objO.faFechaInicio).Equals("01/01/1900")) ? formatoFecha(objO.faFechaInicio) : "";
                            vm.txtfechafin = (!formatoFecha(objO.faFechaFin).Equals("01/01/0001") && !formatoFecha(objO.faFechaFin).Equals("01/01/1900")) ? formatoFecha(objO.faFechaFin) : "";
                            vm.txtnumdocumento = objO.vaOtrasNroDocumento;
                            vm.txtnumregistro = objO.vaOtrasNroRegistro;
                            vm.txtfechaactadmin = (!formatoFecha(objO.faOtrasFecha).Equals("01/01/0001") && !formatoFecha(objO.faOtrasFecha).Equals("01/01/1900")) ? formatoFecha(objO.faOtrasFecha) : "";
                            vm.txtdescripcion = objO.vaOtrasDescripcion;

                            vm.ddlTipoRegistro = new List<VM_Cbo>
                            {
                                new VM_Cbo { Value = "1", Text = "Reingreso" },
                                new VM_Cbo { Value = "2", Text = "Movilización de saldos" },
                                new VM_Cbo { Value = "3", Text = "Reajuste" },
                                new VM_Cbo { Value = "4", Text = "Reformulación" }
                            };
                            vm.ddlTipoRegistroId = objO.vaTipoGestion;

                            foreach (var item in vm.ddlTipoRegistro)
                            {
                                if (item.Value == vm.ddlTipoRegistroId)
                                {
                                    vm.txttiporegistro = item.Text;
                                }
                            }

                            //datos de archivos de otros
                            /*using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=11&vaNombreCategoria=EvidenciaAdminProcess&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivoOtros = objA.result;
                            }

                            //datos de archivo
                            using (WebClient obj = new WebClient())
                            {
                                obj.Headers.Clear();
                                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                                obj.Encoding = UTF8Encoding.UTF8;

                                var data = obj.DownloadString(new Uri(url + "ArchivosFormularios/?inIdObligacion=" + idobligacion + "&inTipoObligacion=11&vaNombreCategoria=" + vm.ddlTipoRegistroId + "&vaEstado=1"));
                                CEntidad objA = JsonConvert.DeserializeObject<CEntidad>(data);
                                vm.listArchivo = objA.result;
                            }*/

                            vm.listArchivoOtros = new List<CEntidad>();
                            vm.listArchivo = new List<CEntidad>();
                            foreach (var item in objO.listaArchivo)
                            {
                                if (item.vaEstado == "1")
                                {
                                    if (item.vaNombreCategoria== "EvidenciaAdminProcess")
                                    {
                                        vm.listArchivoOtros.Add(item);
                                    }
                                    else if (item.vaNombreCategoria== vm.ddlTipoRegistroId)
                                    {
                                        vm.listArchivo.Add(item);
                                    }
                                }
                            }
                            break;
                    }
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        public string rutaObligacion(string numTipoObligacion, int Version)
        {
            string tipoObligacionOpcion = "";

            switch (numTipoObligacion)
            {
                case "1":
                    tipoObligacionOpcion = "OBInformeEjecucion";
                    break;
                case "2":
                    tipoObligacionOpcion = "OBRegenteForestal";
                    break;
                case "3":
                    tipoObligacionOpcion = "OBLibroOperaciones";
                    break;
                case "4":
                    tipoObligacionOpcion = "OBCustodioForestal";
                    break;
                case "5":
                    tipoObligacionOpcion = "OBContratoTerceros";
                    break;
                case "6":
                    tipoObligacionOpcion = "OBLinderoHito";
                    break;
                case "7":
                    tipoObligacionOpcion = "OBGarantiaFielCumplimiento";
                    break;
                case "8":
                    tipoObligacionOpcion = "OBMovilizacionFrutos";
                    break;
                case "9":
                    tipoObligacionOpcion = "OBMarcadoTrozas";
                    break;
                case "10":
                    tipoObligacionOpcion = "OBMedidasCorrectivas";
                    break;
                case "11":
                    tipoObligacionOpcion = "OBActoAdministrativo";
                    break;
                default:
                    tipoObligacionOpcion = numTipoObligacion;
                    break;
            }
            return tipoObligacionOpcion;
        }
        public string rutaObligacion(string numTipoObligacion)
        {
            string tipoObligacionOpcion = "";

            switch (numTipoObligacion)
            {
                case "1":
                    tipoObligacionOpcion = "InformeEjecucion";
                    break;
                case "2":
                    tipoObligacionOpcion = "RegenteForestal";
                    break;
                case "3":
                    tipoObligacionOpcion = "LibroOperaciones";
                    break;
                case "4":
                    tipoObligacionOpcion = "CustodioForestal";
                    break;
                case "5":
                    tipoObligacionOpcion = "ContratoTerceros";
                    break;
                case "6":
                    tipoObligacionOpcion = "RegistroHitoLindero";
                    break;
                case "7":
                    tipoObligacionOpcion = "RegistroFielCumplimiento";
                    break;
                case "8":
                    tipoObligacionOpcion = "FrutosProductosSubProductos";
                    break;
                case "9":
                    tipoObligacionOpcion = "RegistroMarcadoTrozas";
                    break;
                case "10":
                    tipoObligacionOpcion = "RegistroMedidaCorrectiva";
                    break;
                case "11":
                    tipoObligacionOpcion = "RegistroPlanAdministrativo";
                    break;
                default:
                    tipoObligacionOpcion = numTipoObligacion;
                    break;
            }
            return tipoObligacionOpcion;
        }

        public string formatoFecha(string fecha)
        {
            string[] parts = fecha.Split('-');
            string anio = parts[0];
            string mes = parts[1];
            string dia = parts[2].Substring(0, 2);

            return dia + "/" + mes + "/" + anio;
        }

        [HttpPost]
        public JsonResult isExistFile(string nombreArchivo)
        {
            ListResult result = new ListResult();

            try
            {
                using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                    obj.Encoding = UTF8Encoding.UTF8;

                    string rutacompleta = url + "file/download/" + nombreArchivo;
                    var data = obj.DownloadString(new Uri(rutacompleta));
                    result.AddResultado(rutacompleta, true);
                }  
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult Procesar(CEntidad objO)
        {
            ListResult result = new ListResult();

            try
            {
                using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                    obj.Encoding = UTF8Encoding.UTF8;

                    var param = "{\"NU_OBLIGACION_BUSQUEDA\": " + objO.nU_OBLIGACION_BUSQUEDA + "," +
                                "\"NU_ESTADO_BUSQUEDA\": " + objO.nU_ESTADO_BUSQUEDA + "," +
                                "\"NV_CODIGO_BUSQUEDA\": \"" + objO.nV_CODIGO_BUSQUEDA + "\"," +
                                "\"NV_OBSERVACION\": \"" + objO.nV_OBSERVACION + "\"," +
                                "\"NV_CODUCUENTA\": \"" + (ModelSession.GetSession())[0].COD_UCUENTA + "\","+
                                "\"VANOMBREUSUARIO\": \"" + (ModelSession.GetSession())[0].PERSONA + "\","+
                                "\"INIdTituloHabilitante\": " + objO.inIdTituloHabilitante + ","+
                                "\"INIdPlanManejo\": " + objO.inIdPlanManejo + "," +
                                "\"VAAPLICACIONNAME\": \"SIGO\"}";

                    var data = obj.UploadString(new Uri(url + "Obligaciones/Procesar"), param);
                    var jsonObject = JsonConvert.DeserializeObject<CEntVM>(data);

                    if (jsonObject.isSuccess) {
                        result.AddResultado(jsonObject.data.Substring(2, jsonObject.data.Length-2), true);
                    }
                    else
                    {
                        result.AddResultado(jsonObject.tx_Mensaje, false);
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }
    }
}