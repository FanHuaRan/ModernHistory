using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
    /// <summary>
    /// 名人
    /// 2017/06/30 fhr
    /// </summary>
     public class FamousPerson
     {
         /// <summary>
         /// 名人编号
         /// </summary>
         public Int32 FamousPersonId { get; set; }

         /// <summary>
         /// 名人类型编号
         /// </summary>
         public Int32 FamousPersonTypeId { get; set; }        

         /// <summary>
         /// 名人类型
         /// </summary>
         public virtual FamousPersonType PersonType { get; set; }
     }
}
