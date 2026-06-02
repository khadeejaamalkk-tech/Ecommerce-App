namespace Ecommerce_App.DTOs
{
    public class SalesDto
    {
    }
    public class OrderDashboardDto
    {
        public int Pending { get; set; }
        public int Accepted { get; set; }
        public int Billed { get; set; }
        public int Delivered { get; set; }
        public int Returned { get; set; }
        public int AllOrders { get; set; }

    }
    public class AllOrderListDto
    {
        public int OrderId { get; set; }

        public string Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public decimal GrandTotal { get; set; }
        public string SalesMan { get; set; }
        public string DeliveryPartner { get; set; }
    }
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }

        public string Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal GrandTotal { get; set; }
        public string SalesMan { get; set; }
        public string DeliveryPartner { get; set; }

        public List<OrderStatusDto> StatusHistory { get; set; }

        public List<OrderProductDto> Products { get; set; }
    }
    public class OrderStatusDto
    {
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    public class OrderProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageData { get; set; }
    }
    public class OrderStatusRequestDto
    {
        public string Status { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
    public class CustomerListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address1 { get; set; }
    }

}
