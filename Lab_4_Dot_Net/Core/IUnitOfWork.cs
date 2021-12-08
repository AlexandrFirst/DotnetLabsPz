using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Repositories;
using Lab_4_Dot_Net.Core.Domain.Statistics;

namespace Lab_4_Dot_Net.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkerRepository Workers { get; set; }
        IRoleMasterRepository Roles { get; set; }
        IWorkerRoleMappingRepository RoleMappings { get; set; }
        IOwnerRepository Owners { get; set; }
        IFinderRepository Finders { get; set; }
        IFindingRepository Findings { get; set; }
        IObtainingRepository Obtainings { get; set; }
        IExtradictionRepository Extradictions { get; set; }
        IEnumerable<Loser> GetLosersTop();
        IEnumerable<OperationPerWoker> GetNumberOfAllOperationsPerformedByWorkers();
        int GetAllOperationsTotalCount();
        int Complete();
    }
}