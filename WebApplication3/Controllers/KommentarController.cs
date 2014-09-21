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
        private IBloggRepository blogR;

        public KommentarController()
        {
            blogR = new BloggRepository();
        }
        public KommentarController(IBloggRepository repos)
        {
            blogR = repos;
        }
        public ActionResult KommentarIndex(int id)
        {
            ViewBag.innleggId = id;

            Innlegg innlegg = blogR.GetInnlegg(id);
            return View(new InnleggMedKommentarer(innlegg));
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
                    kommentar.Innlegg_Id = id;
                    if(blogR.CreateKommentar(kommentar))
                        return RedirectToAction("KommentarIndex", new { id = id });

                }
                return View();
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
            return View(blogR.SeKommentar(id));
        }

        // POST: Kommentar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Kommentar kommentar)
        {
            try
            {
                int _id = blogR.SeKommentar(id).Innlegg_Id;
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    if (blogR.DeleteKommentar(kommentar, id))
                        return RedirectToAction("KommentarIndex", new { id = _id });

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
