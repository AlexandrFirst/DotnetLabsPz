using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.DTO;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IExtradictionRepository : IRepository<Extradiction>
    {
        IEnumerable<ExtradictionTableDTO> GetExtradictionsTableData();
        ExtradictionFormDTO GetExtradictionFormDTO();
        int Add(ExtradictionFormDTO dto, string username);
        Extradiction PerformMapping(ExtradictionFormDTO dto);
    }
}
