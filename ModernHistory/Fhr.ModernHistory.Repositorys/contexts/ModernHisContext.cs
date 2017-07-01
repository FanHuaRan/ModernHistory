using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Repositorys.Contexts
{
    /// <summary>
    /// EF数据上下文(mysql数据库)
    /// 2017/06/30 fhr
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ModernHisContext : DbContext
    {
        public ModernHisContext()
            : base("conncodefirst")
        {

        }
        //去掉表名复数
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
