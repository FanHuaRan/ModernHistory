using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 名人类型
    /// 2017/06/30 fhr
    /// </summary>
    public class FamousPersonType
    {
        /// <summary>
        /// 名人类型编号
        /// </summary>
        public Int32 FamousPersonTypeId { get; set; }

        /// <summary>
        /// 名人类型名称
        /// </summary>
        public String FamousPersonTypeName { get; set; }
    }
}
