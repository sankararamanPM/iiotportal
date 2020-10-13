using System.Web;
using System.Web.Optimization;

namespace PlanDigitization_web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                    "~/assets/vendor/bootstrap/css/bootstrap.css",
                    "~/assets/vendor/font-awesome/css/font-awesome.css",
                    "~/assets/vendor/magnific-popup/magnific-popup.css",
                    "~/assets/vendor/bootstrap-datepicker/css/datepicker3.css",
                    "~/assets/vendor/jquery-ui/css/ui-lightness/jquery-ui-1.10.4.custom.css",
                    "~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.css",
                    "~/assets/vendor/morris/morris.css",
                    "~/assets/stylesheets/theme.css",
                    "~/assets/stylesheets/skins/default.css",
                    "~/assets/stylesheets/theme-custom.css",
                    "~/assets/vendor/select2/select2.css",
                    "~/assets/vendor/jquery-datatables-bs3/assets/css/datatables.css"
                ));

            bundles.Add(new ScriptBundle("~/assets/firstscript").Include(
                    "~/assets/vendor/modernizr/modernizr.js"
                ));

            bundles.Add(new ScriptBundle("~/assets/secondscript").Include(
                   "~/assets/vendor/jquery/jquery.js",
                    "~/assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js",
                    "~/assets/vendor/bootstrap/js/bootstrap.js",
                    "~/assets/vendor/nanoscroller/nanoscroller.js",
                    "~/assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js",
                    "~/assets/vendor/magnific-popup/magnific-popup.js",
                    "~/assets/vendor/jquery-placeholder/jquery.placeholder.js",
                    "~/assets/vendor/jquery-ui/js/jquery-ui-1.10.4.custom.js",
                    "~/assets/vendor/jquery-ui-touch-punch/jquery.ui.touch-punch.js",
                    "~/assets/vendor/jquery-appear/jquery.appear.js",
                    "~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.js",
                    "~/assets/vendor/jquery-easypiechart/jquery.easypiechart.js",
                    "~/assets/vendor/flot/jquery.flot.js",
                    "~/assets/vendor/flot-tooltip/jquery.flot.tooltip.js",
                    "~/assets/vendor/flot/jquery.flot.pie.js",
                    "~/assets/vendor/flot/jquery.flot.categories.js",
                    "~/assets/vendor/flot/jquery.flot.resize.js",
                    "~/assets/vendor/jquery-sparkline/jquery.sparkline.js",
                    "~/assets/vendor/raphael/raphael.js",
                    "~/assets/vendor/morris/morris.js",
                    "~/assets/vendor/gauge/gauge.js",
                    "~/assets/vendor/snap-svg/snap.svg.js",
                    "~/assets/vendor/liquid-meter/liquid.meter.js",
                    "~/assets/vendor/jqvmap/jquery.vmap.js",
                    "~/assets/vendor/jqvmap/data/jquery.vmap.sampledata.js",
                    "~/assets/vendor/jqvmap/maps/jquery.vmap.world.js",
                    "~/assets/vendor/jqvmap/maps/continents/jquery.vmap.africa.js",
                    "~/assets/vendor/jqvmap/maps/continents/jquery.vmap.asia.js",
                    "~/assets/vendor/jqvmap/maps/continents/jquery.vmap.australia.js",
                    "~/assets/vendor/jqvmap/maps/continents/jquery.vmap.europe.js",
                    "~/assets/vendor/jqvmap/maps/continents/jquery.vmap.north-america.js",
                    "~/assets/vendor/jqvmap/maps/continents/jquery.vmap.south-america.js",
                    "~/assets/javascripts/theme.js",
                    "~/assets/vendor/select2/select2.js",
                    "~/assets/javascripts/theme.custom.js",
                    "~/assets/javascripts/theme.init.js",
                    "~/assets/javascripts/dashboard/examples.dashboard.js",
                    "~/assets/vendor/jquery-validation/jquery.validate.js",
                    "~/assets/javascripts/forms/examples.validation.js",
                    "~/assets/vendor/jquery-datatables/media/js/jquery.dataTables.js",
                    "~/assets/vendor/jquery-datatables/extras/TableTools/js/dataTables.tableTools.min.js",
                    "~/assets/vendor/jquery-datatables-bs3/assets/js/datatables.js",
                    "~/assets/javascripts/tables/examples.datatables.default.js",
                    "~/assets/javascripts/tables/examples.datatables.row.with.details.js",
                    "~/assets/javascripts/tables/examples.datatables.tabletools.js"
                ));
        }
    }
}
