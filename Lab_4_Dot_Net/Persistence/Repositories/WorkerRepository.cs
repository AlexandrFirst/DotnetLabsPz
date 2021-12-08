using Lab_4_Dot_Net.Core.Domain;
using Lab_4_Dot_Net.Core.Domain.RoleMasters;
using Lab_4_Dot_Net.Core.Domain.Workers;
using Lab_4_Dot_Net.Core.DTO;
using Lab_4_Dot_Net.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;


namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(LostAndFoundContext context)
           : base(context)
        {

        }

        public int AddOrUpdate(WorkerFormDTO dto)
        {
            try
            {
                Worker worker;
                if (dto.WorkerId == 0)
                    worker = Entities.Add(PerformMapping(dto));
                else
                {
                    worker = Entities.Find(dto.WorkerId);
                    worker.Birthday = dto.Birthday;
                    worker.Login = dto.Login;
                    worker.Password = dto.Password;
                    worker.Surname = dto.Surname;
                    worker.Name = dto.Name;
                }
                if (dto.isAdmin == true)
                {
                    var role = Context.Set<RoleMaster>().Where(r => r.RoleName == "Admin").SingleOrDefault();
                    Context.Set<WorkerRoleMapping>().Add(new WorkerRoleMapping() { Role = role, Worker = worker });
                }
                Context.SaveChanges();
                return 1;
             } catch { return 0; }
        }

        public WorkerFormDTO GetWorkerFormDTO(int? id)
        {
            var worker = SingleOrDefault(w=>w.WorkerId == id);
            if (worker == null)
                return new WorkerFormDTO() { WorkerId = 0};
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
            var workers = (from w in Entities
                           join wAudit in Context.Set<WorkerAudit>()
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
                Login = dto.Login,
                Name = dto.Name,
                Surname = dto.Surname,
                Password = dto.Password,
                Birthday = dto.Birthday
            };
            return worker;
        }
    }
}