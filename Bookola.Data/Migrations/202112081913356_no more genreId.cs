namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nomoregenreId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Book", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "GenreId", c => c.Int(nullable: false));
        }
    }
}
