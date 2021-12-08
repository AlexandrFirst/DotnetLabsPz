using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;

namespace Lab_4_Dot_Net.Core.Domain.RoleMasters
{
    public class RoleMaster
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<WorkerRoleMapping> Mappings { get; set; }
    }
}