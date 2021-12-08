using Lab3_Dot_Net.Core;
using Lab3_Dot_Net.Core.Repositories.Extradictions;
using Lab3_Dot_Net.Core.Repositories.Finders;
using Lab3_Dot_Net.Core.Repositories.Findings;
using Lab3_Dot_Net.Core.Repositories.Obtainings;
using Lab3_Dot_Net.Core.Repositories.Owners;
using Lab3_Dot_Net.Core.Repositories.RoleMasters;
using Lab3_Dot_Net.Core.Repositories.WorkerRoleMappings;
using Lab3_Dot_Net.Core.Repositories.Workers;
using Lab3_Dot_Net.Persistence.Repositories.Extradictions;
using Lab3_Dot_Net.Persistence.Repositories.Finders;
using Lab3_Dot_Net.Persistence.Repositories.Findings;
using Lab3_Dot_Net.Persistence.Repositories.Obtainings;
using Lab3_Dot_Net.Persistence.Repositories.Owners;
using Lab3_Dot_Net.Persistence.Repositories.RoleMasters;
using Lab3_Dot_Net.Persistence.Repositories.WorkerRoleMappings;
using Lab3_Dot_Net.Persistence.Repositories.Workers;

namespace Lab3_Dot_Net.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IWorkerRepository Workers { get; set; }
        public IRoleMasterRepository Roles { get; set; }
        public IWorkerRoleMappingRepository RoleMappings { get; set; }
        public IWorkerAuditRepository WorkersAudits { get; set; }
        public IFindingRepository Findings { get; set; }
        public IFindingAuditRepository FindingAudits { get; set; }
        public IFinderRepository Finders { get; set; }
        public IFinderAuditRepository FindersAudits { get; set; }
        public IOwnerRepository Owners { get; set; }
        public IOwnerAuditRepository OwnersAudits { get; set; }
        public IObtainingRepository Obtainings { get; set; }
        public IObtainingAuditRepository ObtainingsAudits { get; set; }
        public IExtradictionRepository Extradictions { get; set; }
        public IExtradicitonAuditRepository ExtradicitonsAudits { get; set; }

        public UnitOfWork()
        {
            Workers = new WorkerRepository();
            WorkersAudits = new WorkerAuditRepository();
            Roles = new RoleMasterRepository();
            RoleMappings = new WorkerRoleMappingRepository();
            Findings = new FindingRepository();
            FindingAudits = new FindingAuditRepository();
            Finders = new FinderRepository();
            FindersAudits = new FinderAuditRepository();
            Owners = new OwnerRepository();
            OwnersAudits = new OwnerAuditRepository();
            Obtainings = new ObtainingRepository();
            ObtainingsAudits = new ObtainingAuditRepository();
            Extradictions = new ExtradictionRepository();
            ExtradicitonsAudits = new ExtradictionAuditRepository();
        }
    }
}