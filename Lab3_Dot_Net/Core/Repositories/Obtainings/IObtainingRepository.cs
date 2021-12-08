using Lab3_Dot_Net.Core.Domain.Obtainings;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dot_Net.Core.Repositories.Obtainings
{
    public interface IObtainingRepository : IRepository<Obtaining>
    {
        IEnumerable<ObtainingTableDTO> GetObtainingsTableData();
        ObtainingFormDTO GetObtainingFormDTO();
        int AddObtaining(ObtainingFormDTO dto, string userName);
        Obtaining PerformMapping(ObtainingFormDTO dto);
    }
}
