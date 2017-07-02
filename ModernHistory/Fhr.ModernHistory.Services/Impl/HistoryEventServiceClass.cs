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
      /// HistoryEvent服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class HistoryEventServiceClass: IHistoryEventService
      {
            private IHistoryEventRepository historyEventRepository = new HistoryEventRepositoryClass();

            public IEnumerable<HistoryEvent> FindAll()
            {
                  return historyEventRepository.FindAll();
            }

            public HistoryEvent FindById(object id)
            {
                  return historyEventRepository.FindById(id);
            }
      }
}
