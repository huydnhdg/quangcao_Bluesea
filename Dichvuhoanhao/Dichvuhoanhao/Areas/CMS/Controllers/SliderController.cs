using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class SliderController : BaseController
    {
        // GET: CMS/Slider
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SliderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Slider/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Slider/Create
        [HttpPost]
        public ActionResult Create(Slider collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new SliderDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Slider");
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

        // GET: CMS/Slider/Edit/5
        public ActionResult Edit(int id)
        {
            var item = new SliderDao().ViewDetail(id);
            return View(item);
        }

        // POST: CMS/Slider/Edit/5
        [HttpPost]
        public ActionResult Edit(Slider collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new SliderDao();
                    var result = dao.Update(collection);
                    if (result)
                    {
                        //SetAlert("Cập nhật thành công.", "success");
                        return RedirectToAction("Index", "Slider");
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
            new SliderDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
