using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHDTNEWS.Models;

namespace BHDTNEWS.Controllers
{
    [RoutePrefix("giai-phap")]
    public class SolutionController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        // GET: Solution
        [Route]
        public ActionResult Solution()
        {
            Article article = db.Articles.Where(n => n.CateId == 4).SingleOrDefault();
            //var articletList = new List<Article> { article };

            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View(article);
        }
    }
}