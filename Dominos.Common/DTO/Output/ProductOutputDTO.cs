namespace Dominos.Common.DTO.Output
{
    public class ProductOutputDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ProductOutputDTO Clone()
        {
            return (ProductOutputDTO)(MemberwiseClone());
        }
    }
}