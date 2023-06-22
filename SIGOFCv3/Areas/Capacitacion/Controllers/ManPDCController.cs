using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
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

        // GET: Capacitacion/ManPDC
        public ActionResult IndexPDC()
        {
            VM_ReporteGeneral model = new VM_ReporteGeneral();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            model.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
            model.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

            return View(model);
        }

        public ActionResult RUniverso(String[] oficinas, String[] departamento, string titulo, string titular)
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();

            if (oficinas != null)
            {
                ent.BusOD = ObtenerCadenaArray(oficinas).ToUpper();
            }
            else
            {
                ent.BusOD = "";
            }
            if (departamento != null)
            {
                ent.BusDepartamento = ObtenerCadenaArray(departamento).ToUpper();
            }
            else
            {
                ent.BusDepartamento = "";
            }

            ent.BusTitular = titular;
            ent.BusTitulo = titulo;
            ent.BusFormulario = "PDC_UNIVERSO";
            if (ent.BusOD != "" && ent.BusDepartamento != "" && ent.BusTitular == "" && ent.BusTitulo == "")
            {
                ent.BusFormulario = "PDC_UNIVERSO_FILTROS";
            }
            if (ent.BusOD != "" && ent.BusDepartamento != "" && ent.BusTitular != "" && ent.BusTitulo == "")
            {
                ent.BusFormulario = "PDC_UNIVERSO_FILTROS_TITULAR";
            }
            if (ent.BusOD != "" && ent.BusDepartamento != "" && ent.BusTitular == "" && ent.BusTitulo != "")
            {
                ent.BusFormulario = "PDC_UNIVERSO_FILTROS_TITULO";
            }
            if (ent.BusOD != "" && ent.BusDepartamento != "" && ent.BusTitular != "" && ent.BusTitulo != "")
            {
                ent.BusFormulario = "PDC_UNIVERSO_FILTROS_TODO";
            }

            vmReport.list_universoPDC = exeBus.RepUniversoPDC(ent);
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_redenTUPDC.cshtml", vmReport);
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

        public JsonResult DescargarUniversoPDC()
        {
            ListResult result = new ListResult();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            //result = exeBus.DescargaUniversoPDC(vmReport.list_universoPDC);
            result = exeBus.DesacargarExcelOpcion2(vmReport.list_universoPDC);
            return Json(result);
        }

        public ActionResult IndexConsolidado()
        {
            return View();
        }

        public ActionResult ReporteConsolidado(string codUsuario)
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            ent.BusFormulario = "PDC_CONSOLIDADO";
            vmReport.list_consolidado_PDC = exeBus.RepconsolidadoPDC(ent);
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_renderResumen.cshtml", vmReport);
        }

        public ActionResult ReporteConsolidadoDetalle(string oficina, string modalidad)
        {
            vmReport = new VM_ReporteGeneral();
            vmReport.list_universoPDC = new List<CapaEntidad.DOC.Ent_ReportePDC>();
            CapaLogica.DOC.Log_CAPACITACION exeBus = new CapaLogica.DOC.Log_CAPACITACION();
            CapaEntidad.DOC.Ent_CAPACITACION ent = new CapaEntidad.DOC.Ent_CAPACITACION();
            ent.BusFormulario = "PDC_CONSOLIDADO_DETALLE";
            ent.BusModalidad = modalidad;
            ent.BusOD = oficina;
            vmReport.list_universoPDC = exeBus.RepUniversoPDC(ent);
            return PartialView("~/Areas/Capacitacion/Views/ManPDC/_rederTUPDCDet.cshtml", vmReport);
        }
    }
}