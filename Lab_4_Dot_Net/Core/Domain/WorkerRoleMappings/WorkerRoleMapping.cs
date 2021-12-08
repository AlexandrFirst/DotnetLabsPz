using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.RoleMasters;
using Lab_4_Dot_Net.Core.Domain.Workers;

namespace Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings
{
    public class WorkerRoleMapping 
    {
        public int MappingId { get; set; }
        public int WorkerId { get; set; }
        public int RoleId { get; set; }
        public RoleMaster Role { get; set; }
        public Worker Worker { get; set; }
    }
}