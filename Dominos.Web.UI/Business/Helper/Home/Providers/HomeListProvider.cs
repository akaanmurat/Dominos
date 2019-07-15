using Dominos.Web.UI.Models.Home;

namespace Dominos.Web.UI.Business.Helper.Home.Providers
{
    public class HomeListProvider : BaseHomeProvider, IProvider<HomeViewModel>
    {
        public void Execute(HomeViewModel model)
        {
            FillProductsToModel(model);
        }
    }
}