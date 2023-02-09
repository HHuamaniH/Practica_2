using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Seguridad.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Seguridad/Usuario   
        private Log_Usuario logUser;
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Formulario = "USUARIO";
            ViewBag.TituloFormulario = "Listado de Usuarios";

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Mantenimiento Personas");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }
        [HttpPost]
        public ActionResult _Usuario(string id = "")
        {
            logUser = new Log_Usuario();
            return PartialView(logUser.UsuarioInt(id));
        }
        [HttpGet]
        public ActionResult _UsuarioMenu(string idUser = "")
        {
            logUser = new Log_Usuario();
            return PartialView(logUser.UsuarioMenuInit(idUser));
        }
        [HttpGet]
        public ActionResult _UsuarioPerfil(string idUser = "", string desc = "")
        {
            ViewBag.codUsuario = idUser;
            ViewBag.nUsuario = desc;
            return PartialView();
        }
        [HttpGet]
        public ActionResult _UsuarioAcceso(string idUser = "", string desc = "")
        {
            ViewBag.codUsuario = idUser;
            ViewBag.nUsuario = desc;
            return PartialView();
        }
        public ActionResult _UsuarioAccesoControl(string idUser = "", int id=0)
        {
            ViewBag.codUsuario = idUser;
            logUser = new Log_Usuario();
            return PartialView(logUser.AccesoInt(idUser,id)); 
        }
        [HttpPost]
        public JsonResult SaveUsuario(VM_Usuario vm)
        {
            ListResult result;
            logUser = new Log_Usuario();
            result = logUser.SaveUsuario(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public JsonResult DeleteUsuarioAcceso(VM_Acceso usuarioAcceso)
        {
            logUser = new Log_Usuario();
            return Json(logUser.DeleteUsuarioAcceso(usuarioAcceso, (ModelSession.GetSession())[0].COD_UCUENTA));

        }

        [HttpPost]
        public JsonResult SaveUsuariocambiarPass(VM_Usuario vm)
        {
            ListResult result;
            logUser = new Log_Usuario();
            result = logUser.SaveUsuariocambiarPass(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public JsonResult SaveUsuarioterminosUso(VM_Usuario vm)
        {
            ListResult result;
            logUser = new Log_Usuario();
            result = logUser.SaveUsuarioterminosUso(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public JsonResult SaveUsuarioAccesoControl(VM_Acceso vm)
        {
            ListResult result;
            logUser = new Log_Usuario();
            result = logUser.SaveUsuarioAccesoControl(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }
        [HttpPost]
        public JsonResult SaveUsuarioMenu(VM_Usuario_Menu_List usuarioMenu)
        {
            logUser = new Log_Usuario();
            var ss = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(logUser.SaveUsuarioMenu(usuarioMenu, (ModelSession.GetSession())[0].COD_UCUENTA));

        }

        [HttpPost]
        public ActionResult _MenuRol(VM_Menu_List ob, string cod = "")
        {
            //logPerfil = new Log_Perfil();
            //var itemEdit = logPerfil.AddEditPerfilInit(cod);
            ViewBag.codPerfil = cod;

            return PartialView(ob);
        }

        [HttpPost]
        public JsonResult SaveMenuRol(Ent_Usuario menu)
        {
            logUser = new Log_Usuario();
            menu.COD_UCUENTA_CREACION= (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(logUser._saveMenuRol(menu));

        }

        [HttpPost]
        public JsonResult GetListMenusUsuario(VM_Usuario_Menu_List uMenu)
        {
            try
            {
                logUser = new Log_Usuario();
                var lstMenus = logUser.GetAllUsuarioMenu(uMenu);
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
        public JsonResult GetListUsuarioPerfil(VM_Usuario_Perfil_List uPerfil)
        {
            try
            {
                logUser = new Log_Usuario();
                var lstMenus = logUser.GetAllUsuarioPerfil(uPerfil);
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
        public JsonResult GetUsuarioPerfil(VM_Usuario_Perfil_List uPerfil)
        {
            try
            {
                logUser = new Log_Usuario();
                var lstMenus = logUser.GetUsuarioPerfil(uPerfil);
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
        public JsonResult GetListUsuarioAcceso(VM_Acceso uAcceso)
        {
            try
            {
                logUser = new Log_Usuario();
                var lstAcceso = logUser.GetAllUsuarioAcceso(uAcceso);
                var jsonResult = Json(new { data = lstAcceso, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult SaveUsuarioPerfil(VM_Usuario_Perfil_List usuarioPerfil)
        {
            logUser = new Log_Usuario();
            return Json(logUser.SaveUsuarioPerfil(usuarioPerfil, (ModelSession.GetSession())[0].COD_UCUENTA));

        }
    }
}