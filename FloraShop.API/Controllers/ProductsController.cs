using FloraShop.Application.DTOs.Products;
using FloraShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FloraShop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        await _productService.CreateAsync(dto);

        return Ok("محصول با موفقیت ثبت شد.");
    }

    // Read All
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }

    // Read By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
            return NotFound("محصول موردنظر یافت نشد.");

        return Ok(product);
    }

    // Update
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto)
    {
        try
        {
            await _productService.UpdateAsync(id, dto);

            return Ok("محصول با موفقیت ویرایش شد.");
        }
        catch (Exception ex) when (ex.Message == "محصول موردنظر یافت نشد.")
        {
            return NotFound(ex.Message);
        }
    }
}