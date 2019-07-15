using Dominos.Common.DTO.Output;
using System.Collections.Generic;

namespace Dominos.Web.UI.Models.Basket
{
    public class BasketViewModel
    {
        public BasketViewModel()
        {
            BasketDetails = new List<BasketDetailOutputDTO>();
        }

        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public List<BasketDetailOutputDTO> BasketDetails { get; set; }
        public int AddedProductId { get; set; }
    }
}