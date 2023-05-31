using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TemSMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SlideController : Controller
    {
        private TemSMS.Models.TemSMSEntities data = new Models.TemSMSEntities();
        // GET: Admin/Slide
        public ActionResult Index()
        {
            return View(data.Slides.OrderByDescending(a => a.Time).ToList());
        }

        // GET: Admin/Slide/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Slide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slide/Create
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Time,Alt,Title")] TemSMS.Models.Slide slide)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    slide.Time = DateTime.Now;
                    data.Slides.Add(slide);
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(slide);
            }
            catch
            {
                return View(slide);
            }
        }

        // GET: Admin/Slide/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Slide slide = data.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slide/Edit/5
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Time,Alt,Title")] TemSMS.Models.Slide slide)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    slide.Time = DateTime.Now;
                    data.Entry(slide).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(slide);
            }
            catch
            {
                return View(slide);
            }
        }

        // GET: Admin/Slide/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Slide slide = data.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                // TODO: Add delete logic here
                TemSMS.Models.Slide slide = data.Slides.Find(id);
                data.Slides.Remove(slide);
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
