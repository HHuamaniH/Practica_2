using CapaEntidad.DOC;
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
using System.Net;
using System.Web.Mvc;
using SIGOFCv3.Areas.THabilitante.Models.ManPlanManejoForestal;
using CEntidad = CapaEntidad.DOC.Ent_PLAN_MANEJO;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManPlanManejoForestalController : Controller
    {
        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        // GET: THabilitante/ManPlanManejoForestal
        public ActionResult Index(int opt = 0)
        {
            if (opt == 0)
            {
                ViewBag.thTipoFrmulario = "PLAN_GENERAL_MANEJO_FORESTAL";
                ViewBag.thBusFormulario = "PLAN_GENERAL_MANEJO_FORESTAL";
                ViewBag.thTitleMenu = "Plan General de Manejo Forestal - PGMF";
            }
            else
            {
                ViewBag.thTipoFrmulario = "PLAN_MANEJO_FORESTAL_INTERMEDIO";
                ViewBag.thBusFormulario = "PLAN_MANEJO_FORESTAL_INTERMEDIO";
                ViewBag.thTitleMenu = "Plan General de Manejo Forestal - PMFI";
            }
            ViewBag.thBusCriterio = "TODOS";
            ViewBag.hdfTipoFormulario = "0";
            ViewBag.thEsPMFI = opt;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Plan General de Manejo Forestal");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpGet]
        public ActionResult AddEdit()
        {
            try
            {
                string codPlanManejo = "", codTHabilitante = "", numResolucionOM = "";
                int opt = 0;
                Int16 opRegresar = 0;
                string appClient = Request.QueryString["appClient"]; string appData = Request.QueryString["appData"];
                if (appClient != null && appData != null)
                {
                    opt = Request.QueryString["opt"] == null ? 0 : Convert.ToInt32(Request.QueryString["opt"]);
                    if (appClient.Split('|')[1] == "TRANSFERIR")
                    {
                        //ItemRegistroNuevo(appClient, appData);
                        codTHabilitante = appData.Split('¬')[3];
                        numResolucionOM = appData.Split('¬')[5];
                    }
                    else if (appClient.Split('|')[1] == "VISUALIZAR")
                    {
                        codPlanManejo = appData.Split('¬')[3];
                    }
                    opRegresar = 1;
                }
                else
                {
                    codPlanManejo = Request.QueryString["cod_PM"];
                    opt = Request.QueryString["opt"] == null ? 0 : Convert.ToInt32(Request.QueryString["opt"]);
                }
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Plan General de Manejo Forestal");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                VM_PlanManejoGeneral VM_PM;
                Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
                VM_PM = objLog.IniDatosPlanManejoGeneral(codPlanManejo, (ModelSession.GetSession())[0].COD_UCUENTA, opt, codTHabilitante, numResolucionOM,mr.VALIAS);
                if (appData != null)
                {
                    if (appData.Split('¬')[2] == "0404")
                        VM_PM.codTipoPlan = "PMFI";
                }
                TempData["ListTHabilitante"] = VM_PM.ListTHabilitante;
                TempData["listaEspecies"] = VM_PM.ListEspecies;
                TempData["listaCoordenada"] = VM_PM.ListCoordenadas;
                TempData["listaEspeciesFauna"] = VM_PM.ListEspeciesFauna;
                VM_PM.appClient = appClient;
                VM_PM.appData = appData;
                VM_PM.opRegresar = opRegresar;
                VM_PM.ListEspecies = null;
                VM_PM.ListCoordenadas = null;
                VM_PM.ListEspeciesFauna = null;
                VM_PM.ListTHabilitante = null;
                
                return View(VM_PM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC: " + ex.ToString(), "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public JsonResult ValidarResolucionPGMF(string COD_PGMF, string NUMERO_PGMF, string estado)
        {
            try
            {
                COD_PGMF = COD_PGMF == null ? "" : COD_PGMF;
                Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
                string paramReturn = objLog.ValidarResolucionPGMFV3(COD_PGMF, NUMERO_PGMF, estado);
                return Json(new { success = true, paramReturn = paramReturn }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddEdit(VM_PlanManejoGeneral dto)
        {
            Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
            ListResult resultado;
            resultado = objLog.GuardarPlanManejoForestal(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }
        public ActionResult _EspeciesAprobadas(int numBloque = 0, int esPMFI = 0)
        {
            VM_ESPECIE_APROBADAS VM_E;
            Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
            VM_E = objLog.IniDatosEspecies(numBloque, esPMFI);
            return PartialView(VM_E);
        }
        public ActionResult _EspeciesFaunaS()
        {
            VM_ESPECIE_FS VM_EFS;
            Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
            VM_EFS = objLog.IniDatosEspeciesFS();
            return PartialView(VM_EFS);
        }
        public ActionResult _Coordenadas()
        {
            return PartialView();
        }
        public JsonResult GetAllEpeciesPM()
        {
            List<Ent_PLAN_MANEJO> data = (List<Ent_PLAN_MANEJO>)TempData["listaEspecies"];
            data = data ?? new List<Ent_PLAN_MANEJO>();
            var result = from e in data select new { codSec = e.COD_SECUENCIAL, des = e.DESCRIPCION, numArb = e.NUM_ARBOLES, vol = e.VOLUMEN, numB = e.NUM_BLOQUES, itemE = e.RegEstado, codEsp = e.COD_ESPECIES, descB = e.DESC_BLOQUE, tipomaderable = e.TIPOMADERABLE, unidadMedida = e.UNIDAD_MEDIDA };
            var jsonResult = Json(new { data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetAllCoordenadasPM()
        {
            List<Ent_PLAN_MANEJO> data = (List<Ent_PLAN_MANEJO>)TempData["listaCoordenada"];
            data = data ?? new List<Ent_PLAN_MANEJO>();
            var result = from c in data select new { codSec = c.COD_SECUENCIAL, vert = c.VERTICE, coE = c.COORDENADA_ESTE, coN = c.COORDENADA_NORTE, obs = c.OBSERVACIONES, itemE = c.RegEstado };
            var jsonResult = Json(new { data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetAllEspeciesFaunaPM()
        {
            List<Ent_PLAN_MANEJO> data = (List<Ent_PLAN_MANEJO>)TempData["listaEspeciesFauna"];
            data = data ?? new List<Ent_PLAN_MANEJO>();
            var result = from c in data select new { codSec = c.COD_SECUENCIAL, desc = c.DESCRIPCION, desAm = c.DESC_AMENAZA, obs = c.OBSERVACIONES, itemE = c.RegEstado, codE = c.COD_ESPECIES, codA = c.COD_AMENAZA };
            var jsonResult = Json(new { data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetAllTHabilitantePM()
        {
            List<Ent_PLAN_MANEJO> data = (List<Ent_PLAN_MANEJO>)TempData["ListTHabilitante"];
            data = data ?? new List<Ent_PLAN_MANEJO>();
            int i = 1;
            var result = from t in data
                         select new
                         {
                             itemE = t.RegEstado,
                             cod = t.COD_THABILITANTE,
                             desc = t.DESCRIPCION,
                             mod = t.MODALIDAD,
                             pt = t.PERSONA_TITULAR,
                             codOr = t.COD_OD_REGISTRO,
                             dl = t.D_LINEA,
                             ind = i++
                         };
            var jsonResult = Json(new { data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult buscarTHabilitante(string hdfFormulario, string busCriterio, string busValor)
        {
            try
            {
                Ent_PLAN_MANEJO oCampos = new Ent_PLAN_MANEJO();
                Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
                oCampos.BusFormulario = hdfFormulario;
                oCampos.BusCriterio = busCriterio;
                oCampos.BusValor = busValor;
                List<Ent_PLAN_MANEJO> listado = objLog.LogTitulo(oCampos);
                int i = 1;
                var result = from t in listado
                             select new
                             {
                                 cod = t.CODIGO,
                                 desc = t.DESCRIPCION,
                                 mod = t.MODALIDAD,
                                 pt = t.PERSONA_TITULAR,
                                 codOr = t.COD_OD_REGISTRO,
                                 dl = t.D_LINEA,
                                 ind = i++
                             };
                var jsonResult = Json(new { data = result, s = true, e = "" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", s = false, e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DownloadPGMF(int opt = 0)
        {
            //obteniendo data
            List<String[]> listResult = new List<String[]>();
            Log_THABILITANTE logThabilitante = new Log_THABILITANTE();
            //auditoria
            CapaEntidad.GENE.Ent_AUDITORIA auditoria = new CapaEntidad.GENE.Ent_AUDITORIA();
            auditoria.codCuentaUsuario = (ModelSession.GetSession())[0].COD_UCUENTA;
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            auditoria.hostName = Convert.ToString(ipEntry.HostName);
            auditoria.ipServer = Convert.ToString(ipEntry.AddressList[ipEntry.AddressList.Length - 1]);
            String ipClient = "";
            ipClient = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(ipClient)) { ipClient = Request.ServerVariables["REMOTE_ADDR"]; }
            auditoria.ipCliente = ipClient;
            string formulario = opt == 0 ? "PLAN_GENERAL_MANEJO_FORESTAL" : "";
            string criterio = "REPORTE_PGMF";
            listResult = logThabilitante.ListarTHabilitante(formulario, criterio, "", auditoria);


            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/PGMF.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                //*** Sheet 1
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                worksheet.Column(2).Style.Numberformat.Format = "yyyy-mm-dd";

                foreach (var item in listResult)
                {
                    worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                    worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item[1]; //DateTime.Parse(item[1]);
                    worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item[2];
                    worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = int.Parse(item[3]);
                    // worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Style.Numberformat.Format = "#";
                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item[4];
                    rowStart = rowStart + 1;
                }
                string modelRange = "A1:D" + (rowStart - 1).ToString();
                var modelTable = worksheet.Cells[modelRange];
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                // package.SaveAs(new FileInfo(Server.MapPath("~/Archivos/Plantilla/Paspeq/temp/demo.xlsx")));
                string excelName = "PGMF";
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

        [HttpPost]
        public JsonResult ImportarEspecieAprobada(string esPMFI, int numBloque)
        {
            List<CEntidad> olResult = new List<CEntidad>();

            try
            {
                if (Request != null)
                {
                    olResult = ImportarDatos.Especies_Aprobadas(Request, esPMFI, numBloque);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = olResult.ToArray() });
        }

        [HttpPost]
        public JsonResult ImportarCoordenada()
        {
            List<CEntidad> olResult = new List<CEntidad>();

            try
            {
                if (Request != null)
                {
                    olResult = ImportarDatos.Coordenada(Request);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = olResult.ToArray() });
        }

        [HttpPost]
        public JsonResult ImportarEspecieFS()
        {
            List<CEntidad> olResult = new List<CEntidad>();

            try
            {
                if (Request != null)
                {
                    olResult = ImportarDatos.EspecieFS(Request);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = olResult.ToArray() });
        }

        ///CARR 17.08.2021 exportar
        [HttpPost]
        public JsonResult ExportarExcel(string TVentana, string COD_PGMF)
        {
            object result = new object();
          //  string nomPlantilla = "";
            VM_PlanManejoGeneral VM_PM;
            Log_PLAN_MANEJO objLog = new Log_PLAN_MANEJO();
            VM_PM = objLog.IniDatosPlanManejoGeneral(COD_PGMF, (ModelSession.GetSession())[0].COD_UCUENTA, 0, "", "");
            List<Ent_PLAN_MANEJO> listParam = new List<Ent_PLAN_MANEJO>();

            switch (TVentana)
            {
                case "ESPECIE":
                    listParam = new List<Ent_PLAN_MANEJO>();
                    if (VM_PM.ListEspecies.Count > 0)
                    {
                        listParam = VM_PM.ListEspecies;
                        result = objLog.DescargaExceles("EspeciesAprobadas.xlsx", listParam);
                    }
                    else
                    {

                        var resultado = new { sds = "" };
                        return Json(new { success = false, msj = "no tiene data" });
                    }

                    break;
                case "COORDENADAS":
                    listParam = new List<Ent_PLAN_MANEJO>();
                    if (VM_PM.ListCoordenadas.Count > 0)
                    {
                        listParam = VM_PM.ListCoordenadas;
                        result = objLog.DescargaExceles("VerticesPMForestal.xlsx", listParam);
                    }
                    else
                    {

                        var resultado = new { sds = "" };
                        return Json(new { success = false, msj = "no tiene data" });
                    }
                    break;
                case "FAUNA":
                    listParam = new List<Ent_PLAN_MANEJO>();
                    if (VM_PM.ListEspeciesFauna.Count > 0)
                    {
                        listParam = VM_PM.ListEspeciesFauna;
                        result = objLog.DescargaExceles("EspeciesFS.xlsx", listParam);
                    }
                    else
                    {

                        var resultado = new { sds = "" };
                        return Json(new { success = false, msj = "no tiene data" });
                    }
                    break;
                    
            }
            return Json(result);
        }

        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult Download(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }

    }
}