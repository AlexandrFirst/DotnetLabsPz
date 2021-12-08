namespace Lab_4_Dot_Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtradictionsAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        FindingId = c.Int(nullable: false),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.Extradictions",
                c => new
                    {
                        FindingId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FindingId, t.OwnerId, t.WorkerId })
                .ForeignKey("dbo.Findings", t => t.FindingId, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.FindingId)
                .Index(t => t.OwnerId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Findings",
                c => new
                    {
                        FindingId = c.Int(nullable: false, identity: true),
                        FindingName = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.FindingId);
            
            CreateTable(
                "dbo.Obtainings",
                c => new
                    {
                        FindingId = c.Int(nullable: false),
                        FinderId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FindingId, t.FinderId, t.WorkerId })
                .ForeignKey("dbo.Finders", t => t.FinderId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .ForeignKey("dbo.Findings", t => t.FindingId, cascadeDelete: true)
                .Index(t => t.FindingId)
                .Index(t => t.FinderId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Finders",
                c => new
                    {
                        FinderId = c.Int(nullable: false, identity: true),
                        FinderName = c.String(nullable: false, maxLength: 20),
                        FinderSurname = c.String(nullable: false, maxLength: 20),
                        FinderBirthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FinderId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        WorkerName = c.String(nullable: false, maxLength: 20),
                        WorkerSurname = c.String(nullable: false, maxLength: 20),
                        WorkerBirthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerId);
            
            CreateTable(
                "dbo.WorkerRoleMappings",
                c => new
                    {
                        MappingId = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MappingId)
                .ForeignKey("dbo.RoleMasters", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleMasters",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false, maxLength: 20),
                        OwnerSurname = c.String(nullable: false, maxLength: 20),
                        OwnerBirthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.FindersAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        FinderId = c.Int(nullable: false),
                        FinderName = c.String(nullable: false, maxLength: 20),
                        FinderSurname = c.String(nullable: false, maxLength: 20),
                        FinderBirthday = c.DateTime(nullable: false),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.FindingsAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        FindingId = c.Int(nullable: false),
                        FindingName = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 200),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.ObtainingsAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        FinderId = c.Int(nullable: false),
                        FindingId = c.Int(nullable: false),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.OwnersAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        OwnerName = c.String(nullable: false, maxLength: 20),
                        OwnerSurname = c.String(nullable: false, maxLength: 20),
                        OwnerBirthday = c.DateTime(nullable: false),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.RoleMastersAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.WorkersAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        WorkerName = c.String(nullable: false, maxLength: 20),
                        WorkerSurname = c.String(nullable: false, maxLength: 20),
                        WorkerBirthday = c.DateTime(nullable: false),
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.WorkerRoleMappingsAudits",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        MappingId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Made_At = c.DateTime(nullable: false),
                        Operation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Extradictions", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Extradictions", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Extradictions", "FindingId", "dbo.Findings");
            DropForeignKey("dbo.Obtainings", "FindingId", "dbo.Findings");
            DropForeignKey("dbo.Obtainings", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerRoleMappings", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerRoleMappings", "RoleId", "dbo.RoleMasters");
            DropForeignKey("dbo.Obtainings", "FinderId", "dbo.Finders");
            DropIndex("dbo.WorkerRoleMappings", new[] { "RoleId" });
            DropIndex("dbo.WorkerRoleMappings", new[] { "WorkerId" });
            DropIndex("dbo.Obtainings", new[] { "WorkerId" });
            DropIndex("dbo.Obtainings", new[] { "FinderId" });
            DropIndex("dbo.Obtainings", new[] { "FindingId" });
            DropIndex("dbo.Extradictions", new[] { "WorkerId" });
            DropIndex("dbo.Extradictions", new[] { "OwnerId" });
            DropIndex("dbo.Extradictions", new[] { "FindingId" });
            DropTable("dbo.WorkerRoleMappingsAudits");
            DropTable("dbo.WorkersAudits");
            DropTable("dbo.RoleMastersAudits");
            DropTable("dbo.OwnersAudits");
            DropTable("dbo.ObtainingsAudits");
            DropTable("dbo.FindingsAudits");
            DropTable("dbo.FindersAudits");
            DropTable("dbo.Owners");
            DropTable("dbo.RoleMasters");
            DropTable("dbo.WorkerRoleMappings");
            DropTable("dbo.Workers");
            DropTable("dbo.Finders");
            DropTable("dbo.Obtainings");
            DropTable("dbo.Findings");
            DropTable("dbo.Extradictions");
            DropTable("dbo.ExtradictionsAudits");
        }
    }
}
