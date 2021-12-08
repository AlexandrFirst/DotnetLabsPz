using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Findings
{
    [Table("Findings")]
    public class Finding
    {
        [Key]
        public int FindingId { get; set; }
        public string FindingName { get; set; }
        public string Description { get; set; }
    }
}