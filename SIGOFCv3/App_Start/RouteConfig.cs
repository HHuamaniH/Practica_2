using System.Web.Mvc;
using System.Web.Routing;

namespace SIGOFCv3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            //registramos el router para el login
            routes.MapRoute(
                name: "Login",
                url: "login/index/{id}",
                defaults: new { Controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            //registramos el router para el login
            routes.MapRoute(
                name: "LoginEstudio",
                url: "login/index/{id}",
                defaults: new { Controller = "Login", action = "LoginEstudio", id = UrlParameter.Optional }
            );
        }
    }
}
