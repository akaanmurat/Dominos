using System;
using System.ComponentModel.DataAnnotations;

namespace Dominos.Data.Models
{
    public class Customer : BaseModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "İsim alanı 50 karakterden fazla olamaz.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Soyisim alanı 50 karakterden fazla olamaz.")]
        public string Surname { get; set; }

        [Required]
        [StringLength(19, ErrorMessage = "Telefon numarası alanı 19 karakter olmalıdır.", MinimumLength = 19)]
        [RegularExpression(@"(\([\+]90?\))(\s)([0-9]{3})(\s)([0-9]{3})(\s[0-9]{2})(\s[0-9]{2})")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email alanı 100 karakterden fazla olamaz.")]
        public string Email { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
