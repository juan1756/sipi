using System;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace SIPI.Presentation.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly string Culture = "es-ar";

        protected void Application_Start()
        {
            DependenciesConfig.RegisterDependencies();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var culture = System.Globalization.CultureInfo.CreateSpecificCulture(Culture);

            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected virtual void Application_EndRequest()
        {
            if (FormsAuthentication.IsEnabled
                && HttpContext.Current.Response.StatusCode == (int)HttpStatusCode.Found
                && HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}