using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class CaseUpdatesDM
    {
        private readonly IDbConnection _dbConnection;

        public CaseUpdatesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
