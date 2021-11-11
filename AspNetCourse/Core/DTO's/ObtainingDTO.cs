using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetCourse.Core.Domain;

namespace AspNetCourse.Core.DTO_s
{
    public class ObtainingDTO
    {
        public string Finder { get; set; }
        public string Finding { get; set; }
        public string Worker { get; set; }
        public int WorkerId { get; set; }
        public int FinderId { get; set; }
        public int FindingId { get; set; }
    }
}  