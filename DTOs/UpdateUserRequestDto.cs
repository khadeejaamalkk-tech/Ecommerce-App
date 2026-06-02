namespace Ecommerce_App.DTOs
{
    public class UpdateUserRequestDto
    {
        public string? Name { get; set; }
        public string? Pin { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public IFormFile? Photo { get; set; }
    }
    public class UpdateUserResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pin { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Photo { get; set; }

    }
}
