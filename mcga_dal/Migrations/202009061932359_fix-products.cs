namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixproducts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "image", c => c.String(maxLength: 30));
        }
    }
}
