using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Finders;
using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.Domain.Workers;


namespace Lab_4_Dot_Net.Core.Domain.Obtainings
{
    public class Obtaining
    {
        public int WorkerId { get; set; }
        public int FinderId { get; set; }
        public int FindingId { get; set; }
        public Finder Finder { get; set; }
        public Finding Finding { get; set; }
        public Worker Worker { get; set; }
    }
}