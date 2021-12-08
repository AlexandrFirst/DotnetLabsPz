using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.Workers
{
    [Table("Workers")]
    public class Worker : BaseEntity
    {
        [Key]
        public int WorkerId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}