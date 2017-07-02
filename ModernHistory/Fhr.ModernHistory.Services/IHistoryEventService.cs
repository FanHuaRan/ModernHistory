using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// HistoryEvent服务借口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IHistoryEventService
      {
            IEnumerable<HistoryEvent> FindAll();

            HistoryEvent FindById(Object id);
      }
}
