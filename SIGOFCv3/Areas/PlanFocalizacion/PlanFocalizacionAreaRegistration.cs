using System.Web.Mvc;

namespace SIGOFCv3.Areas.PlanFocalizacion
{
    public class PlanFocalizacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PlanFocalizacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PlanFocalizacion_default",
                "PlanFocalizacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}