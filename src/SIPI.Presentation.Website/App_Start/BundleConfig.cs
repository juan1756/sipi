using System.Web.Optimization;

namespace SIPI.Presentation.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/vendor.css",
                "~/Content/app.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/thirdparty").Include(
                "~/Scripts/thirdparty/jquery-{version}.js",
                "~/Scripts/thirdparty/jquery.validate*",
                "~/Scripts/thirdparty/modernizr-*",
                "~/Scripts/thirdparty/bootstrap.js",
                "~/Scripts/thirdparty/respond.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts/plugins").Include(
                "~/Scripts/plugins/jquery.validate.bootstrap.js"
            ));
        }
    }
}