using Ecommerce_App.DTOs;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;

        }
        [Authorize]
        [HttpPost("Get-CategoryList")]
        public async Task<IActionResult> GetCategoryList([FromBody] CategoryRequestDto request)
        {
            var result = await _service.GetCategoryList(request);
            return StatusCode(result.StatusCode, result);
        }
    }
}
