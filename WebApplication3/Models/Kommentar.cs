using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Kommentarer")]
    public class Kommentar
    {
        [Key]
        public int Kom_id { get; set; }
        public string Kommentar_Tittel { get; set; }
        public string Kommentar_tekst { get; set; }

        public int Innlegg_Id { get; set; }
        public virtual Innlegg innlegg { get; set; }
    }
}