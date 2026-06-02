using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public class BannerRepository:IBannerRepository
    {
        private readonly DapperContext _context;
        public BannerRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BannerDto>> GetBannerList()
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET TO LIST");
            var result = await connection.QueryAsync(
                "sp_Banner_CRUD",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            List<BannerDto> banners = new List<BannerDto>();
            foreach (var item in result)
            {
                int bannerId = item.BannerId;
                var existingBanner = banners.FirstOrDefault(x =>x.BannerId == bannerId);
                if(existingBanner == null)
                {
                    existingBanner = new BannerDto
                    {
                        BannerId = item.BannerId,
                        Banner = item.Banner,
                        Images = new List<string>()
                    };
                    banners.Add(existingBanner);
                }
                if (item.ImageData != null)
                {
                    existingBanner.Images.Add(item.ImageData.ToString());

                }
            }
            return banners;
        }
    }
}
