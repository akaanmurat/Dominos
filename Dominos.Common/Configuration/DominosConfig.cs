namespace Dominos.Common.Configuration
{
    public class DominosConfig
    {
        public string DominosApiUrl { get; set; }
        public ProductServiceUrl ProductServices { get; set; }
        public BasketServiceUrl BasketServices { get; set; }
    }

    public class ProductServiceUrl
    {
        public string GetPizzas { get; set; }
    }

    public class BasketServiceUrl
    {
        public string GetBasket { get; set; }
    }
}