using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.DTO
{
    public class FindingFormDTO
    {
        public int FindingId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [DisplayName("Name")]
        public string FindingName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}