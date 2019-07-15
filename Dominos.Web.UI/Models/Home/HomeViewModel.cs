using Dominos.Common.DTO.Output;
using System.Collections.Generic;

namespace Dominos.Web.UI.Models.Home
{
    public class HomeViewModel
    {
        public int AddedProductId { get; set; }
        public List<ProductOutputDTO> ProductList { get; set; } = new List<ProductOutputDTO>();
    }
}
