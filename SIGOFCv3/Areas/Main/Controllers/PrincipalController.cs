using SIGOFCv3.Models;
using System.Collections.Generic;
using CapaLogica.DOC;
using System.Web.Mvc;
using System.Web.Security;
using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;

namespace SIGOFCv3.Areas.Main.Controllers
{
    public class PrincipalController : Controller
    {
        private Log_Usuario logUser;
        // GET: Main/Principal
        List<CEntidad> ListLogin = new List<CEntidad>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccesoUsuario(CEntidad usr)
        {
            string result;
            logUser = new Log_Usuario();
            result = logUser.veriflecturaterminosUso((ModelSession.GetSession())[0].COD_UCUENTA);
            ViewBag.lanzarterminosUso = result;
            return View();
        }

        public ActionResult AccesoEstudio(CEntidad usr)
        {
            string result;
            logUser = new Log_Usuario();
            result = logUser.veriflecturaterminosUso((ModelSession.GetSession())[0].COD_UCUENTA);
            ViewBag.lanzarterminosUso = result;
            return View();
        }

        public ActionResult _Menu()
        {
            ListLogin = ModelSession.GetSession();
            return View(ListLogin[0]);
        }
        public ActionResult _Header()
        {
            return PartialView();
        }
        public ActionResult _HeaderEstudio()
        {
            return PartialView();
        }
        public ActionResult _cambiarPass()
        {
            return PartialView();
        }
        public ActionResult _terminosUso()
        {
            return PartialView();
        }
        public ActionResult _terminosUsoEstudio()
        {
            return PartialView();
        }
        public ActionResult _Footer()
        {
            return PartialView();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies.Clear();
            ModelSession.Logout();
            return RedirectToAction("Index", "Login", new { Area = "" });
        }
        public ActionResult LogoutEstudio()
        {
            FormsAuthentication.SignOut();
            Response.Cookies.Clear();
            ModelSession.Logout();
            return RedirectToAction("LoginEstudio", "Login", new { Area = "" });
        }
    }
}