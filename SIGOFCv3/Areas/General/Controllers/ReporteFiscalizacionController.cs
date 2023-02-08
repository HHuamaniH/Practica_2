using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ReporteFiscalizacionController : Controller
    {
        // GET: General/ReporteFiscalizacion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pau()
        {

            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            VM_ReporteGeneral vm = new VM_ReporteGeneral();
            Ent_MasterFiltro consulta = new Ent_MasterFiltro();

            consulta.BusValor = "0|1|1|0|1|0|3|0|0|5|0";

            try
            {
                consulta = oCLogica.RegMostFiltro(consulta);
                // OCEntidad = exeBus.RegMostCombo(OCEntidad);

                //lstChkItem = new List<VM_Chk>();
                //for (int i = DateTime.Now.Year; i >= 2004; i--)
                //    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vm.listModalidadPAU = consulta.ListModalidad;
                vm.listDepartamentoPAU = consulta.ListRegion;
                vm.listDireccionLineaSupervision = consulta.ListDLinea;
                vm.listDireccionLineaFiscalizacion = consulta.ListDLinea2;


            }
            catch (Exception)
            {

            }

            return View(vm);
        }
        public ActionResult PauResumen()
        {
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            VM_ReporteGeneral vm = new VM_ReporteGeneral();
            Ent_MasterFiltro consulta = new Ent_MasterFiltro();

            consulta.BusValor = "0|1|1|0|1|0|3|0|0|5|0";

            try
            {
                consulta = oCLogica.RegMostFiltro(consulta);
                // OCEntidad = exeBus.RegMostCombo(OCEntidad);

                //lstChkItem = new List<VM_Chk>();
                //for (int i = DateTime.Now.Year; i >= 2004; i--)
                //    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vm.listModalidadPAU = consulta.ListModalidad;
                vm.listDepartamentoPAU = consulta.ListRegion;
                vm.listDireccionLineaSupervision = consulta.ListDLinea;
                vm.listDireccionLineaFiscalizacion = consulta.ListDLinea2;


            }
            catch (Exception)
            {
            }

            return View(vm);
        }
        public ActionResult PauResumenTotal()
        {
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            VM_ReporteGeneral vm = new VM_ReporteGeneral();
            Ent_MasterFiltro consulta = new Ent_MasterFiltro();

            consulta.BusValor = "0|1|1|0|1|0|3|0|0|5|0";

            try
            {
                consulta = oCLogica.RegMostFiltro(consulta);
                // OCEntidad = exeBus.RegMostCombo(OCEntidad);

                //lstChkItem = new List<VM_Chk>();
                //for (int i = DateTime.Now.Year; i >= 2004; i--)
                //    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vm.listModalidadPAU = consulta.ListModalidad;
                vm.listDepartamentoPAU = consulta.ListRegion;
                vm.listDireccionLineaSupervision = consulta.ListDLinea;
                vm.listDireccionLineaFiscalizacion = consulta.ListDLinea2;


            }
            catch (Exception)
            {
            }

            return View(vm);
        }

        /// <summary>
        /// Número de PAU concluidos
        /// </summary>
        /// <param name="modalidad"></param>
        /// <param name="direccion"></param>
        /// <param name="direccionFisc"></param>
        /// <param name="anio"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public ActionResult ReporteFiscalizacionPauConcluido(String[] modalidad, String[] direccion, String[] direccionFisc, string anio, String[] departamento)
        {
            List<VM_ReporteGeneral> lstvm = new List<VM_ReporteGeneral>();
            List<Ent_Reporte_PAU_CONCLUIDO> ListCampos = new List<Ent_Reporte_PAU_CONCLUIDO>();
            Ent_Reporte_PAU_CONCLUIDO oCEntidad = new Ent_Reporte_PAU_CONCLUIDO();
            Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
            oCEntidad.BusModalidad = ObtenerCadenaArray(modalidad);
            oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
            oCEntidad.BusDireccion2 = ObtenerCadenaArray(direccionFisc);
            oCEntidad.BusRegion = ObtenerCadenaArray(departamento);
            oCEntidad.BusFechaFin = anio;
            oCEntidad.COD_ITIPO = "'0000001'";
            oCEntidad.BusCriterio = "DETALLADO";

            oCEntidad.COD_ITIPO = "0000001";
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de Supervisión (2009 - en adelante)", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000002,0000004";
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de Suspensión", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000003,0000007"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes Técnicos e Informes de Acompañamiento", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000005"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de la Autoridad Forestal", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000006"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes Supervisión OSINFOR-INRENA", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000008"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Otros Informes OSINFOR-INRENA", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000009"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Solicitudes de Renuncias a la Concesión", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000010"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativos(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de la Autoridad Forestal", listPauConcluido = ListCampos });


            return PartialView("~/Areas/General/Views/ReporteFiscalizacion/_sharedRptFiscalizacionPau/_renderDetalle.cshtml", lstvm);
        }
        public ActionResult ReporteResumenFiscalizacionPau(String[] modalidad, String[] direccion, String[] direccionFisc, string anio, String[] departamento, string instancia)
        {

            List<VM_ReporteGeneral> lstvm = new List<VM_ReporteGeneral>();
            List<Ent_Reporte_PAU_CONCLUIDO> ListCampos = new List<Ent_Reporte_PAU_CONCLUIDO>();
            Ent_Reporte_PAU_CONCLUIDO oCEntidad = new Ent_Reporte_PAU_CONCLUIDO();
            Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
            oCEntidad.BusInstancia = instancia;//asBusInstancia == "DFFFS" ? "DFFFS" : "DFFFS,TFFS,PJ";
            oCEntidad.BusModalidad = ObtenerCadenaArray(modalidad);
            oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
            oCEntidad.BusDireccion2 = ObtenerCadenaArray(direccionFisc);
            oCEntidad.BusRegion = ObtenerCadenaArray(departamento);
            oCEntidad.BusFechaFin = anio;
            oCEntidad.BusCriterio = "RESUMEN";


            oCEntidad.COD_ITIPO = "0000001";
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de Supervisión (2009 - en adelante)", listPauConcluido = ListCampos });


            oCEntidad.COD_ITIPO = "0000002,0000004";
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de Suspensión", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000003,0000007"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes Técnicos e Informes de Acompañamiento", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000005"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de la Autoridad Forestal", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000006"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Supervisiones OSINFOR-INRENA", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000008"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Otros Informes OSINFOR-INRENA", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000009"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Solicitudes de Renuncias a la Concesión", listPauConcluido = ListCampos });

            oCEntidad.COD_ITIPO = "0000010"; ;
            ListCampos = exeBus.Log_ExpedientesAdministrativosResumen(oCEntidad);
            lstvm.Add(new VM_ReporteGeneral { tituloReporte = "PAU Concluidos a partir de Informes de Auditoría Quinquenal", listPauConcluido = ListCampos });


            return PartialView("~/Areas/General/Views/ReporteFiscalizacion/_sharedRptFiscalizacionPau/_renderResumen.cshtml", lstvm);
        }

        public String ObtenerCadenaArray(String[] array)
        {
            String cadena;
            try
            {
                cadena = "";
                for (int i = 0; i < array.Length; i++)
                {
                    cadena = cadena + "" + array[i].ToString() + "" + ",";
                }
                return cadena.TrimEnd(',');
            }
            catch
            {
                cadena = "";
                return cadena;
            }
        }
        [HttpPost]
        public ActionResult Rpt_Fiscalizacion_Resumen(Dictionary<string, string> cabecera, VM_ReporteGeneral resumen, string opcion = null)
        {
            string dir = string.Format("~/Archivos/Plantilla/RptFiscalizacionPau{0}.xlsx", opcion != null ? "Detalle" : "Resumen");
            FileInfo template = new FileInfo(Server.MapPath(dir));
            int rowStart = 2;

            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (resumen.listPauConcluido != null)
                {
                    int column = 0;

                    foreach (var item in resumen.listPauConcluido)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ANIO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SUPERVISION;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ARCHIVO_PRELIMINAR;

                        if (opcion != null) worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ARCHIVO_PRELIMINAR_SIN; //

                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.INI_PAU;

                        if (opcion != null) worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SUPER_TERMINADO_PAU; //

                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CANTIDAD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = Math.Round(item.AVANCE * 100, 2).ToString() + " %";

                        if (opcion != null) worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MEDCAU_PAU;//

                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TERMINO_PAU;

                        if (opcion != null)
                        {
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SANCIONADO_PAU;//
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MED_CORREC_PAU;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.AMONEST_PAU;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CADUCADO_PAU;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CADUCADO_PAU_TH;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CADUCADO_PAU_TH_PRV;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ARCHIVO_PAU;//
                        }


                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = Math.Round(item.AVANCE1 * 100, 2).ToString() + " %";
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CASOS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = Math.Round(item.AVANCE_CASOS * 100, 2).ToString() + " %";



                        if (opcion != null)
                        {

                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SANCIONADO_PAU_1RA;//
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SANCIONADO_PAU_2DA;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MONTO_MULTA;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MONTO_MULTA_FINAL;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MONTO_MULTA_FIRME;//
                        }

                        rowStart++;
                    }


                }
                string excelName = cabecera["Titulo"] != null ? cabecera["Titulo"].ToString() : "RptFiscalizacionPau" + (opcion != null ? "Detalle" : "Resumen");
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
        public ActionResult TableroEstadistico()
        {
            CapaLogica.DOC.Log_RESODIREC oCLogica = new CapaLogica.DOC.Log_RESODIREC();
            VM_Resodirec vm = new VM_Resodirec();
            Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
            oCEntidad.BusFormulario = "REPORTE_FISCA";
            oCEntidad.BusCriterio = "ANIO";
            oCEntidad.BusValor = "";
            vm.sBusqueda = oCLogica.busCombo(oCEntidad);

            return View(vm);
        }

        [HttpPost]
        public JsonResult ObtenerReporte01(string tipo, string anio)
        {
            try
            {
                CapaLogica.DOC.Log_RESODIREC oCLogica = new CapaLogica.DOC.Log_RESODIREC();
                VM_Resodirec vm = new VM_Resodirec();
                Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
                oCEntidad.BusFormulario = "REPORTE_FISCA";
                oCEntidad.BusCriterio = tipo;
                oCEntidad.BusValor = anio;
                List<Dictionary<string, string>> olResult = oCLogica.registroUsuarioRD(oCEntidad);
                VM_TableroEstadistico _dto = new VM_TableroEstadistico();

                bool sucess = false;

                if (olResult.Count > 0)
                {
                    sucess = true;
                    if (tipo == "RDTERMINO")
                    {
                        foreach (var itemPart in olResult)
                        {
                            _dto.RESOLUCIONES = itemPart["RESOLUCIONES"] ?? "0";
                            _dto.ALLANAMIENTO = itemPart["ALLANAMIENTO"] ?? "0";
                            _dto.PORC_ALLANAMIENTO = (itemPart["PORC_ALLANAMIENTO"] ?? "0") + " %";
                            _dto.SUBSANACION = itemPart["SUBSANACION"] ?? "0";
                            _dto.PORC_SUBSANACION = (itemPart["PORC_SUBSANACION"] ?? "0") + " %";
                            _dto.DECOMISO = itemPart["DECOMISO"] ?? "0";
                            _dto.PORC_DECOMISO = (itemPart["PORC_DECOMISO"] ?? "0") + " %";
                            _dto.PLAN_CIERRE = itemPart["PLAN_CIERRE"] ?? "0";
                            _dto.PORC_PLAN_CIERRE = (itemPart["PORC_PLAN_CIERRE"] ?? "0") + " %";
                            _dto.DISP_FAUNA = itemPart["DISP_FAUNA"] ?? "0";
                            _dto.PORC_DISP_FAUNA = (itemPart["PORC_DISP_FAUNA"] ?? "0") + " %";
                            _dto.MEDIDA_CORRECTIVA = itemPart["MEDIDA_CORRECTIVA"] ?? "0";
                            _dto.PORC_MEDIDA_CORRECTIVA = (itemPart["PORC_MEDIDA_CORRECTIVA"] ?? "0") + " %";
                            _dto.ARCHIVO = itemPart["ARCHIVO"] ?? "0";
                            _dto.PORC_ARCHIVO = (itemPart["PORC_ARCHIVO"] ?? "0") + " %";
                        }
                    }
                    if (tipo == "RDINICIO")
                    {
                        foreach (var itemPart in olResult)
                        {
                            _dto.RESOLUCIONES = itemPart["RESOLUCIONES"] ?? "0";
                            _dto.MEDIDA_CAUT = itemPart["MEDIDA_CAUT"] ?? "0";
                            _dto.PORC_MEDIDA_CAUT = (itemPart["PORC_MEDIDA_CAUT"] ?? "0") + " %";
                            _dto.MED_CAUT_GTF = itemPart["MED_CAUT_GTF"] ?? "0";
                            _dto.PORC_MED_CAUT_GTF = (itemPart["PORC_MED_CAUT_GTF"] ?? "0") + " %";
                            _dto.LIST_TROZA = itemPart["LIST_TROZA"] ?? "0";
                            _dto.PORC_LIST_TROZA = (itemPart["PORC_LIST_TROZA"] ?? "0") + " %";
                            _dto.PM = itemPart["PM"] ?? "0";
                            _dto.PORC_PM = (itemPart["PORC_PM"] ?? "0") + " %";
                            _dto.POA = itemPart["POA"] ?? "0";
                            _dto.PORC_POA = (itemPart["PORC_POA"] ?? "0") + " %";
                        }
                    }
                }
                return Json(new { success = sucess, result = _dto });
            }
            catch
            {
                return Json(new { success = true, result = "" });
            }
        }

        public ActionResult detalleReport01(string tipo, string anio)
        {
            VM_TableroEstadistico _dto = new VM_TableroEstadistico();
            try
            {
                CapaLogica.DOC.Log_RESODIREC oCLogica = new CapaLogica.DOC.Log_RESODIREC();
                VM_Resodirec vm = new VM_Resodirec();
                Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
                oCEntidad.BusFormulario = "REPORTE_FISCA";
                oCEntidad.BusCriterio = "RESUMEN01";
                oCEntidad.BusValor = anio;
                List<Ent_RESODIREC_REPORTEMEDIDAD> olResult = oCLogica.reporteDetalle(oCEntidad);
                _dto.detalle01 = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
                if (olResult.Count > 0)
                {
                    if (tipo == "0") // todos
                    {
                        _dto.detalle01 = olResult;
                    }
                    if (tipo == "1")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.ALLANAMIENTO == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "2")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.SUBSANACION == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }

                    if (tipo == "3")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.DECOMISO == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "4")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.PLAN_CIERRE == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "5")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.DISP_FAUNA == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "6")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.MED_CORRECTIVA == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "7")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.ARCHIVO == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                }
            }
            catch
            {
                _dto.detalle01 = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
            }
            Session["lisReport"] = _dto.detalle01;
            return PartialView("~/Areas/General/Views/ReporteFiscalizacion/_sharedRptFiscalizacionPau/_renderDetalle01.cshtml", _dto);
        }


        public ActionResult detalleReport02(string tipo, string anio)
        {
            VM_TableroEstadistico _dto = new VM_TableroEstadistico();
            try
            {
                CapaLogica.DOC.Log_RESODIREC oCLogica = new CapaLogica.DOC.Log_RESODIREC();
                VM_Resodirec vm = new VM_Resodirec();
                Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
                oCEntidad.BusFormulario = "REPORTE_FISCA";
                oCEntidad.BusCriterio = "RESUMEN02";
                oCEntidad.BusValor = anio;
                List<Ent_RESODIREC_REPORTEMEDIDAD> olResult = oCLogica.reporteDetalle2(oCEntidad);
                _dto.detalle01 = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
                if (olResult.Count > 0)
                {
                    if (tipo == "0") // todos
                    {
                        _dto.detalle01 = olResult;
                    }
                    if (tipo == "1")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.MED_CAUTELAR == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "2")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.GUIA_TF == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }

                    if (tipo == "3")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.LISTA_TROZAS == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "4")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.PLAN_MANEJO == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                    if (tipo == "5")
                    {
                        foreach (Ent_RESODIREC_REPORTEMEDIDAD item in olResult)
                        {
                            if (item.POA == "Si")
                            {
                                _dto.detalle01.Add(item);
                            }
                        }
                    }
                }
            }
            catch
            {
                _dto.detalle01 = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
            }
            Session["lisReport"] = _dto.detalle01;
            return PartialView("~/Areas/General/Views/ReporteFiscalizacion/_sharedRptFiscalizacionPau/_renderDetalle02.cshtml", _dto);
        }

        public JsonResult ExportarInfracciones()
        {
            CapaLogica.DOC.Log_RESODIREC oCLogica = new CapaLogica.DOC.Log_RESODIREC();
            ListResult result = new ListResult();
            List<Ent_RESODIREC_REPORTEMEDIDAD> listDetalle = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
            listDetalle = (List<Ent_RESODIREC_REPORTEMEDIDAD>)Session["lisReport"];
            result = oCLogica.exportReporteDetalle(listDetalle);
            return Json(result);
        }

        public JsonResult ExportarInfracciones2()
        {
            CapaLogica.DOC.Log_RESODIREC oCLogica = new CapaLogica.DOC.Log_RESODIREC();
            ListResult result = new ListResult();
            List<Ent_RESODIREC_REPORTEMEDIDAD> listDetalle = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
            listDetalle = (List<Ent_RESODIREC_REPORTEMEDIDAD>)Session["lisReport"];
            result = oCLogica.exportReporteDetalle2(listDetalle);
            return Json(result);
        }
    }
}