using CaseManagementSystem.Data.TraceLevels;
using CMS.DL.DM;

namespace CaseManagementSystem.Data.TraceReason
{
    public class TraceReasonService
    {
        private readonly string _connectionString = "";

        public TraceReasonService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<TraceReasonViewModel>> GetAllTraceReasonsAsync()
        {
            TraceReasonDM traceReasonDM = new TraceReasonDM(_connectionString);
            IEnumerable<CMS.DL.Model.TraceReason> traceReason = await traceReasonDM.GetAllTraceReasonsAsync();

            return traceReason.Select(c => new TraceReasonViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                Name = c.Name
            });
        }

        public async Task<TraceReasonViewModel> GetTraceReasonByIdAsync(Guid id)
        {
            TraceReasonDM traceReasonDM = new TraceReasonDM(_connectionString);
            CMS.DL.Model.TraceReason traceReason = await traceReasonDM.GetTraceReasonByIdAsync(id);

            if (traceReason != null)
            {
                return new TraceReasonViewModel
                {
                    Id = traceReason.Id,
                    Created = traceReason.Created,
                    CreatedBy = traceReason.CreatedBy,
                    Updated = traceReason.Updated,
                    UpdatedBy = traceReason.UpdatedBy,
                    Name = traceReason.Name
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTraceReasonAsync(TraceReasonViewModel traceReasonViewModel)
        {
            TraceReasonDM traceReasonDM = new TraceReasonDM(_connectionString);
            int result = await traceReasonDM.InsertTraceReasonAsync(new CMS.DL.Model.TraceReason
            {
                Created = traceReasonViewModel.Created,
                CreatedBy = traceReasonViewModel.CreatedBy,
                Updated = traceReasonViewModel.Updated,
                UpdatedBy = traceReasonViewModel.UpdatedBy,
                Name = traceReasonViewModel.Name
            });

            return result;
        }

        public async Task<int> UpdateTraceReasonAsync(TraceReasonViewModel traceReasonViewModel)
        {
            TraceReasonDM traceReasonDM = new TraceReasonDM(_connectionString);
            int result = await traceReasonDM.UpdateTraceReasonAsync(new CMS.DL.Model.TraceReason
            {
                Id = traceReasonViewModel.Id,
                Created = traceReasonViewModel.Created,
                CreatedBy = traceReasonViewModel.CreatedBy,
                Updated = traceReasonViewModel.Updated,
                UpdatedBy = traceReasonViewModel.UpdatedBy,
                Name = traceReasonViewModel.Name
            });

            return result;
        }

        public async Task<int> DeleteTraceReasonAsync(Guid id)
        {
            TraceReasonDM traceReasonDM = new TraceReasonDM(_connectionString);
            int result = await traceReasonDM.DeleteTraceReasonAsync(id);

            return result;
        }

        #endregion
    }
}
