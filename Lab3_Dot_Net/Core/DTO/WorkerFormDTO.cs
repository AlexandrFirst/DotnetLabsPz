using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.DTO
{
    public class WorkerFormDTO
    {
        public int WorkerId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Surname { get; set; }
        [MaxLength(11)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public string Birthday { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(8)]
        public string Login { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(8)]
        public string Password { get; set; }
        [DisplayName("Is admin:")]
        public bool isAdmin { get; set; }
    }
}