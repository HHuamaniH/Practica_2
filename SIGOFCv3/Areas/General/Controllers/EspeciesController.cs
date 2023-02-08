using CapaEntidad.GENE;
using CapaEntidad.ViewModel.General;
using CapaLogica.GENE;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class EspeciesController : Controller
    {
        // GET: General/Especies
        //private Log_ESPECIES _log;
        public ActionResult Index()
        {
            Ent_ESPECIES ent_ESPECIES = new Ent_ESPECIES() {
                BusFormulario = "ESPECIES",
                BusCriterio = "NESPECIES"
            };
            Log_ESPECIES log_ESPECIES = new Log_ESPECIES();            

            ViewBag.ListNEspecies = log_ESPECIES.RegMostComboSIGO(ent_ESPECIES);
            //ent_ESPECIES.ListNComun = log_ESPECIES.RegMostrarListaEspNComun(ent_ESPECIES);


            
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Gestión de Especies");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View(ent_ESPECIES);
        }
        [HttpPost]
        public JsonResult Operaciones(CapaEntidad.GENE.Ent_ESPECIES especies)
        {
            
            try
            {
                CapaLogica.GENE.Log_ESPECIES log_ESPECIES = new Log_ESPECIES();
                especies.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_ESPECIES.RegGrabarEspecie(especies);
                return Json(new { success = true, msj = "Se actualizó correctamente la especie" });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }
//        [HttpPost]
//        public JsonResult Actualizar(string codCientifico, string codEspecie, string codAgrado, string codImportancia)
//        {
//            try
//            {
//                _log = new Log_ESPECIES();
//                _log.ActualizarEspecie(codCientifico, codEspecie, codAgrado, codImportancia, (ModelSession.GetSession())[0].COD_UCUENTA);
//                return Json(new { success = true, msj = "Se actualizó correctamente la especie" });
//            }
//#pragma warning disable CS0168 // The variable 'ex' is declared but never used
//            catch (Exception ex)
//#pragma warning restore CS0168 // The variable 'ex' is declared but never used
//            {
//                string msj = "Sucedió un error en el servidor";
//                return Json(new { success = false, msj = msj });
//            }

//        }
        // public bool EspecieUpdate(string COD_ENCIENTIFICO, string COD_ESPECIES, string COD_AGRADO_DS, string COD_IMPORTANCIA, string COD_UCUENTA)
    }
}