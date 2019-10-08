namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForDatesBackToOriginal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StartDay", c => c.String());
            AlterColumn("dbo.Customers", "EndDate", c => c.String());
            AlterColumn("dbo.Customers", "ExtraPick", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ExtraPick", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "StartDay", c => c.DateTime(nullable: false));
        }
    }
}
