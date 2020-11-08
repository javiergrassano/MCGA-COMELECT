namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixusers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "username", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "username");
        }
    }
}
