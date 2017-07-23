using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class UrlHelperTableExtensions
    {
        /// <summary>
        /// Returns Table URL with QueryString attached
        /// </summary>
        /// <param name="url"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="routeData"></param>
        /// <returns></returns>
        public static string Table(this UrlHelper url, string action, string controller, object routeData = null)
        {
            var request = url.RequestContext.HttpContext.Request;
            return url.Action($"{action}table", controller, routeData)
                + (request.QueryString.HasKeys()
                    ? "?" + request.QueryString.ToString()
                    : string.Empty);
        }

        public static string PostTable(this UrlHelper url, string action, string controller, object routeData = null)
        {
            var request = url.RequestContext.HttpContext.Request;
            return url.Action(action, controller, routeData)
                + (request.QueryString.HasKeys()
                    ? "?" + request.QueryString.ToString()
                    : string.Empty);
        }

        public static string PreviousLocal(this UrlHelper url, string action, string controller, object routeData = null)
        {
            if (url.RequestContext.HttpContext.Request.UrlReferrer != null 
                && url.IsLocalUrl(url.RequestContext.HttpContext.Request.UrlReferrer.AbsolutePath))
            {
                return url.RequestContext.HttpContext.Request.UrlReferrer.ToString();
            }

            return url.Action(action, controller, routeData);
        }

        public static string PreviousLocalOrHome(this UrlHelper url)
        {
            return url.PreviousLocal("index", "home", new { area = "" });
        }
    }
}