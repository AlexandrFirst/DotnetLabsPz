using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.DTO
{
    public class OwnerFormDTO
    {
        public int OwnerId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Surname { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Birthday { get; set; }
    }
}