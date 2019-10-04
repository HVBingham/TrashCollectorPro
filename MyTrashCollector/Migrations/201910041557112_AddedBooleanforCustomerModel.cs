namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBooleanforCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickConfirmed");
        }
    }
}
