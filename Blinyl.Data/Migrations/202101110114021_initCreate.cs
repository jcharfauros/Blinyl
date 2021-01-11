namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectorsToys", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Toy", "Toys_ToyId", c => c.Int());
            AddColumn("dbo.Toy", "CollectorsToys_CollectorsToysId", c => c.Int());
            AddColumn("dbo.Toy", "Wishlist_WishId", c => c.Int());
            AddColumn("dbo.ToyImage", "ToyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Toy", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Toy", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.Toy", "Series", c => c.String(nullable: false));
            AlterColumn("dbo.Toy", "Artist", c => c.String());
            CreateIndex("dbo.Toy", "Toys_ToyId");
            CreateIndex("dbo.Toy", "CollectorsToys_CollectorsToysId");
            CreateIndex("dbo.Toy", "Wishlist_WishId");
            CreateIndex("dbo.ToyImage", "ToyId");
            AddForeignKey("dbo.Toy", "Toys_ToyId", "dbo.Toy", "ToyId");
            AddForeignKey("dbo.Toy", "CollectorsToys_CollectorsToysId", "dbo.CollectorsToys", "CollectorsToysId");
            AddForeignKey("dbo.ToyImage", "ToyId", "dbo.Toy", "ToyId", cascadeDelete: true);
            AddForeignKey("dbo.Toy", "Wishlist_WishId", "dbo.Wishlist", "WishId");
            DropColumn("dbo.CollectorsToys", "ListTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollectorsToys", "ListTitle", c => c.String(nullable: false, maxLength: 45));
            DropForeignKey("dbo.Toy", "Wishlist_WishId", "dbo.Wishlist");
            DropForeignKey("dbo.ToyImage", "ToyId", "dbo.Toy");
            DropForeignKey("dbo.Toy", "CollectorsToys_CollectorsToysId", "dbo.CollectorsToys");
            DropForeignKey("dbo.Toy", "Toys_ToyId", "dbo.Toy");
            DropIndex("dbo.ToyImage", new[] { "ToyId" });
            DropIndex("dbo.Toy", new[] { "Wishlist_WishId" });
            DropIndex("dbo.Toy", new[] { "CollectorsToys_CollectorsToysId" });
            DropIndex("dbo.Toy", new[] { "Toys_ToyId" });
            AlterColumn("dbo.Toy", "Artist", c => c.String(maxLength: 50));
            AlterColumn("dbo.Toy", "Series", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Toy", "Brand", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Toy", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ToyImage", "ToyId");
            DropColumn("dbo.Toy", "Wishlist_WishId");
            DropColumn("dbo.Toy", "CollectorsToys_CollectorsToysId");
            DropColumn("dbo.Toy", "Toys_ToyId");
            DropColumn("dbo.CollectorsToys", "Title");
        }
    }
}
