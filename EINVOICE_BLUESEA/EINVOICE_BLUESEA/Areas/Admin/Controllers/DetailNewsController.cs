using EINVOICE_BLUESEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Areas.Admin.Controllers
{
    public class DetailNewsController : Controller
    {
        EINVOICE_BLUESEAEntities db = new EINVOICE_BLUESEAEntities();
        // GET: Admin/DetailNews
        public ActionResult Index()
        {
            var model = db.News.OrderByDescending(a => a.Createdate);
            return View(model);
        }

        public ActionResult Create()
        {
            var droplist = new List<Category>();
            droplist.Add(new Category()
            {
                
                Title = "Select Category",
            });
            droplist.AddRange(db.Categories.OrderBy(a => a.Title).ToList());
            ViewBag.CategoryNews = droplist;
            return View();
        }
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] News news)
        {
            if (ModelState.IsValid)
            {
                news.Createdate = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);

        }

        public ActionResult Edit(long? id)
        {

            var droplist = new List<Category>();
            droplist.Add(new Category()
            {

                Title = "Select Category",
            });
            droplist.AddRange(db.Categories.OrderBy(a => a.Title).ToList());
            ViewBag.CategoryNews = droplist;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] News news)
        {
            if (ModelState.IsValid)
            {
                news.Editdate = DateTime.Now;
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);

        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}