using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetCourse.Core.DTO_s;
using AspNetCourse.Core.Domain;

namespace AspNetCourse.ViewModels
{
    public class ObtainingViewModel
    {
        public ObtainingDTO Obtaining { get; set; }
        public IEnumerable<string> Workers { get; set; }
        public IEnumerable<string> Finders { get; set; }
        public IEnumerable<string> Findings { get; set; }
    }
}