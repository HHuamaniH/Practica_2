using CapaEntidad.ViewModel;
using CapaLogica.Documento;
using DocumentFormat.OpenXml.Wordprocessing;
//using DocumentFormat.OpenXml.Packaging;
using wp=DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml.Style;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using OfficeOpenXml;
using DocumentFormat.OpenXml;
using CapaEntidad.ViewModel.General;
using DocumentFormat.OpenXml.Packaging;

namespace SIGOFCv3.Areas.Focalizacion.Controllers
{
    public class PlanTrabajoController : Controller
    {
        // GET: Focalizacion/PlanTrabajo
        private Log_Focalizacion _log;

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
        [HttpGet]
        public ActionResult Index()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            List<VM_Cbo> ods = exeBus.RegMostComboIndividual("FOCALIZACION_OD_V1", "");
            // ods.Remove(ods.Single(r => r.Value == "0000000"));
            ViewBag.ddlOD = ods;
            ViewBag.ddlPeriodo = exeBus.RegMostComboIndividual("FOCALIZACION_PERIODO_PLAN_TRABAJO_V1", "");
            ViewBag.ddlMes = this.ListarMes();

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE FOCALIZACIÓN", "Mantenimiento de planes de trabajo");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        [HttpGet]
        public ActionResult _AddPlan()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlOD_Add = exeBus.RegMostComboIndividual("FOCALIZACION_OD", "");
            ViewBag.ddlPeriodo_Add = exeBus.RegMostComboIndividual("FOCALIZACION_PERIODO_PLAN_TRABAJO_ADD", "");
            ViewBag.ddlMes_Add = this.ListarMes();
            

