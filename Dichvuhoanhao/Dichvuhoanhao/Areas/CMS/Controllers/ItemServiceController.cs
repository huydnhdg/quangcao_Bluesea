using Dichvuhoanhao.Common;
using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class ItemServiceController : BaseController
    {
        // GET: CMS/ItemService
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ItemServiceDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            SetViewBag();
            return View(model);
        }

        // GET: CMS/ItemService/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/ItemService/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: CMS/ItemService/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ItemService entity)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new ItemServiceDao();
                    long id = dao.Insert(entity);
                    if (id > 0)
                    {
                        SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "ItemService");
                    }
                   
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công.");
                    }
                }
                SetViewBag();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/ItemService/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new ItemServiceDao().ViewDetail(id);
            SetViewBag();
            return View(item);
        }

        // POST: CMS/ItemService/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ItemService entity)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new Entity.DaoCms.ItemServiceDao();
                    var result = dao.Update(entity);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "ItemService");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công.");
                    }
                }
                SetViewBag();
                return View(entity);
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/ItemService/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ItemServiceDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ItemServiceDao().ChangeStatus(id);
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
