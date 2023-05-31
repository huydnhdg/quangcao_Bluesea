using EINVOICE_BLUESEA.Models;
using EINVOICE_BLUESEA.Utils;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace EINVOICE_BLUESEA.Controllers
{
    [RoutePrefix("lien-he")]
    public class LienheController : Controller
    {
        EINVOICE_BLUESEAEntities db = new EINVOICE_BLUESEAEntities();
        private Logger logger = LogManager.GetCurrentClassLogger();
        [Route]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(String Name, String Email, String Phone, String TaxNumber, String CompanyWebsite,
            String EinvoiceAmountPerMonth, String Body)
        {
            string userIp = Request.UserHostAddress;
            logger.Info("IP: " + userIp);
            if (userIp == "5.188.84.119" || userIp == "5.188.84.115" || userIp.Contains("5.188."))
            {
                return RedirectToAction("Index");
            }
            try
            {
                var model = new Khachhang()
                {
                    Name = Name,
                    Email = Email,
                    Phone = Phone,
                    Taxcode = TaxNumber,
                    Company = CompanyWebsite,
                    Invoice = EinvoiceAmountPerMonth,
                    Note = Body,
                    Createdate = DateTime.Now
                };
                db.Khachhangs.Add(model);
                db.SaveChanges();

                new SendMail().SendInfo(model);

                ViewBag.message = "Đã gửi thông tin thành công, nhân viên CSKH sẽ liên hệ với bạn trong thời gian sớm nhất.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = "Gửi thông tin không thành công, hãy kiểm tra lại thông tin.";
            }

            return RedirectToAction("Index");
        }
    }
}