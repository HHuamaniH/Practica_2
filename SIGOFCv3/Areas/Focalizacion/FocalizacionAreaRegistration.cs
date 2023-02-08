using System.Web.Mvc;

namespace SIGOFCv3.Areas.Focalizacion
{
    public class FocalizacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Focalizacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Focalizacion_default",
                "Focalizacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}