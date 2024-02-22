namespace CaseManagementSystem.Data.Companies
{
    public class CompaniesViewModel
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string CompanyName { get; set; }
        public string? KeyContact { get; set; }
        public string? KeyContactRole { get; set; }
        public string? Email { get; set; }
        public string? InvoiceEmail { get; set; }
        public byte? CompanyType { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
        public string? Country { get; set; }
    }
}
