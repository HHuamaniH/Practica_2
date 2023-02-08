using CapaEntidad.ViewModel.General;
using CapaLogica.General;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Seguridad.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Seguridad/Perfil
        // GET: Seguridad/Perfil
        private Log_Perfil logPerfil;
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Mantenimiento Perfiles");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }

        }
        
            [HttpGet]
        public JsonResult GetListClasificacionPerfil(int? id= null)
        {
            try
            {
                var lstPerfil = new Log_Perfil().GetListClasificacionPerfil(id);
                var jsonResult = Json(new { data = lstPerfil, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
            [HttpGet]
        public ActionResult _AddEdit(string cod = "")
        {
            logPerfil = new Log_Perfil();
            var itemEdit = logPerfil.AddEditPerfilInit(cod);
            return PartialView(itemEdit);
        }

        [HttpGet]
        public ActionResult _MenuPerfil(string cod = "")
        {
            logPerfil = new Log_Perfil();
            var itemEdit = logPerfil.PerfilMenuInit(cod);
            return PartialView(itemEdit);
        }
        [HttpPost]
        public ActionResult _MenuRol(VM_Menu_List ob, string cod = "")
        {
            //logPerfil = new Log_Perfil();
            //var itemEdit = logPerfil.AddEditPerfilInit(cod);
            ViewBag.codPerfil = cod;
            
            return PartialView(ob);
        }
        [HttpGet]
        public JsonResult GetListPerfil(string criterio = "", string valor = "",string idclasificacion="")
        {
            try
            {
                logPerfil = new Log_Perfil();
                criterio = criterio.Trim();
                valor = valor.Trim();
                var lstPerfil = logPerfil.GetListPerfil(criterio, valor,idclasificacion);
                var jsonResult = Json(new { data = lstPerfil, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetListMenusAsignados(VM_Perfil_Menu_List perfilMenu)
        {
            try
            {
                logPerfil = new Log_Perfil();
                var lstMenus = logPerfil.GetAlltMenuAsignado(perfilMenu);
                var jsonResult = Json(new { data = lstMenus, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult SavePerfilMenu(VM_Perfil_Menu_List perfilMenu)
        {
            logPerfil = new Log_Perfil();
            return Json(logPerfil.SavePerfilMenu(perfilMenu, (ModelSession.GetSession())[0].COD_UCUENTA));

        }
        [HttpPost]
        public JsonResult SaveMenuRol(VM_Perfil_Menu_List menu)
        {
            logPerfil = new Log_Perfil();
            return Json(logPerfil._saveMenuRol(menu));

        }
        [HttpPost]
        public JsonResult _AddEdit(VM_Perfil vm)
        {
            logPerfil = new Log_Perfil();
            return Json(logPerfil.AddEditPerfil(vm, (ModelSession.GetSession())[0].COD_UCUENTA));
        }

        [HttpPost]
        public JsonResult DeletePerfil(string id)
        {
            logPerfil = new Log_Perfil();
            return Json(logPerfil.DeletePerfil(id, (ModelSession.GetSession())[0].COD_UCUENTA));
        }
    }
}