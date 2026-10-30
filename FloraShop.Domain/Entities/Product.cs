using FloraShop.Domain.Enums;

namespace FloraShop.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string? Description { get; private set; }

        public int Stock { get; private set; }

        public decimal Price { get; private set; }

        public DateTime InsertDate { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public ProductStatus Status { get; private set; }



        //Constructor
        public Product(string name, string? description, int stock, decimal price)
        {
            ValidateProductInfo(name, description, price);

            if (stock < 1)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be at least 1.");
        
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            Status = ProductStatus.Available;
            InsertDate = DateTime.UtcNow;
            UpdateDate = null;
        }



        public void Update(string name,string? description,int stock,decimal price)
        {
            ValidateProductInfo(name, description, price);

            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be negative.");

            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            Status = stock == 0
                ? ProductStatus.Unavailable
                : ProductStatus.Available;

            UpdateDate = DateTime.UtcNow;
        }



        private static void ValidateProductInfo(string name,string? description,decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.", nameof(name));

            if (name.Length > 50)
                throw new ArgumentException("Product name cannot exceed 50 characters.", nameof(name));

            if (description?.Length > 500)
                throw new ArgumentException("Description cannot exceed 500 characters.", nameof(description));

            if (price < 10000)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be at least 10,000 toman.");
        }



        public static Product Reconstitute(
            int id,
            string name,
            string? description,
            int stock,
            decimal price,
            DateTime insertDate,
            DateTime? updateDate,
            ProductStatus status)
        {
            return new Product
            {
                Id = id,
                Name = name,
                Description = description,
                Stock = stock,
                Price = price,
                InsertDate = insertDate,
                UpdateDate = updateDate,
                Status = status
            };
        }

        private Product()
        {
        }
    }
}

