namespace PlayOn24Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        DeliveryDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.ProductId);
                Sql(@"CREATE PROC getcustomerid @name NVARCHAR(50), @address NVARCHAR(150)
                    AS
                    DECLARE @id INT
                    IF EXISTS ( SELECT 1 FROM Customers WHERE CustomerName = @name)
                    BEGIN
	                    SELECT @id=CustomerId FROM Customers WHERE CustomerName = @name
	                    UPDATE Customers SET [Address]=@address
	                    WHERE CustomerId=@id
                    END
                    ELSE
                    BEGIN
	                    INSERT INTO Customers (CustomerName, [Address]) VALUES (@name, @address)
	                    SET @id = SCOPE_IDENTITY()
                    END
                    RETURN @id");

        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.getcustomerid");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            
        }
    }
}
