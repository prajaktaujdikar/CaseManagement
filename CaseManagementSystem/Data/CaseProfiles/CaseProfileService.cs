using CaseManagementSystem.Data.CaseTypes;
using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.CaseProfiles
{
    public class CaseProfileService
    {
        private readonly string _connectionString = "";

        public CaseProfileService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET 

        public async Task<IEnumerable<CaseProfileViewModel>> GetAllCaseProfilesAsync()
        {
            CaseProfilesDM caseProfilesDM = new CaseProfilesDM(_connectionString);
            IEnumerable<CMS.DL.Model.CaseProfiles> caseProfiles = await caseProfilesDM.GetAllCaseProfilesAsync();

            return caseProfiles.Select(c => new CaseProfileViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                CaseDescription = c.CaseDescription,
                TimeLimitId = c.TimeLimitId,
                CaseTypeId = c.CaseTypeId,
                CaseTypeName = c.CaseTypeName,
                TimeLimitName = c.TimeLimitName
            }) ;
        }

        public async Task<CaseProfileViewModel> GetCaseProfilesByIdAsync(Guid id)
        {
            CaseProfilesDM caseProfilesDM = new CaseProfilesDM(_connectionString);
            CMS.DL.Model.CaseProfiles caseProfiles = await caseProfilesDM.GetCaseProfilesByIdAsync(id);

            if (caseProfiles != null)
            {
                return new CaseProfileViewModel
                {
                    Id = caseProfiles.Id,
                    Created = caseProfiles.Created,
                    CreatedBy = caseProfiles.CreatedBy,
                    Updated = caseProfiles.Updated,
                    UpdatedBy = caseProfiles.UpdatedBy,
                    CaseDescription = caseProfiles.CaseDescription,
                    TimeLimitId = caseProfiles.TimeLimitId,
                    CaseTypeId = caseProfiles.CaseTypeId,
                    CaseTypeName = caseProfiles.CaseTypeName,
                    TimeLimitName = caseProfiles.TimeLimitName
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<CaseProfileViewModel> GetLastCaseProfileAsync()
        {
            CaseProfilesDM caseProfilesDM = new CaseProfilesDM(_connectionString);
            CMS.DL.Model.CaseProfiles caseProfiles = await caseProfilesDM.GetLastCaseProfileAsync();

            if (caseProfiles != null)
            {
                return new CaseProfileViewModel
                {
                    Id = caseProfiles.Id,
                    Created = caseProfiles.Created,
                    CreatedBy = caseProfiles.CreatedBy,
                    Updated = caseProfiles.Updated,
                    UpdatedBy = caseProfiles.UpdatedBy,
                    CaseDescription = caseProfiles.CaseDescription,
                    TimeLimitId = caseProfiles.TimeLimitId,
                    CaseTypeId = caseProfiles.CaseTypeId,
                    CaseTypeName = caseProfiles.CaseTypeName,
                    TimeLimitName = caseProfiles.TimeLimitName
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE
        public async Task<int> InsertCaseProfilesAsync(CaseProfileViewModel caseProfileViewModel)
        {
            CaseProfilesDM caseProfilesDM = new CaseProfilesDM(_connectionString);
            int result = await caseProfilesDM.InsertCaseProfilesAsync(new CMS.DL.Model.CaseProfiles
            {
                Id = caseProfileViewModel.Id,
                Created = caseProfileViewModel.Created,
                CreatedBy = caseProfileViewModel.CreatedBy,
                Updated = caseProfileViewModel.Updated,
                UpdatedBy = caseProfileViewModel.UpdatedBy,
                CaseDescription = caseProfileViewModel.CaseDescription,
                TimeLimitId = caseProfileViewModel.TimeLimitId,
                CaseTypeId = caseProfileViewModel.CaseTypeId
            });

            return result;
        }

        public async Task<int> UpdateCaseProfilesAsync(CaseProfileViewModel caseProfileViewModel)
        {
            CaseProfilesDM caseProfilesDM = new CaseProfilesDM(_connectionString);
            int result = await caseProfilesDM.UpdateCaseProfilesAsync(new CMS.DL.Model.CaseProfiles
            {
                Id = caseProfileViewModel.Id,
                Created = caseProfileViewModel.Created,
                CreatedBy = caseProfileViewModel.CreatedBy,
                Updated = caseProfileViewModel.Updated,
                UpdatedBy = caseProfileViewModel.UpdatedBy,
                CaseDescription = caseProfileViewModel.CaseDescription,
                TimeLimitId = caseProfileViewModel.TimeLimitId,
                CaseTypeId = caseProfileViewModel.CaseTypeId
            });

            return result;
        }

        public async Task<int> DeleteCaseProfilesAsync(Guid id)
        {
            CaseProfilesDM caseProfilesDM = new CaseProfilesDM(_connectionString);
            return await caseProfilesDM.DeleteCaseProfilesAsync(id);
        }

        #endregion
    }
}


