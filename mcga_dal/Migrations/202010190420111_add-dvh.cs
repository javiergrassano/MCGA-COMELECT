namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddvh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditDVH",
                c => new
                    {
                        tableName = c.String(nullable: false, maxLength: 40),
                        id = c.String(nullable: false, maxLength: 40),
                        dv = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => new { t.tableName, t.id });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditDVH");
        }
    }
}
