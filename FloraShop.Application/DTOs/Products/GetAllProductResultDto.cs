namespace FloraShop.Application.DTOs.Products
{
    public class GetAllProductResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}