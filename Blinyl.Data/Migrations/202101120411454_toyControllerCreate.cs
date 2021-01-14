namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class toyControllerCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Toy", "CollectorsToys_CollectorsToysId", "dbo.CollectorsToys");
            DropIndex("dbo.Toy", new[] { "CollectorsToys_CollectorsToysId" });
            DropColumn("dbo.Toy", "CollectorsToys_CollectorsToysId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Toy", "CollectorsToys_CollectorsToysId", c => c.Int());
            CreateIndex("dbo.Toy", "CollectorsToys_CollectorsToysId");
            AddForeignKey("dbo.Toy", "CollectorsToys_CollectorsToysId", "dbo.CollectorsToys", "CollectorsToysId");
        }
    }
}
