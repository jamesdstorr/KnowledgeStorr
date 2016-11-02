using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeStorr.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArticleCreated { get; set; }
        [AllowHtml]
        public string ArticleContents { get; set; }
        public int CategoryId { get; set; }
        virtual public ArticleCategory articleCategory {get; set; }
        public int SubcategoryId { get; set; }
        virtual public ArticleSubcategory articleSubcategory { get; set; }
        public int UserId { get; set; }
        virtual public User user { get; set; }

    }
}