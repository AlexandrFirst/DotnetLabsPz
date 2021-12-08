using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4_Dot_Net.Core.Domain.Obtainings;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Obtainings
{
    public class ObtainingAuditConfiguration : EntityTypeConfiguration<ObtainingAudit>
    {
        public ObtainingAuditConfiguration()
        {
            ToTable("ObtainingsAudits");

            HasKey(o => o.ChangeId);
            Property(o => o.ChangeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(o => o.FinderId)
                .IsRequired();

            Property(o => o.WorkerId)
                .IsRequired();

            Property(o => o.FindingId)
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