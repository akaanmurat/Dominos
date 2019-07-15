using System.ComponentModel.DataAnnotations;

namespace Dominos.Web.UI.Models.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        public string Password { get; set; }

        public string Validation { get; set; }
    }
}