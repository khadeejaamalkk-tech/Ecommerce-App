using Ecommerce_App.DTOs;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _service.Login(request);
            return StatusCode(result.StatusCode,result);
        }
        [AllowAnonymous]
        [HttpPost("Otp")]
        public async Task<IActionResult> GenerateOtp (string mobileNo)
        {
            var response= await _service.GenerateOtp(mobileNo);
            return StatusCode(response.StatusCode,response);
        }
         
    }
}
