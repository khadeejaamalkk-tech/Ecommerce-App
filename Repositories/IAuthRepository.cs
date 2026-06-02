using Ecommerce_App.DTOs;
using Ecommerce_App.Models;
namespace Ecommerce_App.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Login(string mobileNo);
        Task<OtpResponseDto> GenerateOtp(string mobileNo);
        Task<OtpVerifyResponseDto> VerifyOtp(string mobileNo, string otp);
    }
}
