using System;
namespace WebApplication3.Models
{
    interface IBloggRepository
    {
        bool CreateBlogg(Blogg blogg);
        bool CreateInnlegg(Innlegg innlegg);
        bool CreateKommentar(Kommentar kommentar);
        bool DeleteBlogg(Blogg blogg, int id);
        bool DeleteInnlegg(Innlegg innlegg, int id);
        bool DeleteKommentar(Kommentar kommentar, int id);
        Blogg SeBloggen(int id);
        Innlegg SeeBloggInnlegg(int id);
        Innlegg SeInnlegg(int id);
        bool UpdateBlogg(Blogg blogg);
        Innlegg GetInnleggMedKommentarer(int id);
        Innlegg GetInnlegg(int id);
    }
}
