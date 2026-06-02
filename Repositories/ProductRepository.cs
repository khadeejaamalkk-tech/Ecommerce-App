using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using System.Data;

namespace Ecommerce_App.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<ProductResponseDto> GetProductList (ProductRequestDto request)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET TO LIST");
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@CategoryId", request.CategoryId);
            var result = (await connection.QueryAsync(
                "sp_Product_CRUD",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure)).ToList();
           
            var products = result.Select(x=> new ProductDto
            {
                
                ProductId=x.ProductId,
                Name=x.Name,
                Price=x.Price,
                ImageData=x.ImageData,
            }).ToList();
            int totalRecords = result.Any() ? result.First().TotalRecords : 0;
            return new ProductResponseDto
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = result.First().TotalRecords,
                Products = products
            };
        }
        public async Task<bool> AddToWishlist(int userId, int productId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "ADD");
            parameters.Add("@UserId", userId);
            parameters.Add("@ProductId", productId);
            var result = await connection.QuerySingleOrDefaultAsync<int>(
                "sp_Wishlist",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            return result == 1;
        }
        public async Task<int> AddToCart(int userId, int productId,int quantity)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "ADD");
            parameters.Add("@UserId", userId);
            parameters.Add("@ProductId", productId);
            parameters.Add("@Quantity", quantity);
            var result = await connection.QuerySingleOrDefaultAsync<int>(
                "sp_Cart",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<ProductDetailsDto> GetProductDetails(int productId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "PRODUCT_DETAILS");
            parameters.Add("@ProductId", productId);
            using var multi = await connection.QueryMultipleAsync(
                "sp_Product_CRUD",
                parameters,
                commandType: CommandType.StoredProcedure);
            var product = await multi.ReadFirstOrDefaultAsync<ProductDetailsDto>();
            if(product != null)
            {
                var images = (await multi.ReadAsync<string>()).ToList();
                product.ImageData = images;
            }
            return product;
        }
        public async Task<int> RemoveFromCart(int userId,int productId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "REMOVE");
            parameters.Add("@UserId", userId);
            parameters.Add("@ProductId", productId);
            int rows = await connection.ExecuteScalarAsync<int>(
                "sp_Cart",
                parameters,
                commandType: CommandType.StoredProcedure);
            return rows;
        }
        public async Task<int> RemoveFromWishlist(int userId, int productId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "REMOVE");
            parameters.Add("@UserId", userId);
            parameters.Add("@ProductId", productId);
            int rows = await connection.ExecuteScalarAsync<int>(
                "sp_Wishlist",
                parameters,
                commandType: CommandType.StoredProcedure);
            return rows;
        }
        public async Task<IEnumerable<CartProductListDto>> GetCartProduct(int userId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "CART PRODUCT DETAILS");
            parameters.Add("@UserId", userId);
            var result = await connection.QueryAsync<CartProductListDto>(
                "sp_Cart",
                parameters,
                commandType:CommandType.StoredProcedure);
            return result;
        }
        public async Task<IEnumerable<WishlistProductListDto>> GetWishlistProducts(int userId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "WISHLIST PRODUCT DETAILS");
            parameters.Add("@UserId", userId);
            var result = await connection.QueryAsync<WishlistProductListDto>(
                "sp_Wishlist",
                parameters,
                commandType:CommandType.StoredProcedure);
            return result;
        }
        public async Task<IEnumerable<CheckoutProductDto>> Checkout(int userId,string customer,string salesMan)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "CHECK_OUT");
            parameters.Add("@UserId", userId);
            parameters.Add("@Customer", customer);
            parameters.Add("@SalesMan", salesMan);
            var result = await connection.QueryAsync<CheckoutProductDto>
            (
                "Sp_Order_CRUD",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;

        }


    }
            
    }

