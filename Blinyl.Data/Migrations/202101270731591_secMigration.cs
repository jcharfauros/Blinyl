namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wishlist", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Wishlist", new[] { "UserId" });
            AddColumn("dbo.Wishlist", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Wishlist", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wishlist", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Wishlist", "OwnerId");
            CreateIndex("dbo.Wishlist", "UserId");
            AddForeignKey("dbo.Wishlist", "UserId", "dbo.ApplicationUser", "Id");
        }
    }
}
