using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
    /// <summary>
    /// 历史事件
    /// 2017/06/30 fhr
    /// </summary>
    public class HistoryEvent
    {
        /// <summary>
        /// 历史事件编号
        /// </summary>
        public Int32 HistoryEventId { get; set; }
        /// <summary>
        /// 历史事件类型编号
        /// </summary>
        public Int32 HistoryEventTypeId { get; set; }
        /// <summary>
        /// 历史事件类型
        /// </summary>
        public virtual HistoryEventType EventType { get; set; }
    }
}
