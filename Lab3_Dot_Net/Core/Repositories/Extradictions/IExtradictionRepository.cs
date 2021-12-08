using Lab3_Dot_Net.Core.Domain.Extradictions;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dot_Net.Core.Repositories.Extradictions
{
    public interface IExtradictionRepository : IRepository<Extradiction>
    {
        IEnumerable<ExtradictionTableDTO> GetExtradictionsTableData();
        ExtradictionFormDTO GetExtradictionFormDTO();
        int AddExtradiction(ExtradictionFormDTO dto, string username);
        Extradiction PerformMapping(ExtradictionFormDTO dto);
    }
}
