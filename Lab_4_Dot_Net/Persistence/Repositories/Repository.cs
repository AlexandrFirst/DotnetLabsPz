using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Lab_4_Dot_Net.Core.Repositories;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly DbContext Context;
        protected DbSet<TEntity> Entities;
        public Repository(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            try { 
                Entities.Add(entity);
                return 1;
            }
            catch { return 0; }
        }

        public void AddRange(IEnumerable<TEntity> entities) => Entities.AddRange(entities);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Entities.Where(predicate);

        public TEntity Get(int id) => Entities.Find(id);

        public IEnumerable<TEntity> GetAll() => Entities.ToList();

        public int Remove(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                return 1;
            }
            catch { return 0; }
        }

        public void RemoveRange(IEnumerable<TEntity> entities) => Entities.RemoveRange(entities);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => Entities.SingleOrDefault(predicate);
    }
}