namespace DemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfulltable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        Contents = c.String(maxLength: 1000),
                        ConstractType = c.String(maxLength: 100),
                        SignDate = c.DateTime(nullable: false),
                        EmpId = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Role_RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Contracts", "EmpId", "dbo.Employees");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "User_UserId" });
            DropIndex("dbo.Contracts", new[] { "EmpId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Contracts");
        }
    }
}
