using Fhr.ModernHistory.Models;
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

        public DbSet<FamousPerson> FamousPersons { get; set; }

        public DbSet<FamousPersonType> FamousPersonTypes { get; set; }

        public DbSet<HistoryEvent> HistoryEvents { get; set; }

        public DbSet<HistoryEventType> HistoryEventTypes { get; set; }

        public DbSet<MhUser> MhUsers { get; set; }


        public DbSet<PersonEventRelation> PersonEventRelation { get; set; }

        //去掉表名复数
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
