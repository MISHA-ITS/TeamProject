using Microsoft.AspNetCore.Mvc;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Product;
using SPR311_DreamTeam_Rozetka.BLL.Services.Product;

namespace SPR311_DreamTeam_Rozetka.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            var response = await _productService.CreateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await _productService.DeleteAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto dto)
        {
            var response = await _productService.UpdateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _productService.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _productService.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
