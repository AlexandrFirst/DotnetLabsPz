using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.RoleMasters
{
    [Table("RoleMastersAudits")]
    public class RoleMasterAudit : BaseAudit
    {
        public int RoleId { get; set; }
        public int RoleName { get; set; }
    }
}