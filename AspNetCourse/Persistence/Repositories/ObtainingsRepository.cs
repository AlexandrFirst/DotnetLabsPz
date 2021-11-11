using AspNetCourse.Core.Domain;
using AspNetCourse.Core.DTO_s;
using AspNetCourse.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AspNetCourse.Persistence.Repositories
{
    public class ObtainingsRepository : Repository<Obtaining>, IObtainingRepository
    {
        public override int Add(Obtaining entity)
        {
            string sqlStatement = "INSERT INTO " + _tableName + " (";
            var keyProperties = typeof(Obtaining).GetProperties()
                .Where(p => p.GetCustomAttributes().Any(attr => (attr as KeyAttribute) != null));
            foreach (var keyProperty in keyProperties)
                sqlStatement += keyProperty.Name + ",";
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += ") VALUES (";
            foreach (var keyProperty in keyProperties)
                sqlStatement += "'" + keyProperty.GetValue(entity, null) + "',";
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += ");";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}