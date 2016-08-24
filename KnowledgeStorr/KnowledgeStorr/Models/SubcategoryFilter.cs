using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeStorr.Models
{
    public class SubcategoryFilter
    {
        [Key]
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
    }
}