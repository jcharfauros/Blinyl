namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WishlistToy", "Wishlist_WishId", "dbo.Wishlist");
            DropForeignKey("dbo.WishlistToy", "Toy_ToyId", "dbo.Toy");
            DropIndex("dbo.WishlistToy", new[] { "Wishlist_WishId" });
            DropIndex("dbo.WishlistToy", new[] { "Toy_ToyId" });
            DropTable("dbo.WishlistToy");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WishlistToy",
                c => new
                    {
                        Wishlist_WishId = c.Int(nullable: false),
                        Toy_ToyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wishlist_WishId, t.Toy_ToyId });
            
            CreateIndex("dbo.WishlistToy", "Toy_ToyId");
            CreateIndex("dbo.WishlistToy", "Wishlist_WishId");
            AddForeignKey("dbo.WishlistToy", "Toy_ToyId", "dbo.Toy", "ToyId", cascadeDelete: true);
            AddForeignKey("dbo.WishlistToy", "Wishlist_WishId", "dbo.Wishlist", "WishId", cascadeDelete: true);
        }
    }
}
