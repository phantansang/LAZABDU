using System.Web;
using System.Web.Optimization;

namespace LAZABDU
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").IncludeDirectory("~/Content/static/js/bootstrap/", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/static/js/bootstrap.min.js",
                        "~/Content/static/js/jquery-2.2.4.min.js",
                        "~/Content/static/js/jquery-3.3.1.min.js",
                        "~/Content/static/js/masonry.pkgd.min.js",
                        "~/Content/static/js/multirange.js",
                        "~/Content/static/js/npm.js",
                        "~/Content/static/js/owl.carousel.min.js",
                        "~/Content/static/js/slick.min.js",
                        "~/Content/static/js/sync_owl_carousel.js"
                        ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/static/css/bootstrap.min.css",
                      "~/Content/static/css/bootstrap-theme.min.css",
                      "~/Content/static/css/font-awesome.min.css",
                      "~/Content/static/css/icon-font-linea.css",
                      "~/Content/static/css/owl.carousel.min.css",
                      "~/Content/static/css/owl.theme.default.css",
                      "~/Content/static/css/slick-theme.css",
                      "~/Content/static/css/themify-icons.css"));
        }
    }
}
