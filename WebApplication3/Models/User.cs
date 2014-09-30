using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

       
        public virtual List<Blogg> Blogger { get; set; }


    }
}