using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;
using Fhr.ModernHistory.Services;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// HistoryEvent api控制器
      ///  2017/07/02 fhr
      /// </summary>
      [Authorize]
      public class HistoryEventController : ApiController
      {

            public IHistoryEventService HistoryEventService { get; set; }


            public HistoryEventController(IHistoryEventService historyEventService)
            {
                  this.HistoryEventService = historyEventService;
            }

            public IEnumerable<HistoryEvent> Get()
            {
                  return HistoryEventService.FindAll();
            }

            public HistoryEvent Get(int id)
            {
                  var person = HistoryEventService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "该历史事件不存在");
                  }
                  return person;
            }
            [HttpPost]
            public void Save([FromBody]HistoryEvent value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        HistoryEventService.Save(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Update(int id, [FromBody]HistoryEvent value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        value.HistoryEventId = id;
                        HistoryEventService.Update(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Delete(int id)
            {
                  HistoryEventService.Delete(id);
            }
            [HttpGet]
            public IEnumerable<HistoryEvent> Search([FromUri] EventSearchModel searchModel)
            {
                  return HistoryEventService.Search(searchModel);
            }
      }
}