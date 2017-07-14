using System.Web.Optimization;

namespace SIPI.Presentation.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Main 

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/css/vendor.css",
                "~/Content/css/app.css",
                "~/Content/css/bootstrap-table-1.11.1.css",
                "~/Content/css/bootstrap-datepicker.css",
                "~/Content/css/site.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts/thirdparty").Include(
                "~/Scripts/thirdparty/jquery-3.2.1.js",
                "~/Scripts/thirdparty/jquery.validate*",
                "~/Scripts/thirdparty/modernizr-*",
                "~/Scripts/thirdparty/bootstrap.js",
                "~/Scripts/thirdparty/respond.js",
                "~/Scripts/thirdparty/animations.js",
                "~/Scripts/thirdparty/bootstrap-table-1.11.1.js",
                "~/Scripts/thirdparty/bootstrap-table-es-AR.js",
                "~/Scripts/thirdparty/bootstrap-datepicker.js",
                "~/Scripts/thirdparty/bootstrap-datepicker.es.min.js",
                "~/Scripts/thirdparty/moment-2.18.1.js",
                "~/Scripts/thirdparty/jquery.waypoints.js",
                "~/Scripts/thirdparty/jquery.waypoints.infinite.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts/plugins").Include(
                "~/Scripts/plugins/jquery.validate.bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts/app").Include(
                "~/Scripts/app.js"
            ));

            // Landing

            bundles.Add(new StyleBundle("~/Content/landing/styles").Include(
                "~/Content/landing/css/bootstrap.css",
                "~/Content/landing/css/font-awesome.css",
                "~/Content/landing/css/magnific-popup.css",
                "~/Content/landing/css/creative.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/landing/scripts/thirdparty").Include(
                "~/Scripts/landing/thirdparty/jquery.js",
                "~/Scripts/landing/thirdparty/bootstrap.js",
                "~/Scripts/landing/thirdparty/jquery.easing.js",
                "~/Scripts/landing/thirdparty/scrollreveal.js",
                "~/Scripts/landing/thirdparty/jquery.magnific-popup.js",
                "~/Scripts/landing/thirdparty/creative.js"
            ));
        }
    }
}