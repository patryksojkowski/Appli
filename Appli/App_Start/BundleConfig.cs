using System.Web.Optimization;

namespace Appli
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.lib).Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/datatables/jquery.dataTables.js",
                      "~/Scripts/datatables/dataTables.bootstrap.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/scripts/toastr.js"
                      ));

            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.jqueryval).Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.modernizr).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle(Links.Bundles.Styles.contentCss).Include(
                      "~/Content/bootstrap-darkly.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/content/toastr.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
