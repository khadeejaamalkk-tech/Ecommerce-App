using Ecommerce_App.Helpers;
using Ecommerce_App.DTOs;

namespace Ecommerce_App.Services
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponseDto>> GetProductList(ProductRequestDto request);
        Task<ApiResponse<bool>> AddToWishlist(int userId, WishListRequestDto request);
        Task<ApiResponse<bool>> AddToCart(int userId, CartRequestDto request);
        Task<ApiResponse<ProductDetailsDto>> GetProductDetails(int productId);
        Task<ApiResponse<bool>> RemoveFromCart(int userId, int productId);
        Task<ApiResponse<bool>> RemoveFromWishlist(int userId, int productId);
        Task<ApiResponse<IEnumerable<CartProductListDto>>> GetCartProduct(int userId);
        Task<ApiResponse<IEnumerable<WishlistProductListDto>>> GetWishlistProducts(int userId);
        Task<ApiResponse<IEnumerable<CheckoutProductDto>>> Checkout(int userId,string customer, string salesMan);
    }
        
}
