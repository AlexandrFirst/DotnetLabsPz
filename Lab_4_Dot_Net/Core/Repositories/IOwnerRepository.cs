using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4_Dot_Net.Core.Domain.Owners;
using Lab_4_Dot_Net.Core.DTO;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IOwnerRepository : IRepository<Owner>
    {

        IEnumerable<OwnerAudit> GetOwnersTableData();
        OwnerFormDTO GetOwnerFormDTO(int? id);
        int AddOrUpdate(OwnerFormDTO dto);
        Owner PerformMapping(OwnerFormDTO dto);
    }
}
