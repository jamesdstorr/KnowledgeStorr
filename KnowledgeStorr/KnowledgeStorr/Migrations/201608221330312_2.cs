namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Article", "articleCategory_CategoryId", "dbo.ArticleCategory");
            DropForeignKey("dbo.Article", "articleSubcategory_SubcategoryId", "dbo.ArticleSubcategory");
            DropForeignKey("dbo.Article", "user_Id", "dbo.User");
            DropIndex("dbo.Article", new[] { "articleCategory_CategoryId" });
            DropIndex("dbo.Article", new[] { "articleSubcategory_SubcategoryId" });
            RenameColumn(table: "dbo.Article", name: "articleCategory_CategoryId", newName: "CategoryId");
            RenameColumn(table: "dbo.Article", name: "articleSubcategory_SubcategoryId", newName: "SubcategoryId");
            RenameColumn(table: "dbo.Article", name: "user_Id", newName: "user_UserId");
            RenameIndex(table: "dbo.Article", name: "IX_user_Id", newName: "IX_user_UserId");
            DropPrimaryKey("dbo.User");
            DropColumn("dbo.User", "Id");
            AddColumn("dbo.User", "UserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Article", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Article", "SubcategoryId", c => c.Int(nullable: false));            
            AddPrimaryKey("dbo.User", "UserId");
            CreateIndex("dbo.Article", "CategoryId");
            CreateIndex("dbo.Article", "SubcategoryId");
            AddForeignKey("dbo.Article", "CategoryId", "dbo.ArticleCategory", "CategoryId");
            AddForeignKey("dbo.Article", "SubcategoryId", "dbo.ArticleSubcategory", "SubcategoryId");
            AddForeignKey("dbo.Article", "user_UserId", "dbo.User", "UserId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Article", "user_UserId", "dbo.User");
            DropForeignKey("dbo.Article", "SubcategoryId", "dbo.ArticleSubcategory");
            DropForeignKey("dbo.Article", "CategoryId", "dbo.ArticleCategory");
            DropIndex("dbo.Article", new[] { "SubcategoryId" });
            DropIndex("dbo.Article", new[] { "CategoryId" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.Article", "SubcategoryId", c => c.Int());
            AlterColumn("dbo.Article", "CategoryId", c => c.Int());
            DropColumn("dbo.User", "UserId");
            AddPrimaryKey("dbo.User", "Id");
            RenameIndex(table: "dbo.Article", name: "IX_user_UserId", newName: "IX_user_Id");
            RenameColumn(table: "dbo.Article", name: "user_UserId", newName: "user_Id");
            RenameColumn(table: "dbo.Article", name: "SubcategoryId", newName: "articleSubcategory_SubcategoryId");
            RenameColumn(table: "dbo.Article", name: "CategoryId", newName: "articleCategory_CategoryId");
            CreateIndex("dbo.Article", "articleSubcategory_SubcategoryId");
            CreateIndex("dbo.Article", "articleCategory_CategoryId");
            AddForeignKey("dbo.Article", "user_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Article", "articleSubcategory_SubcategoryId", "dbo.ArticleSubcategory", "SubcategoryId");
            AddForeignKey("dbo.Article", "articleCategory_CategoryId", "dbo.ArticleCategory", "CategoryId");
        }
    }
}
