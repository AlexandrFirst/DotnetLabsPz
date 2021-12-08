using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Extradictions
{
    [Table("ExtradictionsAudits")]
    public class ExtradictionAudit : BaseAudit
    {
        public int WorkerId { get; set; }
        public int OwnerId { get; set; }
        public int FindingId { get; set; }
    }
}