using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Dichvuhoanhao.Common
{
    public class SendMailHelper
    {
        //sale.hoangsahotel @gmail.com
        //    54hoangsa56
        //phải tắt bảo mật trong gmail thì mới được
        public void SendMail(Feedback content)
        {
            var emailedit = new MailsystemDao().get_mail_edit();
            foreach (var item in emailedit)
            {
                ConfigSendMail(item.Email, content);
            }
        }
        private void ConfigSendMail(string toEmail, Feedback content)
        {
            var email = new MailsystemDao().get_mail_system();
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);//mail khach hang
            mail.From = new MailAddress(email.Email);
            mail.Subject = "Feedback Website quangcaohieuqua.com.vn";
            mail.Body = MailContent(content).ToString();// phần thân của mail ở trên
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(email.Email, email.Pass);// tài khoản Gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private StringBuilder MailContent(Feedback content)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Khách hàng đang chờ bạn tư vấn.</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Name:</td><td>" + content.Name + "</td></tr>");
            Body.Append("<tr><td>Email:</td><td>" + content.Email + "</td></tr>");
            Body.Append("<tr><td>Phone:</td><td>" + content.Phone + "</td></tr>");
            Body.Append("<tr><td>Service chose:</td><td>" + content.ServiceChose + "</td></tr>");
            Body.Append("<tr><td>Time:</td><td>" + content.CreateDate + "</td></tr>");
            Body.Append("<tr><td>Note:</td><td>" + content.Note + "</td></tr>");
            Body.Append("</table>");
            return Body;
        }
    }
}