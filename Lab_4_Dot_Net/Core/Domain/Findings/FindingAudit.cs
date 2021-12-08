using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Findings
{
    public class FindingAudit : BaseAudit
    {
        public int FindingId { get; set; }
        public string FindingName { get; set; }
        public string Description { get; set; }
    }
}