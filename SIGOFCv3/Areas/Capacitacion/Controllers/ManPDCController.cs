using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using SIGOFCv3.Reportes.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM = CapaEntidad.ViewModel.VM_ReporteGeneral;

namespace SIGOFCv3.Areas.Capacitacion.Controllers
{
    public class ManPDCController : Controller
    {
        public static VM vmReport = new VM();
        public static VM busqueda = new VM();

        // GET: Capacitacion/ManPDC
        public ActionResult IndexPDC()
        {
            vmReport = new VM();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            vmReport.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            vmReport.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

            return View(vmReport);
        }

        public ActionResult RUniverso(String[] oficinas, String[] departamento, string titulo, string titular)
        {
            if (oficinas != null)
            {
                busqueda.od = ObtenerCadenaArray(oficinas).ToUpper();
            }
            else
            {
                busqueda.od = "";
            }
            if (departamento != null)
            {
                busqueda.departamento = ObtenerCadenaArray(departamento).ToUpper();
            }
            else
            {
                busqueda.departamento = "";
            }

            busqueda.titular = titular.ToUpper();
            busqueda.titulo = titulo.ToUpper();
            //vmReport.formulario = "PDC_UNIVERSO"; 
            ;
            if (busqueda.od != "" && busqueda.departamento != "" && busqueda.titular == "" && busqueda.titulo == "")
            {
                busqueda.formulario = "PDC_UNIVERSO_FILTRO_01";
            }
            if (busqueda.od != "" && busqueda.departamento != "" && (busqueda.titular != "" || busqueda.titulo != ""))
            {
                busqueda.formulario = "PDC_UNIVERSO_FILTRO_02";
            }
            //vmReport.list_universoPDC = exeBus.RepUniversoPDC(ent);
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_redenTUPDC.cshtml");
        }

