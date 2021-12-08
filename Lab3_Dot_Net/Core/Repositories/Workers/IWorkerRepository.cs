using Lab3_Dot_Net.Core.Domain.Workers;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_Dot_Net.Core.Repositories.Workers
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        IEnumerable<WorkerAudit> GetWorkersTableData();
        WorkerFormDTO GetWorkerFormDTO(int? id);
        int AddOrUpdate(WorkerFormDTO dto);
        Worker PerformMapping(WorkerFormDTO dto);
    }
}