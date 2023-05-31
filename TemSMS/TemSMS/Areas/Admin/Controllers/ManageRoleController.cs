
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemSMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageRoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Admin/ManageRole
        public ActionResult Index()
        {
            var model = context.Roles.AsEnumerable();
            return View(model);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }
    }
}