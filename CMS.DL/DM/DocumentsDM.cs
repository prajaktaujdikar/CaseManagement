using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMS.DL.DM
{
    public class DocumentsDM
    {
        private readonly IDbConnection _dbConnection;

        public DocumentsDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<Documents>> GetAllDocumentsAsync()
        {
            string sql = "SELECT * FROM Documents";
            return await _dbConnection.QueryAsync<Documents>(sql);
        }

        public async Task<Documents> GetDocumentsByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM Documents WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Documents>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Documents>> GetDocumentsByCaseIdAsync(Guid caseId)
        {
            string sql = $"SELECT * FROM Documents WHERE CaseId = @CaseId";
            return await _dbConnection.QueryAsync<Documents>(sql, new { CaseId = caseId });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertDocumentsAsync(Documents documents)
        {
            string sql = $"INSERT INTO Documents(Created, CreatedBy, Updated, UpdatedBy, FileName, Data, DataContentType, Size, CaseId) VALUES (@Created, @CreatedBy, @Updated, @UpdatedBy, @FileName, @Data, @DataContentType, @Size, @CaseId)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = documents.Created, CreatedBy = documents.CreatedBy, Updated = documents.Updated, UpdatedBy = documents.UpdatedBy, FileName = documents.FileName, Data = documents.Data, DataContentType = documents.DataContentType, Size = documents.Size, CaseId = documents.CaseId });
        }

        public async Task<int> UpdateDocumentsAsync(Documents documents)
        {
            string sql = $"UPDATE Documents SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, FileName = @FileName, Data = @Data, DataContentType = @DataContentType, Size = @Size, CaseId = @CaseId WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = documents.Created, CreatedBy = documents.CreatedBy, Updated = documents.Updated, UpdatedBy = documents.UpdatedBy, FileName = documents.FileName, Data = documents.Data, DataContentType = documents.DataContentType, Size = documents.Size, CaseId = documents.CaseId, Id = documents.Id });
        }
        #endregion
    }
}
