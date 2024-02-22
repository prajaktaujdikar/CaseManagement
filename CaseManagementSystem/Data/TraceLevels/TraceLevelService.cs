using CaseManagementSystem.Data.TraceLevels;
using CaseManagementSystem.Data.TimeLimits;
using CMS.DL.DM;
using CMS.DL.Model;
using System.Diagnostics;

namespace CaseManagementSystem.Data.TraceLevels
{
    public class TraceLevelService
    {
        private readonly string _connectionString = "";

        public TraceLevelService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<TraceLevelViewModel>> GetAllTraceLevelsAsync()
        {
            TraceLevelsDM traceLevelDM = new TraceLevelsDM(_connectionString);
            IEnumerable<CMS.DL.Model.TraceLevels> traceLevel = await traceLevelDM.GetAllTraceLevelsAsync();

            return traceLevel.Select(c => new TraceLevelViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                Name = c.Name
            });
        }

        public async Task<TraceLevelViewModel> GetTraceLevelsByIdAsync(Guid id)
        {
            TraceLevelsDM traceLevelDM = new TraceLevelsDM(_connectionString);
            CMS.DL.Model.TraceLevels traceLevel = await traceLevelDM.GetTraceLevelsByIdAsync(id);

            if(traceLevel != null)
            {
                return new TraceLevelViewModel
                {
                    Id = traceLevel.Id,
                    Created = traceLevel.Created,
                    CreatedBy = traceLevel.CreatedBy,
                    Updated = traceLevel.Updated,
                    UpdatedBy = traceLevel.UpdatedBy,
                    Name = traceLevel.Name
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTraceLevelAsync(TraceLevelViewModel traceLevelViewModel)
        {
            TraceLevelsDM traceLevelsDM = new TraceLevelsDM(_connectionString);
            int result = await traceLevelsDM.InsertTraceLevelAsync(new CMS.DL.Model.TraceLevels
            {
                Created = traceLevelViewModel.Created,
                CreatedBy = traceLevelViewModel.CreatedBy,
                Updated = traceLevelViewModel.Updated,
                UpdatedBy = traceLevelViewModel.UpdatedBy,
                Name = traceLevelViewModel.Name
            });
            return result;
        }

        public async Task<int> UpdateTraceLevelAsync(TraceLevelViewModel traceLevelViewModel)
        {
            TraceLevelsDM traceLevelsDM = new TraceLevelsDM(_connectionString);
            int result = await traceLevelsDM.UpdateTraceLevelAsync(new CMS.DL.Model.TraceLevels
            {
                Id = traceLevelViewModel.Id,
                Created = traceLevelViewModel.Created,
                CreatedBy = traceLevelViewModel.CreatedBy,
                Updated = traceLevelViewModel.Updated,
                UpdatedBy = traceLevelViewModel.UpdatedBy,
                Name = traceLevelViewModel.Name
            });
            return result;
        }

        public async Task<int> DeleteTraceLevelAsync(Guid id)
        {
            TraceLevelsDM traceLevelsDM = new TraceLevelsDM(_connectionString);
            int result = await traceLevelsDM.DeleteTraceLevelAsync(id);
            return result;
        }

        #endregion
    }
}
