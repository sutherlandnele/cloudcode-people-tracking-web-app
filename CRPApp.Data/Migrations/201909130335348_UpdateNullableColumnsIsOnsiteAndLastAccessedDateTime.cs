namespace CRPApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNullableColumnsIsOnsiteAndLastAccessedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CRPOnsiteStatus", "IsOnsite", c => c.Boolean());
            AlterColumn("dbo.CRPOnsiteStatus", "LastCRPDoorAccessedDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CRPOnsiteStatus", "LastCRPDoorAccessedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CRPOnsiteStatus", "IsOnsite", c => c.Boolean(nullable: false));
        }
    }
}
