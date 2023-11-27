using CapaEntidad.GENE;
using Herramienta;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;
using CLogica = CapaLogica.GENE.Log_USUARIO_CUENTA;

namespace SIGOFCv3.Controllers
{
    public class LoginController : Controller
    {
        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult LoginEstudio()
        {
            return View(new Ent_USUARIO_CUENTA());
        }
            // GET: Login

            CLogica oCLogica = new CLogica();
        List<CEntidad> ListLogin = new List<CEntidad>();
        Utilitarios HerUtil = new Utilitarios();


        [HttpPost]
        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult LogeoEstudio(CEntidad user, string returnUrl)
        {
            String tipoAutenticacion = "";

            string statusError = "";
            try
            {
                tipoAutenticacion = oCLogica.devuelvetipoAutenticacion();
                if (tipoAutenticacion == "1")//si es autenticación local
                {
                    //oCampos.USUARIO_CONTRASENA = txtiscontra.Text.Trim();
                }
                else if (tipoAutenticacion == "2")//si es autenticación integrada
                {
                    user.USUARIO_CONTRASENA = HerUtil.md5(user.USUARIO_CONTRASENA.Trim().ToUpper() + user.USUARIO_CONTRASENA.Trim());
                }
                user.OUTPUTPARAM01 = "";
                user.OUTPUTPARAM02 = "";
                // ListLogin = oCLogica.RegLoginValidando(user,"v3");
                ListLogin = oCLogica.RegLoginValidandoV3(user, "v3");
                if (ListLogin[0].ListUCDMMENU == null)
                    throw new Exception("|No tiene perfil o menus asignados");
                //Session["LoginUsuario"] = ListLogin ;
                FormsAuthentication.SetAuthCookie(ListLogin[0].COD_UCUENTA, true);
                ModelSession.Initialize(ListLogin);

                if (ListLogin[0].COD_UCUENTA != null)
                {
                    //Grabar auditoría usuario
                    CLogica exeAudit = new CLogica();
                    CapaEntidad.GENE.Ent_AUDITORIA entAudit = new CapaEntidad.GENE.Ent_AUDITORIA();
                    entAudit.codCuentaUsuario = ListLogin[0].COD_UCUENTA;
                    entAudit.app = "SIGOsfc v3";
                    entAudit.ipCliente = Request.ServerVariables["REMOTE_ADDR"];
                    exeAudit.RegAuditoriaUsuario(entAudit);
                }

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("AccesoEstudio", "Principal", new { Area = "Main" });
                    //return RedirectToAction("AccesoUsuario", "Principal", new { Area = "Main" });
                }
                else
                {
                    return Redirect(returnUrl);
                }

                //return RedirectToAction("_terminosUso", "Principal", new { Area = "Main" });
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("SQL Server") > 0 || ex.Message.Split('|').Length <= 1)
                {
                    statusError = "Error al conectarse a la base de datos";
                }
                else
                {
                    String[] MessageError = ex.Message.Split('|');
                    statusError = MessageError[1];
                }
                TempData["errorLogin"] = statusError;
                return RedirectToAction("LoginEstudio");
            }

        }



        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult Index()
        {
            string usuer = Request.Form["usuario"];
            //string cod_ucuent
            if (!string.IsNullOrEmpty(usuer))
            {
                CEntidad user = new CEntidad();
                user.USUARIO_LOGIN = usuer;

                user.OUTPUTPARAM01 = "";
                user.OUTPUTPARAM02 = "";
                //ListLogin = oCLogica.RegLoginValidandoIntegrado(user,"v3");
                ListLogin = oCLogica.RegLoginValidandoIntegradoV3(user, "v3");
                FormsAuthentication.SetAuthCookie(ListLogin[0].COD_UCUENTA, true);
                ModelSession.Initialize(ListLogin);

                if (ListLogin[0].COD_UCUENTA != null)
                {
                    //Grabar auditoría usuario
                    CLogica exeAudit = new CLogica();
                    CapaEntidad.GENE.Ent_AUDITORIA entAudit = new CapaEntidad.GENE.Ent_AUDITORIA();
                    entAudit.codCuentaUsuario = ListLogin[0].COD_UCUENTA;
                    entAudit.app = "SIGOsfc v3";
                    entAudit.ipCliente = Request.ServerVariables["REMOTE_ADDR"];
                    exeAudit.RegAuditoriaUsuario(entAudit);
                }

                //return RedirectToAction("AccesoUsuario", "Principal", new { Area = "Main" });
                ////return RedirectToAction("_terminosUso", "Principal", new { Area = "Main" });

                CEntidad result = new CEntidad();
                string[] perfiles = ListLogin[0].COD_SPERFILS.Split(',');
                if (perfiles.Length == 2)
                {
                    return RedirectToAction("AccesoUsuario", "Principal", new { Area = "Main" });
                } else if (perfiles.Length > 2) {
                    return RedirectToAction("Acceso", "Login");
                }
                else
                {
                    TempData["errorLogin"] = "El usuario no tiene ningún perfil asignado";
                }
            }

            if (TempData["errorLogin"] != null)
            {
                ViewBag.errorLogin = TempData["errorLogin"];
            }            
            return View(new Ent_USUARIO_CUENTA());
        }

        [HttpPost]
        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult Login(CEntidad user, string returnUrl)
        {
            String tipoAutenticacion = "";

            string statusError = "";
            try
            {
                tipoAutenticacion = oCLogica.devuelvetipoAutenticacion();
                if (tipoAutenticacion == "1")//si es autenticación local
                {
                    //oCampos.USUARIO_CONTRASENA = txtiscontra.Text.Trim();
                }
                else if (tipoAutenticacion == "2")//si es autenticación integrada
                {
                    user.USUARIO_CONTRASENA = HerUtil.md5(user.USUARIO_CONTRASENA.Trim().ToUpper() + user.USUARIO_CONTRASENA.Trim());
                }
                user.OUTPUTPARAM01 = "";
                user.OUTPUTPARAM02 = "";
                // ListLogin = oCLogica.RegLoginValidando(user,"v3");
                ListLogin = oCLogica.RegLoginValidandoV3(user, "v3");

                if (ListLogin[0].ListUCDMMENU == null)
                    throw new Exception("|No tiene perfil o menus asignados");
                //Session["LoginUsuario"] = ListLogin ;
                FormsAuthentication.SetAuthCookie(ListLogin[0].COD_UCUENTA, true);
                ModelSession.Initialize(ListLogin);

                if (ListLogin[0].COD_UCUENTA != null)
                {
                    //Grabar auditoría usuario
                    CLogica exeAudit = new CLogica();
                    CapaEntidad.GENE.Ent_AUDITORIA entAudit = new CapaEntidad.GENE.Ent_AUDITORIA();
                    entAudit.codCuentaUsuario = ListLogin[0].COD_UCUENTA;
                    entAudit.app = "SIGOsfc v3";
                    entAudit.ipCliente = Request.ServerVariables["REMOTE_ADDR"];
                    exeAudit.RegAuditoriaUsuario(entAudit);
                }

                
                CEntidad result = new CEntidad();
                string[] perfiles = ListLogin[0].COD_SPERFILS.Split(',');
                if (perfiles.Length == 2)
                {
                    return RedirectToAction("AccesoUsuario", "Principal", new { Area = "Main" });
                }
                else if (perfiles.Length > 2)
                {
                    return RedirectToAction("Acceso", "Login");
                }
                else
                {
                    throw new Exception("|El usuario no tiene ningún perfil asignado");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("SQL Server") > 0 || ex.Message.Split('|').Length <= 1)
                {
                    statusError = "Error al conectarse a la base de datos";
                }
                else
                {
                    String[] MessageError = ex.Message.Split('|');
                    statusError = MessageError[1];
                }
                TempData["errorLogin"] = statusError;
                return RedirectToAction("index");
            }

        }


       


        public ActionResult ErrorC(string msjError = "")
        {
            ViewBag.mensajeError = msjError;
            return View();
        }

        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult Acceso()
        {
            
            CEntidad result=new CEntidad();
            try
            {
                 var data = ModelSession.GetSession();

                if (data != null)
                   result = (CEntidad)data[0];
                

                if (TempData["errorLogin"] != null)
                {
                    ViewBag.errorLogin = TempData["errorLogin"];
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }
            
            return View(result);
        }
        [RequiredAuthenticationFilter(Check = false)]
        public ActionResult Perfil(CEntidad user, string returnUrl)
        {

            CEntidad result = new CEntidad();
            try
            {
                var data = ModelSession.GetSession();

                if (data != null)
                {

                    result = oCLogica.RegLoginValidandoIntegradoV3(user, "v3")[0];
                    ListLogin =data;
                    result.COD_SPERFILS = user.COD_SPERFIL;
                    result.COD_SPERFIL = user.COD_SPERFIL;
                    ListLogin[0] = result;
                    ModelSession.Initialize(ListLogin);
                    
                }

                if (TempData["errorLogin"] != null)
                {
                    ViewBag.errorLogin = TempData["errorLogin"];
                    return RedirectToAction("index");
                }
                if (string.IsNullOrEmpty(returnUrl))
                {
                     return RedirectToAction("AccesoUsuario", "Principal", new { Area = "Main" });
                   // return RedirectToAction("Acceso", "Login");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }

            //return RedirectToAction("AccesoUsuario", "Principal", new { Area = "Main" });
        }

    }
}