using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeStorr.Models
{
    public class ArticleCreateViewModel 
    {
        public int Id { get; set; }
        public Article article { get; set; }
        public List<ArticleCategory> categories { get; set; }
        public List<ArticleSubcategory> subcategories { get; set; }

    }
}