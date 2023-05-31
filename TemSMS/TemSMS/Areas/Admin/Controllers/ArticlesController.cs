using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace TemSMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArticlesController : Controller
    {
        private TemSMS.Models.TemSMSEntities data = new Models.TemSMSEntities();
        // GET: Admin/Articles
        public ActionResult Index(String product)
        {
            if (product != null)
            {
                var model = data.Articles.Where(a => a.Product == product).OrderByDescending(a => a.Time).ToList();
                var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
                ViewBag.Product = new SelectList(listProduct, "Value", "Text", "lap-trinh-chuong-trinh-khuyen-mai");
                return View(model);
            }
            else
            {
                var model = data.Articles.OrderByDescending(a => a.Time).ToList();
                var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
                ViewBag.Product = new SelectList(listProduct, "Value", "Text", "lap-trinh-chuong-trinh-khuyen-mai");
                return View(model);
            }
            
        }

        // GET: Admin/Articles/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Article article = data.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
            ViewBag.Product = new SelectList(listProduct, "Value", "Text", "lap-trinh-chuong-trinh-khuyen-mai");
            return View();
        }

        // POST: Admin/Articles/Create
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Time,Text,Image,Product,Url,Tags")] TemSMS.Models.Article article)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    article.Time = DateTime.Now;
                    data.Articles.Add(article);
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }
                var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
                ViewBag.Product = new SelectList(listProduct, "Value", "Text", article.Product);
                return View(article);
            }
            catch
            {
                var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
                ViewBag.Product = new SelectList(listProduct, "Value", "Text", article.Product);
                return View(article);
            }
        }

        // GET: Admin/Articles/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Article article = data.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
            ViewBag.Product = new SelectList(listProduct, "Value", "Text", article.Product);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Time,Text,Image,Product,Url,Tags")] TemSMS.Models.Article article)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    article.Time = DateTime.Now;
                    data.Entry(article).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }
                var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
                ViewBag.Product = new SelectList(listProduct, "Value", "Text", article.Product);
                return View(article);
            }
            catch
            {
                var listProduct = new[] { new SelectListItem() { Text = "lập trình chương trình khuyến mãi", Value = "lap-trinh-chuong-trinh-khuyen-mai" }
                                    , new SelectListItem() { Text = "tem xác thực sms", Value = "tem-xac-thuc" }
                                    ,new SelectListItem() { Text = "bảo hành điện tử sms", Value = "bao-hanh-dien-tu" }};
                ViewBag.Product = new SelectList(listProduct, "Value", "Text", article.Product);
                return View(article);
            }
        }

        // GET: Admin/Articles/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Article article = data.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                // TODO: Add delete logic here
                TemSMS.Models.Article article = data.Articles.Find(id);
                data.Articles.Remove(article);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
