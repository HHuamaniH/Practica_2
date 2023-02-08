using System.Web.Mvc;

namespace SIGOFCv3.Areas.Tribunal
{
    public class TribunalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Tribunal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Tribunal_default",
                "Tribunal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}