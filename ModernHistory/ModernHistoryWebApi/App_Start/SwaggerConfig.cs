using System.Web.Http;
using WebActivatorEx;
using ModernHistoryWebApi;
using Swashbuckle.Application;
using System;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ModernHistoryWebApi
{
      public class SwaggerConfig
      {
            public static void Register()
            {
                  var thisAssembly = typeof(SwaggerConfig).Assembly;

                  GlobalConfiguration.Configuration
                      .EnableSwagger(c =>
                          {
                                c.SingleApiVersion("v1", "ModernHistoryApi");
                                c.IncludeXmlComments(GetXmlCommentsPath());
                          })
                      .EnableSwaggerUi(c =>
                          {
                          });
            }
            /// <summary>
            /// 项目输出xml文件路径
            /// </summary>
            /// <returns></returns>
            private static string GetXmlCommentsPath()
            {
                  return System.String.Format(@"{0}\bin\ModernHistoryApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
            }
      }
}
