namespace Ecommerce_App.DTOs
{
    public class DeliveryDto
    {
    }
    public class DeliverOrderRequestDto
    {
        public int OrderId { get; set; }
        public string Action { get; set; }
    }
    public class ReturnOrderRequestDto
    {
        public int OrderId { get; set; }
        public string Action { get; set; }
    }
}
