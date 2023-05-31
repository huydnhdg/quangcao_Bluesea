using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BHDTNEWS.Models;

namespace BHDTNEWS.Controllers
{
    [RoutePrefix("kenh-youtube")]
    public class YoutubeChannelController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        [Route]
        // GET: YoutubeChannel
        public ActionResult YoutubeChannel(int? page)
        {
            if (page == null) page = 1;

            int pageSize = 6;

            int pageNumber = (page ?? 1);
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            var newsList = db.Articles.Where(n => n.CateId == 3).OrderByDescending(cr => cr.Createdate);
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View(videosList.ToPagedList(pageNumber, pageSize));
        }

        [Route("{id}")]
        public ActionResult YoutubeChannelDetail(int? id)
        {
            Video video = db.Videos.Where(v => v.Id == id).SingleOrDefault();
            //var videotList = new List<Video> { video };
            var list = db.Videos.OrderBy(q => q.Id);
            ViewBag.oldVideos = list.Where(d => d.Id != id).OrderByDescending(n => n.Createdate).Take(2).ToList();
            ViewBag.footerVideos = list.Where(d => d.Id != id).OrderByDescending(n => n.Createdate).Take(4).ToList();
            var newsList = db.Articles.Where(n => n.CateId == 3).OrderByDescending(cr => cr.Createdate);
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View(video);
        }
    }
}