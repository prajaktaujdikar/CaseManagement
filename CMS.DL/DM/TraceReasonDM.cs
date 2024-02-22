using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class TraceReasonDM
    {
        private readonly IDbConnection _dbConnection;

        public TraceReasonDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<TraceReason>> GetAllTraceReasonsAsync()
        {
            string sql = "SELECT * FROM TraceReason";
            return await _dbConnection.QueryAsync<TraceReason>(sql);
        }

        public async Task<TraceReason> GetTraceReasonByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM TraceReason WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TraceReason>(sql, new { Id = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTraceReasonAsync(TraceReason traceReason)
        {
            string sql = $"INSERT INTO TraceReason(Created, CreatedBy, Updated, UpdatedBy, Name) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = traceReason.Created, CreatedBy = traceReason.CreatedBy, Updated = traceReason.Updated, UpdatedBy = traceReason.UpdatedBy, Name = traceReason.Name });
        }

        public async Task<int> UpdateTraceReasonAsync(TraceReason traceReason)
        {
            string sql = $"UPDATE TraceReason SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name = @Name WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = traceReason.Created, CreatedBy = traceReason.CreatedBy, Updated = traceReason.Updated, UpdatedBy = traceReason.UpdatedBy, Name = traceReason.Name, Id = traceReason.Id});
        }

        public async Task<int> DeleteTraceReasonAsync(Guid id)
        {
            string sql = $"DELETE FROM TraceReason WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
