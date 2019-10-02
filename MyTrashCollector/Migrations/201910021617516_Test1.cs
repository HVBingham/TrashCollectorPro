namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "UserId");
            CreateIndex("dbo.Employees", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Customers", "UserId");
        }
    }
}
