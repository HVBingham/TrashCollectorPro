namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreToCustomerDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDay", c => c.String());
            AddColumn("dbo.Customers", "EndDate", c => c.String());
            AddColumn("dbo.Customers", "ExtraPick", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExtraPick");
            DropColumn("dbo.Customers", "EndDate");
            DropColumn("dbo.Customers", "StartDay");
        }
    }
}
