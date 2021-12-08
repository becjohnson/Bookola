namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Id = c.Int(nullable: false),
                        LastName = c.String(maxLength: 50),
                        UserId = c.Guid(nullable: false),
                        FullName = c.String(),
                        Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FirstName)
                .ForeignKey("dbo.Genre", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        LastName = c.String(maxLength: 50),
                        Name = c.String(maxLength: 128),
                        CountryCode = c.Int(nullable: false),
                        ReadingLevel = c.Int(nullable: false),
                        Isbn = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Title)
                .ForeignKey("dbo.Author", t => t.LastName)
                .ForeignKey("dbo.Genre", t => t.Name)
                .Index(t => t.LastName)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.GraphicNovel",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        LastName = c.String(maxLength: 50),
                        Isbn = c.Long(nullable: false),
                        CountryCode = c.Int(nullable: false),
                        IssuedDate = c.DateTime(nullable: false),
                        ReadingLevel = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Title)
                .ForeignKey("dbo.Author", t => t.LastName)
                .ForeignKey("dbo.Genre", t => t.Name, cascadeDelete: true)
                .Index(t => t.LastName)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Magazine",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Volume = c.Int(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Countrycode = c.Int(nullable: false),
                        ReadingLevel = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ISSN = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Title)
                .ForeignKey("dbo.Author", t => t.LastName, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.Name)
                .Index(t => t.LastName)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Magazine", "Name", "dbo.Genre");
            DropForeignKey("dbo.Magazine", "LastName", "dbo.Author");
            DropForeignKey("dbo.GraphicNovel", "Name", "dbo.Genre");
            DropForeignKey("dbo.GraphicNovel", "LastName", "dbo.Author");
            DropForeignKey("dbo.Book", "Name", "dbo.Genre");
            DropForeignKey("dbo.Author", "Name", "dbo.Genre");
            DropForeignKey("dbo.Book", "LastName", "dbo.Author");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Magazine", new[] { "Name" });
            DropIndex("dbo.Magazine", new[] { "LastName" });
            DropIndex("dbo.GraphicNovel", new[] { "Name" });
            DropIndex("dbo.GraphicNovel", new[] { "LastName" });
            DropIndex("dbo.Book", new[] { "Name" });
            DropIndex("dbo.Book", new[] { "LastName" });
            DropIndex("dbo.Author", new[] { "Name" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Magazine");
            DropTable("dbo.GraphicNovel");
            DropTable("dbo.Genre");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
