using System.ComponentModel.DataAnnotations;

namespace ContactMgmtWebApplication.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}