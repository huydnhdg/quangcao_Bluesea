using BHDTNEWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BHDTNEWS.Controllers
{
    [RoutePrefix("tin-tuc")]
    public class NewsController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        // GET: News
        [Route]
        public ActionResult News(int? page)
        {
            if (page == null) page = 1;

            //var news = (from n in db.Articles select n).OrderByDescending(a => a.Createdate);

            int pageSize = 9;

            int pageNumber = (page ?? 1);
            var news= db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View(newsList.ToPagedList(pageNumber, pageSize));
        }        

        [Route("{rewrite}")]
        public ActionResult NewsDetail(String rewrite)
        {
            Article article = db.Articles.Where(n => n.Link == rewrite).SingleOrDefault();

            String[] tags = new String[] { };
            string tags_str = article.tags;
            if (!String.IsNullOrEmpty(tags_str))
            {
                tags = tags_str.Split(',');
            }            
            ViewBag.tags = tags;

            var list = db.Articles.Where(n => n.CateId == 3).OrderByDescending(q => q.Createdate);
            ViewBag.oldNews = list.Where(d => d.Link != rewrite).Take (15).ToList();
            ViewBag.footerNews = list.Where(d => d.Link != rewrite).Take(4).ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View(article);
        }

        [Route("tin-lien-quan")]
        public ActionResult RelatedNews(int? page, String key)
        {
            if (page == null) page = 1;

            int pageSize = 9;

            int pageNumber = (page ?? 1);
            var news = db.Articles.Where(n => n.CateId == 3)
                .Where(l => l.FullContent.Contains(key) || l.ShortDescription.Contains(key))
                .OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();

            var newsFooter = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsFooterList = newsFooter.ToList();

            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsFooterList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            ViewBag.key = key;
            return View(newsList.ToPagedList(pageNumber, pageSize));
        }
    }
}