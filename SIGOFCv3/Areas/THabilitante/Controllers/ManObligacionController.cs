using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using Newtonsoft.Json;
using SIGOFCv3.Areas.General;
using SIGOFCv3.Areas.THabilitante.Models;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_MiBosque_Obligacion;
using CLogica = CapaLogica.DOC.Log_MiBosque_Obligacion;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManObligacionController : Controller
    {
        CLogica objLog;

        // GET: THabilitante/ManObligacion
        const string urlApiMibosque = "https://wstest.osinfor.gob.pe:7000/ApiMiBosque/api/";
        const string enlaceTipoObligacion = urlApiMibosque + "Tipo/?vaNumGrupoTipo=1&vaNumObligacion=0&pageSize=11";
        const string enlaceEstado = urlApiMibosque + "Tipo/?vaNumGrupoTipo=5&vaNumObligacion=0";
        const string enlaceEstadoObligacion = urlApiMibosque + "Tipo/?vaNumGrupoTipo=6&vaNumObligacion=0";
        const string enlaceListado = urlApiMibosque + "TitHabilitante/1?";
        [HttpGet]
        public ActionResult Index(string _alertaInicial = "")
        {
            ViewBag.Formulario = "OBLICACION";
            ViewBag.TituloFormulario = "Obligacion";
            ViewBag.AlertaInicial = _alertaInicial;
            return View();
        }
        [HttpGet]
        public ActionResult OblicacionMiBosque(string _tipoObligacion, string _idObligacion)
        {
            ViewBag.Formulario = "OBLICACIONMIBOSQUE";
            ViewBag.TituloFormulario = "Obligacion - MiBosque";
            ViewBag.AlertaInicial = "";
            ViewBag.TipoObligacion = _tipoObligacion;
            ViewBag.IdObligacion = _idObligacion;
            return View();
        }

        [HttpGet]
        public JsonResult GetAllObligacion(string obligacion, string estado)
        {
            try
            {

                JsonResult jsonResult = new JsonResult();
                TipoSelect lista =  new TipoSelect();
                using (WebClient obj = new WebClient())
                {
                    obj.Headers.Clear();//borra datos anteriores
                                        //establece el tipo de dato de tranferencia
                                        //usuario.Headers[HttpRequestHeader.Authorization] = "Basic " + svcCredentials;
                    obj.Headers[HttpRequestHeader.ContentType] = "application/json";//GlobalVariables.jsonMediaType;
                                                                                    //typo de decodificador reconocimiento carecteres especiales
                    obj.Encoding = UTF8Encoding.UTF8;
                    var json = JsonConvert.SerializeObject("");
                    string rutacompleta = enlaceListado+"iNObligacion="+ obligacion + "&vAEstado="+ estado;
                    //ejecuta la busqueda en la web api usando metodo GET
                    var data = obj.UploadString(new Uri(rutacompleta), json);
                    // convierte los datos traidos por la api a tipo lista de usuarios
                    lista = JsonConvert.DeserializeObject<TipoSelect>(data);
                    //var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);           
                }
                jsonResult = Json(new { data = lista, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            } catch (Exception ex)
            {
                return Json(new { data = "", success = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult _ManGrilla(ManGrillaViewModelMiBosque dto)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            ManGrillaViewModelMiBosque manGrilla = new ManGrillaViewModelMiBosque();

            manGrilla.tipoFormulario = dto.tipoFormulario;
            manGrilla.titleMenu = dto.titleMenu;

            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = manGrilla.tipoFormulario;
            List<Ent_BUSQUEDA> selectopciones = new List<Ent_BUSQUEDA>();
            List<Ent_BUSQUEDA> selectopciones2 = new List<Ent_BUSQUEDA>();
            Ent_BUSQUEDA sopciones = new Ent_BUSQUEDA();
            using (WebClient obj = new WebClient())
            {
                obj.Headers.Clear();//borra datos anteriores
                                    //establece el tipo de dato de tranferencia
                                    //usuario.Headers[HttpRequestHeader.Authorization] = "Basic " + svcCredentials;
                obj.Headers[HttpRequestHeader.ContentType] = "application/json";//GlobalVariables.jsonMediaType;
                                                                                //typo de decodificador reconocimiento carecteres especiales
                obj.Encoding = UTF8Encoding.UTF8;
                var json = JsonConvert.SerializeObject("");
                string rutacompleta = enlaceTipoObligacion;
                //ejecuta la busqueda en la web api usando metodo GET
                var data = obj.DownloadString(new Uri(rutacompleta));
                // convierte los datos traidos por la api a tipo lista de usuarios
                var lista = JsonConvert.DeserializeObject<TipoMibosque>(data);
                sopciones = new Ent_BUSQUEDA();
                sopciones.CODIGO = "0";
                sopciones.DESCRIPCION = "Todos";
                selectopciones.Add(sopciones);
                foreach (var opciones in lista.result)
                {
                    sopciones = new Ent_BUSQUEDA();
                    sopciones.CODIGO = opciones.vaNumTipo;
                    sopciones.DESCRIPCION = opciones.vaTipoDescripcion;
                    selectopciones.Add(sopciones);
                }
                manGrilla.cboOpciones = HelperSigo.LLenarCombos(selectopciones, "0");
                        
            }

           
            using (WebClient obj = new WebClient())
            {
                obj.Headers.Clear();//borra datos anteriores
                                    //establece el tipo de dato de tranferencia
                                    //usuario.Headers[HttpRequestHeader.Authorization] = "Basic " + svcCredentials;
                obj.Headers[HttpRequestHeader.ContentType] = "application/json";//GlobalVariables.jsonMediaType;
                                                                                //typo de decodificador reconocimiento carecteres especiales
                obj.Encoding = UTF8Encoding.UTF8;
                var json = JsonConvert.SerializeObject("");
                string rutacompleta = enlaceEstado;
                //ejecuta la busqueda en la web api usando metodo GET
                var data = obj.DownloadString(new Uri(rutacompleta));
                // convierte los datos traidos por la api a tipo lista de usuarios
                var lista = JsonConvert.DeserializeObject<TipoMibosque>(data);
                selectopciones = new List<Ent_BUSQUEDA>();
                foreach (var opciones in lista.result)
                {
                    sopciones = new Ent_BUSQUEDA();
                    sopciones.CODIGO = opciones.vaNumTipo;
                    sopciones.DESCRIPCION = opciones.vaTipoDescripcion;
                    selectopciones2.Add(sopciones);
                }
                manGrilla.cboOpciones2 = HelperSigo.LLenarCombos(selectopciones2, "");
                       
            }
           
           
            return PartialView(manGrilla);
        }
        [HttpPost]
        public ActionResult _ManGrillaObligacion(Obligacion dto)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            Obligacion manGrilla = new Obligacion();

            manGrilla.tipoFormulario = dto.tipoFormulario;
            manGrilla.titleMenu = dto.titleMenu;
            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = manGrilla.tipoFormulario;
            List<Ent_BUSQUEDA> selectopciones = new List<Ent_BUSQUEDA>();
            Ent_BUSQUEDA sopciones = new Ent_BUSQUEDA();
            //lista estado
            using (WebClient obj = new WebClient())
            {
                obj.Headers.Clear();
                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                obj.Encoding = UTF8Encoding.UTF8;
                string rutacompleta = enlaceEstadoObligacion;
                //ejecuta la busqueda en la web api usando metodo GET
                var data = obj.DownloadString(new Uri(rutacompleta));
                // convierte los datos traidos por la api a tipo lista de usuarios
                var lista = JsonConvert.DeserializeObject<TipoMibosque>(data);

                foreach (var opciones in lista.result)
                {
                    sopciones = new Ent_BUSQUEDA();
                    sopciones.CODIGO = opciones.vaNumTipo;
                    sopciones.DESCRIPCION = opciones.vaTipoDescripcion;
                    selectopciones.Add(sopciones);
                }
                manGrilla.cboOpciones = HelperSigo.LLenarCombos(selectopciones, "");
            }
            //datos de obligacion
            using (WebClient obj = new WebClient())
            {
                obj.Headers.Clear();
                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                obj.Encoding = UTF8Encoding.UTF8;
                string rutacompleta = urlApiMibosque + rutaObligacion(dto.idTipoObligacion) +"/"+dto.idObligacion;
                //ejecuta la busqueda en la web api usando metodo GET
                var data = obj.DownloadString(new Uri(rutacompleta));
                // convierte los datos traidos por la api a tipo lista de usuarios
                var objObligacion = JsonConvert.DeserializeObject<dynamic>(data);
                manGrilla.dataObligacion = objObligacion;
            }
            //titulo habilitante
            using (WebClient obj = new WebClient())
            {
                obj.Headers.Clear();
                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                obj.Encoding = UTF8Encoding.UTF8;
                string rutacompleta = urlApiMibosque + "TitHabilitante/?inIdTituloHabilitante="+ manGrilla.dataObligacion.inIdTituloHabilitante;
                //ejecuta la busqueda en la web api usando metodo GET
                var data = obj.DownloadString(new Uri(rutacompleta));
                // convierte los datos traidos por la api a tipo lista de usuarios
                var objTh = JsonConvert.DeserializeObject<TituloHabilitante>(data);
                manGrilla.tituloHabilitante = objTh;
            }
            //plan de manejo
            using (WebClient obj = new WebClient())
            {
                obj.Headers.Clear();
                obj.Headers[HttpRequestHeader.ContentType] = "application/json";
                obj.Encoding = UTF8Encoding.UTF8;
                string rutacompleta = urlApiMibosque + "PlanManejo/?inIdPlanManejo=" + manGrilla.dataObligacion.inIdPlanManejo;
                //ejecuta la busqueda en la web api usando metodo GET
                var data = obj.DownloadString(new Uri(rutacompleta));
                // convierte los datos traidos por la api a tipo lista de usuarios
                var objTh = JsonConvert.DeserializeObject<PlanManejo>(data);
                manGrilla.planManejo = objTh;
            }
            return PartialView(manGrilla);
        }
        public string rutaObligacion(string numTipoObligacion) {
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
        [HttpPost]
        public JsonResult UpdateObligacion(VM_MiBosqueObligacion dto)
        {
            objLog = new CLogica();
            Object resultado = objLog.RegActualizar(dto);

            return Json(resultado);
        }
    }
}