using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCourse.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);

        int Remove(TEntity entity);

        int Update(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
