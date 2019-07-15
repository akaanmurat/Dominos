namespace Dominos.Data.Models
{
    public class Order : BaseModel
    {
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerAddress { get; set; }
    }
}