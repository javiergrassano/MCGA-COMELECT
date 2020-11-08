namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        userId = c.Int(),
                        logType = c.Short(nullable: false),
                        logDate = c.DateTime(nullable: false),
                        ipAddress = c.String(maxLength: 40),
                        userAgent = c.String(),
                        exception = c.String(),
                        message = c.String(),
                        everything = c.String(),
                        httpReferer = c.String(maxLength: 500),
                        pathAndQuery = c.String(maxLength: 500),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrdersDetails",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        orderId = c.Guid(nullable: false),
                        productId = c.Guid(nullable: false),
                        price = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.orderId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        userId = c.Guid(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        orderNumber = c.Int(nullable: false),
                        methodOfPayment = c.Short(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        itemCount = c.Int(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderNumber",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        number = c.Int(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersDetails", "productId", "dbo.Products");
            DropForeignKey("dbo.OrdersDetails", "orderId", "dbo.Orders");
            DropIndex("dbo.OrdersDetails", new[] { "productId" });
            DropIndex("dbo.OrdersDetails", new[] { "orderId" });
            DropTable("dbo.OrderNumber");
            DropTable("dbo.Orders");
            DropTable("dbo.OrdersDetails");
            DropTable("dbo.Logs");
        }
    }
}
