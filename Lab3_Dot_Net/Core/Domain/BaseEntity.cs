using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain
{
    public class BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}