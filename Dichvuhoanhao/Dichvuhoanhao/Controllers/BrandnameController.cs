using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Controllers
{
    public class BrandnameController : Controller
    {
        private int brandId = 2;
        // GET: Brandname
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            Service seo = new ServiceDao().get_Service_ById(brandId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.service = new ServiceDao().get_Service_ById(brandId);
            ViewBag.SearchString = searchString;
            ViewBag.function = new FunctionDao().get_AllFunction_ById(brandId);
            var model = new ItemServiceDao().ListAllPaging(brandId, searchString, page, pageSize);//1 la sms brandname - 1 la page - 8 la pagesize
            return View(model);
        }
        public ActionResult Baogia()
        {
            Quote seo = new BaogiaDao().get_Baogia(brandId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.itemservice = new ItemServiceDao().get_10_ById(brandId);
            var model = new BaogiaDao().get_Baogia(brandId);
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            ItemService seo = new ItemServiceDao().get_Item_in_Service(id, brandId);
            ViewBag.des = seo.MetaDescription;
            ViewBag.title = seo.MetaTitle;
            ViewBag.itemservice = new ItemServiceDao().get_10_ById(brandId);
            var model = new ItemServiceDao().get_Item_in_Service(id, brandId);            
            return View(model);
        }
    }
}