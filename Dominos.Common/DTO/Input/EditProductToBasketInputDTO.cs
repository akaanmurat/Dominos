namespace Dominos.Common.DTO.Input
{
    public class EditProductToBasketInputDTO
    {
        public int ProductId { get; set; }
        public int? CustomerId { get; set; }
        public string BasketKey { get; set; }
    }
}