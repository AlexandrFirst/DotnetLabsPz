using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Repositories;
using Lab_4_Dot_Net.Core.Domain.Finders;
using Lab_4_Dot_Net.Core.DTO;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class FinderRepository : Repository<Finder>, IFinderRepository
    {
        public FinderRepository(LostAndFoundContext context)
           : base(context)
        {

        }

        public int AddOrUpdate(FinderFormDTO dto)
        {
            try
            {
                if (dto.FinderId == 0)
                    Entities.Add(PerformMapping(dto));
                else
                {
                    Finder finder = Entities.Find(dto.FinderId);
                    finder.Name = dto.Name;
                    finder.Surname = dto.Surname;
                    finder.Birthday = dto.Birthday;
                }
                Context.SaveChanges();
                return 1;
            } catch { return 0; }
        }

        public FinderFormDTO GetFinderFormDTO(int? id)
        {
            var finder = SingleOrDefault(f => f.FinderId == id);
            if (finder == null)
                return new FinderFormDTO() { FinderId = 0 };
            FinderFormDTO dto = new FinderFormDTO()
            {
                Name = finder.Name,
                Surname = finder.Surname,
                Birthday = finder.Birthday,
                FinderId = finder.FinderId
            };
            return dto;
        }

        public IEnumerable<FinderAudit> GetFindersTableData()
        {
            var finders = (from f in Entities
                           join fAudit in Context.Set<FinderAudit>()
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