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

        private DbModel db = new DbModel();
        private BloggRepository bloggR;


        public BloggController()
        {
            bloggR = new BloggRepository();
        }
        public ActionResult Index()
        {
            var blogger = db.Blogger;
            return View(blogger);
        }

        // GET: Blogg/Details/5
        public ActionResult SeBlogg(int id)
        {
            return View(bloggR.SeeBloggInnlegg(id));
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

                if (ModelState.IsValid)
                {
                    if (bloggR.CreateBlogg(b))
                        return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogg/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Blogger.Find(id));
        }

        // POST: Blogg/Edit/5
        [HttpPost]
        public ActionResult Edit(Blogg b)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (bloggR.UpdateBlogg(b))
                        return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogg/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bloggR.SeBloggen(id));
        }

        // POST: Blogg/Delete/5
        [HttpPost]
        public ActionResult Delete(Blogg b, int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    if (bloggR.DeleteBlogg(b, id))
                        return RedirectToAction("Index");
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
