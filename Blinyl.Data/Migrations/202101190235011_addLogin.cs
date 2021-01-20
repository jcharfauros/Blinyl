namespace Blinyl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLogin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Toy", "Toys_ToyId", "dbo.Toy");
            DropIndex("dbo.Toy", new[] { "Toys_ToyId" });
            DropColumn("dbo.Toy", "Toys_ToyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Toy", "Toys_ToyId", c => c.Int());
            CreateIndex("dbo.Toy", "Toys_ToyId");
            AddForeignKey("dbo.Toy", "Toys_ToyId", "dbo.Toy", "ToyId");
        }
    }
}
