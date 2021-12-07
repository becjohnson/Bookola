namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creat : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Book");
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        LastName = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.LastName);
            
            AddColumn("dbo.Book", "FullName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Book", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "Title", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Book", "Title");
            CreateIndex("dbo.Book", "FullName");
            AddForeignKey("dbo.Book", "FullName", "dbo.Author", "LastName", cascadeDelete: true);
            DropColumn("dbo.Book", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Author", c => c.String(nullable: false));
            DropForeignKey("dbo.Book", "FullName", "dbo.Author");
            DropIndex("dbo.Book", new[] { "FullName" });
            DropPrimaryKey("dbo.Book");
            AlterColumn("dbo.Book", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Book", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Book", "FullName");
            DropTable("dbo.Author");
            AddPrimaryKey("dbo.Book", "Id");
        }
    }
}
