namespace Ecommerce_App.DTOs
{
    public class ProductDto
    {

        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImageData { get; set; }

    }
    public class ProductRequestDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int CategoryId { get; set; }
    }
    public class ProductResponseDto
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int? TotalRecords { get; set; }
        public List<ProductDto> Products { get; set; }
    }
    public class WishListRequestDto
    {
        public int ProductId { get; set; }
    }
    public class CartRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public List<string> ImageData { get; set; } = new List<string>();
    }
    public class CartProductListDto
    {

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageData { get; set; }

        public int Quantity { get; set; }
    }
    public class WishlistProductListDto
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageData { get; set; }
    }
    public class CheckoutRequestDto
    {
        public string Customer { get; set; }
    }
    public class CheckoutProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
    }
   
   
}


