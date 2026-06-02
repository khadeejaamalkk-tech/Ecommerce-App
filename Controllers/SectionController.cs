using Ecommerce_App.Models;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController:ControllerBase
    {
        private readonly ISectionService _service;
        public SectionController(ISectionService service)
        {
            _service = service;
        }
        [HttpGet("Get-SectionProducts")]
        [Authorize]
        public async Task<IActionResult> GetSectionList()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetSectionList(userId);
            return StatusCode(response.StatusCode, response);
        }

    }
}
