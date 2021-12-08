using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4_Dot_Net.Persistence.EntityConfigurations.WorkerRoleMappings
{
    public class WorkerRoleMappingConfiguration : EntityTypeConfiguration<WorkerRoleMapping>
    {
        public WorkerRoleMappingConfiguration()
        {
            ToTable("WorkerRoleMappings");

            HasKey(m => m.MappingId);
            Property(m => m.MappingId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(m => m.Role)
                .WithMany(r => r.Mappings)
                .WillCascadeOnDelete();


            HasRequired(m => m.Worker)
                .WithMany(w => w.Mappings)
                .WillCascadeOnDelete();
        }
    }
}