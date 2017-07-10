using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Admin_default",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "SIPI.Presentation.Website.Areas.Admin.Controllers" }
            );
        }
    }
}