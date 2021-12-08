using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4_Dot_Net.Core.Domain.Finders;
using Lab_4_Dot_Net.Core.DTO;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IFinderRepository : IRepository<Finder>
    {
        IEnumerable<FinderAudit> GetFindersTableData();
        FinderFormDTO GetFinderFormDTO(int? id);
        int AddOrUpdate(FinderFormDTO dto);
        Finder PerformMapping(FinderFormDTO dto);
    }
}
