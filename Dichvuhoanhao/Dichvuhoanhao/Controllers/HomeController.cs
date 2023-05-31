using Dichvuhoanhao.Common;
using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Title title = new TitleDao().getTitle();
            ViewBag.title = title.Title1;
            ViewBag.keyword = title.Extra1;
            ViewBag.description = title.Extra2;
            ViewBag.video = new VideoDao().get_Video_in_Home();
            ViewBag.whyme = new WhymeDao().get_Whyme_in_Home();
            ViewBag.customer = new CustomerDao().get_Customer_in_Home();
            ViewBag.itemservice = new ItemServiceDao().get6Item();
            var service = new ServiceDao().get_Service_in_Home();
            return View(service);
        }
        public PartialViewResult LoadQuangcao()
        {
            return PartialView();
        }
        public PartialViewResult LoadSkype()
        {
            var model = new SkypeDao().get_Skype_in_Home();
            return PartialView(model);
        }
        public PartialViewResult LoadPartner()
        {
            var model = new PartnerDao().get_Partner_in_Home();
            return PartialView(model);
        }
        public PartialViewResult LoadSlider()
        {
            var model = new SliderDao().get_Slider_in_Home();
            return PartialView(model);
        }
        public PartialViewResult LoadTopMenu()
        {
            Title title = new TitleDao().getTitle();
            ViewBag.title = title.Title1;
            string fa = "facebook";
            string yo = "youtube";
            string sk = "skype";
            string g = "g-plus";
            ViewBag.yo = new LinkHeaderDao().get_LinkHeader(yo);
            ViewBag.sk = new LinkHeaderDao().get_LinkHeader(sk);
            ViewBag.g = new LinkHeaderDao().get_LinkHeader(g);
            var model = new LinkHeaderDao().get_LinkHeader(fa);
            return PartialView(model);
        }
        public PartialViewResult LoadMainMenu()
        {
            string sms = "sms";
            string icheck = "icheck";
            string hddt = "hddt";
            string dauso = "dauso";
            string digital = "digital";
            string cskh_3c = "cskh_3c";
            string contactCenter = "contactCenter";
            string callCenter = "callCenter";
            ViewBag.sms = new LinkHeaderDao().get_LinkHeader(sms);
            ViewBag.icheck = new LinkHeaderDao().get_LinkHeader(icheck);
            ViewBag.hddt = new LinkHeaderDao().get_LinkHeader(hddt);
            ViewBag.dauso = new LinkHeaderDao().get_LinkHeader(dauso);
            ViewBag.digital = new LinkHeaderDao().get_LinkHeader(digital);
            ViewBag.cskh3c = new LinkHeaderDao().get_LinkHeader(cskh_3c);
            ViewBag.contactCenter = new LinkHeaderDao().get_LinkHeader(contactCenter);
            ViewBag.callCenter = new LinkHeaderDao().get_LinkHeader(callCenter);
            return PartialView();
        }
        [HttpPost]
        public JsonResult Send(string name, string email, string phone, string service, string note)
        {
            var feedBack = new Feedback();
            feedBack.Name = name;
            feedBack.Email = email;
            feedBack.Phone = phone;
            feedBack.ServiceChose = service;
            feedBack.Note = note;
            feedBack.CreateDate = DateTime.Now;
            var id = new FeedbackDao().Insert(feedBack);
            if (id > 0)
            {
                //send mail
                try
                {
                    new SendMailHelper().SendMail(feedBack);
                }
                catch (Exception ex) { }

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
    }
}