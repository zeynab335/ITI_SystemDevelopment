namespace Customers_with_orders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        phoneNum = c.String(nullable: false, maxLength: 11),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustID, cascadeDelete: true)
                .Index(t => t.CustID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustID" });
            DropIndex("dbo.Customers", new[] { "Customer_ID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
