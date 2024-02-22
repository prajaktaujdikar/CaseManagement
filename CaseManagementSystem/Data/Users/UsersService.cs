using CMS.DL.DM;

namespace CaseManagementSystem.Data.Users
{
    public class UsersService
    {
        private readonly string _connectionString = "";

        public UsersService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<UsersViewModel>> GetAllUsersAsync()
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            IEnumerable<CMS.DL.Model.Users> users = await usersDM.GetAllUsersAsync();

            return users.Select(u => new UsersViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                CompanyId = u.CompanyId,
                CompanyName = u.CompanyName,
                EmailAddress = u.EmailAddress,
                LastLogin = u.LastLogin,
                AddressLine1 = u.AddressLine1,
                AddressLine2 = u.AddressLine2,
                AddressLine3 = u.AddressLine3,
                County = u.County,
                City = u.City,
                Postcode = u.Postcode,
                Country = u.Country,
                IsActive = u.IsActive,
                IsSiteAdmin = u.IsSiteAdmin,
                IsSuperUser = u.IsSuperUser,
                RoleType = u.RoleType,
                Created = u.Created,
                CreatedBy = u.CreatedBy,
                Updated = u.Updated,
                UpdatedBy = u.UpdatedBy
            });
        }

        public async Task<IEnumerable<UsersViewModel>> GetAllUsersByClientAsync(Guid? clientId)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            IEnumerable<CMS.DL.Model.Users> users = await usersDM.GetAllUsersByClientAsync(clientId);

            return users.Select(u => new UsersViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                CompanyId = u.CompanyId,
                CompanyName = u.CompanyName,
                EmailAddress = u.EmailAddress,
                LastLogin = u.LastLogin,
                AddressLine1 = u.AddressLine1,
                AddressLine2 = u.AddressLine2,
                AddressLine3 = u.AddressLine3,
                County = u.County,
                City = u.City,
                Postcode = u.Postcode,
                Country = u.Country,
                IsActive = u.IsActive,
                IsSiteAdmin = u.IsSiteAdmin,
                IsSuperUser = u.IsSuperUser,
                RoleType = u.RoleType,
                Created = u.Created,
                CreatedBy = u.CreatedBy,
                Updated = u.Updated,
                UpdatedBy = u.UpdatedBy
            });
        }

        public async Task<IEnumerable<UsersViewModel>> GetAllAgentsAsync()
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            IEnumerable<CMS.DL.Model.Users> users = await usersDM.GetAllAgentsAsync();

            return users.Select(u => new UsersViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                CompanyId = u.CompanyId,
                CompanyName = u.CompanyName,
                EmailAddress = u.EmailAddress,
                LastLogin = u.LastLogin,
                AddressLine1 = u.AddressLine1,
                AddressLine2 = u.AddressLine2,
                AddressLine3 = u.AddressLine3,
                County = u.County,
                City = u.City,
                Postcode = u.Postcode,
                Country = u.Country,
                IsActive = u.IsActive,
                IsSiteAdmin = u.IsSiteAdmin,
                IsSuperUser = u.IsSuperUser,
                RoleType = u.RoleType,
                Created = u.Created,
                CreatedBy = u.CreatedBy,
                Updated = u.Updated,
                UpdatedBy = u.UpdatedBy
            });
        }

        public async Task<IEnumerable<UsersViewModel>> GetAllClientsAsync()
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            IEnumerable<CMS.DL.Model.Users> users = await usersDM.GetAllClientsAsync();

            return users.Select(u => new UsersViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                CompanyId = u.CompanyId,
                CompanyName = u.CompanyName,
                EmailAddress = u.EmailAddress,
                LastLogin = u.LastLogin,
                AddressLine1 = u.AddressLine1,
                AddressLine2 = u.AddressLine2,
                AddressLine3 = u.AddressLine3,
                County = u.County,
                City = u.City,
                Postcode = u.Postcode,
                Country = u.Country,
                IsActive = u.IsActive,
                IsSiteAdmin = u.IsSiteAdmin,
                IsSuperUser = u.IsSuperUser,
                RoleType = u.RoleType,
                Created = u.Created,
                CreatedBy = u.CreatedBy,
                Updated = u.Updated,
                UpdatedBy = u.UpdatedBy
            });
        }

        public async Task<UsersViewModel> GetUsersByIdAsync(Guid id)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            CMS.DL.Model.Users user = await usersDM.GetUsersByIdAsync(id);

            if (user != null)
            {
                return new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyId = user.CompanyId,
                    CompanyName = user.CompanyName,
                    EmailAddress = user.EmailAddress,
                    LastLogin = user.LastLogin,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    AddressLine3 = user.AddressLine3,
                    County = user.County,
                    City = user.City,
                    Postcode = user.Postcode,
                    Country = user.Country,
                    IsActive = user.IsActive,
                    IsSiteAdmin = user.IsSiteAdmin,
                    IsSuperUser = user.IsSuperUser,
                    RoleType = user.RoleType,
                    Created = user.Created,
                    CreatedBy = user.CreatedBy,
                    Updated = user.Updated,
                    UpdatedBy = user.UpdatedBy
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UsersViewModel> GetUsersByUserNameAsync(string userName, Guid? excludeId = null)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            CMS.DL.Model.Users user = await usersDM.GetUsersByUserNameAsync(userName, excludeId);

            if (user != null)
            {
                return new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyId = user.CompanyId,
                    CompanyName = user.CompanyName,
                    EmailAddress = user.EmailAddress,
                    LastLogin = user.LastLogin,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    AddressLine3 = user.AddressLine3,
                    County = user.County,
                    City = user.City,
                    Postcode = user.Postcode,
                    Country = user.Country,
                    IsActive = user.IsActive,
                    IsSiteAdmin = user.IsSiteAdmin,
                    IsSuperUser = user.IsSuperUser,
                    RoleType = user.RoleType,
                    Created = user.Created,
                    CreatedBy = user.CreatedBy,
                    Updated = user.Updated,
                    UpdatedBy = user.UpdatedBy
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UsersViewModel> GetUsersByEmailAddressAsync(string emailAddress, Guid? excludeId = null)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            CMS.DL.Model.Users user = await usersDM.GetUsersByEmailAddressAsync(emailAddress, excludeId);

            if (user != null)
            {
                return new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyId = user.CompanyId,
                    CompanyName = user.CompanyName,
                    EmailAddress = user.EmailAddress,
                    LastLogin = user.LastLogin,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    AddressLine3 = user.AddressLine3,
                    County = user.County,
                    City = user.City,
                    Postcode = user.Postcode,
                    Country = user.Country,
                    IsActive = user.IsActive,
                    IsSiteAdmin = user.IsSiteAdmin,
                    IsSuperUser = user.IsSuperUser,
                    RoleType = user.RoleType,
                    Created = user.Created,
                    CreatedBy = user.CreatedBy,
                    Updated = user.Updated,
                    UpdatedBy = user.UpdatedBy
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UsersViewModel> CheckLogin(string userName)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            CMS.DL.Model.Users user = await usersDM.CheckLogin(userName);

            if (user != null)
            {
                return new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyId = user.CompanyId,
                    CompanyName = user.CompanyName,
                    EmailAddress = user.EmailAddress,
                    LastLogin = user.LastLogin,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    AddressLine3 = user.AddressLine3,
                    County = user.County,
                    City = user.City,
                    Postcode = user.Postcode,
                    Country = user.Country,
                    IsActive = user.IsActive,
                    IsSiteAdmin = user.IsSiteAdmin,
                    IsSuperUser = user.IsSuperUser,
                    RoleType = user.RoleType,
                    Created = user.Created,
                    CreatedBy = user.CreatedBy,
                    Updated = user.Updated,
                    UpdatedBy = user.UpdatedBy
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UsersViewModel> GetLastUsersAsync()
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            CMS.DL.Model.Users user = await usersDM.GetLastUsersAsync();

            if (user != null)
            {
                return new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyId = user.CompanyId,
                    CompanyName = user.CompanyName,
                    EmailAddress = user.EmailAddress,
                    LastLogin = user.LastLogin,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    AddressLine3 = user.AddressLine3,
                    County = user.County,
                    City = user.City,
                    Postcode = user.Postcode,
                    Country = user.Country,
                    IsActive = user.IsActive,
                    IsSiteAdmin = user.IsSiteAdmin,
                    IsSuperUser = user.IsSuperUser,
                    RoleType = user.RoleType,
                    Created = user.Created,
                    CreatedBy = user.CreatedBy,
                    Updated = user.Updated,
                    UpdatedBy = user.UpdatedBy
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertUsersAsync(UsersViewModel usersView)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            int result = await usersDM.InsertUsersAsync(new CMS.DL.Model.Users
            {
                UserName = usersView.UserName,
                Password = usersView.Password,
                FirstName = usersView.FirstName,
                LastName = usersView.LastName,
                CompanyId = usersView.CompanyId,
                EmailAddress = usersView.EmailAddress,
                LastLogin = usersView.LastLogin,
                AddressLine1 = usersView.AddressLine1,
                AddressLine2 = usersView.AddressLine2,
                AddressLine3 = usersView.AddressLine3,
                County = usersView.County,
                City = usersView.City,
                Postcode = usersView.Postcode,
                Country = usersView.Country,
                IsActive = usersView.IsActive,
                IsSiteAdmin = usersView.IsSiteAdmin,
                IsSuperUser = usersView.IsSuperUser,
                RoleType = usersView.RoleType,
                Created = usersView.Created,
                CreatedBy = usersView.CreatedBy,
                Updated = usersView.Updated,
                UpdatedBy = usersView.UpdatedBy
            });

            return result;
        }

        public async Task<int> UpdateUsersAsync(UsersViewModel usersView)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            int result = await usersDM.UpdateUsersAsync(new CMS.DL.Model.Users
            {
                Id = usersView.Id,
                UserName = usersView.UserName,
                Password = usersView.Password,
                FirstName = usersView.FirstName,
                LastName = usersView.LastName,
                CompanyId = usersView.CompanyId,
                EmailAddress = usersView.EmailAddress,
                LastLogin = usersView.LastLogin,
                AddressLine1 = usersView.AddressLine1,
                AddressLine2 = usersView.AddressLine2,
                AddressLine3 = usersView.AddressLine3,
                County = usersView.County,
                City = usersView.City,
                Postcode = usersView.Postcode,
                Country = usersView.Country,
                IsActive = usersView.IsActive,
                IsSiteAdmin = usersView.IsSiteAdmin,
                IsSuperUser = usersView.IsSuperUser,
                RoleType = usersView.RoleType,
                Created = usersView.Created,
                CreatedBy = usersView.CreatedBy,
                Updated = usersView.Updated,
                UpdatedBy = usersView.UpdatedBy
            });

            return result;
        }

        public async Task<int> ActiveUsersAsync(Guid id, bool isActive, Guid updatedBy)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            int result = await usersDM.ActiveUsersAsync(id, isActive, updatedBy);

            return result;
        }

        public async Task<int> UpdateUsersRoleTypeAsync(Guid id, byte? roleType, Guid updatedBy)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            int result = await usersDM.UpdateUsersRoleTypeAsync(id, roleType, updatedBy);

            return result;
        }

        public async Task<int> UpdateUsersPasswordAsync(Guid id, string password, Guid updatedBy)
        {
            UsersDM usersDM = new UsersDM(_connectionString);
            int result = await usersDM.UpdateUsersPasswordAsync(id, password, updatedBy);

            return result;
        }

        #endregion
    }
}
