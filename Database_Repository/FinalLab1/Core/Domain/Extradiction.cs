using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Domain
{
    public class Extradiction
    {
        [Key]
        public int FindingId { get; set; }
        [Key]
        public int OwnerId { get; set; }
        [Key]
        public int WorkerId { get; set; }
        [Key]
        public string ActTime { get; set; }
    }
}
