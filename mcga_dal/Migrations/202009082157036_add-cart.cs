namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartsItems",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        cartId = c.Guid(nullable: false),
                        productId = c.Guid(nullable: false),
                        price = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carts", t => t.cartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.cartId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        cookie = c.String(nullable: false, maxLength: 40),
                        cartDate = c.DateTime(nullable: false),
                        itemCount = c.Int(nullable: false),
                        total = c.Double(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartsItems", "productId", "dbo.Products");
            DropForeignKey("dbo.CartsItems", "cartId", "dbo.Carts");
            DropIndex("dbo.CartsItems", new[] { "productId" });
            DropIndex("dbo.CartsItems", new[] { "cartId" });
            DropTable("dbo.Carts");
            DropTable("dbo.CartsItems");
        }
    }
}
