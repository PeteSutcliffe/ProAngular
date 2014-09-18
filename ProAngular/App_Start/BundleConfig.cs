using System.Web;
using System.Web.Http;
using System.Web.Optimization;

namespace ProAngular
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {            

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap*", "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/js/angular").Include(
                    "~/Scripts/angular*"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
