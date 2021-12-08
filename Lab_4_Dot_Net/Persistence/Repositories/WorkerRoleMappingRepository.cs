using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;
using Lab_4_Dot_Net.Core.Repositories;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class WorkerRoleMappingRepository : Repository<WorkerRoleMapping>, IWorkerRoleMappingRepository
    {
        public WorkerRoleMappingRepository(LostAndFoundContext context) : base(context) { }
    }
}