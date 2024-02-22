using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DL.Model
{
    public class Cases
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? IndividualId { get; set; }
        public string CaseNumber { get; set; }
        public Guid? TraceLevelId { get; set; }
        public decimal? Fee { get; set; }
        public decimal? DebtAmount { get; set; }
        public Guid? ClientRef { get; set; }
        public Guid? EndClient { get; set; }
        public Guid? TraceReasonId { get; set; }
        public string? Notes { get; set; }
        public byte Status { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? CaseLinkId { get; set; }
        public string CompanyName { get; set; }
        public string TraceLevelName { get; set; }
        public string TraceReasonName { get; set; }
        public string SubjectName { get; set; }
        public string ClientName { get; set; }
        public string AgentName { get; set; }
    }
}
