using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeStorr.ViewModels
{
    public class ArticleFilterViewModel
    {
        public int Id { get; set; }
        public List<Models.ArticleCategory> categories { get; set; }
        public List<Models.ArticleSubcategory> subcategories { get; set; }

    }
}