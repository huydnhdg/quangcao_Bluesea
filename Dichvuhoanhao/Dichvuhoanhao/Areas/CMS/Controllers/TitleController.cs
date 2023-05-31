using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class TitleController : Controller
    {
        // GET: CMS/Title
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TitleDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Title/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Title/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Title/Create
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

        // GET: CMS/Title/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new TitleDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/Title/Edit/5
        [HttpPost]
        public ActionResult Edit(Title collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new TitleDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Title");
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

        // GET: CMS/Title/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CMS/Title/Delete/5
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
