namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FistMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        FullName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Isbn = c.Long(nullable: false),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GraphicNovel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Volume = c.Int(nullable: false),
                        Isbn = c.Long(nullable: false),
                        IssuedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Magazine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Volume = c.Int(nullable: false),
                        IssueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_AuthorId })
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "dbo.GraphicNovelAuthor",
                c => new
                    {
                        GraphicNovel_Id = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GraphicNovel_Id, t.Author_AuthorId })
                .ForeignKey("dbo.GraphicNovel", t => t.GraphicNovel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.GraphicNovel_Id)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "dbo.MagazineAuthor",
                c => new
                    {
                        Magazine_Id = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Magazine_Id, t.Author_AuthorId })
                .ForeignKey("dbo.Magazine", t => t.Magazine_Id, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Magazine_Id)
                .Index(t => t.Author_AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.MagazineAuthor", "Author_AuthorId", "dbo.Author");
            DropForeignKey("dbo.MagazineAuthor", "Magazine_Id", "dbo.Magazine");
            DropForeignKey("dbo.GraphicNovelAuthor", "Author_AuthorId", "dbo.Author");
            DropForeignKey("dbo.GraphicNovelAuthor", "GraphicNovel_Id", "dbo.GraphicNovel");
            DropForeignKey("dbo.BookAuthor", "Author_AuthorId", "dbo.Author");
            DropForeignKey("dbo.BookAuthor", "Book_Id", "dbo.Book");
            DropIndex("dbo.MagazineAuthor", new[] { "Author_AuthorId" });
            DropIndex("dbo.MagazineAuthor", new[] { "Magazine_Id" });
            DropIndex("dbo.GraphicNovelAuthor", new[] { "Author_AuthorId" });
            DropIndex("dbo.GraphicNovelAuthor", new[] { "GraphicNovel_Id" });
            DropIndex("dbo.BookAuthor", new[] { "Author_AuthorId" });
            DropIndex("dbo.BookAuthor", new[] { "Book_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.MagazineAuthor");
            DropTable("dbo.GraphicNovelAuthor");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Magazine");
            DropTable("dbo.GraphicNovel");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
