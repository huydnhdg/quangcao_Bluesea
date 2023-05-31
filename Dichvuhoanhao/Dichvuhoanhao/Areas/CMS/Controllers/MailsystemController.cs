using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class MailsystemController : BaseController
    {
        // GET: CMS/Mailsystem
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MailsystemDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        // GET: CMS/Mailsystem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Mailsystem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Mailsystem/Create
        [HttpPost]
        public ActionResult Create(Mailsystem collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new MailsystemDao();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "Mailsystem");
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

        // GET: CMS/Mailsystem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CMS/Mailsystem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new MailsystemDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
