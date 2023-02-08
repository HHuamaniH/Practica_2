using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
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
using CEntidad = CapaEntidad.DOC.Ent_InformeAutoridadForestal;
using CLogica = CapaLogica.DOC.Log_InformeAutoridadForestal;
using VModel = CapaEntidad.ViewModel.VM_InformeAutoridadForestal;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManInformeAutoridadForestalController : Controller
    {
        // GET: THabilitante/ManInformeAutoridadForestal
        [HttpGet]
        public ActionResult Index(int lstManMenu)
        {
            try
            {
                if (lstManMenu == 1)
                {
                    ViewBag.Formulario = "INFORME_AUT_FORESTAL";
                    ViewBag.TituloFormulario = "Informe de la Autoridad Forestal";
                    //obtenemos el rol sobre el formulario
                    VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Informe de Autoridad Forestal");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                if (lstManMenu == 2)
                {
                    ViewBag.Formulario = "OTROS_INFORMES";
                    ViewBag.TituloFormulario = "Otros Informes OSINFOR";
                    //obtenemos el rol sobre el formulario
                    VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Otros Informes OSINFOR");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                if (lstManMenu == 3)
                {
                    ViewBag.Formulario = "RENUNCIA_CONCESION";
                    ViewBag.TituloFormulario = "Formato de Solicitud de Renuncia a la Concesión";
                    //obtenemos el rol sobre el formulario
                    VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Formato de Solicitud de Renuncia a la Concesión");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC: " + ex.ToString(), "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public ActionResult AddEdit(string codigoDato, string codigoComplementario, int nuevo, string tipoFrmulario)
        {
            try
            {
                VM_Menu_Rol mr = new VM_Menu_Rol();
                switch (tipoFrmulario)
                {
                    case "INFORME_AUT_FORESTAL":
                        //obtenemos el rol sobre el formulario
                         mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Informe de Autoridad Forestal");
                        ViewBag.CodRol = mr.NCODROL;
                        ViewBag.VAliasRol = mr.VALIAS;
                        break;
                    case "RENUNCIA_CONCESION":
                        //obtenemos el rol sobre el formulario
                         mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Formato de Solicitud de Renuncia a la Concesión");
                        ViewBag.CodRol = mr.NCODROL;
                        ViewBag.VAliasRol = mr.VALIAS;
                        break;
                    case "OTROS_INFORMES":
                        //obtenemos el rol sobre el formulario
                        mr = HelperSigo.GetRol("MODULO SUPERVISION", "Otros Informes OSINFOR");
                        ViewBag.CodRol = mr.NCODROL;
                        ViewBag.VAliasRol = mr.VALIAS;
                        break;
                    default:
                        break;
                }
                
                VModel objVM;
                CLogica objLog = new CLogica();
                objVM = objLog.IniDatos(
                    codigoDato,
                    codigoComplementario,
                    (ModelSession.GetSession())[0].COD_UCUENTA,
                    (ModelSession.GetSession())[0].COD_UGRUPO,
                    nuevo,
                    tipoFrmulario
                 );
                objVM.TipoFormulario = tipoFrmulario;





                return View(objVM);


            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC: " + ex.ToString(), "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult ImportarDataExcel()
        {


            bool success = true;
            object retorna = new object();

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


                            //Recorriendo Datos
                            CEntidad oCampos;
                            //ListBusqueda<CEntidad> oListBus;     
                            string hdfItemExcelImportar = Request["TVentana"];

                            List<CEntidad> ListItemsDetalle = new List<CEntidad>();

                            switch (hdfItemExcelImportar)
                            {
                                #region ESPDEV
                                case "VOLINJUS":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.VOLUMEN_APROBADO = Decimal.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                        oCampos.VOLUMEN_MOVILIZADO = Int32.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                        oCampos.VOLUMEN_INJUSTIFICADO = Int32.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.VOLUMEN_JUSTIFICADO = Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.ESPECIES,
                                                   row.VOLUMEN_APROBADO,
                                                   row.VOLUMEN_MOVILIZADO,
                                                   row.VOLUMEN_INJUSTIFICADO,
                                                   row.VOLUMEN_JUSTIFICADO,
                                                   row.OBSERVACION,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                    #endregion


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


            var jsonResult = Json(new { success = success, msj = msj, data = retorna });
            jsonResult.MaxJsonLength = int.MaxValue;


            return jsonResult;
        }

        [HttpPost]
        public JsonResult ExportarExcel(VModel dto)
        {
            object result = new object();
            if (dto.ListVolInjustificado.Count > 0)
                result = ReporteInformeAutoridadForestal.DescargaExcel(dto);
            else
                return Json(new { success = false, msj = "no tiene data" });

            return Json(result);
        }
        [HttpGet]
        public ActionResult Download(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpPost]
        public JsonResult Registrar(VModel dto)
        {

            CLogica objLog = new CLogica();
            ListResult resultado;
            resultado = objLog.GuardarDatos(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }
    }
}