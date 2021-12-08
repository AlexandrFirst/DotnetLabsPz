using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        int Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        int Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}