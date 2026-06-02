using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public class SectionRepository:ISectionRepository
    {
        private readonly DapperContext _context;
        public SectionRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<SectionListDto>> GetSectionList(int userId)
            {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET SECTION LIST");
            parameters.Add("@UserId", userId);
            var result = await connection.QueryAsync(
                "sp_Sections_CRUD",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            var groupedData= result
                .GroupBy(x => x.SectionName)
                
                .Select(g => new SectionListDto
                {
                    
                    SectionName=g.Key,
                    Products=g.Select(p=> new SectionProductDto
                    {
                        ProductId=p.ProductId,
                        Name =p.Name,
                        Price=p.Price,
                        ImageData=p.ImageData,
                        IsWishlisted=p.IsWishlisted,
                        IsCarted=p.IsCarted
                    }).ToList()
                }).ToList();
            return groupedData;
        }
    }
}
