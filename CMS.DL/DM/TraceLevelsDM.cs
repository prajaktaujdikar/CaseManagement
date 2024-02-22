using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace CMS.DL.DM
{
    public class TraceLevelsDM
    {
        private readonly IDbConnection _dbConnection;

        public TraceLevelsDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<TraceLevels>> GetAllTraceLevelsAsync()
        {
            string sql = "SELECT * FROM TraceLevels";
            return await _dbConnection.QueryAsync<TraceLevels>(sql);
        }

        public async Task<TraceLevels> GetTraceLevelsByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM TraceLevels WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TraceLevels>(sql, new { ID = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTraceLevelAsync(TraceLevels traceLevels)
        {
            string sql = $"INSERT INTO TraceLevels (Created, CreatedBy, Updated, UpdatedBy, Name) Values(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql , new { Created = traceLevels.Created, CreatedBy = traceLevels.CreatedBy, Updated = traceLevels.Updated, UpdatedBy = traceLevels.UpdatedBy, Name = traceLevels.Name });

        }

        public async Task<int> UpdateTraceLevelAsync(TraceLevels traceLevels)
        {
            string sql = $"UPDATE TraceLevels SET Created = @Created,  CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name = @Name WHERE ID = @ID";
            return await _dbConnection.ExecuteAsync(sql, new { Created = traceLevels.Created, CreatedBy = traceLevels.CreatedBy, Updated = traceLevels.Updated, UpdatedBy = traceLevels.UpdatedBy, Name = traceLevels.Name, Id = traceLevels.Id });
        }

        public async Task<int> DeleteTraceLevelAsync(Guid id)
        {
            string sql = $"DELETE FROM TraceLevels WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
