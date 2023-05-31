using Dichvuhoanhao.Entity.DaoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string keywords)
        {
            int page = 1;
            int pageSize = 10;
            var dao = new ItemServiceDao();
            var model = dao.Search(keywords, page, pageSize);

            ViewBag.SearchString = keywords;
            return View(model);
        }
    }
}