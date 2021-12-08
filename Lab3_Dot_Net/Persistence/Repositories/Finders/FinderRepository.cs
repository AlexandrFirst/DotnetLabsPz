using Lab3_Dot_Net.Core.Domain.Finders;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Core.Repositories.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Persistence.Repositories.Finders
{
    public class FinderRepository : Repository<Finder>, IFinderRepository
    {
        public int AddOrUpdate(FinderFormDTO dto)
        {
            int result = 0;
            try
            {
                Finder finder = PerformMapping(dto);
                if (dto.FinderId == 0)
                    result = Add(finder);
                else
                    result = Update(finder);
                return result;
            }
            catch { return 0; }
        }
        public FinderFormDTO GetFinderFormDTO(int? id)
        {
            var finder = GetAll().Where(f => f.FinderId == id).FirstOrDefault();
            if (finder == null)
                return new FinderFormDTO() { FinderId = 0 };
            FinderFormDTO dto = new FinderFormDTO()
            {
                FinderId = finder.FinderId,
                Name = finder.Name,
                Surname = finder.Surname,
                Birthday = finder.Birthday
            };
            return dto;
        }

        public IEnumerable<FinderAudit> GetFindersTableData()
        {
            var findersAudits = new FinderAuditRepository();
            var finders = (from f in GetAll()
                           join fAudit in findersAudits.GetAll()
                           on f.FinderId equals fAudit.FinderId
                           where fAudit.Operation == "INS"
                           select fAudit).AsEnumerable();
            return finders;
        }

        public Finder PerformMapping(FinderFormDTO dto)
        {
            Finder finder = new Finder()
            {
                FinderId = dto.FinderId,
                Name = dto.Name,
                Surname = dto.Surname,
                Birthday = dto.Birthday
            };
            return finder;
        }
    }
}