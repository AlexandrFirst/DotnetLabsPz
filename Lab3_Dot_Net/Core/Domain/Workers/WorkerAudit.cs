using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Workers
{
    [Table("WorkersAudits")]
    public class WorkerAudit : BaseAudit
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}