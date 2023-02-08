using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformeTecnico;
using CLogica = CapaLogica.DOC.Log_INFTEC;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManInformeTecnicoController : Controller
    {
        private CLogica logInfTecnico = new CLogica();
        public static CEntVM vm = new CEntVM();


        // GET: Fiscalizacion/ManInformeTecnico
        public ActionResult Index()
        {
            // return View();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.Formulario = "INFORME_TECNICO";
            ViewBag.TituloFormulario = "Informes Técnicos";
            ViewBag.Criterio = "TODOS";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("INFORME_TECNICO", "");
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informes Técnicos");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        public ActionResult CreateOrEdit(string asCodigo = "", string asCodTipoIL = "")
        {
            try
            {
                vm = logInfTecnico.init(asCodigo, asCodTipoIL);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informes Técnicos");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vm.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }

        }

        public ActionResult agregarVolumen(string codEspecie, string especie, string volumenAp, string volumenMov, string volumenInjust, string volumenJust, string observaciones)
        {
            try
            {
                if (codEspecie != "0004563" || especie != "|")
                {
                    Ent_INFTEC oCentidad = new Ent_INFTEC();

                    oCentidad.RegEstado = 1;
                    oCentidad.COD_ESPECIES = codEspecie;
                    oCentidad.COD_SECUENCIAL = 0;
                    oCentidad.ESPECIES = especie;
                    oCentidad.VOLUMEN_APROBADO = volumenAp == "" ? 0 : Decimal.Parse(volumenAp);
                    oCentidad.VOLUMEN_MOVILIZADO = volumenMov == "" ? 0 : Decimal.Parse(volumenMov);
                    oCentidad.VOLUMEN_INJUSTIFICADO = volumenInjust == "" ? 0 : Decimal.Parse(volumenInjust);
                    oCentidad.VOLUMEN_JUSTIFICADO = volumenJust == "" ? 0 : Decimal.Parse(volumenJust);
                    oCentidad.OBSERVACION = observaciones;


                    vm.ListVolumen.Add(oCentidad);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/Fiscalizacion/Views/ManInformeTecnico/_Shared/_renderListVolumenes.cshtml", vm);
        }
        public JsonResult ImportarVolumen()
        {
            int band = 0;
            string mensaje = "Existe un error en: ";
            string err = "";
            try
            {
                if (Request != null)
                {
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
                            var obj = new Ent_INFTEC();
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 1].Value.ToString() != "" && workSheet.Cells[rowIterator, 2].Value.ToString() != "")
                                {
                                    obj = new Ent_INFTEC();
                                    obj.RegEstado = 1;
                                    obj.COD_ESPECIES = " ";
                                    obj.COD_SECUENCIAL = 0;
                                    obj.ESPECIES = (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString()) + " | " + (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString());
                                    obj.VOLUMEN_APROBADO = workSheet.Cells[rowIterator, 3].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 3].Value.ToString());
                                    obj.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 4].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 4].Value.ToString());
                                    obj.VOLUMEN_INJUSTIFICADO = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString());
                                    obj.VOLUMEN_JUSTIFICADO = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString());
                                    obj.OBSERVACION = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString();
                                    vm.ListVolumen.Add(obj);
                                }
                                else
                                {
                                    band = 1;
                                    mensaje = mensaje + " " + workSheet.Cells[rowIterator, 1].Value.ToString() + "|" + workSheet.Cells[rowIterator, 2].Value.ToString() + " ,";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            if (band == 1)
            {
                err = mensaje;
            }
            var jsonResult = Json(new
            {
                data = vm.ListVolumen,
                error = err
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEspecies.cshtml", vmInfLegal);

        }

        [HttpPost]
        public JsonResult AddEditRD(CEntVM dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica exeBus = new CLogica();
            ListResult result = exeBus.GuardarDatos(dto, codCuenta);
            return Json(result);
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            CLogica exeBus = new CLogica();
            ListResult result = new ListResult();
            result = exeBus.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
    }
}