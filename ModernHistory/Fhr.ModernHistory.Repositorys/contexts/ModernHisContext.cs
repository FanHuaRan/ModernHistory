using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Repositorys.contexts
{
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
