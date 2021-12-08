using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.DTO
{
    public class ObtainingTableDTO : TableDTO
    {
        public int FinderId { get; set; }
        public string FinderName { get; set; }
    }
}