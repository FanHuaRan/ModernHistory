using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ModernHistoryWebApi
{
      public class WebApiApplication : System.Web.HttpApplication
      {
            protected void Application_Start()
            {
                  //Code First 数据库初始化
                  System.Data.Entity.Database.SetInitializer(new Fhr.ModernHistory.Repositorys.Contexts.SampleData());
                  AreaRegistration.RegisterAllAreas();
                  GlobalConfiguration.Configure(WebApiConfig.Register);
                  FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                  RouteConfig.RegisterRoutes(RouteTable.Routes);
                  BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
      }
}
