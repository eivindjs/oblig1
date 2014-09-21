using System;
using System.Linq;
using System.Collections.Generic;
namespace WebApplication3.Models
{
    public interface IBloggRepository
    {
        IEnumerable<Blogg> AlleBlogger();
        bool CreateBlogg(Blogg blogg);
        bool CreateInnlegg(Innlegg innlegg);
        bool CreateKommentar(Kommentar kommentar);
        bool DeleteBlogg(Blogg blogg, int id);
        bool DeleteInnlegg(Innlegg innlegg, int id);
        bool DeleteKommentar(Kommentar kommentar, int id);
        Innlegg GetInnlegg(int id);
        Innlegg GetInnleggMedKommentarer(int id);
        Blogg SeBloggen(int id);
        Innlegg SeeBloggInnlegg(int id);
        Innlegg SeInnlegg(int id);
        Kommentar SeKommentar(int id);
        bool UpdateBlogg(Blogg blogg);
        bool UpdateInnlegg(Innlegg innlegg);
    }
}
