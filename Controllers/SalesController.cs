using Ecommerce_App.DTOs;
using Ecommerce_App.Models;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController:ControllerBase
    {
        private readonly ISalesService _service;
        public SalesController(ISalesService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("Order-dashboard")]
        public async Task<IActionResult> GetOrderDashboard([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var response = await _service.GetOrderDashboard(userId, fromDate, toDate);

            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpGet("Get-AllOrders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] DateTime? fromDate, [FromQuery,] DateTime? toDate)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetAllOrders(userId, fromDate, toDate);
            return StatusCode(response.StatusCode,response);
        }
        [HttpGet("Order -details")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetOrderDetails(orderId, userId);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("Get-Order-Status")]
        [Authorize]
        public async Task<IActionResult> GetOrdersByStatus([FromBody] OrderStatusRequestDto request)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var response = await _service.GetOrdersByStatus(userId, request.Status,request.FromDate,request.ToDate);

            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("customer-list")]
        public async Task<IActionResult> GetCustomers()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetCustomers(userId);
            return Ok(response);
        }
    }
}
