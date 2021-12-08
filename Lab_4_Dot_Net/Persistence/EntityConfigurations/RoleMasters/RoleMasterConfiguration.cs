using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Domain.RoleMasters;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.RoleMasters
{
    public class RoleMasterConfiguration : EntityTypeConfiguration<RoleMaster>
    {
        public RoleMasterConfiguration()
        {
            ToTable("RoleMasters");

            HasKey(r => r.RoleId);
            Property(r => r.RoleId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.RoleName)
                .HasColumnName("RoleName")
                .IsRequired()
                .HasMaxLength(20);

            HasMany(r => r.Mappings)
                .WithRequired(m => m.Role)
                .WillCascadeOnDelete();
        }
    }
}