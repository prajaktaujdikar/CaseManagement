using CaseManagementSystem.Data.Users;
using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.AgencyTypes
{
    public class AgencyTypeService
    {
        private readonly string _connectionString = "";

        public AgencyTypeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<AgencyTypeViewModel>> GetAllAgencyTypesAsync()
        {
            AgencyTypesDM agencyTypesDM = new AgencyTypesDM(_connectionString);
            IEnumerable<CMS.DL.Model.AgencyTypes> agencyTypes = await agencyTypesDM.GetAllAgencyTypesAsync();

            return agencyTypes.Select(a => new AgencyTypeViewModel
            {
                Id = a.Id,
                Created = a.Created,
                CreatedBy = a.CreatedBy,
                Updated = a.Updated,
                UpdatedBy = a.UpdatedBy,
                Name = a.Name,
            });
        }

        public async Task<AgencyTypeViewModel> GetAgencyTypesByIdAsync(Guid id)
        {
            AgencyTypesDM agencyTypesDM = new AgencyTypesDM(_connectionString);
            CMS.DL.Model.AgencyTypes agencyType = await agencyTypesDM.GetAgencyTypesByIdAsync(id);

            if (agencyType != null)
            {
                return new AgencyTypeViewModel
                {
                    Id = agencyType.Id,
                    Created = agencyType.Created,
                    CreatedBy = agencyType.CreatedBy,
                    Updated = agencyType.Updated,
                    UpdatedBy = agencyType.UpdatedBy,
                    Name = agencyType.Name,
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertAgencyTypesAsync(AgencyTypeViewModel agencyTypeView)
        {
            AgencyTypesDM agencyTypesDM = new AgencyTypesDM(_connectionString);
            int result = await agencyTypesDM.InsertAgencyTypesAsync(new CMS.DL.Model.AgencyTypes
            {
                Created = agencyTypeView.Created,
                CreatedBy = agencyTypeView.CreatedBy,
                Updated = agencyTypeView.Updated,
                UpdatedBy = agencyTypeView.UpdatedBy,
                Name = agencyTypeView.Name,
            });

            return result;
        }

        public async Task<int> UpdateAgencyTypesAsync(AgencyTypeViewModel agencyTypeView)
        {
            AgencyTypesDM agencyTypesDM = new AgencyTypesDM(_connectionString);
            int result = await agencyTypesDM.UpdateAgencyTypesAsync(new CMS.DL.Model.AgencyTypes
            {
                Id = agencyTypeView.Id,
                Created = agencyTypeView.Created,
                CreatedBy = agencyTypeView.CreatedBy,
                Updated = agencyTypeView.Updated,
                UpdatedBy = agencyTypeView.UpdatedBy,
                Name = agencyTypeView.Name,
            });
            return result;
        }

        public async Task<int> DeleteAgencyTypesAsync(Guid id)
        {
            AgencyTypesDM agencyTypesDM = new AgencyTypesDM(_connectionString);
            int result = await agencyTypesDM.DeleteAgencyTypesAsync(id);

            return result;
        }

        #endregion
    }
}