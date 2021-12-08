using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.DTO
{
    public class TableDTO
    {
        public int WorkerId { get; set; }
        public int FindingId { get; set; }
        public string WorkerName { get; set; }
        public string FindingName { get; set; }
        public DateTime AddedOn { get; set; }
    }
}