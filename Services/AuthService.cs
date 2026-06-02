using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;
using Ecommerce_App.Services;



namespace Ecommerce_App.Services
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly JwtService _jwtService;
        public AuthService(IAuthRepository repo, JwtService jwtService)
        {
            _repo = repo;
            _jwtService = jwtService;
        }
        public async Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto request)
        {
            var OtpResult = await _repo.VerifyOtp(request.MobileNo, request.Otp);
            if(OtpResult== null || OtpResult.Status== 0)
            {
                return ApiResponse<LoginResponseDto>.Fail("Invalid OTP");
            }
            var user = await _repo.Login(request.MobileNo);
            if(user == null)
            {
                return ApiResponse<LoginResponseDto>.Fail("User not found", 404);
            }
            var token =  _jwtService.GenerateJwtToken(user);
            var response = new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                MobileNo = user.MobileNo,
                Pin = user.Pin,
                Address1 = user.Address1,
                Address2 = user.Address1,
                Address3 = user.Address1,
                Token = token
            };
            return ApiResponse<LoginResponseDto>.Success(response, "Login successful");
        }
        public async Task<ApiResponse<OtpResponseDto>> GenerateOtp(string mobileNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mobileNo))
                    return ApiResponse<OtpResponseDto>.Fail("Mobile number is required");
                var result = await _repo.GenerateOtp(mobileNo);
                if (result == null || result.Status == 0)
                    return ApiResponse<OtpResponseDto>.Fail(result?.Message ?? "OTP generation failed");
                var response = new OtpResponseDto
                {
                    OTP = result.OTP
                };
                return ApiResponse<OtpResponseDto>.Success(response, result.Message);
            }
            catch (Exception ex) {
                return ApiResponse<OtpResponseDto>.Fail(ex.Message, 500);
            }

        }


    }
}
