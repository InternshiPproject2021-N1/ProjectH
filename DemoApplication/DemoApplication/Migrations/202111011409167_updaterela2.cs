namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterela2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Projects_ProjectId", "dbo.Projects");
            DropIndex("dbo.Employees", new[] { "Projects_ProjectId" });
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        Employees_EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.Employees_EmpId })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employees_EmpId, cascadeDelete: true)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.Employees_EmpId);
            
            DropColumn("dbo.Employees", "Projects_ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Projects_ProjectId", c => c.Int());
            DropForeignKey("dbo.ProjectEmployees", "Employees_EmpId", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployees", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectEmployees", new[] { "Employees_EmpId" });
            DropIndex("dbo.ProjectEmployees", new[] { "Project_ProjectId" });
            DropTable("dbo.ProjectEmployees");
            CreateIndex("dbo.Employees", "Projects_ProjectId");
            AddForeignKey("dbo.Employees", "Projects_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
