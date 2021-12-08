using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Owners
{
    public class Owner : BaseEntity
    {
        public int OwnerId { get; set; }
        public ICollection<Extradiction> Extradictions { get; set; }
    }
}