using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;

namespace Ecommerce_App.Services
{
    public class SectionService: ISectionService
    {
        private readonly ISectionRepository _repository;
        public SectionService(ISectionRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<List<SectionListDto>>> GetSectionList(int userId)
        {
            try
            {
                var data = await _repository.GetSectionList(userId);
                return ApiResponse<List<SectionListDto>>.Success(data, "Section products fetched successfully");

            }
            catch (Exception ex)

            {
                return ApiResponse<List<SectionListDto>>.Fail(ex.Message);
            }
        }
    }
}
