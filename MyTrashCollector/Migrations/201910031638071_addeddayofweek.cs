namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddayofweek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Day");
        }
    }
}
