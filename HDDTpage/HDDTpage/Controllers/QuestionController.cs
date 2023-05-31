using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDDTpage.Models;

namespace HDDTpage.Controllers
{
    [RoutePrefix("thac-mac")]
    public class QuestionController : Controller
    {
        HDDTpage.Models.hoadondientuEntities db = new Models.hoadondientuEntities();
        [Route]
        // GET: Question
        public ActionResult Index()
        {
            List<Article> questions = db.Articles.Where(q => q.Type == 1).ToList();
            return View(questions);
        }
        [Route("{rewrite}")]
        public ActionResult QuestionDetail(String rewrite)
        {
            Article article = db.Articles.Where(q => q.Url == rewrite).SingleOrDefault();

            /*get data more*/
            var list = db.Articles.Where(q => q.Type == 1).OrderBy(q => q.CreateDate);
            ViewBag.old = list.Where(d => d.Url != rewrite).Take(3).ToList();
            return View(article);
        }
    }
}