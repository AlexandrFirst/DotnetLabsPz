using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetCourse.Core.Domain
{
    [Table("Findings")]
    public class Finding
    {
        [Key]
        public int FindingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}