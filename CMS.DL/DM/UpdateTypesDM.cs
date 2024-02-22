using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class UpdateTypesDM
    {
        private readonly IDbConnection _dbConnection;

        public UpdateTypesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
