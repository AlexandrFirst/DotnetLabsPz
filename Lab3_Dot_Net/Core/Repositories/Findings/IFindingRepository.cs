using Lab3_Dot_Net.Core.Domain.Findings;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dot_Net.Core.Repositories.Findings
{
    public interface IFindingRepository : IRepository<Finding>
    {
        IEnumerable<FindingAudit> GetFindingsTableData();
        FindingFormDTO GetFindingFormDTO(int? id);
        int AddOrUpdate(FindingFormDTO dto);
        Finding PerformMapping(FindingFormDTO dto);

    }
}
