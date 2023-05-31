using HDDTpage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDDTpage.Controllers
{
    [RoutePrefix("tin-tuc")]
    public class NewsController : Controller
    {
        HDDTpage.Models.hoadondientuEntities db = new Models.hoadondientuEntities();
        // GET: News
        [Route]
        public ActionResult Index()
        {
            List<Article> news = db.Articles.Where(n => n.Type == 4).OrderByDescending(n => n.CreateDate).ToList();
            return View(news);
        }
        [Route("{rewrite}")]
        public ActionResult NewsDetail(String rewrite)
        {
            Article article = db.Articles.Where(n => n.Url == rewrite).SingleOrDefault();
            /*get data more*/
            var list = db.Articles.Where(q => q.Type == 4).OrderBy(q => q.CreateDate);
            ViewBag.old = list.Where(d => d.Url != rewrite).Take(3).ToList();
            return View(article);
        }
    }
}