using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.WorkerRoleMappings
{
    public class WorkerRoleMappingAuditConfiguration : EntityTypeConfiguration<WorkerRoleMappingAudit>
    {
        public WorkerRoleMappingAuditConfiguration()
        {
            ToTable("WorkerRoleMappingsAudits");

            HasKey(w => w.ChangeId);
            Property(w => w.ChangeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(w => w.MappingId)
                .IsRequired();

            Property(w => w.RoleId)
                .IsRequired();

            Property(w => w.WorkerId)
                .IsRequired();

            Property(w => w.MadeAt)
                .HasColumnName("Made_At")
                .IsRequired();

            Property(w => w.Operation)
                .HasColumnName("Operation")
                .IsRequired();
        }
    }
}