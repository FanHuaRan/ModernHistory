﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys;
using Fhr.ModernHistory.Repositorys.Impl;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// FamousPerson服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class FamousPersonServiceClass : IFamousPersonService
      {
            private IFamousPersonRepository famousPersonRepository = new FamousPersonRepositoryClass();

            public IEnumerable<FamousPerson> FindAll()
            {
                  return famousPersonRepository.FindAll();
            }

            public FamousPerson FindById(object id)
            {
                  return famousPersonRepository.FindById(id);
            }
      }
}