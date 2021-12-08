using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Findings
{
    public class Finding
    {
        public int FindingId { get; set; }
        public string FindingName { get; set; }
        public string Description { get; set; }
        public ICollection<Extradiction> Extradictions { get; set; }
        public ICollection<Obtaining> Obtainings { get; set; }
    }
}