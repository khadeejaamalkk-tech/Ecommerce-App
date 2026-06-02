using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public interface ISectionRepository
    {
        Task<List<SectionListDto>> GetSectionList(int userId);
    }
}
