namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticleSubcategory", "ArticleCategory_Id", "dbo.ArticleCategory");
            DropForeignKey("dbo.Article", "articleCategory_Id", "dbo.ArticleCategory");
            DropForeignKey("dbo.Article", "articleSubcategory_Id", "dbo.ArticleSubcategory");
            DropPrimaryKey("dbo.Article");
            DropPrimaryKey("dbo.ArticleCategory");
            DropPrimaryKey("dbo.ArticleSubcategory");            
            DropIndex("dbo.ArticleSubcategory", new[] { "ArticleCategory_Id" });
            DropColumn("dbo.Article", "Id");
            DropColumn("dbo.ArticleCategory", "Id");
            DropColumn("dbo.ArticleSubcategory", "Id");            
            RenameColumn(table: "dbo.Article", name: "articleCategory_Id", newName: "articleCategory_CategoryId");
            RenameColumn(table: "dbo.Article", name: "articleSubcategory_Id", newName: "articleSubcategory_SubcategoryId");
            RenameColumn(table: "dbo.ArticleSubcategory", name: "ArticleCategory_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Article", name: "IX_articleCategory_Id", newName: "IX_articleCategory_CategoryId");
            RenameIndex(table: "dbo.Article", name: "IX_articleSubcategory_Id", newName: "IX_articleSubcategory_SubcategoryId");
            
            AddColumn("dbo.Article", "ArticleId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ArticleCategory", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ArticleSubcategory", "SubcategoryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ArticleSubcategory", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Article", "ArticleId");
            AddPrimaryKey("dbo.ArticleCategory", "CategoryId");
            AddPrimaryKey("dbo.ArticleSubcategory", "SubcategoryId");
            CreateIndex("dbo.ArticleSubcategory", "CategoryId");
            AddForeignKey("dbo.ArticleSubcategory", "CategoryId", "dbo.ArticleCategory", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Article", "articleCategory_CategoryId", "dbo.ArticleCategory", "CategoryId");
            AddForeignKey("dbo.Article", "articleSubcategory_SubcategoryId", "dbo.ArticleSubcategory", "SubcategoryId");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArticleSubcategory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ArticleCategory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Article", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Article", "articleSubcategory_SubcategoryId", "dbo.ArticleSubcategory");
            DropForeignKey("dbo.Article", "articleCategory_CategoryId", "dbo.ArticleCategory");
            DropForeignKey("dbo.ArticleSubcategory", "CategoryId", "dbo.ArticleCategory");
            DropIndex("dbo.ArticleSubcategory", new[] { "CategoryId" });
            DropPrimaryKey("dbo.ArticleSubcategory");
            DropPrimaryKey("dbo.ArticleCategory");
            DropPrimaryKey("dbo.Article");
            AlterColumn("dbo.ArticleSubcategory", "CategoryId", c => c.Int());
            DropColumn("dbo.ArticleSubcategory", "SubcategoryId");
            DropColumn("dbo.ArticleCategory", "CategoryId");
            DropColumn("dbo.Article", "ArticleId");
            AddPrimaryKey("dbo.ArticleSubcategory", "Id");
            AddPrimaryKey("dbo.ArticleCategory", "Id");
            AddPrimaryKey("dbo.Article", "Id");
            RenameIndex(table: "dbo.Article", name: "IX_articleSubcategory_SubcategoryId", newName: "IX_articleSubcategory_Id");
            RenameIndex(table: "dbo.Article", name: "IX_articleCategory_CategoryId", newName: "IX_articleCategory_Id");
            RenameColumn(table: "dbo.ArticleSubcategory", name: "CategoryId", newName: "ArticleCategory_Id");
            RenameColumn(table: "dbo.Article", name: "articleSubcategory_SubcategoryId", newName: "articleSubcategory_Id");
            RenameColumn(table: "dbo.Article", name: "articleCategory_CategoryId", newName: "articleCategory_Id");
            CreateIndex("dbo.ArticleSubcategory", "ArticleCategory_Id");
            AddForeignKey("dbo.Article", "articleSubcategory_Id", "dbo.ArticleSubcategory", "Id");
            AddForeignKey("dbo.Article", "articleCategory_Id", "dbo.ArticleCategory", "Id");
            AddForeignKey("dbo.ArticleSubcategory", "ArticleCategory_Id", "dbo.ArticleCategory", "Id");
        }
    }
}
