namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterela : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Projects_ProjectId", c => c.Int());
            CreateIndex("dbo.Employees", "Projects_ProjectId");
            AddForeignKey("dbo.Employees", "Projects_ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Projects_ProjectId", "dbo.Projects");
            DropIndex("dbo.Employees", new[] { "Projects_ProjectId" });
            DropColumn("dbo.Employees", "Projects_ProjectId");
        }
    }
}
