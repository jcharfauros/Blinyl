namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistDataTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "Wishlist_WishId", "dbo.Wishlist");
            DropIndex("dbo.ApplicationUser", new[] { "Wishlist_WishId" });
            DropColumn("dbo.ApplicationUser", "Wishlist_WishId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Wishlist_WishId", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "Wishlist_WishId");
            AddForeignKey("dbo.ApplicationUser", "Wishlist_WishId", "dbo.Wishlist", "WishId");
        }
    }
}
