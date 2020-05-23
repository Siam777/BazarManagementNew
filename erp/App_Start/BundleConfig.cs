using System.Web;
using System.Web.Optimization;

namespace erp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundle/styles").Include(
                       //"~/css/bootstrap.css",
                       "~/css/animate.css",                                                             
                     "~/css/font-awesome.min.css",
                     "~/css/simple-line-icons.css",
                     "~/css/font.css",
                     "~/css/app1.css",
                     "~/css/angular-tooltips.css",
                     "~/css/autoComplete/angucomplete-alt.css",
                     "~/css/autoComplete/bariol.css"                    
                     //"~/css/datepicker.min.css"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/jsFixed1").Include(
                       /* "~/Scripts/jquery-2.1.3.js",*/
                        "~/Scripts/jquery-confirm.min.js",
                        "~/Scripts/jquery-migrate-1.2.1.js",
                        "~/vendor/jquery/jquery.jqprint.0.3.js",
                        "~/vendor/angular/angular.js",
                        "~/vendor/angular/angular-animate/angular-animate.js",                                                                 
                        "~/vendor/angular/angular-cookies/angular-cookies.js",
                        "~/vendor/angular/angular-resource/angular-resource.js",
                        "~/vendor/angular/angular-sanitize/angular-sanitize.js",
                        "~/vendor/angular/angular-touch/angular-touch.js",

                        "~/vendor/angular/angular-ui-router/angular-ui-router.js",
                        "~/vendor/angular/ngstorage/ngStorage.js",

                        "~/vendor/angular/angular-bootstrap/ui-bootstrap-tpls.js",

                        "~/vendor/angular/oclazyload/ocLazyLoad.js",

                        "~/vendor/angular/angular-translate/angular-translate.js",
                        "~/vendor/angular/angular-translate/loader-static-files.js",
                        "~/vendor/angular/angular-translate/storage-cookie.js",
                        "~/vendor/angular/angular-translate/storage-local.js",

                        "~/vendor/angular/angular-tooltips.js",
                        "~/vendor/angular/angular-touch.min.js",
                        "~/vendor/angular/angucomplete-alt.min.js",
                        "~/vendor/modules/pdf/jspdf.debug.js",
                        "~/vendor/modules/pdf/jspdf.min.js",
                        "~/vendor/modules/pdf/html2canvas.js",
                        "~/vendor/modules/pdf/html2pdf.js"
                        
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jsChangeable").Include(
                        "~/js/App.js",
                         "~/js/config.js",
                        "~/js/config.lazyload.js",
                         "~/js/config.router.js",
                        "~/js/Main.js"                                              
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jsFixed2").Include(
                        "~/js/services/ui-load.js",
                        "~/js/filters/fromNow.js",
                        "~/js/directives/file-Upload.js",
                        "~/js/services/modalService.js",

                        "~/js/directives/setnganimate.js",
                        "~/js/directives/ui-butterbar.js",
                        "~/js/directives/ui-focus.js",
                        "~/js/directives/ui-fullscreen.js",
                        "~/js/directives/ui-jq.js",
                        "~/js/directives/ui-module.js",
                        "~/js/directives/ui-nav.js",
                        "~/js/directives/ui-scroll.js",
                        "~/js/directives/ui-shift.js",
                        "~/js/directives/ui-toggleclass.js",
                        "~/js/directives/ui-validate.js",
                        "~/js/controllers/bootstrap.js",
                         "~/js/controllers/bootstrap.js"
                        ));
        }
    }
}
