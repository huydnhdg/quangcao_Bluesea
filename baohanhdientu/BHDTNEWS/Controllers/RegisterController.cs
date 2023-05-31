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
    [RoutePrefix("dang-ky")]
    public class RegisterController : Controller
    {
        BHDTNEWS.Models.BHDTNEWSEntities db = new Models.BHDTNEWSEntities();
        // GET: Register
        [Route]
        public ActionResult Register()
        {
            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();

            var packages = db.Packages.OrderBy(n => n.Id);
            List<Package> packagesList = packages.ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();

            return View(packagesList);
        }
        
        [Route("{id}")]
        public ActionResult RegisterForm(String id)
        {
            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderByDescending(n => n.Createdate);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();
            ViewBag.package_id = id;
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult SaveContactData(string name, string phone, string email, string company, string contact_note, string package_id)
        {
            Contact contact = new Contact();
            contact.FullName = name;
            contact.PhoneNumber = phone;
            contact.Email = email;
            contact.Company = company;
            contact.Note = contact_note;
            contact.Createdate = DateTime.Now;
            contact.PackageId = int.Parse(package_id);

            db.Contacts.Add(contact);
            db.SaveChanges();

            if (phone.Length != 0)
            {
                Package package = db.Packages.Where(n => n.Id == contact.PackageId).SingleOrDefault();
                ContentMail content = new ContentMail();
                content.name = name;
                content.phone = phone;
                content.email = email;
                content.company = company;
                content.contact_note = contact_note;
                content.package = package.Package1;
                SendMail(content);

                //return RedirectToAction("RegisterSuccess");
            }

            return RedirectToAction("RegisterSuccess");
        }
        
        [Route("cam-on")]
        public ActionResult RegisterSuccess()
        {
            var news = db.Articles.Where(n => n.CateId == 3).OrderByDescending(n => n.Createdate);
            List<Article> newsList = news.ToList();
            var videos = db.Videos.OrderBy(n => n.Id);
            List<Video> videosList = videos.ToList();
            ViewBag.footerVideos = videos.Take(4).ToList();
            ViewBag.footerNews = newsList.Take(4).ToList();
            var config = db.Configs.OrderBy(n => n.Id);
            ViewBag.config = config.SingleOrDefault();

            return View();
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
            public string name { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string company { get; set; }
            public string contact_note { get; set; }
            public string package { get; set; }
        }
        private void ConfigSendMail(string toEmail, ContentMail content)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);//mail khach hang
            mail.From = new MailAddress("baohanhdientu.vip@gmail.com");
            mail.Subject = "Khách hàng đăng ký - Bảo hành điện tử";
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
            Body.Append("<p>Khách hàng đăng ký</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Họ tên:</td><td>" + content.name + "</td></tr>");
            Body.Append("<tr><td>Số điện thoại:</td><td>" + content.phone + "</td></tr>");
            Body.Append("<tr><td>Email:</td><td>" + content.email + "</td></tr>");
            Body.Append("<tr><td>Tên công ty:</td><td>" + content.company + "</td></tr>");
            Body.Append("<tr><td>Ghi chú:</td><td>" + content.contact_note + "</td></tr>");
            Body.Append("<tr><td>Gói đăng ký:</td><td>" + content.package + "</td></tr>");
            Body.Append("</table>");
            return Body;
        }
    }
}