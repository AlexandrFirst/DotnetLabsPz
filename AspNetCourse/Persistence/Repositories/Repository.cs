using AspNetCourse.Core.Domain;
using AspNetCourse.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace AspNetCourse.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected string _tableName;
        protected string connectionString;
        public Repository()
        {
            Type entityType = typeof(TEntity);
            TableAttribute attribute = entityType.GetCustomAttributes()
                .ToList()
                .Where(attr => (attr as TableAttribute) != null).
                FirstOrDefault() as TableAttribute;
            _tableName = attribute.Name;
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public virtual int Add(TEntity entity)
        {
            List<PropertyInfo> properties = typeof(TEntity).GetProperties()
                .Where(prop => !prop.GetCustomAttributes()
                .Any(attr => (attr as KeyAttribute) != null)).ToList();
            string sqlStatement = "INSERT INTO " + _tableName + " (";
            foreach (var property in properties)
                sqlStatement += property.Name + ",";
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += ") VALUES (";
            foreach (var property in properties)
                sqlStatement += "'" + property.GetValue(entity, null) + "',";
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += ");";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach (TEntity entity in entities)
                    Add(entity);
                return 1;

            } catch
            {
                return -1;
            }
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            string sqlStatement = "SELECT * FROM " + _tableName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<TEntity> entities = new List<TEntity>();
                List<PropertyInfo> properties = typeof(TEntity).GetProperties().ToList();
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ConstructorInfo ctor = typeof(TEntity).GetConstructor(Type.EmptyTypes);
                    var entity = (ctor.Invoke(new object[] { }) as TEntity);
                    foreach (var property in properties)
                        property.SetValue(entity, dataReader[property.Name]);
                    entities.Add(entity);
                }
                return entities;
            }
        }
        public int Remove(TEntity entity)
        {
            string sqlStatement = "DELETE FROM " + _tableName +" WHERE ";
            var keyProperties = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes().Any(attr => (attr as KeyAttribute) != null));
            foreach (var keyProperty in keyProperties)
                sqlStatement += String.Format("{0} = {1} AND ", keyProperty.Name, keyProperty.GetValue(entity, null));
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 4);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach (var entitity in entities)
                    Remove(entitity);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public int Update(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties().ToList();
            var keyProperties = properties.Where(p => p.GetCustomAttributes().Any(attr => (attr as KeyAttribute) != null));
            string sqlStatement = "UPDATE " + _tableName + " SET ";
            foreach (var property in properties.Except(keyProperties))
                sqlStatement += String.Format("{0} = '{1}',", property.Name, property.GetValue(entity, null));
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += " WHERE ";
            foreach (var keyPropery in keyProperties)
                sqlStatement += String.Format("{0} = '{1}' AND ", keyPropery.Name, keyPropery.GetValue(entity, null));
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 4);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}