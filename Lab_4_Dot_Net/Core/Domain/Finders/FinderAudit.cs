using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Finders
{
    public class FinderAudit : BaseAudit
    {
        public int FinderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}