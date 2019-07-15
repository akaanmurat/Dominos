using System.Collections.Generic;

namespace Dominos.Common.DTO.Output
{
    public class BasketOutputDTO
    {
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public List<BasketDetailOutputDTO> BasketDetails { get; set; }
    }
}