using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories
{
    public class FindingsRepository : Repository<Finding>, IFindingRepository
    {
        public FindingsRepository(DbContext context, string tableName) : base(context, tableName)
        {

        }

        public IEnumerable<Keyword> getAllKeywords(Finding finding)
        {
            string sqlString = "EXEC getAllKeywordsByFinding @FindingIdentifier = " + finding.FindingId;
            return context.Database.SqlQuery<Keyword>(sqlString, new SqlParameter("@FindingIdentifier", finding.FindingId)).ToList();
        }
    }
}
