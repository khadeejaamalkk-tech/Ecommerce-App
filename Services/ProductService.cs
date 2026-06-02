using Ecommerce_App.DTOs;
using Ecommerce_App.Repositories;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<ProductResponseDto>> GetProductList(ProductRequestDto request)
        {
            try
            {
                if (request == null)
                {
                    return ApiResponse<ProductResponseDto>.Fail("Invalid request");
                }
                if (request.PageNumber <= 0 || request.PageSize <= 0)
                {
                    return ApiResponse<ProductResponseDto>.Fail("Invalid Pagination value");
                }
                var result = await _repository.GetProductList(request);
                return ApiResponse<ProductResponseDto>.Success(result, "Product list fetched successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductResponseDto>.Fail(
                    $"Something went wrong: {ex.Message}");
            }
        }
        public async Task<ApiResponse<bool>> AddToWishlist(int userId, WishListRequestDto request)
        {
            try
            {
                if (request == null)
                    return ApiResponse<bool>.Fail("Invalid request");
                if (request.ProductId <= 0)
                    return ApiResponse<bool>.Fail("Invalid product");
                bool result = await _repository.AddToWishlist(userId, request.ProductId);
                if (!result)
                    return ApiResponse<bool>.Fail(
                        "Product already exists in wishlist");
                return ApiResponse<bool>.Success(true, "Product added to wishlist successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Something went wrong: {ex.Message}", 500);

            }
        }
        public async Task<ApiResponse<bool>> AddToCart(int userId, CartRequestDto request)
        {
            try
            {
                if (request == null)
                    return ApiResponse<bool>.Fail("Invalid request");
                if (request.ProductId <= 0)
                    return ApiResponse<bool>.Fail("Invalid product");
                if (request.Quantity <= 0)
                    return ApiResponse<bool>.Fail("Quantity must be greater than 0");
                int result = await _repository.AddToCart(userId, request.ProductId, request.Quantity);
                if (result == 1)
                {
                    return ApiResponse<bool>.Success(true, "Product added to cart successfully");

                }
                if (result == 2)
                {
                    return ApiResponse<bool>.Success(true, "Cart updated successfully");
                }
                return ApiResponse<bool>.Fail("Failed to add cart");

            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Something went wrong: {ex.Message}", 500);
            }
        }
        public async Task<ApiResponse<ProductDetailsDto>> GetProductDetails(int productId)
        {
            try
            {
                var product = await _repository.GetProductDetails(productId);
                if (product == null)
                {
                    return ApiResponse<ProductDetailsDto>.Fail("Product not found");
                }

                return ApiResponse<ProductDetailsDto>.Success(
                    product,
                    "Product details fetched successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductDetailsDto>.Fail(ex.Message);
            }

        }
        public async Task<ApiResponse<bool>> RemoveFromCart(int userId, int productId)
        {
            try
            {
                var result = await _repository.RemoveFromCart(userId, productId);
                if (result > 0)
                    return ApiResponse<bool>.Success(true, "product removed from cart");
                return ApiResponse<bool>.Fail("Item is not in the cart");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }
        public async Task<ApiResponse<bool>> RemoveFromWishlist(int userId, int productId)
        {
            var result = await _repository.RemoveFromWishlist(userId, productId);

            if (result > 0)
            {
                return ApiResponse<bool>.Success(
                    true,
                    "Product removed from wishlist successfully");
            }

            return ApiResponse<bool>.Fail(
                "Item is not in the wishlist");
        }
        public async Task<ApiResponse<IEnumerable<CartProductListDto>>> GetCartProduct(int userId)
        {
            try
            {


                var result = await _repository.GetCartProduct(userId);
                if (result == null || !result.Any())
                {
                    return ApiResponse<IEnumerable<CartProductListDto>>.Fail("Cart is empty");
                }
                return ApiResponse< IEnumerable<CartProductListDto>>.Success(result, "Products fetched successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse< IEnumerable<CartProductListDto>>.Fail(ex.Message);
            }
        }
        public async Task<ApiResponse<IEnumerable<WishlistProductListDto>>> GetWishlistProducts(int userId)
        {
            try
            {
                var result = await _repository.GetWishlistProducts(userId);
                if (result == null || !result.Any())
                {
                    return ApiResponse<IEnumerable<WishlistProductListDto>>.Fail("Wishlist is empty");
                }
                return ApiResponse<IEnumerable<WishlistProductListDto>>.Success(result, "Products fetched successfully");

            }
            catch(Exception ex)
            {
                return ApiResponse<IEnumerable<WishlistProductListDto>>.Fail(ex.Message);
            }
        }
        public async Task<ApiResponse<IEnumerable<CheckoutProductDto>>> Checkout(int userId,string customer,string salesMan)
        {
            try
            {
                var result = await _repository.Checkout(userId,customer,salesMan);
                if (result == null || !result.Any())
                {
                    return ApiResponse<IEnumerable<CheckoutProductDto>>
                        .Fail("No products in cart");
                }

                return ApiResponse<IEnumerable<CheckoutProductDto>>
                    .Success(result, "Checkout successful");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CheckoutProductDto>>
                    .Fail(ex.Message);
            }
        }

    }
}