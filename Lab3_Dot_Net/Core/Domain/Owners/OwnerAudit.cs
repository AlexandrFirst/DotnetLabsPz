using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Owners
{
    [Table("OwnersAudits")]
    public class OwnerAudit : BaseAudit
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}