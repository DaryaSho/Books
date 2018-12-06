namespace АРМ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookAvtor = c.String(),
                        BookPhoto = c.String(),
                        BookDescrip = c.String(),
                        PublicationId = c.Int(nullable: false),
                        StyleId = c.Int(nullable: false),
                        CategorId = c.Int(nullable: false),
                        BookPrice = c.Int(nullable: false),
                        PublicatiomYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategorName = c.String(),
                        CategorDescrip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Losses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BookCount = c.Int(nullable: false),
                        Why = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publicats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicatName = c.String(),
                        PublicatDescrip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        SaleData = c.DateTime(nullable: false),
                        Amout = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BookCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StyleName = c.String(),
                        StyleDescrip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Adress = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Photo = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Styles");
            DropTable("dbo.Stocks");
            DropTable("dbo.Sales");
            DropTable("dbo.Publicats");
            DropTable("dbo.Losses");
            DropTable("dbo.Categors");
            DropTable("dbo.Buyers");
            DropTable("dbo.Books");
        }
    }
}
