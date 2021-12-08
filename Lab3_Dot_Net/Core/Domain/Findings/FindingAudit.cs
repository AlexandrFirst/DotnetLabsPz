using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Findings
{
    [Table("FindingsAudits")]
    public class FindingAudit : BaseAudit
    {
        public int FindingId { get; set; }
        public string FindingName { get; set; }
        public string Description { get; set; }
    }
}