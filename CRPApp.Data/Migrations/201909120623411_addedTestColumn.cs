namespace CRPApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTestColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CRPOnsiteStatus", "test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CRPOnsiteStatus", "test");
        }
    }
}
