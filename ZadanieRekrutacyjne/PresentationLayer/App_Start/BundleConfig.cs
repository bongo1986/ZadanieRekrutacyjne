using System.Web;
using System.Web.Optimization;

namespace PresentationLayer
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
                      "~/Content/angular-busy.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularlibs").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/smart-table.js",
                "~/Scripts/angular-busy.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularApp").Include(
                      "~/Scripts/App/angularapp.module.js",
                      "~/Scripts/App/common/common.module.js",
                      "~/Scripts/App/common/blockingPromises.service.js",
                      "~/Scripts/App/common/clientValidation.directive.js",
                      "~/Scripts/App/common/clientValidation.service.js",
                      "~/Scripts/App/common/modal.service.js",

                      "~/Scripts/App/devcontracts/devContracts.module.js",
                      "~/Scripts/App/devcontracts/devContracts.service.js",
                      "~/Scripts/App/devcontracts/httpDevContracts.service.js",
                      "~/Scripts/App/devcontracts/main.controller.js",
                      "~/Scripts/App/devcontracts/appModel.service.js",
                      "~/Scripts/App/devcontracts/devContractsSalary.directive.js"));
        }
    }
}
