using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.CaseTypes
{
    public class CaseTypeService
    {
        private readonly string _connectionString = "";

        public CaseTypeService(IConfiguration configuration) 
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<CaseTypeViewModel>> GetAllCaseTypesAsync()
        {
            CaseTypesDM caseTypesDM = new CaseTypesDM (_connectionString);
            IEnumerable<CMS.DL.Model.CaseTypes> caseTypes = await caseTypesDM.GetAllCaseTypesAsync();

            return caseTypes.Select(c => new CaseTypeViewModel 
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                Name = c.Name
            });
        }

        public async Task<CaseTypeViewModel> GetCaseTypesByIdAsync(Guid id)
        {
            CaseTypesDM caseTypesDM = new CaseTypesDM(_connectionString);
            CMS.DL.Model.CaseTypes caseTypes = await caseTypesDM.GetCaseTypesByIdAsync(id);

            if (caseTypes != null)
            {
                return new CaseTypeViewModel
                {
                    Id = caseTypes.Id,
                    Created = caseTypes.Created,
                    CreatedBy = caseTypes.CreatedBy,
                    Updated = caseTypes.Updated,
                    UpdatedBy = caseTypes.UpdatedBy,
                    Name = caseTypes.Name
                };
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCaseTypesAsync(CaseTypeViewModel caseTypeViewModel)
        {
            CaseTypesDM caseTypesDM = new CaseTypesDM(_connectionString);
            int result = await caseTypesDM.InsertCaseTypesAsync(new CMS.DL.Model.CaseTypes
            {
                Created = caseTypeViewModel.Created,
                CreatedBy= caseTypeViewModel.CreatedBy,
                Updated = caseTypeViewModel.Updated,
                UpdatedBy = caseTypeViewModel.UpdatedBy,
                Name = caseTypeViewModel.Name

            });
            return result;
        }

        public async Task<int> UpdateCaseTypesAsync(CaseTypeViewModel caseTypeViewModel)
        {
            CaseTypesDM caseTypesDM = new CaseTypesDM(_connectionString);
            int result = await caseTypesDM.UpdateCaseTypesAsync(new CMS.DL.Model.CaseTypes
            {
                Id = caseTypeViewModel.Id,
                Created = caseTypeViewModel.Created,
                CreatedBy = caseTypeViewModel.CreatedBy,
                Updated = caseTypeViewModel.Updated,
                UpdatedBy = caseTypeViewModel.UpdatedBy,
                Name = caseTypeViewModel.Name

            });
            return result;
        }

        public async Task<int> DeleteCaseTypesAsync(Guid id)
        {
            CaseTypesDM caseTypesDM = new CaseTypesDM(_connectionString);
            int result = await caseTypesDM.DeleteCaseTypesAsync(id);

            return result;
        }

        #endregion
    }
}
