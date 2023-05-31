using EINVOICE_BLUESEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Controllers
{

    public class HomeController : Controller
    {
        EINVOICE_BLUESEAEntities db = new EINVOICE_BLUESEAEntities();

        [Route]
        public ActionResult Index()
        {
            var listnews = db.News.OrderBy(a => a.Sort).OrderByDescending(a => a.Createdate).Take(8);
            var listpartner = db.Partners.OrderByDescending(a => a.Title);
            HomeViewModel model = new HomeViewModel()
            {
                news = listnews.ToList(),
                partner = listpartner.ToList(),
            };
            return View(model);
        }

        public PartialViewResult loadHotline()
        {
            var config = db.Configs.SingleOrDefault();
            return PartialView(config);
        }

        public PartialViewResult loadFooter()
        {
            var config = db.Configs.SingleOrDefault();
            return PartialView(config);
        }

        public PartialViewResult loadEndNews()
        {
            var config = db.News.Where(a => a.Title.Length < 150).OrderByDescending(a => a.Createdate).Take(5);
            return PartialView(config);
        }

        public PartialViewResult loadPurble()
        {
            
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}