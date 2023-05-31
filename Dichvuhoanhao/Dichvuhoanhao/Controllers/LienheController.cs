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
    public class LienheController : Controller
    {
        // GET: Lienhe
        public ActionResult Index()
        {
            var model = new FeedbackDao().get_Service_in_Lienhe();
            return View(model);
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