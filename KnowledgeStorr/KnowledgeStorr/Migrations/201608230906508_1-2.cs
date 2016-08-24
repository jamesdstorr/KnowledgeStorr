namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
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
            
            AddColumn("dbo.ArticleCategory", "ArticleFilterViewModel_Id", c => c.Int());
            AddColumn("dbo.ArticleSubcategory", "ArticleFilterViewModel_Id", c => c.Int());
            CreateIndex("dbo.ArticleCategory", "ArticleFilterViewModel_Id");
            CreateIndex("dbo.ArticleSubcategory", "ArticleFilterViewModel_Id");
            AddForeignKey("dbo.ArticleCategory", "ArticleFilterViewModel_Id", "dbo.ArticleFilterViewModel", "Id");
            AddForeignKey("dbo.ArticleSubcategory", "ArticleFilterViewModel_Id", "dbo.ArticleFilterViewModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleSubcategory", "ArticleFilterViewModel_Id", "dbo.ArticleFilterViewModel");
            DropForeignKey("dbo.ArticleCategory", "ArticleFilterViewModel_Id", "dbo.ArticleFilterViewModel");
            DropIndex("dbo.ArticleSubcategory", new[] { "ArticleFilterViewModel_Id" });
            DropIndex("dbo.ArticleCategory", new[] { "ArticleFilterViewModel_Id" });
            DropColumn("dbo.ArticleSubcategory", "ArticleFilterViewModel_Id");
            DropColumn("dbo.ArticleCategory", "ArticleFilterViewModel_Id");
            DropTable("dbo.ArticleFilterViewModel");
        }
    }
}
