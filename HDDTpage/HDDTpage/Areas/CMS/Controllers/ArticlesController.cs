using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HDDTpage.Areas.CMS.Controllers
{
    //truong type 
    //1. thắc mắc
    //2. phản hồi
    //3. quy trình
    //4. tin tức

    public class ArticlesController : Controller
    {
        private HDDTpage.Models.hoadondientuEntities db = new Models.hoadondientuEntities();

        // GET: CMS/Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        public ActionResult testTable()
        {
            return View(db.Articles.ToList());
        }

        // GET: CMS/Articles/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDDTpage.Models.Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            //var listType = new[] { new SelectListItem() { Text = "Thắc mắc", Value = "1" }
            //                        , new SelectListItem() { Text = "Phản hồi", Value = "2" }
            //                        ,new SelectListItem() { Text = "Quy trình", Value = "3" }
            //                        , new SelectListItem() { Text = "Tin tức", Value = "4" }};
            //ViewBag.Type = listType.Where(p => p.Value == article.Type.ToString()).First().Text;

            return View(article);
        }

        // GET: CMS/Articles/Create
        public ActionResult Create()
        {
            var listType = new[] { new SelectListItem() { Text = "Thắc mắc", Value = "1" }
                                    , new SelectListItem() { Text = "Phản hồi", Value = "2" }
                                    ,new SelectListItem() { Text = "Quy trình", Value = "3" }
                                    , new SelectListItem() { Text = "Tin tức", Value = "4" }};
            ViewBag.Type = new SelectList(listType, "Value", "Text", "1");
            return View();
        }

        // POST: CMS/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Image,CreateDate,Alt,Url,Type,Text,IsActive,Tag")] HDDTpage.Models.Article article)
        {
            if (ModelState.IsValid)
            {
                article.CreateDate = DateTime.Now;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var listType = new[] { new SelectListItem() { Text = "Thắc mắc", Value = "1" }
                                    , new SelectListItem() { Text = "Phản hồi", Value = "2" }
                                    ,new SelectListItem() { Text = "Quy trình", Value = "3" }
                                    , new SelectListItem() { Text = "Tin tức", Value = "4" }};
            ViewBag.Type = new SelectList(listType, "Value", "Text", "1");
            return View(article);
        }

        // GET: CMS/Articles/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDDTpage.Models.Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            var listType = new[] { new SelectListItem() { Text = "Thắc mắc", Value = "1" }
                                    , new SelectListItem() { Text = "Phản hồi", Value = "2" }
                                    ,new SelectListItem() { Text = "Quy trình", Value = "3" }
                                    , new SelectListItem() { Text = "Tin tức", Value = "4" }};
            ViewBag.Type = new SelectList(listType, "Value", "Text", article.Type);
            return View(article);
        }

        // POST: CMS/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Image,CreateDate,Alt,Url,Type,Text,IsActive,Tag")] HDDTpage.Models.Article article)
        {
            if (ModelState.IsValid)
            {
                article.CreateDate = DateTime.Now;
                db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var listType = new[] { new SelectListItem() { Text = "Thắc mắc", Value = "1" }
                                    , new SelectListItem() { Text = "Phản hồi", Value = "2" }
                                    ,new SelectListItem() { Text = "Quy trình", Value = "3" }
                                    , new SelectListItem() { Text = "Tin tức", Value = "4" }};
            ViewBag.Type = new SelectList(listType, "Value", "Text", article.Type);
            return View(article);
        }

        // GET: CMS/Articles/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDDTpage.Models.Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: CMS/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HDDTpage.Models.Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
