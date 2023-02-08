using System.Web.Mvc;

namespace SIGOFCv3.Areas.Capacitacion
{
    public class CapacitacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Capacitacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Capacitacion_default",
                "Capacitacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}