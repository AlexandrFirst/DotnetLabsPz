using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Repositories
{
    public interface IFindingRepository : IRepository<Finding>
    {
        IEnumerable<Keyword> getAllKeywords(Finding finding);

    }
}
