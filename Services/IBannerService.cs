using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface IBannerService
    {
        Task<ApiResponse<IEnumerable<BannerDto>>> GetBannerList();
    }
}
