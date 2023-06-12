using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Supervision.Models.ManInforme;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_INFORME;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeExSituController : Controller
    {
        [HttpPost]
        public JsonResult AddEditExSitu(VM_Informe_ExSitu dto)
        {
            CLogica exeInf = new CLogica();
            ListResult result = exeInf.GuardarDatosInformeExSitu(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        #region "Mantenimiento Infraestructura y Cautiverio"
        [HttpPost]
        public PartialViewResult _AreaExSitu()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlMaterial = exeBus.RegMostComboIndividual("AREA_EXITU_MATERIAL", "");
            ViewBag.ddlCartel = exeBus.RegMostComboIndividual("AREA_EXITU_CARTEL", "");
            ViewBag.ddlEquipo = exeBus.RegMostComboIndividual("AREA_EXITU_EQUIPO", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _RelPerCentroCria()
        {                        
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _GrupoTaxonomico()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlTipoTaxonomico = exeBus.RegMostComboIndividual("GRUPO_TAXONOMICO_EXSITU", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EquipoContencion(string asTipo)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            switch (asTipo)
            {
                case "CONTENCION_FISICA": ViewBag.ddlTipoEquipo = exeBus.RegMostComboIndividual("EQUIPO_CONT_FISICA_EXSITU", ""); break;
                case "CONTENCION_QUIMICA": ViewBag.ddlTipoEquipo = exeBus.RegMostComboIndividual("EQUIPO_CONT_QUIMICA_EXSITU", ""); break;
                case "EQUIPO_DESINFECCION": ViewBag.ddlTipoEquipo = exeBus.RegMostComboIndividual("EQUIPO_DESINFECCION_EXSITU", ""); break;
            }
            ViewBag.hdfTipo = asTipo;

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ControlPlaga()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlPlaga = exeBus.RegMostComboIndividual("CONTROL_PLAGA_EXSITU", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ManejoRegistro()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlRegistro = exeBus.RegMostComboIndividual("MANEJO_REGISTRO_EXSITU", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EnriquecimientoAmb()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlTipoTaxonomico = exeBus.RegMostComboIndividual("GRUPO_TAXONOMICO_EXSITU", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EspecieReproducida()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlFrecReproduccion = exeBus.RegMostComboIndividual("FREC_REPRODUCCION_EXSITU", "");
            ViewBag.ddlEspecieOrigen = exeBus.RegMostComboIndividual("ESPECIE_ORIGEN", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EspecieCapturada()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _TraslocEspec()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EspecieNacimiento(string asTipo)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlEspecieSexo = exeBus.RegMostComboIndividual("ESPECIE_SEXO", "");
            ViewBag.ddlOpcionSiNo = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" }, new VM_Cbo() { Value = "Si", Text = "SI" }, new VM_Cbo() { Value = "No", Text = "NO" } };
            ViewBag.ddlEstadoEgreso = exeBus.RegMostComboIndividual("ESTADO_EGRESO_ESPECIE", "");
            ViewBag.hdfTipo = asTipo;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _EspecieCenso(string asTipo)
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlProcedencia = exeBus.RegMostComboIndividual("PROCEDENCIA_ESPECIE_EXSITU", "");
            ViewBag.ddlEspecieSexo = exeBus.RegMostComboIndividual("ESPECIE_SEXO", "");
            ViewBag.ddlTipoIdentificacion = exeBus.RegMostComboIndividual("INDENTIFICACION_ESPECIE_EXSITU", "");
            ViewBag.hdfTipo = asTipo;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadEducacion()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            ViewBag.ddlActividad = exeBus.RegMostComboIndividual("ACTTIVIDAD_EDUCACION_EXSITU", "");
            ViewBag.ddlPublicoObjetivo = exeBus.RegMostComboIndividual("PUBLICO_OBJETIVO_EXSITU", "");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadInvestigacion()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ActividadCapacitacion()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult ImportarDatosAreaExSitu(string asCodArea)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    result = ImportarDatos.AreaExSitu(Request, asCodArea);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            var jsonResult = Json(new { success = true, msj = "", data = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult ImportarDatosInformeSimpleExSitu(string asTipo)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipo)
                    {
                        case "NACIMIENTO_ESPECIE": result = ImportarDatos.NacimientoEspecie(Request); break;
                        case "EGRESO_ESPECIE": result = ImportarDatos.EgresoEspecie(Request); break;
                        case "ESPECIE_VERTEBRADO": result = ImportarDatos.EspecieVertebrado(Request); break;
                        case "ESPECIE_INVERTEBRADO": result = ImportarDatos.EspecieInvertebrado(Request); break;
                        case "BALANCE_ING_EGR": result = ImportarDatos.BalanceIngEgr(Request); break;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = result });
        }
        #endregion
    }
}