using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.Cases
{
    public class CaseService
    {
        private readonly string _connectionString = "";

        public CaseService(IConfiguration configuration) 
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<CaseViewModel>> GetAllCasesAsync()
        {
            CasesDM casesDM = new CasesDM(_connectionString);
            IEnumerable<CMS.DL.Model.Cases> cases = await casesDM.GetAllCasesAsync();

            return cases.Select(c => new CaseViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                CompanyId = c.CompanyId,
                IndividualId = c.IndividualId,
                CaseNumber = c.CaseNumber,
                TraceLevelId = c.TraceLevelId,
                Fee = c.Fee,
                DebtAmount = c.DebtAmount,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                TraceReasonId = c.TraceReasonId,
                Notes = c.Notes,
                Status = c.Status,
                SubjectId = c.SubjectId,
                CaseLinkId = c.CaseLinkId,
                CompanyName = c.CompanyName,
                TraceLevelName = c.TraceLevelName,
                TraceReasonName = c.TraceReasonName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName
            });
        }

        public async Task<CaseViewModel> GetCasesByIdAsync(Guid id)
        {
            CasesDM casesDM = new CasesDM(_connectionString);
            CMS.DL.Model.Cases cases = await casesDM.GetCasesByIdAsync(id);

            if (cases != null)
            {
                return new CaseViewModel
                {
                    Id = cases.Id,
                    Created = cases.Created,
                    CreatedBy = cases.CreatedBy,
                    Updated = cases.Updated,
                    UpdatedBy = cases.UpdatedBy,
                    CompanyId = cases.CompanyId,
                    IndividualId = cases.IndividualId,
                    CaseNumber = cases.CaseNumber,
                    TraceLevelId = cases.TraceLevelId,
                    Fee = cases.Fee,
                    DebtAmount = cases.DebtAmount,
                    ClientRef = cases.ClientRef,
                    EndClient = cases.EndClient,
                    TraceReasonId = cases.TraceReasonId,
                    Notes = cases.Notes,
                    Status = cases.Status,
                    SubjectId = cases.SubjectId,
                    CaseLinkId = cases.CaseLinkId,
                    CompanyName = cases.CompanyName,
                    TraceLevelName = cases.TraceLevelName,
                    TraceReasonName = cases.TraceReasonName,
                    SubjectName = cases.SubjectName,
                    ClientName = cases.ClientName,
                    AgentName = cases.AgentName
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CaseViewModel>> GetCasesByClientAsync(Guid? id)
        {
            CasesDM casesDM = new CasesDM(_connectionString);
            IEnumerable<CMS.DL.Model.Cases> cases = await casesDM.GetCasesByClientAsync(id);

            return cases.Select(c => new CaseViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                CompanyId = c.CompanyId,
                IndividualId = c.IndividualId,
                CaseNumber = c.CaseNumber,
                TraceLevelId = c.TraceLevelId,
                Fee = c.Fee,
                DebtAmount = c.DebtAmount,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                TraceReasonId = c.TraceReasonId,
                Notes = c.Notes,
                Status = c.Status,
                SubjectId = c.SubjectId,
                CaseLinkId = c.CaseLinkId,
                CompanyName = c.CompanyName,
                TraceLevelName = c.TraceLevelName,
                TraceReasonName = c.TraceReasonName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName
            });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCasesAsync(CaseViewModel caseViewModel)
        {
            CasesDM casesDM = new CasesDM(_connectionString);
            int result = await casesDM.InsertCasesAsync(new CMS.DL.Model.Cases
            {
                Created = caseViewModel.Created,
                CreatedBy = caseViewModel.CreatedBy,
                Updated = caseViewModel.Updated,
                UpdatedBy = caseViewModel.UpdatedBy,
                CompanyId = (Guid)caseViewModel.CompanyId,
                IndividualId = caseViewModel.IndividualId,
                CaseNumber = caseViewModel.CaseNumber,
                TraceLevelId = caseViewModel.TraceLevelId,
                Fee = caseViewModel.Fee,
                DebtAmount = caseViewModel.DebtAmount,
                ClientRef = caseViewModel.ClientRef,
                EndClient = caseViewModel.EndClient,
                TraceReasonId = caseViewModel.TraceReasonId,
                Notes = caseViewModel.Notes,
                Status = (byte)caseViewModel.Status,
                SubjectId = caseViewModel.SubjectId,
                CaseLinkId = caseViewModel.CaseLinkId
            });
            return result;
        }

        public async Task<int> UpdateCasesAsync(CaseViewModel caseViewModel)
        {
            CasesDM casesDM = new CasesDM(_connectionString);
            int result = await casesDM.UpdateCasesAsync(new CMS.DL.Model.Cases
            {
                Id = caseViewModel.Id,
                Created = caseViewModel.Created,
                CreatedBy = caseViewModel.CreatedBy,
                Updated = caseViewModel.Updated,
                UpdatedBy = caseViewModel.UpdatedBy,
                CompanyId = (Guid)caseViewModel.CompanyId,
                IndividualId = caseViewModel.IndividualId,
                CaseNumber = caseViewModel.CaseNumber,
                TraceLevelId = caseViewModel.TraceLevelId,
                Fee = caseViewModel.Fee,
                DebtAmount = caseViewModel.DebtAmount,
                ClientRef = caseViewModel.ClientRef,
                EndClient = caseViewModel.EndClient,
                TraceReasonId = caseViewModel.TraceReasonId,
                Notes = caseViewModel.Notes,
                Status = (byte)caseViewModel.Status,
                SubjectId = caseViewModel.SubjectId,
                CaseLinkId = caseViewModel.CaseLinkId
            });
            return result;
        }

        public async Task<int> DeleteCasesAsync(Guid id)
        {
            CasesDM casesDM = new CasesDM(_connectionString);
            int result = await casesDM.DeleteCasesAsync(id);

            return result;
        }

        #endregion
    }
}
