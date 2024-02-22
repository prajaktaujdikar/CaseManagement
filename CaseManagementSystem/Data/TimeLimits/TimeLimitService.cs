using CMS.DL.DM;

namespace CaseManagementSystem.Data.TimeLimits
{
    public class TimeLimitService
    {
        private readonly string _connectionString = "";

        public TimeLimitService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET 

        public async Task<IEnumerable<TimeLimitViewModel>> GetAllTimeLimitsAsync()
        {
            TimeLimitsDM timeLimitsDM = new TimeLimitsDM(_connectionString);
            IEnumerable<CMS.DL.Model.TimeLimits> timeLimits = await timeLimitsDM.GetAllTimeLimitsAsync();

            return timeLimits.Select(c => new TimeLimitViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                Name = c.Name,
            });
        }

        public async Task<TimeLimitViewModel> GetTimeLimitsByIdAsync(Guid id)
        {
            TimeLimitsDM timeLimitsDM = new TimeLimitsDM(_connectionString);
            CMS.DL.Model.TimeLimits timeLimits = await timeLimitsDM.GetTimeLimitsByIdAsync(id);

            if (timeLimits != null)
            {
                return new TimeLimitViewModel
                {
                    Id = timeLimits.Id,
                    Created = timeLimits.Created,
                    CreatedBy = timeLimits.CreatedBy,
                    Updated = timeLimits.Updated,
                    UpdatedBy = timeLimits.UpdatedBy,
                    Name = timeLimits.Name
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTimeLimitsAsync(TimeLimitViewModel timeLimitViewModel)
        {
            TimeLimitsDM timeLimitsDM = new TimeLimitsDM(_connectionString);
            int result = await timeLimitsDM.InsertTimeLimitsAsync(new CMS.DL.Model.TimeLimits
            {
                Id = timeLimitViewModel.Id,
                Created = timeLimitViewModel.Created,
                CreatedBy = timeLimitViewModel.CreatedBy,
                Updated = timeLimitViewModel.Updated,
                UpdatedBy = timeLimitViewModel.UpdatedBy,
                Name = timeLimitViewModel.Name

            });

            return result;
        }

        public async Task<int> UpdateTimeLimitsAsync(TimeLimitViewModel timeLimitViewModel)
        {
            TimeLimitsDM timeLimitsDM = new TimeLimitsDM(_connectionString);
            int result = await timeLimitsDM.UpdateTimeLimitsAsync(new CMS.DL.Model.TimeLimits
            {
                Id = timeLimitViewModel.Id,
                Created = timeLimitViewModel.Created,
                CreatedBy = timeLimitViewModel.CreatedBy,
                Updated = timeLimitViewModel.Updated,
                UpdatedBy = timeLimitViewModel.UpdatedBy,
                Name = timeLimitViewModel.Name

            });

            return result;
        }

        public async Task<int> DeleteTimeLimitsAsync(Guid id)
        {
            TimeLimitsDM timeLimitsDM = new TimeLimitsDM(_connectionString);
            int result = await timeLimitsDM.DeleteTimeLimitsAsync(id);

            return result;
        }

        #endregion
    }
}
