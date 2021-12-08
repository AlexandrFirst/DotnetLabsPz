using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Finders;
using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using Lab_4_Dot_Net.Core.Domain.Workers;
using Lab_4_Dot_Net.Core.DTO;
using Lab_4_Dot_Net.Core.Repositories;
using System.Web.Security;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class ObtainingRepository : Repository<Obtaining>, IObtainingRepository
    {
        public ObtainingRepository(LostAndFoundContext context)
          : base(context)
        {

        }

        public int Add(ObtainingFormDTO dto, string username)
        {
            try
            {
                Obtaining obtaining = PerformMapping(dto);
                var worker = Context.Set<Worker>().Where(w => w.Login == username).FirstOrDefault();
                obtaining.Worker = worker;
                obtaining.WorkerId = worker.WorkerId;
                Entities.Add(obtaining);
                Context.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }
        public ObtainingFormDTO GetObtainingFormDTO()
        {
            ObtainingFormDTO dto = new ObtainingFormDTO()
            {
                FindersNames = Context.Set<Finder>().Select(f => f.Name + " " + f.Surname).AsEnumerable(),
                FindingsNames = Context.Set<Finding>()
                .Where(f => !Context.Set<ObtainingAudit>().Select(o=>o.FindingId).Contains(f.FindingId)).Select(f => f.FindingName).AsEnumerable()
            };
            return dto;
        }
        public IEnumerable<ObtainingTableDTO> GetObtainingsTableData()
        {
            var obtainings = (from o in Entities
                              join oAudit in Context.Set<ObtainingAudit>()
                              on new { WorkerId = o.WorkerId, FinderId = o.FinderId, FindingId = o.FindingId }
                              equals new { WorkerId = oAudit.WorkerId, FinderId = oAudit.FinderId, FindingId = oAudit.FindingId }
                              select new ObtainingTableDTO
                              {
                                  WorkerName = o.Worker.Name + " " + o.Worker.Surname,
                                  FindingName = o.Finding.FindingName,
                                  FinderName = o.Finder.Name + " " + o.Finder.Surname,
                                  WorkerId = o.WorkerId,
                                  FinderId = o.FinderId,
                                  FindingId = o.FindingId,
                                  AddedOn = oAudit.MadeAt
                              }).AsEnumerable();
            return obtainings;
        }
        public Obtaining PerformMapping(ObtainingFormDTO dto)
        {
            Obtaining obtaining = new Obtaining();
            var finding = Context.Set<Finding>().Where(f => f.FindingName == dto.FindingName).FirstOrDefault();
            var finder = Context.Set<Finder>().Where(f => f.Name + " " + f.Surname == dto.FinderName).FirstOrDefault();
            obtaining.Finder = finder;
            obtaining.Finding = finding;
            obtaining.FindingId = finding.FindingId;
            obtaining.FinderId = finder.FinderId;
            return obtaining;
        }
    }
}