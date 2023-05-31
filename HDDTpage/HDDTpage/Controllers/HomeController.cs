using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDDTpage.Models;
using HDDTpage.Models.ViewModel;
using System.Text;
using System.Net.Mail;

namespace HDDTpage.Controllers
{
    public class HomeController : Controller
    {
        /*ktdevsoft@gmail.com
         ktdevsoft9191*/
        HDDTpage.Models.hoadondientuEntities db = new Models.hoadondientuEntities();

        // GET: Home
        [Route]
        public ActionResult Index()
        {
            HomeModel Data = new HomeModel();
            /*get data slider*/
            //Data.Slider = db.Images.Where(i => i.Type == 1).ToList();
            /*get data question*/
            Data.Question = db.Articles.Where(q => q.Type == 1).OrderBy(q => q.CreateDate).ToList();
            /*get data customer*/
            Data.Customer = db.Articles.Where(c => c.Type == 2).OrderBy(c => c.CreateDate).ToList();
            return View(Data);
        }
        [HttpPost]
        public JsonResult Popup(string name, string phone, string email, string company, string text)
        {
            if (phone.Length != 0)
            {
                ContentMail content = new ContentMail();
                content.str = name;
                content.str1 = phone;
                content.str2 = email;
                content.str3 = company;
                content.str4 = text;
                SendMail(content);
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        [HttpPost]
        public JsonResult Contact(string name, string phone, string email, string company, string text)
        {
            if (phone.Length != 0)
            {
                ContentMail content = new ContentMail();
                content.str = name;
                content.str1 = phone;
                content.str2 = email;
                content.str3 = company;
                content.str4 = text;
                SendMail(content);
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        private void SendMail(ContentMail content)
        {
            string email = "ktdevsoft@gmail.com";
            ConfigSendMail(email, content);
            string email1 = "vthuyen@evnpt.vn";
            ConfigSendMail(email1, content);
            string email2 = "nguyenthemanh201186@gmail.com";
            ConfigSendMail(email2, content);
            string email3 = "ngaptk@bluesea.vn";
            ConfigSendMail(email3, content);
            string email4 = "vhuyen11@gmail.com";
            ConfigSendMail(email4, content);
        }
        public class ContentMail
        {
            public string str { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string str3 { get; set; }
            public string str4 { get; set; }
        }
        private void ConfigSendMail(string toEmail, ContentMail content)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);//mail khach hang
            mail.From = new MailAddress("hoadonvnpt24h@gmail.com");
            mail.Subject = "Phản hồi từ khách hàng - Hóa đơn điện tử";
            mail.Body = MailContent(content).ToString();//phan than mail
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("hoadonvnpt24h@gmail.com", "Manhha19861991");// tài khoản Gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private StringBuilder MailContent(ContentMail content)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Đăng ký ngay</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Họ và tên:</td><td>" + content.str + "</td></tr>");
            Body.Append("<tr><td>Điện thoại:</td><td>" + content.str1 + "</td></tr>");
            Body.Append("<tr><td>Công ty:</td><td>" + content.str4 + "</td></tr>");
            Body.Append("<tr><td>Email:</td><td>" + content.str2 + "</td></tr>");
            Body.Append("<tr><td>Ghi chú:</td><td>" + content.str3 + "</td></tr>");
            Body.Append("</table>");
            return Body;
        }
    }
}