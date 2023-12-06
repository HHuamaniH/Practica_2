using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Fiscalizacion.Models.InformeFundamentado;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformeFundamentado;
using CEntidadIF = CapaEntidad.DOC.Ent_INFFUN;
using CLogica = CapaLogica.DOC.Log_INFFUN;
using System.Linq;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
using System.Globalization;
using CapaEntidad.Documento;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class InformeFundamentadoController : Controller
    {
        public static CEntVM vmIF = new CEntVM();

        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "INFORME_FUNDAMENTADO";
            ViewBag.TituloFormulario = "Solicitud de FEMAs";
            ViewBag.AlertaInicial = _alertaIncial;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informe Fundamentado");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        public ActionResult AddEdit(string asCodInfFundamentado = "")
        {
            try
            {
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();

                vmIF.lblTituloCabecera = "Informe Fundamentado";
                vmIF.vmControlCalidad = new VM_ControlCalidad_2();
                entIF.BusFormulario = "GENERAL";
                entIF.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                entIF = logIF.RegMostCombo(entIF);
                vmIF.ddlOd = entIF.ListMComboOD.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                vmIF.ddlTipoSolicitud = entIF.ListTipoSolicitud.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmIF.ddlTipoSolicitudId = entIF.ListTipoSolicitud.ElementAt(0).CODIGO;

                vmIF.ddlVencimientoPlazoLegal = entIF.ListVencimientoPlazoLegal.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmIF.ddlVencimientoPlazoLegalId = entIF.ListVencimientoPlazoLegal.ElementAt(0).CODIGO;

                vmIF.ddlEstadoSolicitudFema = entIF.ListEstadoSolicitudFema.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmIF.ddlEstadoSolicitudFemaId = entIF.ListEstadoSolicitudFema.ElementAt(0).CODIGO;

                entIF = logIF.RegMostrarComboEntidad(entIF);
                vmIF.ddlEntidad = entIF.ListarEntidades.Select(i => new VM_Cbo { Value = i.COD_SENTIDAD, Text = i.DESCRIPCION_ENTIDAD });
                vmIF.ddlEntidadId = entIF.ListarEntidades.ElementAt(0).COD_SENTIDAD;
                entIF.COD_INFFUN_ENTIDADES = vmIF.ddlEntidadId;
                entIF = logIF.RegMostrarComboSubEntidad(entIF);
                vmIF.ddlSubEntidad = entIF.ListarEntidades.Select(i => new VM_Cbo { Value = i.COD_SENTIDAD, Text = i.DESCRIPCION_SUBENTIDAD });
                vmIF.ddlSubEntidadId = entIF.ListarEntidades.ElementAt(0).COD_SENTIDAD;
                vmIF.ddlProveidor = new List<VM_Cbo>();

                this.initBusquedaModal();

                if (String.IsNullOrEmpty(asCodInfFundamentado))
                {
                    vmIF.lblTituloEstado = "Nuevo Registro";

                    vmIF.vmControlCalidad.ddlIndicadorId = "0000000";
                    vmIF.hdfCodTipoInfFundamentado = "0000049";
                    vmIF.txtTipoInfFundamentado = "Informes fundamentados - Informes fundamentados";
                    vmIF.ddlOdId = null;
                    vmIF.dtpFechaFundamentado = null;
                    vmIF.txtNumInfFundamentado = null;
                    vmIF.txtConclusiones = null;
                    vmIF.txtObservaciones = null;
                    //vmIF.ddlEstadoSolicitudFema = new List<VM_Cbo>();
                    vmIF.listaProfesionales = new List<CEntidadIF>();
                    vmIF.tbInforme = new List<CEntidadIF>();
                    vmIF.listaEntidades = new List<CEntidadIF>();
                    vmIF.tbEliTABLA = new List<CEntidadIF>();
                    vmIF.RegEstado = 1;
                    vmIF.txtRegistro = null;
                    vmIF.dtpFechaIngresoSolicitud = null;
                    vmIF.txtNumeroOficioSolicitud = null;
                    vmIF.txtcarpetafiscal = null;
                    vmIF.txtDetalle = null;
                    vmIF.ddlTipoSolicitudId = null;
                    vmIF.ddlVencimientoPlazoLegalId = null;
                    vmIF.chkEmitirInforme = false;
                    vmIF.dtpfechaFirmezaPAU = null;
                    vmIF.txtNumeroOficio1 = null;
                    vmIF.dtpFechaEmision2 = null;
                    vmIF.txtNumeroInformeFundamentado = null;
                    vmIF.chkEmitirOficio = false;
                    vmIF.txtNumeroOficio2 = null;
                    vmIF.dtpfechaOficio2 = null;
                    vmIF.txtObservacionesOficio = null;
                    vmIF.chkEmitirOficioPau = false;
                    vmIF.txtNumeroOficio2 = null;
                    vmIF.dtpfechaOficio2 = null;
                    vmIF.txtObservacionesPau = null;
                    vmIF.chkNotificacion = false;
                    vmIF.dtpFechaNotificacion = null;
                    vmIF.txtAnotaciones = null;
                    vmIF.hdfItemEstUbigeoCodigo = null;
                    vmIF.fItemEstUbigeoCodigo = null;
                    vmIF.hdtxtTitularTipo = null;
                    vmIF.txtTitularTipo = null;
                    vmIF.dtpfechaOficio1 = null;
                    vmIF.txtNumeroOficioPau = null;
                    vmIF.dtpFechaEmisionPau = null;
                    vmIF.cboCodProveidoArch = null;
                }
                else
                {
                    entIF = logIF.RegMostrarINFFUNItem(new CEntidadIF() { COD_INFFUN = asCodInfFundamentado });
                    vmIF.lblTituloEstado = "Modificando Registro";
                    vmIF.hdfCodInfFundamentado = asCodInfFundamentado;
                    vmIF.ddlEstadoSolicitudFemaId = entIF.COD_ESTADO_SOLICITUD;
                    vmIF.vmControlCalidad.ddlIndicadorId = entIF.COD_ESTADO_DOC;
                    vmIF.vmControlCalidad.txtUsuarioRegistro = entIF.USUARIO_REGISTRO;
                    vmIF.vmControlCalidad.txtUsuarioControl = entIF.USUARIO_CONTROL;
                    vmIF.vmControlCalidad.chkObsSubsanada = (bool)entIF.OBSERV_SUBSANAR;
                    vmIF.vmControlCalidad.txtControlCalidadObservaciones = entIF.OBSERVACIONES_CONTROL.ToString();
                    vmIF.ddlOdId = entIF.COD_OD_REGISTRO;
                    vmIF.hdfCodTipoInfFundamentado = entIF.COD_FCTIPO;
                    vmIF.txtTipoInfFundamentado = entIF.TIPO_FISCALIZA;

                    vmIF.dtpFechaFundamentado = (entIF.FECHA_EMISION == null || entIF.FECHA_EMISION.ToString().Trim() == "") ? null : entIF.FECHA_EMISION?.ToString();
                    vmIF.txtNumInfFundamentado = entIF.NUMERO_INFORME;
                    vmIF.listaProfesionales = entIF.ListProfesionales;
                    vmIF.tbInforme = entIF.ListInformes;
                    vmIF.listaEntidades = entIF.ListarEntidades;
                    vmIF.txtConclusiones = entIF.CONCLUSIONES;
                    vmIF.txtObservaciones = entIF.DESCRIPCION;
                    vmIF.tbEliTABLA = new List<CEntidadIF>();
                    vmIF.txtRegistro = entIF.NUMERO_TRAMITE;

                    vmIF.dtpFechaIngresoSolicitud = (entIF.FECHA_TRAMITE == null || entIF.FECHA_TRAMITE.ToString().Trim() == "") ? null : entIF.FECHA_TRAMITE?.ToString();
                    vmIF.txtNumeroOficioSolicitud = entIF.NUMERO_SOLICITUD;
                    vmIF.txtcarpetafiscal = entIF.CARPETA_FISCAL;
                    vmIF.txtDetalle = entIF.GLOSA;
                    vmIF.ddlTipoSolicitudId = entIF.COD_TIPO_SOLICITUD;
                    vmIF.ddlVencimientoPlazoLegalId = entIF.COD_VEN_LEGAL;

                    vmIF.chkEmitirInforme = (entIF.FLAG_INFFUN_EMITIDO == 1 ? true : false);
                    vmIF.dtpfechaFirmezaPAU = (entIF.FECHA_FIRMEZA == null || entIF.FECHA_FIRMEZA.ToString().Trim() == "") ? null : entIF.FECHA_FIRMEZA?.ToString();

                    vmIF.txtNumeroOficio1 = entIF.NUMERO_OFICIO1;

                    vmIF.dtpfechaOficio1 = (entIF.FECHA_OFICIO1 == null || entIF.FECHA_OFICIO1.ToString().Trim() == "") ? null : entIF.FECHA_OFICIO1?.ToString();
                    vmIF.txtNumeroInformeFundamentado = entIF.NUMERO_INFORME;

                    vmIF.chkEmitirOficio = (entIF.FLAG_NO_INFUN_EMITIDO == 1 ? true : false);
                    vmIF.txtNumeroOficio2 = entIF.NUMERO_OFICIO2;

                    vmIF.dtpfechaOficio2 = (entIF.FECHA_OFICIO2 == null || entIF.FECHA_OFICIO2.ToString().Trim() == "") ? null : entIF.FECHA_OFICIO2?.ToString();
                    vmIF.txtObservacionesOficio = entIF.NOTA_NO_INFFUN;

                    vmIF.chkEmitirOficioPau = (entIF.FLAG_COPIA_PAU_EMITIDO == 1 ? true : false);
                    vmIF.txtNumeroOficioPau = entIF.NUMERO_OFICIO2;

                    vmIF.dtpFechaEmisionPau = (entIF.FECHA_OFICIO2 == null || entIF.FECHA_OFICIO2.ToString().Trim() == "") ? null : entIF.FECHA_OFICIO2?.ToString();
                    vmIF.txtObservacionesPau = entIF.NOTA_COPIA_PAU;

                    vmIF.chkNotificacion = (entIF.FLAG_NOTIFICACION == 1 ? true : false);
                    vmIF.dtpFechaNotificacion = (entIF.FECHA_NOTIFICACION == null || entIF.FECHA_NOTIFICACION.ToString().Trim() == "") ? null : entIF.FECHA_NOTIFICACION?.ToString();

                    vmIF.txtAnotaciones = entIF.NOTA_NOTIFICACION;
                    vmIF.hdfItemEstUbigeoCodigo = entIF.COD_UBIGEO;
                    vmIF.fItemEstUbigeoCodigo = entIF.ESTAB_UBIGEO;
                    vmIF.hdtxtTitularTipo = entIF.COD_PERSONA_ASIGNADO;
                    vmIF.txtTitularTipo = entIF.PERSONA_TITULAR;
                    vmIF.RegEstado = 0;
                    vmIF.cboCodProveidoArch = entIF.COD_PROVEIDOARCH;
                }
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informe Fundamentado");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmIF.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vmIF);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Index");
            }

        }

        [HttpPost]
        public JsonResult Grabar(CEntVM obj)
        {
            try
            {
                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();

                entIF.COD_FCTIPO = obj.hdfCodTipoInfFundamentado;
                entIF.COD_UCUENTA = codCuenta;
                entIF.COD_PERSONA = "";
                entIF.COD_INFFUN = obj.hdfCodInfFundamentado;
                entIF.NUMERO_INFORME = obj.txtNumInfFundamentado;
                entIF.FECHA_EMISION = obj.dtpFechaFundamentado;
                //entIF.FECHA_CREACION = "";
                entIF.COD_OD_REGISTRO = obj.ddlOdId;
                entIF.COD_ESTADO_DOC = obj.vmControlCalidad.ddlIndicadorId;
                entIF.OBSERVACIONES_CONTROL = obj.vmControlCalidad.txtControlCalidadObservaciones;
                entIF.OBSERV_SUBSANAR = obj.vmControlCalidad.chkObsSubsanada;
                entIF.OUTPUTPARAM01 = "";
                entIF.RegEstado = obj.RegEstado;
                entIF.CONCLUSIONES = obj.txtConclusiones;
                entIF.DESCRIPCION = obj.txtObservaciones;
                entIF.ListInformes = obj.tbInforme;
                entIF.ListarEntidades = obj.listaEntidades;

                if (obj.tbEliTABLA != null)
                {

                    for (int j = 0; j < obj.tbEliTABLA.Count; j++)
                    {
                        var ob = obj.tbEliTABLA[j];
                        vmIF.tbEliTABLA.Add(ob);
                    }
                }

                entIF.ListEliTABLA = vmIF.tbEliTABLA;
                entIF.ListProfesionales = obj.listaProfesionales;

                var estado_final = logIF.RegInformeFundamentado_Grabar(entIF);

                if (estado_final != "0" && estado_final != "1") result.AddResultado("El Registro se Guardo Correctamente", true);
                else result.AddResultado("Error en la información", false);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        public JsonResult GrabarInFun(CEntVM obj)
        {
            try
            {
                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();


                entIF.COD_FCTIPO = obj.hdfCodTipoInfFundamentado;
                entIF.COD_UCUENTA = codCuenta;
                entIF.COD_PERSONA = "";
                entIF.COD_INFFUN = obj.hdfCodInfFundamentado;
                entIF.COD_ESTADO_DOC = obj.vmControlCalidad.ddlIndicadorId;
                entIF.OBSERVACIONES_CONTROL = obj.vmControlCalidad.txtControlCalidadObservaciones;
                entIF.OBSERV_SUBSANAR = obj.vmControlCalidad.chkObsSubsanada;

                // NUEVOS CAMPOS // DATOS SOLICITUD
                entIF.COD_ESTADO_SOLICITUD = obj.ddlEstadoSolicitudFemaId;
                entIF.NUMERO_TRAMITE = obj.txtRegistro;
                entIF.FECHA_TRAMITE = obj.dtpFechaIngresoSolicitud;
                entIF.NUMERO_SOLICITUD = obj.txtNumeroOficioSolicitud;
                entIF.COD_TIPO_SOLICITUD = obj.ddlTipoSolicitudId;
                entIF.CARPETA_FISCAL = obj.txtcarpetafiscal;
                entIF.COD_VEN_LEGAL = obj.ddlVencimientoPlazoLegalId;
                entIF.GLOSA = obj.txtDetalle;
                entIF.COD_OD_REGISTRO = obj.ddlOdId;
                entIF.COD_UBIGEO = obj.hdfItemEstUbigeoCodigo; // PENDIENTE
                entIF.COD_PERSONA_ASIGNADO = obj.hdtxtTitularTipo; // PENDIENTE

                // NUEVOS CAMPOS // INFORME FUNDAMENTADO
                string fechaOficio2 = "";
                string fechaOficio1 = "";

                if (obj.ddlTipoSolicitudId.ToString() == "000001")
                {
                    // INFORME
                    entIF.FLAG_INFFUN_EMITIDO = (obj.chkEmitirInforme ? 1 : 0);
                    entIF.COD_PROVEIDOARCH = obj.ddlproveidorId;
                    if (obj.dtpfechaFirmezaPAU != null)
                    {
                        obj.dtpfechaFirmezaPAU = obj.dtpfechaFirmezaPAU.Trim();
                        entIF.FECHA_FIRMEZA = obj.dtpfechaFirmezaPAU;
                    }

                    entIF.NUMERO_OFICIO1 = obj.txtNumeroOficio1;

                    if (obj.dtpfechaOficio1 != null)
                    {
                        obj.dtpfechaOficio1 = obj.dtpfechaOficio1.Trim();
                        entIF.FECHA_OFICIO1 = obj.dtpfechaOficio1;
                    }

                    entIF.CONCLUSIONES = obj.txtConclusiones;
                    entIF.DESCRIPCION = obj.txtObservaciones;
                    entIF.NUMERO_INFORME = obj.txtNumeroInformeFundamentado;

                    if (obj.dtpFechaFundamentado != null)
                    {
                        obj.dtpFechaFundamentado = obj.dtpFechaFundamentado.Trim();
                        entIF.FECHA_EMISION = obj.dtpFechaFundamentado;
                    }
                    // OFICIO
                    entIF.FLAG_NO_INFUN_EMITIDO = (obj.chkEmitirOficio ? 1 : 0);
                    entIF.NUMERO_OFICIO2 = obj.txtNumeroOficio2;

                    if (obj.dtpfechaOficio2 != null)
                    {
                        obj.dtpfechaOficio2 = obj.dtpfechaOficio2.Trim();
                        entIF.FECHA_OFICIO2 = obj.dtpfechaOficio2;
                    }
                    entIF.NOTA_NO_INFFUN = obj.txtObservacionesOficio;

                }
                else //NUEVOS CAMPOS // PAU/COPIA
                {
                    entIF.FLAG_COPIA_PAU_EMITIDO = (obj.chkEmitirOficioPau ? 1 : 0);
                    entIF.NUMERO_OFICIO2 = obj.txtNumeroOficioPau;

                    if (obj.dtpFechaEmisionPau != null)
                    {
                        obj.dtpFechaEmisionPau = obj.dtpFechaEmisionPau.Trim();
                        entIF.FECHA_OFICIO2 = obj.dtpFechaEmisionPau;
                    }
                    entIF.NOTA_COPIA_PAU = obj.txtObservacionesPau;
                }

                //NUEVOS CAMPOS // NOTIFICACION
                entIF.FLAG_NOTIFICACION = (obj.chkNotificacion ? 1 : 0);

                if (obj.dtpFechaNotificacion != null)
                {
                    obj.dtpFechaNotificacion = obj.dtpFechaNotificacion.Trim();
                    entIF.FECHA_NOTIFICACION = obj.dtpFechaNotificacion;
                }

                entIF.NOTA_NOTIFICACION = obj.txtAnotaciones;

                entIF.OUTPUTPARAM01 = "";
                entIF.RegEstado = obj.RegEstado;

                entIF.ListInformes = obj.tbInforme;
                entIF.ListarEntidades = obj.listaEntidades;

                if (entIF.FLAG_INFFUN_EMITIDO == null)
                    entIF.FLAG_INFFUN_EMITIDO = 0;
                if (entIF.FLAG_NO_INFUN_EMITIDO == null)
                    entIF.FLAG_NO_INFUN_EMITIDO = 0;
                if (entIF.FLAG_COPIA_PAU_EMITIDO == null)
                    entIF.FLAG_COPIA_PAU_EMITIDO = 0;

                if (entIF.FLAG_INFFUN_EMITIDO == 0 && entIF.FLAG_NO_INFUN_EMITIDO == 0 && entIF.FLAG_COPIA_PAU_EMITIDO == 0)
                {
                    entIF.DIAS_HABILES_TRANS_NO_INFFUN = 0;
                    entIF.DIAS_HAB_TRANSCURIDOS = 0;
                }


                if (obj.tbEliTABLA != null)
                {

                    for (int j = 0; j < obj.tbEliTABLA.Count; j++)
                    {
                        var ob = obj.tbEliTABLA[j];
                        vmIF.tbEliTABLA.Add(ob);
                    }
                }

                entIF.ListEliTABLA = vmIF.tbEliTABLA;
                entIF.ListProfesionales = obj.listaProfesionales;

                var estado_final = logIF.RegInformeFundamentado_Grabar(entIF);

                if (estado_final != "0" && estado_final != "1") result.AddResultado("El Registro se Guardo Correctamente", true);
                else result.AddResultado("Error en la información", false);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public bool TryParseFecha(string fechaStr, out DateTime fecha)
        {
            string formatoFecha = "dd/MM/yyyy";
            if (DateTime.TryParseExact(fechaStr, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                return true;
            }
            else
            {
                fecha = DateTime.MinValue;
                return false;
            }
        }

        public int CalcularDiasEntreFechas(string fechaInicioStr, string fechaFinStr)
        {
            DateTime fechaInicio, fechaFin;
            if (!TryParseFecha(fechaInicioStr, out fechaInicio) || !TryParseFecha(fechaFinStr, out fechaFin))
            {
                throw new ArgumentException("Las fechas deben estar en formato 'dd/MM/yyyy' y contener datos válidos.");
            }

            TimeSpan diferencia = fechaFin - fechaInicio;

            //if (diferencia.TotalDays < 0)
            //{
            //    throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de finalización.");
            //}

            int cantidadDias = (int)diferencia.TotalDays;

            return cantidadDias;
        }

        public void initBusquedaModal()
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            vmIF.sBusqueda = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo;

            Combo = new Ent_SBusqueda();
            Combo.Value = "INF_NUMERO";
            Combo.Text = "Informe Supervisión";
            listCombo.Add(Combo);

            Combo = new Ent_SBusqueda();
            Combo.Value = "EXPADM_NUMERO";
            Combo.Text = "Nro. Expediente";
            listCombo.Add(Combo);

            vmIF.txtTituloModal = "Nuevo Registro";

            vmIF.sBusqueda = listCombo;
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult FiltrarSubEntidad(string asCodEntidad)
        {
            try
            {
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();
                vmIF.ddlEntidadId = asCodEntidad;
                entIF.COD_INFFUN_ENTIDADES = vmIF.ddlEntidadId;
                entIF = logIF.RegMostrarComboSubEntidad(entIF);
                vmIF.ddlSubEntidad = entIF.ListarEntidades.Select(i => new VM_Cbo { Value = i.COD_SENTIDAD, Text = i.DESCRIPCION_SUBENTIDAD });
                vmIF.ddlSubEntidadId = entIF.ListarEntidades.ElementAt(0).COD_SENTIDAD;
                return Json(new { success = true, result = vmIF.ddlSubEntidad });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult agregarEntidades(CEntidadIF _dto)
        {
            try
            {
                CEntidadIF oCentidad = new CEntidadIF();
                int band = 0;
                oCentidad.COD_SENTIDAD = _dto.COD_SENTIDAD;
                oCentidad.DESCRIPCION_ENTIDAD = _dto.DESCRIPCION_ENTIDAD;
                oCentidad.DESCRIPCION_SUBENTIDAD = _dto.DESCRIPCION_SUBENTIDAD;
                oCentidad.RegEstado = 1;

                if (vmIF.listaEntidades.Count > 0)
                {
                    for (int j = 0; j < vmIF.listaEntidades.Count; j++)
                    {
                        var obj = vmIF.listaEntidades[j];
                        if (obj.COD_SENTIDAD == oCentidad.COD_SENTIDAD)
                        {
                            band = 1;
                        }
                    }
                    if (band == 0)
                    {
                        vmIF.listaEntidades.Add(oCentidad);
                    }
                }
                else
                    vmIF.listaEntidades.Add(oCentidad);

                bool valor = (band == 0) ? true : false;

                return Json(new { success = true, result = vmIF.listaEntidades, value = valor });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult quitarEntidad(CEntidadIF _dto)
        {
            try
            {
                for (int j = 0; j < vmIF.listaEntidades.Count; j++)
                {
                    var obj = vmIF.listaEntidades[j];
                    if (obj.COD_SENTIDAD == _dto.COD_SENTIDAD)
                    {
                        vmIF.listaEntidades.RemoveAt(j);

                        if (vmIF.RegEstado == 0 && obj.RegEstado == 0)
                        {
                            CEntidadIF oCampos = new CEntidadIF();
                            oCampos.EliTABLA = "INFFUN_DET_ENTIDADES";
                            oCampos.EliVALOR01 = obj.COD_SENTIDAD;
                            vmIF.tbEliTABLA.Add(oCampos);
                        }
                    }
                }

                return Json(new { success = true, msj = "El elemento ha sido eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult agregarProfesionales(CEntidadIF _dto)
        {
            try
            {
                CEntidadIF oCentidad = new CEntidadIF();
                int band = 0;
                oCentidad.COD_PERSONA = _dto.COD_PERSONA;
                oCentidad.NUMERO = _dto.NUMERO;
                oCentidad.APELLIDOS_NOMBRES = _dto.APELLIDOS_NOMBRES;
                oCentidad.TIPO = _dto.TIPO;
                oCentidad.RegEstado = 1;

                if (vmIF.listaProfesionales.Count > 0)
                {
                    for (int j = 0; j < vmIF.listaProfesionales.Count; j++)
                    {
                        var obj = vmIF.listaProfesionales[j];
                        if (obj.COD_PERSONA == oCentidad.COD_PERSONA)
                        {
                            band = 1;
                        }
                    }
                    if (band == 0)
                    {
                        vmIF.listaProfesionales.Add(oCentidad);
                    }
                }
                else
                    vmIF.listaProfesionales.Add(oCentidad);

                bool valor = (band == 0) ? true : false;

                return Json(new { success = true, result = vmIF.listaProfesionales, value = valor });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult quitarProfesional(CEntidadIF _dto)
        {
            try
            {
                for (int j = 0; j < vmIF.listaProfesionales.Count; j++)
                {
                    var obj = vmIF.listaProfesionales[j];
                    if (obj.COD_PERSONA == _dto.COD_PERSONA)
                    {
                        vmIF.listaProfesionales.RemoveAt(j);

                        if (vmIF.RegEstado == 0 && obj.RegEstado == 0)
                        {
                            CEntidadIF oCampos = new CEntidadIF();
                            oCampos.EliTABLA = "INFFUN_DET_PROFESIONAL";
                            oCampos.EliVALOR01 = obj.COD_PERSONA;
                            vmIF.tbEliTABLA.Add(oCampos);
                        }
                    }
                }

                return Json(new { success = true, msj = "El elemento ha sido eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult quitarAll(string opc)
        {
            try
            {
                bool valor = false;
                string resultado = "No se eliminaron elementos";

                if (opc == "PROFESIONAL")
                {
                    if (vmIF.listaProfesionales.Count > 0)
                    {
                        for (int j = 0; j < vmIF.listaProfesionales.Count; j++)
                        {
                            var obj = vmIF.listaProfesionales[j];
                            if (vmIF.RegEstado == 0 && obj.RegEstado == 0)
                            {
                                CEntidadIF oCampos = new CEntidadIF();
                                oCampos.EliTABLA = "INFFUN_DET_PROFESIONAL";
                                oCampos.EliVALOR01 = obj.COD_PERSONA;
                                vmIF.tbEliTABLA.Add(oCampos);
                            }
                        }
                    }

                    vmIF.listaProfesionales.Clear();
                    valor = true;
                    resultado = "Elementos eliminados satisfactoriamente";
                }

                return Json(new { success = valor, msj = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult FiltrarMemoFirmeza(string codigoInforme)
        {
            try
            {
                List<Ent_MemoFirmeza> entidad = new List<Ent_MemoFirmeza>();
                CLogica logIF = new CLogica();
                entidad = logIF.FiltrarMemoFirmeza(codigoInforme);

                return Json(new { success = true, result = entidad });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult FiltrarFechaNotificacion(string numeroDocumento)
        {
            try
            {
                List<Ent_MemoFirmeza> entidad = new List<Ent_MemoFirmeza>();
                CLogica logIF = new CLogica();
                string fechaNotificacion = logIF.FiltrarFechaNotificacion(numeroDocumento);

                return Json(new { success = true, result = fechaNotificacion });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ObtenerDocumentoSITD(string numeroRegistro)
        {
            try
            {
                Ent_DocumentoEntradaSITD entidad = new Ent_DocumentoEntradaSITD();
                CLogica logIF = new CLogica();
                entidad = logIF.ObtenerDocumentoSITD(numeroRegistro);

                return Json(new { success = true, result = entidad });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            CEntidadIF paramsBus = new CEntidadIF();
            CEntidadIF result;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            result = exeBus.RegMostrarINFFUN_BuscarDatos(paramsBus);

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
    }
}