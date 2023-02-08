using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
/// Descripción breve de Utilitarios
/// </summary>

namespace HerraAppCode
{
    public class Utilitarios
    {
        Herramienta.Utilitarios HerUtil = new Herramienta.Utilitarios();
        public void SesionLUsuarioActiva(System.Web.UI.Page page)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                //string appPath = page.Request.ApplicationPath;
                //page.Response.Redirect("~/Login.aspx?MensajeLUsuario=Su sesión ha expirado. Por favor ingrese nuevamente a la aplicación");
                HerUtil.ScriptServidor(page, "VentanaOpenSelf('../Login.aspx?MensajeLUsuario=Su sesión ha expirado. Por favor ingrese nuevamente a la aplicación');", true);
                
            }
        }
        public void SesionLUsuarioActivaMaster(System.Web.UI.MasterPage page)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                //string appPath = page.Request.ApplicationPath;
                HerUtil.ScriptServidor(page, "VentanaOpenSelf('../Login.aspx?MensajeLUsuario=Su sesión ha expirado. Por favor ingrese nuevamente a la aplicación');");
            }
        }
        public void SesionLUsuarioCerrar(System.Web.UI.MasterPage page)
        {
            //Mantener el módulo del sistema por el que se accedio (p.e. SIGO, SEGUIMIENTO)
            //string sCodSistemaMod = "";
            //try { sCodSistemaMod = page.Session["SistemaModulo"].ToString(); } catch (Exception) { sCodSistemaMod = "0000001"; }
            HerUtil.SesionLimpiar(page.Session);
            HerUtil.ScriptServidor(page, "VentanaOpenSelf('../Login.aspx');");
            //HerUtil.ScriptServidor(page, "VentanaOpenSelf('../Login.aspx?SistemaModulo="+sCodSistemaMod+"');");
        }
        
    }
}
