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
    public class ServiceDemoController : Controller
    {
        private BHDTNEWSEntities db = new BHDTNEWSEntities();
        public ActionResult Index()
        {
            var model = db.ServiceDemoes.OrderByDescending(n => n.Createdate).ToList();
            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDemo serviceDemo = db.ServiceDemoes.Find(id);
            if (serviceDemo == null)
            {
                return HttpNotFound();
            }
            return View(serviceDemo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] ServiceDemo serviceDemo)
        {
            if (ModelState.IsValid)
            {
                serviceDemo.Editdate = DateTime.Now;
                db.Entry(serviceDemo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceDemo);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDemo serviceDemo = db.ServiceDemoes.Find(id);
            if (serviceDemo == null)
            {
                return HttpNotFound();
            }
            return View(serviceDemo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ServiceDemo serviceDemo = db.ServiceDemoes.Find(id);
            db.ServiceDemoes.Remove(serviceDemo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}