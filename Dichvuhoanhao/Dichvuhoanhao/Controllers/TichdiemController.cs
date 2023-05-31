using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoClient;

namespace Dichvuhoanhao.Controllers
{
    public class TichdiemController : Controller
    {
        private int cskh3CId = 8;
        // GET: CSKH_3C
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            Service seo = new ServiceDao().get_Service_ById(cskh3CId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.service = new ServiceDao().get_Service_ById(cskh3CId);
            ViewBag.SearchString = searchString;
            ViewBag.function = new FunctionDao().get_AllFunction_ById(cskh3CId);
            var model = new ItemServiceDao().ListAllPaging(cskh3CId, searchString, page, pageSize);//1 la sms brandname - 1 la page - 8 la pagesize
            return View(model);
        }

        public ActionResult Baogia()
        {
            Quote seo = new BaogiaDao().get_Baogia(cskh3CId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.itemservice = new ItemServiceDao().get_10_ById(cskh3CId);
            var model = new BaogiaDao().get_Baogia(cskh3CId);
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            ItemService seo = new ItemServiceDao().get_Item_in_Service(id, cskh3CId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.itemservice = new ItemServiceDao().get_10_ById(cskh3CId);
            var model = new ItemServiceDao().get_Item_in_Service(id, cskh3CId);
            return View(model);
        }
    }
}