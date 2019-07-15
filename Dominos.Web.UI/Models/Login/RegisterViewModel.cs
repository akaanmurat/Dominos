using System.ComponentModel.DataAnnotations;

namespace Dominos.Web.UI.Models.Login
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email girilmesi zorunludur!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim girilmesi zorunludur!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim girilmesi zorunludur!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunludur!")]
        public string Password { get; set; }
    }
}