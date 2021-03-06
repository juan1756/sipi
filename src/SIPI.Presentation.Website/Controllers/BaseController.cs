﻿using SIPI.Presentation.Website.Authentication;
using SIPI.Presentation.Website.Filters.Mvc;
using System.IO;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    [ExceptionHandling]
    [ReplaceJsonToJsonNet]
    public class BaseController : Controller
    {
        protected ActionResult RedirectToHome()
        {
            return RedirectToAction("index", "home", new { area = "" });
        }

        protected string RenderViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        protected CustomPrincipal Usuario
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}