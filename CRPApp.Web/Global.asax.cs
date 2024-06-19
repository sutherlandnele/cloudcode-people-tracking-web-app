using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CRPApp.Web.App_Start;

namespace CRPApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string onlineStatusConnString = ConfigurationManager.ConnectionStrings["OnlineStatusConn"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Start SqlDependency with application initialization
            SqlDependency.Start(onlineStatusConnString);
        }

        protected void Application_End()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Stop SQL dependency
            SqlDependency.Stop(onlineStatusConnString);
        }
    }
}
