using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.Workers
{
    public class WorkerAudit : BaseAudit
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}