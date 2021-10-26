namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Address = c.String(maxLength: 150),
                        Email = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        Status = c.String(maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        Rank = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.EmpId);
            
            CreateTable(
                "dbo.ProjectDetails",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpId, t.ProjectId })
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmpId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        TeamSize = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectDetails", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectDetails", "EmpId", "dbo.Employees");
            DropIndex("dbo.ProjectDetails", new[] { "ProjectId" });
            DropIndex("dbo.ProjectDetails", new[] { "EmpId" });
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectDetails");
            DropTable("dbo.Employees");
        }
    }
}
