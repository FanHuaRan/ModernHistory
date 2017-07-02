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
      /// HistoryEventType服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class HistoryEventTypeServiceClass : IHistoryEventTypeService
      {
            private IHistoryEventTypeRepository historyEventTypeRepository = new HistoryEventTypeRepositoryClass();

            public IEnumerable<HistoryEventType> FindAll()
            {
                  return historyEventTypeRepository.FindAll();
            }

            public HistoryEventType FindById(object id)
            {
                  return historyEventTypeRepository.FindById(id);
            }
      }
}
