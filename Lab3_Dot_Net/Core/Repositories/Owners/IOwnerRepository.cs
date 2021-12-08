using Lab3_Dot_Net.Core.Domain.Owners;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dot_Net.Core.Repositories.Owners
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        IEnumerable<OwnerAudit> GetOwnersTableData();
        OwnerFormDTO GetOwnerFormDTO(int? id);
        int AddOrUpdate(OwnerFormDTO dto);
        Owner PerformMapping(OwnerFormDTO dto);
    }
}
