using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManCorrecMandatoController : Controller
    {
        private Log_RESODIREC exeLogica;

        public ManCorrecMandatoController()
        {
            exeLogica = new Log_RESODIREC();
        }

        #region "Vista General"
        // GET: Supervision/ManCNotificacion
        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "SEGUIMIENTO_MEDIDA";
            ViewBag.TituloFormulario = "Seguimiento Medidas Correctivas/Mandatos";
            ViewBag.AlertaInicial = _alertaIncial;

            return View();
        }
        #endregion

        #region "Mantenimiento Correctivo"
        //public ActionResult AddEdit(string asCodResodirec)
        //{
        //    //ViewBag.hdasCodCCorrectivo = asCodCCorrectivo;
        //    try
        //    {
        //        VM_SeguimientoMedida vm = exeLogica.InitSeguimientoMedida(asCodResodirec);

        //        return View(vm);
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("ErrorC", "Login", new { Area = "" });
        //    }
        //}

        //[HttpPost]
        //public JsonResult AddEdit(CEntVM dto)
        //{
        //    CLogica exePCap = new CLogica();
        //    ListResult result = exePCap.GuardarDatosCNotificacion(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

        //    return Json(result);
        //}

        [HttpGet]
        public ActionResult _ItemNuevo()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult _modalInf()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _modalArchivo()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult _modalFisca(string hdfidCodTramite = "")
        {
            ViewBag.hdfidCodTramite = hdfidCodTramite;
            return PartialView();
        }

        //[HttpPost]
        //public JsonResult ExportarRegistroUsuario()
        //{
        //    ListResult result = new ListResult();

        //    result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

        //    return Json(result);
        //}

        //[HttpPost]
        //public JsonResult ConsultarExpediente(Tra_M_Tramite dto)
        //{
        //    CLogica_Denuncia exeInf = new CLogica_Denuncia();
        //    Tra_M_Tramite result = exeInf.ConsultarTramiteMandatos(dto);
        //    return Json(result);
        //}

        //[HttpPost]
        //public JsonResult selectExpedienteMC(Tra_M_Tramite dto)
        //{
        //    CLogicaR exeInf = new CLogicaR();
        //    List<Tra_M_Tramite> result = exeInf.selectExpedienteMC(dto);
        //    return Json(result);
        //}

        //[HttpPost]
        //public JsonResult guardarTramite(Tra_M_Tramite dto)
        //{
        //    CLogica_Denuncia exeInf = new CLogica_Denuncia();
        //    Tra_M_Tramite result = exeInf.guardarTramite(dto);
        //    return Json(result);
        //}

        public FileResult descargarArchivo(string ruta, string nombre, string mineType)
        {
            byte[] oBytes;
            string rut1a = string.Empty;
            try
            {
                rut1a = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\MCorrectivas\", ruta);
                oBytes = System.IO.File.ReadAllBytes(rut1a);
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                rut1a = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Content\images\General\", "Delete-file-icon.png");
                oBytes = System.IO.File.ReadAllBytes(rut1a);
                mineType = "image/png";
            }
            return File(oBytes, mineType, nombre);
        }

        //[HttpPost]
        //public JsonResult cambioEtadoTramite(Tra_M_Tramite dto)
        //{
        //    CLogica_Denuncia exeInf = new CLogica_Denuncia();
        //    Tra_M_Tramite result = exeInf.cambioEtadoTramite(dto);
        //    return Json(result);
        //}

        //[HttpPost]
        //public JsonResult SP_SELECT_MANDATOS(CEntidadR dto)
        //{
        //    CLogicaR exeInf = new CLogicaR();
        //    List<CEntidadR> result = new List<CEntidadR>(); //CLHC: exeInf.SP_SELECT_MANDATOS(dto);
        //    return Json(result);
        //}

        [HttpGet]
        public ActionResult _ItemExpMandato()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult _modalInfMa()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult SubirArchivo()
        {
            ArchivoMandato archivo = new ArchivoMandato();
            try
            {
                if (Request.Files.Count > 0)
                {
                    //archivo.ID = Path.GetFileName(Request.Files[0].FileName);
                    archivo.Archivos = new List<IMANDATO_SUPERVISION_ARCHIVOS>();
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\InfEvalMandatos\", fileName);
                            file.SaveAs(path);
                            path = path.Split(new[] { AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\InfEvalMandatos\" }, StringSplitOptions.None).Last();
                            IMANDATO_SUPERVISION_ARCHIVOS ar = new IMANDATO_SUPERVISION_ARCHIVOS();
                            ar.URLDIGITAL = path;
                            ar.ARCHIVO_EXTENSION = file.ContentType;
                            ar.URLNOMBRE = file.FileName;
                            archivo.Archivos.Add(ar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(archivo);
        }

        //public JsonResult GetAllPoaPo_Dema()
        //{
        //    var lstPoaPo_Dema = (List<CEntidad>)TempData["tbPoaPo_Dema"];

        //    var jsonResult = Json(new { data = lstPoaPo_Dema.ToArray() }, JsonRequestBehavior.AllowGet);
        //    jsonResult.MaxJsonLength = int.MaxValue;
        //    return jsonResult;
        //}

        [HttpPost]
        public JsonResult SubirArchivoData()
        {
            List<Archivo> archivoList = new List<Archivo>();
            try
            {
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Archivos\MCorrectivas\", fileName);
                            file.SaveAs(path);
                            Archivo archivoFile = new Archivo();
                            archivoFile.path = fileName;
                            archivoFile.mineType = file.ContentType;
                            archivoFile.mensaje = file.FileName;
                            archivoList.Add(archivoFile);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return Json(archivoList);
        }

        #endregion

        [HttpPost]
        public JsonResult ExportarTabla()
        {
            ListResult result = new ListResult();
            EpplusExcel epplus = new EpplusExcel();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            string nombre = "";

            try
            {
                paramsBus.BusFormulario = "SEGUIMIENTO_MEDIDA";
                paramsBus.BusCriterio = "";
                paramsBus.BusValor = "";
                paramsBus.pagesize = 10000;
                paramsBus.currentpage = 1;

                lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

                using (var excelPackage = new ExcelPackage())
                {
                    string OCLfolder = AppDomain.CurrentDomain.BaseDirectory + "Archivos/Plantilla/Reg_Usu/Temp/";
                    nombre = "Seguimiento_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
                    string savepath = OCLfolder + "/" + nombre;

                    System.IO.FileInfo strfilePath = new System.IO.FileInfo(savepath);
                    excelPackage.Workbook.Properties.Author = "SIGOsfc Beta";
                    excelPackage.Workbook.Properties.Title = "Seguimiento Medidas Correctivas/Mandatos";
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add("Listado");
                    _genericSheet.View.ZoomScale = 100;

                    List<string> _cabecera = new List<string>
                    {
                        "Titular",
                        "Título Habilitante",
                        "Modalidad",
                        "Nro. Resolución",
                        "Nro. Expediente"
                    };

                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, "Seguimiento Medidas Correctivas/Mandatos");
                    _genericSheet.Cells["A3:E3"].AutoFilter = true;
                    int rowIndex = 4;

                    foreach (var itemPart in lstResult)
                    {
                        int col = 1;
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["TITULAR"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUM_THABILITANTE"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["MODALIDAD"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUM_RESOLUCION"] ?? string.Empty);
                        epplus._texto_row(_genericSheet, rowIndex, col++, itemPart["NUM_EXPEDIENTE"] ?? string.Empty);
                        rowIndex++;
                    }

                    _genericSheet.View.FreezePanes(4, 2);
                    _genericSheet.Column(1).Width = 40.40;
                    _genericSheet.Column(2).Width = 40.40;
                    _genericSheet.Column(3).Width = 40.40;
                    _genericSheet.Column(4).Width = 40.40;
                    _genericSheet.Column(5).Width = 40.40;

                    byte[] bin = excelPackage.GetAsByteArray();
                    strfilePath.Directory.Create();
                    System.IO.File.WriteAllBytes(savepath, bin);
                }

                result.success = true;
                result.msj = nombre;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return Json(result);
        }
    }
}