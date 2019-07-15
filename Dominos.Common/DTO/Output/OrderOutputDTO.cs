namespace Dominos.Common.DTO.Output
{
    public class OrderOutputDTO
    {
        public int OrderId { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}