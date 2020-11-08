namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixusers2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "signupDate", c => c.DateTime());
            AlterColumn("dbo.Users", "tokenExpiration", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "tokenExpiration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "signupDate", c => c.DateTime(nullable: false));
        }
    }
}
