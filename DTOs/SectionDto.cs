namespace Ecommerce_App.DTOs
{
    public class SectionProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageData { get; set; }
        public bool IsWishlisted { get; set; }
        public bool IsCarted { get; set; }
    }
    public class SectionListDto
    {
       
        public string SectionName { get; set; }
        public List<SectionProductDto> Products { get; set; }
    }
}
