using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.RoleMasters
{
    public class RoleMasterAudit : BaseAudit
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}