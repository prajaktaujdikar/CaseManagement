using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DL.Model
{
    public class CaseProfiles
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string? CaseDescription { get; set; }
        public Guid? TimeLimitId { get; set; }
        public string TimeLimitName { get; set; }
        public Guid? CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public Guid? AgencyTypeId { get; set; }
       
 
    }
}