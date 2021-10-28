using IRepositorySampleConsoleLab1_DotNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IExtradictionRepository Extradictions { get; }
        IFinderRepository Finders { get; }
        IFindingRepository Findings { get; }
        IObtainingRepository Obtainings { get; }
        IOwnerRepository Owners { get; }
        IWorkerRepository Workers { get; }
        IKeywordRepository Keywords { get; }
    }
}
