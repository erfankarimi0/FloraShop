namespace FloraShop.Application.DTOs.Products
{
    public class GetProductResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}