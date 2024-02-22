using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class UsersDM
    {
        private readonly IDbConnection _dbConnection;

        public UsersDM(string connectionString) 
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            string sql = "SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id";
            return await _dbConnection.QueryAsync<Users>(sql);
        }

        public async Task<IEnumerable<Users>> GetAllUsersByClientAsync(Guid? clientId)
        {
            string sql = "SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.CreatedBy = @CreatedBy";
            return await _dbConnection.QueryAsync<Users>(sql, new { CreatedBy = clientId });
        }

        public async Task<IEnumerable<Users>> GetAllAgentsAsync()
        {
            string sql = "SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.RoleType = 3";
            return await _dbConnection.QueryAsync<Users>(sql);
        }

        public async Task<IEnumerable<Users>> GetAllClientsAsync()
        {
            string sql = "SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.RoleType = 2";
            return await _dbConnection.QueryAsync<Users>(sql);
        }

        public async Task<Users> GetUsersByIdAsync(Guid id)
        {
            string sql = $"SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id});
        }

        public async Task<Users> GetUsersByUserNameAsync(string userName, Guid? excludeId = null)
        {
            if (excludeId != null && excludeId != Guid.Empty)
            {
                string sql = $"SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.UserName = @UserName AND U.Id NOT IN (@Id)";
                return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql, new { UserName = userName, Id = excludeId });
            }
            else
            {
                string sql = $"SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.UserName = @UserName";
                return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql, new { UserName = userName });
            }
        }

        public async Task<Users> GetUsersByEmailAddressAsync(string emailAddress, Guid? excludeId = null)
        {
            if (excludeId != null && excludeId != Guid.Empty)
            {
                string sql = $"SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.EmailAddress = @EmailAddress AND U.Id NOT IN (@Id)";
                return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql, new { EmailAddress = emailAddress, Id = excludeId });
            }
            else
            {
                string sql = $"SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE U.EmailAddress = @EmailAddress";
                return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql, new { EmailAddress = emailAddress });
            }
        }

        public async Task<Users> CheckLogin(string userName)
        {
            string sql = $"SELECT U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id WHERE (U.UserName = @UserName OR U.EmailAddress = @UserName) AND U.RoleType IS NOT NULL AND U.IsActive = 1";
            return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql, new { UserName = userName });
        }

        public async Task<Users> GetLastUsersAsync()
        {
            string sql = $"SELECT TOP 1 U.*, C.CompanyName FROM Users AS U LEFT JOIN Companies AS C ON U.CompanyId = C.Id ORDER BY U.Created DESC";
            return await _dbConnection.QueryFirstOrDefaultAsync<Users>(sql);
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertUsersAsync(Users user)
        {
            string sql = $"INSERT INTO Users(Created, CreatedBy, Updated, UpdatedBy, UserName, [Password], FirstName, LastName, CompanyId, EmailAddress, LastLogin, AddressLine1, AddressLine2, AddressLine3, County, City, Postcode, Country, IsActive, IsSiteAdmin, IsSuperUser, RoleType) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @UserName, @Password, @FirstName, @LastName, @CompanyId, @EmailAddress, @LastLogin, @AddressLine1, @AddressLine2, @AddressLine3, @County, @City, @Postcode, @Country, @IsActive, @IsSiteAdmin, @IsSuperUser, @RoleType)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = user.Created, CreatedBy = user.CreatedBy, Updated = user.Updated, UpdatedBy = user.UpdatedBy, UserName = user.UserName, Password = user.Password, FirstName = user.FirstName, LastName = user.LastName, CompanyId = user.CompanyId, EmailAddress = user.EmailAddress, LastLogin = user.LastLogin, AddressLine1 = user.AddressLine1, AddressLine2 = user.AddressLine2, AddressLine3 = user.AddressLine3, County = user.County, City = user.City, Postcode = user.City, Country = user.Country, IsActive = user.IsActive, IsSiteAdmin = user.IsSiteAdmin, IsSuperUser = user.IsSuperUser, RoleType = user.RoleType });

        }

        public async Task<int> UpdateUsersAsync(Users user)
        {
            string sql = $"UPDATE Users SET Created = @Created, CreatedBy = @CreatedBy,Updated = @Updated, UpdatedBy = @UpdatedBy, UserName = @UserName, [Password] = @Password, FirstName = @FirstName, LastName = @LastName, CompanyId = @CompanyId, EmailAddress = @EmailAddress, LastLogin = @LastLogin, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressLine3 = @AddressLine3, County = @County, City = @City, Postcode = @Postcode, Country = @Country, IsActive = @IsActive, IsSiteAdmin = @IsSiteAdmin, IsSuperUser = @IsSuperUser, RoleType = @RoleType WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Created = user.Created, CreatedBy = user.CreatedBy, Updated = user.Updated, UpdatedBy = user.UpdatedBy, UserName = user.UserName, Password = user.Password, FirstName = user.FirstName, LastName = user.LastName, CompanyId = user.CompanyId, EmailAddress = user.EmailAddress, LastLogin = user.LastLogin, AddressLine1 = user.AddressLine1, AddressLine2 = user.AddressLine2, AddressLine3 = user.AddressLine3, County = user.County, City = user.City, Postcode = user.City, Country = user.Country, IsActive = user.IsActive, IsSiteAdmin = user.IsSiteAdmin, IsSuperUser = user.IsSuperUser, RoleType = user.RoleType, Id = user.Id });
        }

        public async Task<int> ActiveUsersAsync(Guid id, bool isActive, Guid updatedBy)
        {
            string sql = $"UPDATE Users SET IsActive = @IsActive, Updated = @Updated, UpdatedBy = @UpdatedBy WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id, IsActive = isActive, Updated = DateTime.UtcNow, UpdatedBy = updatedBy });
        }

        public async Task<int> UpdateUsersRoleTypeAsync(Guid id , byte? roleType, Guid updatedBy)
        {
            string sql = $"UPDATE Users SET RoleType = @RoleType, Updated = @Updated, UpdatedBy = @UpdatedBy WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id, RoleType = roleType, Updated = DateTime.UtcNow, UpdatedBy = updatedBy });
        }

        public async Task<int> UpdateUsersPasswordAsync(Guid id , string password, Guid updatedBy)
        {
            string sql = $"UPDATE Users SET Password = @Password, Updated = @Updated, UpdatedBy = @UpdatedBy WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql,new { Id = id, Password = password, Updated = DateTime.UtcNow, UpdatedBy = updatedBy });
        }

        #endregion
    }
}
