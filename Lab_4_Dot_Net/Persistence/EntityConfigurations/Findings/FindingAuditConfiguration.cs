using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Findings;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Findings
{
    public class FindingAuditConfiguration : EntityTypeConfiguration<FindingAudit>
    {
        public FindingAuditConfiguration()
        {
            ToTable("FindingsAudits");

            HasKey(f => f.ChangeId);
            Property(f => f.ChangeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(f => f.FindingId)
                .IsRequired();

            Property(f => f.FindingName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("FindingName");

            Property(f => f.Description)
                .HasMaxLength(200)
                .HasColumnName("Description");


            Property(f => f.MadeAt)
                .HasColumnName("Made_At")
                .IsRequired();

            Property(f => f.Operation)
                .HasColumnName("Operation")
                .IsRequired();
        }
    }
}