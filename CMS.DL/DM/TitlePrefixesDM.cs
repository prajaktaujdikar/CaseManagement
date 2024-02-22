using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class TitlePrefixesDM
    {
        private readonly IDbConnection _dbConnection;

        public TitlePrefixesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET 
        public async Task<IEnumerable<TitlePrefixes>> GetAllTitlePrefixesAsync()
        {
            string sql = "SELECT * FROM TitlePrefixes";
            return await _dbConnection.QueryAsync<TitlePrefixes>(sql);
        }

        public async Task<TitlePrefixes> GetTitlePrefixesByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM TitlePrefixes WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TitlePrefixes>(sql, new { Id = id });
        }
        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTitlePrefixesAsync(TitlePrefixes titlePrefixes)
        {
            string sql = $"INSERT INTO TitlePrefixes(Created, CreatedBy, Updated, UpdatedBy, Name) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = titlePrefixes.Created, CreatedBy = titlePrefixes.CreatedBy, Updated = titlePrefixes.Updated, UpdatedBy = titlePrefixes.UpdatedBy, Name = titlePrefixes.Name });

        }

        public async Task<int> UpdateTitlePrefixesAsync(TitlePrefixes titlePrefixes)
        {
            string sql = $"UPDATE TitlePrefixes SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name = @Name WHERE Id = @ID";
            return await _dbConnection.ExecuteAsync(sql, new { Created = titlePrefixes.Created, CreatedBy = titlePrefixes.CreatedBy, Updated = titlePrefixes.Updated, UpdatedBy = titlePrefixes.UpdatedBy, Name = titlePrefixes.Name, Id = titlePrefixes.Id });

        }

        public async Task<int> DeleteTitlePrefixesAsync(Guid id)
        {
            string sql = $"DELETE FROM TitlePrefixes WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
