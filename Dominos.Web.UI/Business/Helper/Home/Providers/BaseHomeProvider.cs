using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Home;
using System.Collections.Generic;

namespace Dominos.Web.UI.Business.Helper.Home.Providers
{
    public class BaseHomeProvider : BaseProvider
    {
        public void FillProductsToModel(HomeViewModel model)
        {
            var url = $"{Config.DominosApiUrl}{Config.ProductServices.GetPizzas}";
            model.ProductList = HttpHelper.Get<ResponseEntity<List<ProductOutputDTO>>>(url).Result;
        }
    }
}