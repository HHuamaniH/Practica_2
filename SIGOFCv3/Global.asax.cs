using SIGOFCv3.Models.DataTables;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SIGOFCv3.App_Start;

namespace SIGOFCv3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(DataTableRequest), new DataTableModelBinder());

            //json max length
            JsonValueProviderFactory jsonValueProviderFactory = null;

            foreach (var factory in ValueProviderFactories.Factories)
            {
                if (factory is JsonValueProviderFactory)
                {
                    jsonValueProviderFactory = factory as JsonValueProviderFactory;
                }
            }

            //remove the default JsonVAlueProviderFactory
            if (jsonValueProviderFactory != null) ValueProviderFactories.Factories.Remove(jsonValueProviderFactory);

            //add the custom one
            ValueProviderFactories.Factories.Add(new CustomJsonValueProviderFactory());
        }
        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();

        }
    }
}
