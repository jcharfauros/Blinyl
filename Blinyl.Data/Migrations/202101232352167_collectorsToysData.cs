namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collectorsToysData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectorsToys", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CollectorsToys", "UserId");
            AddForeignKey("dbo.CollectorsToys", "UserId", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectorsToys", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.CollectorsToys", new[] { "UserId" });
            DropColumn("dbo.CollectorsToys", "UserId");
        }
    }
}
