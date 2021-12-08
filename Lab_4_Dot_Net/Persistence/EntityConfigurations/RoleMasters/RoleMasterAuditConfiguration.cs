using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4_Dot_Net.Core.Domain.RoleMasters;
using System.Data.Entity.ModelConfiguration;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.RoleMasters
{
    public class RoleMasterAuditConfiguration : EntityTypeConfiguration<RoleMasterAudit>
    {
        public RoleMasterAuditConfiguration()
        {
            ToTable("RoleMastersAudits");

            HasKey(r => r.ChangeId);
            Property(r => r.ChangeId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.RoleId)
                .IsRequired();

            Property(r => r.RoleName)
                .HasColumnName("RoleName")
                .IsRequired()
                .HasMaxLength(20);

            Property(f => f.MadeAt)
            .HasColumnName("Made_At")
            .IsRequired();

            Property(f => f.Operation)
                .HasColumnName("Operation")
                .IsRequired();
        }
    }
}