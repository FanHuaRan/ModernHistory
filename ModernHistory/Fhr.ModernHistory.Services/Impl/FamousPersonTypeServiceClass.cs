using System;
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
      /// FamousPersonType服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class FamousPersonTypeServiceClass : IFamousPersonTypeService
      {
            private IFamousPersonTypeRepository famousPersonRepository = new FamousPersonTypeRepositoryClass();

            public IEnumerable<FamousPersonType> FindAll()
            {
                  return famousPersonRepository.FindAll();
            }

            public FamousPersonType FindById(object id)
            {
                  return famousPersonRepository.FindById(id);
            }
      }
}
