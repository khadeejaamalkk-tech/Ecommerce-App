using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;

namespace Ecommerce_App.Services
{
    public class BannerService:IBannerService
    {
        private readonly IBannerRepository _repository;
        public BannerService(IBannerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<IEnumerable<BannerDto>>> GetBannerList()
        {
            try
            {
                var banners = await _repository.GetBannerList();
                return ApiResponse<IEnumerable<BannerDto>>.Success(
                    banners, "Banners fetched successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<BannerDto>>.Fail(
                    $"Something went wrong: {ex.Message}");
            }
        }
    }
}
