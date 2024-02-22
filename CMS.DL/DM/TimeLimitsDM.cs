using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class TimeLimitsDM
    {
        private readonly IDbConnection _dbConnection;

        public TimeLimitsDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET 

        public async Task<IEnumerable<TimeLimits>> GetAllTimeLimitsAsync()
        {
            string sql = "SELECT * FROM TimeLimits";
            return await _dbConnection.QueryAsync<TimeLimits>(sql);
        }

        public async Task<TimeLimits> GetTimeLimitsByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM TimeLimits WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TimeLimits>(sql, new { Id = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTimeLimitsAsync(TimeLimits timeLimits)
        {
            string sql = $"INSERT INTO TimeLimits(Created, CreatedBy, Updated, UpdatedBy, Name) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = timeLimits.Created, CreatedBy = timeLimits.CreatedBy, Updated = timeLimits.Updated, UpdatedBy = timeLimits.UpdatedBy, Name = timeLimits.Name });
        }

        public async Task<int> UpdateTimeLimitsAsync(TimeLimits timeLimits)
        {
            string sql = $"UPDATE TimeLimits SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name = @Name WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = timeLimits.Created, CreatedBy = timeLimits.CreatedBy, Updated = timeLimits.Updated, UpdatedBy = timeLimits.UpdatedBy, Name = timeLimits.Name, Id = timeLimits.Id });

        }

        public async Task<int> DeleteTimeLimitsAsync(Guid id)
        {
            string sql = $"DELETE FROM TimeLimits WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
