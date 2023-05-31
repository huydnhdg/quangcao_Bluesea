using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: CMS/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CustomerDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Customer/Create
        [HttpPost]
        public ActionResult Create(Customer collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new CustomerDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Customer");
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

        // GET: CMS/Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new CustomerDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new CustomerDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Customer");
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
            new CustomerDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CustomerDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
