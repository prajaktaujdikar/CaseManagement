using CaseManagementSystem.Data.CaseTypes;
using CMS.DL.DM;
using CMS.DL.Model;
using System;

namespace CaseManagementSystem.Data.Documents
{
    public class DocumentService
    {
        private readonly string _connectionString = "";

        public DocumentService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<DocumentViewModel>> GetAllDocumentsAsync()
        {
            DocumentsDM documentsDM = new DocumentsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Documents> documents = await documentsDM.GetAllDocumentsAsync();
            return documents.Select(c => new DocumentViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FileName = c.FileName,
                Data = c.Data,
                DataContentType = c.DataContentType,
                Size = c.Size,
                CaseId = c.CaseId,
            });
        }

        public async Task<DocumentViewModel> GetDocumentsByIdAsync(Guid id)
        {
            DocumentsDM documentsDM = new DocumentsDM(_connectionString);
            CMS.DL.Model.Documents documents = await documentsDM.GetDocumentsByIdAsync(id);

            if (documents != null)
            {
                return new DocumentViewModel
                {
                    Id = documents.Id,
                    Created = documents.Created,
                    CreatedBy = documents.CreatedBy,
                    Updated = documents.Updated,
                    UpdatedBy = documents.UpdatedBy,
                    FileName = documents.FileName,
                    Data = documents.Data,
                    DataContentType = documents.DataContentType,
                    Size = documents.Size,
                    CaseId = documents.CaseId,

                };
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DocumentViewModel>> GetDocumentsByCaseIdAsync(Guid caseId)
        {
            DocumentsDM documentsDM = new DocumentsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Documents> documents = await documentsDM.GetDocumentsByCaseIdAsync(caseId);

            return documents.Select(c => new DocumentViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FileName = c.FileName,
                Data = c.Data,
                DataContentType = c.DataContentType,
                Size = c.Size,
                CaseId = c.CaseId,
            });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertDocumentsAsync(DocumentViewModel documentViewModel)
        {
            DocumentsDM documentsDM = new DocumentsDM(_connectionString);
            int result = await documentsDM.InsertDocumentsAsync(new CMS.DL.Model.Documents
            {
                Created = documentViewModel.Created,
                CreatedBy = documentViewModel.CreatedBy,
                Updated = documentViewModel.Updated,
                UpdatedBy = documentViewModel.UpdatedBy,
                FileName = documentViewModel.FileName,
                Data = documentViewModel.Data,
                DataContentType = documentViewModel.DataContentType,
                Size = documentViewModel.Size,
                CaseId = documentViewModel.CaseId
            });

            return result;
        }

        public async Task<int> UpdateDocumentsAsync(DocumentViewModel documentViewModel)
        {
            DocumentsDM documentsDM = new DocumentsDM(_connectionString);
            int result = await documentsDM.UpdateDocumentsAsync(new CMS.DL.Model.Documents
            {
                Id = documentViewModel.Id,
                Created = documentViewModel.Created,
                CreatedBy = documentViewModel.CreatedBy,
                Updated = documentViewModel.Updated,
                UpdatedBy = documentViewModel.UpdatedBy,
                FileName = documentViewModel.FileName,
                Data = documentViewModel.Data,
                DataContentType = documentViewModel.DataContentType,
                Size = documentViewModel.Size,
                CaseId = documentViewModel.CaseId
            });

            return result;

        }

        #endregion
    }
}
