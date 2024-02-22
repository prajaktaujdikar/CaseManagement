using CMS.DL.DM;

namespace CaseManagementSystem.Data.Companies
{
    public class CompaniesService
    {
        private readonly string _connectionString = "";

        public CompaniesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<CompaniesViewModel>> GetAllCompaniesAsync()
        {
            CompaniesDM companiesDM = new CompaniesDM(_connectionString);
            IEnumerable<CMS.DL.Model.Companies> companies = await companiesDM.GetAllCompaniesAsync();

            return companies.Select(c => new CompaniesViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                CompanyName = c.CompanyName,
                KeyContact = c.KeyContact,
                KeyContactRole = c.KeyContactRole,
                Email = c.Email,
                InvoiceEmail = c.InvoiceEmail,
                CompanyType = c.CompanyType,
                AddressLine1 = c.AddressLine1,
                AddressLine2 = c.AddressLine2,
                AddressLine3 = c.AddressLine3,
                County = c.County,
                City = c.City,
                Postcode = c.Postcode,
                Country = c.Country
            });
        }

        public async Task<CompaniesViewModel> GetCompaniesByIdAsync(Guid id)
        {
            CompaniesDM companiesDM = new CompaniesDM(_connectionString);
            CMS.DL.Model.Companies company = await companiesDM.GetCompaniesByIdAsync(id);

            if (company != null)
            {
                return new CompaniesViewModel
                {
                    Id = company.Id,
                    Created = company.Created,
                    CreatedBy = company.CreatedBy,
                    Updated = company.Updated,
                    UpdatedBy = company.UpdatedBy,
                    CompanyName = company.CompanyName,
                    KeyContact = company.KeyContact,
                    KeyContactRole = company.KeyContactRole,
                    Email = company.Email,
                    InvoiceEmail = company.InvoiceEmail,
                    CompanyType = company.CompanyType,
                    AddressLine1 = company.AddressLine1,
                    AddressLine2 = company.AddressLine2,
                    AddressLine3 = company.AddressLine3,
                    County = company.County,
                    City = company.City,
                    Postcode = company.Postcode,
                    Country = company.Country
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<CompaniesViewModel> GetLastCompaniesAsync()
        {
            CompaniesDM companiesDM = new CompaniesDM(_connectionString);
            CMS.DL.Model.Companies company = await companiesDM.GetLastCompaniesAsync();

            if (company != null)
            {
                return new CompaniesViewModel
                {
                    Id = company.Id,
                    Created = company.Created,
                    CreatedBy = company.CreatedBy,
                    Updated = company.Updated,
                    UpdatedBy = company.UpdatedBy,
                    CompanyName = company.CompanyName,
                    KeyContact = company.KeyContact,
                    KeyContactRole = company.KeyContactRole,
                    Email = company.Email,
                    InvoiceEmail = company.InvoiceEmail,
                    CompanyType = company.CompanyType,
                    AddressLine1 = company.AddressLine1,
                    AddressLine2 = company.AddressLine2,
                    AddressLine3 = company.AddressLine3,
                    County = company.County,
                    City = company.City,
                    Postcode = company.Postcode,
                    Country = company.Country
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCompaniesAsync(CompaniesViewModel companiesView)
        {
            CompaniesDM companiesDM = new CompaniesDM(_connectionString);
            int result = await companiesDM.InsertCompaniesAsync(new CMS.DL.Model.Companies 
            { 
                Created = companiesView.Created,
                CreatedBy = companiesView.CreatedBy,
                Updated = companiesView.Updated,
                UpdatedBy = companiesView.UpdatedBy,
                CompanyName = companiesView.CompanyName,
                KeyContact = companiesView.KeyContact,
                KeyContactRole = companiesView.KeyContactRole,
                Email = companiesView.Email,
                InvoiceEmail = companiesView.InvoiceEmail,
                CompanyType = Convert.ToByte(companiesView.CompanyType),
                AddressLine1 = companiesView.AddressLine1,
                AddressLine2 = companiesView.AddressLine2,
                AddressLine3 = companiesView.AddressLine3,
                County = companiesView.County,
                City = companiesView.City,
                Postcode = companiesView.Postcode,
                Country = companiesView.Country

            });

            return result;
        }

        public async Task<int> UpadteCompaniesAsync(CompaniesViewModel companiesView)
        {
            CompaniesDM companiesDM = new CompaniesDM(_connectionString);
            int result = await companiesDM.UpdateCompaniesAsync(new CMS.DL.Model.Companies
            {
                Id = companiesView.Id,
                Created = companiesView.Created,
                CreatedBy = companiesView.CreatedBy,
                Updated = companiesView.Updated,
                UpdatedBy = companiesView.UpdatedBy,
                CompanyName = companiesView.CompanyName,
                KeyContact = companiesView.KeyContact,
                KeyContactRole = companiesView.KeyContactRole,
                Email = companiesView.Email,
                InvoiceEmail = companiesView.InvoiceEmail,
                CompanyType = Convert.ToByte(companiesView.CompanyType),
                AddressLine1 = companiesView.AddressLine1,
                AddressLine2 = companiesView.AddressLine2,
                AddressLine3 = companiesView.AddressLine3,
                County = companiesView.County,
                City = companiesView.City,
                Postcode = companiesView.Postcode,
                Country = companiesView.Country

            });

            return result;
        }

        public async Task<int> DeleteCompaniesAsync(Guid id)
        {
            CompaniesDM companiesDM = new CompaniesDM(_connectionString);
            int result = await companiesDM.DeleteCompaniesAsync(id);

            return result;
        }

        #endregion
    }
}
