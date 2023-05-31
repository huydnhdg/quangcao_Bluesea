using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TemSMS.Controllers
{
    public class DefaultController : Controller
    {
        private TemSMS.Models.TemSMSEntities db = new Models.TemSMSEntities();
        [Route]
        public ActionResult Index()
        {
            return View(db.Setupeds.OrderByDescending(a=>a.Time).ToList());
        }
        public PartialViewResult LoadSlider()
        {

            return PartialView(db.Slides.ToList());
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
            string email1 = "vinhtq@bluesea.vn";
            ConfigSendMail(email1, content);
            string email2 = "nguyenthemanh201186@gmail.com";
            ConfigSendMail(email2, content);
            string email3 = "ngaptk@bluesea.vn";
            ConfigSendMail(email3, content);
            string email4 = "quangvinh585@gmail.com";
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
            mail.From = new MailAddress("thuedauso.vn@gmail.com");
            mail.Subject = "Phản hồi từ khách hàng - TemSMS";
            mail.Body = MailContent(content).ToString();//phan than mail
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("thuedauso.vn@gmail.com", "Bongdapro");// tài khoản Gmail của bạn
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