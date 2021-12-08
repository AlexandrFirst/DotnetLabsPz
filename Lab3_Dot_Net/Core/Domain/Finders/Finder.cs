using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Finders
{
    [Table("Finders")]
    public class Finder : BaseEntity
    {
        [Key]
        public int FinderId { get; set; }
    }
}