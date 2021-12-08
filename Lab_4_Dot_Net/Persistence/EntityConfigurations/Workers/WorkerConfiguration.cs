using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4_Dot_Net.Core.Domain.Workers;
using System.Data.Entity.ModelConfiguration;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Workers
{
    public class WorkerConfiguration : EntityTypeConfiguration<Worker>
    {
        public WorkerConfiguration()
        {
            ToTable("Workers");

            HasKey(w => w.WorkerId);
            Property(w => w.WorkerId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(w => w.Name)
                .HasColumnName("WorkerName")
                .IsRequired()
                .HasMaxLength(20);

            Property(w => w.Surname)
                .HasColumnName("WorkerSurname")
                .IsRequired()
                .HasMaxLength(20);

            Property(w => w.Birthday)
                .HasColumnName("WorkerBirthday");

            Property(w => w.Login)
                .HasColumnName("Login")
                .IsRequired()
                .HasMaxLength(30);

            Property(w => w.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(30);

            HasMany(w => w.Mappings)
                .WithRequired(m => m.Worker)
                .WillCascadeOnDelete();

            HasMany(w => w.Extradictions)
                .WithRequired(e => e.Worker)
                .WillCascadeOnDelete();

            HasMany(w => w.Obtainings)
                .WithRequired(o => o.Worker)
                .WillCascadeOnDelete();
        }
    }
}