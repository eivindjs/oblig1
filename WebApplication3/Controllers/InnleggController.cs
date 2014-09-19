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
        private BloggRepository bloggR;
        public InnleggController()
        {
            bloggR = new BloggRepository();
            
        }
        public ActionResult InnleggIndex(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Blogg");
            }
            else
            {
                var innlegg = db.Innlegger.Where(i => i.Blogg_Id == id);
                ViewBag.bloggId = id;
                return View(innlegg);
            }
        }

        // GET: Innlegg/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Innlegg/Create
        public ActionResult Opprett(int id)
        {
            var innlegg = new Innlegg();
            innlegg.Blogg_Id = id;
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
                    innlegg.Blogg_Id = id;
                    bloggR.CreateInnlegg(innlegg);
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
            return View(db.Innlegger.Find(id));
        }

        // POST: Innlegg/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Innlegg i)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    if(bloggR.UpdateInnlegg(i))
                        return RedirectToAction("InnleggIndex", new { id = i.Blogg_Id });

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Innlegg/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bloggR.SeInnlegg(id));
        }

        // POST: Innlegg/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Innlegg innlegg)
        {
            try
            {
                int blogg_id = id;
                if (ModelState.IsValid)
                {
                    if (bloggR.DeleteInnlegg(innlegg, id))
                        return RedirectToAction("InnleggIndex", blogg_id); //Må har blogg_id for å komme tilbake til rett blogg
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
