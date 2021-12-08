using Lab3_Dot_Net.Core.Domain.Obtainings;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Core.Repositories.Finders;
using Lab3_Dot_Net.Core.Repositories.Findings;
using Lab3_Dot_Net.Core.Repositories.Obtainings;
using Lab3_Dot_Net.Core.Repositories.Workers;
using Lab3_Dot_Net.Persistence.Repositories.Finders;
using Lab3_Dot_Net.Persistence.Repositories.Findings;
using Lab3_Dot_Net.Persistence.Repositories.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Lab3_Dot_Net.Persistence.Repositories.Obtainings
{
    public class ObtainingRepository : Repository<Obtaining>, IObtainingRepository
    {
        private IFindingRepository findings;
        private IFinderRepository finders;
        private IWorkerRepository workers;
        public ObtainingRepository()
        {
            findings = new FindingRepository();
            finders = new FinderRepository();
            workers = new WorkerRepository();
        }
        public override int Add(Obtaining entity)
        {
            string sqlStatement = "INSERT INTO " + _tableName + " (";
            var keyProperties = typeof(Obtaining).GetProperties()
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
        public int AddObtaining(ObtainingFormDTO dto, string userName)
        {
            int result = 0;
            try
            {
                Obtaining obtaining = PerformMapping(dto);
                var worker = workers.GetAll().Where(w => w.Login == userName).SingleOrDefault();
                obtaining.WorkerId = worker.WorkerId;
                result = Add(obtaining);
                return result;
            }
            catch { return result; }
        }
        public ObtainingFormDTO GetObtainingFormDTO()
        {

            ObtainingFormDTO dto = new ObtainingFormDTO()
            {
                FindersNames = finders.GetAll().Select(f => f.Name + " " + f.Surname).AsEnumerable(),
                FindingsNames = findings.GetAll().Where(f=>!GetAll().Select(o=>o.FindingId).Contains(f.FindingId))
                .Select(f=>f.FindingName).AsEnumerable()
            };
            return dto;
        }
        public IEnumerable<ObtainingTableDTO> GetObtainingsTableData()
        {
            var obtainingsAudits = new ObtainingAuditRepository();
            var obtainings = (from o in GetAll()
                              join oAudit in obtainingsAudits.GetAll()
                              on new { WorkerId = o.WorkerId, FinderId = o.FinderId, FindingId = o.FindingId }
                               equals new { WorkerId = oAudit.WorkerId, FinderId = oAudit.FinderId, FindingId = oAudit.FindingId }
                              join finder in finders.GetAll()
                              on o.FinderId equals finder.FinderId
                              join finding in findings.GetAll()
                              on o.FindingId equals finding.FindingId
                              join w in workers.GetAll()
                              on o.WorkerId equals w.WorkerId
                              select new ObtainingTableDTO
                              {
                                  WorkerId = w.WorkerId,
                                  WorkerName = w.Name + " " +w.Surname,
                                  FinderId = finder.FinderId,
                                  FinderName = finder.Name + " " + finder.Surname,
                                  FindingId = finding.FindingId,
                                  FindingName = finding.FindingName,
                                  AddedOn = oAudit.Made_At
                              }).AsEnumerable();
            return obtainings;
        }

        public Obtaining PerformMapping(ObtainingFormDTO dto)
        {
            Obtaining obtaining = new Obtaining();
            int finderId = finders.GetAll().Where(f => f.Name + " " + f.Surname == dto.FinderName)
                .Select(f=>f.FinderId).FirstOrDefault();
            int findingId = findings.GetAll().Where(f => f.FindingName == dto.FindingName)
                .Select(f=>f.FindingId).FirstOrDefault();
            obtaining.FindingId = findingId;
            obtaining.FinderId = finderId;
            return obtaining;
        }
    }
}