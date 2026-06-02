using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface IUserService
    {
        Task<ApiResponse<UpdateUserResponseDto>> UpdateUser(int Id, UpdateUserRequestDto request);
    }
}
