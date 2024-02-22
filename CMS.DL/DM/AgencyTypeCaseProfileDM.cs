using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class AgencyTypeCaseProfileDM
    {
        private readonly IDbConnection _dbConnection;

        public AgencyTypeCaseProfileDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET 

        public async Task<IEnumerable<AgencyTypeCaseProfile>> GetAgencyTypeCaseProfileByProfileIdAsync(Guid profileId)
        {
            string sql = "SELECT ATCP.*, ATS.[Name] from AgencyTypeCaseProfile AS ATCP LEFT JOIN AgencyTypes AS ATS ON ATCP.AgencyTypesId = ATS.Id WHERE ATCP.CaseProfilesId = @CaseProfilesId";
            return await _dbConnection.QueryAsync<AgencyTypeCaseProfile>(sql, new { CaseProfilesId = profileId });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertAgencyTypeCaseProfileAsync(AgencyTypeCaseProfile agencyTypeCaseProfile)
        {
            string sql = $"INSERT INTO AgencyTypeCaseProfile(AgencyTypesId, CaseProfilesId) VALUES(@AgencyTypesId, @CaseProfilesId)";
            return await _dbConnection.ExecuteAsync(sql, new { AgencyTypesId = agencyTypeCaseProfile.AgencyTypesId, CaseProfilesId = agencyTypeCaseProfile.CaseProfilesId });
        }

        public async Task<int> DeleteAgencyTypeCaseProfileAsync(Guid profileId)
        {
            string sql = $"DELETE FROM AgencyTypeCaseProfile WHERE CaseProfilesId = @CaseProfilesId";
            return await _dbConnection.ExecuteAsync(sql, new { CaseProfilesId = profileId });
        }

        #endregion
    }
}
