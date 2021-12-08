using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab3_Dot_Net.Core;
using Lab3_Dot_Net.Core.Domain.WorkerRoleMappings;
using Lab3_Dot_Net.Core.Domain.Workers;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Core.Repositories.Workers;
using Lab3_Dot_Net.Persistence.Repositories.RoleMasters;
using Lab3_Dot_Net.Persistence.Repositories.WorkerRoleMappings;

namespace Lab3_Dot_Net.Persistence.Repositories.Workers
{
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public int AddOrUpdate(WorkerFormDTO dto)
        {
            int result = 0;
            try
            {
                Worker worker = PerformMapping(dto);
                if (dto.WorkerId == 0)
                   result = Add(worker);
                else
                    result = Update(worker);
                if (dto.isAdmin == true)
                {
                    var roleRepository = new RoleMasterRepository();
                    var roleId = roleRepository.GetAll().Where(r => r.RoleName == "Admin").Select(r => r.RoleId).SingleOrDefault();
                    var roleMappingRepository = new WorkerRoleMappingRepository();
                    var mapping = new WorkerRoleMapping() { WorkerId = worker.WorkerId, RoleId = roleId };
                    roleMappingRepository.Add(mapping);
                }
                return result;
            }
            catch { return result; }
        }

        public WorkerFormDTO GetWorkerFormDTO(int? id)
        {
            var worker = GetAll().Where(w => w.WorkerId == id).FirstOrDefault();
            if (worker == null)
                return new WorkerFormDTO() { WorkerId = 0 };
            WorkerFormDTO dto = new WorkerFormDTO()
            {
                WorkerId = worker.WorkerId,
                Name = worker.Name,
                Surname = worker.Surname,
                Birthday = worker.Birthday,
                Login = worker.Login,
                Password = worker.Password
            };
            var roleProvider = new WorkersRoleProvider();
            var roles = roleProvider.GetRolesForUser(worker.Login);
            if (roles.Contains("Admin"))
                dto.isAdmin = true;
            return dto;
        }

        public IEnumerable<WorkerAudit> GetWorkersTableData()
        {
            var workerAuditRepository = new WorkerAuditRepository();
            var workers = (from w in GetAll()
                           join wAudit in workerAuditRepository.GetAll()
                           on w.WorkerId equals wAudit.WorkerId
                           where wAudit.Operation == "INS"
                           select wAudit).AsEnumerable();
            return workers;
        }

        public Worker PerformMapping(WorkerFormDTO dto)
        {
            Worker worker = new Worker()
            {
                WorkerId = dto.WorkerId,
                Name = dto.Name,
                Surname = dto.Surname,
                Birthday = dto.Birthday,
                Login = dto.Login,
                Password = dto.Password
            };
            return worker;
        }
    }
}