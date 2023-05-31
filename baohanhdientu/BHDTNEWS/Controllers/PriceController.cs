using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHDTNEWS.Models;

namespace BHDTNEWS.Controllers
{
    [RoutePrefix("bang-gia")]
    public class PriceController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        // GET: Price
        [Route]
        public ActionResult Price()
        {
            var packages = db.Packages.OrderBy(n => n.Id);
            List<Package> packagesList = packages.ToList();

            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = news.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View(packagesList);
        }
    }
}