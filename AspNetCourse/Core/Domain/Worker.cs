using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetCourse.Core.Domain
{
    [Table("Workers")]
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}