using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain
{
    public class BaseAudit
    {
        [Key]
        public int ChangeId { get; set; }
        public DateTime Made_At { get; set; }
        public string Operation { get; set; }
    }
}