using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TemSMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SetupedController : Controller
    {
        private TemSMS.Models.TemSMSEntities data = new Models.TemSMSEntities();
        // GET: Admin/Setuped
        public ActionResult Index()
        {
            return View(data.Setupeds.OrderByDescending(a => a.Time).ToList());
        }

        // GET: Admin/Setuped/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Setuped/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Setuped/Create
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Title,Time,Url")] TemSMS.Models.Setuped setup)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    setup.Time = DateTime.Now;
                    data.Setupeds.Add(setup);
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(setup);
            }
            catch
            {
                return View(setup);
            }
        }

        // GET: Admin/Setuped/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Setuped setup = data.Setupeds.Find(id);
            if (setup == null)
            {
                return HttpNotFound();
            }
            return View(setup);
        }

        // POST: Admin/Setuped/Edit/5
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Title,Time,Url")] TemSMS.Models.Setuped setup)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    setup.Time = DateTime.Now;
                    data.Entry(setup).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(setup);
            }
            catch
            {
                return View(setup);
            }
        }

        // GET: Admin/Setuped/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemSMS.Models.Setuped setup = data.Setupeds.Find(id);
            if (setup == null)
            {
                return HttpNotFound();
            }
            return View(setup);
        }

        // POST: Admin/Setuped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                // TODO: Add delete logic here
                TemSMS.Models.Setuped setup = data.Setupeds.Find(id);
                data.Setupeds.Remove(setup);
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
