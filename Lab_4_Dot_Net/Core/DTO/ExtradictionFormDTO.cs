using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.DTO
{
    public class ExtradictionFormDTO
    {
        [Required]
        [DisplayName("Owner name")]
        public string OwnerName { get; set; }
        [Required]
        [DisplayName("Finding name")]
        public string FindingName { get; set; }
        public IEnumerable<string> FindingsNames { get; set; }
        public IEnumerable<string> OwnersNames { get; set; }
    }
}