using System.ComponentModel.DataAnnotations;

namespace Dominos.Common.DTO.Input
{
    public class LoginInputDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}