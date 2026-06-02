namespace Ecommerce_App.DTOs
{
    public class OtpRequestDto
    {
        public string MobileNo { get; set; }
    }
    public class OtpResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string OTP { get; set; }
    }
    public class OtpVerifyResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
