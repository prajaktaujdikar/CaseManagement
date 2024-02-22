using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CMS.DL.DM
{
    public class CaseProfilesDM
    {
        private readonly IDbConnection _dbConnection;

        public CaseProfilesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET 

        public async Task<IEnumerable<CaseProfiles>> GetAllCaseProfilesAsync()
        {
            string sql = "SELECT CP.*, CT.[Name] AS CaseTypeName, TL.[Name] AS TimeLimitName FROM CaseProfiles AS CP LEFT JOIN CaseTypes AS CT ON CP.CaseTypeId = CT.Id LEFT JOIN TimeLimits AS TL ON CP.TimeLimitId = TL.Id";
            return await _dbConnection.QueryAsync<CaseProfiles>(sql);
        }

        public async Task<CaseProfiles> GetCaseProfilesByIdAsync(Guid id)
        {
            string sql = $"SELECT CP.*, CT.[Name] AS CaseTypeName, TL.[Name] AS TimeLimitName FROM CaseProfiles AS CP LEFT JOIN CaseTypes AS CT ON CP.CaseTypeId = CT.Id LEFT JOIN TimeLimits AS TL ON CP.TimeLimitId = TL.Id WHERE CP.Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<CaseProfiles>(sql, new { Id = id });
        }

        public async Task<CaseProfiles> GetLastCaseProfileAsync()
        {
            string sql = $"SELECT TOP 1 CP.*, CT.[Name] AS CaseTypeName, TL.[Name] AS TimeLimitName FROM CaseProfiles AS CP LEFT JOIN CaseTypes AS CT ON CP.CaseTypeId = CT.Id LEFT JOIN TimeLimits AS TL ON CP.TimeLimitId = TL.Id ORDER BY CP.Created DESC";
            return await _dbConnection.QueryFirstOrDefaultAsync<CaseProfiles>(sql);
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCaseProfilesAsync(CaseProfiles caseProfiles)
        {
            string sql = $"INSERT INTO CaseProfiles(Created, CreatedBy, Updated, UpdatedBy, CaseDescription, TimeLimitId, CaseTypeId) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @CaseDescription, @TimeLimitId, @CaseTypeId);";
            return await _dbConnection.ExecuteAsync(sql, new { Created = caseProfiles.Created, CreatedBy = caseProfiles.CreatedBy, Updated = caseProfiles.Updated, UpdatedBy = caseProfiles.UpdatedBy, CaseDescription = caseProfiles.CaseDescription, TimeLimitId = caseProfiles.TimeLimitId, CaseTypeId = caseProfiles.CaseTypeId});
        }

        public async Task<int> UpdateCaseProfilesAsync(CaseProfiles caseProfiles)
        {
            string sql = $"UPDATE CaseProfiles SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, CaseDescription = @CaseDescription, TimeLimitId = @TimeLimitId, CaseTypeId = @CaseTypeId WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = caseProfiles.Created, CreatedBy = caseProfiles.CreatedBy, Updated = caseProfiles.Updated, UpdatedBy = caseProfiles.UpdatedBy, CaseDescription = caseProfiles.CaseDescription, TimeLimitId = caseProfiles.TimeLimitId, CaseTypeId = caseProfiles.CaseTypeId, Id = caseProfiles.Id });
        }

        public async Task<int> DeleteCaseProfilesAsync(Guid id)
        {
            string sql = $"DELETE FROM CaseProfiles WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
