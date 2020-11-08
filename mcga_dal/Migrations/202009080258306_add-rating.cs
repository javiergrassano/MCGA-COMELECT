namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        userId = c.Guid(nullable: false),
                        productId = c.Guid(nullable: false),
                        stars = c.Int(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "productId", "dbo.Products");
            DropIndex("dbo.Ratings", new[] { "productId" });
            DropTable("dbo.Ratings");
        }
    }
}
