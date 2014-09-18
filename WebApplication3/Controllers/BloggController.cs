using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BloggController : Controller
    {
        //private Blogg blogg = new Blogg();
        //private Innlegg innlegg = new Innlegg();
        private DbModel db = new DbModel();
        // GET: Blogg
        public ActionResult Index()
        {
            var blogger = db.Blogger;
            return View(blogger);
        }

        // GET: Blogg/Details/5
        public ActionResult SeBlogg(int id)
        {
            var inlegg = db.Innlegger.
                Include("Blogger").
                Where(b=> b.Blogg_Id == id);
            return View(inlegg);
        }

        // GET: Blogg/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Blogg/Create
        [HttpPost]
        public ActionResult Create(Blogg b)
        {
            try
            {
                // TODO: Add insert logic here
                  var blogg = new Blogg
                  {
                      Blogg_tekst = b.Blogg_tekst,
                      dato = DateTime.Now
                  };

                  db.Blogger.Add(blogg);
                  db.SaveChanges(); 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogg/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blogg/Edit/5
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

        // GET: Blogg/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blogg/Delete/5
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
