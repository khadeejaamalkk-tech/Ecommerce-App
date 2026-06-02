using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;
using Ecommerce_App.Models;
using Ecommerce_App.Repositories;
using System.Data;
using static System.Net.WebRequestMethods;


namespace Ecommerce_App.Repositories
{
    public class AuthRepository: IAuthRepository

    {
        private readonly DapperContext _context;
        public AuthRepository(DapperContext context)
        { 
            _context = context;
        }
        public async Task<User> Login(string mobileNo)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "LOGIN");
            parameters.Add("@MobileNo", mobileNo);

            var user = await connection.QuerySingleOrDefaultAsync<User>(
                "dbo.sp_Registration_CRUD",
                parameters,
                commandType: CommandType.StoredProcedure)
                ;
            return user;
        }
        public async Task<OtpResponseDto> GenerateOtp(string mobileNo)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GENERATE");
            parameters.Add("@MobileNo", mobileNo);

            var result = await connection.QuerySingleOrDefaultAsync<OtpResponseDto>(
                "dbo.sp_VerifyOTP",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result;

        }
        public async Task<OtpVerifyResponseDto> VerifyOtp(string mobileNo, string Otp)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "VERIFY");
            parameters.Add("@MobileNo", mobileNo);
            parameters.Add("@OTP", Otp);

            var result = await connection.QuerySingleOrDefaultAsync<OtpVerifyResponseDto>(
                "dbo.sp_VerifyOTP",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
