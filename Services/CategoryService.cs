using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;

namespace Ecommerce_App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<CategoryResponseDto>> GetCategoryList(CategoryRequestDto request)
        {
            try
            {
                if (request == null)
                    return ApiResponse<CategoryResponseDto>.Fail("invalid request");
                if (request.PageNumber <= 0)
                    request.PageNumber = 1;
                if (request.PageSize <= 0)
                    request.PageSize = 10;
                var result = await _repository.GetCategoryList(request);
                return ApiResponse<CategoryResponseDto>.Success(result, "Categories fetched successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<CategoryResponseDto>.Fail($"Something went wrong: {ex.Message}", 500);

            }



        }
    }
}
