using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public interface IUserRepository
    {
        Task<UpdateUserResponseDto> UpdateUser(int Id, UpdateUserRequestDto request, string photoPath);
    }
}
