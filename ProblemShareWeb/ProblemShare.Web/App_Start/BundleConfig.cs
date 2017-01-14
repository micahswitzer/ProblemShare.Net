using System.Web;
using System.Web.Optimization;

namespace ProblemShare.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/materialadmin").Include(
                      "~/MaterialAdmin/vendors/bower_components/material-design-iconic-font/dist/css/material-design-iconic-font.min.css",
                      "~/MaterialAdmin/vendors/bower_components/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css",
                      "~/MaterialAdmin/css/app_1.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/MaterialAdmin/vendors/bower_components/jquery/dist/jquery.min.js",
                "~/MaterialAdmin/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/MaterialAdmin/vendors/bower_components/Waves/dist/waves.min.js",
                "~/MaterialAdmin/vendors/bower_components/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js",
                "~/MaterialAdmin/js/app.min.js"
                ));
        }
    }
}
