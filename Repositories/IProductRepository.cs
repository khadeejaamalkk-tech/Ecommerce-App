using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public interface IProductRepository
    {
        Task<ProductResponseDto> GetProductList(ProductRequestDto request);
        Task<bool> AddToWishlist(int userId, int productId);
        Task<int> AddToCart(int userId, int productId,int quantity);
        Task<ProductDetailsDto> GetProductDetails(int productId);
        Task<int> RemoveFromCart(int userId, int productId);
        Task<int> RemoveFromWishlist(int userId, int productId);
        Task<IEnumerable<CartProductListDto>> GetCartProduct(int userId);
        Task<IEnumerable<WishlistProductListDto>> GetWishlistProducts(int userId);
        Task<IEnumerable<CheckoutProductDto>> Checkout(int userId, string customer,string salesMan);
    }
}
