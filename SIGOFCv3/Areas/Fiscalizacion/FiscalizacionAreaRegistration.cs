using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion
{
    public class FiscalizacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Fiscalizacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Fiscalizacion_default",
                "Fiscalizacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}