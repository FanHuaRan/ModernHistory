using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Gloabl
{
    /// <summary>
    /// Web api配置类
    /// 2017/07/10 fhr
    /// </summary>
     public class WebApiConfig
     {
         public static readonly string WEBAPI_BASE_Url = "http://localhost:57759/api";

         public static readonly Uri WEBAPI_BASE_Uri = new Uri("http://localhost:57759/api");
     }
}
