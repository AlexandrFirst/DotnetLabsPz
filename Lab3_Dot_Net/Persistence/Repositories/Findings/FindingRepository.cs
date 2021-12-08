using Lab3_Dot_Net.Core.Domain.Findings;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Core.Repositories.Findings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Persistence.Repositories.Findings
{
    public class FindingRepository : Repository<Finding>, IFindingRepository
    {
        public int AddOrUpdate(FindingFormDTO dto)
        {
            int result = 0;
            try
            {
                Finding finding = PerformMapping(dto);
                if (dto.FindingId == 0)
                    result = Add(finding);
                else
                    result = Update(finding);
                return result;
            }
            catch { return 0; }
        }

        public FindingFormDTO GetFindingFormDTO(int? id)
        {
            var finding = GetAll().Where(f => f.FindingId == id).FirstOrDefault();
            if (finding == null)
                return new FindingFormDTO() { FindingId = 0 };
            FindingFormDTO dto = new FindingFormDTO()
            {
                FindingId = finding.FindingId,
                FindingName = finding.FindingName,
                Description = finding.Description
            };
            return dto;
        }

        public IEnumerable<FindingAudit> GetFindingsTableData()
        {
            var findingAudits = new FindingAuditRepository();
            var findings = (from f in GetAll()
                            join fAudit in findingAudits.GetAll()
                            on f.FindingId equals fAudit.FindingId
                            where fAudit.Operation == "INS"
                            select fAudit).AsEnumerable();
            return findings;
        }

        public Finding PerformMapping(FindingFormDTO dto)
        {
            Finding finding = new Finding()
            {
                FindingId = dto.FindingId,
                FindingName = dto.FindingName,
                Description = dto.Description
            };
            return finding;
        }
    }
}