        [HttpGet]
        public JsonResult ConsultTablaUniverso(DataTableRequest request = null)
        {
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();

            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();

            //int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            ent.BusFormulario = busqueda.formulario;
            ent.BusOD = busqueda.od;
            ent.BusDepartamento = busqueda.departamento;
            ent.BusValor = busqueda.titulo + " " + busqueda.titular;
            ent.v_pagesize = request.Length;
            ent.v_currentpage = page;

            //---modificar 
            vmReport = exeBus.RepUniversoPDC_pag(ent);

            var jsonResult = Json(new
            {
                data = vmReport.list_universoPDC.ToArray(),
                draw = request.Draw,
                recordsTotal = vmReport.v_ROW_INDEX,
                recordsFiltered = vmReport.v_ROW_INDEX,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult DescargarUniverso()
        {
            vmReport.list_universoPDC = new List<Ent_ReportePDC>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            if (busqueda.formulario == "PDC_UNIVERSO_FILTRO_01")
            {
                busqueda.formulario = "PDC_UNIVERSO_FILTRO_01_DESCARGA";
            }
            if (busqueda.formulario == "PDC_UNIVERSO_FILTRO_02")
            {
                busqueda.formulario = "PDC_UNIVERSO_FILTRO_02_DESCARGA";
            }

            ent.BusFormulario = busqueda.formulario;
            ent.BusOD = busqueda.od;
            ent.BusDepartamento = busqueda.departamento;
            ent.BusValor = busqueda.titulo + " " + busqueda.titular;

            if (busqueda.formulario == "PDC_CONSOLIDADO_DETALLE")
            {
                ent.BusFormulario = "PDC_CONSOLIDADO_DETALLE_DESCARGA";
                ent.BusDepartamento = "";
                ent.BusValor = busqueda.departamento;
            }
            if (busqueda.formulario == "PDC_TALLER_DETALLE")
            {
                ent.BusFormulario = "PDC_TALLER_DETALLE_DESCARGA";
                ent.BusOD = busqueda.od;
                ent.BusValor = busqueda.departamento;               
            }

            vmReport.list_universoPDC = exeBus.RepUniversoPDC(ent);

            ListResult result = new ListResult();
            result = ReporteManGrilla.ExportUniversoPDC(vmReport.list_universoPDC);

            return Json(result);
        }

        [HttpGet]
        public JsonResult ConsultTablaUniversoDetalle(DataTableRequest request = null)
        {
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();

            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();

            //int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            ent.BusFormulario = busqueda.formulario;
            ent.BusOD = busqueda.od;
            ent.BusValor = busqueda.departamento;
            ent.v_pagesize = request.Length;
            ent.v_currentpage = page;

            //---modificar 
            vmReport = exeBus.RepUniversoPDC_pag(ent);

            var jsonResult = Json(new
            {
                data = vmReport.list_universoPDC.ToArray(),
                draw = request.Draw,
                recordsTotal = vmReport.v_ROW_INDEX,
                recordsFiltered = vmReport.v_ROW_INDEX,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public String ObtenerCadenaArray(String[] array)
        {
            String cadena;
            try
            {
                cadena = "";
                for (int i = 0; i < array.Length; i++)
                {
                    cadena = cadena + "'" + array[i].ToString() + "'" + ",";
                }
                return cadena.TrimEnd(',');
            }
            catch
            {
                cadena = "";
                return cadena;
            }
        }



        public ActionResult IndexConsolidado()
        {
            return View();
        }

        public ActionResult ReporteConsolidado()
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            ent.BusFormulario = "PDC_CONSOLIDADO";
            vmReport.list_consolidado_PDC = exeBus.RepconsolidadoPDC(ent);
            calcularTalleres(vmReport.list_consolidado_PDC);
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_renderResumen.cshtml", vmReport);
        }

        //metodo para obtener los talleres 
        public ActionResult ReporteTalleres()
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            ent.BusFormulario = "PDC_TALLER";
            vmReport.list_universoPDC = exeBus.PDC_TALLERES(ent);
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_renderTalleres.cshtml", vmReport);
        }

        public ActionResult ReporteTallerDetalle(string lugar, string modalidad)
        {
            busqueda.formulario = "PDC_TALLER_DETALLE";
            busqueda.od = lugar;
            busqueda.departamento = modalidad;
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_renderTallerDetalle.cshtml");
        }

        public ActionResult ReporteTallerDetallePASPEQ(string lugar, string modalidad)
        {
            busqueda.formulario = "PDC_TALLER_DETALLE_PASPEQ";
            busqueda.od = lugar;
            busqueda.departamento = modalidad;
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_renderTallerDetalle.cshtml");
        }

        [HttpGet]
        public JsonResult ConsultTablaTallerDetalle(DataTableRequest request = null)
        {
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();

            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();

            //int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            ent.BusFormulario = busqueda.formulario;
            ent.BusOD = busqueda.od;
            ent.BusValor = busqueda.departamento;
            ent.v_pagesize = request.Length;
            ent.v_currentpage = page;

            //---modificar 
            vmReport = exeBus.RepUniversoPDC_pag(ent);

            var jsonResult = Json(new
            {
                data = vmReport.list_universoPDC.ToArray(),
                draw = request.Draw,
                recordsTotal = vmReport.v_ROW_INDEX,
                recordsFiltered = vmReport.v_ROW_INDEX,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }



        public ActionResult ReporteConsolidadoDetalle(string oficina, string modalidad)
        {
            busqueda.formulario = "PDC_CONSOLIDADO_DETALLE";
            busqueda.od = oficina;
            busqueda.departamento = modalidad;
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_rederTUPDCDet.cshtml");
        }


        public void lugarTaller(List<Ent_ReportePDC> listaPDC)
        {
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_ReportePDC ent = new CapaEntidad.DOC.Ent_ReportePDC();

            //seccion de codigo para buscar el districo con mayor frecuencia
            //la condicion es que sea mayor a 6 para considerarlo 
            //variables para indicar la cantidad y el lugar del taller
            var cant = 0;
            var lugarT = "";

            //debemos obtener el distrito con mayor frecuencia
            var distrito = (from report in listaPDC select report.DISTRITO).Distinct();

            foreach (var d in distrito)
            {
                var listDist = from cust in listaPDC
                               where cust.DISTRITO == d
                               select cust;
                if (listDist.Count() > cant)
                {
                    cant = listDist.Count();
                    lugarT = "Distrito: " + d;
                }

            }
            if (cant == 0)
            {

                //caso contrario hacemos el recorrido a nivel de provincia
                var provincia = (from report in listaPDC select report.PROVINCIA).Distinct();
                foreach (var d in provincia)
                {
                    var listDist = from cust in listaPDC
                                   where cust.PROVINCIA == d
                                   select cust;
                    if (listDist.Count() > 6 && listDist.Count() > cant)
                    {
                        cant = listDist.Count();
                        lugarT = "Provincia: " + d;
                    }

                }
                if (cant == 0)
                {
                    //caso contrario buscamos por departamentos
                    var departamento = (from report in listaPDC select report.DEPARTAMENTO).Distinct();
                    foreach (var d in departamento)
                    {
                        var listDist = from cust in listaPDC
                                       where cust.DEPARTAMENTO == d
                                       select cust;
                        if (listDist.Count() > 6 && listDist.Count() > cant)
                        {
                            cant = listDist.Count();
                            lugarT = "Departamento: " + d;
                        }

                    }
                }

            }
            if (cant > 0)
            {
                //hacemos la actualizacion a nivel de base de datos en los campos creados -- implementar el metodo
                foreach (var obj in listaPDC)
                {
                    ent = new Ent_ReportePDC();
                    ent.IDREGISTRO = Int32.Parse(obj.ID_REGISTRO);
                    ent.CAPACITABLE = lugarT;
                    ent.TALLER = 1;
                    var id = exeBus.asignar_taller(ent);

                }
            }
            var result = 0;
        }
        /// <summary>
        /// metodo para hacer el calculo de talleres y el lugar del taller
        /// </summary>
        /// <param name="oficina_desconcentrada"></param>
        /// <param name="cod_modalidad"></param>
        public void CantidadTaller(String oficina_desconcentrada, String cod_modalidad, int nZise)
        {
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            List<Ent_ReportePDC> listTemReport = new List<Ent_ReportePDC>();

            listTemReport = new List<Ent_ReportePDC>();
            ent.BusFormulario = "PDC_CONSOLIDADO_DETALLE_DESCARGA";
            ent.BusOD = oficina_desconcentrada;
            ent.BusValor = cod_modalidad;
            listTemReport = exeBus.RepUniversoPDC(ent);
            //minimo 7 maximo 40
            var total = listTemReport.Count();


            if (total > nZise)
            {
                //dividimos entre 40 y no acercamos al numero mayor
                //reordenamos por distrito
                listTemReport = listTemReport.OrderBy(x => x.DISTRITO).ToList();

                //otro metodo
                var listas = new List<List<Ent_ReportePDC>>();
                for (int i = 0; i < listTemReport.Count; i += nZise)
                {
                    listas.Add(listTemReport.GetRange(i, Math.Min(nZise, listTemReport.Count - i)));
                }
                if (listas.Count > 0)
                {
                    for (int j = 0; j < listas.Count; j++)
                    {
                        var listTemporal = listas[j];
                        if (listTemporal.Count > 6)
                        {
                            lugarTaller(listTemporal);
                        }
                    }
                }
            }
            else
            {
                lugarTaller(listTemReport);
            }
        }



        /// <summary>
        /// metodo para realizar la asignacion de los talleres
        /// </summary>
        /// <param name="listTemp"></param>
        public void calcularTalleres(List<Ent_ReportConsolidadoPDC> listTemp)
        {
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            Ent_CAPACITACION entTemp = new Ent_CAPACITACION();
            exeBus.REPORTPDC_CAMBIAR_ESTADO_TALLER(entTemp);

            foreach (var PDC in listTemp)
            {
                if (PDC.COD_MODALIDAD == "0000015" || PDC.COD_MODALIDAD == "0000016")
                {
                    if (PDC.ATALAYA > 0)
                    {
                        CantidadTaller("ATALAYA", PDC.COD_MODALIDAD, 20);
                    }
                    if (PDC.CHICLAYO > 0)
                    {
                        CantidadTaller("CHICLAYO", PDC.COD_MODALIDAD, 20);
                    }
                    if (PDC.IQUITOS > 0)
                    {
                        CantidadTaller("IQUITOS", PDC.COD_MODALIDAD, 20);
                    }
                    if (PDC.LA_MERCED > 0)
                    {
                        CantidadTaller("LA MERCED", PDC.COD_MODALIDAD, 20);
                    }
                    if (PDC.PUCALLPA > 0)
                    {
                        CantidadTaller("PUCALLPA", PDC.COD_MODALIDAD, 20);
                    }
                    if (PDC.PUERTO_MALDONADO > 0)
                    {
                        CantidadTaller("PUERTO MALDONADO", PDC.COD_MODALIDAD, 20);

                    }
                    if (PDC.TARAPOTO > 0)
                    {
                        CantidadTaller("TARAPOTO", PDC.COD_MODALIDAD, 20);
                    }
                    if (PDC.SEDE_CENTRAL > 0)
                    {
                        CantidadTaller("SEDE CENTRAL", PDC.COD_MODALIDAD, 20);
                    }
                }
                else
                {
                    if (PDC.ATALAYA > 6)
                    {
                        CantidadTaller("ATALAYA", PDC.COD_MODALIDAD, 40);
                    }
                    if (PDC.CHICLAYO > 6)
                    {
                        CantidadTaller("CHICLAYO", PDC.COD_MODALIDAD, 40);
                    }
                    if (PDC.IQUITOS > 6)
                    {
                        CantidadTaller("IQUITOS", PDC.COD_MODALIDAD, 40);
                    }
                    if (PDC.LA_MERCED > 6)
                    {
                        CantidadTaller("LA MERCED", PDC.COD_MODALIDAD, 40);
                    }
                    if (PDC.PUCALLPA > 6)
                    {
                        CantidadTaller("PUCALLPA", PDC.COD_MODALIDAD, 40);
                    }
                    if (PDC.PUERTO_MALDONADO > 6)
                    {
                        CantidadTaller("PUERTO MALDONADO", PDC.COD_MODALIDAD, 40);

                    }
                    if (PDC.TARAPOTO > 6)
                    {
                        CantidadTaller("TARAPOTO", PDC.COD_MODALIDAD, 40);
                    }
                    if (PDC.SEDE_CENTRAL > 6)
                    {
                        CantidadTaller("SEDE CENTRAL", PDC.COD_MODALIDAD, 40);
                    }
                }
            }

        }



        public ActionResult IndexImport()
        {
            return View();
        }

        public ActionResult TablaImportPASPEQ()
        {
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_renderTImport.cshtml");
        }

        [HttpGet]
        public JsonResult ConsultTablaImport(DataTableRequest request = null)
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();

            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            CapaEntidad.DOC.Ent_PDCImportPASPEQ entpaspeq = new CapaEntidad.DOC.Ent_PDCImportPASPEQ();

            //int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            ent.BusFormulario = request.CustomSearchForm;
            ent.BusCriterio = request.CustomSearchType;//NUM_EXPEDIENTE||NUM_RESOLUCION
            ent.BusValor = request.Search.Value;

            if (ent.BusValor.Length > 2)
            {
                ent.BusFormulario = "PDC_CONSOLIDADO_PASPEQ_SEARCH";
            }

            ent.v_pagesize = request.Length;
            ent.v_currentpage = page;

            vmReport.list_PDC_Import = exeBus.ImportPDC_PASPEQ(ent);
            ent = new Ent_CAPACITACION();
            ent.BusFormulario = "PDC_CONSOLIDADO_PASPEQ_COUNT";
            entpaspeq = exeBus.ImportPDC_PASPEQ_COUNT(ent);

            var jsonResult = Json(new
            {
                data = vmReport.list_PDC_Import.ToArray(),
                draw = request.Draw,
                recordsTotal = entpaspeq.v_ROW_INDEX,
                recordsFiltered = entpaspeq.v_ROW_INDEX,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// importacion de paspeq
        /// </summary>
        /// <returns></returns>
        public JsonResult ImportarPAPEQ()
        {
            int band = 0;
            string mensaje = "Existe un error en: ";
            string err = "";
            List<Ent_PDCImportPASPEQ> listImport = new List<Ent_PDCImportPASPEQ>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_PDCImportPASPEQ ent = new CapaEntidad.DOC.Ent_PDCImportPASPEQ();
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
                            var obj = new Ent_PDCImportPASPEQ();
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 2].Value.ToString() != "")
                                {
                                    obj = new Ent_PDCImportPASPEQ();
                                    obj.ESTADO = 1;
                                    obj.ANIO = 0;
                                    obj.ID_REGISTRO = 0;
                                    obj.TITULO = workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString();
                                    obj.ENFOQUE = workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString();
                                    obj.MES_FOCALIZACION = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString();
                                    obj.MES = workSheet.Cells[rowIterator, 4].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 4].Value.ToString());

                                    listImport.Add(obj);

                                }
                                else
                                {
                                    band = 1;
                                    mensaje = mensaje + " " + workSheet.Cells[rowIterator, 1].Value.ToString() + " ,";
                                }
                            }
                        }
                    }
                }
                if (listImport.Count > 0)
                {
                    Ent_CAPACITACION entTemp = new Ent_CAPACITACION();
                    exeBus.ImportPDC_PASPEQ_CAMBIAR_ESTADO(entTemp);

                    var sesion = (ModelSession.GetSession())[0].COD_UCUENTA;
                    ListResult result = new ListResult();
                    foreach (Ent_PDCImportPASPEQ obj in listImport)
                    {
                        result = exeBus.GuardarDatosPasPEQ(obj, sesion);
                        //(ModelSession.GetSession())[0].COD_UCUENTA
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
                //data = vmRD.ListEspecieMedCorrectiva,
                error = err
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEspecies.cshtml", vmInfLegal);

        }


        public JsonResult ExportarPASPEQ()
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_PDC_Import = new List<Ent_PDCImportPASPEQ>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            ent.BusFormulario = "PDC_CONSOLIDADO_PASPEQ_REPORT";

            vmReport.list_PDC_Import = exeBus.ImportPDC_PASPEQ(ent);

            ListResult result = new ListResult();
            result = exeBus.ExportPASPEQ(vmReport.list_PDC_Import);
            return Json(result);
        }

    }
}