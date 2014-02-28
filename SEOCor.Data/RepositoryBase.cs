using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SEOCor.Domain.Entities;

namespace SEOCor.Data
{
    public class RepositoryBase
    {
        private string _connectionString;
        private SEOCorDataDataContext _dataContext;

        public RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
            _dataContext = new SEOCorDataDataContext(connectionString);
        }

        public SEOCorDataDataContext DataContext
        {
            get
            {
                return _dataContext;
            }
        }

        protected IEnumerable<T> Query<T>(string sproc, DynamicParameters parameters)
        {
            IEnumerable<T> data = null;

            // Execute sproc
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    data = SqlMapper.Query<T>(connection, sproc, parameters);
                }
                catch (Exception ex)
                {
                    // todo
                }
            }
            return data;
        }

        /// <summary>
        /// Opens a connection and executes a stored procedure.
        /// </summary>
        /// <param name="sproc"></param>
        /// <param name="parameters"></param>
        protected void ExecuteNonQuerySproc(string sproc, DynamicParameters parameters)
        {
            // Execute sproc
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    SqlMapper.Execute(connection, sproc, param: parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // todo
                }
            }
        }
    }
}
