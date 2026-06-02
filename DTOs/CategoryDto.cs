namespace Ecommerce_App.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
    }
    public class CategoryRequestDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class CategoryResponseDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords  { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
