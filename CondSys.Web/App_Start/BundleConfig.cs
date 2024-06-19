using System.Web;
using System.Web.Optimization;

namespace CondSys.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.mask.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryTable").Include(
                    "~/Scripts/jqueryDataTables/media/js/jquery.dataTables.min.js",
                    "~/Scripts/jqueryDataTables/media/js/jquery.dataTables.js",
                    "~/Scripts/jqueryDataTables/CriarDataTableJquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/MaterializeJs").Include(
                      "~/Scripts/materialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/camjs").Include(
                      "~/Scripts/cam/cam.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/MaterializeCss").Include(
                      "~/Content/materialize.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                     "~/Scripts/jqueryDataTables/media/css/jquery.dataTables.css",
                     "~/Scripts/jqueryDataTables/media/css/jquery.dataTables.min.css"));

        }
    }
}
