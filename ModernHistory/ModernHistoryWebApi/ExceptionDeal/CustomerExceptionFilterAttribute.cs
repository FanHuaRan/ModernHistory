﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Filters;
using ModernHistoryWebApi.Models;

namespace ModernHistoryWebApi.ExceptionDeal
{
      /// <summary>
      /// 错误处理过滤器
      /// 2017/07/02 fhr
      /// </summary>
      public class CustomerExceptionFilterAttribute : ExceptionFilterAttribute
      {
            /// <summary>
            /// 错误抛出后的拦截方法
            /// </summary>
            /// <param name="actionExecutedContext"></param>
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                  var exception = actionExecutedContext.Exception;
                  //Http相应标识缺省为500
                  var statusCode = HttpStatusCode.InternalServerError;
                  //错误标识缺省为1
                  var code = 1;
                  //错误消息缺省直接就是异常的消息
                  var message = actionExecutedContext.Exception.Message;
                  //检查是否为CustomerApiException自定义API异常，如果是则会进行进一步的处理
                  if (exception is CustomerApiException)
                  {
                        var apiException = exception as CustomerApiException;
                        statusCode = apiException.StatusCode;
                        code = apiException.Code;
                  }
                  //返回自定义的错误httpresponse
                  actionExecutedContext.Response = GetResponseMessage(statusCode, -1, actionExecutedContext.Exception.Message);
            }
            /// <summary>
            /// 自定义
            /// </summary>
            /// <param name="statusCode"></param>
            /// <param name="code"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            private HttpResponseMessage GetResponseMessage(HttpStatusCode statusCode, int code, string message)
            {
                  //实例化错误消息
                  var resultModel = new ApiErrorModel()
                  {
                        StatusCode = statusCode,
                        Code = code,
                        Message = message
                  };
                  //创建有关错误消息的httpresponse
                  return new HttpResponseMessage()
                  {
                        StatusCode = statusCode,
                        Content = new ObjectContent<ApiErrorModel>(resultModel, new JsonMediaTypeFormatter(), "application/json")
                  };
            }
      }
}