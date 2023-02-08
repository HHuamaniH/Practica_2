using CapaEntidad.DOC;
using CapaEntidad.GENE;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica;
using CapaLogica.DOC;
using CapaLogica.GENE;
using Herramienta;
using SIGOFCv3.Areas.General.Models;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using SIGOFCv3.Reportes.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;


namespace SIGOFCv3.Areas.General.Controllers
{
    public class ControlesController : Controller
    {
        #region _ManGrilla
        // POST: General/Controles
        [HttpPost]
        public ActionResult _ManGrilla(ManGrillaViewModel dto)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            ManGrillaViewModel manGrilla = new ManGrillaViewModel();

            manGrilla.tipoFormulario = dto.tipoFormulario;
            manGrilla.titleMenu = dto.titleMenu;

            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = manGrilla.tipoFormulario;
            manGrilla.cboOpciones = HelperSigo.LLenarCombos(exeBus.RegOpcionesCombo(paramsBus), "");

            return PartialView(manGrilla);
        }

        [HttpGet]
        public JsonResult listarBusqueda(String busFormulario, String busCriterio, String busValor)
        {

            object retorno = new object();

            try
            {

                //auditoria
                CapaEntidad.GENE.Ent_AUDITORIA auditoria = new CapaEntidad.GENE.Ent_AUDITORIA();
                auditoria.codCuentaUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
                string strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                auditoria.hostName = Convert.ToString(ipEntry.HostName);
                auditoria.ipServer = Convert.ToString(ipEntry.AddressList[ipEntry.AddressList.Length - 1]);
                String ipClient = "";
                ipClient = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (String.IsNullOrEmpty(ipClient)) { ipClient = Request.ServerVariables["REMOTE_ADDR"]; }
                auditoria.ipCliente = ipClient;
                string ss = Request.ServerVariables["CLIENT_IP"];

                Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
                Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
                oCampos.BusFormulario = busFormulario;
                oCampos.BusCriterio = busCriterio;
                oCampos.BusValor = busValor;

                retorno = oCLogica.RegMostrarLista(oCampos);
                return Json(new { data = retorno, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult ExportarExcelListadoManGrilla(string busFormulario)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            var result = ReporteManGrilla.GenerarReporteManGrilla(busFormulario, codCuenta);
            return Json(result);
        }
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadListadoManGrilla(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla/Reg_Usu"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        #endregion

        #region _ManGrillaPaging
        [HttpPost]
        public PartialViewResult _ManGrillaPaging(ManGrillaViewModel dto)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();

            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = dto.tipoFormulario;
            if (dto.tipoFormulario == "AEXPEDIENTE_SITD")
            {
                dto.cboOpciones = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" } , new SelectListItem() { Text = "Pendiente", Value = "Pendiente" } , new SelectListItem() { Text = "Transferido", Value = "Transferido" },
                                                               new SelectListItem() { Text = "Anulado", Value = "Anulado" }};
                dto.cboOpciones1 = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" } , new SelectListItem() { Text = "OD", Value = "OD" } , new SelectListItem() { Text = "DOC_REFERENCIA", Value = "DOC_REFERENCIA" },
                                                               new SelectListItem() { Text = "NUM_DOCUMENTO", Value = "NUM_DOCUMENTO" },new SelectListItem() { Text = "NUM_TRAMITE", Value = "NUM_TRAMITE" },new SelectListItem() { Text = "NUM_THABILITANTE", Value = "NUM_THABILITANTE" },
                                                                new SelectListItem() { Text = "RESOLUCION_POA", Value = "RESOLUCION_POA" }};
            }
            else if (dto.tipoFormulario == "INFORME_QUINQUENAL")
            {
                dto.cboOpciones = new List<SelectListItem>() { new SelectListItem() { Text = "N° Informe", Value = "NUM_INFORME" } };
            }
            else
            {
                dto.cboOpciones = HelperSigo.LLenarCombos(exeBus.RegOpcionesCombo(paramsBus), "");
            }


            return PartialView(dto);
        }

        [HttpGet]
        public JsonResult GetListaGeneralPaging(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            if (request.CustomSearchType1 != null && request.CustomSearchType1 != "")
                paramsBus.BusCriterio1 = request.CustomSearchType1;
            else paramsBus.BusCriterio1 = " ";
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.pagesize = request.Length;
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;
            if (paramsBus.BusValor == "")
            {
                paramsBus.BusCriterio = "TODOS";
            }

            if (request.Order.Length != 0)
            {
                //paramsBus.sort = request.Columns[request.Order[0].Column].Data + " " + request.Order[0].Dir;
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }
            paramsBus.v_sort = " ";
            if (paramsBus.BusFormulario == "CARTA_NOTIFICACION")
            {
                lstResult = exeBus.CartaNotificacionGetAll(request.CustomSearchType, paramsBus.BusValor, paramsBus.currentpage, paramsBus.pagesize, paramsBus.sort, ref rowcount);
            }
            else if (paramsBus.BusFormulario == "INFORME_SUPERVISION")
            {
                lstResult = exeBus.InformeSupervisionGetAll(request.CustomSearchType, paramsBus.BusValor, paramsBus.currentpage, paramsBus.pagesize, paramsBus.sort, ref rowcount);
            }
            else if (paramsBus.BusFormulario == "PAU_DIGITAL")
            {
                lstResult = exeBus.PAUGetAll(request.CustomSearchType, paramsBus.BusValor, paramsBus.currentpage, paramsBus.pagesize, paramsBus.sort, ref rowcount);
            }
            else if (paramsBus.BusFormulario == "SEGUIMIENTO_MUESTRA_ENDROLOGICA")
            {
                lstResult = exeBus.MuestrasDendrologicasGetAll(request.CustomSearchType, paramsBus.BusValor, paramsBus.currentpage, paramsBus.pagesize, paramsBus.sort, ref rowcount);

            }
            else if (paramsBus.BusFormulario == "INFORME_QUINQUENAL")
            {
                lstResult = exeBus.InformeQuinquenalGetAll(request.CustomSearchType, paramsBus.BusValor, paramsBus.currentpage, paramsBus.pagesize, paramsBus.sort, ref rowcount);
            }
            else if (paramsBus.BusFormulario == "AEXPEDIENTE_SITD")
            {
                 lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

                if (paramsBus.BusCriterio1 != "TODOS")
                {
                    lstResult = lstResult.Where(i => i.ContainsKey("ESTADO_AEXPEDIENTE") && i["ESTADO_AEXPEDIENTE"].Equals(paramsBus.BusCriterio1)).ToList();
                }
            }
            else
            {
                lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);
            }


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

        #region Mantenimiento Calculo de Multa

        [HttpGet]
        public JsonResult GetFactorAA(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;

            paramsBus.pagesize = request.Length;
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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

        public JsonResult GetRegenEsp(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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

        public JsonResult GetCostoAdm(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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
        public JsonResult GetBenEcoInf(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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

        public JsonResult GetIndPreCon(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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
        public JsonResult GetInfProDet(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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

        public JsonResult GetVENMaderable(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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
        public JsonResult GetCatEspMad(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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
        public JsonResult GetValComFau(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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
        public JsonResult GetClaEspAme(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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

        [HttpGet]
        public JsonResult buscarExpediente(string asBusFormulario, string asBusCriterio, string asExpediente)
        {
            try
            {
                Log_GENEPERSONA logPersona = new Log_GENEPERSONA();
                Ent_GENEPERSONA oParams = new Ent_GENEPERSONA()
                {
                    BusFormulario = asBusFormulario,
                    BusCriterio = asBusCriterio,
                    BusValor = asExpediente
                };
                Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
                Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA() {
                    BusFormulario = asBusFormulario,
                    BusCriterio = asBusCriterio,
                    BusValor = asExpediente is null ? "0" : asExpediente
                };
                //List<Ent_GENEPERSONA> consulta = logPersona.BuscarPersonaSimple_v3(oParams);
                List<Ent_BUSQUEDA> consulta = exeBus.BuscarExpediente(paramsBus);// .BuscarPersonaSimple_v3(oParams);


                int i = 1;

                var result = from c in consulta
                             select new
                             {
                                 ind = i++,
                                 EXPEDIENTE = c.EXPEDIENTE,
                                 ADMINISTRADO = c.ADMINISTRADO,
                                 TIPO_DOC = c.TIPO_DOC,
                                 THABILITANTE = c.THABILITANTE
                             };
                var jsonResult = Json(new { data = result, success = true, er = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, er = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCalMulList(DataTableRequest request = null)
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
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

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

        #region _Ubigeo
        [HttpPost]
        public ActionResult _Ubigeo()
        {
            return PartialView();
        }

        [HttpGet]
        public string GetListUbigeoTodo()
        {
            Log_UBIGEO objLogUbigeo = new Log_UBIGEO();
            string listaTotalUbigeo = objLogUbigeo.RegMostrarUbigeoV3();
            return listaTotalUbigeo;
        }
        #endregion

        #region "Titulo Habilitante"
        [HttpGet]
        public ActionResult _THabilitante(string hdfFormulario)
        {
            ViewBag.tipFormulario = hdfFormulario;
            switch (hdfFormulario)
            {
                case "POA":
                case "DEVOLUCION_MADERA":
                    ViewBag.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "GRI_TH_NUMERO", Text = "N° T. Habilitante" }, new SelectListItem { Value = "GRI_TH_TITULAR", Text = "Titular" } };
                    break;
                case "TITULO_HABILITANTE":
                    ViewBag.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "TH_NUMERO", Text = "N° Título Habilitante" } };
                    break;
                case "PLAN_MANEJO":
                    ViewBag.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "PM_TH_NUMERO", Text = "N° Título Habilitante" }, new SelectListItem { Value = "PM_TH_TITULAR", Text = "Titular" } };
                    break;
                case "INFORME_AUT_FORESTAL":
                case "OTROS_INFORMES":
                case "RENUNCIA_CONCESION":
                    ViewBag.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "IAF_TH_NUMERO", Text = "N° Título Habilitante" }, new SelectListItem { Value = "IAF_TH_TITULAR", Text = "Titular" } };
                    break;
                case "GUIA_TRANSPORTE":
                    ViewBag.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "GTF_TH_NUMERO", Text = "N° Título Habilitante" } };
                    break;

                default:
                    ViewBag.cboOpciones = new List<SelectListItem>();
                    break;
            }

            return PartialView();
        }

        [HttpGet]
        public JsonResult buscarTH(string vb)
        {
            try
            {
                string[] parameters = vb.Split('¬');
                string hdfFormulario = parameters[0];
                string busCriterio = parameters[1];
                string busValor = parameters[2];

                Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
                oCampos.BusFormulario = hdfFormulario;
                oCampos.BusCriterio = busCriterio;
                oCampos.BusValor = busValor;
                Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
                var list = oCLogica.RegMostrarLista(oCampos);
                int ind = 1;
                var resultado = from t in list
                                select new
                                {
                                    t.CODIGO,
                                    t.PARAMETRO01,
                                    t.NUMERO,
                                    t.PARAMETRO02,
                                    t.PARAMETRO03,
                                    t.PARAMETRO04,
                                    t.PARAMETRO05,
                                    t.PARAMETRO06,
                                    t.PARAMETRO07,
                                    t.PARAMETRO08,
                                    t.PARAMETRO09,
                                    t.PARAMETRO10,
                                    ROW_INDEX = ind++
                                };


                var jsonResult = Json(new { success = true, msj = "", data = resultado }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region "Persona"
        /// <summary>
        /// Ventana modal para realizar la consulta de personas registradas en el SIGOsfc
        /// </summary>
        /// <param name="asBusGrupo">Grupos personalizados: 'PERSONA','PERSONA_OSINFOR',...</param>
        /// <param name="asCodPTipo">GENE.PERSONA_TIPO: 'TODOS' o COD_PTIPO ('0000001,0000002,...'), el primer COD_PTIPO se envia para crear una nueva persona</param>
        /// <param name="asTipoPersona">'TODOS' o ('N,J')</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult _BuscarPersonaGeneral(string asBusGrupo, string asCodPTipo, string asTipoPersona, string asFormulario="", string asCodMod= "",string asTipoCargo="")
        {
            ViewBag.hdfBusGrupo = asBusGrupo;
            ViewBag.hdfCodPTipo = asCodPTipo;
            ViewBag.hdfTipoPersona = asTipoPersona;
            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfCodMod = asCodMod;
            ViewBag.hdfTipoCargo = asTipoCargo;
            
            return PartialView();
        }
        /// <summary>
        /// Método que realiza la consulta de personas registradas en el SIGOsfc
        /// </summary>
        /// <param name="asBusGrupo">Grupos personalizados: 'PERSONA','PERSONA_OSINFOR',...</param>
        /// <param name="asBusCriterio">'NOMBRES','DOCUMENTO'</param>
        /// <param name="asBusValor">Valor a consultar según el parámetro @asBusCriterio</param>
        /// <param name="asCodPTipo">GENE.PERSONA_TIPO: 'TODOS' o COD_PTIPO ('0000001,0000002,...')</param>
        /// <param name="asTipoPersona">'TODOS' o ('N,J')</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult buscarPersonaGeneral(string asBusGrupo, string asBusCriterio, string asBusValor, string asCodPTipo, string asTipoPersona)
        {
            try
            {
                Log_GENEPERSONA logPersona = new Log_GENEPERSONA();
                Ent_GENEPERSONA oParams = new Ent_GENEPERSONA()
                {
                    BusGrupo = asBusGrupo,
                    BusCriterio = asBusCriterio,
                    BusValor = asBusValor,
                    COD_PTIPO = asCodPTipo,
                    TIPO_PERSONA = asTipoPersona
                };
                List<Ent_GENEPERSONA> consulta = logPersona.BuscarPersonaSimple_v3(oParams);
                int i = 1;

                var result = from c in consulta
                             select new
                             {
                                 ind = i++,
                                 COD_PERSONA = c.COD_PERSONA,
                                 PERSONA = c.PERSONA,
                                 TIPO_PERSONA_TEXT = c.TIPO_PERSONA_TEXT,
                                 DIDENTIDAD = c.DIDENTIDAD,
                                 N_DOCUMENTO = c.N_DOCUMENTO,
                                 PTIPO = c.PTIPO,
                                 NUM_REGISTRO_PROFESIONAL = c.NUM_REGISTRO_PROFESIONAL,
                                 FICHA_REGISTRAL = c.FICHA_REGISTRAL,
                                 
                                 DIRECCION=c.DIRECCION,
                                 COD_UBIGEO = c.COD_UBIGEO,
                                 UBIGEO=c.UBIGEO,
                                 NOMBRES=c.NOMBRES,
                                 APE_PATERNO=c.APE_PATERNO,
                                 APE_MATERNO=c.APE_MATERNO,
                                 N_RUC = c.N_RUC,
                                 COD_PTIPO=c.COD_PTIPO,
                                 TIPO_CARGO =c.TIPO_CARGO
                             };
                var jsonResult = Json(new { data = result, success = true, er = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, er = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// Ventana modal para registrar los datos básicos de una persona (natural o jurídica)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult _Persona(string asFormulario="", string asCodMod="", string asCodPersona="", int opc = 0)
        {
            VM_Persona objPersona = new VM_Persona();
            //Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
            //Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();

            /*objPersona.ddlItemPN_DITipo = oCLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "TIPO_DOCUMENTO_IDENTIDAD", "");
            oCampos.BusFormulario = "DIRECTORIO_UNICO";
            oCampos.BusCriterio = "PERSONA_TIPO";
            var lstTipoCargo = oCLogica.RegOpcionesCombo(oCampos).Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstTipoCargo.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            objPersona.ddlITipoCargo = lstTipoCargo;*/

            Ent_Persona entP = new Ent_Persona();
            Log_Persona logP = new Log_Persona();

            entP.BusFormulario = "DIRECTORIO_UNICO";
            entP.BusCriterio = "TODOS";
            entP.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            entP = logP.RegMostCombo(entP);
            objPersona.ddlItemPN_DITipo = entP.ListCTipoDocIdentidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            objPersona.ddlITipoCargo = entP.ListCTipoCargo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            objPersona.ddlINivelAcademico = entP.ListCNivelAcademico.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            objPersona.ddlIEspecialidad = entP.ListCEspecialidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            var lstCategoria = entP.ListCCategoria.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstCategoria.Insert(0, new VM_Cbo { Value = "0000000", Text = "Seleccionar" });
            objPersona.ddlCategoria = lstCategoria;
            objPersona.ddlMencionRegencia = new List<VM_Cbo>();
            var lstEstado = entP.ListCEstado.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEstado.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            objPersona.ddlEstado = lstEstado;

            var lstAnio = new List<VM_Chk>();
            for (int i = DateTime.Now.Year; i >= 2016; i--)
            {
                lstAnio.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
            }
            objPersona.ddlAnio = lstAnio.Select(i => new VM_Cbo { Value = i.Value, Text = i.Text });

            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfCodMod = asCodMod;
            ViewBag.hdfOpc = opc;

            if (String.IsNullOrEmpty(asCodPersona))
            {
                ViewBag.Titulo = "Nuevo Registro";
                objPersona.RegEstadoPersona = 1;
            }
            else
            {
                entP = logP.RegMostrarListaItem(new Ent_Persona() { COD_PERSONA = asCodPersona });
                objPersona.codigoPersona = asCodPersona;

                if (entP.COD_TPERSONA.Equals("N"))
                {
                    objPersona.ddlItemPN_DITipoId = entP.COD_DIDENTIDAD;
                    objPersona.txtItemPN_DINumero = entP.N_DOCUMENTO;
                    objPersona.txtItemPN_DIRUC = entP.N_RUC;
                    objPersona.txtItemPN_APaterno = entP.APE_PATERNO;
                    objPersona.txtItemPN_AMaterno = entP.APE_MATERNO;
                    objPersona.txtItemPN_Nombres = entP.NOMBRES;
                }
                else
                {
                    objPersona.txtItemPJ_RUC = entP.N_RUC;
                    objPersona.txtItemPJ_RSocial = entP.RAZON_SOCIAL;
                }

                if (opc == 1)
                {
                    ViewBag.Titulo = "Adiciona Tipo Cargo";
                }
                else
                {
                    ViewBag.Titulo = "Editar Registro";
                    objPersona.txtINumRegFfs = entP.NUM_REGISTRO_FFS;
                    objPersona.txtINumRegProf = entP.NUM_REGISTRO_PROFESIONAL;
                    objPersona.txtICargo = entP.CARGO;
                    objPersona.txtINumColegiatura = entP.COLEGIATURA_NUM;
                    objPersona.ddlINivelAcademicoId = entP.COD_NACADEMICO == "" ? "0000000" : entP.COD_NACADEMICO;
                    objPersona.ddlIEspecialidadId = entP.COD_DPESPECIALIDAD == "" ? "0000000" : entP.COD_DPESPECIALIDAD;
                    objPersona.ddlAnioId = entP.ANIO;
                    objPersona.txtNroLicencia = entP.NROLICENCIA;
                    objPersona.txtFecLicencia = entP.OTORGAMIENTO;
                    objPersona.txtResolucion = entP.RESAPROBACION;
                    objPersona.ddlCategoriaId = entP.COD_CATEGORIA == "" ? "0000000" : entP.COD_CATEGORIA;
                    objPersona.txtCIP = entP.CIP;
                    objPersona.ddlEstadoId = entP.ESTADO_REGENTE == "" ? "-" : entP.ESTADO_REGENTE;
                    objPersona.txtOtro = entP.OTRO;

                    foreach (var itemCargo in entP.ListTipoCargo)
                    {
                        objPersona.hdfITipoCargo += "," + itemCargo.COD_PTIPO;
                    }

                    foreach (var itemMencion in entP.ListMencion)
                    {
                        objPersona.hdfMencionRegencia += "," + itemMencion.COD_MENSION;
                    }
                }

                objPersona.RegEstadoPersona = 0;
            }

            return PartialView(objPersona);
        }

        [HttpPost]
        public JsonResult ListarMencionRegencia(string idcategoria)
        {
            try
            {
                Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
                Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
                paramsBus.BusFormulario = "DIRECTORIO_UNICO";
                paramsBus.BusCriterio = "REGENTE_MENCION";
                paramsBus.BusValor = idcategoria;

                List<Ent_BUSQUEDA> list = exeBus.RegOpcionesCombo(paramsBus);
                var ddlMencionRegencia = list.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                return Json(new { success = true, result = ddlMencionRegencia });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        /// <summary>
        /// Método para grabar los datos de una persona (natural o jurídica) en el SIGOsfc
        /// </summary>
        /// <param name="vm">Objeto que contiene los datos básicos de una persona</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult _Persona(VM_Persona vm)
        {
            ListResult result = new ListResult();
            try
            {
                Log_GENEPERSONA oCLogPersona = new Log_GENEPERSONA();
                String coducuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                result = oCLogPersona.GrabarPersonaSimple_v3(coducuenta, vm);
            }
            catch (Exception )
            {
                result.success = false;
                // result.msj = ex.Message;
                result.msj = "Ocurrio un error en el registro, verifique los datos e intente de nuevo";

            }
            return Json(result);
        }
        /// <summary>
        /// Método para consultar los datos de una persona (natural o jurídica) al servicio OSINFOR PIDE (consulta RENIEC y SUNAT)
        /// </summary>
        /// <param name="asBusCriterio"></param>
        /// <param name="asBusValor"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult buscarPersonaNJ_OSINFOR_PIDE(string asBusCriterio, string asBusValor, string asFormulario = "")
        {
            ListResult result = new ListResult();

            try
            {
                List<string> persona = new List<string>();

                if (asBusCriterio == "DNI")
                {
                    pideOSF_Reniec.ReniecServiceClient wsReniec = new pideOSF_Reniec.ReniecServiceClient();
                    pideOSF_Reniec.PersonaRequest paramsReniec = new pideOSF_Reniec.PersonaRequest();
                    paramsReniec.Documento = asBusValor;
                    pideOSF_Reniec.ConsultaInfoRequest infoReniec = new pideOSF_Reniec.ConsultaInfoRequest();
                    infoReniec.App = "SIGOsfc v3";
                    infoReniec.IPTerminal = Request.UserHostAddress;
                    if (asFormulario == "GTF"){ infoReniec.UserName = "mlaurente"; }
                    else { infoReniec.UserName = (ModelSession.GetSession())[0].USUARIO_LOGIN; }
                    
                    pideOSF_Reniec.PersonaResponse resultReniec = new pideOSF_Reniec.PersonaResponse();

                    resultReniec = wsReniec.ConsultaDatosPersonaPorDNI(paramsReniec, infoReniec);
                    persona = new List<string>() { "", "0000001", resultReniec.ApePaterno, resultReniec.ApeMaterno, resultReniec.Nombres, asBusValor, "", "", resultReniec.Ubigeo.Replace("/", " - "), resultReniec.Direccion };
                }
                else if (asBusCriterio == "RUC")
                {
                    pideOSF_Sunat.SunatServiceClient wsSunat = new pideOSF_Sunat.SunatServiceClient();
                    pideOSF_Sunat.PersonaRequest paramsSunat = new pideOSF_Sunat.PersonaRequest();
                    paramsSunat.Ruc = asBusValor;
                    pideOSF_Sunat.ConsultaInfoRequest infoSunat = new pideOSF_Sunat.ConsultaInfoRequest();
                    infoSunat.App = "SIGOsfc v3";
                    infoSunat.IPTerminal = Request.UserHostAddress;
                    if (asFormulario == "GTF") { infoSunat.UserName = "mlaurente"; }
                    else { infoSunat.UserName = (ModelSession.GetSession())[0].USUARIO_LOGIN; }
                    pideOSF_Sunat.DatosRucResponse resultSunat = new pideOSF_Sunat.DatosRucResponse();

                    resultSunat = wsSunat.ConsultaRuc(paramsSunat, infoSunat);
                    string ubigeoText = (resultSunat.Departamento + " - " + resultSunat.Provincia + " - " + resultSunat.Distrito).ToUpper();
                    persona = new List<string>() { resultSunat.RazonSocial, asBusValor, "", ubigeoText, resultSunat.DomicilioLegal, resultSunat.Condicion, resultSunat.Estado };
                    /*
                       Posición:
                          0 - Razon social
                          1 -  Valor de busqueda
                          2 - 
                          3 - Ubigeo
                          4 - Dirección legal
                          5 - Condicion ruc
                          6 - Estado Ruc
                     */
                }
                else { throw new Exception("La consulta para el tipo de documento no se encuentra disponible"); }

                result.AddResultado("Registro encontrado", true, persona);
            }
            catch (EndpointNotFoundException enf) { throw new Exception(enf.Message); }
            catch (Exception ex) { result.success = false; result.msj = ex.Message; }

            return Json(result);
        }

        [HttpPost]
        public JsonResult GetPersona(string asCodPersona)
        {
            try
            {
                //Existen casos en las que no se tiene este valor
                //if (string.IsNullOrEmpty(asCodPersona)) throw new Exception("Código de persona inválido.");

                Ent_Persona oParams = new Ent_Persona() { COD_PERSONA = asCodPersona };
                Log_Persona exePersona = new Log_Persona();
                oParams = exePersona.RegMostrarListaItem(oParams);
                var jsonResult = Json(new { data = oParams, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion

        #region "POA"
        [HttpPost]
        public ActionResult _POA(string asFormulario, string asCriterio, string asValor)
        {
            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfCriterio = asCriterio;
            ViewBag.hdfValor = asValor;

            return PartialView();
        }
        [HttpGet]
        public JsonResult buscarPOA(string asFormulario, string asCriterio, string asValor)
        {
            try
            {
                Ent_CNOTIFICACION paramsCN = new Ent_CNOTIFICACION();
                Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                List<Ent_CNOTIFICACION> lstPoa = new List<Ent_CNOTIFICACION>();

                paramsCN.BusFormulario = asFormulario;
                paramsCN.BusCriterio = asCriterio;
                paramsCN.BusValor = asValor;
                lstPoa = exeCN.RegMostPoa_Thabilitante_Lista_x_Numero(paramsCN);
                var result = from lst in lstPoa
                             select new
                             {
                                 NUM_POA = lst.NUM_POA,
                                 NUM_PCOMPLEMENTARIO = lst.NUM_PCOMPLEMENTARIO,
                                 ESTADO_ORIGEN = lst.ESTADO_ORIGEN,
                                 NUM_RESOLUCION = lst.NUM_RESOLUCION.Trim(),
                                 COD_PMANEJO = lst.COD_PMANEJO.Trim(),
                                 NOMBRE_POA = lst.ESTADO_ORIGEN,
                                 ARESOLUCION_NUM = lst.NUM_RESOLUCION.Trim(),
                                 COD_THABILITANTE = lst.COD_THABILITANTE,
                                 ZAFRA = lst.NUM_ZAFRA
                             };
                var jsonResult = Json(new { success = true, msj = "", data = result }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region "_CNotificacion"
        [HttpPost]
        public PartialViewResult _CNotificacion(string asFormulario, string asCriterio, string asValor, string asControlInstancia = "")
        {
            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfCriterio = asCriterio;
            ViewBag.hdfValor = asValor;
            ViewBag.hdfControlInstancia = asControlInstancia;

            return PartialView();
        }
        public JsonResult buscarCNotificacion(string asFormulario, string asCriterio, string asValor)
        {
            try
            {
                List<Ent_CNOTIFICACION> lstCN = new List<Ent_CNOTIFICACION>();
                Ent_CNOTIFICACION paramsCN = new Ent_CNOTIFICACION();
                Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();

                paramsCN.BusFormulario = asFormulario;
                paramsCN.BusCriterio = asCriterio;
                paramsCN.BusValor = asValor;
                lstCN = exeCN.RegMostCNotificacion_Consulta(paramsCN);

                var jsonResult = Json(new { data = lstCN.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        /*
        [HttpPost]
        public PartialViewResult _CNotificacion(string asFormulario,string asCriterio, string asValor, string asTipo, string asControlInstancia="")
        {
            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfCriterio = asCriterio;
            ViewBag.hdfValor = asValor;
            ViewBag.hdfTipo = asTipo;
            ViewBag.hdfControlInstancia = asControlInstancia;
            return PartialView();
        }
        public JsonResult buscarCNotificacion(string asFormulario, string asCriterio, string asValor,string asTipo)
        {
            try
            {
                List<Ent_NOTIFICACION_CONSULTA> lstFN = new List<Ent_NOTIFICACION_CONSULTA>();
                Ent_NOTIFICACION_CONSULTA paramsFN = new Ent_NOTIFICACION_CONSULTA();
                Log_NOTIFICACION exeFN = new Log_NOTIFICACION();

                paramsFN.BusFormulario = asFormulario;
                paramsFN.BusCriterio = asCriterio;
                paramsFN.BusValor = asValor;
                paramsFN.BusTipo = asTipo;
                lstFN = exeFN.RegListarNotificacionConsulta_v3(paramsFN);

                var jsonResult = Json(new { data = lstFN.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        */
        #endregion

        #region "_IntegracionSIADO"
        public PartialViewResult _IntegracionSIADO(string asCriterio, string asSubCriterio, string asValor = "")
        {
            ViewBag.hdfCriterio = asCriterio;
            ViewBag.hdfSubCriterio = asSubCriterio;
            ViewBag.hdfValor = asValor;

            return PartialView();
        }
        public JsonResult buscarIntegracionSIADO(string asCriterio, string asSubCriterio, string asValor = "")
        {
            try
            {
                //List<Ent_IntSIADO> lstSIADO = new List<Ent_IntSIADO>();
                Ent_IntSIADO paramSIADO = new Ent_IntSIADO();
                Log_IntSIADO exeSIADO = new Log_IntSIADO();

                paramSIADO.BusCriterio = asCriterio;
                paramSIADO.BusValor = asSubCriterio;
                paramSIADO.Parametro = asValor;
                var lstSIADO = exeSIADO.RegMostrarListaSIADO_V3(paramSIADO);
                var jsonResult = Json(new { success = true, data = lstSIADO }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msj = ex.Message });
            }
        }
        public ActionResult VerificaSIADO(string fileName, string origen)
        {
            string pathRepo = "";
            switch (origen)
            {
                case "SIADO-REGION":
                    pathRepo = Server.MapPath("~/Ruta_SIADO_Region/");
                    break;
                case "SIADO":
                    pathRepo = Server.MapPath("~/Ruta_SIADO/");
                    break;
                case "SITD":
                    pathRepo = Server.MapPath("~/Ruta_SITD/");
                    break;
                case "SIGO":
                    pathRepo = Server.MapPath("~/Ruta_REPO_SIGO/");
                    break;
            }
            fileName = HelperSigo.RevisaArchivos(pathRepo, fileName + ".*");
            if (fileName.Trim() != "")
            {
                string FilePath = pathRepo + fileName;
                return new BinaryContentResult
                {
                    FileName = fileName,
                    ContentType = "application/octet-stream",
                    Content = System.IO.File.ReadAllBytes(FilePath)
                };
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }

        }
        public ActionResult DescargarIntegracionSIADO(string fileName, string origen)
        {
            string pathRepo = "";
            switch (origen)
            {
                case "SIADO-REGION":
                    pathRepo = Server.MapPath("~/Ruta_SIADO_Region/");
                    break;
                case "SIADO":
                    pathRepo = Server.MapPath("~/Ruta_SIADO/");
                    break;
                case "SITD":
                    pathRepo = Server.MapPath("~/Ruta_SITD/");
                    break;
                case "SIGO":
                    pathRepo = Server.MapPath("~/Ruta_REPO_SIGO/");
                    break;
            }

            //Extensiones soportadas
            string[] extensiones = { ".pdf", ".zip", ".7z", ".rar" };

            foreach (var ext in extensiones)
            {
                string FilePath = pathRepo + fileName + ext;
                if (System.IO.File.Exists(FilePath))
                {
                    return new BinaryContentResult
                    {
                        FileName = fileName + ext,
                        ContentType = "application/octet-stream",
                        Content = System.IO.File.ReadAllBytes(FilePath)
                    };
                }
            }

            return new HttpStatusCodeResult(0);

        }
        #endregion

        #region "_DevolucionMadera"
        [HttpPost]
        public PartialViewResult _DevolucionMadera(string asFormulario, string asCriterio, string asValor)
        {
            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfCriterio = asCriterio;
            ViewBag.hdfValor = asValor;

            return PartialView();
        }
        public JsonResult buscarDevolucionMadera(string asFormulario, string asCriterio, string asValor)
        {
            try
            {
                List<Ent_CNOTIFICACION> lstCN = new List<Ent_CNOTIFICACION>();
                Ent_CNOTIFICACION paramsCN = new Ent_CNOTIFICACION();
                Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();

                paramsCN.COD_THABILITANTE = asValor;
                lstCN = exeCN.RegMostDevol_Thabilitante_Lista_x_Numero(paramsCN);

                var jsonResult = Json(new { data = lstCN.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion

        #region "_ControlCalidad"
        public PartialViewResult _ControlCalidad(VM_ControlCalidad_2 dto, Boolean disableControl = false)
        {
            Ent_BUSQUEDA entBus = new Ent_BUSQUEDA();
            Log_BUSQUEDA logBus = new Log_BUSQUEDA();
            entBus.BusFormulario = "GENERAL";
            entBus.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            //Validamos el rol del usuario
            entBus.BusValor = dto.VALIAS_ROL;
            entBus = logBus.RegMostCombo(entBus);
            List<VM_Cbo> lstIndicador = entBus.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();

            bool enableIndicador = true;
            string itemSelectIndicador = dto.ddlIndicadorId;
            Log_Helper.controla_estado_calidad(dto.ddlIndicadorId, ref lstIndicador, ref enableIndicador, ref itemSelectIndicador);
            dto.ddlIndicador = lstIndicador;
            dto.ddlIndicadorId = itemSelectIndicador;
            dto.ddlIndicadorEnable = enableIndicador;
            dto.hdnDisableControl = disableControl;

            ViewBag.hdfCodGrupoUsuario = (ModelSession.GetSession())[0].COD_UGRUPO;

            return PartialView(dto);
        }
        public PartialViewResult _ControlCalidadAjax(string formulario, string codigo)
        {
            VM_ControlCalidad_2 vm = new VM_ControlCalidad_2();
            Log_BUSQUEDA logBus = new Log_BUSQUEDA();
            vm = logBus.obtenerControlCalidadV3(formulario, codigo, (ModelSession.GetSession())[0].COD_UCUENTA);
            vm.hdFrmControl = formulario;
            vm.hdIdControl = codigo;
            return PartialView(vm);
        }
        public ActionResult _VPCKEDITOR(string formulario, string codigo)
        {
            VM_ControlCalidad vm = new VM_ControlCalidad();
            Log_BUSQUEDA logBus = new Log_BUSQUEDA();
            vm = logBus.obtenerObservacionControlCalidadV3(formulario, codigo);
            return PartialView(vm);
        }
        #endregion
        #region "SITD"
        [HttpGet]
        public ActionResult _ConsultaSITD(string op = "DOC_SALIDA")
        {
            if (op == "DOC_SALIDA")
            {
                ViewBag.lspOpcionSITD = new List<SelectListItem>() { new SelectListItem() { Text = "Nro Documento", Value = "CNRODOCUMENTO" } };
            }
            else
            {
                ViewBag.lspOpcionSITD = new List<SelectListItem>() { new SelectListItem() { Text = "Nro Documento", Value = "CNRODOCUMENTO" },
                                                                  new SelectListItem() { Text = "Codigo Asignado", Value = "CCODIFICACION" }};
            }
            ViewBag.busFormularioSITD = op;
            return PartialView();
        }
        [HttpGet]
        public ActionResult _MemConsultaSITD(string op = "DOC_SALIDA_MEM")
        {
            if (op == "DOC_SALIDA_MEM")
            {
                ViewBag.lspOpcionSITD = new List<SelectListItem>() { new SelectListItem() { Text = "Codigo Asignado", Value = "CCODIFICACION" } };
            }
            else
            {
                ViewBag.lspOpcionSITD = new List<SelectListItem>() { new SelectListItem() { Text = "Nro Documento", Value = "CNRODOCUMENTO" },
                                                                  new SelectListItem() { Text = "Codigo Asignado", Value = "CCODIFICACION" }};
            }
            ViewBag.busFormularioSITD = op;
            return PartialView();
        }
        [HttpGet]
        public JsonResult GetListaDocumentosSITDPaging(DataTableRequest request = null)
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
                //paramsBus.sort = request.Columns[request.Order[0].Column].Data + " " + request.Order[0].Dir;
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.ListarDocumentosSITD_Paging(paramsBus, ref rowcount);

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
        [HttpGet]
        public JsonResult GetListaDocumentosMemSITDPaging(DataTableRequest request = null)
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
                //paramsBus.sort = request.Columns[request.Order[0].Column].Data + " " + request.Order[0].Dir;
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.ListarDocumentosSITD_Paging(paramsBus, ref rowcount);

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

        #region Dependencia Ubigeo
        [HttpPost]
        public JsonResult getDependenciasxUbigeo(string ubigeo)
        {
            Ent_DEPENDENCIA_UBIGEO oCampos = new Ent_DEPENDENCIA_UBIGEO();

            oCampos.BusFormulario = "DEPENDENCIA_UBIGEO";
            oCampos.BusCriterio = "UBIGEO";
            oCampos.BusValor = ubigeo;
            oCampos = new Log_DEPENDENCIA_UBIGEO().RegMostCombo(oCampos);
            var jsonResult = Json(Log_Helper.ListComboLlenar(oCampos.ListDependencia, "CODIGO", "DESCRIPCION", true), JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
        #region Dependencia Ubigeo
        [HttpPost]
        public JsonResult getDependenciasxCodTHabilitantes(string codTHabilitantes)
        {


            Ent_DEPENDENCIA_UBIGEO oCampos = new Ent_DEPENDENCIA_UBIGEO();
            oCampos.BusFormulario = "DEPENDENCIA_UBIGEO";
            oCampos.BusCriterio = "THABILITANTES";
            oCampos.BusValor = codTHabilitantes;
            oCampos = new Log_DEPENDENCIA_UBIGEO().RegMostCombo(oCampos);
            var jsonResult = Json(Log_Helper.ListComboLlenar(oCampos.ListDependencia, "CODIGO", "DESCRIPCION", true), JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion

        #region "_DenunciaSITD"
        [HttpPost]
        public PartialViewResult _DenunciaSITD()
        {
            return PartialView();
        }
        //public JsonResult buscarDenunciaSITD(string asCriterio, string asValor)
        //{
        //    try
        //    {
        //        Ent_DENUNCIA_SITD oEntDenuncia = new Ent_DENUNCIA_SITD();
        //        Log_DENUNCIA_SITD oLogDenuncia = new Log_DENUNCIA_SITD();

        //        oEntDenuncia.BusFormulario = "DENUNCIA_SITD";
        //        oEntDenuncia.BusCriterio = asCriterio;
        //        oEntDenuncia.BusValor = asValor;

        //        var jsonResult = Json(new { data = oLogDenuncia.RegBuscarDenuncia(oEntDenuncia).ToArray() }, JsonRequestBehavior.AllowGet);
        //        jsonResult.MaxJsonLength = int.MaxValue;
        //        return jsonResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, msj = ex.Message });
        //    }
        //}
        #endregion

        #region "Combos Paging"
        [HttpGet]
        public JsonResult GetComboEspeciePaging(string tipoEspecie, string searchTerm, int pageSize, int pageNum, string type)
        {
            Log_BUSQUEDA log = new Log_BUSQUEDA();
            searchTerm = string.IsNullOrEmpty(searchTerm) ? "" : searchTerm.Trim();
            type = string.IsNullOrEmpty(type) ? "" : type.Trim();
            Select2PagedResult result = new Select2PagedResult();
            if (!type.Equals("query:append"))
            {
                result = log.RegMostComboIndividualPaging("ESPECIES", tipoEspecie, searchTerm, pageSize, pageNum);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetComboCensoPaging(string codTH, string poa, string searchTerm, int pageSize, int pageNum)
        {
            Log_BUSQUEDA log = new Log_BUSQUEDA();
            searchTerm = string.IsNullOrEmpty(searchTerm) ? "" : searchTerm.Trim();
            int itemPoa = Convert.ToInt32(poa);
            var result = log.RegMostComboIndividualPaging("BUSQUEDA_CENSO_X_POA", codTH, searchTerm, pageSize, pageNum, itemPoa);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region "Validar Plantillas"
        public ActionResult ValidarPlantilla()
        {
            ViewBag.vbOrigen = "";
            Log_BUSQUEDA log = new Log_BUSQUEDA();

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Validar Plantilla Excel");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View(log.RegListasValidacionV3());
        }
        [HttpGet]
        public PartialViewResult _ValidarPlantilla(string origen = "")
        {
            ViewBag.vbOrigen = origen;
            Log_BUSQUEDA log = new Log_BUSQUEDA();
            return PartialView(log.RegListasValidacionV3());
        }

        [HttpPost]
        public JsonResult ValidarFormatoExcel()
        {
            try
            {
                List<Ent_BUSQUEDA> oListado = new List<Ent_BUSQUEDA>();
                string ltrerror = "";
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    //obteniendo datos de excel
                    DataTable Datos = HelperSigo.GetDatosExcel(file, Server.MapPath("~/Archivos/DatosImportacion/"));
                    //
                    Log_BUSQUEDA oLogica = new Log_BUSQUEDA();
                    Ent_BUSQUEDA combo = new Ent_BUSQUEDA();
                    Ent_BUSQUEDA oCampos;
                    ListBusqueda<Ent_BUSQUEDA> oListBus;
                    Int32 i = 1;
                    Int32 Item = 0;
                    //String OUTPUTPARAM;
                    int iL = 0; Double diL;
                    combo = oLogica.RegListasValidacion(combo);
                    string tipoFormatoValidar = Request["tipo"];
                    switch (tipoFormatoValidar)
                    {
                        #region POARAM
                        case "POARAM":
                            if (Datos.Columns.Count != 9)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de la Resolución de Aprobación del POA Maderable");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[4].ToString().Trim() == "" || !Int32.TryParse(Fila[4].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo NUM_ARBOLES vacío o irreconocible, "; }
                                    if (Fila[5].ToString().Trim() == "" || !Double.TryParse(Fila[5].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOLUMEN vacío o irreconocible, "; }

                                    if (Fila[2].ToString().Trim() != "" || Fila[3].ToString().Trim() != "")
                                    {
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim()), true);
                                        Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie SERFOR Incorrecta, ";
                                        }
                                    }

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en la Resolución de Aprobación del POA Maderable: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region POARAMPMED
                        case "POARAMPMED":
                            if (Datos.Columns.Count != 12)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de la Resolución de Aprobación del POA Plantas Medicinales");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[4].ToString().Trim() == "" || !Double.TryParse(Fila[4].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ABUNDANCIA vacío o irreconocible, "; }
                                    if (Fila[5].ToString().Trim() == "" || !Double.TryParse(Fila[5].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo NUM_INDIV_APROVECHAR vacío o irreconocible, "; }
                                    if (Fila[6].ToString().Trim() == "" || !Double.TryParse(Fila[6].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PESO_SECO vacío o irreconocible, "; }
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo RENDIMIENTO vacío o irreconocible, "; }

                                    if (Fila[2].ToString().Trim() != "" || Fila[3].ToString().Trim() != "")
                                    {
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim()), true);
                                        Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie SERFOR Incorrecta, ";
                                        }
                                    }

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en la Resolución de Aprobación del POA Maderable: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region POABEXTM
                        case "POABEXTM":
                            if (Datos.Columns.Count != 12)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos del Balance de Extracción del POA Maderable");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[4].ToString().Trim() == "" || !Int32.TryParse(Fila[4].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DMC vacío o irreconocible, "; }
                                    if (Fila[5].ToString().Trim() == "" || !Int32.TryParse(Fila[5].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo TOTAL_ARBOLES vacío o irreconocible, "; }
                                    if (Fila[6].ToString().Trim() == "" || !Double.TryParse(Fila[6].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOLUMEN_AUTORIZADO vacío o irreconocible, "; }
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOLUMEN_MOVILIZADO vacío o irreconocible, "; }
                                    if (Fila[8].ToString().Trim() == "" || !Double.TryParse(Fila[8].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo SALDO vacío o irreconocible, "; }

                                    if (Fila[2].ToString().Trim() != "" || Fila[3].ToString().Trim() != "")
                                    {
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim()), true);
                                        Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie SERFOR Incorrecta, ";
                                        }
                                    }

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en el Balance de Extracción del POA Maderable: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region ISUCVOLINJUS
                        case "ISUCVOLINJUS":
                            if (Datos.Columns.Count != 8)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Volumen Injustificado y Justificado del Informe");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[2].ToString().Trim() == "" || !Double.TryParse(Fila[2].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOL_APROBADO vacío o irreconocible, "; }
                                    if (Fila[3].ToString().Trim() == "" || !Double.TryParse(Fila[3].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOL_MOVILIZADO vacío o irreconocible, "; }
                                    if (Fila[4].ToString().Trim() == "" || !Double.TryParse(Fila[4].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOL_INJUSTIFICADO vacío o irreconocible, "; }
                                    if (Fila[5].ToString().Trim() == "" || !Double.TryParse(Fila[5].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOL_JUSTIFICADO vacío o irreconocible, "; }
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en el Volumen Injustificado y Justificado del Informe: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region POABEXTNMPMED
                        case "POABEXTNMPMED":
                            if (Datos.Columns.Count != 9)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos del Balance de Extracción del POA No Maderable de la Modalidad de Plantas Medicinales");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[4].ToString().Trim() == "" || !Double.TryParse(Fila[4].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_AUTORIZADA vacío o irreconocible, "; }
                                    if (Fila[5].ToString().Trim() == "" || !Double.TryParse(Fila[5].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_MOVILIZADA vacío o irreconocible, "; }
                                    if (Fila[6].ToString().Trim() == "" || !Double.TryParse(Fila[6].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo SALDO vacío o irreconocible, "; }

                                    if (Fila[2].ToString().Trim() != "" || Fila[3].ToString().Trim() != "")
                                    {
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim()), true);
                                        Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Resolución POA Incorrecta, ";
                                        }
                                    }

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en el Balance de Extracción del POA No Maderable de la Modalidad de Plantas Medicinales: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region LISTAPASPEQ
                        case "LISTAPASPEQ":
                            if (Datos.Columns.Count != 62)
                            {
                                throw new Exception("La plantilla seleccionada no se corresponde con el listado del Paspeq");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = "";
                                    oCampos.OBSERVACION = "";
                                    if (Fila[4].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo TABLA_ORIGEN está vacío, "; }
                                    else
                                    {
                                        if (Fila[4].ToString().Trim() == "POA")
                                        {
                                            if (Fila[1].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo COD_THABILITANTE está vacío, "; }
                                            if (Fila[2].ToString().Trim() == "" || !Int32.TryParse(Fila[2].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo NUM_POA está vacío o no es entero, "; }
                                        }
                                        else if (Fila[4].ToString().Trim() == "PLAN_MANEJO")
                                        {
                                            if (Fila[1].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo COD_THABILITANTE está vacío, "; }
                                            if (Fila[2].ToString().Trim() != "0") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo NUM_POA tiene datos inconsistentes, "; }
                                            if (Fila[3].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo COD_PMANEJO está vacío, "; }
                                        }
                                        else
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "El valor del campo TABLA_ORIGEN no corresponde con el nombre de las tablas, ";
                                        }
                                    }

                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }

                                    i++;
                                }
                                ltrerror = String.Format("N° de errores en el listado del Paspeq: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region PRIORIZACION
                        case "PRIORIZACION":
                            if (Datos.Columns.Count != 18)
                            {
                                throw new Exception("La plantilla seleccionada no se corresponde con el formato de priorización");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = "";
                                    oCampos.OBSERVACION = "";
                                    if (Fila[1].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo con el código del registro está vacío, "; }
                                    if (Fila[2].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo con el número del título habilitante está vacío, "; }
                                    if (Fila[3].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo con el nombre del POA está vacío, "; }

                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }

                                    i++;
                                }
                                ltrerror = String.Format("N° de errores en el formato de priorización: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region POAMADE
                        case "POAMADE":
                            if (Datos.Columns.Count != 18)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Censo del POA Maderable");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = "";
                                    oCampos.OBSERVACION = "";
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo VOLUMEN_ESPECIE vacío o irreconocible, "; }
                                    if (Fila[8].ToString().Trim() == "" || !Double.TryParse(Fila[8].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP vacío o irreconocible, "; }
                                    if (Fila[9].ToString().Trim() == "" || !Double.TryParse(Fila[9].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo AC vacío o irreconocible, "; }
                                    if (Fila[10].ToString().Trim() == "" || !Double.TryParse(Fila[10].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DMC vacío o irreconocible, "; }
                                    
                                    if (Fila[12].ToString().Trim() == "")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "debe seleccionar el estado de la especie; ";
                                    }


                                    if (Fila[13].ToString().Trim() != "17" && Fila[13].ToString().Trim() != "18" && Fila[13].ToString().Trim() != "19"
                                        && Fila[13].ToString().Trim() != "17S" && Fila[13].ToString().Trim() != "18S" && Fila[13].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[14].ToString().Trim().Length == 6 || Fila[14].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[14].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[15].ToString().Trim().Length == 7 || Fila[15].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[15].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    //oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim()), true);
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1)
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, ";
                                        oCampos.DESCRIPCION = (oCampos.DESCRIPCION == "" ? String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim()) : oCampos.DESCRIPCION + ", " + String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim()));
                                    }
                                    if (Fila[2].ToString().Trim() != "" || Fila[3].ToString().Trim() != "")
                                    {
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim()), true);
                                        Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Resolución POA Incorrecta, ";
                                        }
                                    }
                                    //oCampos.DESCRIPCION = Fila[9].ToString().Trim();
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", Fila[11].ToString().Trim(), true);
                                    //i++;
                                    Item = combo.ListCondicionMad.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1)
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo Condición incorrecto, ";
                                        oCampos.DESCRIPCION = (oCampos.DESCRIPCION == "" ? Fila[11].ToString().Trim() : oCampos.DESCRIPCION + ", " + Fila[11].ToString().Trim());
                                    }

                                    i++;
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en el CENSO del POA Maderable: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        #region POANOMADEC
                        case "POANOMADEC":
                            if (Datos.Columns.Count != 14)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Censo del POA no Maderable (Castaña)");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[6].ToString().Trim() == "" || !Double.TryParse(Fila[6].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ALTURA vacío o irreconocible, "; }
                                    if (Fila[8].ToString().Trim() == "" || !Double.TryParse(Fila[8].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PRODUCCION_LATAS vacío o irreconocible, "; }
                                    if (Fila[10].ToString().Trim() != "17" && Fila[10].ToString().Trim() != "18" && Fila[10].ToString().Trim() != "19"
                                        && Fila[10].ToString().Trim() != "17S" && Fila[10].ToString().Trim() != "18S" && Fila[10].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[11].ToString().Trim().Length == 6 || Fila[11].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[11].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[12].ToString().Trim().Length == 7 || Fila[12].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[12].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Fila[2].ToString().Trim() != "" || Fila[3].ToString().Trim() != "")
                                    {
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim()), true);
                                        Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Resolución POA Incorrecta, ";
                                        }
                                    }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en el CENSO del POA no Maderable (Castaña): ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUMADE
                        case "ISUMADE":
                            if (Datos.Columns.Count != 36)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Campo Maderables");
                            }
                            else
                            {
                                string codSistema = "";
                                CapaLogica.DOC.Log_POA tmpValidar = new CapaLogica.DOC.Log_POA();

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    codSistema = Fila[0].ToString().Trim();
                                    if (!tmpValidar.Temp_Validad_CodSistema(codSistema))
                                    {
                                        oCampos.OBSERVACION += "Campo COD_SISTEMA: " + codSistema + " no existe en el SIGOsfc";
                                    }

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[9].ToString().Trim(), Fila[10].ToString().Trim());

                                    if (Fila[19].ToString().Trim() == "" || !Double.TryParse(Fila[19].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO vacío o irreconocible, "; }
                                    if (Fila[20].ToString().Trim() == "" || !Double.TryParse(Fila[20].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO 1 vacío o irreconocible, "; }
                                    if (Fila[21].ToString().Trim() == "" || !Double.TryParse(Fila[21].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO 2 vacío o irreconocible, "; }
                                    if (Fila[24].ToString().Trim() == "" || !Double.TryParse(Fila[24].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo AC_CAMPO vacío o irreconocible, "; }

                                    if (Fila[13].ToString().Trim() != "17" && Fila[13].ToString().Trim() != "18" && Fila[13].ToString().Trim() != "19"
                                        && Fila[13].ToString().Trim() != "17S" && Fila[13].ToString().Trim() != "18S" && Fila[13].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[15].ToString().Trim().Length == 6 || Fila[15].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[15].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[17].ToString().Trim().Length == 7 || Fila[17].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[17].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    if (Fila[29].ToString().Trim() == "" || !Int32.TryParse(Fila[29].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_SOBRE_ESTIMA_DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[30].ToString().Trim() == "" || !Double.TryParse(Fila[30].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PORC_SOBRE_ESTIMA_DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[31].ToString().Trim() == "" || !Int32.TryParse(Fila[31].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_SUB_ESTIMA_DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[32].ToString().Trim() == "" || !Double.TryParse(Fila[32].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PORC_SUB_ESTIMA_DIAMETRO vacío o irreconocible, "; }

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de campo de Supervisión Maderable: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUMADESEM
                        case "ISUMADESEM":
                            if (Datos.Columns.Count != 40)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Campo Semillero Maderables");
                            }
                            else
                            {
                                string codSistema = "";
                                CapaLogica.DOC.Log_POA tmpValidar = new CapaLogica.DOC.Log_POA();

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    codSistema = Fila[0].ToString().Trim();
                                    if (!tmpValidar.Temp_Validad_CodSistema(codSistema))
                                    {
                                        oCampos.OBSERVACION += "Campo COD_SISTEMA: " + codSistema + " no existe en el SIGOsfc";
                                    }

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[9].ToString().Trim(), Fila[10].ToString().Trim());

                                    if (Fila[19].ToString().Trim() == "" || !Double.TryParse(Fila[19].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO vacío o irreconocible, "; }
                                    if (Fila[20].ToString().Trim() == "" || !Double.TryParse(Fila[20].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO 1 vacío o irreconocible, "; }
                                    if (Fila[21].ToString().Trim() == "" || !Double.TryParse(Fila[21].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO 2 vacío o irreconocible, "; }
                                    if (Fila[24].ToString().Trim() == "" || !Double.TryParse(Fila[24].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo AC_CAMPO vacío o irreconocible, "; }

                                    if (Fila[13].ToString().Trim() != "17" && Fila[13].ToString().Trim() != "18" && Fila[13].ToString().Trim() != "19"
                                        && Fila[13].ToString().Trim() != "17S" && Fila[13].ToString().Trim() != "18S" && Fila[13].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[15].ToString().Trim().Length == 6 || Fila[15].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[15].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[17].ToString().Trim().Length == 7 || Fila[17].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[17].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    if (Fila[35].ToString().Trim() == "" || !Int32.TryParse(Fila[35].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_SOBRE_ESTIMA_DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[36].ToString().Trim() == "" || !Double.TryParse(Fila[36].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PORC_SOBRE_ESTIMA_DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[37].ToString().Trim() == "" || !Int32.TryParse(Fila[37].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_SUB_ESTIMA_DIAMETRO vacío o irreconocible, "; }
                                    if (Fila[38].ToString().Trim() == "" || !Double.TryParse(Fila[38].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PORC_SUB_ESTIMA_DIAMETRO vacío o irreconocible, "; }

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de campo de Supervisión Semillero Maderable: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUBOSE
                        case "ISUBOSE":
                            if (Datos.Columns.Count != 44)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Campo de Bosques Secos");
                            }
                            else
                            {
                                string codSistema = "";
                                CapaLogica.DOC.Log_POA tmpValidar = new CapaLogica.DOC.Log_POA();

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    codSistema = Fila[0].ToString().Trim();
                                    if (!tmpValidar.Temp_Validad_CodSistema(codSistema))
                                    {
                                        oCampos.OBSERVACION += "Campo COD_SISTEMA: " + codSistema + " no existe en el SIGOsfc";
                                    }

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim());

                                    if (Fila[12].ToString().Trim() == "" || !Double.TryParse(Fila[12].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO vacío o irreconocible, "; }
                                    if (Fila[14].ToString().Trim() == "" || !Double.TryParse(Fila[14].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo AC_CAMPO vacío o irreconocible, "; }

                                    if (Fila[21].ToString().Trim() != "17" && Fila[21].ToString().Trim() != "18" && Fila[21].ToString().Trim() != "19"
                                        && Fila[21].ToString().Trim() != "17S" && Fila[21].ToString().Trim() != "18S" && Fila[21].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[23].ToString().Trim().Length == 6 || Fila[23].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[23].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[25].ToString().Trim().Length == 7 || Fila[25].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[25].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    if (Fila[28].ToString().Trim() == "" || !Double.TryParse(Fila[28].ToString().Trim(), out diL)) { oCampos.OBSERVACION = "ALT_TOTAL_CAMPO vacío"; }
                                    if (Fila[29].ToString().Trim() == "" || !Double.TryParse(Fila[29].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D1_CAMPO vacío"; }
                                    if (Fila[30].ToString().Trim() == "" || !Double.TryParse(Fila[30].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D2_CAMPO vacío"; }
                                    if (Fila[31].ToString().Trim() == "" || !Double.TryParse(Fila[31].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D3_CAMPO vacío"; }
                                    if (Fila[32].ToString().Trim() == "" || !Double.TryParse(Fila[32].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D4_CAMPO vacío"; }
                                    if (Fila[33].ToString().Trim() == "" || !Double.TryParse(Fila[33].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D5_CAMPO vacío"; }
                                    if (Fila[34].ToString().Trim() == "" || !Double.TryParse(Fila[34].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D6_CAMPO vacío"; }
                                    if (Fila[35].ToString().Trim() == "" || !Double.TryParse(Fila[35].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " D7_CAMPO vacío"; }
                                    if (Fila[36].ToString().Trim() == "" || !Double.TryParse(Fila[36].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L1_CAMPO vacío"; }
                                    if (Fila[37].ToString().Trim() == "" || !Double.TryParse(Fila[37].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L2_CAMPO vacío"; }
                                    if (Fila[38].ToString().Trim() == "" || !Double.TryParse(Fila[38].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L3_CAMPO vacío"; }
                                    if (Fila[39].ToString().Trim() == "" || !Double.TryParse(Fila[39].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L4_CAMPO vacío"; }
                                    if (Fila[40].ToString().Trim() == "" || !Double.TryParse(Fila[40].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L5_CAMPO vacío"; }
                                    if (Fila[41].ToString().Trim() == "" || !Double.TryParse(Fila[41].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L6_CAMPO vacío"; }
                                    if (Fila[42].ToString().Trim() == "" || !Double.TryParse(Fila[42].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + " L7_CAMPO vacío"; }
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        //oCampos.ESPECIES = listado_especie[Item].DESCRIPCION;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de campo de Supervisión de Bosques Secos: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUCASTANA
                        case "ISUCASTANA":
                            if (Datos.Columns.Count != 22)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Campo de Castaña");
                            }
                            else
                            {
                                string codSistema = "";
                                CapaLogica.DOC.Log_POA tmpValidar = new CapaLogica.DOC.Log_POA();

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    codSistema = Fila[0].ToString().Trim();
                                    if (!tmpValidar.Temp_Validad_CodSistema(codSistema))
                                    {
                                        oCampos.OBSERVACION += "Campo COD_SISTEMA: " + codSistema + " no existe en el SIGOsfc";
                                    }

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim());

                                    //if (Fila[10].ToString().Trim() == "" || !Double.TryParse(Fila[10].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DIAMETRO_CAMPO vacío o irreconocible, "; }
                                    //if (Fila[12].ToString().Trim() == "" || !Double.TryParse(Fila[12].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ALTURA_CAMPO vacío o irreconocible, "; }
                                    //if (Fila[14].ToString().Trim() == "" || !Double.TryParse(Fila[14].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PRODUCCION_LATAS_CAMPO vacío o irreconocible, "; }

                                    if (Fila[12].ToString().Trim() != "17" && Fila[12].ToString().Trim() != "18" && Fila[12].ToString().Trim() != "19"
                                        && Fila[12].ToString().Trim() != "17S" && Fila[12].ToString().Trim() != "18S" && Fila[12].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[14].ToString().Trim().Length != 6 && Fila[14].ToString().Trim() != "0")
                                    {
                                        if (Fila[14].ToString().Trim() == "")
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                        }
                                        else if (!Int32.TryParse(Fila[14].ToString().Trim(), out iL))
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                        }
                                    }
                                    if (Fila[16].ToString().Trim().Length != 7 && Fila[16].ToString().Trim() != "0")
                                    {
                                        if (Fila[16].ToString().Trim() == "")
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                        }
                                        else if (!Int32.TryParse(Fila[16].ToString().Trim(), out iL))
                                        {
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                        }
                                    }
                                    //if (Fila[25].ToString().Trim() == "" || !Int32.TryParse(Fila[25].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo C_ABIERTO vacío o irreconocible, "; }
                                    //if (Fila[26].ToString().Trim() == "" || !Int32.TryParse(Fila[26].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo C_CERRADO vacío o irreconocible, "; }
                                    //oCampos.OBSERVACION = "";                                
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        //oCampos.ESPECIES = listado_especie[Item].DESCRIPCION;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de campo de Supervisión de Castaña: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUINDADIC
                        case "ISUINDADIC":
                            if (Datos.Columns.Count != 15)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Evaluación de Individuos adicionales");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[5].ToString().Trim() == "" || !Double.TryParse(Fila[5].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO vacío o irreconocible, "; }
                                    if (Fila[6].ToString().Trim() == "" || !Double.TryParse(Fila[6].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO_1 vacío o irreconocible, "; }
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_CAMPO_2 vacío o irreconocible, "; }
                                    if (Fila[9].ToString().Trim() == "" || !Double.TryParse(Fila[9].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo AC_CAMPO vacío o irreconocible, "; }

                                    if (Fila[10].ToString().Trim() != "17" && Fila[10].ToString().Trim() != "18" && Fila[10].ToString().Trim() != "19"
                                                                && Fila[10].ToString().Trim() != "17S" && Fila[10].ToString().Trim() != "18S" && Fila[10].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[11].ToString().Trim().Length == 6 || Fila[11].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[11].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[12].ToString().Trim().Length == 7 || Fila[12].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[12].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de campo de Evaluación de Individuos adicionales: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region CAPPARTICIPANTES
                        case "CAPPARTICIPANTES":
                            if (Datos.Columns.Count != 15)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Participantes de Capacitación");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";
                                    if (!Int32.TryParse(Fila[7].ToString().Trim(), out iL))
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo Edad, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "La edad no tiene el formato correcto (campo vacío o no es un número); ";
                                    }
                                    if (Fila[0].ToString().Trim() == "" && Fila[1].ToString().Trim() == "" && Fila[2].ToString().Trim() == "")
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en los nombres, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Debe definir los apellidos y/o nombres del participante; ";

                                    }
                                    //if ((Fila[3].ToString().Trim().IndexOf("  ") == 0) || (Fila[4].ToString().Trim().IndexOf("  ") == 0))
                                    //{
                                    //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en los nombres, ";
                                    //    oCampos.OBSERVACION = oCampos.OBSERVACION + "No deben existir dobles espacios en los campos NOMBRES_APELLIDOS o APELLIDOS_NOMBRES; ";

                                    //}
                                    //if ((Fila[3].ToString().Trim().IndexOf(" ", Fila[3].ToString().Trim().IndexOf(" ") + 1) == 0 && Fila[3].ToString().Trim() != "") || (Fila[4].ToString().Trim().IndexOf(" ", Fila[4].ToString().Trim().IndexOf(" ") + 1) == 0 && Fila[4].ToString().Trim() != ""))
                                    //{
                                    //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en los nombres, ";
                                    //    oCampos.OBSERVACION = oCampos.OBSERVACION + "Deben estar incluidos los apellidos (paterno y materno) y los nombres, en caso que no esten completos, por favor incluirlos en los campos APE_PARTERNO,APE_MATERNO,NOMBRES; ";

                                    //}
                                    if (Fila[3].ToString().Trim() == "" || Fila[3].ToString().Trim().Length < 8 || Fila[3].ToString().Trim().Length > 8)
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el documento, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "debe indicar correctamente el documento del participante (en caso de no contar con ello ingrese '00000000' y menciónelo en las observaciones); ";

                                    }
                                    if (Fila[4].ToString().Trim() == "")
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en la institución de procedencia, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "debe indicar la institución de procedencia del participante según la lista desplegable; ";

                                    }
                                    if (Fila[6].ToString().Trim() != "M" && Fila[6].ToString().Trim() != "F")
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el genero del Participante, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "debe seleccionar Masculino (M) o Femenino (F); ";

                                    }
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", Fila[4].ToString().Trim(), true);
                                    i++;
                                    Item = combo.ListInstitucionesCapac.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1)
                                    {
                                        oCampos.DESCRIPCION = Fila[4].ToString().Trim();
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Institucion de procedencia Incorrecta, ";
                                    }
                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        //oCampos.ESPECIES = listado_especie[Item].DESCRIPCION;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de Participantes de Capacitación: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region VALGTF
                        case "VALGTF":
                            if (Datos.Columns.Count != 42)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Carga Masiva de Guias de Transporte Forestal");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";
                                    if (Fila[0].ToString().Trim() == "")
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo NUM_GUIA, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo NUM_GUIA no debe ser vacío (Campo Obligatorio); ";
                                    }
                                    else
                                    {
                                        //if (Fila[1].ToString().Trim() == "")
                                        //{
                                        //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo ENTIDAD_EMITE, ";
                                        //    oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo ENTIDAD_EMITE no debe ser vacio; ";
                                        //}
                                        //if (Fila[2].ToString().Trim() == "")
                                        //{
                                        //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo SEDE, ";
                                        //    oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo SEDE no debe ser vacio; ";
                                        //}
                                        if (Fila[3].ToString().Trim() == "")
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo FECHA_EXPEDICION, ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo FECHA_EXPEDICION no debe ser vacío; ";
                                        }
                                        //if (Fila[4].ToString().Trim() == "")
                                        //{
                                        //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo FECHA_VENCIMIENTO, ";
                                        //    oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo FECHA_VENCIMIENTO no debe ser vacío; ";
                                        //}
                                        if (Fila[5].ToString().Trim() == "")
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo TITULO_HABILITANTE, ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo TITULO_HABILITANTE no debe ser vacío (Campo Obligatorio); ";
                                        }
                                        oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", Fila[5].ToString().Trim(), true);
                                        Item = combo.ListTH.FindIndex(oListBus.PredicateBus);
                                        if (Item == -1)
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "" + Fila[5].ToString().Trim() + " ( " + Fila[11].ToString().Trim() + " ), ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "El titulo habilitante no está registrado en la Base de Datos, en caso de procesar los datos se registrará solo el número, ";
                                        }
                                        if (Fila[11].ToString().Trim() == "")
                                        {
                                            if (Item == -1)
                                            {
                                                oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo TITULAR, ";
                                                oCampos.OBSERVACION = oCampos.OBSERVACION + "El Titulo Habilitante No está registrado, no se recomienda que el campo TITULAR este vacío; ";

                                                if (Fila[13].ToString().Trim() == "" && Fila[14].ToString().Trim() == "")
                                                {
                                                    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en los campos TIT_DNI y TIT_RUC, ";
                                                    oCampos.OBSERVACION = oCampos.OBSERVACION + "Se recomienda definir los campos de documentos para el TITULAR, de lo contrario se asignará un numero por defecto ('00000000' para DNI en personas naturales y '00000000000' en RUC para personas jurídicas); ";
                                                }
                                            }
                                            else
                                            {
                                                oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo TITULAR, ";
                                                oCampos.OBSERVACION = oCampos.OBSERVACION + "El Titulo Habilitante está registrado, no es necesario indicar el campo TITULAR, verifique que sea el correcto ; ";
                                            }

                                        }
                                        if (Fila[15].ToString().Trim() == "")
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo PROPIETARIO, ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "No se recomienda que el campo PROPIETARIO este vacío; ";
                                        }
                                        else if (Fila[17].ToString().Trim() == "" && Fila[18].ToString().Trim() == "")
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en los campos PRO_DNI y PRO_RUC, ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Se recomienda definir los campos de documentos para el PROPIETARIO, de lo contrario se asignará un numero por defecto ('00000000' para DNI en personas naturales y '00000000000' en RUC para personas jurídicas); ";
                                        }
                                        //if (Fila[19].ToString().Trim() == "")
                                        //{
                                        //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo DESTINATARIO, ";
                                        //    oCampos.OBSERVACION = oCampos.OBSERVACION + "No se recomienda que el campo DESTINATARIO este vacío; ";
                                        //}
                                        //else if (Fila[21].ToString().Trim() == "" && Fila[22].ToString().Trim() == "")
                                        //{
                                        //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en los campos DES_DNI y DES_RUC, ";
                                        //    oCampos.OBSERVACION = oCampos.OBSERVACION + "Se recomienda definir los campos de documentos para el DESTINATARIO, de lo contrario se asignará un numero por defecto ('00000000' para DNI en personas naturales y '00000000000' en RUC para personas jurídicas); ";
                                        //}
                                        //if (Fila[6].ToString().Trim() == "" || Fila[7].ToString().Trim() == "" || Fila[8].ToString().Trim() == "")
                                        //{
                                        //    oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el ubigeo del Titulo Habilitante, ";
                                        //    oCampos.OBSERVACION = oCampos.OBSERVACION + "Los Campos de Ubigeo deben estar completos de lo contrario no se podrá cargar el dato; ";
                                        //}
                                        if (Fila[9].ToString().Trim() == "")
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo ZAFRA, ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo ZAFRA no debe ser vacío; ";
                                        }
                                        if (Fila[10].ToString().Trim() == "")
                                        {
                                            oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo POA, ";
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "El campo POA no debe ser vacío (Campo Obligatorio); ";
                                        }
                                    }
                                    if (Fila[30].ToString().Trim() == "")
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "Inconsistencia en el campo LISTA_TROZAS, ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "No se recomienda que el campo LISTA_TROZAS sea vacío; ";
                                    }
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", Fila[31].ToString().Trim(), true);
                                    Item = combo.ListEspNCientifico.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1)
                                    {
                                        oCampos.DESCRIPCION = oCampos.DESCRIPCION + "" + Fila[31].ToString().Trim() + ", ";
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "El Nombre Comercial no existe, ";
                                    }
                                    if (Fila[33].ToString().Trim() == "" || !Double.TryParse(Fila[33].ToString().Trim(), out diL))
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANTIDAD vacío o irreconocible, ";
                                    }
                                    if (Fila[35].ToString().Trim() == "" || !Double.TryParse(Fila[35].ToString().Trim(), out diL))
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo TOTAL vacío o irreconocible, ";
                                    }
                                    i++;
                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos Guia de Transporte Forestal: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region VALTROZACAMPO
                        case "VALTROZACAMPO":
                            if (Datos.Columns.Count != 10)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Trozas en Campo");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[1].ToString().Trim(), Fila[2].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[0].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CODIGO_TROZA vacío o irreconocible, "; }
                                    if (Fila[6].ToString().Trim() == "" || !Double.TryParse(Fila[6].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_1 vacío o irreconocible, "; }
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo DAP_2 vacío o irreconocible, "; }
                                    if (Fila[8].ToString().Trim() == "" || !Double.TryParse(Fila[8].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo LC vacío o irreconocible, "; }

                                    if (Fila[3].ToString().Trim() != "17S" && Fila[3].ToString().Trim() != "18S" && Fila[3].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[4].ToString().Trim().Length == 6 || Fila[4].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[4].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[5].ToString().Trim().Length == 7 || Fila[5].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[5].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de troza en campo: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region VALMADEASERRADA
                        case "VALMADEASERRADA":
                            if (Datos.Columns.Count != 11)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Madera Aserrada en Campo");
                            }
                            else
                            {
                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[1].ToString().Trim(), Fila[2].ToString().Trim());
                                    oCampos.OBSERVACION = "";
                                    if (Fila[0].ToString().Trim() == "") { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CODIGO vacío o irreconocible, "; }
                                    if (Fila[3].ToString().Trim() == "" || !Int32.TryParse(Fila[3].ToString().Trim(), out iL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PIEZAS_PARTES vacío o irreconocible, "; }
                                    if (Fila[7].ToString().Trim() == "" || !Double.TryParse(Fila[7].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ESPESOR vacío o irreconocible, "; }
                                    if (Fila[8].ToString().Trim() == "" || !Double.TryParse(Fila[8].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ANCHO vacío o irreconocible, "; }
                                    if (Fila[9].ToString().Trim() == "" || !Double.TryParse(Fila[9].ToString().Trim(), out diL)) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo LARGO vacío o irreconocible, "; }

                                    if (Fila[4].ToString().Trim() != "17S" && Fila[4].ToString().Trim() != "18S" && Fila[4].ToString().Trim() != "19S")
                                    {
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Las Zonas deben ser 17S, 18S o 19S; ";
                                    }

                                    if (Fila[5].ToString().Trim().Length == 6 || Fila[5].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[5].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Este Incorrecta, ";

                                    if (Fila[6].ToString().Trim().Length == 7 || Fila[6].ToString().Trim() == "0")
                                    {
                                        if (!Int32.TryParse(Fila[6].ToString().Trim(), out iL))
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";
                                    }
                                    else oCampos.OBSERVACION = oCampos.OBSERVACION + "C. Norte Incorrecta, ";

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    i++;
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie Incorrecta, "; }
                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de madera aserrada en campo: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUCVERTMAY 
                        case "ISUCVERTMAY":
                            if (Datos.Columns.Count != 9)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Censo de Vertebrados");
                            }
                            else
                            {
                                var lstProcedencia = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "PROCEDENCIA_ESPECIE_EXSITU", "").Select(m => m.Text).ToList();
                                var lstIdentificacion = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "INDENTIFICACION_ESPECIE_EXSITU", "").Select(m => m.Text).ToList();
                                var lstSexo = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "ESPECIE_SEXO", "").Select(m => m.Text).ToList();
                                var lstGAmenaza = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "GRADO_AMENAZA", "").Select(m => m.Text).ToList();
                                var valor = "";

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    i++;
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie incorrecta (" + oCampos.DESCRIPCION + "), "; }

                                    valor = Fila[2].ToString().Trim(); //Procedencia
                                    if (!lstProcedencia.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PROCEDENCIA incorrecto (" + valor + "), ";

                                    valor = Fila[3].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo N_INDIVIDUOS vacío o irreconocible, ";

                                    valor = Fila[4].ToString().Trim(); //Tipo de identificación
                                    if (!lstIdentificacion.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo TIPO_IDENTIFICACION incorrecto (" + valor + "), ";

                                    valor = Fila[6].ToString().Trim(); //Sexo
                                    if (!lstSexo.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo SEXO incorrecto (" + valor + "), ";

                                    valor = Fila[7].ToString().Trim(); //Grado amenaza
                                    if (!lstGAmenaza.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo GRADO_AMENAZA incorrecto (" + valor + "), ";

                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de Censo de Vertebrados: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUCVERTMEN
                        case "ISUCVERTMEN":
                            if (Datos.Columns.Count != 6)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para Datos de Censo de Invertebrados");
                            }
                            else
                            {
                                var lstProcedencia = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "PROCEDENCIA_ESPECIE_EXSITU", "").Select(m => m.Text).ToList();
                                var lstGAmenaza = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "GRADO_AMENAZA", "").Select(m => m.Text).ToList();
                                var valor = "";

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    i++;
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie incorrecta (" + oCampos.DESCRIPCION + "), "; }

                                    valor = Fila[2].ToString().Trim(); //Procedencia
                                    if (!lstProcedencia.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PROCEDENCIA incorrecto (" + valor + "), ";

                                    valor = Fila[3].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo N_INDIVIDUOS vacío o irreconocible, ";

                                    valor = Fila[4].ToString().Trim(); //Grado amenaza
                                    if (!lstGAmenaza.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo GRADO_AMENAZA incorrecto (" + valor + "), ";

                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de Censo de Invertebrados: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region BALANCE_ING_EGR
                        case "BALANCE_ING_EGR":
                            if (Datos.Columns.Count != 21)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para el Balance de Ingreso y Egreso de Especímenes");
                            }
                            else
                            {
                                var lstMotivoIngreso = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "MOTIVO_INGRESO_EXSITU", "").Select(m => m.Text).ToList();
                                var lstMotivoEgreso = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "ESTADO_EGRESO_ESPECIE", "").Select(m => m.Text).ToList();
                                var valor = "";

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    i++;
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie incorrecta (" + oCampos.DESCRIPCION + "), "; }

                                    valor = Fila[2].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CENSO_INICIAL vacío o irreconocible, ";

                                    valor = Fila[3].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT__INGRESO vacío o irreconocible, ";

                                    valor = Fila[6].ToString().Trim();
                                    if (!lstMotivoIngreso.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo MOTIVO_INGRESO incorrecto (" + valor + "), ";

                                    valor = Fila[9].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_EGRESO vacío o irreconocible, ";

                                    valor = Fila[12].ToString().Trim();
                                    if (!lstMotivoEgreso.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo MOTIVO__EGRESO incorrecto (" + valor + "), ";

                                    valor = Fila[19].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo BALANCE_PREVIO vacío o irreconocible, ";

                                    valor = Fila[20].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CENSO_FINAL vacío o irreconocible, ";

                                    if (oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en el Balance de Ingreso y Egreso de Especímenes: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUNACIMIENTO
                        case "ISUNACIMIENTO":
                            if (Datos.Columns.Count != 21)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para los Nacimientos");
                            }
                            else
                            {
                                var lstSexo = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "ESPECIE_SEXO", "").Select(m => m.Text).ToList();
                                var valor = "";

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    i++;
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie incorrecta (" + oCampos.DESCRIPCION + "), "; }

                                    valor = Fila[3].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT__INGRESO vacío o irreconocible, ";

                                    valor = Fila[7].ToString().Trim();
                                    if (valor != "SÍ" && valor != "NO")
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo PROGRAMA_REPRODUCCION_INGRESO incorrecto (" + valor + "), ";

                                    valor = Fila[14].ToString().Trim();
                                    if (!lstSexo.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo SEXO__EGRESO incorrecto (" + valor + "), ";

                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de Nacimientos: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUEGRESO
                        case "ISUEGRESO":
                            if (Datos.Columns.Count != 21)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para los Egresos");
                            }
                            else
                            {
                                var lstSexo = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "ESPECIE_SEXO", "").Select(m => m.Text).ToList();
                                var lstMotivoEgreso = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "ESTADO_EGRESO_ESPECIE", "").Select(m => m.Text).ToList();
                                var valor = "";

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    i++;
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.DESCRIPCION = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    oCampos.OBSERVACION = "";

                                    oListBus = new ListBusqueda<Ent_BUSQUEDA>("DESCRIPCION", oCampos.DESCRIPCION, true);
                                    Item = combo.ListEspecies.FindIndex(oListBus.PredicateBus);
                                    if (Item == -1) { oCampos.OBSERVACION = oCampos.OBSERVACION + "Especie incorrecta (" + oCampos.DESCRIPCION + "), "; }

                                    valor = Fila[9].ToString().Trim();
                                    if (valor == "" || !Int32.TryParse(valor, out iL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo CANT_EGRESO vacío o irreconocible, ";

                                    valor = Fila[12].ToString().Trim();
                                    if (!lstMotivoEgreso.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo MOTIVO__EGRESO incorrecto (" + valor + "), ";

                                    if (valor == "MUERTE")
                                    {
                                        valor = Fila[16].ToString().Trim();
                                        if (valor != "SÍ" && valor != "NO")
                                            oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo NECROPSIA_EGRESO incorrecto (" + valor + "), ";
                                    }

                                    valor = Fila[14].ToString().Trim();
                                    if (!lstSexo.Contains(valor))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo SEXO__EGRESO incorrecto (" + valor + "), ";

                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de Egresos: ({0})", oListado.Count.ToString());
                            }
                            break;
                        #endregion
                        //migrado
                        #region ISUINFRAESTRUCTURA
                        case "ISUINFRAESTRUCTURA":
                            if (Datos.Columns.Count != 21)
                            {
                                throw new Exception("La plantilla seleccionada no es la correcta para registro de infraestructura");
                            }
                            else
                            {
                                var lstMaterial = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "AREA_EXITU_MATERIAL", "").Select(m => m.Text).ToList();
                                var lstCartel = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "AREA_EXITU_CARTEL", "").Select(m => m.Text).ToList();
                                var lstEquipo = oLogica.RegMostComboIndividualV3("COMBO_INDIVIDUAL", "AREA_EXITU_EQUIPO", "").Select(m => m.Text).ToList();
                                var valor = "";

                                foreach (DataRow Fila in Datos.Rows)
                                {
                                    i++;
                                    oCampos = new Ent_BUSQUEDA();
                                    oCampos.OBSERVACION = "";

                                    valor = Fila[1].ToString().Trim();
                                    if (valor == "" || !Double.TryParse(valor, out diL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo LARGO vacío o irreconocible, ";

                                    valor = Fila[2].ToString().Trim();
                                    if (valor == "" || !Double.TryParse(valor, out diL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ANCHO vacío o irreconocible, ";

                                    valor = Fila[3].ToString().Trim();
                                    if (valor == "" || !Double.TryParse(valor, out diL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo ALTURA vacío o irreconocible, ";

                                    valor = Fila[4].ToString().Trim();
                                    if (valor == "" || !Double.TryParse(valor, out diL))
                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo AREA vacío o irreconocible, ";

                                    List<string> lstMaterialSeleccionado = new List<string>();
                                    List<string> lstCartelSeleccionado = new List<string>();
                                    List<string> lstEquipoSeleccionado = new List<string>();

                                    for (int j = 5; j <= 20; j++)
                                    {
                                        valor = Fila[j].ToString().Trim();

                                        if (valor != "")
                                        {
                                            if (j >= 5 && j <= 9)
                                            {
                                                if (!lstMaterial.Contains(valor))
                                                    oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo MAT_CONS_" + (j - 4) + " incorrecto (" + valor + "), ";
                                                else
                                                {
                                                    if (lstMaterialSeleccionado.Contains(valor))
                                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo MAT_CONS_" + (j - 4) + " duplicado (" + valor + "), ";
                                                    else lstMaterialSeleccionado.Add(valor);
                                                }
                                            }
                                            if (j >= 10 && j <= 12)
                                            {
                                                if (!lstCartel.Contains(valor))
                                                    oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo TIENE_CARTEL_" + (j - 9) + " incorrecto (" + valor + "), ";
                                                else
                                                {
                                                    if (lstCartelSeleccionado.Contains(valor))
                                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo TIENE_CARTEL_" + (j - 4) + " duplicado (" + valor + "), ";
                                                    else lstCartelSeleccionado.Add(valor);
                                                }
                                            }
                                            if (j >= 13 && j <= 20)
                                            {
                                                if (!lstEquipo.Contains(valor))
                                                    oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo EQUI_ACCESORIOS_" + (j - 12) + " incorrecto (" + valor + "), ";
                                                else
                                                {
                                                    if (lstEquipoSeleccionado.Contains(valor))
                                                        oCampos.OBSERVACION = oCampos.OBSERVACION + "Campo EQUI_ACCESORIOS_" + (j - 4) + " duplicado (" + valor + "), ";
                                                    else lstEquipoSeleccionado.Add(valor);
                                                }
                                            }
                                        }
                                    }

                                    if (Item == -1 || oCampos.OBSERVACION.ToString().Trim() != "")
                                    {
                                        oCampos.Orden_Categoria = i;
                                        oListado.Add(oCampos);
                                    }
                                }
                                ltrerror = String.Format("N° de errores en los datos de Infraestructura: ({0})", oListado.Count.ToString());
                            }
                            break;
                            #endregion
                    }
                }
                else
                {
                    throw new Exception("Seleccione archivo");
                }

                var json = Json(new { data = oListado, success = true, msj = "", msj1 = ltrerror });
                json.MaxJsonLength = Int32.MaxValue;
                return json;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msj = ex.Message });
            }
        }
        #endregion

        //public ActionResult _cambiarPass()
        //{
        //    return PartialView();
        //}
        #region Modulo de ficalizacion Carlos Rios
        /// <summary>
        /// metodo para comunicarse con la bd de ORACLE
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _ManGrillaPaging_v3(ManGrillaViewModel dto)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();

            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = dto.tipoFormulario;
            if (dto.tipoFormulario == "AEXPEDIENTE_SITD")
            {
                dto.cboOpciones = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" } , new SelectListItem() { Text = "Pendiente", Value = "Pendiente" } , new SelectListItem() { Text = "Transferido", Value = "Transferido" },
                                                               new SelectListItem() { Text = "Anulado", Value = "Anulado" }};
                dto.cboOpciones1 = new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "Todos" } , new SelectListItem() { Text = "OD", Value = "OD" } , new SelectListItem() { Text = "DOC_REFERENCIA", Value = "DOC_REFERENCIA" },
                                                               new SelectListItem() { Text = "NUM_DOCUMENTO", Value = "NUM_DOCUMENTO" },new SelectListItem() { Text = "NUM_TRAMITE", Value = "NUM_TRAMITE" },new SelectListItem() { Text = "NUM_THABILITANTE", Value = "NUM_THABILITANTE" },
                                                                new SelectListItem() { Text = "RESOLUCION_POA", Value = "RESOLUCION_POA" }};
            }
            else
            {
                dto.cboOpciones = HelperSigo.LLenarCombos(exeBus.RegOpcionesCombo(paramsBus), "");
            }


            return PartialView(dto);
        }

        [HttpGet]
        public JsonResult GetListaGeneralPaging_v3(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            if (request.CustomSearchType1 != null && request.CustomSearchType1 != "")
                paramsBus.BusCriterio1 = request.CustomSearchType1;
            paramsBus.BusValor = request.CustomSearchValue;
            if (paramsBus.BusValor == "")
            {
                paramsBus.BusCriterio = "TODOS";
            }
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            if (request.Order.Length != 0)
            {
                //paramsBus.sort = request.Columns[request.Order[0].Column].Data + " " + request.Order[0].Dir;
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.RegMostrarListaPaging_v3(paramsBus, ref rowcount);

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

        #region THComportamiento
        public JsonResult GetTHComportamiento(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

          //  paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.BusCriterio1 = request.CustomSearchType1;

            paramsBus.pagesize = request.Length;
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

            lstResult = exeBus.RegMostrarTHCalificacion(paramsBus, ref rowcount);

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

        [HttpGet]
        public ActionResult _ActualizaCargoPersona(string asFormulario, string asCodPersona)
        {
            VM_Persona objPersona = new VM_Persona();
            Ent_Persona entP = new Ent_Persona();
            Log_Persona logP = new Log_Persona();

            entP.BusFormulario = "DIRECTORIO_UNICO";
            entP.BusCriterio = "TODOS";
            entP.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            entP = logP.RegMostCombo(entP);
            objPersona.ddlItemPN_DITipo = entP.ListCTipoDocIdentidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            objPersona.ddlITipoCargo = entP.ListCTipoCargo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            objPersona.ddlINivelAcademico = entP.ListCNivelAcademico.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            objPersona.ddlIEspecialidad = entP.ListCEspecialidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            var lstCategoria = entP.ListCCategoria.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstCategoria.Insert(0, new VM_Cbo { Value = "0000000", Text = "Seleccionar" });
            objPersona.ddlCategoria = lstCategoria;
            objPersona.ddlMencionRegencia = new List<VM_Cbo>();
            var lstEstado = entP.ListCEstado.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEstado.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            objPersona.ddlEstado = lstEstado;

            var lstAnio = new List<VM_Chk>();
            for (int i = DateTime.Now.Year; i >= 2016; i--)
            {
                lstAnio.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
            }
            objPersona.ddlAnio = lstAnio.Select(i => new VM_Cbo { Value = i.Value, Text = i.Text });

            entP = logP.RegMostrarListaItem(new Ent_Persona() { COD_PERSONA = asCodPersona });
            objPersona.codigoPersona = asCodPersona;

            ViewBag.hdfFormulario = asFormulario;
            ViewBag.hdfTipoPersona = entP.COD_TPERSONA;

            if (entP.COD_TPERSONA.Equals("N"))
            {
                objPersona.ddlItemPN_DITipoId = entP.COD_DIDENTIDAD;
                objPersona.txtItemPN_DINumero = entP.N_DOCUMENTO;
                objPersona.txtItemPN_DIRUC = entP.N_RUC;
                objPersona.txtItemPN_APaterno = entP.APE_PATERNO;
                objPersona.txtItemPN_AMaterno = entP.APE_MATERNO;
                objPersona.txtItemPN_Nombres = entP.NOMBRES;
            }
            else
            {
                objPersona.txtItemPJ_RUC = entP.N_RUC;
                objPersona.txtItemPJ_RSocial = entP.RAZON_SOCIAL;
            }

            objPersona.txtINumRegFfs = entP.NUM_REGISTRO_FFS;
            objPersona.txtINumRegProf = entP.NUM_REGISTRO_PROFESIONAL;
            objPersona.txtICargo = entP.CARGO;
            objPersona.txtINumColegiatura = entP.COLEGIATURA_NUM;
            objPersona.ddlINivelAcademicoId = entP.COD_NACADEMICO == "" ? "0000000" : entP.COD_NACADEMICO;
            objPersona.ddlIEspecialidadId = entP.COD_DPESPECIALIDAD == "" ? "0000000" : entP.COD_DPESPECIALIDAD;
            objPersona.ddlAnioId = entP.ANIO;
            objPersona.txtNroLicencia = entP.NROLICENCIA;
            objPersona.txtFecLicencia = entP.OTORGAMIENTO;
            objPersona.txtResolucion = entP.RESAPROBACION;
            objPersona.ddlCategoriaId = entP.COD_CATEGORIA == "" ? "0000000" : entP.COD_CATEGORIA;
            objPersona.txtCIP = entP.CIP;
            objPersona.ddlEstadoId = entP.ESTADO_REGENTE == "" ? "-" : entP.ESTADO_REGENTE;
            objPersona.txtOtro = entP.OTRO;

            foreach (var itemCargo in entP.ListTipoCargo)
            {
                objPersona.hdfITipoCargo += "," + itemCargo.COD_PTIPO;
            }

            foreach (var itemMencion in entP.ListMencion)
            {
                objPersona.hdfMencionRegencia += "," + itemMencion.COD_MENSION;
            }

            return PartialView(objPersona);
        }

        [HttpPost]
        public JsonResult _ActualizaCargoPersona(VM_Persona vm)
        {
            ListResult result = new ListResult();
            try
            {
                Log_GENEPERSONA oCLogPersona = new Log_GENEPERSONA();
                String coducuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                result = oCLogPersona.GrabarTipoCargo(coducuenta, vm);
            }
            catch (Exception)
            {
                result.success = false;
                result.msj = "Ocurrio un error en el registro, verifique los datos e intente de nuevo";

            }
            return Json(result);
        }
    }

    public class BinaryContentResult : ActionResult
    {
        public BinaryContentResult()
        { }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {

            context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.ContentType = ContentType;

            context.HttpContext.Response.AddHeader("content-disposition",

                                                   "attachment; filename=" + FileName);

            context.HttpContext.Response.BinaryWrite(Content);
            context.HttpContext.Response.End();
        }
    }


}