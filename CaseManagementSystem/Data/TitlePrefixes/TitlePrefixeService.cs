using CaseManagementSystem.Data.TitlePrefixes;
using CaseManagementSystem.Pages;
using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.TitlePrefixes
{
    public class TitlePrefixeService
    {
        private readonly string _connectionString = "";

        public TitlePrefixeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<TitlePrefixeViewModel>> GetAllTitlePrefixesAsync()
        {
            TitlePrefixesDM titlePrefixesDM = new TitlePrefixesDM(_connectionString);
            IEnumerable<CMS.DL.Model.TitlePrefixes> titlePrefixes = await titlePrefixesDM.GetAllTitlePrefixesAsync();

            return titlePrefixes.Select(t => new TitlePrefixeViewModel
            {
                Id = t.Id,
                Created = t.Created,
                CreatedBy = t.CreatedBy,
                Updated = t.Updated,
                UpdatedBy = t.UpdatedBy,
                Name = t.Name,
            });
        }

        public async Task<TitlePrefixeViewModel> GetTitlePrefixesByIdAsync(Guid id)
        {
            TitlePrefixesDM titlePrefixesDM = new TitlePrefixesDM(_connectionString);
            CMS.DL.Model.TitlePrefixes titlePrefixes = await titlePrefixesDM.GetTitlePrefixesByIdAsync(id);

            if (titlePrefixes != null)
            {
                return new TitlePrefixeViewModel
                {
                    Id = titlePrefixes.Id,
                    Created = titlePrefixes.Created,
                    CreatedBy = titlePrefixes.CreatedBy,
                    Updated = titlePrefixes.Updated,
                    UpdatedBy = titlePrefixes.UpdatedBy,
                    Name = titlePrefixes.Name
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertTitlePrefixeAsync(TitlePrefixeViewModel titlePrefixeViewModel)
        {
            TitlePrefixesDM titlePrefixesDM = new TitlePrefixesDM(_connectionString);
            int result = await titlePrefixesDM.InsertTitlePrefixesAsync(new CMS.DL.Model.TitlePrefixes
            {
                Id = titlePrefixeViewModel.Id,
                Created = titlePrefixeViewModel.Created,
                CreatedBy = titlePrefixeViewModel.CreatedBy,
                Updated = titlePrefixeViewModel.Updated,
                UpdatedBy= titlePrefixeViewModel.UpdatedBy,
                Name = titlePrefixeViewModel.Name
            });
            return result;
        }

        public async Task<int> UpdateTitlePrefixeAsync(TitlePrefixeViewModel titlePrefixeViewModel)
        {
            TitlePrefixesDM titlePrefixesDM = new TitlePrefixesDM(_connectionString);
            int result = await titlePrefixesDM.UpdateTitlePrefixesAsync(new CMS.DL.Model.TitlePrefixes
            {
                Id = titlePrefixeViewModel.Id,
                Created = titlePrefixeViewModel.Created,
                CreatedBy = titlePrefixeViewModel.CreatedBy,
                Updated = titlePrefixeViewModel.Updated,
                UpdatedBy = titlePrefixeViewModel.UpdatedBy,
                Name = titlePrefixeViewModel.Name
            });
            return result;
        }

        public async Task<int> DeleteTitlePrefixesAsync(Guid id)
        {
            TitlePrefixesDM titlePrefixesDM = new TitlePrefixesDM(_connectionString);
            int result = await titlePrefixesDM.DeleteTitlePrefixesAsync(id);
            return result;
        }

        #endregion
    }
}
