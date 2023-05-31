using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Areas.CMS.Models
{
    public class LoginModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}