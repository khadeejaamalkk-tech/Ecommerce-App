namespace Ecommerce_App.DTOs
{
    public class LoginRequestDto
    {
        public string MobileNo { get; set; }
        public string Otp { get; set; }
    }
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Pin { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string? Token { get; set; }

    }
}
