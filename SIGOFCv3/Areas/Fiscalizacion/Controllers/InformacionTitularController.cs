using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Fiscalizacion.Models.InformacionTitular;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformacionTitular;
using CEntidadIT = CapaEntidad.DOC.Ent_INFTIT;
using CLogica = CapaLogica.DOC.Log_INFTIT;
using CapaEntidad.DOC;
using SIGOFCv3.Models.DataTables;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class InformacionTitularController : Controller
    {
        public static CEntVM vmIT = new CEntVM();

        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA logB = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "INFORMACION_TITULAR";
            ViewBag.TituloFormulario = "Información Presentada por el Titular";
            ViewBag.AlertaInicial = _alertaIncial;
            ViewBag.ddlListOpciones = logB.RegMostComboIndividual_v3("INFORMACION_TITULAR", "");
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Información Titular");
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

        public ActionResult AddEdit(string asCodInfTitular = "", string asCodTipoIT = "", string asTextTipoIT = "")
        {
            try
            {
                CEntidadIT entIT = new CEntidadIT();
                CLogica logIT = new CLogica();

                vmIT.lblTituloCabecera = "Información Presentada por el Titular";
                vmIT.vmControlCalidad = new VM_ControlCalidad_2();
                entIT.BusFormulario = "GENERAL";
                entIT.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                entIT = logIT.RegMostCombo(entIT);
                vmIT.ddlOd = entIT.ListMComboOD.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                entIT.BusFormulario = "INFORMACION_TITULAR";
                entIT = logIT.RegMostCombo(entIT);
                vmIT.ddlTitular = entIT.ListMComboCategoria.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                entIT = logIT.RegMostrarComboTipoProfesional(entIT);
                vmIT.ddlTipoProfesional = entIT.ListTipoProfesional.Select(i => new VM_Cbo { Value = i.COD_PTIPO, Text = i.PERSONATIPO });

                entIT = logIT.RegMostrarComboTipoDescargo(entIT);
                vmIT.ddlDescargoTipo = entIT.ListTipoDescargo.Select(i => new VM_Cbo { Value = i.COD_INFTIT_DESCARGO_TIPO, Text = i.DESCRIPCION });

                if (String.IsNullOrEmpty(asCodInfTitular))
                {
                    vmIT.lblTituloEstado = "Nuevo Registro";
                    vmIT.vmControlCalidad.ddlIndicadorId = "0000000";
                    vmIT.hdfCodTipoInfTitular = asCodTipoIT;
                    vmIT.txtTipoInfTitular = "Información presentada por el titular - " + asTextTipoIT;

                    RegistroLimpiar();

                    vmIT.RegEstado = 1;
                }
                else
                {
                    RegistroLimpiar();

                    entIT = logIT.RegMostrarListaInfTitItem(new CEntidadIT() { COD_INFTIT = asCodInfTitular });
                    vmIT.lblTituloEstado = "Modificando Registro";
                    vmIT.hdfCodInfTitular = asCodInfTitular;
                    vmIT.hdfCodTipoInfTitular = entIT.COD_FCTIPO;

                    vmIT.hdfItemEstUbigeoLugarpresentacion = entIT.COD_UBIGEO;
                    vmIT.txtItemEstUbigeoLugarpresentacion = entIT.UBIGEO;
                    vmIT.txtTipoInfTitular = entIT.TIPO_FISCALIZA;

                    vmIT.hdfItemTprofesionalCodigo = entIT.COD_PERSONA;
                    vmIT.txtItemTprofesional = entIT.APELLIDOS_NOMBRES;
                    vmIT.txtItemEtiNContrato = entIT.NUMERO_INFTIT;
                    vmIT.txtFechaPresentacion = entIT.FECHA_PRESENTACION.ToString();
                    vmIT.txtFechaEmision = entIT.FECHA_EMISION.ToString();
                    vmIT.txtObservaciones = entIT.DESCRIPCION;
                    vmIT.ddlOdId = entIT.COD_OD_REGISTRO;

                    vmIT.hdfItemEstUbigeoCodigo = entIT.COD_UBIGEO_DESCARGO;
                    vmIT.txtItemEstUbigeo = entIT.UBIGEO_DESCARGO;
                    vmIT.txtDireccion = entIT.DIRECCION;
                    vmIT.txttelefono = entIT.TELEFONO;
                    vmIT.txtcorreo = entIT.CORREO_ELECTRONICO;
                    vmIT.ddlDescargoTipoId = (entIT.COD_INFTIT_DESCARGO_TIPO=="") ? "0000000" : entIT.COD_INFTIT_DESCARGO_TIPO;

                    vmIT.txtdescripciondescargo = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtfunpresentadoscautelar = entIT.FUNDAMENTOS_PRESENTADOS;

                    vmIT.txtfundamentosaudiencia = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtinspeccionoc = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtampliaciondescargo = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtrecursorecon = entIT.FUNDAMENTOS_PRESENTADOS;

                    vmIT.txtnumcuotas = entIT.NUMERO_CUOTAS.ToString();
                    vmIT.txtmontocuota = entIT.MONTO_CUOTA.ToString();
                    vmIT.txtfecinipago = entIT.FECHA_INICIO.ToString();
                    vmIT.txtfecfinpago = entIT.FECHA_FIN.ToString();

                    vmIT.txtrecursoapelacion = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtsolicitudfInfo = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtotros = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtFundQueja_Queja = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.chkNulidad_RecApe = (entIT.NULIDAD == null) ? false: (Boolean) entIT.NULIDAD;
                    vmIT.txtObservNul_RecApe = entIT.OBSERV_NULIDAD;
                    vmIT.txtObservMedidaCorrect = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtMotivoDesistimiento = entIT.FUNDAMENTOS_PRESENTADOS;
                    vmIT.txtObservActividad = entIT.FUNDAMENTOS_PRESENTADOS;

                    vmIT.txtObservSubsanacion = entIT.FUNDAMENTOS_PRESENTADOS;

                    vmIT.hdfItemNewUbigeoTHCodigo = entIT.COD_UBIGEO_DESCARGO;
                    vmIT.txtItemNewUbigeoTH = entIT.UBIGEO_DESCARGO;
                    vmIT.txtNewDireccionTH = entIT.DIRECCION;
                    vmIT.txtNewReferenciaTH = entIT.FUNDAMENTOS_PRESENTADOS;

                    vmIT.tbInforme = entIT.ListInformes;
                    vmIT.tbPersonaFirma = entIT.ListProfesionalFirma;
                    vmIT.tbEliTABLA = entIT.ListEliTABLA;

                    vmIT.chkEmitioCarta = (Boolean) entIT.IMPROCEDENCIA;
                    vmIT.txtNroCarta = entIT.DOCUMENTO_IMPROCEDENCIA;
                    vmIT.txtFechaCarta = entIT.FECHA_IMPROCEDENCIA.ToString();

                    vmIT.txtDomicilioProcesal = entIT.DOMICILIO_PROCESAL;
                    vmIT.chkAudienciaOral = (Boolean) entIT.AUDIENCIA_ORAL;
                    vmIT.ddlTitularId = entIT.COD_PARENTESCO;
                    vmIT.chkfirmaLegalizada = (Boolean) entIT.FIRMA_LEGALIZADA;
                    vmIT.chkApelarMedCaut = (Boolean) entIT.APELAR_MEDCAUT;

                    vmIT.vmControlCalidad.ddlIndicadorId = entIT.COD_ESTADO_DOC;
                    vmIT.vmControlCalidad.txtUsuarioRegistro = entIT.USUARIO_REGISTRO;
                    vmIT.vmControlCalidad.txtUsuarioControl = entIT.USUARIO_CONTROL;
                    vmIT.vmControlCalidad.chkObsSubsanada = (Boolean)entIT.OBSERV_SUBSANAR;
                    vmIT.vmControlCalidad.txtControlCalidadObservaciones = entIT.OBSERVACIONES_CONTROL.ToString();
                   
                    vmIT.RegEstado = 0;
                }

                initBusquedaModal(vmIT.hdfCodTipoInfTitular);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Información Titular");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmIT.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                return View(vmIT);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }

        }

        public void RegistroLimpiar()
        {
            vmIT.ddlOdId = "0000000";
            vmIT.hdfCodInfTitular = "";
            vmIT.hdfItemTprofesionalCodigo = "";
            vmIT.txtItemTprofesional = "";
            vmIT.ddlTitularId = "0000000";
            vmIT.txtFechaEmision = "";
            vmIT.txtFechaPresentacion = "";
            vmIT.hdfItemEstUbigeoLugarpresentacion = "";
            vmIT.txtItemEstUbigeoLugarpresentacion = "";
            vmIT.txtItemEtiNContrato = "";
            vmIT.txtDomicilioProcesal = "";
            vmIT.tbInforme = new List<CEntidadIT>();
            vmIT.tbPersonaFirma = new List<CEntidadIT>();
            vmIT.tbEliTABLA = new List<CEntidadIT>();
            vmIT.chkApelarMedCaut = false;
            vmIT.hdfItemOtraPersonafirma = "";
            vmIT.txtItemOtraPersonafirma = "";
            vmIT.ddlTipoProfesionalId = "";
            vmIT.hdfItemEstUbigeoCodigo = "";
            vmIT.txtItemEstUbigeo = "";
            vmIT.txtDireccion = "";
            vmIT.txttelefono = "";
            vmIT.txtcorreo = "";
            vmIT.ddlDescargoTipoId = "0000000";
            vmIT.chkfirmaLegalizada = false;
            vmIT.chkAudienciaOral = false;
            vmIT.txtdescripciondescargo = "";
            vmIT.txtrecursorecon = "";
            vmIT.txtrecursoapelacion = "";
            vmIT.chkNulidad_RecApe = false;
            vmIT.txtObservNul_RecApe = "";
            vmIT.txtfunpresentadoscautelar = "";
            vmIT.txtnumcuotas = "";
            vmIT.txtmontocuota = "";
            vmIT.txtfecinipago = "";
            vmIT.txtfecfinpago = "";
            vmIT.txtfundamentosaudiencia = "";
            vmIT.txtinspeccionoc = "";
            vmIT.txtampliaciondescargo = "";
            vmIT.txtsolicitudfInfo = "";
            vmIT.txtotros = "";
            vmIT.txtFundQueja_Queja = "";
            vmIT.txtObservMedidaCorrect = "";
            vmIT.txtObservActividad = "";
            vmIT.txtMotivoDesistimiento = "";
            vmIT.hdfItemNewUbigeoTHCodigo = "";
            vmIT.txtItemNewUbigeoTH = "";
            vmIT.txtNewDireccionTH = "";
            vmIT.txtNewReferenciaTH = "";
            vmIT.txtObservSubsanacion = "";
            vmIT.chkEmitioCarta = false;
            vmIT.txtNroCarta = "";
            vmIT.txtFechaCarta = "";
            vmIT.txtObservaciones = "";
    }

        public void initBusquedaModal(string tipocb)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            vmIT.sBusqueda = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo;

            switch (tipocb)
            {
                case "0000019"://Descargos 

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directorales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Inicio PAU";
                    vmIT.txtTituloDocumento = "DESCARGO DE RD INICIO PAU";

                    break;

                case "0000020"://Solicitud de Variacion de Medida Cautelar    

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directorales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Inicio PAU";
                    vmIT.txtTituloDocumento = "SOLICITUD DE VARIACION DE MEDIDAS CAUTELARES";

                    break;

                case "0000021"://Audiencia Oral

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directoriales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de Expedientes Administrativos / Resolucion Directoral";
                    vmIT.txtTituloDocumento = "SOLICITUD DE AUDIENCIA ORAL";

                    break;

                case "0000022"://Inspección Ocular   

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de Expedientes Administrativos";
                    vmIT.txtTituloDocumento = "SOLICITUD DE INSPECCION OCULAR";

                    break;

                case "0000023"://Ampliacón de Descargos   

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directorales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Inicio PAU";
                    vmIT.txtTituloDocumento = "AMPLIACION DE DESCARGO";

                    break;

                case "0000024"://Fraccionamiento de Multa  

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directorales";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Termino PAU / N° Expediente Administrativo";
                    vmIT.txtTituloDocumento = "FRACCIONAMIENTO DE MULTA";

                    break;

                case "0000025"://Recurso de Reconsideración 

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directoriales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Termino PAU";
                    vmIT.txtTituloDocumento = "RECURSO DE RECONSIDERACION";

                    break;

                case "0000026"://Recurso de Apelación

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directoriales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Termino PAU";
                    vmIT.txtTituloDocumento = "RECURSO DE APELACION";

                    break;

                case "0000027"://Solicitud de Información    

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informe Supervisión";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de Informes de Supervisión y Expedientes Administrativos";
                    vmIT.txtTituloDocumento = "SOLICITUD DE INFORMACION";

                    break;

                case "0000050"://Otros				

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de Expedientes Administrativos";
                    vmIT.txtTituloDocumento = "INFTIT_OTROSS";

                    break;

                case "0000081"://Queja 

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "Resoluciones Directoriales";
                    Combo.Text = "RD_NUMERO";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD";
                    vmIT.txtTituloDocumento = "RECURSO QUEJA";

                    break;

                case "0000082"://Informe de Medidas Correctivas 

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_TER_NUMERO";
                    Combo.Text = "Resoluciones de Término de PAU";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Término PAU";
                    vmIT.txtTituloDocumento = "INFORME MEDIDAS CORRECTIVAS";

                    break;

                case "0000083"://Informe de Actividades 

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "POAPM_TH_NUMERO";
                    Combo.Text = "Nro. Título Habilitante";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Seleccionar Título Habilitante - Documentos de Gestión";
                    vmIT.txtTituloDocumento = "INFORME ACTIVIDADES";

                    break;

                case "0000084"://Desistimiento de Apelación

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_TER_NUMERO";
                    Combo.Text = "Resoluciones de Término de PAU";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD Término PAU";
                    vmIT.txtTituloDocumento = "DESISTIMIENTO DE APELACION";

                    break;

                case "0000085"://Cambio de domicilio procesal

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "TH_NUMERO";
                    Combo.Text = "Nro. Título Habilitante";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de Título Habilitante";
                    vmIT.txtTituloDocumento = "CAMBIO DOMICILIO PROCESAL";

                    break;

                case "0000086"://Desistimiento de Apelación

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directoriales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD";
                    vmIT.txtTituloDocumento = "INFORME DE SUBSANACION";

                    break;

                case "0000112"://Descargos - Etapa Resolutiva

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Informes Legales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de Informe Legal";
                    vmIT.txtTituloDocumento = "INFORME LEGAL";

                    break;

                case "0000124"://SOLICITUD DE COMPENSACION DE MULTA POR CONSERVACION DE BOSQUES

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directoriales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD";
                    vmIT.txtTituloDocumento = "COMPENSACION DE MULTA POR CONSERVACION";

                    break;

                case "0000125"://SOLICITUD DE COMPENSACION DE MULTA POR RESTAURACION DE AREAS DEGRADADAS

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Resoluciones Directoriales";
                    listCombo.Add(Combo);

                    vmIT.lbldocumento = "Lista de RD";
                    vmIT.txtTituloDocumento = "COMPENSACION DE MULTA POR RESTAURACION DE SUBSANACION";

                    break;
            }

            vmIT.txtTituloModal = "Nuevo Registro";
            vmIT.sBusqueda = listCombo;
        }

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            CEntidadIT paramsBus = new CEntidadIT();
            CEntidadIT result;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            result = exeBus.RegMostrarINFTIT_BuscarDatos(paramsBus);

            var jsonResult = Json(new
            {
                data = result.ListBusqueda.ToArray(),
                draw = request.Draw,
                recordsTotal = result.v_row_index,
                recordsFiltered = result.v_row_index,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion

        [HttpPost]
        public JsonResult Grabar(CEntVM obj)
        {
            try
            {
                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();

                if (obj.tbInforme != null)
                {
                    CEntidadIT entIT = new CEntidadIT();
                    CLogica logIT = new CLogica();

                    entIT.COD_FCTIPO = obj.hdfCodTipoInfTitular;
                    entIT.COD_UCUENTA = codCuenta;
                    entIT.COD_PERSONA = obj.hdfItemTprofesionalCodigo;
                    entIT.COD_INFTIT = obj.hdfCodInfTitular;
                    entIT.COD_INFTIT_AUXILIAR = "";
                    entIT.DESCRIPCION = obj.txtObservaciones;
                    entIT.NUMERO_INFTIT = obj.txtItemEtiNContrato.Trim();
                    entIT.COD_UBIGEO = obj.hdfItemEstUbigeoLugarpresentacion;
                    entIT.FECHA_PRESENTACION = obj.txtFechaPresentacion;

                    //Variables de control de calidad
                    entIT.COD_ESTADO_DOC = obj.vmControlCalidad.ddlIndicadorId;
                    entIT.OBSERVACIONES_CONTROL = obj.vmControlCalidad.txtControlCalidadObservaciones;
                    entIT.OBSERV_SUBSANAR = obj.vmControlCalidad.chkObsSubsanada;
                    entIT.USUARIO_CONTROL = null;
                    entIT.USUARIO_REGISTRO = null;

                    entIT.COD_OD_REGISTRO = obj.ddlOdId;
                    entIT.OUTPUTPARAM01 = "";
                    entIT.RegEstado = obj.RegEstado;
                    entIT.TIPO_FISCALIZA = null;
                    entIT.UBIGEO_DESCARGO = null;
                    entIT.APELLIDOS_NOMBRES = null;
                    entIT.UBIGEO = null;
                    entIT.COD_PARENTESCO = obj.ddlTitularId;
                    entIT.DOMICILIO_PROCESAL = obj.txtDomicilioProcesal;

                    switch (entIT.COD_FCTIPO)
                    {
                        case "0000019":
                        case "0000112":
                            entIT.TELEFONO = obj.txttelefono;
                            entIT.COD_UBIGEO_DESCARGO = obj.hdfItemEstUbigeoCodigo;
                            entIT.DIRECCION = obj.txtDireccion;
                            entIT.CORREO_ELECTRONICO = obj.txtcorreo;
                            entIT.COD_INFTIT_DESCARGO_TIPO = obj.ddlDescargoTipoId;
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtdescripciondescargo;
                            entIT.AUDIENCIA_ORAL = obj.chkAudienciaOral;
                            entIT.FIRMA_LEGALIZADA = obj.chkfirmaLegalizada;
                            entIT.APELAR_MEDCAUT = obj.chkApelarMedCaut;  
                            break;

                        case "0000025":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtrecursorecon;
                            entIT.IMPROCEDENCIA = obj.chkEmitioCarta;
                            entIT.DOCUMENTO_IMPROCEDENCIA = obj.txtNroCarta.Trim();
                            entIT.FECHA_IMPROCEDENCIA = obj.txtFechaCarta;
                            break;

                        case "0000026":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtrecursoapelacion;
                            entIT.NULIDAD = obj.chkNulidad_RecApe;
                            entIT.OBSERV_NULIDAD = obj.txtObservNul_RecApe;
                            entIT.IMPROCEDENCIA = obj.chkEmitioCarta;
                            entIT.DOCUMENTO_IMPROCEDENCIA = obj.txtNroCarta.Trim();
                            entIT.FECHA_IMPROCEDENCIA = obj.txtFechaCarta;
                            break;

                        case "0000020":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtfunpresentadoscautelar;
                            break;

                        case "0000021":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtfundamentosaudiencia;
                            break;

                        case "0000024":
                            entIT.COD_INFTIT = obj.hdfCodInfTitular;
                            entIT.NUMERO_CUOTAS = int.Parse(obj.txtnumcuotas);
                            entIT.MONTO_CUOTA = decimal.Parse(obj.txtmontocuota);
                            entIT.FECHA_INICIO = obj.txtfecinipago;
                            entIT.FECHA_FIN = obj.txtfecfinpago;
                            break;

                        case "0000022":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtinspeccionoc;
                            break;

                        case "0000023":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtampliaciondescargo;
                            break;

                        case "0000027":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtsolicitudfInfo;
                            break;

                        case "0000050":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtotros;
                            break;

                        case "0000081":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtFundQueja_Queja;
                            break;

                        case "0000082":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtObservMedidaCorrect;
                            entIT.FECHA_EMISION = obj.txtFechaEmision;
                            break;

                        case "0000083":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtObservActividad;
                            break;

                        case "0000084":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtMotivoDesistimiento;
                            break;

                        case "0000085":
                            entIT.COD_UBIGEO_DESCARGO = obj.hdfItemNewUbigeoTHCodigo;
                            entIT.DIRECCION = obj.txtNewDireccionTH;
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtNewReferenciaTH;
                            break;

                        case "0000086":
                            entIT.FUNDAMENTOS_PRESENTADOS = obj.txtObservSubsanacion;
                            break;
                    }

                    entIT.ListInformes = obj.tbInforme;
                    entIT.ListProfesionalFirma = obj.tbPersonaFirma;

                    if (obj.tbEliminaInforme != null)
                    {
                        for (int j = 0; j < obj.tbEliminaInforme.Count; j++)
                        {
                            var ob = obj.tbEliminaInforme[j];
                            vmIT.tbEliTABLA.Add(ob);
                        }
                    }

                    if (obj.tbEliminaPersona != null)
                    {
                        for (int j = 0; j < obj.tbEliminaPersona.Count; j++)
                        {
                            var ob = obj.tbEliminaPersona[j];
                            vmIT.tbEliTABLA.Add(ob);
                        }
                    }

                    entIT.ListEliTABLA = vmIT.tbEliTABLA;

                    var estado_final = logIT.RegGrabaInfTitular(entIT);

                    if (estado_final != "0" && estado_final != "1")
                    {
                        RegistroLimpiar();
                        result.AddResultado("El Registro se Guardo Correctamente", true);
                    }
                    else result.AddResultado("Error en la información", false);
                }
                else
                {
                    result.AddResultado("Ingresar el Informe de Supervisión o el Expediente", false);
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}