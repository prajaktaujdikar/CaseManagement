using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class CaseTypesDM
    {
        private readonly IDbConnection _dbConnection;

        public CaseTypesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<CaseTypes>> GetAllCaseTypesAsync()
        {
            string sql = "SELECT * FROM CaseTypes";
            return await _dbConnection.QueryAsync<CaseTypes>(sql);
        }

        public async Task<CaseTypes> GetCaseTypesByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM CaseTypes WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<CaseTypes>(sql , new { Id = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCaseTypesAsync(CaseTypes caseTypes)
        {
            string sql = $"INSERT INTO CaseTypes(Created, CreatedBy, Updated, UpdatedBy, Name) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql , new {Created = caseTypes.Created, CreatedBy = caseTypes.CreatedBy, Updated = caseTypes.Updated, UpdatedBy = caseTypes.UpdatedBy, Name = caseTypes.Name});
        }

        public async Task<int> UpdateCaseTypesAsync(CaseTypes caseTypes)
        {
            string sql = $"UPDATE CaseTypes SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name =@Name WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql ,new {Created = caseTypes.Created, CreatedBy = caseTypes.CreatedBy, Updated = caseTypes.Updated, UpdatedBy = caseTypes.UpdatedBy, Name = caseTypes.Name, Id = caseTypes.Id});
        }

        public async Task<int> DeleteCaseTypesAsync(Guid id)
        {
            string sql = $"DELETE FROM CaseTypes WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
