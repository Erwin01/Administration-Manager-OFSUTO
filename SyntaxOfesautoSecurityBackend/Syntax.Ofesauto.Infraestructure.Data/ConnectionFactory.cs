using Microsoft.Extensions.Configuration;
using Syntax.Ofesauto.Security.Transversal.Common;
using System.Data;
using System.Data.SqlClient;

namespace Syntax.Ofesauto.Security.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// Object allows accessing the properties of different projects
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Method to connect to the database and return the instance of the connection
        /// </summary>
        /// <param name="configuration"></param>
        /// 
        #region [ ICONFIGURATION ]
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        /// <summary>
        /// Method to access database and returns open connection instance
        /// </summary>
        /// 
        #region [ GET CONNECTION ]
        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();

                if (sqlConnection == null)
                {
                    return null;
                }
                else
                {
                    sqlConnection.ConnectionString = _configuration.GetConnectionString("Ofesauto");
                    sqlConnection.Open();

                    return sqlConnection;
                }
            }
        }
        #endregion
    }
}
