using System.Web.Http;
using WebActivatorEx;
using ModernHistoryWebApi;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

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
                                c.SingleApiVersion("v1", "swagger");
                                c.IncludeXmlComments(GetXmlCommentsPath());
                          })
                      .EnableSwaggerUi(c =>
                          {
                          });
            }
            /// <summary>
            /// ��Ŀ���xml�ļ�·��
            /// </summary>
            /// <returns></returns>
            private static string GetXmlCommentsPath()
            {
                  return System.String.Format(@"{0}\bin\swagger.xml", System.AppDomain.CurrentDomain.BaseDirectory);
            }
      }
}
