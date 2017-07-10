using SIPI.Presentation.Website.Authentication;
using System;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
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
            ModelBindersConfig.RegisterModelBinders();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var culture = System.Globalization.CultureInfo.CreateSpecificCulture(Culture);

            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/1064271/asp-net-mvc-set-custom-iidentity-or-iprincipal
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var customData = new JavaScriptSerializer().Deserialize<CustomPrincipalData>(authTicket.UserData);
                var principal = new CustomPrincipal(authTicket.Name, customData);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
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