using System.ComponentModel.DataAnnotations;

namespace Dominos.Common.DTO.Input
{
    public class RegisterInputDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "İsim alanı 50 karakterden fazla olamaz.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Soyisim alanı 50 karakterden fazla olamaz.")]
        public string Surname { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email alanı 100 karakterden fazla olamaz.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}