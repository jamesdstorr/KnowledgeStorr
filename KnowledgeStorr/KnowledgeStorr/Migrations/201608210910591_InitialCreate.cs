namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(),
                        ArticleDescription = c.String(),
                        ArticleCreated = c.DateTime(nullable: false),
                        ArticleContents = c.String(),
                        articleCategory_Id = c.Int(),
                        articleSubcategory_Id = c.Int(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleCategory", t => t.articleCategory_Id)
                .ForeignKey("dbo.ArticleSubcategory", t => t.articleSubcategory_Id)
                .ForeignKey("dbo.User", t => t.user_Id)
                .Index(t => t.articleCategory_Id)
                .Index(t => t.articleSubcategory_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.ArticleCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleSubcategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubcategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "user_Id", "dbo.User");
            DropForeignKey("dbo.Article", "articleSubcategory_Id", "dbo.ArticleSubcategory");
            DropForeignKey("dbo.Article", "articleCategory_Id", "dbo.ArticleCategory");
            DropIndex("dbo.Article", new[] { "user_Id" });
            DropIndex("dbo.Article", new[] { "articleSubcategory_Id" });
            DropIndex("dbo.Article", new[] { "articleCategory_Id" });
            DropTable("dbo.User");
            DropTable("dbo.ArticleSubcategory");
            DropTable("dbo.ArticleCategory");
            DropTable("dbo.Article");
        }
    }
}
