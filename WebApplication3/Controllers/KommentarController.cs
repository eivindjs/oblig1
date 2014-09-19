using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class KommentarController : Controller
    {
        // GET: Kommentar
        private DbModel db = new DbModel();
        private BloggRepository blogR;

        public KommentarController()
        {
            blogR = new BloggRepository();
        }
        public ActionResult KommentarIndex(string id)
        {
            int _id = Convert.ToInt32(id);
            ViewBag.innleggId = id;

            Innlegg ii = blogR.GetInnlegg(_id);
            return View(new InnleggMedKommentarer(ii));
        }

        // GET: Kommentar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kommentar/Create
        public ActionResult Create(string id)
        {
            var kommentar = new Kommentar();
            kommentar.Innlegg_Id = Convert.ToInt32(id);
            return View(kommentar);
        }

        // POST: Kommentar/Create
        [HttpPost]
        public ActionResult Create(Kommentar kommentar, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var komment = new Kommentar
                    {
                        Kommentar_Tittel = kommentar.Kommentar_Tittel,
                        Kommentar_tekst = kommentar.Kommentar_tekst,
                        Innlegg_Id = id
                    };
                    db.Kommentarer.Add(komment);
                    db.SaveChanges();
                }
                return RedirectToAction("KommentarIndex", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Kommentar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kommentar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kommentar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kommentar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
