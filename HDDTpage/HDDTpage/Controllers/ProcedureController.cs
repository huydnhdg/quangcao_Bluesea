using HDDTpage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDDTpage.Controllers
{
    [RoutePrefix("quy-trinh")]
    public class ProcedureController : Controller
    {
        HDDTpage.Models.hoadondientuEntities db = new hoadondientuEntities();
        // GET: Procedure
        [Route]
        public ActionResult Index()
        {
            Article article = db.Articles.Where(p=>p.Type==3).FirstOrDefault();
            return View(article);
        }
    }
}