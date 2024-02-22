using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class AgencyTypesDM
    {
        private readonly IDbConnection _dbConnection;

        public AgencyTypesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<AgencyTypes>> GetAllAgencyTypesAsync()
        {
            string sql = "SELECT * FROM AgencyTypes";
            return await _dbConnection.QueryAsync<AgencyTypes>(sql);
        }

        public async Task<AgencyTypes> GetAgencyTypesByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM AgencyTypes WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<AgencyTypes>(sql, new { Id = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertAgencyTypesAsync(AgencyTypes agencyType)
        {
            string sql = $"INSERT INTO AgencyTypes(Created, CreatedBy, Updated, UpdatedBy, Name) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @Name)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = agencyType.Created, CreatedBy = agencyType.CreatedBy, Updated = agencyType.Updated, UpdatedBy = agencyType.UpdatedBy, Name = agencyType.Name });
        }

        public async Task<int> UpdateAgencyTypesAsync(AgencyTypes agencyType)
        {
            string sql = $"UPDATE AgencyTypes SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, Name = @Name WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = agencyType.Created, CreatedBy = agencyType.CreatedBy, Updated = agencyType.Updated, UpdatedBy = agencyType.UpdatedBy, Name = agencyType.Name, Id = agencyType.Id });
        }

        public async Task<int> DeleteAgencyTypesAsync(Guid id)
        {
            string sql = $"DELETE FROM AgencyTypes WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }    
}
