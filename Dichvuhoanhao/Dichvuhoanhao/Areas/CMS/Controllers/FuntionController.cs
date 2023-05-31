using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class FuntionController : BaseController
    {
        // GET: CMS/Funtion
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FuntionDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            SetViewBag();
            return View(model);
        }

        // GET: CMS/Funtion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Funtion/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: CMS/Funtion/Create
        [HttpPost ValidateInput(false)]
        public ActionResult Create(Function entity)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new FuntionDao();
                    long id = dao.Insert(entity);
                    if (id > 0)
                    {
                        SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Funtion");
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

        // GET: CMS/Funtion/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new FuntionDao().ViewDetail(id);
            SetViewBag();
            return View(item);
        }

        // POST: CMS/Funtion/Edit/5
        [HttpPost ValidateInput(false)]
        public ActionResult Edit(Function entity)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new Entity.DaoCms.FuntionDao();
                    var result = dao.Update(entity);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Funtion");
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

        // GET: CMS/Funtion/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FuntionDao().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selected = null)
        {
            var dao = new ServiceDao();
            ViewBag.service = new SelectList(dao.get_Service_in_Home(), "Id", "Name", selected);
        }
    }
}
