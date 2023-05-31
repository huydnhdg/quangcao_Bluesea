using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class PartnerController : BaseController
    {
        // GET: CMS/Partner
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new PartnerDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Partner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Partner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Partner/Create
        [HttpPost]
        public ActionResult Create(Partner collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new PartnerDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Partner");
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

        // GET: CMS/Partner/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new PartnerDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/Partner/Edit/5
        [HttpPost]
        public ActionResult Edit(Partner collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new PartnerDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Partner");
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
            new PartnerDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new PartnerDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
