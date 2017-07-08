﻿using System;
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
    }
}