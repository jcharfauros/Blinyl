namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCollect : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectorsToys", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.CollectorsToys", new[] { "UserId" });
            AddColumn("dbo.CollectorsToys", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.CollectorsToys", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollectorsToys", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.CollectorsToys", "OwnerId");
            CreateIndex("dbo.CollectorsToys", "UserId");
            AddForeignKey("dbo.CollectorsToys", "UserId", "dbo.ApplicationUser", "Id");
        }
    }
}
