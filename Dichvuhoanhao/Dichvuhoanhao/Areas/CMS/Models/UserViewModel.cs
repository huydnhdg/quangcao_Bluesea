using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Areas.CMS.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName(Email)")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class EditViewModel
    {
        public long ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string FullName { set; get; }

        [Display(Name = "Kích hoạt")]
        public bool Status { set; get; }

        [Display(Name = "Phân Quyền")]
        [Required(ErrorMessage = "Yêu cầu chọn nhóm")]
        public string Role { set; get; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }
    }

    public class CreateViewModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string FullName { set; get; }

        [Display(Name = "Kích hoạt")]
        public bool Status { set; get; }

        [Display(Name = "Phân Quyền")]
        [Required(ErrorMessage = "Yêu cầu chọn nhóm")]
        public string Role { set; get; }
    }

    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu đang sử dụng")]
        public string OldPass { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPass { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPass", ErrorMessage = "2 Mật khẩu mới không giống nhau.")]
        [Display(Name = "Xác nhận mật khẩu mới")]
        public string ConfirmNewPass { get; set; }
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}