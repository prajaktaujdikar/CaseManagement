using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class CompanyUsersDM
    {
        private readonly IDbConnection _dbConnection;

        public CompanyUsersDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
