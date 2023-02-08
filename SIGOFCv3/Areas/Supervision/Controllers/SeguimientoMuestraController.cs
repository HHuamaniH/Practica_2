using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.Doc;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class SeguimientoMuestraController : Controller
    {
        private Log_SeguimientoMuestra log_Seg;
        EpplusExcel epplus = new EpplusExcel();

        // GET: Supervision/SeguimientoMuestra
        #region "Acciones - Vistas"
        [HttpGet]
        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "SEGUIMIENTO_MUESTRA_ENDROLOGICA";
            ViewBag.TituloFormulario = "Seguimiento Muestra Dendrologica";
            ViewBag.AlertaInicial = _alertaIncial;

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Muestras Dendrológicas");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }
        [HttpGet]
        public ActionResult AddEdit(string codSegMuestra = "")
        {
            try
            {
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Muestras Dendrológicas");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                log_Seg = new Log_SeguimientoMuestra();
                var vm = log_Seg.AddEditInit(codSegMuestra, (ModelSession.GetSession())[0].COD_UCUENTA, mr.VALIAS);
                if (TempData["msjCabeceraDendrologica"] != null)
                {
                    vm.msjR = TempData["msjCabeceraDendrologica"].ToString();
                }
                else vm.msjR = "";

                

                return View(vm);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }

        }
        [HttpGet]
        public ActionResult _AddEditMuestra(string cod = "", string sec = "", string est = "")
        {
            log_Seg = new Log_SeguimientoMuestra();
            int secuencial = string.IsNullOrEmpty(sec) ? 0 : Convert.ToInt32(sec);
            var itemEdit = log_Seg.AddEditMuestraInit(cod, secuencial);
            TempData["tbFotosMuestraDendrologica"] = itemEdit.fotos;
            return PartialView(itemEdit);
        }

        public ActionResult _BuscarInformeSupervision()
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            paramsBus.BusFormulario = "MANGRILLA";
            paramsBus.BusCriterio = "SEGUIMIENTO_MUESTRA_ENDROLOGICA";
            ViewBag.lstOpcionesI = HelperSigo.LLenarCombos(exeBus.RegOpcionesCombo(paramsBus), "");
            return PartialView();
        }
        #endregion
        #region "Accion - Operaciones"
        [HttpPost]
        public JsonResult AddEdit(VM_SeguimientoMuestra vm)
        {
            log_Seg = new Log_SeguimientoMuestra();
            bool aviso = string.IsNullOrEmpty(vm.id) ? true : false;
            var result = log_Seg.AddEditSeguimientoCabecera(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
            if (aviso)
            {
                if (result.success) TempData["msjCabeceraDendrologica"] = result.msj;
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult AddEditMuestra(VM_SeguimientoMuestraDetalle vm)
        {
            log_Seg = new Log_SeguimientoMuestra();
            return Json(log_Seg.AddEditSeguimientoDetalle(vm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
        [HttpPost]
        public JsonResult DeleteMuestra(List<VM_SeguimientoMuestraDetalle> lstVm)
        {
            log_Seg = new Log_SeguimientoMuestra();
            return Json(log_Seg.DeleteSeguimientoDetalle(lstVm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
        #endregion
        #region "Accion - Listados"
        [HttpGet]
        public JsonResult buscarInformeSupervision(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;
            paramsBus.v_sort = " ";
            paramsBus.BusCriterio1 = " ";

            if (request.Order.Length != 0)
            {

                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

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
        public ActionResult GetListEspeciePaging(string searchTerm, int pageSize, int pageNum)
        {
            Log_BUSQUEDA log = new Log_BUSQUEDA();
            searchTerm = string.IsNullOrEmpty(searchTerm) ? "" : searchTerm.Trim();
            var result = log.GetListComboPaging("SEGUIMIENTO_MUESTRA_ENDROLOGICA_ESPECIE", "", searchTerm, pageSize, pageNum);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllFotos()
        {
            try
            {
                var lstAdjuntos = (List<VM_ArchivoMuestra>)TempData["tbFotosMuestraDendrologica"];
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
        public JsonResult GetAllMuestra(string codSeguimiento)
        {
            try
            {
                log_Seg = new Log_SeguimientoMuestra();
                var lstMuestras = log_Seg.GetListSeguimientoDetalle(codSeguimiento);
                var jsonResult = Json(new { data = lstMuestras, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
        #region "Manejo Archivos"
        [HttpPost]
        public JsonResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                List<string> direcPath = new List<string>();
                try
                {
                    string fileName = "", nomArch = "", extArch = "", fname = "";
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        fileName = file.FileName;
                        nomArch = fileName.Substring(0, fileName.LastIndexOf("."));
                        nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                        extArch = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                        fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/MuestraDendrologica/Temp/"), fname));
                        direcPath.Add(Path.Combine(Server.MapPath("~/Archivos/Modulo/Supervision/MuestraDendrologica/Temp/"), fname));
                        result.Add(new Dictionary<string, object>(){ { "archivo", nomArch },
                                                    {"generado",fname },{"ext",extArch },{"secuencial",0 } });

                    }
                    return Json(new { success = true, data = result, msj = "Archivos subido correctamente" });
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
        public JsonResult EliminarArchivo(string name)
        {
            try
            {
                string direcTemp = "~/Archivos/Modulo/Supervision/MuestraDendrologica/Temp/";
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
        #endregion
        #region "Excel"
        public FileResult ExportarTabla()
        {
            string nombre_reporte = "reporte_Muestra";
            try
            {
                List<VM_SeguimientoMuestra> vM_SeguimientoMuestras = new Log_SeguimientoMuestra().reporteDendrenales();
                using (var excelPackage = new ExcelPackage())
                {
                    excelPackage.Workbook.Properties.Author = nombre_reporte.Replace("_", " ");
                    excelPackage.Workbook.Properties.Title = nombre_reporte.Replace("_", " ");
                    var _genericSheet = excelPackage.Workbook.Worksheets.Add(nombre_reporte.Replace("_", " "));
                    _genericSheet.View.ZoomScale = 100;
                    List<string> _cabecera = new List<string>
                    {
                        "N°",
                        "FECHA DE REGISTRO",
                        "AÑO",
                        "COD SEGUIMIENTO",
                        "NRO SITD ENVIO",
                        "NRO SITD RESPUESTA",
                        "NRO INFORME",
                        "NRO CNOTIFICACIÓN",
                        "MODALIDAD",
                        "NRO THABILILITANTE",
                        "TITULAR SUPERVISADO",
                        "SUPERVISOR",
                        "POA SUPERVISADO",
                        "O.D. desde donde registra la información",

                        "MUESTRA",
                        "FECHA COLECCIÓN",
                        "ZONA UTM",
                        "COOR. ESTE",
                        "COOR. NORTE",
                        "Nro POA",
                        "Código Censo",
                        "Especie Censo",
                        "Estado",
                        "Condición",
                        "Colector",
                        "Supervisor",
                        "1. De la forma del fuste",
                        "2. Del tipo de ramificación",
                        "3. Del tipo de raices",
                        "4.1. Color",
                        "4.2. De las lenticelas",
                        "4.3. Del ritidoma",
                        "4.4. Otras estructuras",
                        "5.1. Color",
                        "5.2. Olor",
                        "5.3.1. Tipo",
                        "5.3.2. Color",
                        "5.3.3. Olor",
                        "5.3.4. Sabor",
                        "5.3.5. Abundancia",
                        "5.3.6. Otra caracteristica",
                        "5.4. Tipo",
                        "6.1. Espinas",
                        "6.2. Aguijones",
                        "6.3. Otras estructuras",
                        "7. Del hábito del árbol",
                        "8.1.1. Simple",
                        "8.1.2. Compuesta",
                        "8.2. Por su forma",
                        "8.3. Tipo de borde",
                        "8.4. Disposición de la lamina",
                        "9.1. Color",
                        "9.2. Tamaño",
                        "9.3.1. Flor simple",
                        "9.3.2. Inflorescencia",
                        "9.4. Otras caracteristicas",
                        "10.1. Tipo",
                        "10.2. Color",
                        "10.3. Tamaño",
                        "10.4. Otras características",
                        "ESTADO",
                        "Especie Respuesta",
                    };
                    int finish = epplus.pintarcabeceras(_cabecera, _genericSheet, nombre_reporte.Replace("_", " "));
                    _genericSheet.Cells["A3:" + epplus.convertNumberToLetter(finish) + "3"].AutoFilter = true;
                    int rowIndex = 4;
                    int row = 1;
                    foreach (var objeto in vM_SeguimientoMuestras)
                    {
                        foreach (var z in objeto.detalle)
                        {
                            int col = 1;
                            epplus._texto_row(_genericSheet, rowIndex, col++, row++);
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.fecha == null) ? "" : objeto.fecha.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, objeto.anio.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.id == null) ? "" : objeto.id.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.desTramEnvio == null) ? "" : objeto.desTramEnvio.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.desTramRespuesta == null) ? "" : objeto.desTramRespuesta.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.desSupervision == null) ? "" : objeto.desSupervision.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.desNotificacion == null) ? "" : objeto.desNotificacion.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.modalidad == null) ? "" : objeto.modalidad.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.desTHabilitante == null) ? "" : objeto.desTHabilitante.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.titular == null) ? "" : objeto.titular.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.supervisor == null) ? "" : objeto.supervisor.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.poa == null) ? "" : objeto.poa.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (objeto.ddlODRegistroId == null) ? "" : objeto.ddlODRegistroId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.codMuestra == null) ? "" : z.codMuestra.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.fColeccion == null) ? "" : z.fColeccion.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.Z_UTMId == null) ? "" : z.Z_UTMId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.C_ESTE == null) ? "" : z.C_ESTE.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.C_NORTE == null) ? "" : z.C_NORTE.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.poa == null) ? "" : z.poa.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.codCenso == null) ? "" : z.codCenso.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.descripcion == null) ? "" : z.descripcion.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.estadoEspecieCenso == null) ? "" : z.estadoEspecieCenso.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.condicionEspecieCenso == null) ? "" : z.condicionEspecieCenso.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.colectorDes == null) ? "" : z.colectorDes.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.supervisoDes == null) ? "" : z.supervisoDes.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboFFusteId == null) ? "" : z.cboFFusteId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboTRamificacionId == null) ? "" : z.cboTRamificacionId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboTRaicesId == null) ? "" : z.cboTRaicesId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCEColorId == null) ? "" : z.cboCEColorId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCELenticelasId == null) ? "" : z.cboCELenticelasId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCERitidomaId == null) ? "" : z.cboCERitidomaId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCEOExtructuraId==null)?"": z.cboCEOExtructuraId.ToString());                              
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cortezaiColor == null) ? "" : z.cortezaiColor.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cortezaiOlor == null) ? "" : z.cortezaiOlor.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCIETipoId == null) ? "" : z.cboCIETipoId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCIEColorId == null) ? "" : z.cboCIEColorId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cortezaiExuOlor == null) ? "" : z.cortezaiExuOlor.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCIESaborId == null) ? "" : z.cboCIESaborId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCIEAbundanciaId == null) ? "" : z.cboCIEAbundanciaId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.otrasCaracteristica == null) ? "" : z.otrasCaracteristica.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboCITipoId == null) ? "" : z.cboCITipoId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboIFEspinasId == null) ? "" : z.cboIFEspinasId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboIFAguijonesId == null) ? "" : z.cboIFAguijonesId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.otrasEstructuras == null) ? "" : z.otrasEstructuras.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.habitoArbol == null) ? "" : z.habitoArbol.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, z.chkHSimple ? "SI" : "NO");
                            epplus._texto_row(_genericSheet, rowIndex, col++, z.chkHCompuesta ? "SI" : "NO");
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboHojaFormaId == null) ? "" : z.cboHojaFormaId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboHojaBordeId == null) ? "" : z.cboHojaBordeId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboHojaLaminaId == null) ? "" : z.cboHojaLaminaId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboFloresColorId == null) ? "" : z.cboFloresColorId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.floresTamaño == null) ? "" : z.floresTamaño.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, z.chkFSimple ? "SI" : "NO");
                            epplus._texto_row(_genericSheet, rowIndex, col++, z.chkFInflorescencia ? "SI" : "NO");
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.floresOtrasCaract == null) ? "" : z.floresOtrasCaract.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboFrutosTipoId == null) ? "" : z.cboFrutosTipoId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.cboFrutosColorId == null) ? "" : z.cboFrutosColorId.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.frutosTamanio == null) ? "" : z.frutosTamanio.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.frutosOtrasCaract == null) ? "" : z.frutosOtrasCaract.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, z.estado.ToString());
                            epplus._texto_row(_genericSheet, rowIndex, col++, (z.codEspecie == null) ? "" : z.codEspecie.ToString());
                            rowIndex++;
                        }
                    }

                    _genericSheet.Row(3).Height = 50;
                    _genericSheet.View.FreezePanes(4, 2);
                    return File(excelPackage.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombre_reporte + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx");
                }
            }
            catch (Exception e)
            {
                string x = e.Message;
                return File(System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Content\images\General\", "Delete-file-icon.png")), "image/png");
            }

        }
        #endregion
    }
}