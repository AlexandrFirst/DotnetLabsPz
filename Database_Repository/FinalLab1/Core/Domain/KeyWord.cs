using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Domain
{
    public class Keyword
    {
        [Key]
        public int KeywordId { get; set; }
        public string Word { get; set; }
    }
}
