using Lab3_Dot_Net.Core.Domain.Owners;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Core.Repositories.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Persistence.Repositories.Owners
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public int AddOrUpdate(OwnerFormDTO dto)
        {
            int result = 0;
            try
            {
                Owner owner = PerformMapping(dto);
                if (dto.OwnerId == 0)
                    result = Add(owner);
                else
                    result = Update(owner);
                return result;
            }
            catch { return 0; }
        }
        public OwnerFormDTO GetOwnerFormDTO(int? id)
        {
            var owner = GetAll().Where(o => o.OwnerId == id).FirstOrDefault();
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
            var ownerAudits = new OwnerAuditRepository();
            var owners = (from o in GetAll()
                          join oAudit in ownerAudits.GetAll()
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