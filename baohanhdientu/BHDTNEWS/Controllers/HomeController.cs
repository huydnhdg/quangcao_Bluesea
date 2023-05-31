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
    /*[RoutePrefix("Index")]*/
    public class HomeController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        [Route]
        public ActionResult Index()
        {
            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = news.Take(4).ToList();

            var packages = db.Packages.OrderBy(n => n.Id);
            ViewBag.packagesList = packages.ToList();

            var banners = db.Banners.OrderBy(n => n.Id);
            ViewBag.bannersList = banners.ToList();

            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();

            return View();
        }

        [HttpPost]
        public ActionResult TrialForm(string phone)
        {
            /*Contact contact = new Contact();
            contact.PhoneNumber = phone;
            contact.Createdate = DateTime.Now;
            db.Contacts.Add(contact);
            db.SaveChanges();

            if (phone.Length != 0)
            {
                ContentMail content = new ContentMail();
                content.phone = phone;
                SendMail(content);
            }            

            return RedirectToAction("Index", new { success = "success" });*/

            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            ViewBag.trial_form_phone = phone;

            return View("~/Views/Trial/Trial.cshtml");
        }

        private void SendMail(ContentMail content)
        {
            string email1 = "baohanh@bluesea.vn";
            ConfigSendMail(email1, content);
            string email2 = "xuanhung@bluesea.vn";
            ConfigSendMail(email2, content);
            string email3 = "nguyenthemanh201186@gmail.com";
            ConfigSendMail(email3, content);
            string email4 = "vinhhq@bluesea.vn";
            ConfigSendMail(email4, content);
        }
        public class ContentMail
        {
            public string phone { get; set; }
        }
        private void ConfigSendMail(string toEmail, ContentMail content)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);//mail khach hang
            mail.From = new MailAddress("baohanhdientu.vip@gmail.com");
            mail.Subject = "Khách hàng liên hệ - Bảo hành điện tử";
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
            Body.Append("<p>Khách hàng liên hệ</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Điện thoại:</td><td>" + content.phone + "</td></tr>");
            Body.Append("</table>");
            return Body;
        }
    }
}