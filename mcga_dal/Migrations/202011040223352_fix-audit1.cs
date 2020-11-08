namespace mcga.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixaudit1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AuditDVH");
            AlterColumn("dbo.AuditDVH", "tableName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.AuditDVH", "id", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.AuditDVH", "dv", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.AuditDVH", new[] { "tableName", "id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AuditDVH");
            AlterColumn("dbo.AuditDVH", "dv", c => c.String(maxLength: 40));
            AlterColumn("dbo.AuditDVH", "id", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.AuditDVH", "tableName", c => c.String(nullable: false, maxLength: 40));
            AddPrimaryKey("dbo.AuditDVH", new[] { "tableName", "id" });
        }
    }
}
