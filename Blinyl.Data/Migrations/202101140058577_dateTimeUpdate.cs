namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CollectorsToys", "CreateUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CollectorsToys", "ModifiedUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CollectorsToys", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.CollectorsToys", "CreateUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
