namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrating2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "productId", "dbo.Products");
            DropIndex("dbo.Ratings", new[] { "productId" });
            DropPrimaryKey("dbo.Ratings");
            AddPrimaryKey("dbo.Ratings", new[] { "userId", "productId" });
            DropColumn("dbo.Ratings", "id");
            DropColumn("dbo.Ratings", "createdBy");
            DropColumn("dbo.Ratings", "changedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "changedBy", c => c.Guid());
            AddColumn("dbo.Ratings", "createdBy", c => c.Guid());
            AddColumn("dbo.Ratings", "id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Ratings");
            AddPrimaryKey("dbo.Ratings", "id");
            CreateIndex("dbo.Ratings", "productId");
            AddForeignKey("dbo.Ratings", "productId", "dbo.Products", "id", cascadeDelete: true);
        }
    }
}
