namespace Dominos.Data.Models
{
    public class BasketDetail : BaseModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int BasketId { get; set; }
    }
}