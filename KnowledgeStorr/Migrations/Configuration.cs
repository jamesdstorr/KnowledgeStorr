namespace KnowledgeStorr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KnowledgeStorr.Data_Access.DataAccess>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KnowledgeStorr.Data_Access.DataAccess context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Models.ArticleCategory category = new Models.ArticleCategory();
            category.CategoryId=1;
            category.CategoryName="All";
            context.Categories.AddOrUpdate(category);
            Models.ArticleSubcategory subcategory = new Models.ArticleSubcategory();
            subcategory.SubcategoryId = 1;
            subcategory.CategoryId = 1;
            subcategory.SubcategoryName = "All";
            context.Subcategories.AddOrUpdate(subcategory);
            context.SaveChanges();
        }
    }
}
