namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _240816 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Article", "user_UserId", "dbo.User");
            DropIndex("dbo.Article", new[] { "user_UserId" });
            RenameColumn(table: "dbo.Article", name: "user_UserId", newName: "UserId");
            AlterColumn("dbo.Article", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Article", "UserId");
            AddForeignKey("dbo.Article", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "UserId", "dbo.User");
            DropIndex("dbo.Article", new[] { "UserId" });
            AlterColumn("dbo.Article", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Article", name: "UserId", newName: "user_UserId");
            CreateIndex("dbo.Article", "user_UserId");
            AddForeignKey("dbo.Article", "user_UserId", "dbo.User", "UserId");
        }
    }
}
