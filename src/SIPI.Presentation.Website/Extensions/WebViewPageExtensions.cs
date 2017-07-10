using SIPI.Presentation.Website.Authentication;

namespace System.Web.Mvc
{
    public static class WebViewPageExtensions
    {
        public static CustomPrincipal Usuario(this WebViewPage view)
        {
            return view.User as CustomPrincipal;
        }

        public static bool IsController(this WebViewPage view, string controller)
        {
            return string.Equals(
                view.ViewContext.RouteData.Values["controller"].ToString(),
                controller,
                StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsAction(this WebViewPage view, string actionName)
        {
            return string.Equals(
                view.ViewContext.RouteData.Values["action"].ToString(),
                actionName,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}