using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Supervision.Models.ManInforme;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_INFORME;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeTaraController : Controller
    {
        [HttpPost]
        public JsonResult AddEditTara(VM_Informe_Tara dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GuardarDatosInformeTara(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public PartialViewResult _ManPlantacion()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlManActividad = exeBus.RegMostComboIndividual("MANTENIMIENTO_PLANTACION", "");
            ViewBag.ddlOpcionSiNo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},
                new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"}
            };
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _Aprovechamiento()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _Capacitacion()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ProduccionFruto()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _AprovechaForestal()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ArbolSupervisado()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlPresenciaVaina = exeBus.RegMostComboIndividual("PRESENCIA_VAINAS", "");
            ViewBag.ddlOpcionSiNo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},
                new VM_Cbo() { Value="SI",Text="SI"},
                new VM_Cbo() { Value="NO",Text="NO"}
            };
            ViewBag.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _Kardex()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult ImportarDatosInformeSimpleTara(string asTipo)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipo)
                    {
                        case "CENSO": result = ImportarDatos.CensoTara(Request); break;
                        case "KARDEX": result = ImportarDatos.KardexTara(Request); break;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
            return Json(new { success = true, msj = "", data = result });
        }
    }
}