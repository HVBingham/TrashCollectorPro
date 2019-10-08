namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testfordates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "StartDay");
            DropColumn("dbo.Customers", "EndDate");
            DropColumn("dbo.Customers", "ExtraPick");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ExtraPick", c => c.String());
            AddColumn("dbo.Customers", "EndDate", c => c.String());
            AddColumn("dbo.Customers", "StartDay", c => c.String());
        }
    }
}
