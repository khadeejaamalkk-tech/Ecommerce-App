using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Ecommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost("Get-ProductList")]
        public async Task<IActionResult> GetProductList([FromBody] ProductRequestDto request)
        {
            var response = await _service.GetProductList(request);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpPost("Add-To-Wishlist")]
        public async Task<IActionResult> AddToWishlist(WishListRequestDto request)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.AddToWishlist(userId,request);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpPost("Add-To-Cart")]
        public async Task<IActionResult> AddToCart(CartRequestDto request)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.AddToCart(userId, request);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpGet("Get-ProductDetails")]
        public async Task<IActionResult> GetProductDetails(int productId)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetProductDetails(productId);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpDelete("Remove-From-Cart")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.RemoveFromCart(userId, productId);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpDelete("Remove-From-Wishlist")]
        public async Task<IActionResult> RemoveFromWishlist(int productId)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.RemoveFromWishlist(userId, productId);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpGet("Get-CartProducts")]
        public async Task<IActionResult> GetCartProduct()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetCartProduct(userId);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpGet("Get-WishlistProducts")]
        public async Task<IActionResult> GetWishlistProducts()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var response = await _service.GetWishlistProducts(userId);
            return StatusCode(response.StatusCode, response);
        }
        [Authorize]
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var salesMan=User.FindFirst(ClaimTypes.Name)?.Value;
            var response = await _service.Checkout(userId,request.Customer,salesMan);
            return StatusCode(response.StatusCode, response);
        }
    }




}
