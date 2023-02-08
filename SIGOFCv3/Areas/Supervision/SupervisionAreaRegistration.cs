using System.Web.Mvc;

namespace SIGOFCv3.Areas.Supervision
{
    public class SupervisionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Supervision";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Supervision_default",
                "Supervision/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}