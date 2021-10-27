using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        protected readonly string tableName;

        public Repository(DbContext context, string tableName)
        {
            this.context = context;
            this.tableName = tableName;
        }
        public virtual int Add(TEntity entity)
        {
            List<PropertyInfo> properties = typeof(TEntity).GetProperties().ToList();
            string sqlString = "INSERT INTO " + tableName + " (";
            foreach(var prop in properties)
                if(!prop.Name.Contains("Id"))
                sqlString += prop.Name + ",";
            sqlString = sqlString.Remove(sqlString.Length - 1, 1);
            sqlString += ") VALUES(";
            foreach (var prop in properties)
                if (!prop.Name.Contains("Id"))
                    sqlString += "'" + prop.GetValue(entity, null) + "',";
            sqlString = sqlString.Remove(sqlString.Length - 1, 1);
            sqlString += ")";
            return context.Database.ExecuteSqlCommand(sqlString);
        }
        public int Remove(TEntity entity)
        {
            List<PropertyInfo> identifierProperties = getIdentifierProperties(typeof(TEntity));
            string sqlString = "DELETE FROM " + tableName + " WHERE ";

            for(int i = 0;i < identifierProperties.Count(); i++)
            {
                sqlString += identifierProperties[i].Name + " = " + identifierProperties[i].GetValue(entity, null);
                if (identifierProperties.Count - 1 != i)
                    sqlString += " AND ";
            }
            return context.Database.ExecuteSqlCommand(sqlString);
        }

        public IEnumerable<TEntity> GetAll()
        {
            string sqlString = "EXEC getALL @tableName = " + "'" + tableName + "'";
            return context.Database.SqlQuery<TEntity>(sqlString, new SqlParameter("@tableName", tableName)).ToList();
        }
        public TEntity Get(int id)
        {
            string sqlString = "EXEC get @entityIdentifier = " + id +
                " ,@tableName = '" + tableName + "'";
            return context.Database.SqlQuery<TEntity>(sqlString,
                new SqlParameter("@entityIdentifier", id),
                new SqlParameter("@tableName", tableName)).FirstOrDefault();
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                int result = Add(entity);
                if (result < 0)
                    break;
            }
            return 1;
        }

        public int RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                int result = Remove(entity);
                if (result < 0)
                    break;
            }
            return 1;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => 
            GetAll().AsQueryable().Where(predicate);


        private List<PropertyInfo> getIdentifierProperties(Type entityType)
        {
            List<PropertyInfo> properties = entityType.GetProperties().ToList();
            List<PropertyInfo> identifierProperties = new List<PropertyInfo>();
            foreach (var prop in properties)
                if (prop.CustomAttributes.Count() != 0)
                    identifierProperties.Add(prop);
            return identifierProperties;
        }


        public int AddComposite(TEntity entity)
        {
            List<PropertyInfo> properties = typeof(TEntity).GetProperties().ToList();
            string sqlString = "INSERT INTO " + tableName + " (";
            foreach (PropertyInfo prop in properties)
                sqlString += prop.Name + ",";
            sqlString = sqlString.Remove(sqlString.Length - 1, 1);
            sqlString += ") VALUES (";
            foreach (PropertyInfo prop in properties)
                sqlString += "'" + prop.GetValue(entity, null) + "',";
            sqlString = sqlString.Remove(sqlString.Length - 1, 1);
            sqlString += ");";

            return context.Database.ExecuteSqlCommand(sqlString);
        }
    }

}
