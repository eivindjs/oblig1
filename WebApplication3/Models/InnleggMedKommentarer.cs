using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class InnleggMedKommentarer
    {
        private IBloggRepository BloggR = new BloggRepository();
        public IEnumerable<Kommentar> kommentarer = new List<Kommentar>();
        public Innlegg innlegg;

        public InnleggMedKommentarer(Innlegg innlegg)
        {
            this.innlegg = innlegg;
            BloggR.GetInnleggMedKommentarer(innlegg.Innlegg_Id);
        }
    }
}