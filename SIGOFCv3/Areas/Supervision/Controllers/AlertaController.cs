using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_Alerta;
using VModel = CapaEntidad.ViewModel.VM_Alerta;
using CEntidad = CapaEntidad.DOC.Ent_ALERTA;
using CapaEntidad.ViewModel;
using System.Web.Helpers;
using Herramienta;
using System.IO;
using SIGOFCv3.Models;
using System.Net.Mail;
using SIGOFCv3.Helper;
using SIGOFCv3.Models.DataTables;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using CapaEntidad.ViewModel.General;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class AlertaController : Controller
    {
        // GET: Supervision/Alerta
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult MainAlerta()
        {
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Alertas OSINFOR");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        public ActionResult GetAll(DataTableRequest_1 request, string criterio, string valorBusqueda, string sort = "")
        {
            CLogica objLog = new CLogica();
            List<CEntidad> lstResult = new List<CEntidad>();
            int rowcount = 0;
            int currentpage = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;
            int pagesize = request.Length;
            valorBusqueda = valorBusqueda ?? "";
            sort = sort ?? "";
            
            lstResult = objLog.AlertaListaItems(criterio, valorBusqueda, currentpage, pagesize, sort, ref rowcount);

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
            List<CEntidad> lstResult = new List<CEntidad>();
            int rowcount = 0;
            int currentpage = 0;
            int pagesize = 0;
            string sort = "";
            CLogica log_Itenerario = new CLogica();
           
            lstResult = log_Itenerario.AlertaListaItems("REGISTROS_USUARIO", (ModelSession.GetSession())[0].COD_UCUENTA, currentpage, pagesize, sort, ref rowcount);
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Reg_Usu/PlantillaAlertaOsinfor.xlsx"));
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
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = (item.FECHA_SALIDA == " " || string.IsNullOrEmpty(item.FECHA_SALIDA)) ? DateTime.MinValue : Convert.ToDateTime(item.FECHA_SALIDA);
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";// "dd/mm/yyyy HH:mm";
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = (item.FECHA_LLEGADA == " " || string.IsNullOrEmpty(item.FECHA_LLEGADA)) ? DateTime.MinValue : Convert.ToDateTime(item.FECHA_LLEGADA);
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.OD;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.CARTA_NOTIFICACION;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.NUM_THABILITANTE;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.SUPERVISOR;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.SUPERVISADO;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.TIPO_INFORME;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.ENVIAR_ALERTA_TEXT;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.USUARIO;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:K" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "AlertaOsinfor";
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
        [HttpPost]
        public JsonResult UploadFileOficio()
        {
            
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                VModel objVM = new VModel(); 
                  objVM.entidad=(CEntidad)Session["EntBitacora"];
              
                try
                {
                    string fileName = "", nomArch = "", extArch = "", fname = "";

                    HttpPostedFileBase file = Request.Files[0];
                    fileName = file.FileName;
                    nomArch = fileName.Substring(0, fileName.LastIndexOf("."));
                    nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                    extArch = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                    fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;
                    file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/Temp"), fname));   
                    objVM.entidad.ARCHIVO_OFICIO_TEXT = nomArch + "." + extArch;
                    objVM.entidad.ARCHIVO_OFICIO = fname;//nom
                    objVM.entidad.ESTADO_ARCHIVO_OFICIO = "2";
                    Session["EntBitacora"] = objVM.entidad;
                    return Json(new { success = true, data = new Archivos() {
                        nombreOriginal = nomArch,
                        nombreGenerado = fname,
                        extension = extArch,
                        estado = 1,
                        nombreBDAntiguo = ""
                    } , msj = "Archivo subido correctamente" });
                }
                catch (Exception ex)
                {                   
                    return Json(new { success = false, data = "", msj = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontraron archivos" });
            }
        }
        [HttpGet]
        public ActionResult AddEdit()
        {

            string codigoDato = Request.QueryString["codigoDato"].ToString();
            string codigoComplementario = Request.QueryString["codigoComplementario"].ToString();
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            CEntidad oCampos = new CEntidad();
            oCampos.COD_BITACORA = codigoDato;
            oCampos.COD_THABILITANTE = codigoComplementario;
            String COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatosEdit(oCampos, COD_UCUENTA);
            objVM.codigoComplementario = codigoComplementario;
            objVM.codigoDato = codigoDato;
            Session["EntBitacora"] = objVM.entidad;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Alertas OSINFOR");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View(objVM);
        }
        public ActionResult _ItemDocRecibido()
        {

            return PartialView();
        }
        [HttpGet]
        public ActionResult Seguimiento()
        {

            string codigoDato = Request.QueryString["codigoDato"].ToString();
            string codigoComplementario = Request.QueryString["codigoComplementario"].ToString();
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            CEntidad oCampos = new CEntidad();
            oCampos.COD_BITACORA = codigoDato;
            oCampos.COD_THABILITANTE = codigoComplementario;
            String COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatosSeguimiento(oCampos, COD_UCUENTA);
            objVM.codigoComplementario = codigoComplementario;
            objVM.codigoDato = codigoDato;
            Session["EntBitacora"] = objVM.entidad;

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Alertas OSINFOR");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View(objVM);
        }

        [HttpGet]
        public JsonResult GetAllDocRecibidoByAlerta()
        {
            string codigoDato = Request.QueryString["codigoDato"].ToString();
            string codigoComplementario = Request.QueryString["codigoComplementario"].ToString();
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            CEntidad oCampos = new CEntidad();
            oCampos.COD_BITACORA = codigoDato;
            oCampos.COD_THABILITANTE = codigoComplementario;
            String COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatosSeguimiento(oCampos, COD_UCUENTA);
            objVM.codigoComplementario = codigoComplementario;
            objVM.codigoDato = codigoDato;
            Session["EntBitacora"] = objVM.entidad;

            var jsonResult = Json(new { data = objVM.entidad.ListDocRecibido }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult saveDocRecibido(VModel dto)
        {
            
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            resultado = objLog.GuardarSeguimiento(dto, codUCuenta);
            return Json(resultado);
        }

        [HttpGet]
        public JsonResult GetAllEspecieBExt()
        {
            //ListBEXT
            CEntidad entidad = (CEntidad)Session["EntBitacora"];
            var jsonResult = Json(new { data = entidad.ListBEXT, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public ActionResult Downloadfile()
        {
            string nombreArchivo = Request["nombreArchivo"];
            string nombreArchivoOriginal = Request["nombreOriginal"];
            string opcion = Request["opcion"];
            string FilePath = "";
            if (opcion == "0")
            {  //archivos que ya estan registrado en la BD  
                FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/"), nombreArchivo);
            }
            else if (opcion == "1")
            {
                FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp/"), nombreArchivo);
            }
            else if (opcion == "2")
            {
                //probiene de ruta antigua
                String RutaBITACORAAntigua = "~/Archivos/Archivo_Bitacora/";
                FilePath = System.IO.Path.Combine(Server.MapPath(RutaBITACORAAntigua), nombreArchivo);
            }
            //opcion oficio
            else if (opcion == "3")
            {
                FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/Temp/"), nombreArchivo);
            }
            else if (opcion == "4")
            {
                FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/"), nombreArchivo);
            }
            else if (opcion == "5") //para descargar archivos de origen coactiva - temporales
            {
                FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Temporales/"), nombreArchivo);
            }          

            return new BinaryContentResultDowload
            {
                FileName = nombreArchivoOriginal,
                ContentType = "application/octet-stream",
                Content = System.IO.File.ReadAllBytes(FilePath)
            };

         }
        public JsonResult ExistFileDownload(string nombreArchivo, string opcion)
        {
            ListResult result = new ListResult();
            
            try
            {
                string FilePath = "";
                if (opcion == "0")
                {  //archivos que ya estan registrado en la BD  
                    FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/"), nombreArchivo);
                }
                else if (opcion == "1")
                {
                    FilePath = System.IO.Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp/"), nombreArchivo);
                }
                else if (opcion == "2")
                {
                    //probiene de ruta antigua
                    String RutaBITACORAAntigua = "~/Archivos/Archivo_Bitacora/";
                    FilePath = System.IO.Path.Combine(Server.MapPath(RutaBITACORAAntigua), nombreArchivo);
                }
                if (System.IO.File.Exists(FilePath))
                {
                    result.existe = true;
                }
                else
                {
                    result.existe = false;
                }
                result.success = true;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDestinatariosCC(string supuesto)
        {
            CLogica objLog = new CLogica();
            CEntidad result;

            result = objLog.GetDestinatarios_CC(supuesto); ;
            var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public PartialViewResult _BalanceExtra()
        {
           
            return PartialView();
        }
        public JsonResult GetAllEspecieBExtxCodNot(string codNotificacion)
        {
            CLogica objLog = new CLogica();
            List<CEntidad> result;
            result = objLog.RegEspecieBExt(codNotificacion);
            var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetAllItemActaAlerta(VModel objVM)
        {
            ListResult result = new ListResult();
            try
            {
                result.fileInfo = new List<Archivos>();
                //CEntidad oCEntBitacora = new CEntidad();
                //CLogica objLog = new CLogica();

                //oCEntBitacora.COD_BITACORA = objVM.codigoDato;
                //oCEntBitacora.COD_THABILITANTE = objVM.codigoComplementario.Split('|')[0].ToString();
                //oCEntBitacora.COD_SECUENCIAL = Int32.Parse(objVM.codigoComplementario.Split('|')[1].ToString());

                //oCEntBitacora = objLog.EditItemsAlerta(oCEntBitacora);
                CEntidad oCEntBitacora = (CEntidad)Session["EntBitacora"];
                var lst = oCEntBitacora.ListBitacoras;
                string var_nombreBD = "", extenArchivo = "", nameArch = "", nomArch = "";
                for (int i = 0; i < lst.Count; i++)
                {
                    var_nombreBD = lst[i].COD_BITACORA + lst[i].COD_SECUENCIAL_ACTA.ToString() + "." + lst[i].EXTENSION_ARCH;
                    extenArchivo = lst[i].EXTENSION_ARCH;
                    nomArch = lst[i].NOMBRE_ARCH;
                    if (lst[i].NOMBRE_ARCH_ANTIGUO.Trim() != "")
                    {
                        nameArch = lst[i].NOMBRE_ARCH;
                        nomArch = nameArch.Substring(0, nameArch.LastIndexOf("."));
                        extenArchivo = nameArch.Substring(nameArch.LastIndexOf(".") + 1).ToLower();

                    }
                    result.fileInfo.Add(new Archivos
                    {
                        indexPadre = 0,
                        index = 0,
                        nombreOriginal = nomArch,// lst[i].NOMBRE_ARCH,
                        nombreGenerado = lst[i].ARCHIVOS,
                        extension = extenArchivo,
                        nombreBD = var_nombreBD,
                        cod_Sec_Acta = lst[i].COD_SECUENCIAL_ACTA, //si es 0 la direccion del archivo se obtendra de la tabla DOC:BITACORA_SUPERVISIONES_DETALLE
                        nombreBDAntiguo = lst[i].NOMBRE_ARCH_ANTIGUO,
                        codGuiId=lst[i].COD_GUID
                    });
                }
                result.success = true;
            }
            catch (Exception)
            {

                result.success = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteItemActaId(string codGuiId)
        {
            try
            {
                CEntidad oCEntBitacora = (CEntidad)Session["EntBitacora"];
                var lst = oCEntBitacora.ListBitacoras;
                //CEntidad entidadDelete= oCEntBitacora.ListBitacoras.
                return Json(new { success = true, msj = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false ,msj=""}, JsonRequestBehavior.AllowGet) ;
            }
        }
        public JsonResult btngrvInfraccionesEliSD_Click(VModel objVM)
        {
            ListResult result = new ListResult();
            try
            {
                int ListIndex = objVM.ListIndex;
                var oCEntBitacora = (CEntidad)Session["EntBitacora"];
                Int32 RegEstado = oCEntBitacora.ListBEXT[ListIndex].RegEstado;
                if (oCEntBitacora.ListEliTABLA == null)
                {
                    oCEntBitacora.ListEliTABLA = new List<CEntidad>();
                }
                if (RegEstado == 0 || RegEstado == 2)
                {
                    CEntidad oCampos = new CEntidad();
                    oCampos.EliTABLA = "BITACORA_BALANCE";
                    oCampos.COD_BITACORA = oCEntBitacora.COD_BITACORA;
                    oCampos.COD_THABILITANTE = oCEntBitacora.ListBEXT[ListIndex].COD_THABILITANTE;
                    oCampos.NUM_POA = oCEntBitacora.ListBEXT[ListIndex].NUM_POA;
                    oCampos.COD_ESPECIES = oCEntBitacora.ListBEXT[ListIndex].COD_ESPECIES.ToString();
                    oCampos.COD_SECUENCIAL = oCEntBitacora.ListBEXT[ListIndex].COD_SECUENCIAL;
                    oCampos.COD_CNOTIFICACION = oCEntBitacora.COD_CNOTIFICACION;
                    oCampos.RegEstado = 0;
                    oCEntBitacora.ListEliTABLA.Add(oCampos);
                }
                oCEntBitacora.ListBEXT.RemoveAt(ListIndex);
                Session["EntBitacora"] = oCEntBitacora;
                result.success = true;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ItemRegistroGrabar(CEntidad cn)
        {
            //String OUTPUTPARAM = null;
            ListResult result = new ListResult();
            try
            {
                CLogica oCLogica = new CLogica();
                CEntidad oCEntBitacora = new CEntidad();
                oCEntBitacora = (CEntidad)Session["EntBitacora"];
                CLogica objLog = new CLogica();

                if (oCEntBitacora.ListInformeDetSupervisor.Count() > 0 && oCEntBitacora.ListBitacoras.Count() > 0)
                {
                    GuardarArchivoInfoGeo();
                    oCEntBitacora.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;

                }

            }
            catch (Exception)
            {

                result.success = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void GuardarArchivoInfoGeo()
        {
            Utilitarios HerUtil = new Utilitarios();
            CEntidad oCEntBitacora = new CEntidad();
            oCEntBitacora = (CEntidad)Session["EntBitacora"];
            try
            {
                DateTime fechaDir;
                string path = "", filename = "";
                int existeArch = 0; //[0: NO, 1:SI y 2:Mensaje enviado]
                for (int i = 0; i < oCEntBitacora.ListBitacoras.Count; i++)
                {
                    for (int j = 0; j < oCEntBitacora.ListBitacoras[i].ListInfoGeo.Count; j++)
                    {
                        if (oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].RegEstado == 1)
                        {
                            if (existeArch != 2) existeArch = 1;
                            //Datos del archivo a guardar
                            fechaDir = Convert.ToDateTime(oCEntBitacora.FECHA_SALIDA);
                            path = "Regreso\\" + "RETORNO_" + fechaDir.Year.ToString() + "\\" + HerUtil.MesNombre(fechaDir.Month).ToString() + "\\" + GetDirectorioSupervisores();
                            filename = oCEntBitacora.ListBitacoras[i].NUM_THABILITANTE.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                            filename = filename.Length >= 15 ? filename.Substring(filename.Length - 15, 15) : filename;
                            filename += oCEntBitacora.ListBitacoras[i].POAS == "" ? "" : ("_" + oCEntBitacora.ListBitacoras[i].POAS);

                            DateTime fechaActual = DateTime.Now;
                            filename += "_" + fechaActual.Year.ToString() + fechaActual.Month.ToString("00") + fechaActual.Day.ToString("00") + fechaActual.Hour.ToString("00") + fechaActual.Minute.ToString("00") + fechaActual.Second.ToString("00") + fechaActual.Millisecond.ToString("000") + j.ToString();
                            filename += "." + oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].EXTENSION_ARCH;

                            oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].RUTA_ARCH = SubirArchivoInfoGeo((HttpPostedFile)oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].FILE, path, filename);
                            if (oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].RUTA_ARCH == "0")
                            {
                                oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].NOMBRE_ARCH = "";
                                oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].EXTENSION_ARCH = "";
                                oCEntBitacora.ListBitacoras[i].ListInfoGeo[j].RUTA_ARCH = "";
                            }
                        }
                    }
                    if (existeArch == 1)
                    {
                        //HerUtil.MensajeBox(udpItemSupervisor, "Subiendo archivo(s)...", eMensajeTipo.Msginfo);
                        existeArch = 2;
                    }
                }
                //Session["EntBitacora"] = oCEntBitacora;
            }
            catch (Exception)
            {
                //HerUtil.MensajeBox(udpItemSupervisor, ex.Message, eMensajeTipo.Msgerror);
            }

        }

        public string GetDirectorioSupervisores()
        {
            CEntidad oCEntBitacora = new CEntidad();
            string path = "";
            string dirSup = "";
            foreach (var superv in oCEntBitacora.ListInformeDetSupervisor)
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

        public string SubirArchivoInfoGeo(HttpPostedFile file, string path, string filename)
        {
            try
            {
                String RutaGeoBITACORA = "~/Ruta_REPO_Geo";
                // Se carga la ruta física de la carpeta temp del sitio
                string rutaBase = Server.MapPath(RutaGeoBITACORA) + "\\" + path;
                //string rutaBase = "@\\srvfs01\\OTI\\GBD_GEO\\" + path;

                // Si el directorio no existe, crearlo
                if (!Directory.Exists(rutaBase))
                    Directory.CreateDirectory(rutaBase + "\\Historico");

                string archivo = String.Format("{0}\\{1}", rutaBase, filename);

                // Verificar que el archivo no exista
                if (System.IO.File.Exists(archivo))
                {
                    archivo = "0";
                }
                else
                {
                    file.SaveAs(archivo);
                }

                return archivo;
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public JsonResult btnItemConfirmar_Click(CEntidad entidad)
        {
            String[] correos;
            String msjLog = "";
            String OUTPUTPARAM = null;
            String OUTPUTPARAM01 = "";
            ListResult result = new ListResult();
            Utilitarios HerUtil = new Utilitarios();
            CLogica oCLogica = new CLogica();
            CEntidad oCEntBitacora = new CEntidad();
            oCEntBitacora = (CEntidad)Session["EntBitacora"];
            if ((Boolean)oCEntBitacora.ENVIAR_ALERTA)
            {
                if (oCEntBitacora.ListBEXT != null && oCEntBitacora.ListBEXT.Count > 0)
                {
                    //para guardar la lista de especies del balance
                    OUTPUTPARAM01 = oCLogica.RegGrabarBitacoraBXConfirmacion(oCEntBitacora);
                    result.data = OUTPUTPARAM01;
                }

                if (OUTPUTPARAM01 == "")
                {
                    result.msj = ("El envio de la alerta no es posible porque ya fue enviada anteriormente, revise el campo 'Fecha y hora de envio de la alerta'");
                    result.success = false;
                }

                if (OUTPUTPARAM01 != "")
                {
                    //ItemRegistroLimpiar(); //se ejecuta por js
                    result.msj = ("Se actualizo el balance de la Alerta");
                    //en caso de ser este caso retora a la vista principal
                    result.success = true;
                }
            }
            else
            {
                if ((Boolean)entidad.ENVIAR_ALERTA)
                {
                    String RutaBITACORA = "~/Archivos/Archivo_Bitacora/";
                    string pathArchivoAntiguo = "";
                    List<Attachment> lstAttachment = new List<Attachment>();

                    var lstBitacora = oCEntBitacora.ListBitacoras;
                    string var_nombreBD = "";
                    string var_descripcionBD = "";

                    for (int i = 0; i < lstBitacora.Count; i++)
                    {
                        var_nombreBD = lstBitacora[i].COD_BITACORA + lstBitacora[i].COD_SECUENCIAL_ACTA.ToString() + "." + lstBitacora[i].EXTENSION_ARCH;
                        var_descripcionBD = lstBitacora[i].NOMBRE_ARCH + "." + lstBitacora[i].EXTENSION_ARCH;
                        if (lstBitacora[i].NOMBRE_ARCH_ANTIGUO.Trim() != "")
                        {
                            pathArchivoAntiguo = lstBitacora[i].NOMBRE_ARCH_ANTIGUO.Trim();
                            if (System.IO.File.Exists(Server.MapPath(RutaBITACORA) + pathArchivoAntiguo))
                            {
                                lstAttachment.Add(new Attachment(Server.MapPath(RutaBITACORA) + pathArchivoAntiguo));
                            }
                        }
                        else
                        {
                            if (System.IO.File.Exists(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/") + var_nombreBD)) {
                                Attachment attachment = new Attachment(Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/") + var_nombreBD);
                                attachment.Name = var_descripcionBD;
                                lstAttachment.Add(attachment);
                            }
                        }
                    }
                    //registrando archivo oficio
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/Temp/"), oCEntBitacora.ARCHIVO_OFICIO)))
                    {    //moviendo archivos a la carpeta 
                        System.IO.File.Copy(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/Temp/"), oCEntBitacora.ARCHIVO_OFICIO), Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/"), oCEntBitacora.ARCHIVO_OFICIO));
                        Attachment attachment = new Attachment(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/") + oCEntBitacora.ARCHIVO_OFICIO);
                        attachment.Name = oCEntBitacora.ARCHIVO_OFICIO_TEXT;
                        lstAttachment.Add(attachment);
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/Temp/"), oCEntBitacora.ARCHIVO_OFICIO));
                    }
                    //correos =new string[] { "consultorusfs10@osinfor.gob.pe", "consultorusfs14@osinfor.gob.pe" , "consultorusfs16@osinfor.gob.pe" };
                    correos = entidad.DESTINO_ENVIO_ALERTA.Trim().Split(';');
                    //correos = ("epimentel@osinfor.gob.pe;epimentel@osinfor.gob.pe;epimentel@osinfor.gob.pe;epimentel@osinfor.gob.pe;epimentel@osifor.gob.pe;epimentel@osinfor.gob.pe;epimentel@osinfor.gob.pe").Split(';');
                    msjLog = "<table><thead><tr><th>Destinatario</th><th>Estado envio correo</th></tr></thead><tbody>";
                    foreach (var correo in correos)
                    {
                        try
                        {                          
                            //Configuración del Mensaje
                            SmtpClient smtpClient = new SmtpClient();
                            MailMessage message = new MailMessage();
                            MailAddress fromAddress = new MailAddress("sigo@osinfor.gob.pe", "SIGO");

                            smtpClient.Host = "10.10.11.9";
                            smtpClient.Port = 25;
                            //smtpClient.Credentials = new System.Net.NetworkCredential("consultorusfs14@osinfor.gob.pe", "*2021*Orty");                      
                            smtpClient.UseDefaultCredentials = true;

                            message.From = fromAddress;
                            message.To.Add(correo);
                            message.CC.Add("sigo@osinfor.gob.pe");
                            message.Subject = entidad.ASUNTO_ENVIO_ALERTA.Trim();
                            message.Body = entidad.MENSAJE_ENVIO_ALERTA.Trim();
                            message.IsBodyHtml = true;

                            foreach (var itemArchivo in lstAttachment)
                            {
                                message.Attachments.Add(itemArchivo);
                            }

                            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                            //enviando correo
                            smtpClient.Send(message); 
                            //message.Dispose();                            

                            msjLog += "<tr><td>" + correo + "</td><td>Mensaje enviado</td></tr>";
                        }
                        catch (Exception ex)
                        {                            
                            msjLog += "<tr><td>" + correo + "</td><td>" + ex.Message + "</td></tr>";
                           
                        }
                    }
                    msjLog += "</tbody></table>";
                    try
                    {
                        
                        //Configuración del Mensaje
                        SmtpClient smtpClient = new SmtpClient();
                        MailMessage message = new MailMessage();
                        MailAddress fromAddress = new MailAddress("sigo@osinfor.gob.pe", "SIGO");
                        //MailAddress fromAddress = new MailAddress("consultorusfs14@osinfor.gob.pe", "SIGO");

                        smtpClient.Host = "10.10.11.9";
                        smtpClient.Port = 25;
                        //smtpClient.Credentials = new System.Net.NetworkCredential("consultorusfs14@osinfor.gob.pe", "*2021*Orty");
                        smtpClient.UseDefaultCredentials = true;

                        message.From = fromAddress;
                        //correos = new string[] { "consultorusfs10@osinfor.gob.pe", "consultorusfs14@osinfor.gob.pe", "consultorusfs16@osinfor.gob.pe" };
                        correos = entidad.CONCOPIA_ENVIO_ALERTA.Trim().Split(';');
                        foreach (var correo in correos)
                        {
                            message.To.Add(correo);
                        }

                        message.Subject = "Resumen " + entidad.ASUNTO_ENVIO_ALERTA.Trim() + " " + entidad.NUM_THABILITANTE + " " + entidad.POA;//Aquí ponemos el asunto del correo                    
                        message.Body = entidad.MENSAJE_ENVIO_ALERTA.Trim() + "<div>Resumen de Envíos:</div><div>" + msjLog + "</div>";//Aquí ponemos el mensaje que incluirá el correo
                        message.IsBodyHtml = true;

                        foreach (var itemArchivo in lstAttachment)
                        {
                            message.Attachments.Add(itemArchivo);
                        }

                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //enviando correo
                        smtpClient.Send(message);
                        //message.Dispose();
                        
                        oCEntBitacora.COD_UCUENTA_ENVIA = (ModelSession.GetSession())[0].COD_UCUENTA;
                        oCEntBitacora.NUM_CNOTIFICACION = null;
                        oCEntBitacora.NUM_THABILITANTE = null;
                        oCEntBitacora.ESTADO_ARCHIVO_OFICIO = null;
                        oCEntBitacora.MODALIDAD = null;
                        oCEntBitacora.TITULAR = null;
                        oCEntBitacora.POA = null;
                        oCEntBitacora.UBICACION = null;
                        oCEntBitacora.SUPERVISOR = null;
                        oCEntBitacora.ListVertices = null;
                        oCEntBitacora.FECHA_ENVIO_ALERTA = null;
                        oCEntBitacora.USUARIO_ENVIA = null;
                        oCEntBitacora.FECHA_SALIDA = null;
                        oCEntBitacora.FECHA_LLEGADA = null;
                        oCEntBitacora.SUPUESTO = null;
                        oCEntBitacora.ENVIAR_ALERTA = entidad.ENVIAR_ALERTA; //jose
                        oCEntBitacora.COD_SUPUESTO = entidad.COD_SUPUESTO;
                        oCEntBitacora.ASUNTO_ENVIO_ALERTA = entidad.ASUNTO_ENVIO_ALERTA.Trim();
                        oCEntBitacora.DESTINO_ENVIO_ALERTA = entidad.DESTINO_ENVIO_ALERTA.Trim();
                        oCEntBitacora.DESTINO_ENVIO_TEXT = entidad.DESTINO_ENVIO_TEXT.Trim();
                        oCEntBitacora.CONCOPIA_ENVIO_ALERTA = entidad.CONCOPIA_ENVIO_ALERTA.Trim();
                        oCEntBitacora.LOG_ENVIO_ALERTA = msjLog;
                        oCEntBitacora.MENSAJE_ENVIO_ALERTA = entidad.MENSAJE_ENVIO_ALERTA.Trim() + "<div>Resumen de Envios:</div><div>" + msjLog + "</div>";
                        oCEntBitacora.ACTA_ARCHIVO_TEXT = Server.MapPath(RutaBITACORA) + oCEntBitacora.ACTA_ARCHIVO;
                        //oCEntBitacora.ACTA_ARCHIVO_TEXT = "C:\\inetpub\\wwwroot\\fiscalizacion\\Archivos\\Archivo_Bitacora\\Bitacora2016913123438434.pdf";
                        oCEntBitacora.ACTA_ARCHIVO = null;
                        oCEntBitacora.ListBEXT = entidad.ListBEXT;                       
                        oCEntBitacora.ListEliTABLA= entidad.ListEliTABLA;

                        if (oCEntBitacora.ListBEXT != null && oCEntBitacora.ListBEXT.Count > 0)
                        {
                            OUTPUTPARAM01 = oCLogica.RegGrabarBitacoraBXConfirmacion(oCEntBitacora);//para guardar la lista de especies del balance 
                        }

                        if(oCEntBitacora.ListEliTABLA!=null && oCEntBitacora.ListEliTABLA.Count > 0)
                        {
                            OUTPUTPARAM01 = oCLogica.RegGrabarBitacoraBXConfirmacion(oCEntBitacora);
                        }

                        OUTPUTPARAM = oCLogica.RegEnviarAlerta(oCEntBitacora);
                        result.success = true;
                        result.msj = "Se envió la alerta a los destinatarios indicados, por favor revise el correo resumen";
                    }
                    catch (Exception ex)
                    {
                        result.success = false;
                        result.msj = ex.Message;
                    }
                    
                }
                else
                {
                    result.success = false;
                    result.msj = "Para poder enviar alertas hay que seleccionar la opcion (seleccionar alerta)";
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllRutaDestino(string busCriterio, string cod_departamentos, string supuesto)
        {
            //ListResult result = new ListResult();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            //try
            //{
                CEntidad oCampos = new CEntidad();
                oCampos.BUSVALOR = cod_departamentos;
                oCampos.BUSCRITERIO = busCriterio;
                oCampos.SUPUESTO = supuesto;
                CapaLogica.DOC.Log_Alerta logB = new CapaLogica.DOC.Log_Alerta();
                result = logB.GetAllRutaDestino(oCampos);
            //}
            //catch (Exception)
            //{
            //    //result.success = false;
            //}
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult _ItemRegRespuesta(string token)
        {
            CLogica objLog = new CLogica();
            CEntidad result;
            ViewBag.TOKEN = token != null ? token : "";
            result = objLog.GetRegRespuesta(token); ;
            ViewBag.COD_BITACORA = result.ListRptaEnlace.Count > 0 ? result.ListRptaEnlace[0].COD_BITACORA : "";
            ViewBag.COD_THABILITANTE = result.ListRptaEnlace.Count > 0 ? result.ListRptaEnlace[0].COD_THABILITANTE : "";
            ViewBag.COD_SECUENCIAL = result.ListRptaEnlace.Count > 0 ? result.ListRptaEnlace[0].COD_SECUENCIAL : 0;
            ViewBag.CORREO = result.ListRptaEnlace.Count > 0 ? result.ListRptaEnlace[0].DESTINATARIO : "";
            

            return View();
        }

        [RequiredAuthenticationFilter(Check = false)]
        [HttpPost]        
        public JsonResult saveRptaEnlace(VModel dto)
        {

            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = "SIGOLINK";
            resultado = objLog.GuardarRptaEnlace(dto, codUCuenta);
            return Json(resultado);
        }

    }
    
}