using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain
{
    public class BaseAudit
    {
        public int ChangeId { get; set; }
        public DateTime MadeAt { get; set; }
        public string Operation { get; set; }
    }
}