namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2forDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "ExtraPick", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExtraPick");
            DropColumn("dbo.Customers", "EndDate");
            DropColumn("dbo.Customers", "StartDay");
        }
    }
}
