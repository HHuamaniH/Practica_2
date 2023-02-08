using System.Web.Mvc;
using System.Web.Routing;

namespace SIGOFCv3.Helper
{
    public class RequiredAuthenticationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public RequiredAuthenticationFilter()
        {
            Check = true;
        }

        /// Determina si se va realizar la comprobacion de autenticacion para un metodo de accion 
        /// de cada controlador, por defecto es true      
        public bool Check { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            if (!Check) return;

            //var routeValueDictionary = new RouteValueDictionary(new
            //{
            //    action = Action ?? "Index",
            //    controller = Controller ?? "Login",
            //    Area = ""
            //});

            if (!filterContext.HttpContext.Request.IsAuthenticated || !Models.ModelSession.IsLogin())
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult() { Data = new { success = false, msj = "El usuario perdio la sesión. Vuelva ingresar al sistema", data = "" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    filterContext.HttpContext.Response.StatusCode = 203;
                }
                else
                {
                    var url = filterContext.HttpContext.Request.Url;
                    filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary(new
                         {
                             action = "Index",
                             controller = "Login",
                             Area = "", 
                             returnUrl = url
                         })
                    );
                    //filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
                }
            }
        }
    }
}