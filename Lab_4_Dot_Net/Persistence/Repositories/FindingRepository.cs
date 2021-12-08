using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.DTO;
using Lab_4_Dot_Net.Core.Repositories;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class FindingRepository : Repository<Finding>, IFindingRepository
    {
        public FindingRepository(LostAndFoundContext context)
          : base(context)
        {

        }

        public int AddOrUpdate(FindingFormDTO dto)
        {
            try
            {
                if (dto.FindingId == 0)
                    Entities.Add(PerformMapping(dto));
                else
                {
                    Finding finding = Entities.Find(dto.FindingId);
                    finding.FindingName = dto.FindingName;
                    finding.Description = dto.Description;
                }
                Context.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }

        public FindingFormDTO GetFindingFormDTO(int? id)
        {
            var finding = SingleOrDefault(f => f.FindingId == id);
            if (finding == null)
                return new FindingFormDTO() { FindingId = 0 };
            FindingFormDTO dto = new FindingFormDTO()
            {
                Description = finding.Description,
                FindingName = finding.FindingName,
                FindingId = finding.FindingId
            };
            return dto;
        }

        public IEnumerable<FindingAudit> GetFindingsTableData()
        {
            var findings = (from f in Entities
                            join fAudit in Context.Set<FindingAudit>()
                            on f.FindingId equals fAudit.FindingId
                            where fAudit.Operation == "INS"
                            select fAudit).AsEnumerable();
            return findings;
        }
        public Finding PerformMapping(FindingFormDTO dto)
        {
            Finding finding = new Finding()
            {
                FindingName = dto.FindingName,
                Description = dto.Description,
                FindingId = dto.FindingId
            };
            return finding;
        }
    }
}