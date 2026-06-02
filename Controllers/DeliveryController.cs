using Ecommerce_App.DTOs;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController:ControllerBase
    {
        private readonly IDeliveryService _service;
        public DeliveryController (IDeliveryService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost("deliver")]
        public async Task<IActionResult> DeliverOrder([FromBody] DeliverOrderRequestDto request)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var deliveryPartner = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var response=await _service.DeliverOrder(userId,deliveryPartner,role, request);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpPost("Return")]
        public async Task<IActionResult> ReturnOrder([FromBody] ReturnOrderRequestDto request)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var deliveryPartner = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var response = await _service.ReturnOrder(userId, deliveryPartner,role, request);
            return StatusCode(response.StatusCode, response);
        }

    }
}
