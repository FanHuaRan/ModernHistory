using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 历史事件类型
    /// 2017/06/30 fhr
    /// </summary>
    public class HistoryEventType
    {
        /// <summary>
        /// 历史事件类型编号
        /// </summary>
        public Int32 HistoryEventTypeId { get; set; }
        /// <summary>
        /// 历史事件类型名称
        /// </summary>
        public string HistoryEventTypeName { get; set; }
    }
}
