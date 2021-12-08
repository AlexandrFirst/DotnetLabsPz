using Lab_4_Dot_Net.Core.Domain.Finders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Finders
{
    public class FinderAuditConfiguration : EntityTypeConfiguration<FinderAudit> 
    {
        public FinderAuditConfiguration()
        {
            ToTable("FindersAudits");

            HasKey(f => f.ChangeId);
            Property(f => f.ChangeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(f => f.FinderId).
                IsRequired();

            Property(f => f.Name)
               .IsRequired()
               .HasColumnName("FinderName")
               .HasMaxLength(20);

            Property(f => f.Surname)
               .IsRequired()
               .HasColumnName("FinderSurname")
               .HasMaxLength(20);

            Property(f => f.Birthday)
               .HasColumnName("FinderBirthday");

            Property(f => f.MadeAt)
                .HasColumnName("Made_At")
                .IsRequired();

            Property(f => f.Operation)
                .HasColumnName("Operation")
                .IsRequired();
        }
    }
}