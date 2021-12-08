using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;
using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.Domain.Obtainings;


namespace Lab_4_Dot_Net.Core.Domain.Workers
{
    public class Worker : BaseEntity
    {
        public int WorkerId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<WorkerRoleMapping> Mappings { get; set; }
        public ICollection<Extradiction> Extradictions { get; set; }
        public ICollection<Obtaining> Obtainings { get; set; }
    }
}