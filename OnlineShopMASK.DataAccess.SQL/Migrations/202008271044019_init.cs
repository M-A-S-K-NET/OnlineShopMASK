namespace OnlineShopMASK.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductRatings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Comments = c.String(),
                        ThisDateTime = c.DateTime(),
                        Rating = c.Int(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Rating", c => c.Int());
            AddColumn("dbo.Products", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Comment");
            DropColumn("dbo.Products", "Rating");
            DropTable("dbo.ProductRatings");
        }
    }
}
