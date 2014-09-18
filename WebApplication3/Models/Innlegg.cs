using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Innlegger")]
    public class Innlegg
    {
        [Key]
        public int Innlegg_Id { get; set; }
        public string Innlegg_Tittel { get; set; }
        public string Innlegg_Tekst { get; set; }
        public DateTime Dato { get; set; }
        public int Blogg_Id { get; set; }

        public virtual Blogg Blogger { get; set; }
        public virtual List<Kommentar> kommentarer { get; set; }
    }
}