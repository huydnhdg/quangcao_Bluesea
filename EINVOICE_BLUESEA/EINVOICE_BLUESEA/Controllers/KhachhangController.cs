using EINVOICE_BLUESEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Controllers
{
    [RoutePrefix("khach-hang")]
    public class KhachhangController : Controller
    {
        EINVOICE_BLUESEAEntities db = new EINVOICE_BLUESEAEntities();
        [Route]
        public ActionResult Index()
        {
            var model = db.Partners;
            return View(model);
        }
    }
}