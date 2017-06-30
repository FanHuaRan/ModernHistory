using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Repositorys.contexts
{
    /// <summary>
    /// EF数据库初始化策略
    /// 2017/06/30 fhr
    /// </summary>
    public class SampleData : DropCreateDatabaseIfModelChanges<ModernHisContext>
    {
        /// <summary>
        /// 数据库初始化操作
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ModernHisContext context)
        {

        }
    }
}
