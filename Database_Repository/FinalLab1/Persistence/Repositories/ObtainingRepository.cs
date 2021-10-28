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
    public class ObtainingRepository :Repository<Obtaining>, IObtainingRepository
    {
        public ObtainingRepository(DbContext context, string tableName) : base(context, tableName)
        {
            
        }
        public IEnumerable<Obtaining> getObtainingsByDate(string year, string month, string day)
        {
            SqlParameter queryParameter = null;
            string sqlString = "EXEC getActionByDate @tableName = " + tableName;
            if (year != null)
            {
                sqlString += ", @year = '" + year + "'";
                queryParameter = new SqlParameter("@year", year);
            }
            if (month != null)
            {
                sqlString += ", @month = '" + month + "'";
                queryParameter = new SqlParameter("@month", month);
            }
            if (day != null)
            {
                sqlString += ", @day = '" + day + "'";
                queryParameter = new SqlParameter("@day", day);
            }
            return context.Database.SqlQuery<Obtaining>(sqlString,
                queryParameter, new SqlParameter("@tableName", tableName)).ToList();
        }
        public override int Add(Obtaining entity)
        {
            string sqlString = "EXEC insertIntoObtainings @WorkerIdentifier = " + entity.WorkerId +
                ", @FinderIdentifier = " + entity.FinderId +
                ", @FindingIdentifier = " + entity.FindingId +
                ", @DateOfAct = '" + entity.ActTime + "'";
            return context.Database.ExecuteSqlCommand(sqlString,
                new SqlParameter("@WorkerIdentifier", entity.WorkerId),
                new SqlParameter("@FinderIdentifier", entity.FinderId),
                new SqlParameter("@FindingIdentifier", entity.FindingId),
                new SqlParameter("@DateOfAct", entity.ActTime));
        }
    }
}
