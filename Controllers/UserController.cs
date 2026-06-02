using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController:ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPut("update-profile")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromForm]UpdateUserRequestDto request)
        {
            
            var userIdClaim = User.FindFirst("UserId");

            if (userIdClaim == null)
                return Unauthorized(ApiResponse<bool>.Fail("Invalid token"));

            int userId = int.Parse(userIdClaim.Value);

            
            var result = await _service.UpdateUser(userId, request);

            
            return StatusCode(result.StatusCode, result);
        }



    }
}
