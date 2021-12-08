using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4_Dot_Net.Core.Domain.Owners;
using System.Data.Entity.ModelConfiguration;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Owners
{
    public class OwnerAuditConfiguration : EntityTypeConfiguration<OwnerAudit>
    {
        public OwnerAuditConfiguration()
        {
            ToTable("OwnersAudits");

            HasKey(o => o.ChangeId);
            Property(o => o.ChangeId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(o => o.OwnerId)
                .IsRequired();

            Property(f => f.Name)
              .IsRequired()
              .HasColumnName("OwnerName")
              .HasMaxLength(20);

            Property(f => f.Surname)
               .IsRequired()
               .HasColumnName("OwnerSurname")
               .HasMaxLength(20);

            Property(f => f.Birthday)
                .HasColumnName("OwnerBirthday");

            Property(f => f.MadeAt)
              .HasColumnName("Made_At")
              .IsRequired();

            Property(f => f.Operation)
                .HasColumnName("Operation")
                .IsRequired();
        }
    }
}