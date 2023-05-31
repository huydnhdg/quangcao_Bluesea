using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Controllers
{
    [RoutePrefix("hoi-dap")]
    public class HoidapController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}