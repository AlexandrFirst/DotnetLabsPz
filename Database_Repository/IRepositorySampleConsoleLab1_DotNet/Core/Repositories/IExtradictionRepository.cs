using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Repositories
{
    public interface IExtradictionRepository : IRepository<Extradiction>
    {
        IEnumerable<Extradiction> getExtradictionsByDate(string year = null, string month = null, string day = null);
    }
}
