namespace onlinePharmacyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Mname = c.String(),
                        Price = c.Double(nullable: false),
                        itemTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MName = c.String(nullable: false),
                        MType = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        MedicineId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        MedicineName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        SubPrice = c.Double(nullable: false),
                        Orders_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Orders_OrderId)
                .Index(t => t.MedicineId)
                .Index(t => t.Orders_OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        OrderStatus = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Carts", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.OrderItems", new[] { "Orders_OrderId" });
            DropIndex("dbo.OrderItems", new[] { "MedicineId" });
            DropIndex("dbo.Carts", new[] { "MedicineId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Customers");
            DropTable("dbo.Medicines");
            DropTable("dbo.Carts");
            DropTable("dbo.Admins");
        }
    }
}
