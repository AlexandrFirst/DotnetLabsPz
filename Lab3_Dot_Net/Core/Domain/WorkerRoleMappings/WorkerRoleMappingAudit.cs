using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_Dot_Net.Core.Domain.WorkerRoleMappings
{
    [Table("WorkerRoleMappingsAudits")]
    public class WorkerRoleMappingAudit : BaseAudit
    {
        public int MappingId { get; set; }
        public int WorkerId { get; set; }
        public int RoleId { get; set; }
    }
}