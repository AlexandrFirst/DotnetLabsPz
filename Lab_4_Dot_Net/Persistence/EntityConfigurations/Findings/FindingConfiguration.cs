using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.Findings;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Findings
{
    public class FindingConfiguration : EntityTypeConfiguration<Finding>
    {
        public FindingConfiguration()
        {
            ToTable("Findings");

            HasKey(f => f.FindingId);
            Property(f => f.FindingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(f => f.FindingName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("FindingName");

            Property(f => f.Description)
                .HasMaxLength(200)
                .HasColumnName("Description");

            HasMany(f => f.Obtainings)
                .WithRequired(o => o.Finding)
                .WillCascadeOnDelete();

            HasMany(f => f.Extradictions)
                .WithRequired(e => e.Finding)
                .WillCascadeOnDelete();
        }
    }
}