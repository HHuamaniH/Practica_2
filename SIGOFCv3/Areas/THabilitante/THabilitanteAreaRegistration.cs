using System.Web.Mvc;

namespace SIGOFCv3.Areas.THabilitante
{
    public class THabilitanteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "THabilitante";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "THabilitante_default",
                "THabilitante/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}