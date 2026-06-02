using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryResponseDto> GetCategoryList(CategoryRequestDto request);

    }
}
