using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using Lab_4_Dot_Net.Core.Domain.Owners;
using Lab_4_Dot_Net.Core.Domain.Workers;
using Lab_4_Dot_Net.Core.DTO;
using Lab_4_Dot_Net.Core.Repositories;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class ExtradictionRepository : Repository<Extradiction>, IExtradictionRepository
    {
        public ExtradictionRepository(LostAndFoundContext context)
          : base(context)
        {

        }

        public int Add(ExtradictionFormDTO dto, string username)
        {
            try
            {
                Extradiction extradiction = PerformMapping(dto);
                var worker = Context.Set<Worker>().Where(w => w.Login == username).FirstOrDefault();
                extradiction.Worker = worker;
                extradiction.WorkerId = worker.WorkerId;
                Entities.Add(extradiction);
                Context.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }

        public ExtradictionFormDTO GetExtradictionFormDTO()
        {
            var findingsIdentifiers = Context.Set<Obtaining>()
                .Where(o => !Context.Set<ExtradictionAudit>().Select(e => e.FindingId).Contains(o.FindingId))
                .Select(o => o.FindingId).AsEnumerable().ToList();
            ExtradictionFormDTO dto = new ExtradictionFormDTO()
            {
                OwnersNames = Context.Set<Owner>().Select(o => o.Name + " " + o.Surname).AsEnumerable(),
                FindingsNames = Context.Set<Finding>().Where(f => findingsIdentifiers.Contains(f.FindingId)).Select(f => f.FindingName).AsEnumerable()
            };
            return dto;
        }
        public IEnumerable<ExtradictionTableDTO> GetExtradictionsTableData()
        {
            var extradictions = (from e in Entities
                                 join eAudit in Context.Set <ExtradictionAudit>()
                                 on new { WorkerId = e.WorkerId, FindingId = e.FindingId, OwnerId = e.OwnerId }
                                 equals new { WorkerId = eAudit.WorkerId, FindingId = eAudit.FindingId, OwnerId = eAudit.OwnerId }
                                 select new ExtradictionTableDTO
                                 {
                                     WorkerName = e.Worker.Name + " " + e.Worker.Surname,
                                     WorkerId = e.WorkerId,
                                     FindingId = e.FindingId,
                                     FindingName = e.Finding.FindingName,
                                     OwnerId = e.OwnerId,
                                     OwnerName = e.Owner.Name + " " + e.Owner.Surname,
                                     AddedOn = eAudit.MadeAt
                                 }).AsEnumerable();
            return extradictions;
        }

        public Extradiction PerformMapping(ExtradictionFormDTO dto)
        {
            Extradiction extradiction = new Extradiction();
            var finding = Context.Set<Finding>().Where(f => f.FindingName == dto.FindingName).FirstOrDefault();
            var owner = Context.Set<Owner>().Where(o => o.Name + " " + o.Surname == dto.OwnerName).FirstOrDefault();
            extradiction.Owner = owner;
            extradiction.OwnerId = owner.OwnerId;
            extradiction.Finding = finding;
            extradiction.FindingId = finding.FindingId;
            return extradiction;
        }
    }
}