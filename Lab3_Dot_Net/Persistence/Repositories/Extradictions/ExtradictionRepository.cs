using Lab3_Dot_Net.Core.Domain.Extradictions;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Core.Repositories.Extradictions;
using Lab3_Dot_Net.Core.Repositories.Findings;
using Lab3_Dot_Net.Core.Repositories.Owners;
using Lab3_Dot_Net.Core.Repositories.Workers;
using Lab3_Dot_Net.Persistence.Repositories.Findings;
using Lab3_Dot_Net.Persistence.Repositories.Owners;
using Lab3_Dot_Net.Persistence.Repositories.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Lab3_Dot_Net.Persistence.Repositories.Extradictions
{
    public class ExtradictionRepository : Repository<Extradiction>, IExtradictionRepository
    {

        private IFindingRepository findings;
        private IOwnerRepository owners;
        private IWorkerRepository workers;
        public ExtradictionRepository()
        {
            findings = new FindingRepository();
            owners = new OwnerRepository();
            workers = new WorkerRepository();
        }
        public override int Add(Extradiction entity)
        {
            string sqlStatement = "INSERT INTO " + _tableName + " (";
            var keyProperties = typeof(Extradiction).GetProperties()
                .Where(p => p.GetCustomAttributes().Any(attr => (attr as KeyAttribute) != null));
            foreach (var keyProperty in keyProperties)
                sqlStatement += keyProperty.Name + ",";
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += ") VALUES (";
            foreach (var keyProperty in keyProperties)
                sqlStatement += "'" + keyProperty.GetValue(entity, null) + "',";
            sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1);
            sqlStatement += ");";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddExtradiction(ExtradictionFormDTO dto, string username)
        {
            int result = 0;
            try
            {
                Extradiction extradiction = PerformMapping(dto);
                var worker = workers.GetAll().Where(w => w.Login == username).SingleOrDefault();
                extradiction.WorkerId = worker.WorkerId;
                result = Add(extradiction);
                return result;
            }
            catch { return result; }
        }

        public ExtradictionFormDTO GetExtradictionFormDTO()
        {
            ExtradictionFormDTO dto = new ExtradictionFormDTO()
            {
                OwnersNames = owners.GetAll().Select(f => f.Name + " " + f.Surname).AsEnumerable(),
                FindingsNames = findings.GetAll().Where(f => !GetAll().Select(o => o.FindingId).Contains(f.FindingId))
               .Select(f => f.FindingName).AsEnumerable()
            };
            return dto;
        }

        public IEnumerable<ExtradictionTableDTO> GetExtradictionsTableData()
        {
            var extradictionAudits = new ExtradictionAuditRepository();
            var extradictions = (from e in GetAll()
                                 join eAudit in extradictionAudits.GetAll()
                                 on new { WorkerId = e.WorkerId, OwnerId = e.OwnerId, FindingId = e.FindingId }
                                  equals new { WorkerId = eAudit.WorkerId, OwnerId = eAudit.OwnerId, FindingId = eAudit.FindingId }
                                 join owner in owners.GetAll()
                                 on e.OwnerId equals owner.OwnerId
                                 join finding in findings.GetAll()
                                 on e.FindingId equals finding.FindingId
                                 join w in workers.GetAll()
                                 on e.WorkerId equals w.WorkerId
                                 select new ExtradictionTableDTO
                                 {
                                     WorkerId = w.WorkerId,
                                     WorkerName = w.Name + " " + w.Surname,
                                     OwnerId = owner.OwnerId,
                                     OwnerName = owner.Name + " " + owner.Surname,
                                     FindingId = finding.FindingId,
                                     FindingName = finding.FindingName,
                                     AddedOn = eAudit.Made_At
                                 }).AsEnumerable();
            return extradictions;
        }

        public Extradiction PerformMapping(ExtradictionFormDTO dto)
        {
            Extradiction extradiction = new Extradiction();
            int ownerId = owners.GetAll().Where(o => o.Name + " " + o.Surname == dto.OwnerName)
                .Select(o => o.OwnerId).SingleOrDefault();
            int findingId = findings.GetAll().Where(f => f.FindingName == dto.FindingName)
                .Select(f => f.FindingId).FirstOrDefault();
            extradiction.FindingId = findingId;
            extradiction.OwnerId = ownerId;
            return extradiction;
        }
    }
}