using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Extradictions
{
    public class ExtradictionAudit : BaseAudit
    {
        public int WorkerId {get;set;}
        public int OwnerId { get; set; }
        public int FindingId{ get; set; }
    }
}