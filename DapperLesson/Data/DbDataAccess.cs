using DapperLesson.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace DapperLesson.Data
{
    public abstract class DbDataAccess<T>: IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;


        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("DataProvider");

            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["dataAccessConnectionString"];
        }
        public void Dispose()
        {
            connection.Close();
        }
        public abstract ICollection<T> Select();
        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(Guid index);


        public void ExecuteTransation(params DbCommand[] commands)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
