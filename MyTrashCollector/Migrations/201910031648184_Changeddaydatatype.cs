namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeddaydatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Day", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Day", c => c.Int(nullable: false));
        }
    }
}
