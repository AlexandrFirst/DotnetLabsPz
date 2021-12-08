using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using Lab_4_Dot_Net.Core.DTO;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IObtainingRepository : IRepository<Obtaining>
    {
        IEnumerable<ObtainingTableDTO> GetObtainingsTableData();
        ObtainingFormDTO GetObtainingFormDTO();
        int Add(ObtainingFormDTO dto, string userName);
        Obtaining PerformMapping(ObtainingFormDTO dto);
    }
}
