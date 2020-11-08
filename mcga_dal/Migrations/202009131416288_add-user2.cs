namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "tokenExpiration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "tokenExpiration");
        }
    }
}
