using Dichvuhoanhao.Areas.CMS.Models;
using Dichvuhoanhao.Common;
using Dichvuhoanhao.Entity;
using Dichvuhoanhao.Entity.DaoCms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dichvuhoanhao.Areas.CMS.Controllers
{
    public class UserController : BaseController
    {
        // GET: CMS/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: CMS/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/User/Create
        public ActionResult Create()
        {
            CreateViewModel model = null;
            SetupRole(model);
            return View(model);
        }

        // POST: CMS/User/Create
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Usercm user = new Usercm();
                    var session = (UserLogin)Session[CommonConstant.USER_SESSION];
                    var dao = new UserDao();
                    var encryptedMD5Pass = Encryptor.MD5Hash(model.Password);
                    user.Password = encryptedMD5Pass;
                    user.UserName = model.UserName;
                    user.Role = model.Role;
                    user.Status = model.Status;
                    user.FullName = model.FullName;
                    long id = dao.Insert(user);
                    if (id > 0)
                    {
                        //SetAlert("Thêm thành công.", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công.");
                    }
                }
            }
            catch { }
            SetupRole(model);
            return View();
        }

        // GET: CMS/User/Edit/5
        public ActionResult Edit(long id)
        {
            var u = new UserDao().ViewDetail(id);
            EditViewModel model = new EditViewModel();
            model.ID = u.Id;
            model.FullName = u.FullName;
            model.UserName = u.UserName;
            model.Status = u.Status;
            model.Role = u.Role;
            model.Password = null;
            model.ConfirmPassword = null;
            SetupRoleEdit(model);
            return View(model);
        }

        // POST: CMS/User/Edit/5
        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Usercm u = new Usercm();
                    u.Id = model.ID;
                    u.FullName = model.FullName;
                    u.UserName = model.UserName;
                    u.Status = model.Status;
                    u.Role = model.Role;
                    var session = (UserLogin)Session[CommonConstant.USER_SESSION];
                    var dao = new UserDao();
                    var result = dao.Update(u);
                    if (result)
                    {
                        //SetAlert("cập nhật thành công.", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công.");
                    }
                }
            }
            catch { }
            SetupRoleEdit(model);
            return View();
        }
        [HttpDelete]
        // GET: CMS/User/Delete/5
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        private void SetupRole(CreateViewModel a)
        {
            List<Property> ListRole = new List<Property>();
            //if (a == null)
            //{
            //    ListRole.Add(new Property() { Name = "Biên tập viên", Value = "Editor" });
            //}
            ListRole.Add(new Property() { Name = "Biên tập viên", Value = "Editor" });
            ListRole.Add(new Property() { Name = "Quản trị viên", Value = "Administrator" });
            ListRole.Add(new Property() { Name = "Quản lý nội dung", Value = "Manager" });

            if (a != null)
            {
                ViewBag.Role = new SelectList(ListRole, "Value", "Name", a.Role);
            }
            else
                ViewBag.Role = new SelectList(ListRole, "Value", "Name");
        }

        private void SetupRoleEdit(EditViewModel a)
        {
            List<Property> ListRole = new List<Property>();
            //if (a == null)
            //{
            //    ListRole.Add(new Property() { Name = "Chọn nhóm cho tài khoản", Value = "" });
            //}
            ListRole.Add(new Property() { Name = "Quản trị viên", Value = "Administrator" });
            ListRole.Add(new Property() { Name = "Quản lý nội dung", Value = "Manager" });
            ListRole.Add(new Property() { Name = "Biên tập viên", Value = "Editor" });
            if (a != null)
            {
                ViewBag.Role = new SelectList(ListRole, "Value", "Name", a.Role);
            }
            else
                ViewBag.Role = new SelectList(ListRole, "Value", "Name");
        }
    }
}
