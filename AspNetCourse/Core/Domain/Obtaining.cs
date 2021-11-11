using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetCourse.Core.Domain
{

    [Table("Obtainings")]
    public class Obtaining
    {
        [Key]
        public int FindingId { get; set; }
        [Key]
        public int FinderId { get; set; }
        [Key]
        public int WorkerId { get; set; }
    }
}