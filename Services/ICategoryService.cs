using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface ICategoryService
    {
        Task<ApiResponse<CategoryResponseDto>> GetCategoryList(CategoryRequestDto request);


    }
}
