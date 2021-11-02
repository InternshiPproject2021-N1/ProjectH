namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterela5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Employees_EmpId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "Employees_EmpId" });
            DropColumn("dbo.Projects", "Employees_EmpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Employees_EmpId", c => c.Int());
            CreateIndex("dbo.Projects", "Employees_EmpId");
            AddForeignKey("dbo.Projects", "Employees_EmpId", "dbo.Employees", "EmpId");
        }
    }
}
