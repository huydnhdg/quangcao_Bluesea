using BHDTNEWS.Areas.Admin.Models;
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
    public class ArticleController : Controller
    {
        private BHDTNEWSEntities db = new BHDTNEWSEntities();
        public ActionResult Index()
        {
            var model = from a in db.Articles
                        join b in db.NewsCates on a.CateId equals b.Id
                        select new ArticleViewModel()
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Link = a.Link,
                            ShortDescription = a.ShortDescription,
                            Image = a.Image,
                            CountView = a.CountView,
                            FullContent = a.FullContent,
                            Createdate = a.Createdate,
                            CateId = a.CateId,
                            CateName = b.Title,
                            tags = a.tags
                        };
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.CateId = new SelectList(db.NewsCates.ToList(), "Id", "Title", null);
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.Createdate = DateTime.Now;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);

        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateId = new SelectList(db.NewsCates.ToList(), "Id", "Title", id);
            return View(article);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}