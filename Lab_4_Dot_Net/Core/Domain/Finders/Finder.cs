using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Finders
{
    public class Finder : BaseEntity
    {
        public int FinderId { get; set; }
        public ICollection<Obtaining> Obtainings { get; set; }
    }
}