namespace CaseManagementSystem.Data.AgencyTypes
{
    public class AgencyTypeViewModel
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string Name { get; set; }
    }
}
