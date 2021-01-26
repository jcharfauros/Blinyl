namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Toy", "Wishlist_WishId", "dbo.Wishlist");
            DropIndex("dbo.Toy", new[] { "Wishlist_WishId" });
            CreateTable(
                "dbo.WishlistToy",
                c => new
                    {
                        Wishlist_WishId = c.Int(nullable: false),
                        Toy_ToyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wishlist_WishId, t.Toy_ToyId })
                .ForeignKey("dbo.Wishlist", t => t.Wishlist_WishId, cascadeDelete: true)
                .ForeignKey("dbo.Toy", t => t.Toy_ToyId, cascadeDelete: true)
                .Index(t => t.Wishlist_WishId)
                .Index(t => t.Toy_ToyId);
            
            DropColumn("dbo.Toy", "Wishlist_WishId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Toy", "Wishlist_WishId", c => c.Int());
            DropForeignKey("dbo.WishlistToy", "Toy_ToyId", "dbo.Toy");
            DropForeignKey("dbo.WishlistToy", "Wishlist_WishId", "dbo.Wishlist");
            DropIndex("dbo.WishlistToy", new[] { "Toy_ToyId" });
            DropIndex("dbo.WishlistToy", new[] { "Wishlist_WishId" });
            DropTable("dbo.WishlistToy");
            CreateIndex("dbo.Toy", "Wishlist_WishId");
            AddForeignKey("dbo.Toy", "Wishlist_WishId", "dbo.Wishlist", "WishId");
        }
    }
}
