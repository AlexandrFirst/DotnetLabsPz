using Lab3_Dot_Net.Core.Domain.Finders;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dot_Net.Core.Repositories.Finders
{
    public interface IFinderRepository : IRepository<Finder>
    {
        IEnumerable<FinderAudit> GetFindersTableData();
        FinderFormDTO GetFinderFormDTO(int? id);
        int AddOrUpdate(FinderFormDTO dto);
        Finder PerformMapping(FinderFormDTO dto);
    }
}
