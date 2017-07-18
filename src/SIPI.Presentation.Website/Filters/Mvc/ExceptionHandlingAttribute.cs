using System;
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
                throw new HttpException((int)System.Net.HttpStatusCode.NotImplemented, "Not Implemented", ex);

            throw new HttpException((int)System.Net.HttpStatusCode.InternalServerError, "InternalServerError", ex);
        }
    }
}