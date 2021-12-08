namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        LastName = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        FullName = c.String(),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.LastName);
            
            CreateTable(
                "dbo.GraphicNovel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 128),
                        Title = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Isbn = c.Long(nullable: false),
                        CountryCode = c.Int(nullable: false),
                        IssuedDate = c.DateTime(nullable: false),
                        ReadingLevel = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.FullName)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.FullName)
                .Index(t => t.GenreId);
            
            AddColumn("dbo.Book", "Author_LastName", c => c.String(maxLength: 128));
            AddColumn("dbo.Magazine", "Author_LastName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Book", "Author_LastName");
            CreateIndex("dbo.Magazine", "Author_LastName");
            AddForeignKey("dbo.Book", "Author_LastName", "dbo.Author", "LastName");
            AddForeignKey("dbo.Magazine", "Author_LastName", "dbo.Author", "LastName");
            DropColumn("dbo.Magazine", "AuthorId");
            DropColumn("dbo.Magazine", "Countrycode");
            DropColumn("dbo.Magazine", "ReadingLevel");
            DropColumn("dbo.Magazine", "ISSN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Magazine", "ISSN", c => c.Int(nullable: false));
            AddColumn("dbo.Magazine", "ReadingLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Magazine", "Countrycode", c => c.Int(nullable: false));
            AddColumn("dbo.Magazine", "AuthorId", c => c.String(nullable: false));
            DropForeignKey("dbo.Magazine", "Author_LastName", "dbo.Author");
            DropForeignKey("dbo.GraphicNovel", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.GraphicNovel", "FullName", "dbo.Author");
            DropForeignKey("dbo.Book", "Author_LastName", "dbo.Author");
            DropIndex("dbo.GraphicNovel", new[] { "GenreId" });
            DropIndex("dbo.GraphicNovel", new[] { "FullName" });
            DropIndex("dbo.Magazine", new[] { "Author_LastName" });
            DropIndex("dbo.Book", new[] { "Author_LastName" });
            DropColumn("dbo.Magazine", "Author_LastName");
            DropColumn("dbo.Book", "Author_LastName");
            DropTable("dbo.GraphicNovel");
            DropTable("dbo.Author");
        }
    }
}
