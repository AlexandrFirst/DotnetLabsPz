using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Lab_4_Dot_Net.Core.Domain.Workers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.Workers
{
    public class WorkerAuditConfiguration : EntityTypeConfiguration<WorkerAudit>
    {
        public WorkerAuditConfiguration()
        {
            ToTable("WorkersAudits");

            HasKey(w => w.ChangeId);
            Property(w => w.ChangeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(w => w.WorkerId)
                .IsRequired();

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

            Property(f => f.MadeAt)
             .HasColumnName("Made_At")
             .IsRequired();

            Property(f => f.Operation)
                .HasColumnName("Operation")
                .IsRequired();
        }
    }
}