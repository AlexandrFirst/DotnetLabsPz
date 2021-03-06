using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.DTO
{
    public class ObtainingFormDTO
    {
        [Required]
        [DisplayName("Finder name")]
        public string FinderName { get; set; }
        [Required]
        [DisplayName("Finding name")]
        public string FindingName { get; set; }
        public IEnumerable<string> FindingsNames { get; set; }
        public IEnumerable<string> FindersNames { get; set; }
    }
}