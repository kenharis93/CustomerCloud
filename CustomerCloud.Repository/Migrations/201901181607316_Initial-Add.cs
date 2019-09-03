namespace CustomerCloud.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerEntity_Id)
                .Index(t => t.CustomerEntity_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Product_Id = c.Guid(),
                        OrderEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Orders", t => t.OrderEntity_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.OrderEntity_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerEntity_Id", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderEntity_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.OrderDetails", new[] { "OrderEntity_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerEntity_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
