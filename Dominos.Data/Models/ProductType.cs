using System.ComponentModel.DataAnnotations;

namespace Dominos.Data.Models
{
    public class ProductType : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}