            return PartialView();
        }
        [HttpGet]
        public ActionResult Plan(string id)
        {
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE FOCALIZACIÓN", "Mantenimiento de planes de trabajo");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            _log = new Log_Focalizacion();
            VM_Focalizacion_PlanTrabajo obj = _log.PlanTrabajoGetById(id, (ModelSession.GetSession())[0].COD_UCUENTA, mr.VALIAS);
            
           
            return View(obj);
        }
        [HttpPost]
        public JsonResult PlanGuardar(string od, string periodo, Int16 mes)
        {
            try
            {
                _log = new Log_Focalizacion();
                string id = _log.PlanTrabajoCreate(od, periodo, mes, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se generó correctamente", id = id });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanGuardarG(VM_Focalizacion_PlanTrabajo vm)
        {
            try
            {
                _log = new Log_Focalizacion();
                vm.codUsuarioCreacion = (ModelSession.GetSession())[0].COD_UCUENTA;
                string id = _log.PlanTrabajoCreate(vm);
                return Json(new { success = true, msj = "Se generó correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanDetGuardar(List<VM_Focalizacion_PlanTrabajoDet> vm)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDetCreate(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se agrego correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanEliminar(VM_Focalizacion_PlanTrabajo vm)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDelete(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se anuló el plan de trabajo correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanDetEliminar(VM_Focalizacion_PlanTrabajoDet vm)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDetDelete(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se eliminó el item correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpGet]
        public ActionResult PlanTrabajoListar(DataTableRequest_1 request, string codOd, string codRegistro, string periodo, int? mes, string sort = "")
        {


            List<VM_Focalizacion_PlanTrabajo_List> lstResult = new List<VM_Focalizacion_PlanTrabajo_List>();
            int rowcount = 0;
            int currentpage = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;
            int pagesize = request.Length;
            codOd = codOd ?? "0000000";
            codRegistro = codRegistro ?? "";
            sort = sort ?? "";
            periodo = periodo ?? "";
            mes = mes ?? 0;
            _log = new Log_Focalizacion();
            lstResult = _log.PlanTrabajoListar(codOd, periodo, mes.Value, codRegistro, currentpage, pagesize, sort, ref rowcount);

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
        public ActionResult _PlanManejoOrd(int tipoSupervision)
        {
            ViewBag.tipoSupervision = tipoSupervision;
            return PartialView();
        }
        [HttpGet]
        public ActionResult _Consolidado(long codPlanDetId)
        {
            _log = new Log_Focalizacion();
            return PartialView(_log.PlanTrabajoDetGetConsolidado_GetByPTSD(codPlanDetId));
        }
        [HttpGet]
        public JsonResult PlanManejoCalificadoListar(string codPlanTrabajo, int tipoSupervision = 4)
        {
            _log = new Log_Focalizacion();
            List<VM_PlanManejoCalificacion> result = new List<VM_PlanManejoCalificacion>();
            result = _log.PlanManejoCalificadoGetAll(codPlanTrabajo, tipoSupervision);
            var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult PlanTrabajoDetListar(string codPlanTrabajo)
        {
            _log = new Log_Focalizacion();
            List<VM_Focalizacion_PlanTrabajoDet_List> result = new List<VM_Focalizacion_PlanTrabajoDet_List>();
            result = _log.PlanTrabajoDetGetByPadreId(codPlanTrabajo);
            var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public ActionResult _CalificacionEspecie(long codPlanDetId, string tipoPManejo)
        {
            _log = new Log_Focalizacion();
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            ViewBag.tipoPManejo = tipoPManejo;
            ViewBag.existeConsolidado = 0;
            var lstConsolidado = _log.PlanTrabajoDetGetConsolidado_GetByPTSD(codPlanDetId);
            if (lstConsolidado.Count() > 0) ViewBag.existeConsolidado = 1;
            result = _log.PlanTrabajoDetGetEspecieCalificacionNoCites(codPlanDetId);
            return PartialView(result);
        }
        [HttpPost]
        public JsonResult GenerarCalificacionMuestra(string codTH, int numPoa, long codPlanSupervisionDetalle, string tipoPManejo)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.GenerarCalificacionMuestra(codTH, numPoa, codPlanSupervisionDetalle, (ModelSession.GetSession())[0].COD_UCUENTA, tipoPManejo);
                return Json(new { success = true, msj = "Se generó correctamente la calificación", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpGet]
        public ActionResult _MuestraMinimaEspecie(long codPlanDetId)
        {
            _log = new Log_Focalizacion();
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            result = _log.PlanTrabajoDetGetMuestraMinima_GetByPTSD(codPlanDetId);
            ViewBag.cantEspeciesCites = _log.PlanTrabajoDetGetCantidadEspeciesCites_GetByPTSD(codPlanDetId);
            return PartialView(result);
        }
        [HttpPost]
        public JsonResult GenerarMuestraMinima(long codPlanSupervisionDetalle)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.GenerarMuestraMinima(codPlanSupervisionDetalle, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se generó correctamente la muestra mínima", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanTrabajoDetEspecieDelete(long codPlanSupervisionDetalle)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDetEspecieDelete(codPlanSupervisionDetalle, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se eliminó correctamente la calificación", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanTrabajoDetMuestraDelete(long codPlanSupervisionDetalle)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDetalleMuestraMinima_Delete(codPlanSupervisionDetalle, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se eliminó correctamente la muestra", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult ActualizarPTSDetalleCalificacion(VM_PlanTrabajoDetalleEspecie item)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.ActualizarPTSDetalleCalificacion(item, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se actualizó la calificación correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpGet]
        public JsonResult PlanTrabajoDetGetEspecieCalificacion(long codPlanDetId)
        {
            _log = new Log_Focalizacion();
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            result = _log.PlanTrabajoDetGetEspecieCalificacionNoCites(codPlanDetId);
            var jsonResult = Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult PlanTrabajoDetEspecieAdic(VM_PlanTrabajoDetalleEspecie especieAdicional)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDetalleAdicionalOrigen_Create(especieAdicional, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se registró correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult ModificarCantidadConsolidado(VM_PlanTrabajoDetalleEspecie especieConsolidado)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.ModificarCantidadConsolidado(especieConsolidado, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se modificó correctamente" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        [HttpPost]
        public JsonResult PlanTrabajoDetEspecieAdicDelete(long id, long idPlanTrajoDet)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.PlanTrabajoDetalleAdicionalOrigen_Delete(id, idPlanTrajoDet, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se eliminó correctamente", id = "" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        #region "Plan Trabajo Extra-Ordinario"
        [HttpPost]
        public JsonResult GenerarUniversoExtraOrdinario(string codPlan, string codTH, string codPManejo, int numPoa, string idPlanTrajo, int oportunidadSupId)
        {
            try
            {
                _log = new Log_Focalizacion();
                _log.GenerarUniversoExtraOrdinario(codPlan, codTH, codPManejo, numPoa, idPlanTrajo, oportunidadSupId, (ModelSession.GetSession())[0].COD_UCUENTA);
                return Json(new { success = true, msj = "Se agrego correctamente" });
            }
            catch (Exception ex)
            {
                string msj = "Sucedió un error";
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                return Json(new { success = false, msj = msj });
            }

        }
        #endregion
        #region "Reportes"
        public ActionResult DownloadCalificacionEspecie(long codPlanDetId)
        {
            _log = new Log_Focalizacion();
            VM_Focalizacion_PlanTrabajoDet_List planDetalle = _log.PlanTrabajoDetGetById(codPlanDetId);

            List<VM_PlanTrabajoDetalleEspecie> calificacionEspecies = new List<VM_PlanTrabajoDetalleEspecie>();
            calificacionEspecies = _log.PlanTrabajoDetGetEspecieCalificacionNoCites(codPlanDetId);
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Focalizacion/PlantillaR_Calificacion.xlsx"));
            int rowStart = 10;
            int contador = 0;
            //valores para muestra
            int rowMuestra = rowStart + 4;
            int rowMuestraStar = rowMuestra + 1;
            int contadorMuestra = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                worksheet.Cells["C2"].Value = planDetalle.idPlan;
                worksheet.Cells["C3"].Value = planDetalle.OdAmbito;
                worksheet.Cells["C4"].Value = planDetalle.numTH;
                worksheet.Cells["C5"].Value = planDetalle.modalidad;
                worksheet.Cells["C6"].Value = planDetalle.nombrePManejo;
                worksheet.Cells["C7"].Value = $"{planDetalle.departamento}/{planDetalle.provincia}/{planDetalle.distrito}";
                if (calificacionEspecies.Count > 0)
                {
                    foreach (var item in calificacionEspecies)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.descripcionEspecie;
                        // worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.codSecuencial;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.totalIndividuos;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.numAprov;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.numSemilleros;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.volAutorizado;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.volMovilizado;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.abundanciaPuntaje;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.volAprobadoPuntaje;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.volMovilizadoPuntaje;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.puntajeEspeciesAmenazadas;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.puntajeCategoriaMad;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.puntajeTotalCalificacion;
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item.puntajeTotalPorcentaje;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A10:N" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    //obteniendo muestra mínima
                    List<VM_PlanTrabajoDetalleEspecie> lstMuestraMinima = new List<VM_PlanTrabajoDetalleEspecie>();
                    lstMuestraMinima = _log.PlanTrabajoDetGetMuestraMinima_GetByPTSD(codPlanDetId);
                    rowMuestra = rowStart + 4;
                    rowMuestraStar = rowMuestra + 1;
                    if (lstMuestraMinima.Count > 0)
                    {
                        
                        System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#dae7f5");
                        worksheet.Cells[$"B{rowMuestra - 2}"].Style.Font.Bold = true;
                        worksheet.Cells[$"B{rowMuestra - 2}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"B{rowMuestra - 2}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"B{rowMuestra - 2}"].Value = "Muestra Mínima";
                        worksheet.Cells[$"C{rowMuestra - 2}"].Value = lstMuestraMinima.First().muestraMinima;
                        worksheet.Cells[$"A{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"A{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"A{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"A{rowMuestra}"].Value = "N°";
                        worksheet.Cells[$"B{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"B{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"B{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"B{rowMuestra}"].Value = "Especie";
                        worksheet.Cells[$"C{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"C{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"C{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"C{rowMuestra}"].Value = "T. Individuos";
                        worksheet.Cells[$"D{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"D{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"D{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"D{rowMuestra}"].Value = "N° de Aprov";
                        worksheet.Cells[$"E{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"E{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"E{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"E{rowMuestra}"].Value = "N° de Sem";
                        worksheet.Cells[$"F{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"F{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"F{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"F{rowMuestra}"].Value = "Factor. Aprov";
                        worksheet.Cells[$"G{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"G{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"G{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"G{rowMuestra}"].Value = "Factor. Sem";
                        worksheet.Cells[$"H{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"H{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"H{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"H{rowMuestra}"].Value = "Muestra Aprov";
                        worksheet.Cells[$"I{rowMuestra}"].Style.Font.Bold = true;
                        worksheet.Cells[$"I{rowMuestra}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"I{rowMuestra}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        worksheet.Cells[$"I{rowMuestra}"].Value = "Muestra Sem";
                        foreach (var itemMuestra in lstMuestraMinima)
                        {
                            worksheet.Cells[HelperSigo.GetColum(1) + rowMuestraStar.ToString()].Value = ++contadorMuestra;
                            worksheet.Cells[HelperSigo.GetColum(2) + rowMuestraStar.ToString()].Value = itemMuestra.descripcionEspecie;
                            worksheet.Cells[HelperSigo.GetColum(3) + rowMuestraStar.ToString()].Value = itemMuestra.totalIndividuos;
                            worksheet.Cells[HelperSigo.GetColum(4) + rowMuestraStar.ToString()].Value = itemMuestra.numAprov;
                            worksheet.Cells[HelperSigo.GetColum(5) + rowMuestraStar.ToString()].Value = itemMuestra.numSemilleros;
                            worksheet.Cells[HelperSigo.GetColum(6) + rowMuestraStar.ToString()].Value = itemMuestra.factorAprov;
                            worksheet.Cells[HelperSigo.GetColum(7) + rowMuestraStar.ToString()].Value = itemMuestra.factorSem;
                            worksheet.Cells[HelperSigo.GetColum(8) + rowMuestraStar.ToString()].Value = itemMuestra.muestraAprov;
                            worksheet.Cells[HelperSigo.GetColum(9) + rowMuestraStar.ToString()].Value = itemMuestra.muestraSem;
                            rowMuestraStar = rowMuestraStar + 1;
                        }
                        string modelRangeMuestra = $"A{rowMuestra}:I" + (rowMuestraStar - 1).ToString();
                        var modelTableMustra = worksheet.Cells[modelRangeMuestra];
                        modelTableMustra.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTableMustra.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTableMustra.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTableMustra.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }
                List<VM_PlanTrabajoDetalleEspecie> lstConsolidado = new List<VM_PlanTrabajoDetalleEspecie>();
                lstConsolidado = _log.PlanTrabajoDetGetConsolidado_GetByPTSD(codPlanDetId);
                if (lstConsolidado.Count > 0)
                {
                    //var resultsConsolidado = from p in lstConsolidado
                    //                         group p.codEspecie by p.codEspecie into g
                    //                         select new { codEspecie = g.Key, especies = g.ToList() };
                    var resultsConsolidado = lstConsolidado.GroupBy(p => p.codEspecie);
                    int rowConsolidado = rowMuestraStar + 4;
                    int rowConsolidadoStar = rowConsolidado + 1;
                    int contadorConsolidado = 0;
                    System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#dae7f5");
                    worksheet.Cells[$"A{rowConsolidado - 1}:E{rowConsolidado - 1}"].Merge = true;
                    worksheet.Cells[$"A{rowConsolidado - 1}:E{rowConsolidado - 1}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[$"A{rowConsolidado - 1}:E{rowConsolidado - 1}"].Value = "ESPECIES A SUPERVISAR";
                    worksheet.Cells[$"A{rowConsolidado - 1}:E{rowConsolidado - 1}"].Style.Font.Bold = true;
                    worksheet.Cells[$"A{rowConsolidado - 1}:E{rowConsolidado - 1}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"A{rowConsolidado - 1}:E{rowConsolidado - 1}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"A{rowConsolidado}"].Style.Font.Bold = true;
                    worksheet.Cells[$"A{rowConsolidado}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"A{rowConsolidado}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"A{rowConsolidado}"].Value = "N°";
                    worksheet.Cells[$"B{rowConsolidado}"].Style.Font.Bold = true;
                    worksheet.Cells[$"B{rowConsolidado}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"B{rowConsolidado}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"B{rowConsolidado}"].Value = "Especie";
                    worksheet.Cells[$"C{rowConsolidado}"].Style.Font.Bold = true;
                    worksheet.Cells[$"C{rowConsolidado}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"C{rowConsolidado}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"C{rowConsolidado}"].Value = "PC";
                    worksheet.Cells[$"D{rowConsolidado}"].Style.Font.Bold = true;
                    worksheet.Cells[$"D{rowConsolidado}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"D{rowConsolidado}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"D{rowConsolidado}"].Value = "N° de Aprov";
                    worksheet.Cells[$"E{rowConsolidado}"].Style.Font.Bold = true;
                    worksheet.Cells[$"E{rowConsolidado}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"E{rowConsolidado}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"E{rowConsolidado}"].Value = "N° de Sem";
                    worksheet.Cells[$"F{rowConsolidado}"].Style.Font.Bold = true;
                    worksheet.Cells[$"F{rowConsolidado}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"F{rowConsolidado}"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    worksheet.Cells[$"F{rowConsolidado}"].Value = "T. Individuos";
                    int subTotalAprov = 0, subTotalSem = 0;
                    foreach (var itemC in resultsConsolidado)
                    {
                        subTotalAprov = 0; subTotalSem = 0;
                        worksheet.Cells[HelperSigo.GetColum(1) + rowConsolidadoStar.ToString()].Value = ++contadorConsolidado;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowConsolidadoStar.ToString()].Value = itemC.First().descripcionEspecie;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowConsolidadoStar.ToString()].Value = itemC.First().PCA;
                        subTotalAprov = itemC.Sum(x => x.muestraAprovFinal);
                        subTotalSem = itemC.Sum(x => x.muestraSemFinal);
                        worksheet.Cells[HelperSigo.GetColum(4) + rowConsolidadoStar.ToString()].Value = subTotalAprov;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowConsolidadoStar.ToString()].Value = subTotalSem;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowConsolidadoStar.ToString()].Value = subTotalAprov + subTotalSem;
                        rowConsolidadoStar = rowConsolidadoStar + 1;
                    }
                    string modelRangeConsolidado = $"A{rowConsolidado}:F" + (rowConsolidadoStar - 1).ToString();
                    var modelTableConsolidado = worksheet.Cells[modelRangeConsolidado];
                    modelTableConsolidado.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTableConsolidado.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTableConsolidado.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTableConsolidado.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "CalificaciónEspecies";
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
        public ActionResult DownloadPlanDet(string codPlanId)
        {
            _log = new Log_Focalizacion();

            VM_Focalizacion_PlanTrabajo planTrabajo = _log.PlanTrabajoGetById(codPlanId, (ModelSession.GetSession())[0].COD_UCUENTA);
            List<VM_Focalizacion_PlanTrabajoDet_List> planTrabajoDet = _log.PlanTrabajoDetGetByPadreId(codPlanId);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Focalizacion/PlantillaR_PlanDet.xlsx"));
            int rowStart = 10;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (planTrabajoDet.Count > 0)
                {

                    worksheet.Cells["C3"].Value = planTrabajo.od;
                    worksheet.Cells["C4"].Value = planTrabajo.ddlPeriodoId;
                    worksheet.Cells["C5"].Value = planTrabajo.mesFocalizacion;
                    worksheet.Cells["C6"].Value = planTrabajo.usuarioCreacion;
                    worksheet.Cells["C7"].Value = planTrabajo.funcionarioResponsable;
                    foreach (var item in planTrabajoDet)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.titular;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.numTH;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.modalidad;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.nombrePManejo;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.departamento;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.provincia;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.distrito;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.tipoSupervision;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.criterios;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.oportunidadSupervision;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A9:K" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "PlanManejoSupervisar";
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
        public ActionResult DownloadPlanCabecera(string codOd, string periodo, int? mes)
        {
            _log = new Log_Focalizacion();

            List<VM_Focalizacion_PlanTrabajo_List> lstResult = new List<VM_Focalizacion_PlanTrabajo_List>();
            int rowcount = 0, currentpage = 1, pagesize = 100000;
            codOd = codOd ?? "0000000";
            String sort = "", codRegistro = "";
            periodo = periodo ?? "";
            mes = mes ?? 0;
            _log = new Log_Focalizacion();
            lstResult = _log.PlanTrabajoListar(codOd, periodo, mes.Value, codRegistro, currentpage, pagesize, sort, ref rowcount);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/Focalizacion/PlantillaR_PlanCabecera.xlsx"));
            int rowStart = 4;
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
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.fRegistro;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.idPlanTrajo;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.od;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.periodo;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.mes;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.supervisor;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.funcionario;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.estadoDoc;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A4:I" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "PlanTrabajo";
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
        [HttpGet]
        public PartialViewResult _PlanManejoExtra()
        {
            return PartialView();
        }
        #endregion
        #region "Proyeccion"
        public ActionResult ProyecTarPlanTrabajo(string id)
        {
            _log = new Log_Focalizacion();
            //obteniendo cabecera de un plan de trabajo
            VM_Focalizacion_PlanTrabajo planTrabajo = _log.PlanTrabajoGetById(id, (ModelSession.GetSession())[0].COD_UCUENTA);
            //obteniendo detalle (planes de manejo)
            List<VM_Focalizacion_PlanTrabajoDet_List> planTrabajoDetalle = _log.PlanTrabajoDetGetByPadreId(id);
            string aLosTH = "al Título Habilitante ";
            string objetivoDeberes = "el contrato";
            string objetivoTitular = "cuyo titular es:";
            string titulares = "";
            Table tbPlanesManejo = new Table();
            Table tbPlanesManejoEspecie = new Table();
            DateTime fechaActual = DateTime.Now;
            string mesActual = this.ListarMes().Find(x => x.Value == fechaActual.Month.ToString()).Text;
            string lugaryFecha = $"Lima, {fechaActual.Day} de {mesActual.ToLower()} del {fechaActual.Year}.";
            string numTHabilitante = "";
            if (planTrabajoDetalle.Count > 1)
            {
                aLosTH = "a los Títulos Habilitantes ";
                List<string> tempNUmTHabilitante = planTrabajoDetalle.Select(x => x.numTH).Distinct().ToList();
                numTHabilitante = string.Join(", ", tempNUmTHabilitante);
                List<string> tempTitulares= planTrabajoDetalle.Select(x => x.titular).Distinct().ToList();
               
                titulares = string.Join(", ", tempTitulares);

                objetivoDeberes = "los contratos";
                objetivoTitular = "cuyos titulares son:";
               
                
            }
            else
            {
                numTHabilitante = planTrabajoDetalle.FirstOrDefault().numTH;
                titulares = planTrabajoDetalle.FirstOrDefault().titular;
            }

            byte[] bytePlantilla = System.IO.File.ReadAllBytes(Server.MapPath("~/Archivos/Plantilla/Focalizacion/PlanTrabajo/PPlanTrabajo.docx"));

            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(bytePlantilla, 0, (int)bytePlantilla.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    var paras = body.Elements<Paragraph>();
                    var tables = body.Elements<Table>();
                    BuscarReemplazarTexto(paras, "SUB_DIRECTOR_DSFFS", planTrabajo.funcionarioResponsableNA);
                    BuscarReemplazarTexto(paras, "A_LOS_PLANES", aLosTH);
                    BuscarReemplazarTexto(paras, "NUMTHABILITANTEXXX", numTHabilitante);
                    BuscarReemplazarTexto(paras, "MESXXX", planTrabajo.mesFocalizacion.ToLower());
                    BuscarReemplazarTexto(paras, "ANIOPLANXXX", planTrabajo.fCreacion.Year.ToString());
                    BuscarReemplazarTexto(paras, "LUGARFECHAXXX", lugaryFecha);
                    BuscarReemplazarTexto(paras, "LUGARFECHAXXX", lugaryFecha);
                    BuscarReemplazarTexto(paras, "ELCONTRATOXXX", objetivoDeberes);
                    BuscarReemplazarTexto(paras, "CUYOTITULARXX", objetivoTitular);
                    BuscarReemplazarTexto(paras, "TITULARXXX", $"{titulares}.");
                    BuscarReemplazarTextoTabla(tables, "NUMTHABILITANTEXXX", numTHabilitante); 
                    BuscarReemplazarTexto(paras, "SUPERVISORNXXX", $"{planTrabajo.usuarioCreacionNA}");
                    #region "Tabla de planes de manejo"
                    if (planTrabajoDetalle.Count > 0)
                    {
                        tbPlanesManejo = (Table)tables.ToList()[0];
                        TableRow tr1;
                        int contadorItem = 1;
                        foreach (var item in planTrabajoDetalle)
                        {
                           
                            tr1 = new TableRow();
                            TableCell tc1 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(contadorItem.ToString()))));
                            TableCell tc2 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.titular))));
                            TableCell tc3 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.numTH))));
                            TableCell tc4 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.modalidad))));
                            TableCell tc5 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.nombrePManejo))));
                            TableCell tc6 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.departamento))));
                            TableCell tc7 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.provincia))));
                            TableCell tc8 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.distrito))));
                            TableCell tc9 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.tipoSupervision))));
                            TableCell tc10 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(System.Text.RegularExpressions.Regex.Replace(item.criterios, ",", ", ")))));
                            TableCell tc11 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(item.oportunidadSupervision))));
                            tr1.Append(tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11);
                            tbPlanesManejo.AppendChild(tr1);
                            contadorItem++;
                        }
                    }
                    #endregion

                    #region "Especies a supervisar"
                    if (planTrabajoDetalle.Count > 0)
                    {
                        tbPlanesManejoEspecie = (Table)tables.ToList()[1];
                        TableRow trEspecie;
                        //System.Web.UI.WebControls.TableRowCollection trCC;
                        int contadorItemEspecie = 1;
                        int subTotalAprov = 0;
                        int subTotalSem = 0;
                        foreach (var planDetalle in planTrabajoDetalle)
                        {
                            var lstTempConsolidado = _log.PlanTrabajoDetGetConsolidado_GetByPTSD(planDetalle.idPlanTrajoDet);
                            if (lstTempConsolidado.Count() > 0)
                            {
                               // trCC = new System.Web.UI.WebControls.TableRowCollection();
                                foreach (var planDetConsolidado in lstTempConsolidado.GroupBy(e => e.codEspecie))
                                {
                                    subTotalAprov = planDetConsolidado.Sum(x => x.muestraAprovFinal);
                                    subTotalSem = planDetConsolidado.Sum(x => x.muestraSemFinal);
                                    trEspecie = new TableRow();
                                    
                                    TableCell tc1 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(contadorItemEspecie.ToString()))));
                                    //TableCellProperties cellOneProperties = new TableCellProperties();
                                    //cellOneProperties.Append(new VerticalMerge()
                                    //{
                                    //    Val = MergedCellValues.Restart
                                    //});

                                    //TableCellProperties cellTwoProperties = new TableCellProperties();
                                    //cellTwoProperties.Append(new VerticalMerge()
                                    //{
                                    //    Val = MergedCellValues.Continue
                                    //});
                                    // tc1.Append(cellOneProperties);
                                   // TableCellProperties cellOneProperties = new TableCellProperties();
                                   // cellOneProperties.VerticalMerge = new VerticalMerge();
                                   // cellOneProperties.VerticalMerge =new VerticalMerge() { Val = MergedCellValues.Restart };
                                    TableCell tc2 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(planDetalle.titular))));
                                    /*if (contadorItemEspecie == 1 || contadorItemEspecie == 1)
                                    {
                                        
                                       tc2.Append(cellOneProperties);
                                    }
                                    if (contadorItemEspecie == 2)
                                    {
                                        
                                    }*/
                                    
                                    TableCell tc3 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(planDetalle.numTH))));
                                    TableCell tc4 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(planDetalle.nombrePManejo))));
                                    TableCell tc5 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(planDetConsolidado.First().descripcionEspecie))));
                                    TableCell tc6 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(subTotalAprov.ToString()))));
                                    TableCell tc7 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text(subTotalSem.ToString()))));
                                    TableCell tc8 = new TableCell(new Paragraph(new Run(new RunProperties(new wp.FontSize() { Val = "14" }), new Text((subTotalAprov + subTotalSem).ToString()))));
                                    trEspecie.Append(tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8);
                                    
                                    tbPlanesManejoEspecie.AppendChild(trEspecie);
                                }
                                contadorItemEspecie++;
                            }                           
                        }
                    }                    
                    #endregion

                    wordDoc.Close();
                }
                return new BinaryContentResultDowload
                {
                    FileName = "demo" + ".docx",
                    ContentType = "application/octet-stream",
                    Content = mem.ToArray()
                };
                //using (FileStream fileStream = new FileStream(Server.MapPath("~/Archivos/Plantilla/Focalizacion/PlanTrabajo/PPlanTrabajo1.docx"), FileMode.Create))
                //{
                //    mem.WriteTo(fileStream);
                //    mem.Close();
                //    fileStream.Close();
                //}
                //byte[] bytePlantillaDescargar = System.IO.File.ReadAllBytes(Server.MapPath("~/Archivos/Plantilla/Focalizacion/PlanTrabajo/PPlanTrabajo1.docx"));

            }            
        }
        private void BuscarReemplazarTexto(IEnumerable<Paragraph> paragraphs, string textoBuscar, string textoReemplazar)
        {
            //search & replace string
            foreach (var para in paragraphs)
            {
                foreach (var run in para.Elements<Run>())
                {
                    foreach (var text in run.Elements<Text>())
                    {
                        if (text.Text.Trim().Contains(textoBuscar))
                        {
                            text.Text = text.Text.Trim().Replace(textoBuscar, textoReemplazar);
                        }
                    }
                }
            }
        }
        private void BuscarReemplazarTextoTabla(IEnumerable<Table> tables, string textoBuscar, string textoReemplazar)
        {
            foreach (var table in tables)
            {
                foreach (var row in table.Elements<TableRow>())
                {
                    foreach (var cell in row.Elements<TableCell>())
                    {
                        foreach (var para in cell.Elements<Paragraph>())
                        {
                            foreach (var run in para.Elements<Run>())
                            {
                                foreach (var text in run.Elements<Text>())
                                {
                                    if (text.Text.Trim().Contains(textoBuscar))
                                    {
                                        text.Text = text.Text.Trim().Replace(textoBuscar, textoReemplazar);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}