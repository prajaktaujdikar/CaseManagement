using CaseManagementSystem.Data.CaseTypes;
using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.TraceResults
{
    public class TraceResultsService
    {
        private readonly string _connectionString = "";

        public TraceResultsService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<TraceResultViewModel>> GetAllTraceResultsAsync()
        {
            TraceResultsDM traceResultsDM = new TraceResultsDM(_connectionString);
            IEnumerable<CMS.DL.Model.TraceResults> traceResults = await traceResultsDM.GetAllTraceResultsAsync();

            return traceResults.Select(t => new TraceResultViewModel
            {
                Id = t.Id,
                Created = t.Created,
                CreatedBy = t.CreatedBy,
                Updated = t.Updated,
                UpdatedBy = t.UpdatedBy,
                Name = t.Name,
            });
        }

        public async Task<TraceResultViewModel> GetTraceResultsByIdAsync(Guid id)
        {
            TraceResultsDM traceResultsDM = new TraceResultsDM(_connectionString);
            CMS.DL.Model.TraceResults traceResults = await traceResultsDM.GetTraceResultsByIdAsync(id);

            if (traceResults != null)
            {
                return new TraceResultViewModel
                {
                    Id = traceResults.Id,
                    Created = traceResults.Created,
                    CreatedBy = traceResults.CreatedBy,
                    Updated = traceResults.Updated,
                    UpdatedBy = traceResults.UpdatedBy,
                    Name = traceResults.Name,
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTraceResultsAsync(TraceResultViewModel traceResultViewModel)
        {
            TraceResultsDM traceResultsDM = new TraceResultsDM(_connectionString);
            int result = await traceResultsDM.InsertTraceResultsAsync(new CMS.DL.Model.TraceResults
            {
                Created = traceResultViewModel.Created,
                CreatedBy = traceResultViewModel.CreatedBy,
                Updated = traceResultViewModel.Updated,
                UpdatedBy = traceResultViewModel.UpdatedBy,
                Name = traceResultViewModel.Name,

            });
            return result;
        }

        public async Task<int> UpdateTraceResultsAsync(TraceResultViewModel traceResultViewModel)
        {
            TraceResultsDM traceResultsDM = new TraceResultsDM(_connectionString);
            int result = await traceResultsDM.UpdateTraceResultsAsync(new CMS.DL.Model.TraceResults
            {
                Id = traceResultViewModel.Id,
                Created = traceResultViewModel.Created,
                CreatedBy = traceResultViewModel.CreatedBy,
                Updated = traceResultViewModel.Updated,
                UpdatedBy = traceResultViewModel.UpdatedBy,
                Name = traceResultViewModel.Name,

            });
            return result;
        }

        public async Task<int> DeleteTraceResultsAsync(Guid id)
        {
            TraceResultsDM traceResultsDM = new TraceResultsDM(_connectionString);
            int result = await traceResultsDM.DeleteTraceResultsAsync(id);
            return result;
        }

        #endregion
    }
}
