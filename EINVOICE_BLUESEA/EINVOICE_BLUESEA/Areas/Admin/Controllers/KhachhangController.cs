using EINVOICE_BLUESEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Areas.Admin.Controllers
{
    public class KhachhangController : Controller
    {
        EINVOICE_BLUESEAEntities db = new EINVOICE_BLUESEAEntities();
        // GET: Admin/Khachhang
        public ActionResult Index()
        {
            var model = db.Khachhangs.OrderByDescending(a => a.Createdate);
            return View(model);
        }
    }
}