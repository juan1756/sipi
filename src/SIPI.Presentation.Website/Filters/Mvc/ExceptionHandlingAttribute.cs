using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Filters.Mvc
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            var ex = filterContext.Exception;

            if (ex is NotImplementedException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.ServiceUnavailable;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "503",
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData,
                    MasterName = "_Layout"
                };
            }
        }
    }
}