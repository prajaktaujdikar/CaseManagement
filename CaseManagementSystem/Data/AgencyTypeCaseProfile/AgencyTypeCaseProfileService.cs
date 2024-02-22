using CaseManagementSystem.Data.CaseProfiles;
using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.AgencyTypeCaseProfile
{
    public class AgencyTypeCaseProfileService
    {
        private readonly string _connectionString = "";

        public AgencyTypeCaseProfileService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET 

        public async Task<IEnumerable<AgencyTypeCaseProfileViewModel>> GetAgencyTypeCaseProfileByProfileIdAsync(Guid profileId)
        {
            AgencyTypeCaseProfileDM agencyTypeCaseProfileDM = new AgencyTypeCaseProfileDM(_connectionString);
            IEnumerable<CMS.DL.Model.AgencyTypeCaseProfile> agencyTypeCaseProfiles = await agencyTypeCaseProfileDM.GetAgencyTypeCaseProfileByProfileIdAsync(profileId);

            return agencyTypeCaseProfiles.Select(c => new AgencyTypeCaseProfileViewModel
            {
                CaseProfilesId = c.CaseProfilesId,
                AgencyTypesId = c.AgencyTypesId,
                Name = c.Name
            });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertAgencyTypeCaseProfileAsync(AgencyTypeCaseProfileViewModel agencyTypeCaseProfile)
        {
            AgencyTypeCaseProfileDM agencyTypeCaseProfileDM = new AgencyTypeCaseProfileDM(_connectionString);
            return await agencyTypeCaseProfileDM.InsertAgencyTypeCaseProfileAsync(new CMS.DL.Model.AgencyTypeCaseProfile
            {
                AgencyTypesId = agencyTypeCaseProfile.AgencyTypesId,
                CaseProfilesId = agencyTypeCaseProfile.CaseProfilesId
            });
        }

        public async Task<int> DeleteAgencyTypeCaseProfileAsync(Guid profileId)
        {
            AgencyTypeCaseProfileDM agencyTypeCaseProfileDM = new AgencyTypeCaseProfileDM(_connectionString);
            return await agencyTypeCaseProfileDM.DeleteAgencyTypeCaseProfileAsync(profileId);
        }

        #endregion
    }
}
