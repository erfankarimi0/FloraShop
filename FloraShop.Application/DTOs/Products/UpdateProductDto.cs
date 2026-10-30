using System.ComponentModel.DataAnnotations;

namespace FloraShop.Application.DTOs.Products
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "نام محصول الزامی است.")]
        [StringLength(50, ErrorMessage = "نام محصول نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "توضیحات محصول نمی‌تواند بیشتر از ۵۰۰ کاراکتر باشد.")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "موجودی نمی‌تواند منفی باشد.")]
        public int Stock { get; set; }

        [Range(typeof(decimal), "10000", "79228162514264337593543950335",
            ErrorMessage = "قیمت محصول باید حداقل ۱۰٬۰۰۰ تومان باشد.")]
        public decimal Price { get; set; }
    }
}