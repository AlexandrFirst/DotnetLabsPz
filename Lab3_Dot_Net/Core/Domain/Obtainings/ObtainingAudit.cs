using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Obtainings
{
    [Table("ObtainingsAudits")]
    public class ObtainingAudit : BaseAudit
    {
        public int WorkerId { get; set; }
        public int FinderId { get; set; }
        public int FindingId { get; set; }
    }
}