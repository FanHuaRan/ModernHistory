﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ModernHistoryWebApi
{
      public static class WebApiConfig
      {
            public static void Register(HttpConfiguration config)
            {
                  // Web API 配置和服务

                  // Web API 路由
                  config.MapHttpAttributeRoutes();

                  config.Routes.MapHttpRoute(
                      name: "DefaultApi",
                      routeTemplate: "api/{controller}/{action}/{id}",
                      defaults: new { id = RouteParameter.Optional }
                  );
                  //清除xml序列化，因为我们的实体类没有加上序列化特性，但是Google浏览器默认是xml，
                  GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            }
      }
}
