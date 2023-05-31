using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Controllers
{
    public class HddtController : Controller
    {
        private int hddtId = 4;
        // GET: Hddt
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            Service seo = new ServiceDao().get_Service_ById(hddtId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.service = new ServiceDao().get_Service_ById(hddtId);
            ViewBag.SearchString = searchString;
            ViewBag.function = new FunctionDao().get_AllFunction_ById(hddtId);
            var model = new ItemServiceDao().ListAllPaging(hddtId, searchString, page, pageSize);//1 la sms brandname - 1 la page - 8 la pagesize
            return View(model);
        }
        public ActionResult Baogia()
        {
            Quote seo = new BaogiaDao().get_Baogia(hddtId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.itemservice = new ItemServiceDao().get_10_ById(hddtId);
            var model = new BaogiaDao().get_Baogia(hddtId);
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            ItemService seo = new ItemServiceDao().get_Item_in_Service(id, hddtId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.itemservice = new ItemServiceDao().get_10_ById(hddtId);
            var model = new ItemServiceDao().get_Item_in_Service(id, hddtId);
            return View(model);
        }
    }
}