using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using KnowledgeStorr.Models;


namespace KnowledgeStorr.Data_Access
{
    public class DataAccess : DbContext
    {
        public DataAccess() :base("KSContext")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> Categories { get; set; }
        public DbSet<ArticleSubcategory> Subcategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<KnowledgeStorr.ViewModels.ArticleFilterViewModel> ArticleFilterViewModels { get; set; }
    }
}