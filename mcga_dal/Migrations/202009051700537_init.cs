namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        firstName = c.String(nullable: false, maxLength: 30),
                        lastName = c.String(nullable: false, maxLength: 30),
                        lifeSpan = c.String(maxLength: 30),
                        country = c.String(maxLength: 30),
                        description = c.String(maxLength: 2000),
                        totalProducts = c.Int(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        title = c.String(nullable: false, maxLength: 100),
                        description = c.String(maxLength: 250),
                        artistId = c.Guid(nullable: false),
                        image = c.String(maxLength: 30),
                        price = c.Double(nullable: false),
                        quantitySold = c.Int(nullable: false),
                        avgStars = c.Double(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Artists", t => t.artistId, cascadeDelete: true)
                .Index(t => t.artistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "artistId", "dbo.Artists");
            DropIndex("dbo.Products", new[] { "artistId" });
            DropTable("dbo.Products");
            DropTable("dbo.Artists");
        }
    }
}
