using System.ComponentModel.DataAnnotations;

namespace Devyt.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tài khoản không thể bỏ trống!")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không thể bỏ trống!")]
        public string Password { get; set; }
    }
}