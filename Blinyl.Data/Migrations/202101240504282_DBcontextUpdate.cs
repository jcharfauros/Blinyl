namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcontextUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Toy", name: "Wishlist_WishId", newName: "WishId");
            RenameIndex(table: "dbo.Toy", name: "IX_Wishlist_WishId", newName: "IX_WishId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Toy", name: "IX_WishId", newName: "IX_Wishlist_WishId");
            RenameColumn(table: "dbo.Toy", name: "WishId", newName: "Wishlist_WishId");
        }
    }
}
