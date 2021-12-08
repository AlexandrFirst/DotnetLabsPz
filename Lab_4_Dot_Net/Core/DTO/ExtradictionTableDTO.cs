using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.DTO
{
    public class ExtradictionTableDTO : TableDTO
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}