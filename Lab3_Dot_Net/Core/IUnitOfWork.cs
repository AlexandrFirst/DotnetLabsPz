using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3_Dot_Net.Core.Repositories;
using Lab3_Dot_Net.Core.Repositories.Findings;
using Lab3_Dot_Net.Core.Repositories.RoleMasters;
using Lab3_Dot_Net.Core.Repositories.WorkerRoleMappings;
using Lab3_Dot_Net.Core.Repositories.Workers;
using Lab3_Dot_Net.Core.Repositories.Finders;
using Lab3_Dot_Net.Core.Repositories.Owners;
using Lab3_Dot_Net.Core.Repositories.Obtainings;
using Lab3_Dot_Net.Core.Repositories.Extradictions;


namespace Lab3_Dot_Net.Core
{
    public interface IUnitOfWork
    {
        IWorkerRepository Workers { get; set; }
        IRoleMasterRepository Roles { get; set; }
        IWorkerRoleMappingRepository RoleMappings { get; set; }
        IWorkerAuditRepository WorkersAudits { get; set; }
        IFindingRepository Findings { get; set; }
        IFindingAuditRepository FindingAudits { get; set; }
        IFinderRepository Finders { get; set; }
        IFinderAuditRepository FindersAudits { get; set; }
        IOwnerRepository Owners { get; set; }
        IOwnerAuditRepository OwnersAudits { get; set; }
        IObtainingRepository Obtainings { get; set; }
        IObtainingAuditRepository ObtainingsAudits { get; set; }
        IExtradictionRepository Extradictions { get; set; }
        IExtradicitonAuditRepository ExtradicitonsAudits { get; set; }
    }
}
