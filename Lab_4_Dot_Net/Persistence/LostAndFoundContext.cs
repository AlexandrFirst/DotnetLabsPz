using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//Domain
using Lab_4_Dot_Net.Core.Domain.Extradictions;
using Lab_4_Dot_Net.Core.Domain.Finders;
using Lab_4_Dot_Net.Core.Domain.Findings;
using Lab_4_Dot_Net.Core.Domain.Obtainings;
using Lab_4_Dot_Net.Core.Domain.Owners;
using Lab_4_Dot_Net.Core.Domain.RoleMasters;
using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;
using Lab_4_Dot_Net.Core.Domain.Workers;

//Configurations
using Lab_4_Dot_Net.Persistence.EntityConfigurations.Extradictions;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.Finders;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.Findings;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.Obtainings;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.Owners;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.RoleMasters;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.WorkerRoleMappings;
using Lab_4_Dot_Net.Persistence.EntityConfigurations.Workers;


namespace Lab_4_Dot_Net.Persistence
{
    public class LostAndFoundContext : DbContext
    {
        public LostAndFoundContext() : base("name=LostAndFoundDB_Lab4")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Extradiction> Extradictions { get; set; }
        public virtual DbSet<ExtradictionAudit> ExtradictionAudits { get; set; }
        public virtual DbSet<Finder> Finders { get; set; }
        public virtual DbSet<FinderAudit> FinderAudits { get; set; }
        public virtual DbSet<Finding> Findings { get; set; }
        public virtual DbSet<FindingAudit> FindingAudits { get; set; }
        public virtual DbSet<Obtaining> Obtainings { get; set; }
        public virtual DbSet<ObtainingAudit> ObtainingAudits { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<OwnerAudit> OwnerAudits { get; set; }
        public virtual DbSet<RoleMaster> Roles { get; set; }
        public virtual DbSet<RoleMasterAudit> RoleAudits { get; set; }
        public virtual DbSet<WorkerRoleMapping> WorkerRoleMappings { get; set; }
        public virtual DbSet<WorkerRoleMappingAudit> WorkerRoleMappingAudits { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkerAudit> WorkerAudits { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExtradicitonConfiguration());
            modelBuilder.Configurations.Add(new ExtradictionAuditConfiguration());
            modelBuilder.Configurations.Add(new FinderConfiguration());
            modelBuilder.Configurations.Add(new FinderAuditConfiguration());
            modelBuilder.Configurations.Add(new FindingConfiguration());
            modelBuilder.Configurations.Add(new FindingAuditConfiguration());
            modelBuilder.Configurations.Add(new ObtainingConfiguration());
            modelBuilder.Configurations.Add(new ObtainingAuditConfiguration());
            modelBuilder.Configurations.Add(new OwnerConfiguration());
            modelBuilder.Configurations.Add(new OwnerAuditConfiguration());
            modelBuilder.Configurations.Add(new RoleMasterConfiguration());
            modelBuilder.Configurations.Add(new RoleMasterAuditConfiguration());
            modelBuilder.Configurations.Add(new WorkerRoleMappingConfiguration());
            modelBuilder.Configurations.Add(new WorkerRoleMappingAuditConfiguration());
            modelBuilder.Configurations.Add(new WorkerConfiguration());
            modelBuilder.Configurations.Add(new WorkerAuditConfiguration());
        }
    }
}