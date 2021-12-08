using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IFindingRepository :IRepository<Finding>
    {
        IEnumerable<FindingAudit> GetFindingsTableData();
        FindingFormDTO GetFindingFormDTO(int? id);
        int AddOrUpdate(FindingFormDTO dto);
        Finding PerformMapping(FindingFormDTO dto);
    }
}