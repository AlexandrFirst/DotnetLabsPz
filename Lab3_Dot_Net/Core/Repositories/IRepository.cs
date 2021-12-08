using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dot_Net.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        int Remove(TEntity entity);
        int Update(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        bool Exists(TEntity entity);
    }
}
