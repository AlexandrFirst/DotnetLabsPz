using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Domain
{
    public class Finding
    {
        [Key]
        public int FindingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
