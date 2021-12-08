using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Workers;
using Lab_4_Dot_Net.Core.DTO;

namespace Lab_4_Dot_Net.Core.Repositories
{
    public interface IWorkerRepository :IRepository<Worker>
    {
        IEnumerable<WorkerAudit> GetWorkersTableData();
        WorkerFormDTO GetWorkerFormDTO(int? id);
        int AddOrUpdate(WorkerFormDTO dto);
        Worker PerformMapping(WorkerFormDTO dto);
        
    }
}