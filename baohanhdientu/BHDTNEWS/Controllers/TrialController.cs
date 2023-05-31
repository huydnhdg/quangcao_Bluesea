using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHDTNEWS.Models;
using System.Net.Mail;
using System.Text;

namespace BHDTNEWS.Controllers
{
    [RoutePrefix("dung-thu")]
    public class TrialController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        // GET: Trial
        [Route]
        public ActionResult Trial()
        {
            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            ViewBag.trial_form_phone = "";

            return View();
        }

        [HttpPost]        
        public ActionResult TrialDemo(string company, string product, string hotline, string product_code, string warranty_time)
        {
            ServiceDemo sd = new ServiceDemo();
            sd.ComName = company;
            sd.ProdName = product;
            sd.Hotline = hotline;
            sd.ProdCode = product_code;
            sd.TimeWarranti = warranty_time;
            sd.Createdate = DateTime.Now;

            db.ServiceDemoes.Add(sd);
            db.SaveChanges();

            if (hotline.Length != 0)
            {
                ContentMail content = new ContentMail();
                content.company = company;
                content.product = product;
                content.hotline = hotline;
                content.product_code = product_code;
                content.warranty_time = warranty_time;
                SendMail(content);
            }
            
            long id = sd.Id;

            return RedirectToAction("TrialDemo", new { id = id });
        }

        [Route("{id}")]
        public ActionResult TrialDemo(long id)
        {
            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();

            var serviceDemo = db.ServiceDemoes.Where(i => i.Id == id).SingleOrDefault();

            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();

            return View(serviceDemo);
        }
        
        private void SendMail(ContentMail content)
        {
            string email1 = "baohanh@bluesea.vn";
            ConfigSendMail(email1, content);
            string email2 = "xuanhung@bluesea.vn";
            ConfigSendMail(email2, content);
            string email3 = "nguyenthemanh201186@gmail.com";
            ConfigSendMail(email3, content);
            string email4 = "ngaptk@bluesea.vn";
            ConfigSendMail(email4, content);
            string email5 = "vinhhq@bluesea.vn";
            ConfigSendMail(email5, content);
        }
        public class ContentMail
        {
            public string company { get; set; }
            public string product { get; set; }
            public string hotline { get; set; }
            public string product_code { get; set; }
            public string warranty_time { get; set; }
        }
        private void ConfigSendMail(string toEmail, ContentMail content)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);//mail khach hang
            mail.From = new MailAddress("baohanhdientu.vip@gmail.com");
            mail.Subject = "Khách hàng dùng thử - Bảo hành điện tử";
            mail.Body = MailContent(content).ToString();//phan than mail
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("baohanhdientu.vip@gmail.com", "pdcibvjsyvyjoung");// tài khoản Gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private StringBuilder MailContent(ContentMail content)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Khách hàng dùng thử</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Tên thương hiệu:</td><td>" + content.company + "</td></tr>");
            Body.Append("<tr><td>Tên sản phẩm:</td><td>" + content.product + "</td></tr>");
            Body.Append("<tr><td>Hotline:</td><td>" + content.hotline + "</td></tr>");
            Body.Append("<tr><td>Mã sản phẩm trên tem:</td><td>" + content.product_code + "</td></tr>");
            Body.Append("<tr><td>Thời gian bảo hành:</td><td>" + content.warranty_time + " năm</td></tr>");
            Body.Append("</table>");
            return Body;
        }
    }
}