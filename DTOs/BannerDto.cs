namespace Ecommerce_App.DTOs
{
    public class BannerDto
    {
        public int BannerId { get; set; }
        public string Banner {get; set; }
        public List<string> Images { get; set; } = new();
    }
}
