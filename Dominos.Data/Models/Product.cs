using System.ComponentModel.DataAnnotations;

namespace Dominos.Data.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int TypeId { get; set; }

        public bool IsActive { get; set; }
    }
}