using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Domain.WorkerRoleMappings
{
    [Table("WorkerRoleMappings")]
    public class WorkerRoleMapping
    {
        [Key]
        public int MappingId { get; set; }
        public int WorkerId { get; set; }
        public int RoleId { get; set; }
    }
}