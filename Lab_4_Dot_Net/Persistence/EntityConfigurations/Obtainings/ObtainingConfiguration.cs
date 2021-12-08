using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lab_4_Dot_Net.Core.Domain.Obtainings;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Obtainings
{
    public class ObtainingConfiguration : EntityTypeConfiguration<Obtaining>
    {
        public ObtainingConfiguration()
        {
            ToTable("Obtainings");

            HasKey(o => new { o.FindingId, o.FinderId, o.WorkerId });

            HasRequired(o => o.Worker)
                .WithMany(w => w.Obtainings)
                .HasForeignKey(o => o.WorkerId)
                .WillCascadeOnDelete();

            HasRequired(o => o.Finding)
                .WithMany(f => f.Obtainings)
                .HasForeignKey(o => o.FindingId)
                .WillCascadeOnDelete();

            HasRequired(o => o.Finder)
                .WithMany(f => f.Obtainings)
                .HasForeignKey(o => o.FinderId)
                .WillCascadeOnDelete();
        }
    }
}