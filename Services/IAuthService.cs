using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto request);
        Task<ApiResponse<OtpResponseDto>> GenerateOtp(string mobileNo);
    }
}
