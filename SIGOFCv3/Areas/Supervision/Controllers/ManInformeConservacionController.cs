using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_INFORME;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeConservacionController : Controller
    {
        [HttpPost]
        public JsonResult AddEditConservacion(VM_Informe_Conservacion dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GuardarDatosInformeConservacion(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public PartialViewResult _CoordenadaUTM()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _InfraestructuraImpl()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActTuristica()
        {
          
            ViewBag.ddlZona = new Log_BUSQUEDA().RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _InterpretacionAmbiental()
        {

            ViewBag.ddlZona = new Log_BUSQUEDA().RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActInvestigacion()
        {

            ViewBag.ddlZona = new Log_BUSQUEDA().RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActVisitas()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActOtrosProgramas()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadCapacitacion()
        {
            ViewBag.ddlOpcionSiNo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},
                new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"}
            };
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadInvestigacion()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ManejoImpacto()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _RegistroFlora()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _RegistroPaisaje()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EquipamientoCons()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _CapacitacionEfectuadaCons()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadLocalCons()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _DocumentoGestionCons()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadObligacion()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _AprovEspecieObligacion()
        {
            ViewBag.ddlOpcionSiNo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},
                new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"}
            };
            return PartialView();
        }
    }
}