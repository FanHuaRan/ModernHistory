using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// 图片下载控制器
      /// http://www.cnblogs.com/soundcode/p/6217016.html
      /// </summary>
      public class ImageDownLoadController : ApiController
      {
            // GET api/<controller>
            public IEnumerable<string> Get()
            {
                  return new string[] { "value1", "value2" };
            }

            // GET api/<controller>/5
            public string Get(int id)
            {
                  return "value";
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