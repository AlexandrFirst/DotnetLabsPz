using Lab_4_Dot_Net.Core.Domain.Owners;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Owners
{
    public class OwnerConfiguration : EntityTypeConfiguration<Owner>
    {
        public OwnerConfiguration() 
        {
            ToTable("Owners");

            HasKey(o => o.OwnerId);
            Property(o => o.OwnerId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

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

            HasMany(o => o.Extradictions)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete();
        }
    }
}