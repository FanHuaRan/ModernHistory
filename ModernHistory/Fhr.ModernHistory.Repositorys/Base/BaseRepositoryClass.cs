using Fhr.ModernHistory.Repositorys.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Repositorys
{
    /// <summary>
    /// 泛型基本仓库实现
    /// 2017/07/01 fhr
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepositoryClass<T> : IBaseRepository<T> where T : class
    {

        public T FindById(object id)
        {
            using (var context = new ModernHisContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Delete(T obj)
        {
            using (var context = new ModernHisContext())
            {
                context.Set<T>().Remove(obj);
                context.SaveChanges();
            }
        }

        public void DeleteById(object id)
        {
            using (var context = new ModernHisContext())
            {
                var obj = FindById(id);
                if (obj != null)
                {
                    Delete(obj);
                }
            }
        }

        public T Save(T obj)
        {
            using (var context = new ModernHisContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
                return obj;
            }
        }

        public virtual T Update(T obj)
        {
            throw new NotImplementedException();

        }

        public T Update(T obj, Func<T, object> getPkHandler)
        {
            using (var context = new ModernHisContext())
            {
                var key = getPkHandler.Invoke(obj);
                var oldObj = context.Set<T>().Find(key);
                if (oldObj == null)
                {
                    return null;
                }
                context.Entry<T>(oldObj).State = EntityState.Modified;
                context.SaveChanges();
                return oldObj;
            }
        }

        public virtual IEnumerable<T> FindAll()
        {
            using (var context = new ModernHisContext())
            {
                return context.Set<T>().Select(p => p);
            }
        }

        public IEnumerable<T> FindByLinq(Func<T, bool> expression)
        {
            using (var context = new ModernHisContext())
            {
                return context.Set<T>()
                              .Where(expression)
                              .Select(p => p);
            }
        }

        public IEnumerable<object> FindByWhereAndSelect(Func<T, bool> whereExpression, Func<T, object> selectExpression)
        {
            using (var context = new ModernHisContext())
            {
                return context.Set<T>()
                              .Where(whereExpression)
                              .Select(selectExpression);
            }
        }

        public IEnumerable<V> FindBySelect<V>(Func<T, V> selectExpression)
        {
            using (var context = new ModernHisContext())
            {
                return context.Set<T>()
                              .Select(selectExpression);
            }
        }

        public IEnumerable<T> FindBySQL(string sql, params object[] sqlParams)
        {
            using (var context = new ModernHisContext())
            {
                return context.Database.SqlQuery<T>(sql, sqlParams);
            }
        }
    }
}
