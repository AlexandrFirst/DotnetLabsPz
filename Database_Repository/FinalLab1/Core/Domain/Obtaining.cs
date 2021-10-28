using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Domain
{
    public class Obtaining
    {
        [Key]
        public int FindingId { get; set; }
        [Key]
        public int FinderId { get; set; }
        [Key]
        public int WorkerId { get; set; }
        public string ActTime { get; set; }
    }
}
