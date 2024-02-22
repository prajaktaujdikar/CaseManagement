namespace CaseManagementSystem.Data.Subjects
{
    public class SubjectViewModel
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Alias { get; set; }
        public Guid? AssociatedCompany { get; set; }
        public string? Notes { get; set; }
        public string Email { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }
        public string? Country { get; set; }
        public Guid? TitlePrefixId { get; set; }
        public string TitlePrfixName { get; set; }
        public string SubjectName { get; set; }
        public string ClientName { get; set; }
        public string AgentName { get; set; }
        public string CaseNumber { get; set; }
        public Guid? ClientRef { get; set; }
        public Guid? EndClient { get; set; }
        public string CompanyName { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CaseId { get; set; }
        public DateTime? CaseCreated { get; set; }
        public string CaseNotes { get; set; }
    }
}
