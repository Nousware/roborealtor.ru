using System;
using System.Web;
using System.Web.Optimization;


namespace Nousware.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var siteLess = new LessBundle("~/Content/site").Include("~/Content/Site.less");
            bundles.Add(siteLess);
        }
    }
}