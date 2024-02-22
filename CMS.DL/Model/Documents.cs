using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DL.Model
{
    public class Documents
    {
        public Guid Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string? FileName { get; set; }
        public byte[]? Data { get; set; }
        public string? DataContentType { get; set; }
        public long? Size { get; set; }
        public Guid? CaseId { get; set; }
    }
}
