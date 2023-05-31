using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class QuoteController : BaseController
    {
        // GET: CMS/Quote
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new Entity.DaoCms.QuoteDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Quote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Quote/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost ValidateInput(false)]
        public ActionResult Create(Quote collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new QuoteDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Quote");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công.");
                    }
                }
                SetViewBag();
                return View();
            }
            catch { }
            return View();
        }

        // GET: CMS/Quote/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new QuoteDao().ViewDetail(id);
            SetViewBag();
            return View(item);
        }

        // POST: CMS/Quote/Edit/5
        [HttpPost ValidateInput(false)]
        public ActionResult Edit(Quote collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new QuoteDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Quote");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công.");
                    }
                }
                SetViewBag();
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
            new QuoteDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new QuoteDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public void SetViewBag(long? selected = null)
        {
            var dao = new ServiceDao();
            ViewBag.service = new SelectList(dao.get_Service_in_Home(), "Id", "Name", selected);
        }
    }
}
