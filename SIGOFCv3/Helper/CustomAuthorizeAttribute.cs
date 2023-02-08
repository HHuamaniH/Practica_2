using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SIGOFCv3.Helper
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly int[] allowedmenus;

        public CustomAuthorizeAttribute(params int[] menus)
        {
            allowedmenus = menus;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
            var userSession = ModelSession.GetSession()[0];

            if (!string.IsNullOrEmpty(userSession.COD_UCUENTA))
            {
                var contenedor = userSession.ListUCDMMENU[0];

                foreach (var grupo in contenedor.ListMENUGRUPO)
                {
                    foreach (var padre in grupo.ListMENUPADRE)
                    {
                        if (allowedmenus.Contains(padre.COD_SECUENCIAL_PADRE))
                        {
                            return true;
                        }
                        else
                        {
                            foreach (var menu in padre.ListMENUMENU)
                            {
                                if (allowedmenus.Contains(menu.COD_SECUENCIAL_HIJO))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Login" },
                    { "action", "Index" },
                    { "area", "" }
               });
        }
    }
}