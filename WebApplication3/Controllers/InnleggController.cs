using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class InnleggController : Controller
    {
        private DbModel db = new DbModel();
        // GET: Innlegg
        private int Bloggid;
        public ActionResult InnleggIndex(string id)
        {
            int _id = Convert.ToInt32(id);
            Bloggid = _id;
            var innlegg = db.Innlegger.Where(i => i.Blogg_Id == _id);
            ViewBag.bloggId = id;
            return View(innlegg);
        }

        // GET: Innlegg/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Innlegg/Create
        public ActionResult Opprett(string id)
        {
            var innlegg = new Innlegg();
            innlegg.Blogg_Id = Convert.ToInt32(id);
            return View(innlegg);
        }

        // POST: Innlegg/Create
        [HttpPost]
        public ActionResult Opprett(Innlegg innlegg, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    var post = new Innlegg
                    {
                        Innlegg_Tittel = innlegg.Innlegg_Tittel,
                        Innlegg_Tekst = innlegg.Innlegg_Tekst,
                        Dato = DateTime.Now,
                        Blogg_Id = id

                    };
                    db.Innlegger.Add(post);
                    db.SaveChanges();
                }
                return RedirectToAction("InnleggIndex", new { id = id });
            }

            catch
            {
                return View();
            }
        }

        // GET: Innlegg/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Innlegg/Edit/5
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

        // GET: Innlegg/Delete/5
        public ActionResult Delete(int id)
        {
            Innlegg innlegg = db.Innlegger.Find(id);
            ViewBag.innleggId = innlegg.Blogg_Id;
            return View(innlegg);
        }

        // POST: Innlegg/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Innlegg innlegg)
        {
            try
            {
                // TODO: Add delete logic here
               /* var inlegg = db.Innlegger.Where(i=> i.Innlegg_Id == id).FirstOrDefault();
                db.Innlegger.Remove(inlegg);
                db.SaveChanges(); */
                if (ModelState.IsValid)
                {
                    innlegg = db.Innlegger.Find(id);
                    db.Innlegger.Remove(innlegg);
                    db.SaveChanges();
                }
                //må ha bloggid for å komme tilbake til rett plass
                return RedirectToAction("InnleggIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
