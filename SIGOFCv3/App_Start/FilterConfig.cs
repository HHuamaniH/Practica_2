using SIGOFCv3.Helper;
using System.Web.Mvc;

namespace SIGOFCv3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //aplicamos el filtro para verificar la autenticacion personalizada
            filters.Add(new RequiredAuthenticationFilter());
        }
    }
}
