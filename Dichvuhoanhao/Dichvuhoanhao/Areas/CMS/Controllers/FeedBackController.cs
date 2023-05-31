using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class FeedBackController : BaseController
    {
        // GET: CMS/FeedBack
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FeedBackDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/FeedBack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/FeedBack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/FeedBack/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/FeedBack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CMS/FeedBack/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/FeedBack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CMS/FeedBack/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
