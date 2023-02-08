using CapaEntidad.ViewModel;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_INFORME;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeFaunaController : Controller
    {
        [HttpPost]
        public JsonResult AddEditFauna(VM_Informe_Fauna dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GuardarDatosInformeFauna(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public PartialViewResult _ResponsabilidadSocial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _POAFaunaSupervisado(string asCodInforme, Int32 aiNumPoa)
        {
            CLogica exeInf = new CLogica();
            VM_Informe_POAFaunaSupervisado vm = exeInf.InitDatosPOAFaunaSupervisado(asCodInforme, aiNumPoa);
            return PartialView(vm);
        }
        [HttpPost]
        public JsonResult GrabarPOAFaunaSupervisado(VM_Informe_POAFaunaSupervisado dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GuardarDatosPOAFaunaSupervisado(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        [HttpPost]
        public PartialViewResult _InfraestructuraImpl()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _Zonificacion()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _AprovSostenible()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActoObligacion()
        {
            return PartialView();
        }
    }
}