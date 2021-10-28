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
    public class FindersRepository : Repository<Finder>, IFinderRepository
    {
        public FindersRepository(DbContext context, string tableName) : base(context, tableName)
        {

        }

        public IEnumerable<Finder> GetFindersByNumberOfObtainings(int obtainingsNumber)
        {
            string sqlString = "SELECT * FROM dbo.getPeopleWhoBroughtMoreThanOneItem(" + obtainingsNumber + ")";
            return context.Database.SqlQuery<Finder>(sqlString).ToList();
        }
    }
}
