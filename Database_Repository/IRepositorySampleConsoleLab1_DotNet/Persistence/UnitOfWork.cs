using IRepositorySampleConsoleLab1_DotNet.Core;
using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Core.Repositories;
using IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext context;

        public UnitOfWork(RepositoryContext context)
        {
            this.context = context;
            Obtainings = new ObtainingRepository(context, "Obtainings");
            Finders = new FindersRepository(context, "Finders");
            Findings = new FindingsRepository(context, "Findings");
            Extradictions = new ExtradictionRepository(context, "Extradictions");
            Owners = new OwnersRepository(context, "Owners");
            Workers = new WorkersRepository(context, "Workers");
            Keywords = new KeywordsRepository(context, "Keywords");
        }

        public IExtradictionRepository Extradictions { get; private set; }
        public IFinderRepository Finders { get; private set; }
        public IFindingRepository Findings { get; private set; }
        public IObtainingRepository Obtainings { get; private set; }
        public IOwnerRepository Owners { get; private set; }
        public IWorkerRepository Workers { get; private set; }

        public IKeywordRepository Keywords { get; private set; }

        public void Dispose() => context.Dispose();
    }
}
