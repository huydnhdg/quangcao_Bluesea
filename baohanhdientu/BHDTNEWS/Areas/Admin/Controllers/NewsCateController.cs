using BHDTNEWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BHDTNEWS.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsCateController : Controller
    {
        private BHDTNEWSEntities db = new BHDTNEWSEntities();
        public ActionResult Index()
        {
            var model = db.NewsCates.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] NewsCate newscate)
        {
            if (ModelState.IsValid)
            {
                newscate.Createdate = DateTime.Now;
                db.NewsCates.Add(newscate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newscate);

        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCate newscate = db.NewsCates.Find(id);
            if (newscate == null)
            {
                return HttpNotFound();
            }
            return View(newscate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] NewsCate newscate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newscate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newscate);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCate newscate = db.NewsCates.Find(id);
            if (newscate == null)
            {
                return HttpNotFound();
            }
            return View(newscate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            NewsCate newscate = db.NewsCates.Find(id);
            db.NewsCates.Remove(newscate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}