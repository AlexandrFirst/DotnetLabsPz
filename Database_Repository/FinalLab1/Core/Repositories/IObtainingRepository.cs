using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Core.Repositories
{
    public interface IObtainingRepository : IRepository<Obtaining>
    {
        IEnumerable<Obtaining> getObtainingsByDate(string year = null, string month = null, string day = null);
    }
}
