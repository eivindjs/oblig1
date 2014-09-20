using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class BloggRepository : WebApplication3.Models.IBloggRepository
    {
        private DbModel db;

        public BloggRepository()
        {
            db = new DbModel();
        }

        public bool CreateBlogg(Blogg blogg)
        {
            try
            {
                blogg.dato = DateTime.Now;
                db.Blogger.Add(blogg);
                db.SaveChanges();

                return true;
            }

            catch
            {
                return false;
            }
        }
        /// <summary>
        /// For å se info om bloggen med blogg_id
        /// </summary>
        /// <param name="id">blogg_id</param>
        /// <returns></returns>
        public Blogg SeBloggen(int id)
        {
            var blogg = db.Blogger.Find(id);
            return blogg;
        }
        public List<Blogg> AlleBlogger()
        {
            List<Blogg> blogg = db.Blogger.ToList();
            return blogg;
        }
        public bool DeleteBlogg(Blogg blogg, int id)
        {
            try 
            {
                blogg = db.Blogger.Find(id);
                db.Blogger.Remove(blogg);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool UpdateBlogg(Blogg blogg)
        {
            try
            {
                blogg.dato = DateTime.Now;
                db.Entry(blogg).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }
        /// <summary>
        /// For å se alle innleggene til bloggen med en angitt blogg_id
        /// </summary>
        /// <param name="id">blogg_id</param>
        /// <returns></returns>
        public Innlegg SeeBloggInnlegg(int id)
        {
            var inlegg = db.Innlegger.
               Include("Blogger").
               Where(b => b.Blogg_Id == id).FirstOrDefault();
           
                return inlegg;
        }
        public Innlegg SeInnlegg(int id)
        {
            return db.Innlegger.Find(id);
        }
        public bool DeleteInnlegg(Innlegg innlegg, int id)
        {
            try
            {
                innlegg = db.Innlegger.Find(id);
                db.Innlegger.Remove(innlegg);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreateInnlegg(Innlegg innlegg)
        {
            try
            {
                innlegg.Dato = DateTime.Now;
                db.Innlegger.Add(innlegg);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateInnlegg(Innlegg innlegg)
        {
            try
            {
                innlegg.Dato = DateTime.Now;
                db.Entry(innlegg).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }
        public bool CreateKommentar(Kommentar kommentar)
        {
            try
            {
                db.Kommentarer.Add(kommentar);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteKommentar(Kommentar kommentar, int id)
        {
            try
            {
                kommentar = db.Kommentarer.Find(id);
                db.Kommentarer.Remove(kommentar);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Kommentar SeKommentar(int id)
        {
            return db.Kommentarer.Find(id);
        }
        public Innlegg GetInnlegg(int id)
        {
            return db.Innlegger.Include("Kommentarer").Where(i => i.Innlegg_Id == id).FirstOrDefault();
        }
        public Innlegg GetInnleggMedKommentarer(int id)
        {
            var innlegg = db.Innlegger
                .Include("Kommentarer")
                .Where(i => i.Innlegg_Id == id).FirstOrDefault();
            return innlegg;
        }
    }
}