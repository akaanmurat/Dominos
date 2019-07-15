namespace Dominos.Data.Models
{
    public class OrderDetail : BaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public double ProductDiscountPrice { get; set; }
        public double DiscountValue { get; set; }
    }
}