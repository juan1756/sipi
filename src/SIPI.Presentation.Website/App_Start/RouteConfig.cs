using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SIPI.Presentation.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            // More to less specific

            routes.MapRoute(
                name: "pedidos/crear/confirmar",
                url: "pedidos/crear",
                defaults: new { controller = "pedidos", action = "confirmar" },
                constraints: new { Confirmar = new ParameterValueConstraint(true) },
                namespaces: new[] { "SIPI.Presentation.Website.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "SIPI.Presentation.Website.Controllers" }
            );
        }
    }

    public class ParameterValueConstraint : IRouteConstraint
    {
        private object _parameterValue;

        public ParameterValueConstraint(object parameterValue)
        {
            if (parameterValue == null)
                throw new ArgumentNullException("parameterValue");

            _parameterValue = parameterValue;
        }
        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                return IsOnRequestParams(httpContext.Request, parameterName)
                    || IsOnRouteValueDictionary(values, parameterName);
            }
            else
            {
                return IsOnRouteValueDictionary(values, parameterName);
            }
        }

        private bool IsOnRequestParams(HttpRequestBase request, string parameterName)
        {
            return request.Params[parameterName] != null 
                && request.Params[parameterName].Equals(_parameterValue.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsOnRouteValueDictionary(RouteValueDictionary values, string parameterName)
        {
            return values.ContainsKey(parameterName)
                && values[parameterName] == _parameterValue;
        }
    }
}