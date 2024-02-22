using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace CMS.DL.DM
{
    public class CompaniesDM
    {
        private readonly IDbConnection _dbConnection;

        public CompaniesDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<Companies>> GetAllCompaniesAsync()
        {
            string sql = "SELECT * FROM Companies";
            return await _dbConnection.QueryAsync<Companies>(sql);
        }

        public async Task<Companies> GetCompaniesByIdAsync(Guid id)
        {
            string sql = $"SELECT * FROM Companies WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Companies>(sql, new { Id = id });
        }

        public async Task<Companies> GetLastCompaniesAsync()
        {
            string sql = $"SELECT TOP 1 * FROM Companies ORDER BY Created DESC";
            return await _dbConnection.QueryFirstOrDefaultAsync<Companies>(sql);
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertCompaniesAsync(Companies company)
        {
            string sql = $"INSERT INTO Companies(Created, CreatedBy, Updated, UpdatedBy, CompanyName, KeyContact, KeyContactRole, Email, InvoiceEmail, CompanyType, AddressLine1, AddressLine2, AddressLine3, County, City, Postcode, Country) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @CompanyName, @KeyContact, @KeyContactRole, @Email, @InvoiceEmail, @CompanyType, @AddressLine1, @AddressLine2, @AddressLine3, @County, @City, @Postcode, @country)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = company.Created, CreatedBy = company.CreatedBy, Updated  = company.Updated, UpdatedBy = company.UpdatedBy, CompanyName = company.CompanyName, KeyContact = company.KeyContact, KeyContactRole = company.KeyContactRole, Email = company.Email ,InvoiceEmail = company.InvoiceEmail, CompanyType = company.CompanyType, AddressLine1 = company.AddressLine1, AddressLine2 = company.AddressLine2, AddressLine3 = company.AddressLine3, County = company.County, City = company.City, Postcode = company.Postcode, Country = company.Country});
        }

        public async Task<int> UpdateCompaniesAsync(Companies company)
        {
            string sql = $"UPDATE Companies SET Created = @Created, CreatedBy = @CreatedBy,Updated = @Updated, UpdatedBy = @UpdatedBy, CompanyName = @CompanyName, KeyContact = @KeyContact, KeyContactRole = @KeyContactRole, Email = @Email, InvoiceEmail = @InvoiceEmail,CompanyType = @CompanyType, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressLine3 = @AddressLine3, County = @County, City = @City, Postcode = @Postcode, Country = @Country WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = company.Created, CreatedBy = company.CreatedBy, Updated = company.Updated, UpdatedBy = company.UpdatedBy, CompanyName = company.CompanyName, KeyContact = company.KeyContact, KeyContactRole = company.KeyContactRole, Email = company.Email, InvoiceEmail = company.InvoiceEmail, CompanyType = company.CompanyType, AddressLine1 = company.AddressLine1, AddressLine2 = company.AddressLine2, AddressLine3 = company.AddressLine3, County = company.County, City = company.City, Postcode = company.Postcode, Country = company.Country, Id = company.Id });
        }

        public async Task<int> DeleteCompaniesAsync(Guid id)
        {
            string sql = $"DELETE FROM Companies WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
