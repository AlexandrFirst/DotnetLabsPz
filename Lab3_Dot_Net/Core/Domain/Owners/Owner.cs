using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Owners
{
    [Table("Owners")]
    public class Owner : BaseEntity
    {
        [Key]
        public int OwnerId { get; set; }
    }
}