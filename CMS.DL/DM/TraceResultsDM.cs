using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class TraceResultsDM
    {
        private readonly IDbConnection _dbConnection;

        public TraceResultsDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET
        public async Task<IEnumerable<TraceResults>> GetAllTraceResultsAsync()
        {
            string sql = "SELECT * FROM TraceResults";
            return await _dbConnection.QueryAsync<TraceResults>(sql);
        }

        public async Task<TraceResults> GetTraceResultsByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM TraceResults WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TraceResults>(sql, new { Id = id });
        }
        #endregion


        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTraceResultsAsync(TraceResults traceResults)
        {
            string sql = $"INSERT INTO TraceResults(Created, CreatedBy, Updated, UpdatedBy, Name) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = traceResults.Created, CreatedBy = traceResults.CreatedBy, Updated = traceResults.Updated, UpdatedBy = traceResults.UpdatedBy, Name = traceResults.Name });
        }
        public async Task<int> UpdateTraceResultsAsync(TraceResults traceResults)
        {
            string sql = $"UPDATE TraceResults SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name = @Name WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = traceResults.Created, CreatedBy = traceResults.CreatedBy, Updated = traceResults.Updated, UpdatedBy = traceResults.UpdatedBy, Name = traceResults.Name , Id = traceResults.Id });
        }

        public async Task<int> DeleteTraceResultsAsync(Guid id)
        {
            string sql = $"DELETE FROM TraceResults WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
