using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeStorr.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set;}

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public  string  Email { get; set; }

    }
}