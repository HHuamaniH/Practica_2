using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using CapaLogica.GENE;
using SIGOFCv3.Areas.THabilitante.Models;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Reportes.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_BUSQUEDA;
using CLogica = CapaLogica.DOC.Log_BUSQUEDA;
using CLogPersona = CapaLogica.DOC.Log_GENEPERSONA;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ControlesController : Controller
    {
        CLogPersona oCLogPersona = new CLogPersona();
        #region "ActionResult"
        [HttpPost]
        public ActionResult _ManGrilla(ManGrillaViewModel dto)
        {
            Log_THABILITANTE logThabilitante = new Log_THABILITANTE();
            ManGrillaViewModel manGrilla = new ManGrillaViewModel();
            manGrilla.idModulo = dto.idModulo;
            manGrilla.idMenu = dto.idMenu;
            manGrilla.titleMenu = dto.titleMenu;
            manGrilla.tipoFrmulario = dto.tipoFrmulario;//logThabilitante.ObtenerTipoVista(dto.idModulo, dto.idMenu);
            manGrilla.busFormulario = dto.busFormulario;//manGrilla.tipoFrmulario;
            manGrilla.busCriterio = dto.busCriterio;//"TODOS";            
            manGrilla.busModuloConsulta = dto.busModuloConsulta;
            //ViewBag.Title = titleMenu;
            //cargando combo
            CEntidad oCampos = new CEntidad();
            List<CEntidad> ListOpcionesBusqueda = new List<CEntidad>();
            oCampos.BusFormulario = "MANGRILLA";
            oCampos.BusCriterio = manGrilla.tipoFrmulario;
            oCampos.TIPO = manGrilla.busModuloConsulta;
            CLogica oCLogica = new CLogica();
            ListOpcionesBusqueda = oCLogica.RegOpcionesCombo(oCampos);
            manGrilla.cboOpciones = HelperSigo.LLenarCombos(ListOpcionesBusqueda, "");
            ViewBag.hdfFormulario = manGrilla.tipoFrmulario;
            return PartialView(manGrilla);
        }
        //modal de opciones de modalidad
        public ActionResult _ManModalidad(string busFormulario, string hdfTipoFormulario)
        {
            Ent_THABILITANTE oCampos = new Ent_THABILITANTE();
            Log_THABILITANTE oCLogica = new Log_THABILITANTE();
            oCampos.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            oCampos.BusFormulario = busFormulario;
            oCampos = oCLogica.RegMostCombo(oCampos);
            ManGrillaViewModel latManModalidad = new ManGrillaViewModel();
            latManModalidad.listMComboModalidad = oCampos.ListMComboModalidad;
            latManModalidad.hdfTipoFormulario = hdfTipoFormulario;
            latManModalidad.chkManConsolidado = false;
            return PartialView(latManModalidad);
        }
        public ActionResult _VPCKEDITOR(string formulario, string codigo)
        {
            VM_ControlCalidad vm = new VM_ControlCalidad();
            // ViewBag.valCKEDITOR = textCkEDITOR;
            switch (formulario)
            {
                case "PLAN_GENERAL_MANEJO_FORESTAL":
                case "PLAN_MANEJO_FORESTAL_INTERMEDIO":
                case "PLAN_MANEJO":
                case "PASPEQ_PLAN_TRABAJO":
                    Log_PLAN_MANEJO oCLogica = new Log_PLAN_MANEJO();
                    vm = oCLogica.LogObtenerControlCalidadV3(formulario, codigo);
                    break;
            }
            return PartialView(vm);
        }
        public ActionResult _THabilitante(string hdfFormulario, string idModal)
        {

            Log_THABILITANTE oCLogica = new Log_THABILITANTE();
            ManGrillaViewModel latManModalidad = new ManGrillaViewModel();
            latManModalidad.busFormulario = hdfFormulario;
            ViewBag.idModal = idModal;
            latManModalidad.hdfTipoFormulario = hdfFormulario;
            if (hdfFormulario == "POA" || hdfFormulario == "DEMA" || hdfFormulario == "PMFI")
            {
                latManModalidad.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "GRI_TH_NUMERO", Text = "N° T. Habilitante" }, new SelectListItem { Value = "GRI_TH_TITULAR", Text = "Titular" } };
            }
            else if (hdfFormulario == "TITULO_HABILITANTE")
            {
                latManModalidad.cboOpciones = new List<SelectListItem>() { new SelectListItem { Value = "TH_NUMERO", Text = "N° Título Habilitante" }, new SelectListItem { Value = "TH_TITULAR", Text = "Titular" } };
            }


            return PartialView(latManModalidad);
        }
        [HttpPost]
        public ActionResult _BuscarPersona(ManGrillaViewModel view)
        {

            return PartialView(view);
        }
        //[HttpGet]
        //public JsonResult _BuscarPersona(string valor, string TVentana, string ddlItemBuscar_Criterio)
        //{

        //    CEntPersona oCampos = new CEntPersona();
        //    switch (TVentana)
        //    {
        //        //Consultor
        //        case "C":
        //            oCampos.COD_PTIPO = "0000003";
        //            break;
        //        //Recomienda Aprobacion  | Técnico Ocular
        //        case "RA":
        //        case "TO":
        //        case "AO":
        //            oCampos.COD_PTIPO = "0000004|0000005";
        //            break;
        //        //Funcionario
        //        case "FA":
        //        case "FS":
        //            oCampos.COD_PTIPO = "0000006";
        //            break;
        //        //Consultor
        //        case "RP":
        //            oCampos.COD_PTIPO = "0000003";
        //            break;
        //        default: break;
        //    }

        //    oCampos.BusCriterio = ddlItemBuscar_Criterio;
        //    oCampos.BusValor = valor;
        //    var data = oCLogPersona.RegPersonaBuscarV3(oCampos);

        //    //CODIGO,DESCRIPCION, N_DOCUMENTO, CARGO, NUM_REGISTRO_FFS, NUM_REGISTRO_PROFESIONAL            
        //    int i = 1;
        //    var lstMin = from cust in data
        //                 select new
        //                 {
        //                     NRO = i++,
        //                     CODIGO = cust.CODIGO,
        //                     DESCRIPCION = cust.DESCRIPCION,
        //                     N_DOCUMENTO = cust.N_DOCUMENTO,
        //                     CARGO = cust.CARGO,
        //                     NUM_REGISTRO_FFS = cust.NUM_REGISTRO_FFS,
        //                     NUM_REGISTRO_PROFESIONAL = cust.NUM_REGISTRO_PROFESIONAL
        //                 };            

        //    var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
        //    jsonResult.MaxJsonLength = int.MaxValue;
        //    return jsonResult;
        //}
        #endregion
        #region "JsonResult"
        [HttpGet]
        public JsonResult listarBusqueda(String formulario, String criterio, String valor)
        {

            List<String[]> retorno = new List<String[]>();

            try
            {
                Log_THABILITANTE logThabilitante = new Log_THABILITANTE();
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
                retorno = logThabilitante.ListarTHabilitante(formulario, criterio, valor, auditoria);
                return Json(new { data = retorno, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false }, JsonRequestBehavior.AllowGet);
            }

        }
        //busCriterio tendra por ejemplo valor de TITULO_HABILITANTE
        [HttpGet]
        public JsonResult llenarCombo(string busCriterio, string moduloConsulta = "")
        {

            CEntidad oCampos = new CEntidad();
            List<CEntidad> ListOpcionesBusqueda = new List<CEntidad>();
            oCampos.BusFormulario = "MANGRILLA";
            oCampos.BusCriterio = busCriterio;
            oCampos.TIPO = moduloConsulta;
            CLogica oCLogica = new CLogica();
            ListOpcionesBusqueda = oCLogica.RegOpcionesCombo(oCampos);
            return Json(HelperSigo.LLenarCombos(ListOpcionesBusqueda, ""), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult buscarTHabilitante(string hdfFormulario, string busCriterio, string busValor)
        {
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.BusFormulario = hdfFormulario;
                oCampos.BusCriterio = busCriterio;
                oCampos.BusValor = busValor;
                CLogica oCLogica = new CLogica();
                var resultado = oCLogica.RegMostrarLista(oCampos);

                return Json(new { success = true, msj = "", r = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
        #endregion

        #region "Ubigeo"
        [HttpPost]
        public ActionResult _Ubigeo(string formOrigen, string controlOrigen)
        {
            ViewBag.ubFormularioOrigen = formOrigen;
            ViewBag.ubControlOrigen = controlOrigen;
            return PartialView();
        }
        public string GetListUbigeoTodo()
        {
            Log_UBIGEO objLogUbigeo = new Log_UBIGEO();
            string listaTotalUbigeo = objLogUbigeo.RegMostrarUbigeoV3();
            return listaTotalUbigeo;
        }
        #endregion
        #region "persona natural- Juridica"
        [HttpPost]
        public ActionResult _Persona(string tipoPersona = "", string formOrigen = "", string controlOrigen = "", string codigoPersona = "", string regEstado = "", string tVentana = "", string p_Tipo = "")
        {
            VM_Persona objPersona;
            Log_THABILITANTE objLog = new Log_THABILITANTE();
            objPersona = objLog.iniciarRegistroPeronaNJ(codigoPersona, (ModelSession.GetSession())[0].COD_UCUENTA, tipoPersona, p_Tipo);
            objPersona.tipo = tipoPersona;
            objPersona.formOrigen = formOrigen;
            objPersona.controlOrigen = controlOrigen;
            objPersona.regEstado = regEstado;
            objPersona.tVentana = tVentana;
            objPersona.COD_PTIPO = p_Tipo;
            return PartialView(objPersona);
        }
        //[HttpPost]
        //public JsonResult buscarPersonaNJ(string busCriterio, string busValor)
        //{
        //    ListResult result = new ListResult();

        //    try
        //    {
        //        List<string> persona = new List<string>();

        //        if (busCriterio == "DNI")
        //        {
        //            pideOSF_Reniec.ReniecServiceClient wsReniec = new pideOSF_Reniec.ReniecServiceClient();
        //            pideOSF_Reniec.PersonaRequest paramsReniec = new pideOSF_Reniec.PersonaRequest();
        //            paramsReniec.Documento = busValor;
        //            pideOSF_Reniec.ConsultaInfoRequest infoReniec = new pideOSF_Reniec.ConsultaInfoRequest();
        //            infoReniec.App = "SIGOsfc v3";
        //            infoReniec.IPTerminal = Request.UserHostAddress;
        //            infoReniec.UserName = (ModelSession.GetSession())[0].USUARIO_LOGIN;
        //            pideOSF_Reniec.PersonaResponse resultReniec = new pideOSF_Reniec.PersonaResponse();

        //            resultReniec = wsReniec.ConsultaDatosPersonaPorDNI(paramsReniec, infoReniec);
        //            persona = new List<string>() { "", "0000001", resultReniec.ApePaterno, resultReniec.ApeMaterno, resultReniec.Nombres, busValor, "", "-", resultReniec.Ubigeo.Replace("/", " - "), resultReniec.Direccion };
        //        }
        //        else if (busCriterio=="RUC")
        //        {
        //            pideOSF_Sunat.SunatServiceClient wsSunat = new pideOSF_Sunat.SunatServiceClient();
        //            pideOSF_Sunat.PersonaRequest paramsSunat = new pideOSF_Sunat.PersonaRequest();
        //            paramsSunat.Ruc = busValor;
        //            pideOSF_Sunat.ConsultaInfoRequest infoSunat = new pideOSF_Sunat.ConsultaInfoRequest();
        //            infoSunat.App = "SIGOsfc v3";
        //            infoSunat.IPTerminal = Request.UserHostAddress;
        //            infoSunat.UserName = (ModelSession.GetSession())[0].USUARIO_LOGIN;
        //            pideOSF_Sunat.DatosRucResponse resultSunat = new pideOSF_Sunat.DatosRucResponse();

        //            resultSunat = wsSunat.ConsultaRuc(paramsSunat, infoSunat);
        //            string ubigeoText = (resultSunat.Departamento + " - " + resultSunat.Provincia + " - " + resultSunat.Distrito).ToUpper();
        //            persona = new List<string>() { resultSunat.RazonSocial, busValor, "-", ubigeoText, resultSunat.DomicilioLegal };
        //        }

        //        result.AddResultado("Registro encontrado", true, persona);
        //    }
        //    catch (EndpointNotFoundException enf) { throw new Exception(enf.Message); }
        //    catch (Exception ex) { result.success = false; result.msj = ex.Message; }

        //    return Json(result); 
        //}
        [HttpGet]
        public ActionResult _BuscarPersonaGeneral(string formOrigen, string controlOrigen, string titulo)
        {
            ViewBag.fFormOrigen = formOrigen;
            ViewBag.fControlOrigen = controlOrigen;
            ViewBag.fTitulo = titulo;
            return PartialView();
        }
        //[HttpGet]
        //public JsonResult buscarPersonaGeneral(string busCriterio,string busValor, string cod_pTipo="")
        //{  //( 0 ) Registros Encontrados

        //    try
        //    {
        //        Log_GENEPERSONA logPersona = new Log_GENEPERSONA();
        //        List<Ent_GENEPERSONA> consulta = new List<CEntPersona>();
        //        consulta = logPersona.buscarFuncionriov3(cod_pTipo, busCriterio, busValor);
        //        int i = 1;
        //        var result = from c in consulta select new { cod = c.CODIGO, desc = c.DESCRIPCION,nd=c.N_DOCUMENTO,t=c.TIPO_PERSONA, ind = i++ };
        //        var jsonResult=Json(new { data = result,s=true, e = "" }, JsonRequestBehavior.AllowGet);
        //        jsonResult.MaxJsonLength = int.MaxValue;
        //        return jsonResult;

        //    }
        //    catch(Exception ex)
        //    {
        //        return Json(new { data = "", s = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }

        //}
        [HttpPost]
        public JsonResult registrarPersona(VM_Persona _persona)
        {
            Log_GENEPERSONA logPersona = new Log_GENEPERSONA();
            return Json(logPersona.registrarPersona(_persona));
        }
        #endregion

        #region "Exportar Excel"
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadListadoManGrilla(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla/Reg_Usu"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpPost]
        public JsonResult ExportarExcelListadoManGrilla(string busFormulario)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            var result = ReporteManGrilla.GenerarReporteManGrilla(busFormulario, codCuenta);
            return Json(result);
        }
        #endregion

        #region "Auditoria"
        public void regAccionManGrilla()
        {
            String direccionIP = "";
            String strHostName = System.Net.Dns.GetHostName();
            System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            direccionIP = Convert.ToString(ipEntry.AddressList[ipEntry.AddressList.Length - 1]);
            String IPAdd = "";
            IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(IPAdd)) { IPAdd = Request.ServerVariables["REMOTE_ADDR"]; }
        }
        #endregion


    }
}