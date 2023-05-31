using EINVOICE_BLUESEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace EINVOICE_BLUESEA.Utils
{
    public class SendMail
    {
        private string email = System.Configuration.ConfigurationManager.AppSettings["Email"];
        private string pass = System.Configuration.ConfigurationManager.AppSettings["Pass"];
        private string listemail = System.Configuration.ConfigurationManager.AppSettings["ListEmail"];
        public void SendInfo(Khachhang content)
        {
            string[] word = listemail.Split(';');
            foreach (var item in word)
            {
                if (item.Length > 5)
                    ConfigSendMail(item, content);
            }
        }
        private void ConfigSendMail(string toEmail, Khachhang content)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);//mail khach hang
            mail.From = new MailAddress(email);
            mail.Subject = "Feedback Website b-invoice.vn";
            mail.Body = MailContent(content).ToString();// phần thân của mail ở trên
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(email, pass);// tài khoản Gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private StringBuilder MailContent(Khachhang content)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Khách hàng đang chờ bạn tư vấn.</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Họ tên:</td><td>" + content.Name + "</td></tr>");
            Body.Append("<tr><td>Email:</td><td>" + content.Email + "</td></tr>");
            Body.Append("<tr><td>Số điện thoại:</td><td>" + content.Phone + "</td></tr>");
            Body.Append("<tr><td>Mã số thuế:</td><td>" + content.Taxcode + "</td></tr>");
            Body.Append("<tr><td>Công ty:</td><td>" + content.Company + "</td></tr>");
            Body.Append("<tr><td>Số hóa đơn hàng tháng:</td><td>" + content.Invoice + "</td></tr>");
            Body.Append("<tr><td>Ghi chú:</td><td>" + content.Note + "</td></tr>");
            Body.Append("<tr><td>Ngày yêu cầu:</td><td>" + content.Createdate + "</td></tr>");
            Body.Append("</table>");
            return Body;
        }
    }
}