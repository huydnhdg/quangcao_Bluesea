using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace HDDTpage.Areas.CMS.Controllers
{
    public class LoginController : Controller
    {
        public static HDDTpage.Models.hoadondientuEntities db = new Models.hoadondientuEntities();
        // GET: CMS/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String email, String password)
        {

            if (ModelState.IsValid)
            {
                //var admin = db.Admins.Where(i => i.Email == email);
                //if (admin != null && admin.Count() > 0)
                //{
                //    if (admin.First().Password.Equals(GetMd5Hash(password))) {
                //        Session["username"] = email;
                //        return RedirectToAction("Index", "Articles");
                //    }

                //}
                
                    var result = checkLogin(email, GetMd5Hash(password));
                    if (result == 1)
                    {
                        Session["username"] = email;
                        return RedirectToAction("Index", "Articles");
                    }
                    else if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    }
                    else if (result == -1)
                    {
                        ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                    }

                    else if (result == -2)
                    {
                        ModelState.AddModelError("", "Mật khẩu không đúng.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng");
                    }

            }
                return View("Login");
        }

        public static int checkLogin(String email, String password)
        {
            var result = db.Admins.SingleOrDefault(x => x.Email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}