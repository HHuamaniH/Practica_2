using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Areas.General.Controllers;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_PLAN_MANEJO;
using CLogica = CapaLogica.DOC.Log_PLAN_MANEJO;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManPlanManejoController : Controller
    {
        CLogica objLog;

        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        // GET: THabilitante/ManPlanManejo 
        [HttpGet]
        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "PLAN_MANEJO";
            ViewBag.TituloFormulario = "Plan de Manejo";
            ViewBag.AlertaInicial = _alertaIncial;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Plan de Manejo");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpGet]
        public ActionResult AddEditPM()
        {
            try
            {
                string codPM = "", codTH = "", modTH = "", numTH = "", tituTH = "", indi = "", cod_mtipo = "", resolucion_Num = "";
                string appClient = Request.QueryString["appClient"]; string appData = Request.QueryString["appData"];
                Int16 opRegresar = 0;
                objLog = new CLogica();
                if (appClient != null && appData != null)
                {
                    if (appClient.Split('|')[1] == "TRANSFERIR")
                    {
                        //ItemRegistroNuevo(-1, appClient, appData);
                        CEntidad oTh = new CEntidad();
                        oTh.BusFormulario = "TITULO_HABILITANTE";
                        oTh.BusCriterio = "PM_TH_NUMERO";
                        oTh.BusValor = appData.Split('¬')[4];
                        oTh = objLog.RegNuevoBuscar(oTh).Where(th => th.COD_THABILITANTE == appData.Split('¬')[3]).FirstOrDefault();
                        codTH = oTh.COD_THABILITANTE;
                        modTH = oTh.MODALIDAD; numTH = oTh.NUM_THABILITANTE;
                        tituTH = oTh.PERSONA; indi = oTh.INDICADOR;
                        cod_mtipo = oTh.COD_MTIPO;
                        resolucion_Num = appData.Split('¬')[5];
                    }
                    else if (appClient.Split('|')[1] == "VISUALIZAR")
                    {
                        // hdfAppClient.Value = appClient;
                        // hdfAppData.Value = appData;
                        // ItemRegistroModificar(new List<CEntidad>(), -1, appData.Split('|')[3]);
                        codPM = appData.Split('¬')[3];
                    }
                    opRegresar = 1;
                }
                else
                {
                    codPM = Request.QueryString["codPM"]; codTH = Request.QueryString["codTH"];
                    modTH = Request.QueryString["modTH"]; numTH = Request.QueryString["numTH"];
                    tituTH = Request.QueryString["tituTH"]; indi = Request.QueryString["indi"];
                    cod_mtipo = Request.QueryString["cod_mtipo"];
                }
                VM_PlanManejo VM_PM;
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Plan de Manejo");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                VM_PM = objLog.IniDatosPlanManejo(codPM, codTH, modTH, numTH, tituTH, indi, cod_mtipo, (ModelSession.GetSession())[0].COD_UCUENTA, resolucion_Num, mr.VALIAS);
                VM_PM.appClient = appClient;
                VM_PM.appData = appData;
                VM_PM.opRegresar = opRegresar;

               
                return View(VM_PM);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        [HttpPost]
        public JsonResult AddEditPM(VM_PlanManejo dto)
        {
            Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
            ListResult resultado;
            resultado = objLog.GuardarPlanManejo(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult DeletetPM(string codPM)
        {
            Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
            ListResult resultado;
            resultado = objLog.EliminarPlanManejo(codPM, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditExSitu(string codPM, string modTH, string numTH, string tituTH,
                                       string indi, string cod_mtipo)
        {
            try
            {
                VM_ExSitu VM_EX;
                objLog = new CLogica();
                VM_EX = objLog.IniDatosExSitu(codPM, modTH, numTH, tituTH, indi, cod_mtipo);
                return View(VM_EX);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public JsonResult GetAllPlanManejo(string busFormulario, string busCriterio, string busValor)
        {
            try
            {

                List<Dictionary<string, string>> ListPLAN_MANEJO = new List<Dictionary<string, string>>();
                objLog = new CLogica();
                CEntidad oCampos = new CEntidad();
                oCampos.BusFormulario = busFormulario;
                oCampos.BusCriterio = busCriterio;
                oCampos.BusValor = busValor.Trim();
                ListPLAN_MANEJO = objLog.RegMostrarPlanManejoList(oCampos);
                var jsonResult = Json(new { data = ListPLAN_MANEJO, success = true, e = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DownloadPlanManejo()
        {
            //obteniendo data
            List<Dictionary<string, string>> ListPLAN_MANEJO = new List<Dictionary<string, string>>();
            objLog = new CLogica();
            CEntidad oCampos = new CEntidad();
            oCampos.BusFormulario = "PLAN_MANEJO";
            oCampos.BusCriterio = "REPORTE";
            oCampos.BusValor = "";
            ListPLAN_MANEJO = objLog.RegMostrarPlanManejoList(oCampos);


            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/PManejo.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                //*** Sheet 1
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                worksheet.Column(2).Style.Numberformat.Format = "yyyy-mm-dd";
                foreach (var itemDictionary in ListPLAN_MANEJO)
                {
                    worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                    worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = DateTime.Parse(itemDictionary["FECHA"]);
                    worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = itemDictionary["PERSONA_TITULAR"];
                    worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = itemDictionary["ARESOLUCION_NUM"];
                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = itemDictionary["MODALIDAD"];
                    worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = itemDictionary["NUM_THABILITANTE"];
                    rowStart = rowStart + 1;
                    /* foreach (KeyValuePair<string, string> entry in itemDictionary)
                    // {


                     //}*/
                }
                string modelRange = "A1:F" + (rowStart - 1).ToString();
                var modelTable = worksheet.Cells[modelRange];
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                // package.SaveAs(new FileInfo(Server.MapPath("~/Archivos/Plantilla/Paspeq/temp/demo.xlsx")));
                string excelName = "planManejo";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResult
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        //obtiene los detalle del plan manejo general
        [HttpGet]
        public JsonResult GetAllItemsPlanManejo(string codPM)
        {
            objLog = new CLogica();
            try
            {
                var listado = objLog.GetPlanManejoListIdV3(codPM);
                var jsonResult = Json(new { data = listado, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult ListMComboCArea()
        {
            objLog = new CLogica();
            try
            {
                var listado = objLog.GetDatosComboV3("PLAN_MANEJO", "CondicionArea");
                var jsonResult = Json(new { data = listado, success = true }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //especies FAUNA EXSITU
        [HttpGet]
        public JsonResult ListEspecieFE()
        {
            objLog = new CLogica();
            try
            {
                var listado = objLog.GetDatosComboV3("PLAN_MANEJO", "Especie_Fauna");
                var jsonResult = Json(new { data = listado, success = true }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #region "Modales ESitu"
        [HttpGet]
        public ActionResult _ItemESituIAnual(string es, string codPM, string codSec)
        {
            objLog = new CLogica();
            var vm = objLog.InitEsituAnual(codPM, codSec, es);
            return PartialView(vm);
        }
        [HttpGet]
        public ActionResult _ItemESituPGenetico(string es, string codPM, string codSec)
        {
            objLog = new CLogica();
            var vm = objLog.InitEsituPGenetivo(codPM, codSec, es);
            return PartialView(vm);
        }
        [HttpGet]
        public ActionResult _Balance(string es, string codPM, string codSec, string tipo)
        {
            objLog = new CLogica();
            var vm = objLog.InitEsituBalance(codPM, codSec, es, tipo);
            return PartialView(vm);
        }
        [HttpPost]
        public JsonResult AddEditESituIAnual(VM_ExSituItem vm)
        {
            objLog = new CLogica();
            string codcuntaUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(objLog.AddEditESituIAnual(vm, codcuntaUsuario), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddEditESituPGenetico(VM_PGeneticoItem vm)
        {
            objLog = new CLogica();
            string codcuntaUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(objLog.AddEditESituPGenetico(vm, codcuntaUsuario), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddEditESituBalance(VM_BalanceItem vm)
        {
            objLog = new CLogica();
            string codcuntaUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(objLog.AddEditESituBalance(vm, codcuntaUsuario), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteExsitu(string codPM, string codS, string tipo, string codE = "")
        {
            objLog = new CLogica();
            return Json(objLog.DeleteExsitu(codPM, codS, tipo, codE), JsonRequestBehavior.AllowGet);
        }

        #region "Listados ExSitu"
        [HttpGet]
        public JsonResult GetAllExSituOpcion(string codPM, string busCriterio)
        {
            objLog = new CLogica();
            try
            {
                var listado = objLog.LogMostrarListaItemsESituV3(codPM, busCriterio);
                var jsonResult = Json(new { data = listado, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult GetListPGenetico(string COD_PMANEJO, string COD_PGSECUENCIAL)
        {

            try
            {
                CEntidad oCampoEspecie = new CEntidad();
                objLog = new CLogica();
                var lisRpt = objLog.PLAN_MANEJO_EXSITU_PGENETICO_MostItemV3(oCampoEspecie);
                var jsonResult = Json(new { data = lisRpt.Item1, data1 = lisRpt.Item2, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
        #endregion
        #region "Partial Plan Manejo"
        public ActionResult _pnlItemInSitu()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _CoordenadaUTM()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemTaraAEAprov()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemTaraPApro()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemTaraOpcion(string hdTaraOpionVentana)
        {
            //
            CEntidad oCampos = new CEntidad();
            oCampos.BusFormulario = "PLAN_MANEJO";
            oCampos.BusCriterio = "PLAN_MANEJO_TOPCIONES";
            objLog = new CLogica();
            List<CEntidad> ListMComboTaraOpciones = new List<CEntidad>();
            ListMComboTaraOpciones = objLog.RegMostComboTOpciones(oCampos);
            ViewBag.cboOpciones = from c in ListMComboTaraOpciones
                                  where c.TIPO == hdTaraOpionVentana
                                  select new { Value = c.CODIGO, Text = c.DESCRIPCION };
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemTaraAutoExtraer()
        {
            objLog = new CLogica();
            ViewBag.cboOpciones = objLog.GetDatosComboV3("PLAN_MANEJO", "AutoExtraer");
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemTaraInventario()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemEcotInforme()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _ItemISituCArea()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _InventarioFauna()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult _InventarioFlora()
        {
            objLog = new CLogica();
            ViewBag.cboOpciones = objLog.GetDatosComboV3("PLAN_MANEJO", "Especie_Flora", true);
            return PartialView();
        }

        #endregion
        #region "Excel"
        [HttpPost]
        public JsonResult ImportarExcelCUTM()
        {
            List<Dictionary<string, string>> lista = new List<Dictionary<string, string>>();
            bool success = true;
            string msj = "";
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            Dictionary<string, string> objVertice;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                validarFilaVertice(workSheet, rowIterator);
                                objVertice = new Dictionary<string, string>();
                                objVertice.Add("RegEstado", "1");
                                objVertice.Add("COD_SECUENCIAL", "0");
                                objVertice.Add("NUM_PARCELA", workSheet.Cells[rowIterator, 1].Value.ToString());
                                objVertice.Add("NUM_PUNTOS", workSheet.Cells[rowIterator, 2].Value.ToString());
                                objVertice.Add("COORDENADA_ESTE", workSheet.Cells[rowIterator, 3].Value.ToString());
                                objVertice.Add("COORDENADA_NORTE", workSheet.Cells[rowIterator, 4].Value.ToString());
                                objVertice.Add("OBSERVACION", workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString());
                                lista.Add(objVertice);
                                objVertice = null;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                else msj = ex.Message;
            }


            var jsonResult = Json(new { success = success, msj = msj, data = lista });
            jsonResult.MaxJsonLength = int.MaxValue;


            return jsonResult;

        }
        public void validarFilaVertice(ExcelWorksheet workSheet, int rowIterator)
        {
            if (workSheet.Cells[rowIterator, 1].Value == null || workSheet.Cells[rowIterator, 2].Value == null || workSheet.Cells[rowIterator, 3].Value == null || workSheet.Cells[rowIterator, 4].Value == null)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas PARCELAS, PUNTOS/VERTICES, COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            if (workSheet.Cells[rowIterator, 1].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 2].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 3].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 4].Value.ToString().Trim() == "")
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas PARCELAS, PUNTOS/VERTICES, COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            //validando si son numeros
            bool isNum;
            Int32 retNum;
            isNum = Int32.TryParse(Convert.ToString(workSheet.Cells[rowIterator, 3].Value.ToString()), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            if (!isNum)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADA_ESTE debe ser numero entero");
            }
            isNum = Int32.TryParse(Convert.ToString(workSheet.Cells[rowIterator, 4].Value.ToString()), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            if (!isNum)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_NORTE debe ser numero entero");
            }
            if (workSheet.Cells[rowIterator, 3].Value.ToString().Length > 6)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE debe ser numero entero maximo de 6 digitos");
            }
            if (workSheet.Cells[rowIterator, 4].Value.ToString().Length > 7)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE debe ser numero entero maximo de 7 digitos");
            }
            if (Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString()) < 0 || Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value.ToString()) < 0)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE y COORDENADAS_NORTE deben ser mayor o igual a 0");
            }

        }
        [HttpPost]
        public JsonResult ImportarExcelInventario()
        {
            List<Dictionary<string, string>> lista = new List<Dictionary<string, string>>();
            bool success = true;
            string msj = "";
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            Dictionary<string, string> objInventario;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                validarFilaInventario(workSheet, rowIterator);
                                objInventario = new Dictionary<string, string>();
                                objInventario.Add("RegEstado", "1");
                                objInventario.Add("COD_SECUENCIAL", "0");
                                objInventario.Add("N_ARBOL", workSheet.Cells[rowIterator, 1].Value.ToString());
                                objInventario.Add("CONDICION", workSheet.Cells[rowIterator, 2].Value.ToString());
                                objInventario.Add("ESTADO_FITOSAN", workSheet.Cells[rowIterator, 3].Value.ToString());
                                objInventario.Add("ALTURA_ESTIMADO", workSheet.Cells[rowIterator, 4].Value.ToString());
                                objInventario.Add("PESO_VAINAS_KILOGRAMOS", workSheet.Cells[rowIterator, 5].Value.ToString());
                                objInventario.Add("COORDENADA_ESTE", workSheet.Cells[rowIterator, 6].Value.ToString());
                                objInventario.Add("COORDENADA_NORTE", workSheet.Cells[rowIterator, 7].Value.ToString());
                                objInventario.Add("OBSERVACION", workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                lista.Add(objInventario);
                                objInventario = null;

                            }
                        }
                    }
                }
                if (lista.Count <= 0) throw new Exception("No existe items en el excel");
            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                else msj = ex.Message;
            }
            var jsonResult = Json(new { success = success, msj = msj, data = lista });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;


        }
        public void validarFilaInventario(ExcelWorksheet workSheet, int rowIterator)
        {
            if (workSheet.Cells[rowIterator, 1].Value == null || workSheet.Cells[rowIterator, 2].Value == null || workSheet.Cells[rowIterator, 3].Value == null
                || workSheet.Cells[rowIterator, 4].Value == null || workSheet.Cells[rowIterator, 5].Value == null || workSheet.Cells[rowIterator, 6].Value == null
                || workSheet.Cells[rowIterator, 7].Value == null)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas N_ARBOL, CONDICION, ESTADO_FITOSANITARIO, ALTURA_ESTIMADA, PESO VAINAS EN KG., COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            if (workSheet.Cells[rowIterator, 1].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 2].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 3].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 4].Value.ToString().Trim() == ""
                || workSheet.Cells[rowIterator, 5].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 6].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 7].Value.ToString().Trim() == "")
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas N_ARBOL, CONDICION, ESTADO_FITOSANITARIO, ALTURA_ESTIMADA, PESO VAINAS EN KG., COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            //validando si son numeros
            bool isNum;
            Int32 retNum;
            isNum = Int32.TryParse(Convert.ToString(workSheet.Cells[rowIterator, 6].Value.ToString()), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            if (!isNum)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADA_ESTE debe ser numero entero");
            }
            isNum = Int32.TryParse(Convert.ToString(workSheet.Cells[rowIterator, 7].Value.ToString()), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            if (!isNum)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_NORTE debe ser numero entero");
            }
            if (workSheet.Cells[rowIterator, 6].Value.ToString().Length > 6)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE debe ser numero entero maximo de 6 digitos");
            }
            if (workSheet.Cells[rowIterator, 7].Value.ToString().Length > 7)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE debe ser numero entero maximo de 7 digitos");
            }
            if (Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString()) < 0 || Convert.ToInt32(workSheet.Cells[rowIterator, 7].Value.ToString()) < 0)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE y COORDENADAS_NORTE deben ser mayor o igual a 0");
            }

        }
        #endregion
        [HttpGet]
        public JsonResult buscarTHabilitante(string vb)
        {
            try
            {
                string[] valBusqueda = vb.Split('¬');
                CEntidad oCampos = new CEntidad();
                objLog = new CLogica();
                oCampos.BusFormulario = "TITULO_HABILITANTE";
                oCampos.BusCriterio = valBusqueda[1];
                oCampos.BusValor = valBusqueda[2];
                List<CEntidad> listado = objLog.RegNuevoBuscar(oCampos);
                int i = 1;
                var result = from t in listado
                             select new
                             {
                                 cod = t.COD_THABILITANTE,
                                 nt = t.NUM_THABILITANTE,
                                 mod = t.MODALIDAD,
                                 pt = t.PERSONA,
                                 ind = t.INDICADOR,
                                 cod_mt = t.COD_MTIPO,
                                 num = i++
                             };
                var jsonResult = Json(new { data = result, success = true, e = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _ErrorMaterial()
        {
            return PartialView();
        }
    }
}