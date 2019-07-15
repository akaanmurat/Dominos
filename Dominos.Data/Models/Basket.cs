using System.Collections.Generic;

namespace Dominos.Data.Models
{
    public class Basket : BaseModel
    {
        public int? CustomerId { get; set; }
        public string BasketKey { get; set; }
    }
}