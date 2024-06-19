namespace CRPApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedTestColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CRPOnsiteStatus", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CRPOnsiteStatus", "test", c => c.String());
        }
    }
}
