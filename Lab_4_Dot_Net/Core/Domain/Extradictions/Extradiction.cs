using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Workers;
using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.Domain.Owners;


namespace Lab_4_Dot_Net.Core.Domain.Extradictions
{
    public class Extradiction
    {
        public int WorkerId { get; set; }
        public int OwnerId { get; set; }
        public int FindingId { get; set; }
        public Owner Owner { get; set; }
        public Finding Finding { get; set; }
        public Worker Worker { get; set; }
    }
}