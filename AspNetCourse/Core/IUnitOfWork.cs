using AspNetCourse.Core.Repositories;
using AspNetCourse.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCourse.Core
{
    public interface IUnitOfWork
    {
        IFinderRepository Finders { get; set; }
        IFindingRepository Findings { get; set; }
        IObtainingRepository Obtainings { get; set; }
        IOwnerRepository Owners { get; set; }
        IWorkerRepository Workers { get; set; }
    }
}
