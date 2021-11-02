namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterela3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectEmployees", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectEmployees", "Employees_EmpId", "dbo.Employees");
            DropIndex("dbo.ProjectEmployees", new[] { "Project_ProjectId" });
            DropIndex("dbo.ProjectEmployees", new[] { "Employees_EmpId" });
            AddColumn("dbo.Projects", "Employees_EmpId", c => c.Int());
            CreateIndex("dbo.Projects", "Employees_EmpId");
            AddForeignKey("dbo.Projects", "Employees_EmpId", "dbo.Employees", "EmpId");
            DropTable("dbo.ProjectEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        Employees_EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.Employees_EmpId });
            
            DropForeignKey("dbo.Projects", "Employees_EmpId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "Employees_EmpId" });
            DropColumn("dbo.Projects", "Employees_EmpId");
            CreateIndex("dbo.ProjectEmployees", "Employees_EmpId");
            CreateIndex("dbo.ProjectEmployees", "Project_ProjectId");
            AddForeignKey("dbo.ProjectEmployees", "Employees_EmpId", "dbo.Employees", "EmpId", cascadeDelete: true);
            AddForeignKey("dbo.ProjectEmployees", "Project_ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}
