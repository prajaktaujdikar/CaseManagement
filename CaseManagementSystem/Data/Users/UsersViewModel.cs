using CaseManagementSystem.Data.Enum;

namespace CaseManagementSystem.Data.Users
{
    public class UsersViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
        public string? Country { get; set; }
        public bool IsActive { get; set; }
        public bool IsSiteAdmin { get; set; }
        public bool IsSuperUser { get; set; }
        public byte? RoleType { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }

        public string GetActiveValue() {
            return (IsActive ? "Yes" : "No");
        }

        public string GetSiteAdminValue()
        {
            return (IsSiteAdmin ? "Yes" : "No");
        }

        public string GetSuperUserValue()
        {
            return (IsSuperUser ? "Yes" : "No");
        }

        public string GetRoleTypeName()
        {
            try
            {
                RoleType roleType = (RoleType)RoleType;
                return roleType.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetFullName()
        {
            try
            {
                return FirstName + " " + LastName;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
