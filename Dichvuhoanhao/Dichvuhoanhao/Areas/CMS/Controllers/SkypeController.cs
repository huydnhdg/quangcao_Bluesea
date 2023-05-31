using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class SkypeController : BaseController
    {
        // GET: CMS/Skype
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SkypeDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Skype/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Skype/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Skype/Create
        [HttpPost]
        public ActionResult Create(Skype collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new SkypeDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Skype");
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

        // GET: CMS/Skype/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new SkypeDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/Skype/Edit/5
        [HttpPost]
        public ActionResult Edit(Skype collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new SkypeDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Skype");
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

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SkypeDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new SkypeDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
