using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController:ControllerBase
    {
        private readonly IBannerService _service;
        public BannerController(IBannerService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("Get-BannerList")]
        public async Task<IActionResult> GetBannerList()
        {
            var response = await _service.GetBannerList();
            return StatusCode(response.StatusCode,response);
        }
    }
}
