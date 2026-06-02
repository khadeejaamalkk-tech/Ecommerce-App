using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface ISectionService
    {
        Task<ApiResponse<List<SectionListDto>>> GetSectionList(int userId);
    }
}
