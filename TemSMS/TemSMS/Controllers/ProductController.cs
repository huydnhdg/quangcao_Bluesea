using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemSMS.Models;

namespace TemSMS.Controllers
{
    [RoutePrefix("tin-tuc")]
    public class ProductController : Controller
    {
        private TemSMS.Models.TemSMSEntities db = new Models.TemSMSEntities();
        [Route("lap-trinh-chuong-trinh-khuyen-mai")]
        // GET: Product
        public ActionResult KM(int Id = 0, int StartPage = 0)
        {

            int Page = Id;
            int Perpage = 12;
            int Row = Page * Perpage;
            int count = db.Articles.Where(a => a.Product == "lap-trinh-chuong-trinh-khuyen-mai").Count();
            int DisplayPage = 12;
            ViewBag.Row = Row;
            ViewBag.SectionTitle = @"<a href=""/Home"">Home</a>";

            /**
                 * hien thi 1 luc 5 page
                 */
            int TotalPage = count / Perpage + (count % Perpage == 0 ? 0 : 1);
            String PagingHtml = String.Empty;
            if (Page == StartPage + DisplayPage - 1)
            {
                //tang giai page vd: 0-4 --> 4-8
                StartPage += DisplayPage - 1;
            }
            else if (Page == StartPage)
            {
                if (StartPage > DisplayPage - 1)
                {
                    StartPage -= DisplayPage - 1;
                }
                else
                {
                    StartPage = 0;
                }
            }

            for (int i = StartPage; i < DisplayPage + StartPage; i++)
            {
                if (TotalPage <= i)
                    break;
                String url = Url.Action("Index", new { Id = i, StartPage = StartPage });
                if (i == Page)
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}""><strong>{1}</strong></a></li>", url, (i + 1));
                }
                else
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}"">{1}</a></li>", url, (i + 1));
                }
            }

            ViewBag.PagingHtml = PagingHtml;
            ViewBag.Page = Id;
            var model = db.Articles.Where(a => a.Product == "lap-trinh-chuong-trinh-khuyen-mai").OrderByDescending(o => o.Time).Skip(Row).Take(12).ToList();

            return View(model);
        }
        [Route("tem-xac-thuc")]
        // GET: Product
        public ActionResult XT(int Id = 0, int StartPage = 0)
        {

            int Page = Id;
            int Perpage = 12;
            int Row = Page * Perpage;
            int count = db.Articles.Where(a => a.Product == "tem-xac-thuc").Count();
            int DisplayPage = 12;
            ViewBag.Row = Row;
            ViewBag.SectionTitle = @"<a href=""/Home"">Home</a>";

            /**
                 * hien thi 1 luc 5 page
                 */
            int TotalPage = count / Perpage + (count % Perpage == 0 ? 0 : 1);
            String PagingHtml = String.Empty;
            if (Page == StartPage + DisplayPage - 1)
            {
                //tang giai page vd: 0-4 --> 4-8
                StartPage += DisplayPage - 1;
            }
            else if (Page == StartPage)
            {
                if (StartPage > DisplayPage - 1)
                {
                    StartPage -= DisplayPage - 1;
                }
                else
                {
                    StartPage = 0;
                }
            }

            for (int i = StartPage; i < DisplayPage + StartPage; i++)
            {
                if (TotalPage <= i)
                    break;
                String url = Url.Action("Index", new { Id = i, StartPage = StartPage });
                if (i == Page)
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}""><strong>{1}</strong></a></li>", url, (i + 1));
                }
                else
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}"">{1}</a></li>", url, (i + 1));
                }
            }

            ViewBag.PagingHtml = PagingHtml;
            ViewBag.Page = Id;
            var model = db.Articles.Where(a => a.Product == "tem-xac-thuc").OrderByDescending(o => o.Time).Skip(Row).Take(12).ToList();

            return View(model);
        }
        [Route("bao-hanh-dien-tu")]
        // GET: Product
        public ActionResult BH(int Id = 0, int StartPage = 0)
        {

            int Page = Id;
            int Perpage = 12;
            int Row = Page * Perpage;
            int count = db.Articles.Where(a => a.Product == "bao-hanh-dien-tu").Count();
            int DisplayPage = 12;
            ViewBag.Row = Row;
            ViewBag.SectionTitle = @"<a href=""/Home"">Home</a>";

            /**
                 * hien thi 1 luc 5 page
                 */
            int TotalPage = count / Perpage + (count % Perpage == 0 ? 0 : 1);
            String PagingHtml = String.Empty;
            if (Page == StartPage + DisplayPage - 1)
            {
                //tang giai page vd: 0-4 --> 4-8
                StartPage += DisplayPage - 1;
            }
            else if (Page == StartPage)
            {
                if (StartPage > DisplayPage - 1)
                {
                    StartPage -= DisplayPage - 1;
                }
                else
                {
                    StartPage = 0;
                }
            }

            for (int i = StartPage; i < DisplayPage + StartPage; i++)
            {
                if (TotalPage <= i)
                    break;
                String url = Url.Action("Index", new { Id = i, StartPage = StartPage });
                if (i == Page)
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}""><strong>{1}</strong></a></li>", url, (i + 1));
                }
                else
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}"">{1}</a></li>", url, (i + 1));
                }
            }

            ViewBag.PagingHtml = PagingHtml;
            ViewBag.Page = Id;
            var model = db.Articles.Where(a => a.Product == "bao-hanh-dien-tu").OrderByDescending(o => o.Time).Skip(Row).Take(12).ToList();

            return View(model);
        }
        [Route]
        // GET: Product
        public ActionResult Index(int Id = 0, int StartPage = 0)
        {

            int Page = Id;
            int Perpage = 12;
            int Row = Page * Perpage;
            int count = db.Articles.Count();
            int DisplayPage = 12;
            ViewBag.Row = Row;
            ViewBag.SectionTitle = @"<a href=""/Home"">Home</a>";

            /**
                 * hien thi 1 luc 5 page
                 */
            int TotalPage = count / Perpage + (count % Perpage == 0 ? 0 : 1);
            String PagingHtml = String.Empty;
            if (Page == StartPage + DisplayPage - 1)
            {
                //tang giai page vd: 0-4 --> 4-8
                StartPage += DisplayPage - 1;
            }
            else if (Page == StartPage)
            {
                if (StartPage > DisplayPage - 1)
                {
                    StartPage -= DisplayPage - 1;
                }
                else
                {
                    StartPage = 0;
                }
            }

            for (int i = StartPage; i < DisplayPage + StartPage; i++)
            {
                if (TotalPage <= i)
                    break;
                String url = Url.Action("Index", new { Id = i, StartPage = StartPage });
                if (i == Page)
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}""><strong>{1}</strong></a></li>", url, (i + 1));
                }
                else
                {
                    PagingHtml += String.Format(@"<li><a href=""{0}"">{1}</a></li>", url, (i + 1));
                }
            }

            ViewBag.PagingHtml = PagingHtml;
            ViewBag.Page = Id;
            var model = db.Articles.OrderByDescending(o => o.Time).Skip(Row).Take(12).ToList();

            return View(model);
        }

        [Route("{rewrite}")]
        public ActionResult Article(String rewrite)
        {
            Article article = db.Articles.Where(n => n.Url == rewrite).SingleOrDefault();
            return View(article);
        }
    }
}