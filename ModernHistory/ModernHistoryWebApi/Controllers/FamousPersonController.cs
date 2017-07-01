﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys.Contexts;
using Fhr.ModernHistory.Services;
using Fhr.ModernHistory.Services.Impl;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// http://localhost:57759/api/FamousPerson/get
      /// </summary>
      public class FamousPersonController : ApiController
      {

            public IFamousPersonService famousPersonService = new FamousPersonServiceClass();

            // GET api/<controller>
            public IEnumerable<FamousPerson> Get()
            {
                 // SampleData.TestSeed();
                  return famousPersonService.FindAll();
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