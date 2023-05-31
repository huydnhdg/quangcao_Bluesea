using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class VideoController : BaseController
    {
        // GET: CMS/Video
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new VideoDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Video/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Video/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Video/Create
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

        // GET: CMS/Video/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new VideoDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/Video/Edit/5
        [HttpPost]
        public ActionResult Edit(Video collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new VideoDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Video");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công.");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/Video/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CMS/Video/Delete/5
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
