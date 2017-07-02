﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ModernHistoryWebApi.Models
{
      /// <summary>
      /// API错误数据描述
      /// 2017/07/02 fhr
      /// </summary>
      public class ApiErrorModel
      {
            /// <summary>
            ///http错误标识，枚举类型，且int值与其相应代号相同 所以就直接使用了
            /// </summary>
            public HttpStatusCode StatusCode { get; set; }
            /// <summary>
            /// 错误业务标识
            /// </summary>
            public int Code { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>
            public string Message { get; set; }
      }
}