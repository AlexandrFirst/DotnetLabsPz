using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories
{
    public class ExtradictionRepository : Repository<Extradiction>, IExtradictionRepository
    {
        public ExtradictionRepository(DbContext context, string tableName) : base(context, tableName)
        {

        }
        public override int Add(Extradiction entity)
        {
            //List<PropertyInfo> properties = typeof(Extradiction).GetProperties().ToList();
            //string sqlString = "INSERT INTO " + tableName + " (";
            //foreach (PropertyInfo prop in properties)
            //    sqlString += prop.Name + ",";
            //sqlString = sqlString.Remove(sqlString.Length - 1, 1);
            //sqlString += ") VALUES (";
            //foreach (PropertyInfo prop in properties)
            //    sqlString += "'" + prop.GetValue(entity, null) + "',";
            //sqlString = sqlString.Remove(sqlString.Length - 1, 1);
            //sqlString += ");";
            string sqlString = "EXEC insertIntoExtradictions @OwnerIdentifier = " + entity.OwnerId +
                ", @FindingIdentifier = " + entity.FindingId + ", @WorkerIdentifier = " + entity.WorkerId +
                ", @DateOfAct = '" + entity.ActTime + "'";
            return context.Database.ExecuteSqlCommand(sqlString,
                new SqlParameter("@OwnerIdentifier", entity.OwnerId),
                new SqlParameter("@FindingIdentifier", entity.FindingId),
                new SqlParameter("@WorkerIdentifier", entity.WorkerId),
                new SqlParameter("@DateOfAct", entity.ActTime));
        }

        public IEnumerable<Extradiction> getExtradictionsByDate(string year, string month, string day)
        {
            SqlParameter queryParameter = null;
            string sqlString = "EXEC getActionByDate @tableName = '" + tableName + "'";
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
            return context.Database.SqlQuery<Extradiction>(sqlString,
                queryParameter, new SqlParameter("@tableName", tableName)).ToList();
        }
    }
}
