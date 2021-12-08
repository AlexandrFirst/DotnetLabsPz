using Lab_4_Dot_Net.Core;
using Lab_4_Dot_Net.Core.Domain.Statistics;
using Lab_4_Dot_Net.Core.Repositories;
using Lab_4_Dot_Net.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LostAndFoundContext _context;

        public UnitOfWork(LostAndFoundContext context)
        {
            this._context = context;
            Workers = new WorkerRepository(context);
            Roles = new RoleMasterRepository(context);
            RoleMappings = new WorkerRoleMappingRepository(context);
            Owners = new OwnerRepository(context);
            Findings = new FindingRepository(context);
            Finders = new FinderRepository(context);
            Obtainings = new ObtainingRepository(context);
            Extradictions = new ExtradictionRepository(context);
        }
        public IWorkerRepository Workers { get; set; }
        public IRoleMasterRepository Roles { get; set; }
        public IWorkerRoleMappingRepository RoleMappings { get; set; }
        public IOwnerRepository Owners { get; set; }
        public IFindingRepository Findings { get; set; }
        public IFinderRepository Finders { get; set; }
        public IObtainingRepository Obtainings { get; set; }
        public IExtradictionRepository Extradictions { get; set; }

        public int Complete() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();

        public int GetAllOperationsTotalCount() {
            DbRawSqlQuery<int> a = _context.Database.SqlQuery<int>("getNumberOfAllOperations");
            return 0;
        }

        public IEnumerable<Loser> GetLosersTop() => _context.Database.SqlQuery<Loser>("GetLosersTop");

        public IEnumerable<OperationPerWoker> GetNumberOfAllOperationsPerformedByWorkers() => 
            _context.Database.SqlQuery<OperationPerWoker>("number_Of_Obtainings_Extradictions_Per_Worker");
    }
}