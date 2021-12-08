using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lab_4_Dot_Net.Core.Domain.Extradictions;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Extradictions
{
    public class ExtradictionAuditConfiguration : EntityTypeConfiguration<ExtradictionAudit>
    {
        public ExtradictionAuditConfiguration()
        {
            ToTable("ExtradictionsAudits");

            HasKey(e => e.ChangeId);
            Property(e => e.ChangeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.FindingId)
                .IsRequired();
            Property(e => e.OwnerId)
               .IsRequired();
            Property(e => e.WorkerId)
               .IsRequired();

            Property(e => e.MadeAt)
               .HasColumnName("Made_At")
               .IsRequired();

            Property(e => e.Operation)
                .HasColumnName("Operation")
                .IsRequired();

        }
    }
}