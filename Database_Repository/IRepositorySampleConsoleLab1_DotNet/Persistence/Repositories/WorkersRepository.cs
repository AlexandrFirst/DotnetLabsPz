using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories
{
    public class WorkersRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkersRepository(DbContext context, string tableName) : base(context, tableName)
        {
        }

        public int GetNumberOfPerformedActions(Worker worker)
        {
            string sqlString = " SELECT dbo.getNumberOfWorkerActions(" + worker.WorkerId + ")";
            return context.Database.SqlQuery<int>(sqlString).FirstOrDefault();
        }
    }
}
