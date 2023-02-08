using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Tribunal.Models.TribunalNotificacion2da;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_TribunalNotificacion2da;
using CEntidadN2da = CapaEntidad.DOC.Ent_FISNOTI2da;
using CLogica2da = CapaLogica.DOC.Log_FISNOTI2da;
using CapaEntidad.DOC;
using SIGOFCv3.Models.DataTables;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace SIGOFCv3.Areas.Tribunal.Controllers
{
    public class TribunalNotificacion2daController : Controller
    {
        public static CEntVM vmN = new CEntVM();

        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA logB = new CapaLogica.DOC.Log_BUSQUEDA();

            //ViewBag.Formulario = "FIS_NOTIFICACION";
            ViewBag.Formulario = "FIS_NOTIFICACION_2da";
            ViewBag.TituloFormulario = "Notificaciones Segunda Instancia";
            ViewBag.AlertaInicial = _alertaIncial;
            ViewBag.ddlListOpciones = logB.RegMostComboIndividual_v3("FIS_NOTIFICACION_2da", "");
            return View();
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        public ActionResult AddEdit(string asCodNotificacion = "", string asCodTipoN = "", string asTextTipoN="")
        {
            try
            {
                CEntidadN2da entN = new CEntidadN2da();
                CLogica2da logN = new CLogica2da();

                vmN.lblTituloCabecera = "Notificaciones Segunda Instancia";
                vmN.vmControlCalidad = new VM_ControlCalidad_2();
                entN.BusFormulario = "GENERAL";
                entN.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                entN = logN.RegMostCombo(entN);
                vmN.ddlOd = entN.ListMComboOD.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                vmN.ddlEstadoCargo = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0", Text = "Seleccionar" },
                    new VM_Cbo { Value = "2", Text = "Devuelto" },
                    new VM_Cbo { Value = "1", Text = "Notificado" },
                    new VM_Cbo { Value = "3", Text = "Pendiente" },
                };

                //entN.BusFormulario = "FIS_NOTIFICACION";
                entN.BusFormulario = "FIS_NOTIFICACION_2da";
                entN = logN.RegMostCombo(entN);
                vmN.ddlTitular = entN.ListParentesco.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmN.ddlEntidad = entN.ListEntidades.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                vmN.ddlZonaUtm= new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0", Text = "Seleccionar" },
                    new VM_Cbo { Value = "17S", Text = "17S" },
                    new VM_Cbo { Value = "18S", Text = "18S" },
                    new VM_Cbo { Value = "19S", Text = "19S" },
                };

                if (String.IsNullOrEmpty(asCodNotificacion))
                {
                    vmN.lblTituloEstado = "Nuevo Registro";
                    vmN.vmControlCalidad.ddlIndicadorId = "0000000";
                    vmN.hdfCodTipoNotificacion = asCodTipoN;
                    vmN.txtTipoNotificacion = "Notificaciones - " + asTextTipoN;

                    RegistroLimpiar();

                    vmN.RegEstado = 1;

                    vmN.lblTituloDatosG = "Notificación a otras entidades";

                    if (vmN.hdfCodTipoNotificacion == "0000080") NotificaEntidadTitulo();
                    else NotificaTitularTitulo();
                }
                else
                {
                    RegistroLimpiar();

                    entN = logN.RegMostrarListaInfNotiItem(new CEntidadN2da() { COD_FISNOTI = asCodNotificacion });
                    vmN.lblTituloEstado = "Modificando Registro";
                    vmN.hdfCodNotificacion = asCodNotificacion;

                    vmN.hdfIdOrigenRegistro = entN.ID_ORIGEN_REGISTRO.ToString();
                    vmN.vmControlCalidad.ddlIndicadorId = entN.COD_ESTADO_DOC;
                    vmN.vmControlCalidad.txtUsuarioRegistro = entN.USUARIO_REGISTRO;
                    vmN.vmControlCalidad.txtUsuarioControl = entN.USUARIO_CONTROL;
                    vmN.vmControlCalidad.chkObsSubsanada = (bool)entN.OBSERV_SUBSANAR;
                    vmN.vmControlCalidad.txtControlCalidadObservaciones = entN.OBSERVACIONES_CONTROL.ToString();
                    vmN.ddlOdId = entN.COD_OD_REGISTRO;
                    vmN.hdfCodTipoNotificacion = entN.COD_FCTIPO;
                    vmN.txtTipoNotificacion = entN.TIPO_FISCALIZA;

                    vmN.hdfCodNotificador = entN.COD_NOTIFICADOR;
                    vmN.txtNotificador = entN.NOTIFICADOR;

                    if (vmN.hdfCodNotificador.Trim()=="")
                    {
                        vmN.hdfCodNotificador = (ModelSession.GetSession())[0].COD_PERSONA;
                        vmN.txtNotificador = (ModelSession.GetSession())[0].PERSONA;
                    }

                    vmN.txtNumCarta = entN.NUMERO_NOTIFICACION;

                    vmN.txtFechaEmision = entN.FECHA_EMISION.ToString();
                    vmN.txtFechaRecepcion = entN.FECHA_RECEPCION_OD.ToString();
                    vmN.txtFechaEntrega = entN.FECHA_NOTIFICADOR.ToString();
                    vmN.txtFechaNotificacion = entN.FECHA_NOTIFICA_TITULAR.ToString();
                    vmN.txtFechaDevolucion = entN.fdevolucionSEC.ToString();
                    vmN.tbInforme = entN.ListInformes;
                    vmN.ddlEstadoCargoId = entN.IdEstadoCargo.ToString();
                    vmN.chkPrimeraVisita = (Boolean)entN.FlagPrimeraVisita;
                    vmN.chkSegundaVisita = (Boolean)entN.FlagSegundaVisita;
                    vmN.txtFechaPVisita = entN.FechaPrimeraVisita.ToString();
                    vmN.txtFechaSVisita = entN.FechaSegundaVisita.ToString();

                    if (entN.FlagConformeRecepcion == true) vmN.radSituacion = "1";
                    if (entN.FlagSeNegoRecibir == true) vmN.radSituacion = "2";
                    if (entN.FlagSeNegoFirmar == true) vmN.radSituacion = "3";
                    if (entN.FlagBajoPuerta == true) vmN.radSituacion = "4";

                    if (!(Boolean)entN.FlagBajoPuerta)
                    {
                        if (!(Boolean)entN.BUZON && vmN.radSituacion=="") //para los registros antiguos
                            vmN.radSituacion = "1";
                    }

                    vmN.txtParentesco = entN.PARENTESCO.ToString();
                    vmN.ddlTitularId = entN.COD_PARENTESCO;
                    vmN.ddlEntidadId = entN.COD_FENTIDAD;
                    vmN.hdfCodNotificado = entN.COD_RECIBE_NOTIFICA;
                    vmN.txtNotificado = entN.APELLIDOS_NOMBRES;
                    vmN.hdfUbigeo = entN.COD_UBIGEO;
                    vmN.txtUbigeo = entN.UBIGEO;
                    vmN.txtDireccion = entN.DIRECCION;
                    vmN.chkActa = (Boolean)entN.FlagActaNotificacion;

                    if (entN.MedidorAgua == true) vmN.radMedidor = "a";
                    if (entN.MedidorLuz == true) vmN.radMedidor = "l";

                    vmN.txtNumMedidor = entN.NroMedidor.Trim();
                    vmN.txtMatFachada = entN.MaterialColorFachada.Trim();
                    vmN.txtMatPuerta = entN.MaterialColorPuerta.Trim();
                    vmN.txtNumPisos = entN.NroPisos.Trim();

                    string coordenadaRegistrada = entN.CoordenadaUTM.Trim();
                    string[] arrCordenada = coordenadaRegistrada.Split('¬');
                    if (!string.IsNullOrEmpty(coordenadaRegistrada) && arrCordenada.Length > 1)
                    {
                        vmN.ddlZonaUtmId = coordenadaRegistrada.Split('¬')[0];
                        vmN.txtCoordEste = coordenadaRegistrada.Split('¬')[1];
                        vmN.txtCoordNorte = coordenadaRegistrada.Split('¬')[2];
                    }
                    else
                    {
                        vmN.ddlZonaUtmId = "0";
                        vmN.txtCoordEste = "";
                        vmN.txtCoordNorte = "";
                    }

                    vmN.txtTelefono = entN.TelefonoOtros;
                    vmN.chkDeclaracionJurada = (Boolean)entN.FlagCambioDomicilio;
                    vmN.txtCalleDJ = entN.DireccionDeCambioDomicilio;
                    vmN.txtLugarDJ = entN.UrbanizacionDeCambioDomicilio.Trim();
                    vmN.hdfUbigeoDJ = entN.CodUbigeoCambioDomicilio;
                    vmN.txtUbigeoDJ = "";
                    vmN.txtReferenciaDJ = entN.ReferenciaDeCambioDomicilio.Trim();
                    vmN.txtObservaciones = entN.OBSERVACION;
                    vmN.txtDocAdjuntos = entN.DOCUMENTOS_ADJUNTOS;
                    vmN.txtnomArchOriginal = (entN.NOMBRE_ARCHIVO == null) ? "" : entN.NOMBRE_ARCHIVO;
                    vmN.txtnomArchTemporal = (entN.NOMBRE_TEMPORAL_ARCHIVO == null) ? "" : entN.NOMBRE_TEMPORAL_ARCHIVO;
                    vmN.txtextArch = (entN.EXTENSION_ARCHIVO == null) ? "" : entN.EXTENSION_ARCHIVO;
                    vmN.txtestadoArch = "0";
                    vmN.txtcCodificacionSiTD = (entN.cCodificacion_SiTD == null) ? "" : entN.cCodificacion_SiTD;

                    vmN.RegEstado = 0;
                    vmN.chknotifTitular = (Boolean)entN.NOTIF_TITULAR;
                    vmN.idTramiteSITD = entN.ID_TRAMITE_SITD;
                    vmN.chkactadispensa = (Boolean)entN.ACTA_DISPENSA;
                    vmN.chkdjcambiodomicilio = (Boolean)entN.DJ_CAMBIO_DOMICILIO;

                    if ((Boolean)entN.NOTIF_TITULAR)
                    {
                        vmN.lblTituloDatosG = "Notificación al Titular / Tercero Solidario / Regente";
                        NotificaTitularTitulo();
                    }
                    else {
                        vmN.lblTituloDatosG = "Notificación a otras entidades";
                        NotificaEntidadTitulo();
                    } 
                }

                initBusquedaModal(vmN.hdfCodTipoNotificacion);

                return View(vmN);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }

        }

        public void RegistroLimpiar()
        {
            vmN.ddlOdId = "0000000";
            vmN.hdfCodNotificacion = "";
            vmN.hdfCodNotificador = "";//
            vmN.txtNotificador = "";//
            vmN.txtNumCarta = "";//
            vmN.txtFechaEmision = "";//
            vmN.txtFechaRecepcion = "";//
            vmN.txtFechaEntrega = "";
            vmN.txtFechaNotificacion = "";//
            vmN.txtFechaDevolucion = "";
            vmN.tbInforme = new List<CEntidadN2da>();
            vmN.tbEliTABLA = new List<CEntidadN2da>();
            vmN.ddlEstadoCargoId = "0";
            vmN.chkPrimeraVisita = false;
            vmN.chkSegundaVisita = false;
            vmN.txtFechaPVisita = "";
            vmN.txtFechaSVisita = "";
            vmN.radSituacion = "";
            vmN.txtParentesco = "";
            vmN.ddlTitularId = "0000000";
            vmN.ddlEntidadId = "0000000";
            vmN.hdfCodNotificado = "";
            vmN.txtNotificado = "";
            vmN.hdfUbigeo = "";//
            vmN.txtUbigeo = "";//
            vmN.txtDireccion = "";//
            vmN.chkActa = false;
            vmN.radMedidor = "";
            vmN.txtNumMedidor = "";
            vmN.txtMatFachada = "";
            vmN.txtMatPuerta = "";
            vmN.txtNumPisos = "";
            vmN.ddlZonaUtmId = "0";
            vmN.txtCoordEste = "";
            vmN.txtCoordNorte = "";
            vmN.txtTelefono = "";
            vmN.chkDeclaracionJurada = false;
            vmN.txtCalleDJ = "";
            vmN.txtLugarDJ = "";
            vmN.hdfUbigeoDJ = "";
            vmN.txtUbigeoDJ = "";
            vmN.txtReferenciaDJ = "";
            vmN.txtObservaciones = "";//
            vmN.txtDocAdjuntos = "";//
            vmN.txtnomArchOriginal = "";
            vmN.txtnomArchTemporal = "";
            vmN.txtextArch = "";
            vmN.txtestadoArch = "";
            vmN.txtcCodificacionSiTD = "";
            vmN.chknotifTitular = false;
            vmN.idTramiteSITD = -1;
            vmN.chkactadispensa = false;
            vmN.chkdjcambiodomicilio = false;
        }

        [HttpPost]
        public JsonResult Grabar(CEntVM obj)
        {
            try
            {
                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();

                if (obj.tbInforme != null || obj.hdfIdOrigenRegistro == "1")
                {
                    CEntidadN2da entN = new CEntidadN2da();
                    CLogica2da logN = new CLogica2da();

                    entN.COD_FCTIPO = obj.hdfCodTipoNotificacion;
                    entN.COD_UCUENTA = codCuenta;
                    entN.COD_FISNOTI = obj.hdfCodNotificacion;

                    entN.FlagBajoPuerta = (obj.radSituacion == "4") ? true : false;
                    entN.BUZON = (obj.radSituacion == "4") ? true : false;

                    entN.COD_PARENTESCO = (obj.radSituacion == "1") ? obj.ddlTitularId : null;
                    entN.COD_RECIBE_NOTIFICA = (obj.radSituacion == "1") ? obj.hdfCodNotificado : null;

                    entN.ACTA_DISPENSA = obj.chkactadispensa;
                    entN.DJ_CAMBIO_DOMICILIO = obj.chkdjcambiodomicilio;

                    entN.COD_NOTIFICADOR = obj.hdfCodNotificador;
                    entN.OBSERVACION = obj.txtObservaciones;
                    entN.NUMERO_NOTIFICACION = obj.txtNumCarta;
                    entN.FECHA_EMISION = obj.txtFechaEmision;
                    entN.FECHA_RECEPCION_OD = obj.txtFechaRecepcion;
                    entN.FECHA_NOTIFICA_TITULAR = obj.txtFechaNotificacion;
                    entN.FECHA_NOTIFICADOR = obj.txtFechaEntrega;
                    entN.fdevolucionSEC = obj.txtFechaDevolucion;
                    entN.COD_OD_REGISTRO = obj.ddlOdId;
                    entN.COD_ESTADO_DOC = obj.vmControlCalidad.ddlIndicadorId;
                    entN.OBSERVACIONES_CONTROL = obj.vmControlCalidad.txtControlCalidadObservaciones;
                    entN.OBSERV_SUBSANAR = obj.vmControlCalidad.chkObsSubsanada;
                    entN.USUARIO_CONTROL = null;
                    entN.USUARIO_REGISTRO = null;

                    entN.COD_FENTIDAD = obj.ddlEntidadId;

                    entN.OUTPUTPARAM01 = "";
                    entN.COD_UBIGEO = obj.hdfUbigeo;
                    entN.CodUbigeoCambioDomicilio = obj.hdfUbigeoDJ;
                    entN.DOCUMENTOS_ADJUNTOS = obj.txtDocAdjuntos;
                    entN.DIRECCION = (obj.txtDireccion == null) ? null : (obj.txtDireccion.Trim() == "") ? null : obj.txtDireccion;
                    entN.DireccionDeCambioDomicilio = (obj.txtCalleDJ == null) ? null : (obj.txtCalleDJ.Trim()) == "" ? null : obj.txtCalleDJ;
                    entN.ID_TRAMITE_SITD = obj.idTramiteSITD;
                    entN.NOTIF_TITULAR = obj.chknotifTitular;


                    if ((Boolean)entN.NOTIF_TITULAR)
                    {
                        entN.COD_FENTIDAD = null;  
                    }
                    else {
                        entN.COD_PARENTESCO = null;
                        entN.COD_UBIGEO = null;
                    } 

                    entN.RegEstado = vmN.RegEstado;

                    entN.TIPO_FISCALIZA = null;
                    entN.APELLIDOS_NOMBRES = null;
                    entN.UBIGEO = null;
                    entN.UBIGEOCAMBIO = null;
                    entN.NOTIFICADOR = null;
                    entN.ORIGEN_REGISTRO = 1;

                    entN.NOMBRE_ARCHIVO = obj.txtnomArchOriginal;
                    entN.NOMBRE_TEMPORAL_ARCHIVO = obj.txtnomArchTemporal;
                    entN.EXTENSION_ARCHIVO = obj.txtextArch;
                    entN.ESTADO_ARCHIVO = obj.txtestadoArch;
                    entN.cCodificacion_SiTD = obj.txtcCodificacionSiTD;

                    if ((Boolean)entN.NOTIF_TITULAR)
                    {
                        entN.FlagActaNotificacion = obj.chkActa;
                        entN.IdEstadoCargo = Convert.ToInt32(obj.ddlEstadoCargoId);
                        entN.FlagPrimeraVisita = obj.chkPrimeraVisita;
                        entN.FechaPrimeraVisita = (obj.txtFechaPVisita == null) ? null : (obj.txtFechaPVisita.Trim() == "") ? null : obj.txtFechaPVisita;
                        entN.FlagSegundaVisita = obj.chkSegundaVisita;
                        entN.FechaSegundaVisita = (obj.txtFechaSVisita == null) ? null : (obj.txtFechaSVisita.Trim() == "") ? null : obj.txtFechaSVisita;
                        entN.FlagConformeRecepcion = (obj.radSituacion == "1") ? true : false;
                        entN.FlagSeNegoRecibir = (obj.radSituacion == "2") ? true : false;
                        entN.FlagSeNegoFirmar = (obj.radSituacion == "3") ? true : false;
                        entN.FlagBajoPuerta = (obj.radSituacion == "4") ? true : false;
                        entN.MedidorAgua = (obj.radMedidor == "a") ? true : false;
                        entN.MedidorLuz = (obj.radMedidor == "l") ? true : false;
                        entN.NroMedidor = (obj.txtNumMedidor == null) ? null : (obj.txtNumMedidor.Trim() == "") ? null : obj.txtNumMedidor;
                        entN.MaterialColorFachada = (obj.txtMatFachada == null) ? null : (obj.txtMatFachada.Trim() == "") ? null : obj.txtMatFachada;
                        entN.MaterialColorPuerta = (obj.txtMatPuerta == null) ? null : (obj.txtMatPuerta.Trim() == "") ? null : obj.txtMatPuerta;
                        entN.NroPisos = (obj.txtNumPisos == null) ? null : (obj.txtNumPisos.Trim() == "") ? null : obj.txtNumPisos;
                        string zonaUTM = obj.ddlZonaUtmId;
                        string coordenadaEste = (obj.txtCoordEste == null) ? null : obj.txtCoordEste.Trim();
                        string coordenadaNorte = (obj.txtCoordNorte == null) ? null : obj.txtCoordNorte.Trim();
                        string datoCoordenadaRegistrar = "";
                        if (zonaUTM != "0")
                        {
                            if (string.IsNullOrEmpty(coordenadaEste) || string.IsNullOrEmpty(coordenadaNorte))
                            {
                                throw new Exception("Los campos Coordenada Este y Norte son obligatorios");
                            }
                            datoCoordenadaRegistrar = zonaUTM + "¬" + coordenadaEste + "¬" + coordenadaNorte;
                        }
                        entN.CoordenadaUTM = (datoCoordenadaRegistrar == null) ? null : (datoCoordenadaRegistrar == "") ? null : datoCoordenadaRegistrar;
                        entN.TelefonoOtros = (obj.txtTelefono == null) ? null : (obj.txtTelefono.Trim() == "") ? null : obj.txtTelefono;
                        entN.FlagCambioDomicilio = obj.chkDeclaracionJurada;
                        entN.UrbanizacionDeCambioDomicilio = (obj.txtLugarDJ == null) ? null : (obj.txtLugarDJ.Trim() == "") ? null : obj.txtLugarDJ;
                        entN.ReferenciaDeCambioDomicilio = (obj.txtReferenciaDJ == null) ? null : (obj.txtReferenciaDJ.Trim() == "") ? null : obj.txtReferenciaDJ;
                        entN.PARENTESCO = obj.txtParentesco;
                    }

                    if (entN.ESTADO_ARCHIVO == "1" || entN.ESTADO_ARCHIVO == "2")
                    {
                        entN.cCodificacion_SiTD = (entN.cCodificacion_SiTD == null) ? "" : entN.cCodificacion_SiTD.Trim();
                        string nombreArchivoReg = entN.cCodificacion_SiTD.Trim() + "-Cargo." + entN.EXTENSION_ARCHIVO;
                        string nombreArchivoRegTemp = entN.cCodificacion_SiTD.Trim() + "-Cargo_" + DateTime.Now.ToShortDateString() + "." + entN.EXTENSION_ARCHIVO;
                        nombreArchivoReg = nombreArchivoReg.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                        nombreArchivoRegTemp = nombreArchivoRegTemp.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                        if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), entN.NOMBRE_TEMPORAL_ARCHIVO)))
                        {
                            //verificando si existe archivo en el repositorio. si existe lo trasladamos a la carpeta Coactiva/eliminados como temporal
                            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/"), nombreArchivoReg)))
                            {
                                System.IO.File.Copy(Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/"), nombreArchivoReg), Path.Combine(Server.MapPath("~/Ruta_SITD/Coactiva/Eliminados"), nombreArchivoRegTemp), true);
                            }
                            //moviendo archivos a la carpeta 
                            System.IO.File.Copy(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), entN.NOMBRE_TEMPORAL_ARCHIVO), Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/"), nombreArchivoReg), true);

                            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), entN.NOMBRE_TEMPORAL_ARCHIVO));
                        }
                        entN.NOMBRE_ARCHIVO = entN.NOMBRE_ARCHIVO + "." + entN.EXTENSION_ARCHIVO;
                        entN.EXTENSION_ARCHIVO = null;
                        entN.NOMBRE_TEMPORAL_ARCHIVO = nombreArchivoReg; //sera el campo CNombreNuevo de la tabla Tra_M_Tramite_Digitales de la bd std_osinfor
                    }
                    else
                    {
                        entN.NOMBRE_ARCHIVO = null;
                        entN.EXTENSION_ARCHIVO = null;
                        entN.NOMBRE_TEMPORAL_ARCHIVO = null;
                        entN.ESTADO_ARCHIVO = null;
                    }

                    entN.ListInformes = obj.tbInforme;
                    entN.ListEliTABLA = obj.tbEliTABLA;
                    entN.ID_ORIGEN_REGISTRO = null;
                    entN.cCodificacion_SiTD = null;

                    var estado_final = logN.RegNotificacion_Grabar(entN);

                    if (estado_final != "0" && estado_final != "1") {
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

        public void initBusquedaModal(string tipocb)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            vmN.sBusqueda = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo;

            switch (tipocb)
            {
                case "0000028"://Archivo del Informe de Supervisión

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informe Supervisión";
                    listCombo.Add(Combo);

                    vmN.lbldocumento = "Lista de Informes de Supervisión, Suspensión, Cancelación y/o Técnicos";
                    vmN.txtTituloDocumento = "FN-ARCHIVO DE INFORME DE SUPERVISION";

                    break;

                case "0000121"://Notificación del Informe de Supervisión (DSFFS)    

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informe Supervisión";
                    listCombo.Add(Combo);

                    vmN.lbldocumento = "Lista de Informes de Supervisión, Suspensión, Cancelación y/o Técnicos";
                    vmN.txtTituloDocumento = "FN-NOTIFICACION INFORME DE SUPERVISION";

                    break;

                case "0000029"://RD Archivo del Informe de Supervisión

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD ARCHIVO DE INFORME DE SUPERVISION";

                    break;

                case "0000030"://Notificación del Informe de Supervisión (DSFFS)    

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD INICIO PAU";

                    break;

                case "0000031"://Notificación del Informe de Supervisión (DSFFS)    

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD AMPLIACION DE PAU";

                    break;

                case "0000032"://RD Término PAU

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD TERMINO DE PAU";

                    break;

                case "0000033"://RD Rectificación

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD RECTIFICACION";

                    break;

                case "0000034"://RD Acumulación de Expedientes con PAU

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD ACUMULACION DE EXPEDIENTES CON PAU";

                    break;

                case "0000035"://RD Evaluación del Recurso de Reconsideración

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD EVALUACION DE RECONSIDERACION";

                    break;

                case "0000036"://RD Medidas Cautelares 				

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD LEVANTAMIENTO DE MEDIDAS CAUTELARES";

                    break;

                case "0000037"://Otros   

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Expediente Administrativo";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    vmN.lbldocumento = "Lista de Expediente Administrativo y Resolución Directoral";
                    vmN.txtTituloDocumento = "NOTIF_OTROS";

                    break;

                case "0000080"://Proveido Firme el Acto administrativo

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_TER_NUMERO";
                    Combo.Text = "Nro. RD Término PAU";
                    listCombo.Add(Combo);

                    vmN.lbldocumento = "Lista de Resoluciones Directorales de Término de PAU";
                    vmN.txtTituloDocumento = "NOTIF_FIRME_ACTO";

                    break;

                case "0000109"://Informe Final de instrucción

                case "0000110"://Informe legal de fase decisora

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_LEGAL_INS";
                    Combo.Text = "Nro. Inf. Legal";
                    listCombo.Add(Combo);

                    vmN.lbldocumento = "Lista de Informes Legales de Instrucción o de fase decisora";
                    vmN.txtTituloDocumento = "INF_LEGAL_INS";

                    break;

                case "0000114"://RD Conservación Acto Administrativo

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD CONSERVACION DE ACTO ADMINISTRATIVO";

                    break;

                case "0000115"://RD Variación de Imputación de Cargos

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RSD VARIACION DE IMPUTACION DE CARGOS";

                    break;

                case "0000116"://RD Auditoria Quinquenal

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "RD AUDITORIA QUINQUENAL";

                    break;

                case "0000117"://RD Aplicación de Medidas Cautelares (Antes del PAU)

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "XXXXX";

                    break;

                case "0000128"://RD Verificación de Medidas Correctivas

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "RD_NUMERO";
                    Combo.Text = "Nro. Resolución";
                    listCombo.Add(Combo);

                    //vmN.lbldocumento = "Lista de Resolución Directoral";
                    vmN.lbldocumento = "Lista de Resolución del TFFS";
                    vmN.txtTituloDocumento = "XXXXX";

                    break;
            }

            vmN.txtTituloModal = "Nuevo Registro";
            vmN.sBusqueda = listCombo;
        }

        public void NotificaEntidadTitulo()
        {
            vmN.lblTituloItemDoc = "Número Oficio remitido a la entidad";
            vmN.lblTituloItemFechaNotif = "Fecha de notificación a la entidad";
            vmN.ddlTitularId = "0000000";
            vmN.lblTituloItemRecibeNotif = "Destinatario";
        }

        public void NotificaTitularTitulo()
        {
            vmN.lblTituloItemDoc = "Número Carta o Cédula remitida al Titular / Tercero Solidario / Regente";
            vmN.lblTituloItemFechaNotif = "Fecha de notificación al titular";
            vmN.ddlEntidadId = "0000000";
            vmN.lblTituloItemRecibeNotif = "Persona que recibe la notificación";
        }

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica2da exeBus = new CLogica2da();
            CEntidadN2da paramsBus = new CEntidadN2da();
            CEntidadN2da result;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            result = exeBus.RegMostrarFISNOTIInf_BuscarDatos(paramsBus);

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
        public JsonResult GrabarDocumentoAdjunto()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    CEntidadN2da entN = JsonConvert.DeserializeObject<CEntidadN2da>(Request.Form["data"]);
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 
                    CLogica2da exeBus = new CLogica2da();
                    string nomArch = "", extArch = "";
                    string nameArch = "";

                    nameArch = file.FileName;
                    nomArch = nameArch.Substring(0, nameArch.LastIndexOf("."));
                    nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                    extArch = nameArch.Substring(nameArch.LastIndexOf(".") + 1).ToLower();
                    string fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;

                    file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), fname));

                    entN.NOMBRE_ARCHIVO = nomArch + "." + extArch;
                    entN.NOMBRE_TEMPORAL_ARCHIVO = fname;
                    entN.EXTENSION_ARCHIVO = extArch;
                    entN.ESTADO_ARCHIVO = "1";

                    return Json(new { success = true, msj = "Se subio correctamente el archivo", data = entN });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontró el documento a subir" });
            }
        }

        public void DescargarDocumentoAdjunto(string nombreArchivo, string nombreOriginal)
        {
            string FilePath = "";

            FilePath = Path.Combine(HttpContext.Server.MapPath("~/Archivos/Temporales/"), nombreArchivo);

            if (FilePath != "")
            {
                HttpContext.Response.Clear();
                HttpContext.Response.Charset = "";
                HttpContext.Response.ContentType = "application/download";
                HttpContext.Response.ContentEncoding = System.Text.Encoding.Default;
                HttpContext.Response.Charset = "";
                HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreOriginal);
                HttpContext.Response.TransmitFile(FilePath);
                HttpContext.Response.Flush();
            }
        }
    }
}