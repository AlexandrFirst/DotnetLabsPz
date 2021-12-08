using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lab_4_Dot_Net.Core.Domain.Finders;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Finders
{
    public class FinderConfiguration : EntityTypeConfiguration<Finder>
    {
        public FinderConfiguration()
        {
            ToTable("Finders");

            HasKey(f => f.FinderId);
            Property(f => f.FinderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

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

            HasMany(f => f.Obtainings)
                .WithRequired(o => o.Finder)
                .WillCascadeOnDelete();
        }
    }
}