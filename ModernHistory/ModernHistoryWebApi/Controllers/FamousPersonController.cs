using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;
using Fhr.ModernHistory.Repositorys.Contexts;
using Fhr.ModernHistory.Services;
using Fhr.ModernHistory.Services.Impl;
using ModernHistoryWebApi.ExceptionDeal;
using ModernHistoryWebApi.Models;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      ///  FamousPerson API控制器
      ///  2017/07/02 fhr
      /// </summary>
      [Authorize]
      public class FamousPersonController : ApiController
      {

            public IFamousPersonService FamousPersonService { get; set; }

            public FamousPersonController(IFamousPersonService famousePersonService)
            {
                  this.FamousPersonService = famousePersonService;
            }

            public IEnumerable<FamousPerson> Get()
            {
                  return FamousPersonService.FindAll();
            }

            public FamousPerson Get(int id)
            {
                  var person= FamousPersonService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "该名人不存在");
                  }
                  return person;
            }
            [HttpPost]
            public void Save([FromBody]FamousPerson value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        FamousPersonService.Save(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Update(int id, [FromBody]FamousPerson value)
            {
                  if (value!=null&&ModelState.IsValid)
                  {
                        value.FamousPersonId = id;
                        FamousPersonService.Update(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Delete(int id)
            {
                  FamousPersonService.Delete(id);
            }
            [HttpGet]
            public IEnumerable<FamousPerson> Search([FromUri] PersonSearchModel searchModel)
            {
                  return FamousPersonService.Search(searchModel);
            }
      }
}