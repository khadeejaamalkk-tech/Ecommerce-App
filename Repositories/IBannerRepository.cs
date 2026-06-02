using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public interface IBannerRepository
    {
        Task<IEnumerable<BannerDto>> GetBannerList();
    }
}
