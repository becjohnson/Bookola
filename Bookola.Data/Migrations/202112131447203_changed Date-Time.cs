namespace Bookola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Magazine", "IssueDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Magazine", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}
