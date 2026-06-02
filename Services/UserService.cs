using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;
using System.Linq.Expressions;


namespace Ecommerce_App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<UpdateUserResponseDto>> UpdateUser(int Id, UpdateUserRequestDto request)
        {
            try
            {
                if (request == null)
                    return ApiResponse<UpdateUserResponseDto>.Fail("Invalid request");
                string photoPath = null;
                if (request.Photo != null && request.Photo.Length >0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    if(!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);
                    var filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Photo.CopyToAsync(stream);
                    }
                    photoPath = "https://localhost:7208/images/" + fileName; 
                }
                if (string.IsNullOrWhiteSpace(request.Name) &&
                    request.Pin == null &&
                    string.IsNullOrWhiteSpace(request.Address1) &&
                    string.IsNullOrWhiteSpace(request.Address2) &&
                    string.IsNullOrWhiteSpace(request.Address3) &&
                    photoPath == null)

                {
                    return ApiResponse<UpdateUserResponseDto>.Fail("No data provided to update");
                }
                var updateUser= await _repository.UpdateUser(Id, request,photoPath);
                if (updateUser== null)
                {
                    return ApiResponse<UpdateUserResponseDto>.Fail("update failed");
                }
                updateUser.Id = Id;
                updateUser.Success = true;
                updateUser.Message = "Profile updated successfully";
                return ApiResponse<UpdateUserResponseDto>.Success(updateUser, "Profile updated successfully");
               
            
            
            }
            catch (Exception ex) {
                return ApiResponse<UpdateUserResponseDto>.Fail("Something went wrong:" +ex.Message, 500);
            }
        }
    }
}
