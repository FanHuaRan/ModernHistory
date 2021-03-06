﻿using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Fhr.ModernHistory.Services;
using Fhr.ModernHistory.Repositorys.Impl;
using Fhr.ModernHistory.Services.Impl;

namespace ModernHistoryWebApi.OAuth
{
      /// <summary>
      /// 基于密码和客户端授权的OAuth授权服务器
      /// 这里模仿Spring-Security-OAuth2,同时使用客户端和密码授权
      /// 实际运行时：先运行ValidateClientAuthentication 后运行GrantResourceOwnerCredentials
      /// 2017/07/03 fhr
      /// </summary>
      public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
      {
            //用户服务组件 自定义
            private IMhUserService userService;

            public OpenAuthorizationServerProvider()
            {
                  //无法不知道如何使用依赖注入 暂时手动了
                  userService = new MhUserServiceClass(new MhUserRepositoryClass());
            }

            /// <summary>
            /// 验证 client 信息
            /// 如果此方法不进行客户端校验，只依靠下面的校验，则为单纯的密码授权
            /// </summary>
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                  //从用户的请求参数中获取clientId与clientsecret
                  string clientId;
                  string clientSecret;
                  if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
                  {
                        context.TryGetFormCredentials(out clientId, out clientSecret);
                  }
                  context.Validated();
            }

            /// <summary>
            /// 授予资源所有者证书
            /// 此方法主要作用：验证用户，生成初始的access_token
            /// 如果此方法不进行用户校验，只依靠上面方法的校验，即只是单纯的客户端授权
            /// </summary>
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                  //令牌中间件提供者允许CORS
                  context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                  //验证用户名和密码
                  if (string.IsNullOrEmpty(context.UserName))
                  {
                        context.SetError("invalid_username", "username is not valid");
                        return;
                  }
                  if (string.IsNullOrEmpty(context.Password))
                  {
                        context.SetError("invalid_password", "password is not valid");
                        return;
                  }
                  if (context.Password != await userService.FindPasswordAsync(context.UserName))
                  {
                        context.SetError("invalid_identity", "username or password is not valid");
                        return;
                  }
                  var OAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                  OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                  //通过校验
                  context.Validated(OAuthIdentity);
            }
      }
}