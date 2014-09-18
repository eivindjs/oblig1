using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Blogger")]
    public class Blogg
    {
        [Key]
        public int Blogg_Id { get; set; }
        public string Blogg_tekst { get; set; }
        public DateTime dato { get; set; }

       public virtual List<Innlegg> Innlegger { get; set; }
    }
}