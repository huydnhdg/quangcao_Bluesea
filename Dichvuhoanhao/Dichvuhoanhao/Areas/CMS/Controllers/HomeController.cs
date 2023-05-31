using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class HomeController : BaseController
    {
        // GET: CMS/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}