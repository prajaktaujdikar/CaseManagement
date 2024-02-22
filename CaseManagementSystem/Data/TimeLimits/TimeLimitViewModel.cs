﻿namespace CaseManagementSystem.Data.TimeLimits
{
    public class TimeLimitViewModel
    {

        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string? Name { get; set; }
    }
}