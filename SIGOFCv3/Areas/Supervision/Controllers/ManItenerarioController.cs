using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.Documento;
using CapaEntidad.ViewModel.General;
using CapaLogica.Documento;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
  
    public class ManItenerarioController : Controller
    {
        // GET: Supervision/ManItenerario
        private Log_Itenerario log_Itenerario;
        String RutaGeoBITACORA = "~/Ruta_REPO_Geo";
        string msgEncrypt = "";
        private List<SelectListItem> ListarMes()
        {
            return new List<SelectListItem>() { new SelectListItem() { Text = "Todos", Value = "0" },
                                                                    new SelectListItem() { Text = "Enero", Value = "1" },
                                                                    new SelectListItem() { Text = "Febrero", Value = "2" },
                                                                    new SelectListItem() { Text = "Marzo", Value = "3" },
                                                                    new SelectListItem() { Text = "Abril", Value = "4" },
                                                                    new SelectListItem() { Text = "Mayo", Value = "5" },
                                                                    new SelectListItem() { Text = "Junio", Value = "6" },
                                                                    new SelectListItem() { Text = "Julio", Value = "7" },
                                                                    new SelectListItem() { Text = "Agosto", Value = "8" },
                                                                    new SelectListItem() { Text = "Setiembre", Value = "9" },
                                                                    new SelectListItem() { Text = "Octubre", Value = "10" },
                                                                    new SelectListItem() { Text = "Noviembre", Value = "11" },
                                                                    new SelectListItem() { Text = "Diciembre", Value = "12" }
                                                                };
        }
        public ActionResult Index()
        {
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Itinerario de supervisión");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        
        public ActionResult AddEdit(string id="0")
        { 
            Log_Itenerario log_Itenerario = new Log_Itenerario();
            VM_Itenerario vM_Itenerario = log_Itenerario.GetById(id);
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Itinerario de supervisión");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View(vM_Itenerario);
        }
        [HttpPost]
        public JsonResult EliminarBitacoraDetalle(Ent_BITACORA_SUPER vm)
        {
          
            Log_Itenerario log_Itenerario = new Log_Itenerario();
            try
            {
                 log_Itenerario.EliminarBitacoraDetalle(vm);
                return Json(new { success = true, msj = "Se elimino correctamente" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error en el servidor: "+ ex.Message;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj });
            }
        }
        [HttpPost]
        public JsonResult Guardar(VM_Itenerario vm)
        {
            string id;
            Log_Itenerario log_Itenerario = new Log_Itenerario();
            try
            {
                id = log_Itenerario.Guardar(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se registro correctamente", id });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error en el servidor: " + ex.Message;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj });
            }
        }
        private string GetDirectorioSupervisores(List<Ent_GENEPERSONA> ListInformeDetSupervisor)
        {
            string path = "";
            string dirSup = "";

            foreach (var superv in ListInformeDetSupervisor)
            {
                if (superv.NOMBRES.Trim() != "" && superv.APE_PATERNO.Trim() != "" && superv.APE_MATERNO.Trim() != "")
                {
                    dirSup = superv.NOMBRES.Trim().Length >= 15 ? superv.NOMBRES.Trim().Substring(0, 15) : superv.NOMBRES.Trim();
                    dirSup += "-" + (superv.APE_PATERNO.Trim().Length > 0 ? superv.APE_PATERNO.Trim().Substring(0, 1) : superv.APE_PATERNO.Trim());
                    dirSup += "-" + (superv.APE_MATERNO.Trim().Length > 0 ? superv.APE_MATERNO.Trim().Substring(0, 1) : superv.APE_MATERNO.Trim());
                }
                else
                {
                    dirSup = "CODSUPERVISOR." + superv.COD_PERSONA;
                }

                path += path == "" ? dirSup : "-" + dirSup;
            }

            return path;
        }
        [HttpGet]       
        public ActionResult DownloadFileInfoGeo(string ruta,string nombre)
        {
            if (System.IO.File.Exists(ruta))
            {
                var mimeType = MimeMapping.GetMimeMapping(ruta);
                return File(ruta, mimeType, nombre+ Path.GetExtension(ruta));
            }

            return Json("No existe el archivo", JsonRequestBehavior.AllowGet); 
        }
        private string SubirArchivoInfoGeo(string filenameTem, string pathDestino, string filename)
        {
            try
            {
                // Se carga la ruta física de la carpeta temp del sitio
                string rutaBase = Server.MapPath(RutaGeoBITACORA) + "\\" + pathDestino;
                //string rutaBase = "@\\srvfs01\\OTI\\GBD_GEO\\" + path;

                // Si el directorio no existe, crearlo
                if (!Directory.Exists(rutaBase))
                    Directory.CreateDirectory(rutaBase);

                string archivo = String.Format("{0}\\{1}", rutaBase, filename);
                if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), filenameTem)))
                {
                    //Grabando archivos
                    System.IO.File.Copy(System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), filenameTem), archivo);
                    // lstPath.Add(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                    //eliminando temporal
                    System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), filenameTem));

                }
                return archivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al subir archivos de Información geográfica: "+ex.Message);
            }
        }
        [HttpPost]
        public JsonResult GuardarCartaBitacora(Ent_BITACORA_SUPER cartaNB)
        {          
            Log_Itenerario log_Itenerario = new Log_Itenerario();
            try
            {
                cartaNB.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                //guardando ListInfoGeo
                if (cartaNB.ListInfoGeo != null)
                {
                    if (cartaNB.ListInfoGeo.Count > 0)
                    {
                        if(cartaNB.ListInformeDetSupervisor==null || cartaNB.ListInformeDetSupervisor.Count() <= 0)
                        {
                            throw new Exception("Se debe seleccionar como mínimo un Supervisor ");
                        }

                        DateTime fechaDir;
                        string path = "", filename = "";
                        foreach (var item in cartaNB.ListInfoGeo)
                        {
                            fechaDir = Convert.ToDateTime(cartaNB.FECHA_SALIDA);
                            path = "Regreso\\" + "RETORNO_" + fechaDir.Year.ToString() + "\\" + HelperSigo.MesNombre(fechaDir.Month).ToString() + "\\" + GetDirectorioSupervisores(cartaNB.ListInformeDetSupervisor);
                            filename = cartaNB.NUM_THABILITANTE.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                            filename = filename.Length >= 15 ? filename.Substring(0, 15) : filename;
                            //filename += oCEntBitacora.ListBitacoras[i].POAS == "" ? "" : ("_" + oCEntBitacora.ListBitacoras[i].POAS);
                            DateTime fechaActual = DateTime.Now;
                            filename += "_" + fechaActual.Year.ToString() + fechaActual.Month.ToString("00") + fechaActual.Day.ToString("00") + fechaActual.Hour.ToString("00") + fechaActual.Minute.ToString("00") + fechaActual.Second.ToString("00") + fechaActual.Millisecond.ToString("000");
                            filename += "." + item.EXTENSION_ARCH;
                            item.RUTA_ARCH = SubirArchivoInfoGeo(item.NOM_ARCH_TEMP, path, filename);
                        }
                    }
                    
                }

                log_Itenerario.RegistrarCartaNotificacionBitacora(cartaNB);
                return Json(new { success = true, msj = "Se registro correctamente"});
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error en el servidor: " + ex.Message;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj });
            }
        }
        [HttpGet]
        public ActionResult GetAll(DataTableRequest_1 request, string criterio, string valorBusqueda, string sort = "")
        {
            List<VM_Itenerario_List> lstResult = new List<VM_Itenerario_List>();
            int rowcount = 0;
            int currentpage = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;
            int pagesize = request.Length;
            valorBusqueda = valorBusqueda ?? "";
            sort = sort ?? "";
            log_Itenerario = new Log_Itenerario();
            lstResult = log_Itenerario.GetAll(criterio,valorBusqueda, currentpage, pagesize, sort, ref rowcount);

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
        public ActionResult DescargarLista()
        {
            List<VM_Itenerario_List> lstResult = new List<VM_Itenerario_List>();
            int rowcount = 0;
            int currentpage = 0;
            int pagesize = 0;
            string sort = "";                  
            log_Itenerario = new Log_Itenerario();
            lstResult = log_Itenerario.Reporte("REGISTROS_USUARIO", (ModelSession.GetSession())[0].COD_UCUENTA, currentpage, pagesize, sort, ref rowcount);
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Reg_Usu/BITACORASUPER_Reg_Usu.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy HH:mm";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value =  item.FECHA;                        
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.ANIO_REGISTRO;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.MES_REGISTRO;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.OD;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.CARTA_NOTIFICACION;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.NUM_THABILITANTE;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.SUPERVISOR;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.SUPERVISADO;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.TIPO_INFORME;


                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.USUARIO;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.FECHA_HORA_SALIDA;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.FECHA_RECEPCION_CHEQUE;
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item.FECHA_COBRO_CHEQUE;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:N" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "Itinerario";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }            
        }
        public ActionResult _renserSupervisiones(string codBitacora="")
        {
            log_Itenerario = new Log_Itenerario();
            var lstSupervisiones = log_Itenerario.GetAllItenerarioSupervision(codBitacora);           
            return PartialView(lstSupervisiones);
        }
        public ActionResult _CartaBitacora(string codBitacora,string codNotificacion, string codTH, int codSecuencial)
        {
            log_Itenerario = new Log_Itenerario();
            Ent_BITACORA_SUPER vm = new Ent_BITACORA_SUPER();
            vm = log_Itenerario.GetAllItenerarioSupervisionGetById(codBitacora, codNotificacion, codTH, codSecuencial);
            TempData["tbDetActa"] = vm.ListDetActa;
            TempData["tbInfoGeo"] = vm.ListInfoGeo;
            TempData["tbEncryp"] = vm.ListEncryp;
            if (vm.SUPERVISADO_TEXT.Trim() == "")
            {
                vm.SUPERVISADO_TEXT = "SN";
            }
            ViewBag.vmddlSupervisado = new List<VM_Cbo>() { new VM_Cbo() { Text = "Seleccionar", Value = "SN" },
                                                                    new VM_Cbo() { Text = "SI", Value = "SI" },
                                                                    new VM_Cbo() { Text = "NO", Value = "NO" }, };
            ViewBag.vmddTipoInforme = log_Itenerario.ComboListar("BITACORA_SUPER", "TIPO_INFORME", " ");
            ViewBag.vmddlAlertaIlegal= new List<VM_Cbo>() { new VM_Cbo() { Text = "Seleccionar", Value = "SN" },
                                                                    new VM_Cbo() { Text = "SI", Value = "SI" },
                                                                    new VM_Cbo() { Text = "NO", Value = "NO" }, };
            if (vm.ALERTA_ILEGAL_TEXT.Trim() == "")
            {
                vm.ALERTA_ILEGAL_TEXT = "SN";
            }
            return PartialView(vm);
        }
        [HttpGet]
        public JsonResult GetAllDetaActa()
        {
            try
            {
                var lstAdjuntos = (List<Ent_BITACORA_SUPER>)TempData["tbDetActa"];
                var jsonResult = Json(new { data = lstAdjuntos, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetAllDetaInfoGeo()
        {
            try
            {
                var lstAdjuntos = (List<Ent_BITACORA_SUPER>)TempData["tbInfoGeo"];
                var jsonResult = Json(new { data = lstAdjuntos, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetAllDetaEncryp()
        {
            try
            {
                var lstAdjuntos = (List<Ent_BITACORA_SUPER>)TempData["tbEncryp"];
                var jsonResult = Json(new { data = lstAdjuntos, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult _BuscarCartaNotificacion()
        {            
            return PartialView();
        }
        public JsonResult GetAllCartaNotificacion(string BusValor)
        {   
            try
            {
                log_Itenerario = new Log_Itenerario();
                List<Ent_BITACORA_SUPER> consulta = log_Itenerario.GetAllCartaNotificacion("CARTA_NOTIFICACION", "BS_CN_NUMERO", BusValor,"");
                //int i = 1;

                //var result = from c in consulta
                //             select new
                //             {
                //                 ind = i++,
                //                 COD_CNOTIFICACION = c.COD_CNOTIFICACION,
                //                 NUM_CNOTIFICACION = c.NUM_CNOTIFICACION,
                //                 MODALIDAD = c.MODALIDAD,
                //                 COD_THABILITANTE = c.COD_THABILITANTE,
                //                 NUM_THABILITANTE = c.NUM_THABILITANTE,
                //                 TITULAR = c.TITULAR,
                //                 POA = c.POA

                //             };
                var jsonResult = Json(new { data = consulta, success = true, er = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, er = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UploadFilesInfoGeo()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                List<Ent_BITACORA_SUPER> listTempFile = new List<Ent_BITACORA_SUPER>();
                Ent_BITACORA_SUPER tempFile = null;
                // List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                List<string> direcPath = new List<string>();
                try
                {
                    string fileName = "", nomArch = "", extArch = "", fname = "";
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        tempFile = new Ent_BITACORA_SUPER();

                        HttpPostedFileBase file = Request.Files[i];
                        fileName = file.FileName;
                        nomArch = fileName.Substring(0, fileName.LastIndexOf("."));
                        nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                        extArch = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                        fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), fname));

                        direcPath.Add(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), fname));

                        //result.Add(new Dictionary<string, object>(){ { "archivo", nomArch },
                        //                            {"generado",fname },{"ext",extArch },{"secuencial",0 } });

                        tempFile.NOMBRE_ARCH = nomArch;
                        tempFile.EXTENSION_ARCH = extArch;
                        tempFile.NOM_ARCH_TEMP = fname;
                        tempFile.COD_SECUENCIAL_ACTA = 0;
                        tempFile.RegEstado = 1;
                        listTempFile.Add(tempFile);
                    }
                    return Json(new { success = true, data = listTempFile, msj = "Archivos subido correctamente" });
                }
                catch (Exception ex)
                {
                    //eliminando si existe error
                    foreach (string item in direcPath)
                    {
                        if (System.IO.File.Exists(item))
                        {
                            System.IO.File.Delete(item);
                        }
                    }
                    return Json(new { success = false, data = "", msj = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontraron archivos" });
            }
        }

        [HttpPost]
        public JsonResult UploadFilesEncryp()
        {
            string encript = Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Encriptado/");
            string rutaDesencrip = Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Encriptado/Desencriptado/");
            if (!Directory.Exists(encript))
                Directory.CreateDirectory(encript);
            if (!Directory.Exists(rutaDesencrip))
                Directory.CreateDirectory(rutaDesencrip);
            
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                List<Ent_BITACORA_SUPER> listTempFile = new List<Ent_BITACORA_SUPER>();
                Ent_BITACORA_SUPER tempFile = null;
                // List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                List<string> direcPath = new List<string>();
                try
                {
                    string fileName = "", nomArch = "", extArch = "", fname = "", rutaEncrip="";
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        tempFile = new Ent_BITACORA_SUPER();

                        HttpPostedFileBase file = Request.Files[i];
                        fileName = file.FileName;
                        nomArch = fileName.Substring(0, fileName.LastIndexOf("."));
                        nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                        extArch = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                        fname = nomArch + "." + extArch;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), fname));

                        direcPath.Add(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), fname));

                        //result.Add(new Dictionary<string, object>(){ { "archivo", nomArch },
                        //                            {"generado",fname },{"ext",extArch },{"secuencial",0 } });

                        tempFile.NOMBRE_ARCH = nomArch;
                        tempFile.EXTENSION_ARCH = extArch;
                        tempFile.NOM_ARCH_TEMP = fname;
                        tempFile.COD_SECUENCIAL_ENCRYP = 0;
                        tempFile.RegEstado = 1;
                        listTempFile.Add(tempFile);
                        
                        if (!Directory.Exists(rutaDesencrip))
                            Directory.CreateDirectory(rutaDesencrip);
                        rutaEncrip = Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp/");
                        UploadFilesDesencryp(rutaEncrip + fname, rutaDesencrip + nomArch + ".csv");
                    }
                    if (msgEncrypt == "Longitud de datos para descifrado no válida.")
                    {
                        return Json(new { success = false, data = listTempFile, msj = msgEncrypt });
                    }
                    else 
                        return Json(new { success = true, data = listTempFile, msj = "Archivos subido correctamente" });
                }
                catch (Exception ex)
                {
                    //eliminando si existe error
                    foreach (string item in direcPath)
                    {
                        if (System.IO.File.Exists(item))
                        {
                            System.IO.File.Delete(item);
                        }
                    }
                    return Json(new { success = false, data = "", msj = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontraron archivos" });
            }
        }
        [HttpPost]
        public JsonResult UploadFilesDesencryp(string inputFile, string outputFile )
        {
                try
                {
                    string code = @"Amazon33"; // Your Key Here

                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(code);

                    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    CryptoStream cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateDecryptor(key, key),
                        CryptoStreamMode.Read);

                    FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                    int data;
                    try
                    {
                        while ((data = cs.ReadByte()) != -1)
                            fsOut.WriteByte((byte)data);
                        fsOut.Close();
                        fsCrypt.Close();
                        cs.Close();
                    }
                    catch (Exception ex)
                    {
                        fsOut.Close();               
                        fsCrypt.Close();
                        cs.Clear();
                    }
                    
                return Json(new { success = true, msj = "Archivos subido correctamente" });
                }
                catch (Exception ex)
                {
                    msgEncrypt = ex.Message;
                    if (System.IO.File.Exists(inputFile))
                    {
                        System.IO.File.Delete(inputFile);
                    }
                    if (System.IO.File.Exists(outputFile))
                    {
                        System.IO.File.Delete(outputFile);
                    }
                    //return Json(new { success = false, data = "", msj = ex.Message});
                    return Json(new {msj = ex.Message });
                }

        }
        [HttpGet]
        public JsonResult EliminarArchivoInfoGeo(string name)
        {
            try
            {
                string direcTemp = "~/Archivos/Modulo/Supervision/Itinerario/Temp/";
                if (System.IO.File.Exists(Path.Combine(Server.MapPath(direcTemp), name)))
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath(direcTemp), name));
                }
                return Json(new { success = true, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = "", msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UploadFilesAlerta()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                List<Ent_BITACORA_SUPER> listTempFile = new List<Ent_BITACORA_SUPER>();
                Ent_BITACORA_SUPER tempFile = null;
               // List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                List<string> direcPath = new List<string>();
                try
                {
                    string fileName = "", nomArch = "", extArch = "", fname = "";
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        tempFile = new Ent_BITACORA_SUPER();

                        HttpPostedFileBase file = Request.Files[i];
                        fileName = file.FileName;
                        nomArch = fileName.Substring(0, fileName.LastIndexOf("."));
                        nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                        extArch = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                        fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), fname));
                       
                        direcPath.Add(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp"), fname));
                        
                        //result.Add(new Dictionary<string, object>(){ { "archivo", nomArch },
                        //                            {"generado",fname },{"ext",extArch },{"secuencial",0 } });
                        
                        tempFile.NOMBRE_ARCH = nomArch;
                        tempFile.EXTENSION_ARCH = extArch;
                        tempFile.NOM_ARCH_TEMP = fname;
                        tempFile.COD_SECUENCIAL_ACTA = 0;
                        tempFile.RegEstado = 1;
                        listTempFile.Add(tempFile);
                    }
                    return Json(new { success = true, data = listTempFile, msj = "Archivos subido correctamente" });
                }
                catch (Exception ex)
                {
                    //eliminando si existe error
                    foreach (string item in direcPath)
                    {
                        if (System.IO.File.Exists(item))
                        {
                            System.IO.File.Delete(item);
                        }
                    }
                    return Json(new { success = false, data = "", msj = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontraron archivos" });
            }
        }
        [HttpGet]
        public JsonResult EliminarArchivoActa(string name)
        {
            try
            {
                string direcTemp = "~/Archivos/Modulo/Supervision/Itinerario/Temp/";
                if (System.IO.File.Exists(Path.Combine(Server.MapPath(direcTemp), name)))
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath(direcTemp), name));
                }
                return Json(new { success = true, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = "", msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult EliminarArchivoEncryp(string name)
        {
            try
            {
                string direcTemp = "~/Archivos/Modulo/Supervision/Itinerario/Temp/";         
                if (System.IO.File.Exists(Path.Combine(Server.MapPath(direcTemp), name)))
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath(direcTemp), name));
                }
                return Json(new { success = true, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = "", msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}