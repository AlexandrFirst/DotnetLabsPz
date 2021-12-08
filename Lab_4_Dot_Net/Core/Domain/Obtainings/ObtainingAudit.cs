using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Obtainings
{
    public class ObtainingAudit : BaseAudit
    {
        public int WorkerId { get; set; }
        public int FinderId { get; set; }
        public int FindingId { get; set; }
    }
}