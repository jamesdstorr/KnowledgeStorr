namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleFilterViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ArticleFilterViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.ArticleFilterViewModel", t => t.ArticleFilterViewModel_Id)
                .Index(t => t.ArticleFilterViewModel_Id);
            
            CreateTable(
                "dbo.ArticleSubcategory",
                c => new
                    {
                        SubcategoryId = c.Int(nullable: false, identity: true),
                        SubcategoryName = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ArticleFilterViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SubcategoryId)
                .ForeignKey("dbo.ArticleCategory", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ArticleFilterViewModel", t => t.ArticleFilterViewModel_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.ArticleFilterViewModel_Id);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(),
                        ArticleDescription = c.String(),
                        ArticleCreated = c.DateTime(nullable: false),
                        ArticleContents = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.ArticleCategory", t => t.CategoryId)
                .ForeignKey("dbo.ArticleSubcategory", t => t.SubcategoryId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SubcategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "UserId", "dbo.User");
            DropForeignKey("dbo.Article", "SubcategoryId", "dbo.ArticleSubcategory");
            DropForeignKey("dbo.Article", "CategoryId", "dbo.ArticleCategory");
            DropForeignKey("dbo.ArticleSubcategory", "ArticleFilterViewModel_Id", "dbo.ArticleFilterViewModel");
            DropForeignKey("dbo.ArticleSubcategory", "CategoryId", "dbo.ArticleCategory");
            DropForeignKey("dbo.ArticleCategory", "ArticleFilterViewModel_Id", "dbo.ArticleFilterViewModel");
            DropIndex("dbo.Article", new[] { "UserId" });
            DropIndex("dbo.Article", new[] { "SubcategoryId" });
            DropIndex("dbo.Article", new[] { "CategoryId" });
            DropIndex("dbo.ArticleSubcategory", new[] { "ArticleFilterViewModel_Id" });
            DropIndex("dbo.ArticleSubcategory", new[] { "CategoryId" });
            DropIndex("dbo.ArticleCategory", new[] { "ArticleFilterViewModel_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Article");
            DropTable("dbo.ArticleSubcategory");
            DropTable("dbo.ArticleCategory");
            DropTable("dbo.ArticleFilterViewModel");
        }
    }
}
