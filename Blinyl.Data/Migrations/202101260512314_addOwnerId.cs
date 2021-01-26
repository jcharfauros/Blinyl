namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Toy", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Toy", "OwnerId");
        }
    }
}
