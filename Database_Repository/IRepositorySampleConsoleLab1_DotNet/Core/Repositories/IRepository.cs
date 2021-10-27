using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        int Remove(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
