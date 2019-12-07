namespace Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AboutImage = c.String(nullable: false, maxLength: 250),
                        İconimg = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllMarket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarketName = c.String(maxLength: 50),
                        Image = c.String(maxLength: 800),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        Price = c.Double(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Discount_price = c.Double(),
                        İconimg = c.String(maxLength: 50),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        subCategoryId = c.Int(),
                        MarketId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategory", t => t.subCategoryId)
                .ForeignKey("dbo.AllMarket", t => t.MarketId)
                .Index(t => t.subCategoryId)
                .Index(t => t.MarketId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        UserId = c.Int(),
                        PurchaseDate = c.DateTime(),
                        Amount = c.Int(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        İd = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.İd)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        İd = c.Int(nullable: false, identity: true),
                        slide = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.İd);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "MarketId", "dbo.AllMarket");
            DropForeignKey("dbo.Product", "subCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Orders", "UserId", "dbo.User");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Product");
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "MarketId" });
            DropIndex("dbo.Product", new[] { "subCategoryId" });
            DropTable("dbo.Slide");
            DropTable("dbo.Contact");
            DropTable("dbo.Category");
            DropTable("dbo.SubCategory");
            DropTable("dbo.User");
            DropTable("dbo.Orders");
            DropTable("dbo.Product");
            DropTable("dbo.AllMarket");
            DropTable("dbo.Admin");
            DropTable("dbo.AboutUs");
        }
    }
}
