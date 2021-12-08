namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Author", "GenreName", "dbo.Genre");
            DropForeignKey("dbo.Book", "GenreName", "dbo.Genre");
            DropForeignKey("dbo.GraphicNovel", "GenreName", "dbo.Genre");
            DropForeignKey("dbo.Magazine", "GenreName", "dbo.Genre");
            RenameColumn(table: "dbo.Author", name: "Name", newName: "GenreName");
            RenameColumn(table: "dbo.Book", name: "Name", newName: "GenreName");
            RenameColumn(table: "dbo.GraphicNovel", name: "Name", newName: "GenreName");
            RenameColumn(table: "dbo.Magazine", name: "Name", newName: "GenreName");
            RenameIndex(table: "dbo.Author", name: "IX_Name", newName: "IX_GenreName");
            RenameIndex(table: "dbo.Book", name: "IX_Name", newName: "IX_GenreName");
            RenameIndex(table: "dbo.GraphicNovel", name: "IX_Name", newName: "IX_GenreName");
            RenameIndex(table: "dbo.Magazine", name: "IX_Name", newName: "IX_GenreName");
            DropPrimaryKey("dbo.Genre");
            AddColumn("dbo.Genre", "GenreName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Genre", "GenreName");
            AddForeignKey("dbo.Author", "GenreName", "dbo.Genre", "GenreName");
            AddForeignKey("dbo.Book", "GenreName", "dbo.Genre", "GenreName");
            AddForeignKey("dbo.GraphicNovel", "GenreName", "dbo.Genre", "GenreName", cascadeDelete: true);
            AddForeignKey("dbo.Magazine", "GenreName", "dbo.Genre", "GenreName");
            DropColumn("dbo.Genre", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Magazine", "GenreName", "dbo.Genre");
            DropForeignKey("dbo.GraphicNovel", "GenreName", "dbo.Genre");
            DropForeignKey("dbo.Book", "GenreName", "dbo.Genre");
            DropForeignKey("dbo.Author", "GenreName", "dbo.Genre");
            DropPrimaryKey("dbo.Genre");
            DropColumn("dbo.Genre", "GenreName");
            AddPrimaryKey("dbo.Genre", "Name");
            RenameIndex(table: "dbo.Magazine", name: "IX_GenreName", newName: "IX_Name");
            RenameIndex(table: "dbo.GraphicNovel", name: "IX_GenreName", newName: "IX_Name");
            RenameIndex(table: "dbo.Book", name: "IX_GenreName", newName: "IX_Name");
            RenameIndex(table: "dbo.Author", name: "IX_GenreName", newName: "IX_Name");
            RenameColumn(table: "dbo.Magazine", name: "GenreName", newName: "Name");
            RenameColumn(table: "dbo.GraphicNovel", name: "GenreName", newName: "Name");
            RenameColumn(table: "dbo.Book", name: "GenreName", newName: "Name");
            RenameColumn(table: "dbo.Author", name: "GenreName", newName: "Name");
            AddForeignKey("dbo.Magazine", "GenreName", "dbo.Genre", "GenreName");
            AddForeignKey("dbo.GraphicNovel", "GenreName", "dbo.Genre", "GenreName", cascadeDelete: true);
            AddForeignKey("dbo.Book", "GenreName", "dbo.Genre", "GenreName");
            AddForeignKey("dbo.Author", "GenreName", "dbo.Genre", "GenreName");
        }
    }
}
