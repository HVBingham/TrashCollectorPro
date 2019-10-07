namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbooleanforpickups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PickUpConfimation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "PickUpConfimation");
        }
    }
}
