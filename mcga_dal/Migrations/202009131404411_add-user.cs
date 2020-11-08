namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        firstName = c.String(nullable: false, maxLength: 30),
                        lastName = c.String(nullable: false, maxLength: 30),
                        email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Role = c.Short(nullable: false),
                        Retries = c.Short(nullable: false),
                        Bloqued = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        signupDate = c.DateTime(nullable: false),
                        createdOn = c.DateTime(nullable: false),
                        createdBy = c.Guid(),
                        changedOn = c.DateTime(nullable: false),
                        changedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
