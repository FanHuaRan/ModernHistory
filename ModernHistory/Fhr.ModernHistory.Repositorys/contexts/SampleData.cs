using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Repositorys.Contexts
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
                  var personTypes = new List<FamousPersonType>()
                  {
                        new FamousPersonType(){FamousPersonTypeName = "思想家"},
                        new FamousPersonType(){FamousPersonTypeName ="政治家"},
                        new FamousPersonType(){FamousPersonTypeName = "军事家"},
                        new FamousPersonType(){FamousPersonTypeName = "文学家"},
                        new FamousPersonType(){FamousPersonTypeName = "商人"},
                        new FamousPersonType(){FamousPersonTypeName = "明星"},
                  };
                  personTypes.ForEach(p => context.FamousPersonTypes.Add(p));
                  var persons = new List<FamousPerson>()
                  {
                        new FamousPerson()
                        {
                              PersonName="曾国藩",
                              Province="湖南",
                              Nation="汉族",
                              BornDate=DateTime.Parse("1828/06/02"),
                              BornPlace="湖南省xxxxxxxx",
                              BornX=54521d,
                              BornY=124d,
                              DeadDate=DateTime.Parse("1828/06/02"),
                              Gender=1,
                              PersonType=personTypes.First()
                        }
                  };
                  persons.ForEach(p => context.FamousPersons.Add(p));
                  context.SaveChanges();
            }
      }
}
