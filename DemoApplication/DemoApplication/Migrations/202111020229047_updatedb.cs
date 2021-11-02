namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropPrimaryKey("dbo.Roles");
            DropPrimaryKey("dbo.UserRoles");
            AlterColumn("dbo.Roles", "RoleId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserRoles", "Role_RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Roles", "RoleId");
            AddPrimaryKey("dbo.UserRoles", new[] { "User_UserId", "Role_RoleId" });
            CreateIndex("dbo.UserRoles", "Role_RoleId");
            AddForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropPrimaryKey("dbo.UserRoles");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.UserRoles", "Role_RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Roles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserRoles", new[] { "User_UserId", "Role_RoleId" });
            AddPrimaryKey("dbo.Roles", "RoleId");
            CreateIndex("dbo.UserRoles", "Role_RoleId");
            AddForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
    }
}
