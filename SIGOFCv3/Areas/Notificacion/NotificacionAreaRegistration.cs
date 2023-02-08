using System.Web.Mvc;

namespace SIGOFCv3.Areas.Notificacion
{
    public class NotificacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Notificacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Notificacion_default",
                "Notificacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}