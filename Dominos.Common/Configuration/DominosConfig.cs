﻿namespace Dominos.Common.Configuration
{
    public class DominosConfig
    {
        public string DominosApiUrl { get; set; }
        public ProductServiceUrl ProductServices { get; set; }
        public BasketServiceUrl BasketServices { get; set; }
        public CustomerServiceUrl CustomerServices { get; set; }
    }

    public class ProductServiceUrl
    {
        public string GetPizzas { get; set; }
    }

    public class BasketServiceUrl
    {
        public string GetBasket { get; set; }
        public string AddProductToBasket { get; set; }
        public string DecreaseProductFromBasket { get; set; }
        public string DeleteProductFromBasket { get; set; }
    }

    public class CustomerServiceUrl
    {
        public string GetCustomer { get; set; }
        public string Login { get; set; }
        public string Register { get; set; }
    }
}