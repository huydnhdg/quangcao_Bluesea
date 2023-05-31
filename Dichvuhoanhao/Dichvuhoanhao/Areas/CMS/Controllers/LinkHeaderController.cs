
using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class LinkHeaderController : BaseController
    {
        // GET: CMS/LinkHeader
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new LinkHeaderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/LinkHeader/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/LinkHeader/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/LinkHeader/Create
        [HttpPost]
        public ActionResult Create(LinkHeader collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new LinkHeaderDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "LinkHeader");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công.");
                    }
                }
            }
            catch { }
            return View();
        }

        // GET: CMS/LinkHeader/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new LinkHeaderDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/LinkHeader/Edit/5
        [HttpPost]
        public ActionResult Edit(LinkHeader collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new LinkHeaderDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "LinkHeader");
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

        // GET: CMS/LinkHeader/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CMS/LinkHeader/Delete/5
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
