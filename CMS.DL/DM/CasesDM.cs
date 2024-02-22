using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;
using System.Data;
using static Azure.Core.HttpHeader;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace CMS.DL.DM
{
    public class CasesDM
    {
        private readonly IDbConnection _dbConnection;

        public CasesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<Cases>> GetAllCasesAsync()
        {
            string sql = "SELECT C.*, CO.CompanyName, TL.Name as TraceLevelName, TR.Name as TraceReasonName, CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName FROM Cases AS C LEFT JOIN Companies AS CO ON C.CompanyId = CO.Id LEFT JOIN TraceLevels AS TL ON C.TraceLevelId = TL.Id LEFT JOIN TraceReason AS TR ON C.TraceReasonId = TR.Id LEFT JOIN Subjects AS S ON C.SubjectId = S.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id";
            return await _dbConnection.QueryAsync<Cases>(sql);
        }

        public async Task<Cases> GetCasesByIdAsync(Guid id)
        {
            string sql = $"SELECT C.*, CO.CompanyName, TL.Name as TraceLevelName, TR.Name as TraceReasonName, CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName FROM Cases AS C LEFT JOIN Companies AS CO ON C.CompanyId = CO.Id LEFT JOIN TraceLevels AS TL ON C.TraceLevelId = TL.Id LEFT JOIN TraceReason AS TR ON C.TraceReasonId = TR.Id LEFT JOIN Subjects AS S ON C.SubjectId = S.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id WHERE C.Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Cases>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Cases>> GetCasesByClientAsync(Guid? id)
        {
            string sql = $"SELECT C.*, CO.CompanyName, TL.Name as TraceLevelName, TR.Name as TraceReasonName, CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName FROM Cases AS C LEFT JOIN Companies AS CO ON C.CompanyId = CO.Id LEFT JOIN TraceLevels AS TL ON C.TraceLevelId = TL.Id LEFT JOIN TraceReason AS TR ON C.TraceReasonId = TR.Id LEFT JOIN Subjects AS S ON C.SubjectId = S.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id WHERE C.CreatedBy = @CreatedBy OR C.ClientRef = @ClientRef";
            return await _dbConnection.QueryAsync<Cases>(sql, new { CreatedBy = id, ClientRef = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCasesAsync(Cases cases)
        {
            string sql = $"INSERT INTO Cases(Created, CreatedBy, Updated, UpdatedBy, CompanyId, IndividualId, CaseNumber, TraceLevelId, Fee, DebtAmount, ClientRef, EndClient, TraceReasonId, Notes, Status, SubjectId, CaseLinkId) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @CompanyId, @IndividualId, @CaseNumber, @TraceLevelId, @Fee, @DebtAmount, @ClientRef, @EndClient, @TraceReasonId, @Notes, @Status, @SubjectId, @CaseLinkId)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = cases.Created, CreatedBy = cases.CreatedBy, Updated = cases.Updated, UpdatedBy = cases.UpdatedBy, CompanyId = cases.CompanyId, IndividualId = cases.IndividualId, CaseNumber = cases.CaseNumber, TraceLevelId = cases.TraceLevelId, Fee = cases.Fee, DebtAmount = cases.DebtAmount, ClientRef = cases.ClientRef, EndClient = cases.EndClient, TraceReasonId = cases.TraceReasonId, Notes = cases.Notes, Status = cases.Status, SubjectId = cases.SubjectId, CaseLinkId = cases.CaseLinkId });
        }

        public async Task<int> UpdateCasesAsync(Cases cases)
        {
            string sql = $"UPDATE Cases SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, CompanyId = @CompanyId, IndividualId = @IndividualId, CaseNumber = @CaseNumber, TraceLevelId = @TraceLevelId, Fee = @Fee, DebtAmount = @DebtAmount, ClientRef = @ClientRef, EndClient = @EndClient, TraceReasonId = @TraceReasonId, Notes = @Notes, Status = @Status, SubjectId = @SubjectId, CaseLinkId = @CaseLinkId WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = cases.Created, CreatedBy = cases.CreatedBy, Updated = cases.Updated, UpdatedBy = cases.UpdatedBy, CompanyId = cases.CompanyId, IndividualId = cases.IndividualId, CaseNumber = cases.CaseNumber, TraceLevelId = cases.TraceLevelId, Fee = cases.Fee, DebtAmount = cases.DebtAmount, ClientRef = cases.ClientRef, EndClient = cases.EndClient, TraceReasonId = cases.TraceReasonId, Notes = cases.Notes, Status = cases.Status, SubjectId = cases.SubjectId, CaseLinkId = cases.CaseLinkId, Id = cases.Id });
        }

        public async Task<int> DeleteCasesAsync(Guid id)
        {
            string sql = $"DELETE FROM Cases WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
