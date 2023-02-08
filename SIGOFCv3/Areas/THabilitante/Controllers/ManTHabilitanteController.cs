using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Reportes.THabilitante;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidadUC = CapaEntidad.GENE.Ent_USUARIO_CUENTA;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManTHabilitanteController : Controller
    {
        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        // GET: THabilitante/ManTHabilitante
        public ActionResult ManTHabilitanteV()
        {
            ViewBag.thTipoFrmulario = "TITULO_HABILITANTE";
            ViewBag.thBusFormulario = "TITULO_HABILITANTE";
            ViewBag.thTitleMenu = "Título Habilitante";
            ViewBag.thBusCriterio = "TODOS";
            ViewBag.hdfTipoFormulario = "1";
            //invocamos el rol del usuario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Título Habilitante");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                string codigoThabilitante = "", cboManModalidad = "", nombreTH = "";
                VM_THabilitante objVM;
                Log_THABILITANTE objLog = new Log_THABILITANTE();
                string appClient = Request.QueryString["appClient"]; string appData = Request.QueryString["appData"];
                Int16 opRegresar = 0;
                //invocamos el rol del usuario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Título Habilitante");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                if (appClient != null && appData != null)
                {//cuando se accede desde otro origen
                    if (appClient.Split('|')[1] == "TRANSFERIR")
                    {
                        if (appClient.Split('|')[2] == "ADENDA")
                        {
                            codigoThabilitante = appData.Split('¬')[3];
                        }
                        else
                        {
                            codigoThabilitante = "";
                            cboManModalidad = appData.Split('¬')[6];
                            nombreTH = appData.Split('¬')[3];

                        }
                    }
                    else if (appClient.Split('|')[1] == "VISUALIZAR")
                    {
                        codigoThabilitante = appData.Split('¬')[3];
                    }
                    opRegresar = 1;
                }
                else
                {//cuando es llamado desde mantenimiento de TH
                    codigoThabilitante = Request["codTH"];
                    cboManModalidad = Request["dtoMod"];
                    opRegresar = 0;
                }
                objVM = objLog.IniDatosTHabilitante(codigoThabilitante, (ModelSession.GetSession())[0].COD_UCUENTA, cboManModalidad, nombreTH);
                objVM.appClient = appClient;
                objVM.appData = appData;
                objVM.opRegresar = opRegresar;                
                TempData["listaTDDVVERTICE"] = objVM.ListTDDVVERTICE;
                objVM.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                //objVM.ListTDDVVERTICE = null;
                return View(objVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC: " + ex.ToString(), "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public JsonResult GetAllVertices()
        {
            List<Ent_THABILITANTE> data = (List<Ent_THABILITANTE>)TempData["listaTDDVVERTICE"];
            data = data ?? new List<Ent_THABILITANTE>();
            //devolviendo solo data requerida
            var lstMin = from cust in data
                         select new
                         {
                             VERTICE = cust.VERTICE,
                             ZONA = cust.ZONA,
                             COORDENADA_ESTE = cust.COORDENADA_ESTE,
                             COORDENADA_NORTE = cust.COORDENADA_NORTE,
                             OBSERVACION = cust.OBSERVACION,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             RegEstado = cust.RegEstado,
                             COD_SECUENCIAL_ADENDA = cust.COD_SECUENCIAL_ADENDA
                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult RegistrarThabilitante(VM_THabilitante dto)
        {
            Log_THABILITANTE objLog = new Log_THABILITANTE();
            ListResult resultado;
                resultado = objLog.GuardarDatosThabilitante(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }
        public ActionResult _PnlItemExsitu()
        {

            return PartialView();
        }
        public ActionResult _Recategorizacion()
        {
            return PartialView();
        }
        public ActionResult _PnlItemDGeneral()
        {
            return PartialView();
        }
        public ActionResult _PnlItemTitulares()
        {
            return PartialView();
        }
        public ActionResult _ListAdenda()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult Download(string file = "THabilitanteVertice.xlsx")
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadVertices(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpPost]
        public JsonResult ImportarDataExcel()
        {
            var lstVertice = new List<VM_THA_Vertice>();
            bool success = true;
            string msj = "";
            try
            {
                if (Request != null)
                {
                    Int32 iCodSecuencialAdenda = Convert.ToInt32(Request.Form["aiCodSecuencialAdenda"]);

                    HttpPostedFileBase file = Request.Files[0];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            var objVertice = new VM_THA_Vertice();
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                validarFilaVertice(workSheet, rowIterator);
                                objVertice = new VM_THA_Vertice();
                                objVertice.RegEstado = 1;
                                objVertice.COD_SECUENCIAL = 0;
                                objVertice.VERTICE = workSheet.Cells[rowIterator, 1].Value.ToString();
                                objVertice.ZONA = workSheet.Cells[rowIterator, 2].Value.ToString();
                                objVertice.COORDENADA_ESTE = Convert.ToDecimal(workSheet.Cells[rowIterator, 3].Value.ToString());
                                objVertice.COORDENADA_NORTE = Convert.ToDecimal(workSheet.Cells[rowIterator, 4].Value.ToString());
                                objVertice.OBSERVACION = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString();
                                objVertice.COD_SECUENCIAL_ADENDA = iCodSecuencialAdenda;
                                lstVertice.Add(objVertice);
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

            var jsonResult = Json(new { success = success, msj = msj, data = lstVertice });
            jsonResult.MaxJsonLength = int.MaxValue;


            return jsonResult;
        }
        public void validarFilaVertice(ExcelWorksheet workSheet, int rowIterator)
        {
            string[] zonaUTM = new string[] { "17S", "18S", "19S" };
            if (workSheet.Cells[rowIterator, 1].Value == null || workSheet.Cells[rowIterator, 2].Value == null || workSheet.Cells[rowIterator, 3].Value == null || workSheet.Cells[rowIterator, 4].Value == null)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas VERTICE, ZONA_UTM, COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            if (workSheet.Cells[rowIterator, 1].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 2].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 3].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 4].Value.ToString().Trim() == "")
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas VERTICE, ZONA_UTM, COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            if (!zonaUTM.Contains(workSheet.Cells[rowIterator, 2].Value.ToString()))
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores correctos solo pueden ser 17S, 18S y 19S en mayuscula");
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
        public JsonResult ExportarExcelVertices(string COD_THABILITANTE)
        {
            var result = ReporteTHabilitante.GenerarReporteVerticeTH(COD_THABILITANTE);
            return Json(result);
        }

        [HttpPost]
        public PartialViewResult _ErrorMaterial()
        {
            return PartialView();
        }
        
    }
}