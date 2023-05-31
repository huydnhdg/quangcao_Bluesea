using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemSMS.Controllers
{
    public class SearchController : Controller
    {
        private TemSMS.Models.TemSMSEntities db = new Models.TemSMSEntities();
        [Route("tim-kiem")]
        // GET: Search
        public ActionResult Index(string keywords)
        {
            var model = db.Articles.Where(a => a.Title.Contains(keywords)).OrderByDescending(b => b.Time).ToList();
            return View(model);
        }
    }
}