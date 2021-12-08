using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Owners;
using Lab_4_Dot_Net.Core.DTO;
using Lab_4_Dot_Net.Core.Repositories;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class OwnerRepository :  Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(LostAndFoundContext context)
           : base(context)
        {

        }

        public int AddOrUpdate(OwnerFormDTO dto)
        {
            try
            {
                if (dto.OwnerId == 0)
                    Entities.Add(PerformMapping(dto));
                else
                {
                    Owner owner = Entities.Find(dto.OwnerId);
                    owner.Name = dto.Name;
                    owner.Surname = dto.Surname;
                    owner.Birthday = dto.Birthday;
                }
                Context.SaveChanges();
                return 1;
            } catch { return 0; }
        }

        public OwnerFormDTO GetOwnerFormDTO(int? id)
        {
            var owner = SingleOrDefault(o => o.OwnerId == id);
            if (owner == null)
                return new OwnerFormDTO() { OwnerId = 0 };
            OwnerFormDTO dto = new OwnerFormDTO()
            {
                OwnerId = owner.OwnerId,
                Name = owner.Name,
                Surname = owner.Surname,
                Birthday = owner.Birthday
            };
            return dto;
        }

        public IEnumerable<OwnerAudit> GetOwnersTableData()
        {
            var owners = (from o in Entities
                          join oAudit in Context.Set<OwnerAudit>()
                          on o.OwnerId equals oAudit.OwnerId
                          where oAudit.Operation == "INS"
                          select oAudit).AsEnumerable();
            return owners;
        }

        public Owner PerformMapping(OwnerFormDTO dto)
        {
            Owner owner = new Owner()
            {
                OwnerId = dto.OwnerId,
                Name = dto.Name,
                Surname = dto.Surname,
                Birthday = dto.Birthday
            };
            return owner;
        }
    }
}