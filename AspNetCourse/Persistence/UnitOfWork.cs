using AspNetCourse.Core;
using AspNetCourse.Core.Repositories;
using AspNetCourse.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetCourse.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFinderRepository Finders { get; set; }
        public IFindingRepository Findings { get; set; }
        public IObtainingRepository Obtainings { get; set; }
        public IOwnerRepository Owners { get; set; }
        public IWorkerRepository Workers { get; set; }
        public UnitOfWork()
        {
           Finders = new FindersRepository();
            Workers = new WorkersRepository();
            Obtainings = new ObtainingsRepository();
            Owners = new OwnersRepository();
            Findings = new FindingsRepository();
        }
    }
}