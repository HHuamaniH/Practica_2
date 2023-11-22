using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Fiscalizacion.Models.GestionConstancia;
using CapaLogica.DOC;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_Constancia;
using CLogica = CapaLogica.DOC.Log_Constancia;
using CEntidadN = CapaEntidad.DOC.Ent_FISNOTI;
using System.IO;
using WnvWordToPdf;
using DocumentFormat.OpenXml.Packaging;
using wp = DocumentFormat.OpenXml.Wordprocessing;
using ish = iTextSharp;
using CapaEntidad.ViewModel.DOC;
using SIGOFCv3.Models;
using System.Net;
using Newtonsoft.Json;
using QRCoder;
using System.Drawing;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class GestionConstanciaController : Controller
    {
        // GET: Fiscalizacion/GestionConstancia
        private string folderPlantilla = "~/Archivos/Constancias";
        private string folderConstanciaGenerado = "~/Archivos/Constancias/Generados";
        private string folderConstanciaGeneradoWord = "~/Archivos/Constancias/Generados/WordGenerado";
        private string folderConstanciaWordSubido = "~/Archivos/Constancias/Generados/WordSubido";
        private string folderConstanciaFirmado = "~/Archivos/Constancias/Firmados";
        private string folderSITDVirtual = "~/"+System.Configuration.ConfigurationManager.AppSettings["pathTransferidoSITD"];
        public ActionResult Index()
        {
            try
            {
                ViewBag.TituloFormulario = "Gestión de Constancias";

                Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
                Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
                paramsBus.BusFormulario = "CONSTANCIA_OBLIGACIONES";

                ViewBag.ddlOpcion = exeBus.RegOpcionesCombo(paramsBus).Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public JsonResult GetListaConstancia(string opcion, string txtvalor)
        {
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.BusFormulario = "CONSTANCIA_OBLIGACIONES";
                param.BusCriterio = opcion;
                param.BusValor = txtvalor;
                var lstConstancia = logExe.ListarConstancia(param);
                var jsonResult = Json(new { data = lstConstancia, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ExportarConstancia(string opcion, string txtvalor)
        {
            ListResult result = new ListResult();

            CEntidad param = new CEntidad();
            param.BusFormulario = "CONSTANCIA_OBLIGACIONES";
            param.BusCriterio = opcion;
            param.BusValor = txtvalor;
            result = ExportarDatos.ListaConstancia(param);

            return Json(result);
        }

        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult Download(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpGet]      
        public FileResult DescargarConstancia(string identificador)
        {
            string message = string.Empty;
            CLogica logConstancia = null;
            VM_CONSTANCIA constancia = null;
            string fullPath = string.Empty;
            try
            {
                logConstancia = new CLogica();
                constancia = logConstancia.ObtenerPorIdentificador(identificador);
                if(constancia.ESTADO_DOCUMENTO== EstadoConstancia.TRANSFERIDO)
                {
                    fullPath = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));
                }
                else
                {
                    fullPath = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));
                   
                }
                if (!System.IO.File.Exists(fullPath))
                {
                    throw new Exception("0|No existe archivo a descargar");
                }
                return File(fullPath, "application/pdf", constancia.ARCHIVO);
            }
            catch (Exception ex)
            {
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    message = mensaje[1];
                else message = "Sucedió un error al descargar la constancia";
                throw new Exception(message);
            }   
        }
        [HttpPost]
        public JsonResult ActualizarEstado(string identificador,string estado)
        {
            bool success = false; string message = string.Empty;           
            try
            {
                var usuario = (ModelSession.GetSession())[0];
                DateTime fechaOperacion = DateTime.Now;
                new Log_Constancia().ActualizarEstado(identificador, estado, fechaOperacion, usuario.COD_UCUENTA);
                success = true;
                message = $"Se actualizó correctamente la constancia a estado {estado}";
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message });
        }
        [HttpPost]
        public JsonResult TransferirSITD(string identificador)
        {
            
            bool success = false; string message = string.Empty;
            string pathDocOrigenFirmado = "";
            string pathDocOrigenGenerado = "";
            string pathDestino = "";
            string msj = string.Empty;
            VM_CONSTANCIA constancia = null;
            Log_Constancia logConstancia = null;
            DateTime fechaOperacion = DateTime.Now;
            try
            {
                logConstancia = new Log_Constancia();
                var usuario = (ModelSession.GetSession())[0];
                constancia = logConstancia.ObtenerPorIdentificador(identificador);
                if (constancia.ESTADO_DOCUMENTO != EstadoConstancia.FIRMADO) throw new Exception($"0|Para poder trasnferir el documento debe estar en estado {EstadoConstancia.FIRMADO}");

                try
                {
                    if (!Directory.Exists(Server.MapPath(folderSITDVirtual)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderSITDVirtual));
                    }
                }
                catch (Exception ex)
                {
                    msj = ex.Message;
                    throw new Exception($"0|Error el crear la carpeta de integración SIGO-SITD");
                }
              

                //validando que el documento existe
                pathDocOrigenFirmado = (Path.Combine(Server.MapPath(folderConstanciaFirmado), $"{constancia.ARCHIVO}"));
                if (!System.IO.File.Exists(pathDocOrigenFirmado)) throw new Exception($"0|No existe el archivo a transferir");
                pathDocOrigenGenerado = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));
                pathDestino = (Path.Combine(Server.MapPath(folderSITDVirtual), $"{constancia.ARCHIVO}"));

                try
                {
                    if (System.IO.File.Exists(pathDestino))
                    {
                        System.IO.File.Delete(pathDestino);
                    }
                    System.IO.File.Copy(pathDocOrigenFirmado, pathDestino);
                }
                catch (Exception ex)
                {
                    msj = ex.Message;
                    throw new Exception($"0|Sucedió un error al mover el archivo al repositorio de trámite");
                }

                try
                {
                    //Actualizando estado de constancias
                    logConstancia.ActualizarEstado(constancia.NV_CONSTANCIA, EstadoConstancia.TRANSFERIDO, fechaOperacion, usuario.COD_UCUENTA);

                }
                catch (Exception)
                {
                    throw new Exception($"0|Sucedió un error al actualizar el estado en el SIGO");
                }

                try
                {
                    //creando registro del archivo en SITD
                    logConstancia.TramiteDigitalGuardar(constancia.TRAMITE_ID, constancia.ARCHIVO, constancia.ARCHIVO, fechaOperacion);

                }
                catch (Exception)
                {
                    logConstancia.ActualizarEstado(constancia.NV_CONSTANCIA, EstadoConstancia.FIRMADO, fechaOperacion, usuario.COD_UCUENTA);
                    throw new Exception($"0|Sucedió un error al realizar la integración con la base de datos del SITD");
                }
               
                //Eliminando archivos de la carpeta de generados y eliminados
                this.EliminarArchivo(pathDocOrigenGenerado);
                this.EliminarArchivo(pathDocOrigenFirmado);
                success = true;
                message = $"Se ha transferido correctamente el documento de la constancia número {constancia.NUMERO} al SITD";
            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (string.IsNullOrEmpty(msj))
                {
                    msj = ex.Message;
                }               
                if (mensaje[0] == "0")
                    message = mensaje[1];
                else message = "Sucedió un error, no se puede continuar";
            }
            return Json(new { success, message , msj });
        }
        [HttpPost]
        public JsonResult ObtenerById(string identificador)
        {
            bool success = false; string message = string.Empty;           
            VM_CONSTANCIA constancia = null;
            try
            {
                constancia =new Log_Constancia().ObtenerPorIdentificador(identificador);
                success = true;                 
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message, constancia });
        }
        [HttpPost]
        public JsonResult ObtenerValidarById(string identificador)
        {
            bool success = false; string message = string.Empty;
            VM_CONSTANCIA constancia = null;
            string fullPath = "";
            bool existeArchivo = false;
            try
            {
                constancia = new Log_Constancia().ObtenerPorIdentificador(identificador);
                if (constancia.ESTADO_DOCUMENTO == EstadoConstancia.GENERADO)
                {
                    fullPath = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));
                }
                else if(constancia.ESTADO_DOCUMENTO == EstadoConstancia.FIRMADO)
                {
                    fullPath = (Path.Combine(Server.MapPath(folderConstanciaFirmado), $"{constancia.ARCHIVO}"));
                }
                else if (constancia.ESTADO_DOCUMENTO == EstadoConstancia.TRANSFERIDO)
                {
                    fullPath = (Path.Combine(Server.MapPath(folderSITDVirtual), $"{constancia.ARCHIVO}"));

                }
                if (System.IO.File.Exists(fullPath))
                {
                    existeArchivo = true;
                }
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message, constancia, existeArchivo });
        }
        [HttpPost]
        public JsonResult GenerarConstancia(string identificador)
        {
            bool success = false; string message = string.Empty;

            string codigoGenerado = string.Empty;
            string nombreContratoGenerado = string.Empty;   
            CLogica logConstancia = null;
            Log_Persona logPersona = null;
            VM_CONSTANCIA constancia = null;
            VM_CONSTANCIA_TRAMITE tramite = null;
            VM_CONSTANCIA_REMITENTE remitente = null;
            Ent_Persona titular = null;
            DateTime fechaOperacion = DateTime.Now;
            bool flagRegeneracion = false;
            int oficinaId=0, trabajadorId = 0;
            string nroDocumentoJefe=string.Empty, nombresJefe = string.Empty, apellidosJefe = string.Empty, oficina = string.Empty;
            string exInterno = string.Empty;
            try
            {
                var usuario = (ModelSession.GetSession())[0];

                

                logConstancia = new CLogica();
                logPersona = new Log_Persona();
                             


                //obteniendo datos de constancia
                constancia = logConstancia.ObtenerPorIdentificador(identificador);
              
                if (constancia == null) throw new Exception("0|El registro de constancia no existe");
                // if(constancia.TRAMITE_ID>0 && !string.IsNullOrEmpty(constancia.ARCHIVO)) throw new Exception($"0|La constancia ya ha sido generado la fecha : {HelperWord.FechaDDMMAAAA(constancia.FECHA_EMISION)}");

                //Validando datos de tramite
                try
                {
                    oficinaId = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["sitd_const_oficina"]);
                }
                catch (Exception)
                {
                    throw new Exception("0|Falta configurar oficina");
                }
                
                if (oficinaId== 0) throw new Exception("0|Falta configurar oficina");
                logConstancia.ObtenerJefeByOficina(oficinaId, out trabajadorId, out nroDocumentoJefe,
                                       out nombresJefe, out apellidosJefe, out oficina);
                if(string.IsNullOrEmpty(oficina)) throw new Exception("0|Falta configurar el nombre de la oficina en el SITD");
                if(trabajadorId<=0) throw new Exception($"0|Falta configurar los datos del jefe de la oficina {oficina} en el SITD");
                if (string.IsNullOrEmpty(nombresJefe)) throw new Exception($"0|No existe el nombre del jefe de la oficina {oficina} en el SITD");
                if (string.IsNullOrEmpty(apellidosJefe)) throw new Exception($"0|No existe los apellidos del jefe de la oficina {oficina} en el SITD");
                if (string.IsNullOrEmpty(nroDocumentoJefe)) throw new Exception($"0|No existe el número de documento del jefe {nombresJefe} de la oficina {oficina} en el SITD");

               
                if (System.Configuration.ConfigurationManager.AppSettings["sitd_const_validarUsuario"] == "1")
                {
                    var personaLogin = logPersona.RegMostrarListaItem(new Ent_Persona() { COD_PERSONA = usuario.COD_PERSONA });
                    personaLogin.N_DOCUMENTO = personaLogin.N_DOCUMENTO?.Trim();
                    if (personaLogin.N_DOCUMENTO != nroDocumentoJefe)
                    {
                        throw new Exception($"0|El usuario {personaLogin.APELLIDOS_NOMBRES} no tiene permiso para realizar esta operación");
                    }
                }   
                if (constancia.TRAMITE_ID <= 0)
                {//si no existe registro de constancia en el tramite

                    if (!System.IO.File.Exists(Path.Combine(Server.MapPath(folderPlantilla), "PlantillaConstanciasTH.docx")))
                    {
                        throw new Exception("0|No existe plantilla de constancias");
                    }
                   
                    //obteniendo el titualar
                    titular = logPersona.RegMostrarListaItem(new Ent_Persona() { COD_PERSONA = constancia.COD_TITULAR });
                    if (titular.COD_PERSONA.Length <= 0) titular = null;
                    if (titular == null) throw new Exception("0|No existe titular, por lo tanto no se puede generar la constancia");
                    //obteniendo remitente del SITD
                    remitente = logConstancia.RemitenteObtenerByNroDocumento(titular.COD_TPERSONA?.Trim(), titular.COD_DIDENTIDAD?.Trim(), titular.N_DOCUMENTO?.Trim());
                    if (remitente == null)
                    {   //creando remitente
                        VM_CONSTANCIA_REMITENTE remitenteCrear = new VM_CONSTANCIA_REMITENTE();
                        remitenteCrear.tipoPersona = titular.COD_TPERSONA?.Trim();
                        remitenteCrear.tipoDocumento = titular.COD_DIDENTIDAD?.Trim();
                        if (remitenteCrear.tipoPersona == "0000006") remitenteCrear.persona = titular.RAZON_SOCIAL;
                        else remitenteCrear.persona = $"{titular.NOMBRES} {titular.APE_PATERNO} {titular.APE_MATERNO}";
                        remitenteCrear.nroDocumento = titular.N_DOCUMENTO;
                        if (titular.ListDomicilio != null)
                        {
                            if (titular.ListDomicilio.Count > 0)
                            {
                                var domicilio = titular.ListDomicilio.FirstOrDefault();
                                remitenteCrear.direccion = domicilio.DIRECCION?.Trim();
                                if (domicilio.COD_UBIGEO?.Length == 6)
                                {
                                    remitenteCrear.codDepartamento = domicilio.COD_UBIGEO.Substring(0, 2);
                                    remitenteCrear.codProvincia = domicilio.COD_UBIGEO.Substring(2, 2);
                                    remitenteCrear.codDistrito = domicilio.COD_UBIGEO.Substring(4, 2);
                                }
                            }
                        }
                        if (titular.ListTelefono != null)
                        {
                            if (titular.ListTelefono.Count > 0)
                            {
                                var telefono = titular.ListTelefono.FirstOrDefault();
                                remitenteCrear.telefono = telefono?.NUMERO;
                            }
                        }
                        if (titular.ListCorreo != null)
                        {
                            if (titular.ListCorreo.Count > 0)
                            {
                                var correo = titular.ListCorreo.FirstOrDefault();
                                remitenteCrear.email = correo?.CORREO;
                            }
                        }
                        remitenteCrear.cFlag = 1;
                        remitenteCrear.remitenteId = 0;
                        //guardando datos del remitente
                        int remitenteId = logConstancia.RemitenteCrear(remitenteCrear);
                        if (remitenteId > 0)
                        {
                            //obteniendo remitente creado
                            remitente = logConstancia.RemitenteObtenerById(remitenteId);
                        }
                    }
                    //creando correlativo en el SITD
                    tramite = new VM_CONSTANCIA_TRAMITE();
                    tramite.codTipoDoc = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["sitd_const_tipoDocumento"]);
                    tramite.codificacionINF = constancia.NUMERO_INFORME;
                    tramite.codOficina = oficinaId;// DSFFS--oficina con que se logueo el usuario
                    tramite.asunto = $"Constancia de Cumplimiento de Obligaciones del titular {constancia.APELLIDOS_NOMBRES} correspondiente a la supervision {constancia.NUMERO_INFORME}";
                    tramite.observacion = null;
                    tramite.numFolio = "1";
                    tramite.trabajadorLoginId = trabajadorId;
                    tramite.fechaEmision = fechaOperacion;
                    tramite.remitenteId = remitente?.remitenteId;
                    tramite.persona = remitente?.persona?.Trim();
                    tramite.direccion = remitente?.direccion?.Trim();
                    tramite.departamento = remitente?.codDepartamento?.Trim();
                    tramite.provincia = remitente?.codProvincia?.Trim();
                    tramite.distrito = remitente?.codDistrito?.Trim();
                    tramite.tramiteId = 0;
                    tramite.tramiteId = logConstancia.TramiteGuardarConstancia(tramite);
                    tramite = logConstancia.TramiteObtenerById(tramite.tramiteId);
                    if (tramite == null)
                    {
                        throw new Exception("0|Error al generar correlativo en el SITD");
                    }
                    constancia.NUMERO = tramite.codificacion.Trim();
                    constancia.PASSWORD = tramite.password.Trim();
                    constancia.TRAMITE_ID = tramite.tramiteId;                  
                    constancia.FECHA_EMISION = fechaOperacion;
                    constancia.PERSONA_FIRMA = $"{nombresJefe} {apellidosJefe}";
                    constancia.OFICINA = oficina;
                    //codigoGenerado = $"{DateTime.Now.Year.ToString()}.{DateTime.Now.Month.ToString()}.{DateTime.Now.Day.ToString()}.{DateTime.Now.Hour.ToString()}.{DateTime.Now.Minute.ToString()}.{DateTime.Now.Second.ToString()}";
                    nombreContratoGenerado = constancia.NUMERO.Replace(' ', '-'); ;
                    nombreContratoGenerado= nombreContratoGenerado.Replace('/', '-');
                    constancia.ARCHIVO = $"CONSTANCIA-DE-CUMPLIMIENTO-DE-OBLIGACIONES-{nombreContratoGenerado}-SALIDA.pdf";
                    logConstancia.ActualizarDatosIntegración(constancia.NV_CONSTANCIA, constancia.NUMERO,
                        fechaOperacion,usuario.COD_UCUENTA, EstadoConstancia.GENERADO, fechaOperacion, constancia.TRAMITE_ID, constancia.ARCHIVO);
                    this.CrearConstancia(constancia);
                }
                else
                {              
                    /*
                     Si sucede un error por x motivos y no se ha generado el archivo, por base de datos se podra cambiar el estado
                     a PENDIENTE y volver a generar la constancia
                     * */
                    if (constancia.ESTADO_DOCUMENTO == EstadoConstancia.PENDIENTE)
                    {

                        //string pathDestinoPdf = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));
                        //this.EliminarArchivo(pathDestinoPdf);
                        //if (!System.IO.File.Exists(pathDestinoPdf))
                        //{//volvemo a generar la plantilla
                        //    tramite = logConstancia.TramiteObtenerById(constancia.TRAMITE_ID);
                        //    constancia.NUMERO = tramite.codificacion.Trim();
                        //    constancia.PASSWORD = tramite.password.Trim();
                        //    constancia.PERSONA_FIRMA = $"{nombresJefe} {apellidosJefe}";
                        //    constancia.OFICINA = oficina;
                        //    this.CrearConstancia(constancia);
                        //    logConstancia.ActualizarEstado(constancia.NV_CONSTANCIA, EstadoConstancia.GENERADO, fechaOperacion, usuario.COD_UCUENTA);
                        //    flagRegeneracion = true;
                        string pathDestinoWord = (Path.Combine(Server.MapPath(folderConstanciaGeneradoWord), $"{constancia.ARCHIVO_TEMP}"));
                        string pathDestinoPdf = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));
                        this.EliminarArchivo(pathDestinoPdf);
                        if (System.IO.File.Exists(pathDestinoWord))
                        {//actualizamos la plantilla
                            tramite = logConstancia.TramiteObtenerById(constancia.TRAMITE_ID);
                            constancia.NUMERO = tramite.codificacion.Trim();
                            constancia.PASSWORD = tramite.password.Trim();
                            constancia.PERSONA_FIRMA = $"{nombresJefe} {apellidosJefe}";
                            constancia.OFICINA = oficina;
                            this.CrearConstanciaActualizar(constancia);
                            logConstancia.ActualizarEstado(constancia.NV_CONSTANCIA, EstadoConstancia.GENERADO, fechaOperacion, usuario.COD_UCUENTA);
                            flagRegeneracion = true;
                        }
                        else
                        {
                            throw new Exception("0|No se puede generar constancia");
                        }
                    }
                    else
                    {
                        throw new Exception("0|La constancia está generado, no se puede volver a generar");
                    }                   
                }
                success = true;
                message = flagRegeneracion? $"Se ha vuelto a generar correctamente la constancia número {constancia.NUMERO}": $"Se ha generado correctamente la constancia número {constancia.NUMERO}";
            }
            catch (Exception ex)
            {
                exInterno = ex.Message;
                   success = false; 
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    message = mensaje[1];
                else message = "Sucedió un error al generar la constancia";
            }
            return Json(new { success, message, exInterno });
        }
        [HttpPost]
        public JsonResult GenerarWord(string identificador)
        {
            bool success = false; string message = string.Empty;
            string fullPath = "";
            bool existeArchivo = false;

            string codigoGenerado = string.Empty;
            string nombreContratoGenerado = string.Empty;
            CLogica logConstancia = null;
            Log_Persona logPersona = null;
            VM_CONSTANCIA_V2 constancia = null;
            DateTime fechaOperacion = DateTime.Now;
            bool flagRegeneracion = false;
            string nroDocumentoJefe = string.Empty, nombresJefe = string.Empty, apellidosJefe = string.Empty, oficina = string.Empty;
            string exInterno = string.Empty;
            try
            {
                var usuario = (ModelSession.GetSession())[0];
                logConstancia = new CLogica();
                logPersona = new Log_Persona();

                //obteniendo datos de constancia
                constancia = logConstancia.ObtenerPorIdentificador_v2(identificador);
                if (constancia == null) throw new Exception("0|El registro de constancia no existe");
                if (!System.IO.File.Exists(Path.Combine(Server.MapPath(folderPlantilla), "PlantillaConstanciasTH.docx")))
                {
                    throw new Exception("0|No existe plantilla de constancias");
                }
                
                constancia.ARCHIVO = $"CONSTANCIA-DE-CUMPLIMIENTO-DE-OBLIGACIONES-{identificador}-SALIDA.docx";
                this.CrearWord(constancia);
                //success = true;

                //Generamos para descargar
                //constancia = new Log_Constancia().ObtenerPorIdentificador(identificador);
                if (constancia.ESTADO_DOCUMENTO == EstadoConstancia.PENDIENTE)
                {
                    fullPath = (Path.Combine(Server.MapPath(folderConstanciaGeneradoWord), $"{constancia.ARCHIVO}"));
                }    
                if (System.IO.File.Exists(fullPath))
                {
                    existeArchivo = true;
                }
                success = true;
                message = flagRegeneracion ? $"Se ha vuelto a generar correctamente la constancia número {constancia.NUMERO}" : $"Se ha generado correctamente el documento";

            }
            catch (Exception ex)
            {
                exInterno = ex.Message;
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    message = mensaje[1];
                else message = "Sucedió un error al generar el documento";
            }
            return Json(new { success, message, exInterno, constancia, existeArchivo });
        }
        private void CrearWord(VM_CONSTANCIA_V2 constancia)
        {
            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;
            byte[] bytePlantilla = null;
            string nomArch = string.Empty;
            //obteniendo plantilla
            try
            {
                bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderPlantilla), "PlantillaConstanciasTH.docx"));

            }
            catch (Exception)
            {
                throw new Exception("0|Error al leer la plantilla de constancia");
            }

            if (!Directory.Exists(Server.MapPath(folderConstanciaGeneradoWord)))
            {
                Directory.CreateDirectory(Server.MapPath(folderConstanciaGeneradoWord));
            }
            nomArch = constancia.ARCHIVO.Substring(0, constancia.ARCHIVO.LastIndexOf("."));
            pathDestinoWord = (Path.Combine(Server.MapPath(folderConstanciaGeneradoWord), $"{nomArch}.docx"));
            string planManejoPC = "";
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    var paras = body.Elements<wp.Paragraph>();
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_TITULAR_TH", constancia.VAR_TITULAR);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_TIPO_DOC", constancia.VAR_TIPO_DOC);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_DOCUMENTO", constancia.VAR_NUMERO_DOC);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_NUM_TH", constancia.VAR_TITULO);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_PLANES", constancia.VAR_PLANES);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_REGENTE", constancia.VAR_REGENTE);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_LIC_REGENTE", constancia.VAR_LIC_REGENTE);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_FECHA_SUPER", constancia.VAR_FECHA_SUP);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_INFORME", constancia.VAR_INFORME);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_EMISION_INFORME", HelperWord.FechaDDMMAAAA(constancia.VAR_FECHA_INFORME));
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_POA_CONST", constancia.VAR_POA_CONST);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_FIN_SUP", HelperWord.FechaDDMMAAAA(constancia.VAR_FIN_SUP));
                    //HelperWord.SearchAndReplace(wordDoc, "VAR_RESOLUCION_APLAN", constancia.VAR_RESOLUCION_APLAN, true);

                    var path_qr = GenerarQR(constancia.NV_CONSTANCIA);
                    HelperWord.ReplaceImage(wordDoc, "img_qr", path_qr);

                    wordDoc.Close();
                }
                this.GuardarMemoryStream(mem, pathDestinoWord);
            }        
        }

        private string GenerarQR(string codConstancia)
        {
            string path_qr = Server.MapPath("~/Archivos/Constancias/QR/" + codConstancia + ".png");

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://constancia-cumplimiento.osinfor.gob.pe/visor-documento/" + codConstancia, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(0, 124, 75), Color.FromArgb(246, 246, 246), true);

            qrCodeImage.Save(path_qr, System.Drawing.Imaging.ImageFormat.Png);

            return path_qr;
        }

        private void CrearConstancia(VM_CONSTANCIA constancia)
        {   
            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;         
            byte[] bytePlantilla = null;
            string nomArch = string.Empty;
            string arch_temp = string.Empty;
            //obteniendo plantilla
            arch_temp = constancia.ARCHIVO_TEMP;
            try
            {
                bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderConstanciaWordSubido), arch_temp));
              
            }
            catch (Exception)
            {
                throw new Exception("0|Error al leer la plantilla de constancia");
            }
                     
            if (!Directory.Exists(Server.MapPath(folderConstanciaGenerado)))
            {
                Directory.CreateDirectory(Server.MapPath(folderConstanciaGenerado));
            }
            nomArch = constancia.ARCHIVO.Substring(0, constancia.ARCHIVO.LastIndexOf("."));
            pathDestinoWord = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{nomArch}.docx"));
            pathDestinoPdf = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{nomArch}.pdf"));
            //string planManejoPC = "";
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    var paras = body.Elements<wp.Paragraph>();
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_TITULAR_TH", constancia.APELLIDOS_NOMBRES?.ToUpper());
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_NUM_TH", constancia.NUMERO_TH);
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_PM_NOMBRE", constancia.TIPO_PLAN);
                    //if (constancia.TIPO_PLAN.ToUpper() == "DEMA")
                    //{
                    //    planManejoPC = $"PC N° {constancia.PARCELA}";
                    //}
                    //else
                    //{
                    //    planManejoPC = $"N° {constancia.NUM_POA}, PC N° {constancia.PARCELA}";
                    //}
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_PM_NUMERO",planManejoPC);
                    ////HelperWord.BuscarReemplazarTexto(paras, "VAR_PM_PC", constancia.PARCELA);
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_SUP_INICIO", HelperWord.FechaLetras(constancia.FECHA_SUPERVISION_INICIO));
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_SUP_FIN", HelperWord.FechaLetras(constancia.FECHA_SUPERVISION_FIN));
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_SUP_NUMERO", constancia.NUMERO_INFORME);
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_SUP_PRESENTACION", HelperWord.FechaDDMMAAAA(constancia.FECHA_INFORME));
                    //HelperWord.BuscarReemplazarTexto(paras, "VAR_SUP_DMA_FIN", HelperWord.FechaLetras(constancia.FECHA_SUPERVISION_FIN));
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_CONST_EMISION", HelperWord.FechaLetras(constancia.FECHA_EMISION));

                    //DATOS DEL SITD
                    HelperWord.SearchAndReplace(wordDoc, "VAR_SITD_NCONSTANCIA", constancia.NUMERO, true);
                    HelperWord.SearchAndReplace(wordDoc, "VAR_SITD_CLAVE", constancia.PASSWORD, true);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_JEFE_FIRMA", constancia.PERSONA_FIRMA.ToUpper());
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_JEFE_OFICINA", constancia.OFICINA .ToUpper());
                    wordDoc.Close();
                }
                this.GuardarMemoryStream(mem, pathDestinoWord);
                this.GenerarPDF(pathDestinoWord, pathDestinoPdf);
            }
            this.EliminarArchivo(pathDestinoWord);          
        }
        private void CrearConstanciaActualizar(VM_CONSTANCIA constancia)
        {

            string pathDestinoWord = string.Empty;
            string pathDestinoPdf = string.Empty;
            byte[] bytePlantilla = null;
            string nomArch = string.Empty;
            string nomArchPDF = string.Empty;
            string archivo_temp = string.Empty;

            archivo_temp = constancia.ARCHIVO_TEMP;
            //obteniendo plantilla
            try
            {
                bytePlantilla = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(folderConstanciaWordSubido), archivo_temp));

            }
            catch (Exception)
            {
                throw new Exception("0|Error al leer la plantilla de constancia");
            }

            if (!Directory.Exists(Server.MapPath(folderConstanciaGeneradoWord)))
            {
                Directory.CreateDirectory(Server.MapPath(folderConstanciaGeneradoWord));
            }
            nomArch = archivo_temp.Substring(0, archivo_temp.LastIndexOf("."));
            nomArchPDF = constancia.ARCHIVO.Substring(0, constancia.ARCHIVO.LastIndexOf("."));
            pathDestinoWord = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{nomArch}.docx"));
            pathDestinoPdf = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{nomArchPDF}.pdf"));
            //string planManejoPC = "";
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    var paras = body.Elements<wp.Paragraph>();

                    HelperWord.BuscarReemplazarTexto(paras, "VAR_CONST_EMISION", HelperWord.FechaLetras(constancia.FECHA_EMISION));

                    //DATOS DEL SITD
                    HelperWord.SearchAndReplace(wordDoc, "VAR_SITD_NCONSTANCIA", constancia.NUMERO, true);
                    HelperWord.SearchAndReplace(wordDoc, "VAR_SITD_CLAVE", constancia.PASSWORD, true);
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_JEFE_FIRMA", constancia.PERSONA_FIRMA.ToUpper());
                    HelperWord.BuscarReemplazarTexto(paras, "VAR_JEFE_OFICINA", constancia.OFICINA.ToUpper());
                    wordDoc.Close();
                }
                this.GuardarMemoryStream(mem, pathDestinoWord);
                this.GenerarPDF(pathDestinoWord, pathDestinoPdf);
            }
            this.EliminarArchivo(pathDestinoWord);
        }
        private void GuardarMemoryStream(MemoryStream ms, string fileName)
        {
            FileStream outStream = System.IO.File.OpenWrite(fileName);
            ms.WriteTo(outStream);
            outStream.Flush();
            outStream.Close();
        }
        private void GenerarPDF(string fileNameOrigen, string fileNameDestino)
        {
            WordToPdfConverter wordToPdfConverter = new WordToPdfConverter();
            wordToPdfConverter.LicenseKey = "G5WGlIaHlIOFjICUhYGahJSHhZqFhpqNjY2NlIQ=";
            try
            {             
                byte[] outPdfBuffer = wordToPdfConverter.ConvertWordFile(fileNameOrigen);
                System.IO.File.WriteAllBytes(fileNameDestino, outPdfBuffer);
            }
            catch (Exception e)
            {
                throw new Exception("Error al convertir a PDF");
            }
        }
        private void EliminarArchivo(string fileName)
        {  try
            {
                if (System.IO.File.Exists(fileName))               
                    System.IO.File.Delete(fileName);               
            }
            catch (Exception){}
        }
        [HttpPost]
        public ActionResult PdfExtractPages(string identificador, int pageNumber)
        {
            // Intialize a new PdfReader instance with the contents of the source Pdf file:
            string sourcePdfPath = string.Empty;           
            VM_CONSTANCIA constancia = null;
            Log_Constancia logConstancia = new Log_Constancia();

            constancia = logConstancia.ObtenerPorIdentificador(identificador);
           
            sourcePdfPath = (Path.Combine(Server.MapPath(folderConstanciaGenerado), $"{constancia.ARCHIVO}"));

            if (!System.IO.File.Exists(sourcePdfPath))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Archivo no encontrado");
            }

            ish.text.pdf.PdfReader reader = new ish.text.pdf.PdfReader(sourcePdfPath);

            int pageCount = reader.NumberOfPages;

            if (pageNumber > pageCount)
            {
                pageNumber = pageCount;
            }

            using (var ms = new MemoryStream())
            {
                // Capture the correct size and orientation for the page:
                ish.text.Document document = new ish.text.Document(reader.GetPageSizeWithRotation(pageNumber));

                //PdfWriter writer = PdfWriter.GetInstance(document, ms);
                //writer.CloseStream = false;

                ish.text.pdf.PdfCopy copy = new ish.text.pdf.PdfCopy(document, ms) { CloseStream = false };

                //string outputFile = @"C:\\pagina.pdf";
                //PdfCopy copy = new PdfCopy(document, new FileStream(outputFile, FileMode.Create));

                document.Open();

                // Extract the desired page number                    
                copy.AddPage(copy.GetImportedPage(reader, pageNumber));

                document.Close();
                reader.Close();

                //return ms.GetBuffer();
                //return Convert.ToBase64String(ms.ToArray());
                string page = Convert.ToBase64String(ms.ToArray());
                return Json(new { page, pageCount });
            }
        }
        [HttpPost]
        public JsonResult GrabarDocumentoAdjunto()
        {
            //string nombreContratoGenerado = string.Empty;
            CLogica logConstancia = null;
            VM_CONSTANCIA constancia = null;
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    VM_CONSTANCIA entN = JsonConvert.DeserializeObject<VM_CONSTANCIA>(Request.Form["data"]);
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 
                    CLogica exeBus = new CLogica();
                    logConstancia = new CLogica();
                    string nomArch = "";
                    string identificador;

                    if (!Directory.Exists(Server.MapPath(folderConstanciaWordSubido)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folderConstanciaWordSubido));
                    }
                    identificador = entN.NV_CONSTANCIA;
                    nomArch = file.FileName;
                    //entN.ARCHIVO = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
                    constancia = logConstancia.ObtenerPorIdentificador(identificador);
                    //Guardar el doc ajunto
                    string name = $"CONSTANCIA-DE-CUMPLIMIENTO-DE-OBLIGACIONES-{identificador}-SALIDA.docx";
                    string url_base = "~/Archivos/Constancias/Generados/WordSubido/";
                    string url_doc = url_base + name;

                    //Get the complete folder path and store the file inside it.
                    file.SaveAs(Server.MapPath(url_doc));


                    exeBus.ActualizarArchivoConstancia(entN.NV_CONSTANCIA, name);
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
    }
    public sealed class EstadoConstancia
    {
        public const string
            PENDIENTE = "PENDIENTE",
            GENERADO = "GENERADO",
            FIRMADO = "FIRMADO",
            TRANSFERIDO = "TRANSFERIDO";
    }
}