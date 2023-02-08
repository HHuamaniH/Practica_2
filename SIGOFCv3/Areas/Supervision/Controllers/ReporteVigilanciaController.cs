using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Supervision.Models.ReporteVigilancia;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Veeduria;
using CEntidad = CapaEntidad.DOC.Ent_Veeduria;
using CLogica = CapaLogica.DOC.Log_Veeduria;
using CapaEntidad.DOC;
using SIGOFCv3.Models;
using CapaLogica.DOC;
using System.Net.Mail;
using System.Net;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ReporteVigilanciaController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                ViewBag.TituloFormulario = "Reportes de Vigilancia";
                CLogica exe = new CLogica();
                CEntidad param = new CEntidad() { NV_CATALOGO = "0000001" };
                CEntidad obj = exe.ListarTipo(param);

                List<VM_Cbo> lstCboTipoHallazgo = new List<VM_Cbo>();
                lstCboTipoHallazgo.Add(new VM_Cbo() { Value = "0000000", Text = "Todos" });
                foreach (var item in obj.ListTipo)
                {
                    lstCboTipoHallazgo.Add(new VM_Cbo() { Value = item.NV_TIPO, Text = item.NV_DESCRIPCION, Group = item.NV_CATALOGO });
                }
                ViewBag.ddlTipoHallazgo = lstCboTipoHallazgo;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public JsonResult GetRptHallazgo(string txtComunidad, string idtipohallazgo, string txtfechaini, string txtfechafin)
        {
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.NV_COMUNIDAD = txtComunidad.Trim();
                param.NV_TIPO = (idtipohallazgo == "0000000") ? null : idtipohallazgo;
                param.FE_INICIO = txtfechaini;
                param.FE_TERMINO = txtfechafin;
                var lstRptHallazgo = logExe.ListarRptHallazgo(param);
                var jsonResult = Json(new { data = lstRptHallazgo, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ExportarRptHallazgo(string txtComunidad, string idtipohallazgo, string txtfechaini, string txtfechafin)
        {
            ListResult result = new ListResult();

            CEntidad param = new CEntidad();
            param.NV_COMUNIDAD = txtComunidad.Trim();
            param.NV_TIPO = (idtipohallazgo == "0000000") ? null : idtipohallazgo;
            param.FE_INICIO = txtfechaini;
            param.FE_TERMINO = txtfechafin;
            result = ExportarDatos.RptHallazgo(param);

            return Json(result);
        }

        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult Download(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }

        public ActionResult ValidarHallazgo(string idhallazgo, string txtComunidad)
        {
            try
            {
                CEntVM vm = new CEntVM();
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad() { NV_REPORTEHALLAZGO = idhallazgo };
                CEntidad obj = logExe.MostrarHallazgo(param);

                vm.lblTituloCabecera = "Reportes de Vigilancia";
                vm.lblTituloEstado = "Procesando Registro";
                vm.hdfCodHallazgo = obj.NV_REPORTEHALLAZGO;
                vm.hdfCodUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                vm.hdfCodUsuarioControl = obj.COD_UCUENTA_PROCESA;
                vm.hdfCodEquipo = obj.NV_EQUIPO;
                vm.hdfCodIntegrante = obj.NV_INTEGRANTE;
                vm.hdfCodOrganizacion = obj.NV_ORGANIZACION;
                vm.txtfecha = obj.FE_EMISION;
                vm.txtsector = obj.NV_SECTOR;
                vm.txtobservacion = obj.NV_OBSERVACION;
                vm.txtobservacion_validado = obj.NV_OBSERVACION_VALIDADO;

                vm.ddlTipoHallazgo = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000001" })
                    .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                vm.ddlTipoHallazgoId = obj.NV_TIPO;

                if (obj.NU_ESTADO == 1)
                {
                    vm.ddlEstado = new List<VM_Cbo>
                    {
                        new VM_Cbo { Value = "1", Text = "RECIBIDO" },
                        new VM_Cbo { Value = "2", Text = "PROCESAMIENTO INICIADO" },
                        new VM_Cbo { Value = "4", Text = "REGISTRO NO CONFORME" }
                    };
                }
                else if (obj.NU_ESTADO == 2)
                {
                    vm.ddlEstado = new List<VM_Cbo>
                    {
                        new VM_Cbo { Value = "2", Text = "PROCESAMIENTO INICIADO" },
                        new VM_Cbo { Value = "3", Text = "PROCESAMIENTO TERMINADO" }
                    };
                }
                else if (obj.NU_ESTADO == 3)
                {
                    vm.ddlEstado = new List<VM_Cbo>
                    {
                        new VM_Cbo { Value = "3", Text = "PROCESAMIENTO TERMINADO" }
                    };
                }
                else if (obj.NU_ESTADO == 4)
                {
                    vm.ddlEstado = new List<VM_Cbo>
                    {
                        new VM_Cbo { Value = "4", Text = "REGISTRO NO CONFORME" }
                    };
                }

                vm.ddlEstadoId = obj.NU_ESTADO.ToString();

                if (vm.ddlTipoHallazgoId == "0000003"
                    || vm.ddlTipoHallazgoId == "0000004"
                    || vm.ddlTipoHallazgoId == "0000005")
                {
                    vm.txtcoordenadaEste = obj.NU_COORDENADA_ESTE;
                    vm.txtcoordenadaNorte = obj.NU_COORDENADA_NORTE;
                    vm.ddlZona = new List<VM_Cbo>
                    {
                        new VM_Cbo { Value = "-", Text = "Seleccionar" },
                        new VM_Cbo { Value = "17", Text = "17S" },
                        new VM_Cbo { Value = "18", Text = "18S" },
                        new VM_Cbo { Value = "19", Text = "19S" },
                    };
                    vm.ddlZonaId = obj.NV_ZONA;

                    switch (obj.NV_TIPO)
                    {
                        case "0000003":
                            vm.txtsuperficie = obj.NU_SUPERFICIE;
                            vm.txtnomempresa = obj.NV_NOMBRE_EMPRESA;
                            vm.txtnomempresa_validado = obj.NV_NOMBRE_EMPRESA_VALIDADO;

                            vm.ddlTipoActividad = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000003" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoActividadId = obj.NV_ACTIVIDAD;
                            vm.ddlTipoResponsable = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000009" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoResponsableId = obj.NV_RESPONSABLE;
                            break;

                        case "0000004":
                            vm.txtsuperficie = obj.NU_SUPERFICIE;
                            vm.txtTHabilitante = obj.NV_THABILITANTE;
                            vm.txtTHabilitante_validado = obj.NV_THABILITANTE_VALIDADO;
                            vm.hdfCodTHabilitante = obj.COD_THABILITANTE;
                            vm.txtTitular = obj.NV_TITULAR;
                            vm.txtTitular_validado = obj.NV_TITULAR_VALIDADO;
                            vm.hdfCodTitular = obj.COD_TITULAR;

                            vm.ddlTipoVia = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000004" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoViaId = obj.NV_VIA;
                            vm.ddlTipoVehiculo = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000005" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoVehiculoId = obj.NV_VEHICULO;
                            vm.ddlTipoFrecuencia = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000006" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoFrecuenciaId = obj.NV_FRECUENCIA;
                            vm.ddlTipoResponsable = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000010" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoResponsableId = obj.NV_RESPONSABLE;
                            break;

                        case "0000005":
                            vm.ddlTipoHecho = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000007" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoHechoId = obj.NV_HECHO;
                            vm.ddlTipoResponsable = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000008" })
                                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                            vm.ddlTipoResponsableId = obj.NV_RESPONSABLE;
                            break;
                    }
                }

                obj = logExe.ListarDetHallazgo(param);
                vm.listDetHallazgo = obj.ListDetHallazgo;

                param.BUS_CRITERIO = "LISTA";
                obj = logExe.ListarTHabilitante(param);
                vm.listTHabilitanteVinculado = obj.ListTHabilitante;

                param = new CEntidad() { CODIGO_RELACIONADO = idhallazgo };
                obj = logExe.ListarArchivo(param);
                vm.listArchivo = obj.ListArchivo;

                param = new CEntidad() { NV_ORGANIZACION = vm.hdfCodOrganizacion };
                obj = logExe.MostrarOrganizacion(param);
                vm.txtcomunidad = txtComunidad;
                vm.txtorgregional = obj.NV_ORGREGIONAL;
                vm.txtorginterna = obj.NV_DESCRIPCION;

                param = new CEntidad() { NV_INTEGRANTE = vm.hdfCodIntegrante };
                obj = logExe.MostrarIntegrante(param);
                vm.txtUsuarioRegistro = obj.NV_APE_PATERNO + " " + obj.NV_APE_MATERNO + " " + obj.NV_NOMBRES;

                param = new CEntidad() { COD_UCUENTA = vm.hdfCodUsuarioControl };
                obj = logExe.MostrarUsuario(param);
                vm.txtUsuarioControl = obj.APELLIDOS_NOMBRES;
                return View(vm);
            }
            catch (Exception ex)
            {
                //return RedirectToAction("ErrorC", "Index");
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public PartialViewResult _AddEditDetHallazgo(string asEstadoDt)
        {
            CLogica logExe = new CLogica();
            Ent_POA oCampos = new Ent_POA();
            oCampos.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            oCampos.BusFormulario = "POA";
            oCampos.BusCriterio = "POA_GENERAL";
            Log_POA exePoa = new Log_POA();
            oCampos = exePoa.RegMostCombo(oCampos);

            if (asEstadoDt == "2" || asEstadoDt == "3")
            {
                ViewBag.ddlEstadoDt = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "2", Text = "CONFORME" },
                    new VM_Cbo { Value = "3", Text = "NO CONFORME" }
                };
            }
            else
            {
                ViewBag.ddlEstadoDt = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "1", Text = "RECIBIDO" },
                    new VM_Cbo { Value = "2", Text = "CONFORME" },
                    new VM_Cbo { Value = "3", Text = "NO CONFORME" }
                };
            }

            ViewBag.ddlTipoDt = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000012" })
                .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });

            ViewBag.ddlZona = new List<VM_Cbo>
            {
                new VM_Cbo { Value = "-", Text = "Seleccionar" },
                new VM_Cbo { Value = "17", Text = "17S" },
                new VM_Cbo { Value = "18", Text = "18S" },
                new VM_Cbo { Value = "19", Text = "19S" }
            };

            var lstEspecies = oCampos.ListMComboEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstEspecies = lstEspecies;

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult _VincularTHabilitante()
        {
            ViewBag.ddlOpc = new List<VM_Cbo>
            {
                new VM_Cbo { Value = "TITULO_HABILITANTE", Text = "N° T. Habilitante" },
                new VM_Cbo { Value = "TITULAR", Text = "Titular" }
            };
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetTHabilitante(string codbuscar, string txtvalor)
        {
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.BUS_CRITERIO = codbuscar;
                param.BUS_VALOR = txtvalor;
                var lstTHabilitante = logExe.ListarTHabilitante(param).ListTHabilitante;
                var jsonResult = Json(new { data = lstTHabilitante, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult IniciaProceso(CEntVM _vm)
        {
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                param.NV_REPORTEHALLAZGO = _vm.hdfCodHallazgo;
                param.NU_ESTADO = Int32.Parse(_vm.ddlEstadoId);
                param.RegEstado = _vm.hdfRegEstado;

                string OUTPUTPARAM = logExe.Inicia_ProcesarHallazgo(param);

                if (OUTPUTPARAM != "")
                {
                    param = new CEntidad() { COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA };
                    var obj = logExe.MostrarUsuario(param);

                    return Json(new
                    {
                        hdfCodUsuarioControl = (ModelSession.GetSession())[0].COD_UCUENTA,
                        txtUsuarioControl = obj.APELLIDOS_NOMBRES,
                        success = true
                    });
                }
                else
                {
                    return Json(new { success = false, msjError = "Error en la operación" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msjError = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DownloadFile(string ruta)
        {
            ListResult result = new ListResult();

            try
            {
                string trama = Convert.ToBase64String(System.IO.File.ReadAllBytes(ruta));
                result.AddResultado(trama, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult Grabar(CEntVM _vm)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                param.NV_REPORTEHALLAZGO = _vm.hdfCodHallazgo;
                param.NV_EQUIPO = _vm.hdfCodEquipo;
                param.NV_INTEGRANTE = _vm.hdfCodIntegrante;
                param.NV_ORGANIZACION = _vm.hdfCodOrganizacion;
                param.NV_TIPO = _vm.ddlTipoHallazgoId;
                param.FE_EMISION = _vm.txtfecha;
                param.NV_SECTOR = _vm.txtsector;
                param.NV_NOMBRE_EMPRESA_VALIDADO = _vm.txtnomempresa_validado;
                param.COD_THABILITANTE = _vm.hdfCodTHabilitante;
                param.NV_THABILITANTE_VALIDADO = _vm.txtTHabilitante_validado;
                param.COD_TITULAR = _vm.hdfCodTitular;
                param.NV_TITULAR_VALIDADO = _vm.txtTitular_validado;
                param.NV_OBSERVACION_VALIDADO = _vm.txtobservacion_validado;
                param.NU_ESTADO = Int32.Parse(_vm.ddlEstadoId);
                param.RegEstado = _vm.hdfRegEstado;
                param.ListDetHallazgo = _vm.listDetHallazgo;
                param.ListTHabilitante = _vm.listTHabilitanteVinculado;
                param.ListElimTHabilitante = _vm.listElimTHabilitanteVinculado;

                string OUTPUTPARAM = logExe.GrabarHallazgo(param);

                if (OUTPUTPARAM != "")
                {
                    result.AddResultado(OUTPUTPARAM.Split('|')[1], true);
                }
                else
                {
                    result.AddResultado("Error en la operación", false);
                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }

        public ActionResult ComunicarHallazgo(string idhallazgo, string txtComunidad)
        {
            try
            {
                CEntVM vm = new CEntVM();
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad() { NV_REPORTEHALLAZGO = idhallazgo };
                CEntidad obj = logExe.MostrarHallazgo(param);

                vm.lblTituloCabecera = "Reportes de Vigilancia";
                vm.lblTituloEstado = "Comunicar Hallazgo";
                vm.hdfCodHallazgo = obj.NV_REPORTEHALLAZGO;
                vm.hdfCodOrganizacion = obj.NV_ORGANIZACION;
                vm.txtfecha = obj.FE_EMISION;
                vm.txtsector = obj.NV_SECTOR;

                vm.ddlTipoHallazgo = logExe.ListarTipo(new CEntidad() { NV_CATALOGO = "0000001" })
                    .ListTipo.Select(i => new VM_Cbo { Value = i.NV_TIPO, Text = i.NV_DESCRIPCION, Group = i.NV_CATALOGO });
                vm.ddlTipoHallazgoId = obj.NV_TIPO;

                obj = logExe.ListarEnviado(param);
                vm.listEnviado = obj.ListEnviado;

                param = new CEntidad() { NV_ORGANIZACION = vm.hdfCodOrganizacion };
                obj = logExe.MostrarOrganizacion(param);
                vm.txtcomunidad = txtComunidad;
                vm.txtorgregional = obj.NV_ORGREGIONAL;
                vm.txtorginterna = obj.NV_DESCRIPCION;

                return View(vm);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public PartialViewResult _EnviarCorreo()
        {
            CLogica logExe = new CLogica();
            CEntidad obj = logExe.ListarCorreo(new CEntidad());

            var lstCorreos = obj.ListCorreo.Select(i => new VM_Cbo { Value = i.CORREO, Text = i.OFICINA + " <" + i.CORREO + ">" }).ToList();
            lstCorreos.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstDestino = lstCorreos;
            ViewBag.lstDestinoCC = lstCorreos;

            return PartialView();
        }

        [HttpPost]
        public JsonResult EnviarMensaje(CEntVM _vm)
        {
            ListResult result = new ListResult();
            string[] destinos, destinosCC;
            List<Attachment> lstAttachment = new List<Attachment>();

            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad() { CODIGO_RELACIONADO = _vm.hdfCodHallazgo };
                CEntidad obj = logExe.ListarArchivo(param);

                foreach (var item in obj.ListArchivo)
                {
                    if (System.IO.File.Exists(item.RUTA))
                    {
                        Attachment attachment = new Attachment(item.RUTA);
                        attachment.Name = item.NV_NOMBRE;
                        lstAttachment.Add(attachment);
                    }
                }

                destinos = _vm.txtdestino.Split(';');

                //Configuración del Mensaje
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                //MailAddress fromAddress = new MailAddress("sigo@osinfor.gob.pe", "SIGO");
                MailAddress fromAddress = new MailAddress("mesadeayuda@rakler.pe", "SIGO");
                //smtpClient.Host = "10.10.11.9";
                smtpClient.Host = "smtp.gmail.com";
                //smtpClient.Port = 25;
                smtpClient.Port = 587;
                //smtpClient.UseDefaultCredentials = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;//Agregado por el correo mesadeayuda
                smtpClient.Credentials = new NetworkCredential("mesadeayuda@rakler.pe", "");//Agregado por el correo mesadeayuda

                message.From = fromAddress;

                foreach (var correo in destinos)
                {
                    if (correo.Length > 0)
                    {
                        message.To.Add(correo);
                    }
                }

                if (_vm.txtdestinoCC != null)
                {
                    destinosCC = _vm.txtdestinoCC.Split(';');

                    foreach (var correo in destinosCC)
                    {
                        if (correo.Length > 0)
                        {
                            message.CC.Add(correo);
                        }
                    }
                }

                message.Subject = _vm.txtasunto;
                message.Body = _vm.txtmensaje_envio.Trim();
                message.IsBodyHtml = true;

                foreach (var itemArchivo in lstAttachment)
                {
                    message.Attachments.Add(itemArchivo);
                }

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //enviando correo
                smtpClient.Send(message);
                message.Dispose();

                param = new CEntidad();
                param.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                param.NV_REPORTEHALLAZGO = _vm.hdfCodHallazgo;
                param.NV_PARA = _vm.txtdestino;
                param.NV_CC = _vm.txtdestinoCC;
                param.NV_CUERPO = _vm.txtmensaje_envio.Trim();
                param.RegEstado = 1;

                string OUTPUTPARAM = logExe.GrabarEnviado(param);

                if (OUTPUTPARAM != "")
                {
                    result.AddResultado(OUTPUTPARAM.Split('|')[1], true);
                }
                else
                {
                    result.AddResultado("Error en la operación", false);
                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetListaEnviados(string idhallazgo)
        {
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad() { NV_REPORTEHALLAZGO = idhallazgo };
                CEntidad obj = logExe.ListarEnviado(param);
                var listEnviado = obj.ListEnviado;
                return Json(new { data = listEnviado, success = true });
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }
    }
}