using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys.Contexts;
using Fhr.ModernHistory.Services;
using Fhr.ModernHistory.Services.Impl;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      ///  FamousPerson API控制器
      ///  2017/07/02 fhr
      /// </summary>
      public class FamousPersonController : ApiController
      {

            public IFamousPersonService FamousPersonService { get; set; }

            public FamousPersonController(IFamousPersonService famousePersonService)
            {
                  this.FamousPersonService = famousePersonService;
            }

            // GET api/<controller>
            public IEnumerable<FamousPerson> Get()
            {
                  // SampleData.TestSeed();
                  return FamousPersonService.FindAll();
            }

            // GET api/<controller>/5
            public FamousPerson Get(int id)
            {
                  var person= FamousPersonService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "错误消息");
                  }
                  return person;
            }

            // POST api/<controller>
            public void Post([FromBody]string value)
            {

            }

            // PUT api/<controller>/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE api/<controller>/5
            public void Delete(int id)
            {
            }
      }
}