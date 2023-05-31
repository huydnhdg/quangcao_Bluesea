using EINVOICE_BLUESEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Controllers
{
    [RoutePrefix("tin-tuc")]
    public class TintucController : Controller
    {
        EINVOICE_BLUESEAEntities db = new EINVOICE_BLUESEAEntities();
        [Route]
        public ActionResult Index(string keyword)
        {
            var model = db.News.OrderByDescending(a => a.Createdate).ToList();
            if (!String.IsNullOrEmpty(keyword))
            {
                model.Where(a => a.Title.Contains(keyword));
            }
            return View(model);
        }

        public ActionResult Search(string keyword)
        {
            var model = db.News.OrderByDescending(a => a.Createdate).ToList();
            if (!String.IsNullOrEmpty(keyword))
            {
                model.Where(a => a.Title.Contains(keyword));
            }
            return View(model);
        }

        [Route("{rewrite}")]
        public ActionResult Detail(string rewrite)
        {
            var model = db.News.Where(a => a.Alt == rewrite).SingleOrDefault();

            var listOld = db.News.Where(a => a.Cate_Id == model.Cate_Id && a.Id != model.Id).Take(10).ToList();
            ViewBag.listOld = listOld;
            return View(model);
        }


    }
}