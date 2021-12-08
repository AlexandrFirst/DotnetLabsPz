using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings
{
    public class WorkerRoleMappingAudit : BaseAudit
    {
        public int MappingId { get; set; }
        public int WorkerId { get; set; }
        public int RoleId { get; set; }
    }
}