using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lab_4_Dot_Net.Core.Domain.Extradictions;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Extradictions
{
    public class ExtradicitonConfiguration : EntityTypeConfiguration<Extradiction>
    {
        public ExtradicitonConfiguration()
        {
            ToTable("Extradictions");

            HasKey(e => new { e.FindingId, e.OwnerId, e.WorkerId });

            HasRequired(e => e.Worker)
                .WithMany(w => w.Extradictions)
                .HasForeignKey(e=>e.WorkerId)
                .WillCascadeOnDelete();

            HasRequired(e => e.Owner)
                .WithMany(o => o.Extradictions)
                .HasForeignKey(e=>e.OwnerId)
                .WillCascadeOnDelete();

            HasRequired(e => e.Finding)
                .WithMany(f => f.Extradictions)
                .HasForeignKey(e => e.FindingId)
                .WillCascadeOnDelete();
        }
    }
}